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
        public Queue<CommandBase> CommandQueue;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private CommandManager()
        {

        }
    }
}
