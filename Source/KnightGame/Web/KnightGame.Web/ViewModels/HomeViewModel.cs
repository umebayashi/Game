using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnightGame.Web.ViewModels
{
	public class HomeViewModel
	{
		public HomeViewModel()
		{
		}

		#region field / property

		public GameViewModel GameModel { get; set; }

		#endregion
	}
}