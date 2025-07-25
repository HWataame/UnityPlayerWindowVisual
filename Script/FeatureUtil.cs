/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
HW.UnityPlayerWindowVisualパッケージの機能に関する処理を保持するクラス

FeatureUtil.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using AOT;
using HW.UnityPlayerWindowVisual.Libraries;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace HW.UnityPlayerWindowVisual
{
    /// <summary>
    /// HW.UnityPlayerWindowVisualパッケージの機能に関する処理を保持するクラス
    /// </summary>
    public static class FeatureUtil
    {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        /// <summary>
        /// 処理を許可するか
        /// </summary>
        private static readonly bool isAllowProcess;
        /// <summary>
        /// SetWindowColorCallbackのデリゲートのキャッシュ
        /// </summary>
        private static readonly User32Wrapper.SingleEnumWindowsProc SetWindowColorCallbackCache;
#endif

        /// <summary>
        /// ログを出力するか
        /// </summary>
        private static bool isOutputLog;

        /// <summary>
        /// ログを出力するか
        /// </summary>
        public static bool IsOutputLog
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => isOutputLog;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => isOutputLog = value;
        }


        /// <summary>
        /// 初期化処理
        /// </summary>
        static FeatureUtil()
        {
            // ログ出力を有効化する
            isOutputLog = true;

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            // 現在の環境がWindowsのスタンドアロンプレイヤーか判定する
            isAllowProcess = Application.platform == RuntimePlatform.WindowsPlayer;

            // SetWindowColorCallbackのデリゲートをキャッシュする
            SetWindowColorCallbackCache = SetWindowColorCallback;
#endif
        }

        /// <summary>
        /// ウィンドウの色を設定する(内部処理)
        /// </summary>
        /// <param name="attributeType">属性値</param>
        /// <param name="colorValue">色を示す値</param>
        /// <param name="typeName">型名</param>
        /// <param name="kindName">値の種類名</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SetInternal(
            uint attributeType, uint colorValue, string typeName, string kindName)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            if (isAllowProcess)
            {
                // 実行が許可される場合
                // パラメーターを準備する
                var parameters = new SetWindowColorCallbackParameters(
                    attributeType, Kernel32Wrapper.GetCurrentProcessId(), colorValue);

                // トップレベルのウィンドウを処理する
                return User32Wrapper.EnumWindows(SetWindowColorCallbackCache, ref parameters);
            }
            else
            {
                // 実行が許可されない(WindowsのUnityEditor)場合は失敗
                if (isOutputLog)
                {
                    Debug.LogWarning($"[UnityPlayerWindowVisual.{typeName ?? "(不明な型)"}] " +
                        "Windowsのスタンドアロンプレイヤー以外の環境" +
                        $"({Application.platform})から{kindName ?? "(不明値)"}を設定しようとしました");
                }
                return false;
            }
#else
            // Windows環境以外である場合は失敗
            if (isOutputLog)
            {
                Debug.LogWarning($"[UnityPlayerWindowVisual.{typeName ?? "(不明な型)"}] " +
                    $"Windows以外の環境({Application.platform})から{kindName ?? "(不明値)"}を設定しようとしました");
            }
            return false;
#endif
        }

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        /// <summary>
        /// ウィンドウの色を設定する処理のコールバック関数
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル</param>
        /// <param name="parameters">パラメーター</param>
        /// <returns>処理を続行するか</returns>
        [MonoPInvokeCallback(typeof(User32Wrapper.SingleEnumWindowsProc))]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static bool SetWindowColorCallback(
            nint windowHandle, ref SetWindowColorCallbackParameters parameters)
        {
            if (User32Wrapper.GetWindowThreadProcessId(windowHandle, out var processId) == 0 ||
                parameters.ProcessId != processId)
            {
                // 現在のプロセスIDとウィンドウを生成したプロセスのIDが異なる場合は何もしない
                return true;
            }

            // ウィンドウの色を設定する
            uint colorValue = parameters.ColorValue;
            DwmApiWrapper.DwmSetWindowAttribute(
                windowHandle, parameters.AttributeType,
                ref colorValue, DwmApiWrapper.WindowColorValueDataSize);

            return true;
        }
#endif
    }
}
