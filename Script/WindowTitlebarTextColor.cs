/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
タイトルバーの文字色を操作するクラス

WindowTitlebarTextColor.cs
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
    /// タイトルバーの文字色を操作するクラス
    /// </summary>
    public static class WindowTitlebarTextColor
    {
        /// <summary>
        /// DwmSetWindowAttributeにタイトルバーの文字列の色の処理であることを示す属性値
        /// </summary>
        private const int DwmWindowCaptionTextColor = 36;


        /// <summary>
        /// タイトルバーの文字色を設定する
        /// </summary>
        /// <param name="color">タイトルバーの文字色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color color)
        {
            // タイトルバーの文字色の設定を試行する
            return FeatureUtil.SetInternal(
                DwmWindowCaptionTextColor, ColorUtil.GetColorValueFrom(color),
                typeof(WindowTitlebarColor).Name, "タイトルバーの文字色");
        }

        /// <summary>
        /// タイトルバーの文字色を設定する
        /// </summary>
        /// <param name="color">タイトルバーの文字色</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(Color32 color)
        {
            // タイトルバーの文字色の設定を試行する
            return FeatureUtil.SetInternal(
                DwmWindowCaptionTextColor, ColorUtil.GetColorValueFrom(color),
                typeof(WindowTitlebarColor).Name, "タイトルバーの文字色");
        }

        /// <summary>
        /// タイトルバーの文字色をシステムの既定値に設定する
        /// </summary>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetDefault()
        {
            // タイトルバーの文字色の設定を試行する
            return FeatureUtil.SetInternal(
                DwmWindowCaptionTextColor, ColorUtil.DwmDefaultColor,
                typeof(WindowTitlebarColor).Name, "タイトルバーの文字色");
        }
    }
}
