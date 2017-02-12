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
			//var mvcName = typeof(Controller).Assembly.GetName();
			//var isMono = Type.GetType("Mono.Runtime") != null;

			//ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			//ViewData["Runtime"] = isMono ? "Mono" : ".NET";

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
			return "";
		}
		public string NegativeImage(string name)
		{
			try
			{
				var image = Image.FromFile(name);
				var negativeImage = image.DrawAsNegative();
				var newImagePath = Guid.NewGuid() + "negative.png";
				negativeImage.Save(newImagePath);
				return newImagePath;
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("The file is not found in: {0}", name);
			}
			return "";
		}
		public string TransparImage(string name)
		{
			try
			{
				var image = Image.FromFile(name);
				var transparImage = image.DrawWithTransparency();
				var newImagePath = Guid.NewGuid() + "transpar.png";
				transparImage.Save(newImagePath);
				return newImagePath;
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("The file is not found in: {0}", name);
			}
			return "";
		}
		public string GrayscaleImage(string name)
		{
			try
			{
				var image = Image.FromFile(name);
				var grayscaleImage = image.DrawAsGrayscale();
				var newImagePath = Guid.NewGuid() + "grayscale.png";
				grayscaleImage.Save(newImagePath);
				return newImagePath;
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("The file is not found in: {0}", name);
			}
			return "";
		}




	
	}


}
