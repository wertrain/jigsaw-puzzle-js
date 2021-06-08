using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiecePathEditor
{
    /// <summary>
    /// 座標
    /// </summary>
    public class Point
    {
        /// <summary>
        /// 
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// コマンドの基底クラス
    /// </summary>
    public class CommandBase
    {

    }

    /// <summary>
    /// ポイント追加コマンド
    /// </summary>
    public class CommandAddPoint : CommandBase
    {

    }

    /// <summary>
    /// ポイント移動コマンド
    /// </summary>
    public class CommandMovePoint :CommandBase
    {

    }
}
