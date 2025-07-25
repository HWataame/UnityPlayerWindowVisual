/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの複数の色を設定する用のパラメーターの構造体

SetWindowColorsCallbackParameters.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
using System.Runtime.CompilerServices;

namespace HW.UnityPlayerWindowVisual
{
    /// <summary>
    /// ウィンドウの複数の色を設定する用のパラメーターの構造体
    /// </summary>
    internal readonly ref struct SetWindowColorsCallbackParameters
    {
        /// <summary>
        /// 自身のプロセスID
        /// </summary>
        private readonly uint processId;
        /// <summary>
        /// 縁の色を示す値
        /// </summary>
        private readonly uint borderColorValue;
        /// <summary>
        /// タイトルバーの色を示す値
        /// </summary>
        private readonly uint titlebarColorValue;
        /// <summary>
        /// タイトルバーの文字色を示す値
        /// </summary>
        private readonly uint titlebarTextColorValue;
        /// <summary>
        /// 設定する色のフラグ
        /// </summary>
        private readonly WindowColorType type;

        /// <summary>
        /// 処理を行う属性値
        /// </summary>
        internal readonly WindowColorType Type
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => type;
        }

        /// <summary>
        /// 自身のプロセスID
        /// </summary>
        internal readonly uint ProcessId
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => processId;
        }

        /// <summary>
        /// 設定の有無と色を示す値
        /// </summary>
        /// <param name="index">色番号</param>
        internal (bool isSet, uint colorValue) this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                // 種類に応じた値を返す
                bool isSet = ((int)type & (1 << index)) != 0;
                uint colorValue = index switch
                {
                    0 => borderColorValue,          // 縁の色
                    1 => titlebarColorValue,        // タイトルバーの色
                    2 => titlebarTextColorValue,    // タイトルバーの文字色
                    _ => ColorUtil.DwmDefaultColor, // 未定義の種類である場合
                };

                return (isSet, colorValue);
            }
        }


        /// <summary>
        /// 構造体を構築する
        /// </summary>
        /// <param name="type">設定する色のフラグ</param>
        /// <param name="processId">プロセスID</param>
        /// <param name="borderColorValue">縁の色を示す値</param>
        /// <param name="titlebarColorValue">タイトルバーの色を示す値</param>
        /// <param name="titlebarTextColorValue">タイトルバーの文字色を示す値</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal SetWindowColorsCallbackParameters(
            WindowColorType type, uint processId, uint borderColorValue,
            uint titlebarColorValue, uint titlebarTextColorValue)
        {
            // 値を受け取る
            this.type = type;
            this.processId = processId;
            this.borderColorValue = borderColorValue;
            this.titlebarColorValue = titlebarColorValue;
            this.titlebarTextColorValue = titlebarTextColorValue;
        }
    }
}
#endif
