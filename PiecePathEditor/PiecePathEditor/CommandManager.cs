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
    public class CommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static CommandManager Instance { get; } = new CommandManager();

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
        public enum CommandTypes
        {
            /// <summary>
            /// 
            /// </summary>
            None,

            /// <summary>
            /// 
            /// </summary>
            Add,

            /// <summary>
            /// 
            /// </summary>
            Move,

            /// <summary>
            /// 
            /// </summary>
            Remove,
        }

        /// <summary>
        /// 
        /// </summary>
        public class Command
        {
            /// <summary>
            /// 
            /// </summary>
            public CommandTypes Type { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public Point Point { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Queue<Command> CommandQueue;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private CommandManager()
        {

        }
    }
}
