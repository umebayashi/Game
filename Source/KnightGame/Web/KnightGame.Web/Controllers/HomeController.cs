using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnightGame.Web.Models;
using KnightGame.Web.WorkerServices;

namespace KnightGame.Web.Controllers
{
	public class HomeController : Controller
	{
		public HomeController()
		{
			this.WorkerService = new HomeWorkerService(this);
		}

		public HomeWorkerService WorkerService { get; set; }

		public ActionResult Index(string cellID)
		{
			var viewModel = this.WorkerService.GetViewModel(cellID);

			return View(viewModel);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
