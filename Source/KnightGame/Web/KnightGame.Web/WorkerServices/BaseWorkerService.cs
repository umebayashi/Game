using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnightGame.Web.WorkerServices
{
	public class BaseWorkerService
	{
		public BaseWorkerService(Controller controller)
		{
			this.Controller = controller;
		}

		protected Controller Controller
		{
			get;
			private set;
		}
	}
}