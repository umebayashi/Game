using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightGame.Core.Domains
{
	public class GameOption
	{
		#region constructor

		public GameOption()
		{
			this.BoardSize = DEFAULT_BOARD_SIZE;
			this.PlayerCount = DEFAULT_PLAYER_COUNT;
			this.RandomStartPosition = DEFAULT_RANDOM_START_POSITION;
		}

		#endregion

		#region constant

		public const int DEFAULT_BOARD_SIZE = 8;

		public const int DEFAULT_PLAYER_COUNT = 2;

		public const bool DEFAULT_RANDOM_START_POSITION = true;

		#endregion

		#region field / property

		/// <summary>
		/// ゲーム盤(チェス盤)の縦/横のマス目の数
		/// </summary>
		public int BoardSize { get; set; }

		/// <summary>
		/// プレイヤーの数
		/// </summary>
		public int PlayerCount { get; set; }

		/// <summary>
		/// 開始時の駒の配置をランダムにするかどうか
		/// </summary>
		public bool RandomStartPosition { get; set; }

		#endregion
	}
}
