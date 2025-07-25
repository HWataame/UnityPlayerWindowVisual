/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの色の種類を示す列挙型

WindowColorType.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System;

namespace HW.UnityPlayerWindowVisual
{
    /// <summary>
    /// ウィンドウの色の種類を示す列挙型
    /// </summary>
    [Flags]
    internal enum WindowColorType : byte
    {
        /// <summary>
        /// 何も設定しない
        /// </summary>
        None = 0,
        /// <summary>
        /// 縁の色を設定する
        /// </summary>
        Border = 1,
        /// <summary>
        /// タイトルバーの色を設定する
        /// </summary>
        Titlebar = 2,
        /// <summary>
        /// タイトルバーの文字色を設定する
        /// </summary>
        TitlebarText = 4,

        /// <summary>
        /// ウィンドウの周囲の色を設定する
        /// </summary>
        /// <remarks>縁とタイトルバーの色</remarks>
        Around = Border | Titlebar,
        /// <summary>
        /// タイトルバー全体の色を設定する
        /// </summary>
        /// <remarks>タイトルバーとタイトルバーの文字列の色</remarks>
        WholeOfTitlebar = Titlebar | TitlebarText,
        /// <summary>
        /// すべての色を設定する
        /// </summary>
        /// <remarks>縁とタイトルバーとタイトルバーの文字列の色</remarks>
        All = Border | Titlebar | TitlebarText
    }
}
