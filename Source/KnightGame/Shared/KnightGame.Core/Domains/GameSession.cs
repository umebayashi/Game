﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KnightGame.Core.Domains
{
	[Serializable]
	public class GameSession
	{
		#region constructor

		public GameSession()
		{
			this.Moves = new List<Move>();
			this.BoardCellStatuses = new List<BoardCellStatus>();
		}

		#endregion

		#region field / property

		public Guid UID { get; private set; }

		public GameOption GameOption { get; private set; }

		public Player[] Players { get; private set; }

		public Player ActivePlayer { get; private set; }

		private List<Move> Moves { get; set; }

		private List<BoardCellStatus> BoardCellStatuses { get; set; }

		#endregion

		#region static method

		public static GameSession CreateSession(GameOption gameOption, Player[] players)
		{
			var newUID = Guid.NewGuid();
			var session = new GameSession { UID = newUID, GameOption = gameOption, Players = players, ActivePlayer = players[0] };

			foreach (var player in players)
			{
				player.PieceMoved += session.Player_PieceMoved;
			}

			session.InitializeBoardCellStatusList();

			return session;
		}

		#endregion

		#region method

		public BoardCellStatus GetBoardCellStatus(int column, int row)
		{
			var bcStatus = this.BoardCellStatuses
				.Where(x => x.Column == column && x.Row == row)
				.FirstOrDefault();

			return bcStatus;
		}

		private void Player_PieceMoved(object sender, MovePieceEventArgs e)
		{
			this.Moves.Add(e.Move);
			this.UpdateBoardCellStatusList();
		}

		private void InitializeBoardCellStatusList()
		{
			this.BoardCellStatuses.Clear();
			for (int col = 1; col <= this.GameOption.BoardSize; col++)
			{
				for (int row = 1; row <= this.GameOption.BoardSize; row++)
				{
					var bcStatus = new BoardCellStatus(col, row, BoardCellStatusType.Default, null);
					this.BoardCellStatuses.Add(bcStatus);
				}
			}
		}

		private void UpdateBoardCellStatusList()
		{
			foreach (var move in this.Moves)
			{
				var bcStatus = this.BoardCellStatuses
					.Where(x => x.Column == move.MoveTo.X && x.Row == move.MoveTo.Y)
					.First();

				bcStatus.StatusType = BoardCellStatusType.PlayerVisited;
				bcStatus.Player = move.Player;
			}

			foreach (var player in this.Players)
			{
				if (player.CurrentPosition != null)
				{
					var bcStatus = this.BoardCellStatuses
						.Where(x => x.Column == player.CurrentPosition.X && x.Row == player.CurrentPosition.Y)
						.First();

					if (player == this.ActivePlayer)
					{
						bcStatus.StatusType = BoardCellStatusType.ActiveUserExists;
						this.SetNextAvailableCells(player);
					}
					else
					{
						bcStatus.StatusType = BoardCellStatusType.PieceExists;
					}
				}

			}
		}

		private void SetNextAvailableCells(Player player)
		{
			foreach (var movablePosition in Move.MovablePositions)
			{
				var nextPosition = Position.Add(player.CurrentPosition, movablePosition);

				var bcStatus = this.BoardCellStatuses
					.Where(x => x.Column == nextPosition.X && x.Row == nextPosition.Y)
					.FirstOrDefault();

				if (bcStatus != null && bcStatus.StatusType == BoardCellStatusType.Default)
				{
					bcStatus.StatusType = BoardCellStatusType.NextAvailable;
				}
			}
		}

		#endregion
	}
}
