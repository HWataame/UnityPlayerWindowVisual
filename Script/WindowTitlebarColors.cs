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
    /// ウィンドウのタイトルバー全体の色を操作するクラス
    /// </summary>
    public static class WindowTitlebarColors
    {
        /// <summary>
        /// ウィンドウのタイトルバー全体の色を設定する
        /// </summary>
        /// <param name="titlebarColor">ウィンドウのタイトルバーの色</param>
        /// <param name="titlebarTextColor">ウィンドウのタイトルバーの文字色</param>
        /// <returns>処理結果</returns>
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
        /// ウィンドウのタイトルバー全体の色を設定する
        /// </summary>
        /// <param name="titlebarColor">ウィンドウのタイトルバーの色</param>
        /// <param name="titlebarTextColor">ウィンドウのタイトルバーの文字色</param>
        /// <returns>処理結果</returns>
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
        /// ウィンドウのタイトルバー全体の色をシステムの既定値に設定する
        /// </summary>
        /// <returns>処理結果</returns>
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
