using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiecePathEditor
{
    /// <summary>
    /// 
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
        public static CommandManager Instance { get; } = new CommandManager();

        /// <summary>
        /// 
        /// </summary>
        public Queue<CommandBase> CommandQueue;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private CommandManager()
        {

        }
    }
}
