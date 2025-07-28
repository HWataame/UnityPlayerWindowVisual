/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
タイトルバーの文字色を操作するクラス

WindowTitlebarTextColor.cs
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
    /// JP: タイトルバーの文字色を操作するクラス
    /// EN: Processes of Standalone Player window titlebar text color
    /// </summary>
    public static class WindowTitlebarTextColor
    {
        /// <summary>
        /// DwmSetWindowAttributeにタイトルバーの文字列の色の処理であることを示す属性値
        /// </summary>
        internal const int DwmWindowCaptionTextColor = 36;


        /// <summary>
        /// JP: タイトルバーの文字色を設定する<br />
        /// EN: Set Standalone Player window titlebar text color
        /// </summary>
        /// <param name="color">
        /// JP: タイトルバーの文字色<br />
        /// EN: Window titlebar text color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color color)
        {
            // タイトルバーの文字色の設定を試行する
            return FeatureUtil.SetInternal(DwmWindowCaptionTextColor,
                ColorUtil.GetColorValueFrom(color), typeof(WindowTitlebarTextColor).Name,
                "タイトルバーの文字色", "Standalone Player window Titlebar text color");
        }

        /// <summary>
        /// JP: タイトルバーの文字色を設定する<br />
        /// EN: Set Standalone Player window titlebar text color
        /// </summary>
        /// <param name="color">
        /// JP: タイトルバーの文字色<br />
        /// EN: Window titlebar text color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 color)
        {
            // タイトルバーの文字色の設定を試行する
            return FeatureUtil.SetInternal(DwmWindowCaptionTextColor,
                ColorUtil.GetColorValueFrom(color), typeof(WindowTitlebarTextColor).Name,
                "タイトルバーの文字色", "Standalone Player window Titlebar text color");
        }

        /// <summary>
        /// JP: タイトルバーの文字色をシステムの既定値に設定する<br />
        /// EN: Set Standalone Player window titlebar text color to system default
        /// </summary>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetDefault()
        {
            // タイトルバーの文字色の設定を試行する
            return FeatureUtil.SetInternal(DwmWindowCaptionTextColor,
                ColorUtil.DwmDefaultColor, typeof(WindowTitlebarTextColor).Name,
                "タイトルバーの文字色", "Standalone Player window Titlebar text color");
        }
    }
}
