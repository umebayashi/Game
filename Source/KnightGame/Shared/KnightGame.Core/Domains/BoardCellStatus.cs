﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightGame.Core.Domains
{
	public class BoardCellStatus
	{
		#region construcot

		public BoardCellStatus()
		{
			this.StatusType = BoardCellStatusType.Default;
		}

		public BoardCellStatus(int column, int row, BoardCellStatusType statusType, Player player)
		{
			this.Column = column;
			this.Row = row;
			this.StatusType = statusType;
			this.Player = player;
		}

		#endregion

		#region field / property

		public int Row { get; set; }

		public int Column { get; set; }

		public BoardCellStatusType StatusType { get; set; }

		public Player Player { get; set; }

		#endregion
	}

	/// <summary>
	/// ゲーム盤の特定のマス目の状態種別
	/// </summary>
	public enum BoardCellStatusType
	{
		/// <summary>
		/// 初期状態(駒が過去／現在に配置されたことがない)
		/// </summary>
		Default,

		/// <summary>
		/// 駒が現在配置されている
		/// </summary>
		PieceExists,

		/// <summary>
		/// 駒が過去に配置されたことがある
		/// </summary>
		PlayerVisited,

		/// <summary>
		/// アクティブユーザの駒が現在配置されている
		/// </summary>
		ActiveUserExists,

		/// <summary>
		/// アクティブユーザが次に駒を配置できる
		/// </summary>
		NextAvailable
	}
}
