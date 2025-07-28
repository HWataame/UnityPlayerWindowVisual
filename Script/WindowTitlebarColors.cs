/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウのタイトルバー全体の色を操作するクラス

WindowTitlebarColors.cs
────────────────────────────────────────
バージョン: 1.0.1
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HW.UnityPlayerWindowVisual
{
    /// <summary>
    /// JP: ウィンドウのタイトルバー全体の色を操作するクラス
    /// EN: Processes of Standalone Player window titlebar and titlebar text color
    /// </summary>
    public static class WindowTitlebarColors
    {
        /// <summary>
        /// JP: ウィンドウのタイトルバー全体の色を設定する<br />
        /// EN: Set Standalone Player window titlebar and titlebar text color
        /// </summary>
        /// <param name="titlebarColor">
        /// JP: ウィンドウのタイトルバーの色<br />
        /// EN: Window titlebar color
        /// </param>
        /// <param name="titlebarTextColor">
        /// JP: ウィンドウのタイトルバーの文字色<br />
        /// EN: Window titlebar text color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color titlebarColor, Color titlebarTextColor)
        {
            // ウィンドウのタイトルバー全体の色の設定を試行する
            return FeatureUtil.SetInternal(WindowColorType.WholeOfTitlebar, 0,
                ColorUtil.GetColorValueFrom(titlebarColor),
                ColorUtil.GetColorValueFrom(titlebarTextColor), typeof(WindowTitlebarColors).Name,
                "ウィンドウのタイトルバー全体の色", "Standalone Player window titlebar and text colors");
        }

        /// <summary>
        /// JP: ウィンドウのタイトルバー全体の色を設定する<br />
        /// EN: Set Standalone Player window titlebar and titlebar text color
        /// </summary>
        /// <param name="titlebarColor">
        /// JP: ウィンドウのタイトルバーの色<br />
        /// EN: Window titlebar color
        /// </param>
        /// <param name="titlebarTextColor">
        /// JP: ウィンドウのタイトルバーの文字色<br />
        /// EN: Window titlebar text color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 titlebarColor, Color32 titlebarTextColor)
        {
            // ウィンドウのタイトルバー全体の色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.WholeOfTitlebar, 0, ColorUtil.GetColorValueFrom(titlebarColor),
                ColorUtil.GetColorValueFrom(titlebarTextColor), typeof(WindowTitlebarColors).Name,
                "ウィンドウのタイトルバー全体の色", "Standalone Player window titlebar and text colors");
        }

        /// <summary>
        /// JP: ウィンドウのタイトルバー全体の色をシステムの既定値に設定する<br />
        /// EN: Set Standalone Player window titlebar and titlebar text color to system default
        /// </summary>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetDefault()
        {
            // ウィンドウのタイトルバー全体の色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.WholeOfTitlebar, 0, ColorUtil.DwmDefaultColor,
                ColorUtil.DwmDefaultColor, typeof(WindowTitlebarColors).Name,
                "ウィンドウのタイトルバー全体の色", "Standalone Player window titlebar and text colors");
        }
    }
}
