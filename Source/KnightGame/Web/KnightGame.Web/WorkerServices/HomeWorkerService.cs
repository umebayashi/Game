using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnightGame.Core.Domains;
using KnightGame.Web.ViewModels;

namespace KnightGame.Web.WorkerServices
{
	public class HomeWorkerService
	{
		public HomeViewModel GetViewModel()
		{
			var homeViewModel = new HomeViewModel();

			homeViewModel.GameModel = this.GetGameViewModel();

			return homeViewModel;
		}

		private GameViewModel GetGameViewModel()
		{
			var gameLogic = new GameLogic();

			var gameOption = new GameOption();
			var p01 = gameLogic.NewPlayer("P01", "Player01");
			var p02 = gameLogic.NewPlayer("P02", "Player02");
			p01.DisplaySymbol = "♘";
			p02.DisplaySymbol = "♞";
			var gameSession = gameLogic.NewSession(gameOption, new Player[] { p01, p02 });

			var gameViewModel = new GameViewModel(gameSession);
			return gameViewModel;
		}
	}
}