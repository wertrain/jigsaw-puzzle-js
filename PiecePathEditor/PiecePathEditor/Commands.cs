﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiecePathEditor
{
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
        /// <summary>
        /// 
        /// </summary>
        public Point Point { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="point"></param>
        public CommandAddPoint(Point point) => Point = point;
    }

    /// <summary>
    /// ポイント挿入コマンド
    /// </summary>
    public class CommandInsertPoint : CommandBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Point Point { get; }

        /// <summary>
        /// 挿入インデックス
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="point"></param>
        public CommandInsertPoint(Point point, int index)
        {
            Point = point;
            Index = index;
        }
    }

    /// <summary>
    /// ポイント移動コマンド
    /// </summary>
    public class CommandMovePoint : CommandBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Point Point;

        /// <summary>
        /// 
        /// </summary>
        public Point MovedPoint;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="moved"></param>
        public CommandMovePoint(Point point, Point moved)
        {
            Point = point;
            MovedPoint = moved;
        }
    }

    /// <summary>
    /// ポイント削除コマンド
    /// </summary>
    public class CommandRemovePoint : CommandBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Point Point;

        /// <summary>
        /// 
        /// </summary>
        public Point PrevPoint;

        /// <summary>
        /// 
        /// </summary>
        public CommandRemovePoint(Point point, Point prevPoint)
        {
            Point = point;
            PrevPoint = prevPoint;
        }
    }
}
