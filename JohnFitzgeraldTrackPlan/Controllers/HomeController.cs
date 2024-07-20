using System.Text.RegularExpressions;
using System.Web.Mvc;
using JohnFitzgeraldTrackPlan.Models;

namespace JohnFitzgeraldTrackPlan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Welcome";
            return View();
            
        }


        [HttpPost]
        public ActionResult Word(DataModel model)
        {
            if (model.Word != null && model.Word.Contains(" "))
            {
                ModelState.AddModelError("Word", "Try a single word; sentences will not be processed!");
            }

            if (!ModelState.IsValid)
            {
                return View(model); // Return to the form view with validation messages
            }

            // Store the data in TempData
            TempData["Word"] = model.Word;

            // Redirect to another action
            return RedirectToAction("WordOutput");
        }


        public ActionResult WordOutput()
        {
            ViewBag.Title = "Word Display";
            // Retrieve the data from TempData
            string word = TempData["Word"] as string;

            if (word == null)
            {
                // Redirect to home if data is not present
                return RedirectToAction("Index");
            }

            string upperWord = word.ToUpper();
            char[] charArray = upperWord.ToCharArray();

            var model = new DataModel { CharArray = charArray };

            return View(model);
        }





    }
}