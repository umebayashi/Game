using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnightGame.Core.Domains;

namespace KnightGame.Web.ViewModels
{
	public class GameViewModel
	{
		#region constructor

		public GameViewModel()
		{
		}

		public GameViewModel(GameSession gameSession)
		{
			this.GameSession = gameSession;
		}

		#endregion

		#region field / property

		public GameSession GameSession { get; set; }

		public int BoardSize
		{
			get
			{
				return this.GameSession.GameOption.BoardSize;
			}
		}

		#endregion

		#region method

		public BoardCellStatus GetBoardCellStatus(int column, int row)
		{
			return this.GameSession.GetBoardCellStatus(column, row);
		}

		#endregion
	}
}