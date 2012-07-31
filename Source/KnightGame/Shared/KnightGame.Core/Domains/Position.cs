using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KnightGame.Core.Domains
{
	/// <summary>
	/// 駒の位置
	/// </summary>
	[Serializable]
	public class Position
	{
		#region constructor

		public Position()
		{
		}

		public Position(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		#endregion

		#region field / property

		private static Random random = new Random(DateTime.Now.Millisecond);

		/// <summary>
		/// 位置の初期状態
		/// </summary>
		public static readonly Position Default = new Position(0, 0);

		/// <summary>
		/// X軸(列)
		/// </summary>
		public int X { get; private set; }

		/// <summary>
		/// Y軸(行)
		/// </summary>
		public int Y { get; private set; }

		#endregion

		#region static method

		public static Position Add(Position p1, Position p2)
		{
			return new Position(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Position CreateRandom(int size)
		{
			return new Position(random.Next(size) + 1, random.Next(size) + 1);
		}

		#endregion

		#region method

		public override bool Equals(object obj)
		{
			if (obj is Position)
			{
				var target = (Position)obj;
				return (this.X == target.X && this.Y == target.Y);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("[ X: {0}, Y: {1} ]", this.X, this.Y);
		}

		#endregion
	}
}
