using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml;
using System.Xml.Linq;
using KnightGame.Core.Domains;
using KnightGame.Web.ViewModels;

namespace KnightGame.Web.Helpers
{
	public static class GameUIHelper
	{
		public static MvcHtmlString DrawGameUI(GameViewModel gameViewModel)
		{
			var tbody = new XElement("tbody");

			// 1行目: 座標行
			tbody.Add(GetBoardRow(gameViewModel, true));

			// 2行目～n+1行目:
			for (int row = gameViewModel.BoardSize; row >= 1; row--)
			{
				tbody.Add(GetBoardRow(gameViewModel, false, row));
			}

			// n+2行目: 座標行
			tbody.Add(GetBoardRow(gameViewModel, true));

			var xdoc = new XDocument(
				new XElement("div",
					new XAttribute("class", "chessBoardArea"),
					new XElement("table",
						new XAttribute("class", "chessBoard"),
						tbody
					)
				)
			);

			return new MvcHtmlString(xdoc.ToString());
		}

		private static XElement GetBoardCell(string tagName, string className, string value = null)
		{
			var tag = new XElement(tagName,
				new XAttribute("class", className)
			);
			if (value != null)
			{
				tag.Value = value;
			}

			return tag;
		}

		private static XElement GetBoardCell(string tagName, GameViewModel gameViewModel, int column, int row)
		{
			var tag = new XElement(tagName);

			var id = string.Format("R{0}C{1}", row, column);
			var attrID = new XAttribute("id", id);
			tag.Add(attrID);

			var className = GetDefaultCellCssClass(column, row);

			var boardCellStatus = gameViewModel.GetBoardCellStatus(column, row);
			switch (boardCellStatus.StatusType)
			{
				case BoardCellStatusType.Default:
					className = GetDefaultCellCssClass(column, row);
					break;
				case BoardCellStatusType.ActiveUserExists:
					tag.Add(new XElement("span", boardCellStatus.Player.DisplaySymbol));
					className = "activePiece";
					break;
				case BoardCellStatusType.PieceExists:
					tag.Add(new XElement("span", boardCellStatus.Player.DisplaySymbol));
					break;
				case BoardCellStatusType.NextAvailable:
					className = "nextAvailable";
					break;
				case BoardCellStatusType.PlayerVisited:
					className = GetDefaultCellCssClass(column, row);
					tag.Add(new XElement("span", boardCellStatus.Player.Number.ToString()));
					break;
			}

			var attrClass = new XAttribute("class", className);
			tag.Add(attrClass);

			return tag;
		}

		private static string GetColorValue(Color color)
		{
			return string.Format("#{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"));
		}

		private static string GetDefaultCellCssClass(int column, int row)
		{
			bool isBlack = ((column + row) % 2) == 0;
			return isBlack ? "blackCell" : "whiteCell";
		}

		private static string GetPlayerVisitedCellCssClass(BoardCellStatus cellStatus)
		{
			return null;
		}

		private static XElement GetBoardRow(GameViewModel gameViewModel, bool isCoordRow, int row = 0)
		{
			var tr = new XElement("tr");

			if (isCoordRow)
			{
				tr.Add(GetBoardCell("td", "boardCorner"));

				var ch = 'a';
				for (int col = 1; col <= gameViewModel.BoardSize; col++)
				{
					tr.Add(GetBoardCell("th", "hCoords", ch.ToString()));

					ch = (char)(((int)ch) + 1);
				}

				tr.Add(GetBoardCell("td", "boardCorner"));
			}
			else
			{
				tr.Add(GetBoardCell("th", "vCoords", row.ToString()));

				for (int col = 1; col <= gameViewModel.BoardSize; col++)
				{
					var td = GetBoardCell("td", gameViewModel, col, row);
					tr.Add(td);
				}

				tr.Add(GetBoardCell("th", "vCoords", row.ToString()));
			}

			return tr;
		}
	}
}