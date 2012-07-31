using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnightGame.Core.Domains;
using KnightGame.Web.ViewModels;

namespace KnightGame.Web.WorkerServices
{
	public class HomeWorkerService : BaseWorkerService
	{
		public HomeWorkerService(Controller controller) : base(controller)
		{
		}

		private const string SESSION_KEY_GAME_SESSION = "GAME_SESSION";

		private GameSession InitGameSession()
		{
			var gameLogic = new GameLogic();
			var gameOption = new GameOption();
			var p01 = gameLogic.NewPlayer("P01", "Player01");
			var p02 = gameLogic.NewPlayer("P02", "Player02");
			p01.DisplaySymbol = "♘";
			p01.VisitedColor = Color.Cyan;
			p01.Number = 1;
			p02.DisplaySymbol = "♞";
			p02.VisitedColor = Color.Magenta;
			p02.Number = 2;
			var gameSession = gameLogic.NewSession(gameOption, new Player[] { p01, p02 });

			this.Controller.Session[SESSION_KEY_GAME_SESSION] = gameSession;

			return gameSession;
		}

		private GameSession GetGameSession()
		{
			var gameSession = this.Controller.Session[SESSION_KEY_GAME_SESSION] as GameSession;
			if (gameSession == null)
			{
				return this.InitGameSession();
			}
			else
			{
				return gameSession;
			}
		}

		public HomeViewModel GetViewModel(string cellID)
		{
			var homeViewModel = new HomeViewModel();

			homeViewModel.GameModel = this.GetGameViewModel(cellID);

			return homeViewModel;
		}

		private GameViewModel GetGameViewModel(string cellID)
		{
			var gameSession = this.GetGameSession();
			if (cellID != null)
			{
				gameSession.MovePiece(cellID);
			}

			var gameViewModel = new GameViewModel(gameSession);
			return gameViewModel;
		}
	}
}