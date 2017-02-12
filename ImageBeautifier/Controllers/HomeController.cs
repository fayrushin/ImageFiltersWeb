using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using BitmapFilters;


namespace ImageBeautifier.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var mvcName = typeof(Controller).Assembly.GetName();
			var isMono = Type.GetType("Mono.Runtime") != null;

			ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData["Runtime"] = isMono ? "Mono" : ".NET";

			return View();
		}

		[HttpPost]
		public string SepiaImage(string name)
		{
			try
			{
				var image = Image.FromFile(name);
				var sepiaImage = image.DrawAsGrayscale();
				var newImagePath = Guid.NewGuid() + "sepia.png";
				sepiaImage.Save(newImagePath);
				return newImagePath;
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("The file is not found in: {0}",name);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return "";
		}




	
	}


}
