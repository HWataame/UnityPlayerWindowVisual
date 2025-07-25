/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
色の処理を保持するクラス

ColorUtil.cs
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
    /// 色の処理を保持するクラス
    /// </summary>
    internal static class ColorUtil
    {
        /// <summary>
        /// システム既定の色を使用することを示す値
        /// </summary>
        internal const uint DwmDefaultColor = 0xffffffff;
        /// <summary>
        /// 色を使用しないことを示す値
        /// </summary>
        internal const uint DwmNoneColor = 0xfffffffe;


        /// <summary>
        /// 色から色を示す値を取得する
        /// </summary>
        /// <param name="color">色</param>
        /// <returns>色を示す値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint GetColorValueFrom(Color color)
        {
            // 32ビットカラーに変換し、色を示す値を取得する
            return GetColorValueFrom((Color32)color);
        }

        /// <summary>
        /// 色から色を示す値を取得する
        /// </summary>
        /// <param name="color">32ビットカラー</param>
        /// <returns>色を示す値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint GetColorValueFrom(Color32 color)
        {
            // 最下位バイトから赤、緑、青の順に8ビットの色を結合した値を返す(最上位バイトは0)
            return (uint)(color.r | (color.g << 8) | (color.b << 16));
        }
    }
}
