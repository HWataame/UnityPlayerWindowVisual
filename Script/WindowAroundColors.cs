/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの周囲の色を操作するクラス

WindowAroundColors.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HW.UnityPlayerWindowVisual
{
    /// <summary>
    /// ウィンドウの周囲の色を操作するクラス
    /// </summary>
    public static class WindowAroundColors
    {
        /// <summary>
        /// ウィンドウの周囲の色を設定する
        /// </summary>
        /// <param name="color">ウィンドウの周囲の色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color color)
        {
            // 色を示す値を求める
            uint colorValue = ColorUtil.GetColorValueFrom(color);

            // ウィンドウの周囲の色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, colorValue, colorValue, 0,
                typeof(WindowAroundColors).Name, "ウィンドウの周囲の色");
        }

        /// <summary>
        /// ウィンドウの周囲の色を設定する
        /// </summary>
        /// <param name="color">ウィンドウの周囲の色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 color)
        {
            // 色を示す値を求める
            uint colorValue = ColorUtil.GetColorValueFrom(color);

            // ウィンドウの周囲の色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, colorValue, colorValue, 0,
                typeof(WindowAroundColors).Name, "ウィンドウの周囲の色");
        }

        /// <summary>
        /// ウィンドウの周囲の色を設定する
        /// </summary>
        /// <param name="borderColor">ウィンドウの縁の色</param>
        /// <param name="titlebarColor">ウィンドウのタイトルバーの色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color borderColor, Color titlebarColor)
        {
            // ウィンドウの周囲の色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, ColorUtil.GetColorValueFrom(borderColor),
                ColorUtil.GetColorValueFrom(titlebarColor), 0,
                typeof(WindowAroundColors).Name, "ウィンドウの周囲の色");
        }

        /// <summary>
        /// ウィンドウの周囲の色を設定する
        /// </summary>
        /// <param name="borderColor">ウィンドウの縁の色</param>
        /// <param name="titlebarColor">ウィンドウのタイトルバーの色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 borderColor, Color32 titlebarColor)
        {
            // ウィンドウの周囲の色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, ColorUtil.GetColorValueFrom(borderColor),
                ColorUtil.GetColorValueFrom(titlebarColor), 0,
                typeof(WindowAroundColors).Name, "ウィンドウの周囲の色");
        }

        /// <summary>
        /// ウィンドウの周囲の色をシステムの既定値に設定する
        /// </summary>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetDefault()
        {
            // ウィンドウの周囲の色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, ColorUtil.DwmDefaultColor, ColorUtil.DwmDefaultColor,
                0, typeof(WindowAroundColors).Name, "ウィンドウの周囲の色");
        }
    }
}
