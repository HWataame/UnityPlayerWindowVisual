/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの色を設定する用のパラメーターの構造体

SetWindowColorCallbackParameters.cs
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
    /// ウィンドウの色を設定する用のパラメーターの構造体
    /// </summary>
    internal readonly ref struct SetWindowColorCallbackParameters
    {
        /// <summary>
        /// 処理を行う属性値
        /// </summary>
        private readonly uint attributeType;
        /// <summary>
        /// 自身のプロセスID
        /// </summary>
        private readonly uint processId;
        /// <summary>
        /// 色を示す値
        /// </summary>
        private readonly uint colorValue;

        /// <summary>
        /// 処理を行う属性値
        /// </summary>
        internal readonly uint AttributeType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => attributeType;
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
        /// 色を示す値
        /// </summary>
        internal readonly uint ColorValue
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => colorValue;
        }


        /// <summary>
        /// 構造体を構築する
        /// </summary>
        /// <param name="attributeType">処理を行う属性値</param>
        /// <param name="processId">プロセスID</param>
        /// <param name="colorValue">色を示す値</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal SetWindowColorCallbackParameters(
            uint attributeType, uint processId, uint colorValue)
        {
            // 値を受け取る
            this.attributeType = attributeType;
            this.processId = processId;
            this.colorValue = colorValue;
        }
    }
}
#endif
