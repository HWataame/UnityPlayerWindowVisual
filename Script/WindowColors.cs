/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの縁とタイトルバー全体の色を操作するクラス

WindowColors.cs
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
    /// JP: ウィンドウの縁とタイトルバー全体の色を操作するクラス
    /// EN: Processes of Standalone Player window border, titlebar and titlebar text color
    /// </summary>
    public static class WindowColors
    {
        /// <summary>
        /// JP: ウィンドウの色を設定する<br />
        /// EN: Set Standalone Player window colors
        /// </summary>
        /// <param name="aroundColor">
        /// JP: ウィンドウの周囲の色<br />
        /// EN: Window border and titlebar color
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
        public static bool Set(Color aroundColor, Color titlebarTextColor)
        {
            // 色を示す値を求める
            uint aroundColorValue = ColorUtil.GetColorValueFrom(aroundColor);

            // ウィンドウの色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.All, aroundColorValue, aroundColorValue,
                ColorUtil.GetColorValueFrom(titlebarTextColor),
                typeof(WindowColors).Name, "ウィンドウの色", "Window colors");
        }

        /// <summary>
        /// JP: ウィンドウの色を設定する<br />
        /// EN: Set Standalone Player window colors
        /// </summary>
        /// <param name="aroundColor">
        /// JP: ウィンドウの周囲の色<br />
        /// EN: Window border and titlebar color
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
        public static bool Set(Color32 aroundColor, Color32 titlebarTextColor)
        {
            // 色を示す値を求める
            uint aroundColorValue = ColorUtil.GetColorValueFrom(aroundColor);

            // ウィンドウの色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.All, aroundColorValue, aroundColorValue,
                ColorUtil.GetColorValueFrom(titlebarTextColor),
                typeof(WindowColors).Name, "ウィンドウの色", "Window colors");
        }

        /// <summary>
        /// JP: ウィンドウの色を設定する<br />
        /// EN: Set Standalone Player window colors
        /// </summary>
        /// <param name="borderColor">
        /// JP: ウィンドウの縁の色<br />
        /// EN: Window border color
        /// </param>
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
        public static bool Set(Color borderColor, Color titlebarColor, Color titlebarTextColor)
        {
            // ウィンドウの色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, ColorUtil.GetColorValueFrom(borderColor),
                ColorUtil.GetColorValueFrom(titlebarColor), ColorUtil.GetColorValueFrom(titlebarTextColor),
                typeof(WindowColors).Name, "ウィンドウの色", "Window colors");
        }

        /// <summary>
        /// JP: ウィンドウの色を設定する<br />
        /// EN: Set Standalone Player window colors
        /// </summary>
        /// <param name="borderColor">
        /// JP: ウィンドウの縁の色<br />
        /// EN: Window border color
        /// </param>
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
        public static bool Set(Color32 borderColor, Color32 titlebarColor, Color32 titlebarTextColor)
        {
            // ウィンドウの色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, ColorUtil.GetColorValueFrom(borderColor),
                ColorUtil.GetColorValueFrom(titlebarColor), ColorUtil.GetColorValueFrom(titlebarTextColor),
                typeof(WindowColors).Name, "ウィンドウの色", "Window colors");
        }

        /// <summary>
        /// JP: ウィンドウの色をシステムの既定値に設定する<br />
        /// EN: Set Standalone Player window colors to system default
        /// </summary>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetDefault()
        {
            // ウィンドウの色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, ColorUtil.DwmDefaultColor, ColorUtil.DwmDefaultColor,
                ColorUtil.DwmDefaultColor, typeof(WindowColors).Name, "ウィンドウの色", "Window colors");
        }
    }
}
