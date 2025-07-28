/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの縁の色を操作するクラス

WindowBorderColor.cs
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
    /// JP: ウィンドウの縁の色を操作するクラス
    /// EN: Processes of Standalone Player window border color
    /// </summary>
    public static class WindowBorderColor
    {
        /// <summary>
        /// DwmSetWindowAttributeにウィンドウの縁の色の処理であることを示す属性値
        /// </summary>
        internal const int WindowBorderColorAttribute = 34;


        /// <summary>
        /// JP: ウィンドウの縁の色を設定する<br />
        /// EN: Set Standalone Player window border color
        /// </summary>
        /// <param name="color">
        /// JP: ウィンドウの縁の色<br />
        /// EN: Window border color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color color)
        {
            // ウィンドウの縁の色の設定を試行する
            return FeatureUtil.SetInternal(WindowBorderColorAttribute, ColorUtil.GetColorValueFrom(color),
                typeof(WindowBorderColor).Name, "ウィンドウの縁の色", "Standalone Player window border color");
        }

        /// <summary>
        /// JP: ウィンドウの縁の色を設定する<br />
        /// EN: Set Standalone Player window border color
        /// </summary>
        /// <param name="color">
        /// JP: ウィンドウの縁の色<br />
        /// EN: Window border color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 color)
        {
            // ウィンドウの縁の色の設定を試行する
            return FeatureUtil.SetInternal(WindowBorderColorAttribute, ColorUtil.GetColorValueFrom(color),
                typeof(WindowBorderColor).Name, "ウィンドウの縁の色", "Standalone Player window border color");
        }

        /// <summary>
        /// JP: ウィンドウの縁の色をシステムの既定値に設定する<br />
        /// EN: Set Standalone Player window border color to system default
        /// </summary>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetDefault()
        {
            // ウィンドウの縁の色の設定を試行する
            return FeatureUtil.SetInternal(WindowBorderColorAttribute, ColorUtil.DwmDefaultColor,
                typeof(WindowBorderColor).Name, "ウィンドウの縁の色", "Standalone Player window border color");
        }

        /// <summary>
        /// JP: ウィンドウの縁を描画しないように設定する<br />
        /// EN: Hide Standalone Player window border
        /// </summary>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetNoneBorder()
        {
            // ウィンドウの縁の色の設定を試行する
            return FeatureUtil.SetInternal(WindowBorderColorAttribute, ColorUtil.DwmNoneColor,
                typeof(WindowBorderColor).Name, "ウィンドウの縁", "Standalone Player window border");
        }
    }
}
