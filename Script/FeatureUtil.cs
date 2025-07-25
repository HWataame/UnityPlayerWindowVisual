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
        /// SetWindowColorsCallbackのデリゲートのキャッシュ
        /// </summary>
        private static readonly User32Wrapper.EnumWindowsProc SetWindowColorsCallbackCache;
#endif


        /// <summary>
        /// 初期化処理
        /// </summary>
        static FeatureUtil()
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            // 現在の環境がWindowsのスタンドアロンプレイヤーか判定する
            isAllowProcess = Application.platform == RuntimePlatform.WindowsPlayer;

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
                var parameters = new SetWindowColorsCallbackParameters(
                    attributeType, Kernel32Wrapper.GetCurrentProcessId(), colorValue);

                // トップレベルのウィンドウを処理する
                return User32Wrapper.EnumWindows(SetWindowColorsCallbackCache, ref parameters);
            }
            else
            {
                // 実行が許可されない(WindowsのUnityEditor)場合は失敗
                return false;
            }
#else
            // Windows環境以外である場合は失敗
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
        [MonoPInvokeCallback(typeof(User32Wrapper.EnumWindowsProc))]
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
