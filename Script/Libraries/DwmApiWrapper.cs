/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
dwmapi.dllの関数を呼び出せるようにするラッパークラス

DwmApiWrapper.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
using System.Runtime.InteropServices;

namespace HW.UnityPlayerWindowVisual.Libraries
{
    /// <summary>
    /// dwmapi.dllの関数を呼び出せるようにするラッパークラス
    /// </summary>
    internal static class DwmApiWrapper
    {
        /// <summary>
        /// 色を示す値のデータサイズ
        /// </summary>
        internal const int WindowColorValueDataSize = 4;


        /// <summary>
        /// ウィンドウの領域外の属性を設定する
        /// </summary>
        /// <remarks>ウィンドウの色変更用に引数を変更した版</remarks>
        /// <param name="windowHandle">ウィンドウのハンドル</param>
        /// <param name="attribute">変更する属性</param>
        /// <param name="colorValue">色を示す値</param>
        /// <param name="dataSize">データサイズ</param>
        /// <returns>処理結果のHRESULT値</returns>
        [DllImport("dwmapi.dll", EntryPoint = "DwmSetWindowAttribute", CallingConvention = CallingConvention.Winapi)]
        internal static extern HResult DwmSetWindowAttribute(nint windowHandle,
            uint attribute, ref uint colorValue, uint dataSize);
    }
}
#endif
