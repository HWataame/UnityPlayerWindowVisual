/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
タイトルバーの色を操作するクラス

WindowTitlebarColor.cs
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
    /// タイトルバーの色を操作するクラス
    /// </summary>
    public static class WindowTitlebarColor
    {
        /// <summary>
        /// DwmSetWindowAttributeにタイトルバーの色の処理であることを示す属性値
        /// </summary>
        internal const int DwmWindowCaptionColor = 35;


        /// <summary>
        /// タイトルバーの色を設定する
        /// </summary>
        /// <param name="color">タイトルバーの色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color color)
        {
            // タイトルバーの色の設定を試行する
            return FeatureUtil.SetInternal(
                DwmWindowCaptionColor, ColorUtil.GetColorValueFrom(color),
                typeof(WindowTitlebarColor).Name, "タイトルバーの色");
        }

        /// <summary>
        /// タイトルバーの色を設定する
        /// </summary>
        /// <param name="color">タイトルバーの色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 color)
        {
            // タイトルバーの色の設定を試行する
            return FeatureUtil.SetInternal(
                DwmWindowCaptionColor, ColorUtil.GetColorValueFrom(color),
                typeof(WindowTitlebarColor).Name, "タイトルバーの色");
        }

        /// <summary>
        /// タイトルバーの色をシステムの既定値に設定する
        /// </summary>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetDefault()
        {
            // タイトルバーの色の設定を試行する
            return FeatureUtil.SetInternal(
                DwmWindowCaptionColor, ColorUtil.DwmDefaultColor,
                typeof(WindowTitlebarColor).Name, "タイトルバーの色");
        }
    }
}
