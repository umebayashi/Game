using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightGame.Core.Domains
{
	public class MovePieceEventArgs : EventArgs
	{
		#region constructor

		public MovePieceEventArgs(Move move)
			: base()
		{
			this.Move = move;
		}

		#endregion

		#region field / property

		public Move Move { get; private set; }

		#endregion
	}

	public delegate void MovePieceEventHandler(object sender, MovePieceEventArgs e);
}
