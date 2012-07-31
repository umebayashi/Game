using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightGame.Core.Domains
{
	public class GameLogic
	{
		#region constructor

		public GameLogic()
		{
		}

		#endregion

		#region method

		/// <summary>
		/// 新規プレイヤーを作成する
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public Player NewPlayer(string id, string name)
		{
			var player = Player.CreatePlayer(id, name);

			return player;
		}

		public Player LoadPlayer(string id)
		{
			var player = Player.LoadPlayer(id);

			return player;
		}

		public GameSession NewSession(GameOption gameOption, Player[] players)
		{
			var session = GameSession.CreateSession(gameOption, players);

			this.SetInitialPlayerPositions(gameOption, players);

			return session;
		}

		private void SetInitialPlayerPositions(GameOption gameOption, Player[] players)
		{
			if (gameOption.RandomStartPosition)
			{
				var listPosition = new List<Position>();
				for (int i = 0; i < players.Length; i++)
				{
					while (true)
					{
						var initialPosition = Position.CreateRandom(gameOption.BoardSize);
						if (listPosition.Contains(initialPosition))
						{
							continue;
						}

						players[i].SetInitialPosition(initialPosition);
						listPosition.Add(initialPosition);
						break;
					}
				}
			}
		}

		#endregion
	}
}
