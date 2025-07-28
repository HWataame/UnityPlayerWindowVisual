/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
HW.UnityPlayerWindowVisualパッケージの機能に関する処理を保持するクラス

FeatureUtil.cs
────────────────────────────────────────
バージョン: 1.0.1
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using HW.UnityPlayerWindowVisual.Libraries;
using System.Runtime.CompilerServices;
using UnityEngine;
#if HAS_COMMON_MAIN_WINDOW_HANDLE_GETTER_HW
using CommonMainWindowHandle = HW.UnityPlayerWindowHandle.UnityPlayerWindow;
#endif

namespace HW.UnityPlayerWindowVisual
{
    /// <summary>
    /// JP: HW.UnityPlayerWindowVisualパッケージの機能に関する処理を保持するクラス<br />
    /// EN: Processes about feature of HW.UnityPlayerWindowVisual package
    /// </summary>
    public static class FeatureUtil
    {
        /// <summary>
        /// ログを出力するか
        /// </summary>
        private static bool isOutputLog = true;

        /// <summary>
        /// JP: ログを出力するか<br />
        /// EN: Does output "executing from unsupported environment" warning logs?
        /// </summary>
        public static bool IsOutputLog
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => isOutputLog;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => isOutputLog = value;
        }


        /// <summary>
        /// ウィンドウの色を設定する(内部処理)
        /// </summary>
        /// <param name="attributeType">属性値</param>
        /// <param name="colorValue">縁の色</param>
        /// <param name="typeName">型名</param>
        /// <param name="kindNameJapanese">種類名(日本語)</param>
        /// <param name="kindNameEnglish">種類名(英語)</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SetInternal(uint attributeType, uint colorValue,
            string typeName, string kindNameJapanese, string kindNameEnglish)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            if (IsHandleValid())
            {
                // スタンドアロンプレイヤーのメインウィンドウの
                // ウィンドウハンドルが有効である場合はウィンドウの色を設定する
                return DwmApiWrapper.DwmSetWindowAttribute(GetWindowHandle(), attributeType,
                    ref colorValue, DwmApiWrapper.WindowColorValueDataSize) == HResult.Ok;
            }
            else
            {
                // スタンドアロンプレイヤーのメインウィンドウのウィンドウハンドルが
                // 有効ではない(WindowsのUnityEditorなど)場合は失敗
                if (isOutputLog)
                {
                    Debug.LogWarning($"[UnityPlayerWindowVisual.{typeName}]\n" +
                        "\tJP: Windowsのスタンドアロンプレイヤー以外の環境" +
                        $"({Application.platform})から{kindNameJapanese}を設定しようとしました\n" +
                        $"EN: Trying to set {kindNameEnglish} from except Windows Standalone Player on Windows" +
                        $" ({Application.platform})");
                }
                return false;
            }
#else
            // Windows環境以外である場合は失敗
            if (isOutputLog)
            {
                Debug.LogWarning("[UnityPlayerWindowVisual.{typeName}]\n" +
                    $"\tJP: Windows以外の環境({Application.platform})から{kindNameJapanese}を設定しようとしました\n" +
                    $"\tEN: Trying to set {kindNameEnglish} from except Windows ({Application.platform})");
            }
            return false;
#endif
        }

        /// <summary>
        /// ウィンドウの複数の色を設定する(内部処理)
        /// </summary>
        /// <param name="type">設定する色のフラグ</param>
        /// <param name="borderColorValue">縁の色を示す値</param>
        /// <param name="titlebarColorValue">タイトルバーの色を示す値</param>
        /// <param name="titlebarTextColorValue">タイトルバーの文字色を示す値</param>
        /// <param name="typeName">型名</param>
        /// <param name="kindNameJapanese">種類名(日本語)</param>
        /// <param name="kindNameEnglish">種類名(英語)</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SetInternal(
            WindowColorType type, uint borderColorValue, uint titlebarColorValue,
            uint titlebarTextColorValue, string typeName, string kindNameJapanese, string kindNameEnglish)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            if (IsHandleValid())
            {
                // ウィンドウハンドルを取得する
                var windowHandle = GetWindowHandle();

                // スタンドアロンプレイヤーのメインウィンドウのウィンドウハンドルが有効である場合
                if ((type & WindowColorType.Border) != 0)
                {
                    // 縁の色を設定する場合
                    DwmApiWrapper.DwmSetWindowAttribute(
                        windowHandle, WindowBorderColor.WindowBorderColorAttribute,
                        ref borderColorValue, DwmApiWrapper.WindowColorValueDataSize);
                }

                if ((type & WindowColorType.Titlebar) != 0)
                {
                    // タイトルバーの色を設定する場合
                    DwmApiWrapper.DwmSetWindowAttribute(
                        windowHandle, WindowTitlebarColor.DwmWindowCaptionColor,
                        ref titlebarColorValue, DwmApiWrapper.WindowColorValueDataSize);
                }

                if ((type & WindowColorType.Titlebar) != 0)
                {
                    // タイトルバーの文字色を設定する場合
                    DwmApiWrapper.DwmSetWindowAttribute(
                        windowHandle, WindowTitlebarTextColor.DwmWindowCaptionTextColor,
                        ref titlebarTextColorValue, DwmApiWrapper.WindowColorValueDataSize);
                }

                return true;
            }
            else
            {
                // スタンドアロンプレイヤーのメインウィンドウのウィンドウハンドルが
                // 有効ではない(WindowsのUnityEditorなど)場合は失敗
                if (isOutputLog)
                {
                    Debug.LogWarning($"[UnityPlayerWindowVisual.{typeName}]\n" +
                        "\tJP: Windowsのスタンドアロンプレイヤー以外の環境" +
                        $"({Application.platform})から{kindNameJapanese}を設定しようとしました\n" +
                        $"EN: Trying to set {kindNameEnglish} from except Windows Standalone Player on Windows" +
                        $" ({Application.platform})");
                }
                return false;
            }
#else
            // Windows環境以外である場合は失敗
            if (isOutputLog)
            {
                Debug.LogWarning("[UnityPlayerWindowVisual.{typeName}]\n" +
                    $"\tJP: Windows以外の環境({Application.platform})から{kindNameJapanese}を設定しようとしました\n" +
                    $"\tEN: Trying to set {kindNameEnglish} from except Windows ({Application.platform})");
            }
            return false;
#endif
        }

        /// <summary>
        /// ウィンドウハンドルが有効か判定する
        /// </summary>
        /// <returns>判定結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsHandleValid()
        {
#if HAS_COMMON_MAIN_WINDOW_HANDLE_GETTER_HW
            // 共通のウィンドウハンドル取得クラスが存在する場合
            return CommonMainWindowHandle.IsHandleValid;
#else
            // 共通のウィンドウハンドル取得クラスが存在しない場合
            return UnityPlayerWindow.IsHandleValid;
#endif
        }

        /// <summary>
        /// ウィンドウハンドルを取得する
        /// </summary>
        /// <returns>ウィンドウハンドル</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static nint GetWindowHandle()
        {
#if HAS_COMMON_MAIN_WINDOW_HANDLE_GETTER_HW
            // 共通のウィンドウハンドル取得クラスが存在する場合
            return CommonMainWindowHandle.MainWindowHandle;
#else
            // 共通のウィンドウハンドル取得クラスが存在しない場合
            return UnityPlayerWindow.MainWindowHandle;
#endif
        }
    }
}
