/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの縁とタイトルバー全体の色を操作するクラス

WindowColors.cs
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
    /// ウィンドウの縁とタイトルバー全体の色を操作するクラス
    /// </summary>
    public static class WindowColors
    {
        /// <summary>
        /// ウィンドウの色を設定する
        /// </summary>
        /// <param name="aroundColor">ウィンドウの周囲の色</param>
        /// <param name="titlebarTextColor">ウィンドウのタイトルバーの文字色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color aroundColor, Color titlebarTextColor)
        {
            // 色を示す値を求める
            uint aroundColorValue = ColorUtil.GetColorValueFrom(aroundColor);

            // ウィンドウの色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.All, aroundColorValue, aroundColorValue,
                ColorUtil.GetColorValueFrom(titlebarTextColor),
                typeof(WindowColors).Name, "ウィンドウの色");
        }

        /// <summary>
        /// ウィンドウの色を設定する
        /// </summary>
        /// <param name="aroundColor">ウィンドウの周囲の色</param>
        /// <param name="titlebarTextColor">ウィンドウのタイトルバーの文字色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 aroundColor, Color32 titlebarTextColor)
        {
            // 色を示す値を求める
            uint aroundColorValue = ColorUtil.GetColorValueFrom(aroundColor);

            // ウィンドウの色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.All, aroundColorValue, aroundColorValue,
                ColorUtil.GetColorValueFrom(titlebarTextColor),
                typeof(WindowColors).Name, "ウィンドウの色");
        }

        /// <summary>
        /// ウィンドウの色を設定する
        /// </summary>
        /// <param name="borderColor">ウィンドウの縁の色</param>
        /// <param name="titlebarColor">ウィンドウのタイトルバーの色</param>
        /// <param name="titlebarTextColor">ウィンドウのタイトルバーの文字色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color borderColor, Color titlebarColor, Color titlebarTextColor)
        {
            // ウィンドウの色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, ColorUtil.GetColorValueFrom(borderColor),
                ColorUtil.GetColorValueFrom(titlebarColor), ColorUtil.GetColorValueFrom(titlebarTextColor),
                typeof(WindowColors).Name, "ウィンドウの色");
        }

        /// <summary>
        /// ウィンドウの色を設定する
        /// </summary>
        /// <param name="borderColor">ウィンドウの縁の色</param>
        /// <param name="titlebarColor">ウィンドウのタイトルバーの色</param>
        /// <param name="titlebarTextColor">ウィンドウのタイトルバーの文字色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 borderColor, Color32 titlebarColor, Color32 titlebarTextColor)
        {
            // ウィンドウの色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, ColorUtil.GetColorValueFrom(borderColor),
                ColorUtil.GetColorValueFrom(titlebarColor), ColorUtil.GetColorValueFrom(titlebarTextColor),
                typeof(WindowColors).Name, "ウィンドウの色");
        }

        /// <summary>
        /// ウィンドウの色をシステムの既定値に設定する
        /// </summary>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetDefault()
        {
            // ウィンドウの色の設定を試行する
            return FeatureUtil.SetInternal(
                WindowColorType.Around, ColorUtil.DwmDefaultColor, ColorUtil.DwmDefaultColor,
                ColorUtil.DwmDefaultColor, typeof(WindowColors).Name, "ウィンドウの色");
        }
    }
}
