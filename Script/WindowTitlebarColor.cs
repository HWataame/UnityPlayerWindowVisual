/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
タイトルバーの色を操作するクラス

WindowTitlebarColor.cs
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
    /// JP: タイトルバーの色を操作するクラス
    /// EN: Processes of Standalone Player window titlebar color
    /// </summary>
    public static class WindowTitlebarColor
    {
        /// <summary>
        /// DwmSetWindowAttributeにタイトルバーの色の処理であることを示す属性値
        /// </summary>
        internal const int DwmWindowCaptionColor = 35;


        /// <summary>
        /// JP: タイトルバーの色を設定する<br />
        /// EN: Set Standalone Player window titlebar color
        /// </summary>
        /// <param name="color">
        /// JP: タイトルバーの色<br />
        /// EN: Window titlebar color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color color)
        {
            // タイトルバーの色の設定を試行する
            return FeatureUtil.SetInternal(DwmWindowCaptionColor, ColorUtil.GetColorValueFrom(color),
                typeof(WindowTitlebarColor).Name, "タイトルバーの色", "Standalone Player window Titlebar color");
        }

        /// <summary>
        /// JP: タイトルバーの色を設定する<br />
        /// EN: Set Standalone Player window titlebar color
        /// </summary>
        /// <param name="color">
        /// JP: タイトルバーの色<br />
        /// EN: Window titlebar color
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 color)
        {
            // タイトルバーの色の設定を試行する
            return FeatureUtil.SetInternal(DwmWindowCaptionColor, ColorUtil.GetColorValueFrom(color),
                typeof(WindowTitlebarColor).Name, "タイトルバーの色", "Standalone Player window Titlebar color");
        }

        /// <summary>
        /// JP: タイトルバーの色をシステムの既定値に設定する<br />
        /// EN: Set Standalone Player window titlebar color to system default
        /// </summary>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetDefault()
        {
            // タイトルバーの色の設定を試行する
            return FeatureUtil.SetInternal(DwmWindowCaptionColor, ColorUtil.DwmDefaultColor,
                typeof(WindowTitlebarColor).Name, "タイトルバーの色", "Standalone Player window Titlebar color");
        }
    }
}
