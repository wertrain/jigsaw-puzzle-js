﻿using System;
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
        /// 
        /// </summary>
        public Point()
        {
            X = Y = 0;
        }

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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="point"></param>
        /// <param name="scale"></param>
        public Point(Point point, float scale)
        {
            X = (int)(point.X * scale);
            Y = (int)(point.Y * scale);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="point"></param>
        /// <param name="scale"></param>
        public Point(int x, int y, float scale)
        {
            X = (int)(x * scale);
            Y = (int)(y * scale);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        public Stack<CommandBase> CommandStack;

        /// <summary>
        /// 
        /// </summary>
        public Stack<CommandBase> CommandHistoryStack;

        /// <summary>
        /// 
        /// </summary>
        public LinkedList<Point> Points;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AddPoint(int x, int y)
        {
            AddPoint(new Point(x, y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(Point point)
        {
            CommandStack.Push(new CommandAddPoint(point));
            Points.AddLast(point);

            CommandHistoryStack.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void InsertPoint(int index, int x, int y)
        {
            InsertPoint(index, new Point(x, y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public void InsertPoint(int index, Point point)
        {
            CommandStack.Push(new CommandInsertPoint(point, index));

            var points = Points.ToList();
            points.Insert(index + 1, point);
            Points = new LinkedList<Point>(points);

            CommandHistoryStack.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MovePoint(Point startPoint, Point point)
        {
            var find = Points.Find(point);
            if (find != null)
            {
                var findPoint = find.Value;
                CommandStack.Push(new CommandMovePoint(startPoint, point));
            }

            CommandHistoryStack.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public void RemovePoint(Point point)
        {
            var find = Points.Find(point);
            if (find != null)
            {
                CommandStack.Push(new CommandRemovePoint(find.Value, find.Previous.Value));
                Points.Remove(point);
            }

            CommandHistoryStack.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool UndoCommand()
        {
            if (CommandStack.Count == 0) return false;

            var history = CommandStack.Pop();
            switch(history)
            {
                case CommandAddPoint command:
                    Points.Remove(command.Point);
                    break;

                case CommandRemovePoint command:
                    var prev = Points.Find(command.PrevPoint);
                    Points.AddAfter(prev, command.Point);
                    break;

                case CommandMovePoint command:
                    var find = Points.Find(command.MovedPoint);
                    if (find != null)
                    {
                        var findPoint = find.Value;
                        findPoint.X = command.Point.X;
                        findPoint.Y = command.Point.Y;
                    }
                    break;

                case CommandInsertPoint command:
                    Points.Remove(command.Point);
                    break;
            }

            CommandHistoryStack.Push(history);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool RedoCommand()
        {
            if (CommandHistoryStack.Count == 0) return false;

            var history = CommandHistoryStack.Pop();
            switch (history)
            {
                case CommandAddPoint command:
                    Points.AddLast(command.Point);
                    break;

                case CommandInsertPoint command:
                    var points = Points.ToList();
                    points.Insert(command.Index + 1, command.Point);
                    Points = new LinkedList<Point>(points);
                    break;

                case CommandMovePoint command:
                    var point = Points.Find(command.MovedPoint);
                    point.Value.X = command.Point.X;
                    point.Value.Y = command.Point.Y;
                    break;
            }

            CommandStack.Push(history);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            CommandStack.Clear();
            CommandHistoryStack.Clear();
            Points.Clear();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CommandManager()
        {
            CommandStack = new Stack<CommandBase>();
            CommandHistoryStack = new Stack<CommandBase>();
            Points = new LinkedList<Point>();
        }
    }
}
