using System;
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
            try
            {
                var word =model.Word.Trim();

                if (string.IsNullOrEmpty(word))
                {
                    ModelState.AddModelError("Word", "Input cannot be empty!");
                }
                else if (word.Contains(" "))
                {
                    ModelState.AddModelError("Word", "Try a single word; sentences will not be processed!");
                }

                TempData["Word"] = word;
                return RedirectToAction("WordOutput");
            }
            catch (Exception ex)
            {
                return View("Error"); 
            }
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