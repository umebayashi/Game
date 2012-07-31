using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KnightGame.Core.Domains
{
	[Serializable]
	public class Player
	{
		#region constructor

		public Player()
		{
			this.PositionHistory = new List<Position>();
		}

		public Player(Guid uid, string id, string name) : this()
		{
			this.UID = uid;
			this.ID = id;
			this.Name = name;
		}

		#endregion

		#region field / property

		/// <summary>
		/// 内部ユニークID
		/// </summary>
		public Guid UID { get; private set; }

		/// <summary>
		/// ユーザID
		/// </summary>
		public string ID { get; private set; }

		/// <summary>
		/// ユーザ名
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// プレイヤー番号
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// 駒のシンボルとして表示する文字列
		/// </summary>
		public string DisplaySymbol { get; set; }

		/// <summary>
		/// 過去訪れたマス目に表示する色
		/// </summary>
		public Color VisitedColor { get; set; }

		/// <summary>
		/// 現在の駒の位置
		/// </summary>
		public Position CurrentPosition { get; private set; }

		/// <summary>
		/// 駒の位置の履歴
		/// </summary>
		public List<Position> PositionHistory { get; private set; }

		#endregion

		#region event

		public event MovePieceEventHandler PieceMoved;

		#endregion

		#region static method

		public static Player CreatePlayer(string id, string name)
		{
			var player = new Player { UID = Guid.NewGuid(), ID = id, Name = name };

			return player;
		}

		public static Player LoadPlayer(string id)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region method

		public override bool Equals(object obj)
		{
			if (obj is Player)
			{
				var target = (Player)obj;
				return this.UID.Equals(target.UID);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("[ UID: {0}, ID: {1}, Name: {2}, CurrentPosition: {3} ]",
				this.UID,
				this.ID,
				this.Name,
				this.CurrentPosition == null ? "(null)" : this.CurrentPosition.ToString());
		}

		/// <summary>
		/// プレイヤーの初期位置を設定する
		/// </summary>
		/// <param name="initialPosition"></param>
		public void SetInitialPosition(Position initialPosition)
		{
			this.CurrentPosition = Position.Default;
			this.MovePiece(initialPosition);
		}

		/// <summary>
		/// プレイヤーが自分の持ち駒を動かす
		/// </summary>
		/// <param name="moveTo"></param>
		public void MovePiece(Position moveTo)
		{
			var move = new Move(this, this.CurrentPosition, moveTo);
			this.CurrentPosition = moveTo;
			this.PositionHistory.Add(moveTo);

			var args = new MovePieceEventArgs(move);
			if (this.PieceMoved != null)
			{
				this.PieceMoved(this, args);
			}
		}

		#endregion
	}
}
