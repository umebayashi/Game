using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightGame.Core.Domains
{
	[TestClass]
	public class GameLogicTest
	{
		[TestMethod]
		public void TestNewPlayer()
		{
			var gameLogic = new GameLogic();
			var player = gameLogic.NewPlayer("P01", "Player01");

			Assert.IsNotNull(player);
			Assert.AreNotEqual<Guid>(Guid.Empty, player.UID);
			Assert.AreEqual<string>("P01", player.ID);
			Assert.AreEqual<string>("Player01", player.Name);
			Assert.IsNull(player.CurrentPosition);
			Assert.IsNotNull(player.PositionHistory);
		}

		[TestMethod]
		public void TestNewSession()
		{
			var gameLogic = new GameLogic();

			var gameOption = new GameOption();

			var player01 = gameLogic.NewPlayer("P01", "Player01");
			var player02 = gameLogic.NewPlayer("P02", "Player02");

			var gameSession = gameLogic.NewSession(gameOption, new Player[] { player01, player02 });

			Assert.IsNotNull(gameSession);
			Assert.AreNotEqual<Guid>(Guid.Empty, gameSession.UID);
			Assert.IsNotNull(gameSession.Players);
			Assert.AreEqual<int>(2, gameSession.Players.Length);
			//Assert.IsNotNull(gameSession.Moves);
			//Assert.AreEqual<int>(0, gameSession.Moves.Count);

			for (int i = 0; i < gameSession.Players.Length; i++)
			{
				Assert.IsNotNull(gameSession.Players[i]);
				Assert.IsNotNull(gameSession.Players[i].CurrentPosition);
				Assert.AreEqual<int>(1, gameSession.Players[i].PositionHistory.Count);

				Console.WriteLine(gameSession.Players[i]);
			}
		}
	}
}
