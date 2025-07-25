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
using System;
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
        /// <summary>
        /// SetWindowColorsCallbackのデリゲートのキャッシュ
        /// </summary>
        private static readonly User32Wrapper.MultiEnumWindowsProc SetWindowColorsCallbackCache;

        /// <summary>
        /// 色の種類に対応する属性値
        /// </summary>
        private static readonly uint[] ColorTypeAttributes =
        {
            WindowBorderColor.WindowBorderColorAttribute,
            WindowTitlebarColor.DwmWindowCaptionColor,
            WindowTitlebarTextColor.DwmWindowCaptionTextColor
        };
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

            // SetWindowColorsCallbackのデリゲートをキャッシュする
            SetWindowColorsCallbackCache = SetWindowColorsCallback;
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

        /// <summary>
        /// ウィンドウの複数の色を設定する(内部処理)
        /// </summary>
        /// <param name="type">設定する色のフラグ</param>
        /// <param name="borderColorValue">縁の色を示す値</param>
        /// <param name="titlebarColorValue">タイトルバーの色を示す値</param>
        /// <param name="titlebarTextColorValue">タイトルバーの文字色を示す値</param>
        /// <param name="typeName">型名</param>
        /// <param name="kindName">値の種類名</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SetInternal(
            WindowColorType type, uint borderColorValue, uint titlebarColorValue,
            uint titlebarTextColorValue, string typeName, string kindName)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            if (isAllowProcess)
            {
                // 実行が許可される場合
                // パラメーターを準備する
                var parameters = new SetWindowColorsCallbackParameters(
                    type, borderColorValue, titlebarColorValue,
                    titlebarTextColorValue, Kernel32Wrapper.GetCurrentProcessId());

                // トップレベルのウィンドウを処理する
                return User32Wrapper.EnumWindows(SetWindowColorsCallbackCache, ref parameters);
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
        /// ウィンドウの複数の色を設定する処理のコールバック関数
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル</param>
        /// <param name="parameters">パラメーター</param>
        /// <returns>処理を続行するか</returns>
        [MonoPInvokeCallback(typeof(User32Wrapper.MultiEnumWindowsProc))]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static bool SetWindowColorsCallback(
            nint windowHandle, ref SetWindowColorsCallbackParameters parameters)
        {
            if (User32Wrapper.GetWindowThreadProcessId(windowHandle, out var processId) == 0 ||
                parameters.ProcessId != processId)
            {
                // 現在のプロセスIDとウィンドウを生成したプロセスのIDが異なる場合は何もしない
                return true;
            }

            // 属性値を取得する
            ReadOnlySpan<uint> attributes = ColorTypeAttributes;

            // ウィンドウの色を設定する
            for (int i = 0; i < attributes.Length; ++i)
            {
                var (isSet, colorValue) = parameters[i];
                if (isSet)
                {
                    // 処理中の色が設定されている場合はウィンドウの色を設定する
                    DwmApiWrapper.DwmSetWindowAttribute(windowHandle, attributes[i],
                        ref colorValue, DwmApiWrapper.WindowColorValueDataSize);
                }
            }

            return true;
        }
#endif
    }
}
