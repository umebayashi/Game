using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KnightGame.Core.Domains
{
	/// <summary>
	/// 駒の移動情報
	/// </summary>
	[Serializable]
	public class Move
	{
		#region constructor

		public Move()
		{
		}

		public Move(Player player, Position moveFrom, Position moveTo)
		{
			this.Player = player;
			this.MoveFrom = moveFrom;
			this.MoveTo = moveTo;
		}

		#endregion

		#region field / property

		public static readonly Position[] MovablePositions = new Position[]
		{
			new Position(1, 2),
			new Position(2, 1),
			new Position(2, -1),
			new Position(1, -2),
			new Position(-1, -2),
			new Position(-2, -1),
			new Position(-2, 1),
			new Position(-1, 2)
		};

		/// <summary>
		/// プレイヤーのセッション情報
		/// </summary>
		public Player Player { get; private set; }
 
		/// <summary>
		/// 移動元の位置
		/// </summary>
		public Position MoveFrom { get; private set; }

		/// <summary>
		/// 移動先の位置
		/// </summary>
		public Position MoveTo { get; private set; }

		#endregion

		#region static method

		#endregion

		#region method

		public override bool Equals(object obj)
		{
			if (obj is Move)
			{
				var target = (Move)obj;
				return (
					this.Player.Equals(target.Player) && 
					this.MoveFrom.Equals(target.MoveFrom) && 
					this.MoveTo.Equals(target.MoveTo));
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("[ Player: {0}, MoveFrom: {1}, MoveTo: {2} ]",
				this.Player,
				this.MoveFrom,
				this.MoveTo);
		}

		#endregion
	}
}
