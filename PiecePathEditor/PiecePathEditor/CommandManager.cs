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
    /// 
    /// </summary>
    public class CommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        public Queue<CommandBase> CommandQueue;

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
            CommandQueue.Enqueue(new CommandAddPoint(point));
            Points.AddLast(point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MovePoint(Point point, int x, int y)
        {
            var find = Points.Find(point);
            if (find != null)
            {
                var findPoint = find.Value;
                CommandQueue.Enqueue(new CommandMovePoint(new Point(findPoint.X, findPoint.Y), new Point(x, y)));

                findPoint.X = x;
                findPoint.Y = y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public void RemovePoint(Point point)
        {
            if (Points.Remove(point))
            {
                CommandQueue.Enqueue(new CommandRemovePoint(point));
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CommandManager()
        {
            CommandQueue = new Queue<CommandBase>();
            Points = new LinkedList<Point>();
        }
    }
}
