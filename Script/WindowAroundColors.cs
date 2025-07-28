/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの周囲の色を操作するクラス

WindowAroundColors.cs
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
    /// JP: ウィンドウの周囲の色を操作するクラス
    /// EN: Processes of Standalone Player window border and titlebar color
    /// </summary>
    public static class WindowAroundColors
    {
        /// <summary>
        /// JP: ウィンドウの周囲の色を設定する<br />
        /// EN: Set Standalone Player window border and titlebar color
        /// </summary>
        /// <param name="color">
        /// JP: ウィンドウの周囲の色<br />
        /// EN: Window border and titlebar color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color color)
        {
            // 色を示す値を求める
            uint colorValue = ColorUtil.GetColorValueFrom(color);

            // ウィンドウの周囲の色の設定を試行する
            return FeatureUtil.SetInternal(WindowColorType.Around,
                colorValue, colorValue, 0, typeof(WindowAroundColors).Name,
                "ウィンドウの周囲の色", "Standalone Player window border and titlebar colors");
        }

        /// <summary>
        /// JP: ウィンドウの周囲の色を設定する<br />
        /// EN: Set Standalone Player window border and titlebar color
        /// </summary>
        /// <param name="color">
        /// JP: ウィンドウの周囲の色<br />
        /// EN: Window border and titlebar color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 color)
        {
            // 色を示す値を求める
            uint colorValue = ColorUtil.GetColorValueFrom(color);

            // ウィンドウの周囲の色の設定を試行する
            return FeatureUtil.SetInternal(WindowColorType.Around,
                colorValue, colorValue, 0, typeof(WindowAroundColors).Name,
                "ウィンドウの周囲の色", "Standalone Player window border and titlebar colors");
        }

        /// <summary>
        /// JP: ウィンドウの周囲の色を設定する<br />
        /// EN: Set Standalone Player window border and titlebar color
        /// </summary>
        /// <param name="borderColor">
        /// JP: ウィンドウの縁の色<br />
        /// EN: Window border color
        /// </param>
        /// <param name="titlebarColor">
        /// JP: ウィンドウのタイトルバーの色<br />
        /// EN: Window titlebar color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color borderColor, Color titlebarColor)
        {
            // ウィンドウの周囲の色の設定を試行する
            return FeatureUtil.SetInternal(WindowColorType.Around,
                ColorUtil.GetColorValueFrom(borderColor),
                ColorUtil.GetColorValueFrom(titlebarColor), 0, typeof(WindowAroundColors).Name,
                "ウィンドウの周囲の色", "Standalone Player window border and titlebar colors");
        }

        /// <summary>
        /// JP: ウィンドウの周囲の色を設定する<br />
        /// EN: Set Standalone Player window border and titlebar color
        /// </summary>
        /// <param name="borderColor">
        /// JP: ウィンドウの縁の色<br />
        /// EN: Window border color
        /// </param>
        /// <param name="titlebarColor">
        /// JP: ウィンドウのタイトルバーの色<br />
        /// EN: Window titlebar color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 borderColor, Color32 titlebarColor)
        {
            // ウィンドウの周囲の色の設定を試行する
            return FeatureUtil.SetInternal(WindowColorType.Around,
                ColorUtil.GetColorValueFrom(borderColor),
                ColorUtil.GetColorValueFrom(titlebarColor), 0, typeof(WindowAroundColors).Name,
                "ウィンドウの周囲の色", "Standalone Player window border and titlebar colors");
        }

        /// <summary>
        /// JP: ウィンドウの周囲の色をシステムの既定値に設定する<br />
        /// EN: Set Standalone Player window border and titlebar color to system default
        /// </summary>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetDefault()
        {
            // ウィンドウの周囲の色の設定を試行する
            return FeatureUtil.SetInternal(WindowColorType.Around,
                ColorUtil.DwmDefaultColor, ColorUtil.DwmDefaultColor, 0, typeof(WindowAroundColors).Name,
                "ウィンドウの周囲の色", "Standalone Player window border and titlebar colors");
        }
    }
}
