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
        /*
         * Handles POST requests to process input from the form submission.
         * Trims the input word to remove any leading or trailing whitespace.
         * Validates the trimmed word to ensure it is not empty and does not contain spaces.
         * If valid, stores the word in TempData for use in the WordOutput action.
         * Redirects to the WordOutput action to display the processed word.
         * In case of exceptions, it returns an error view.
         */

        [HttpPost]
        public ActionResult Word(DataModel model)
        {

            try
            {
                var cleanWord = model.Word?.Trim();
               

                if (string.IsNullOrEmpty(cleanWord))
                {
                    ModelState.AddModelError("Word", "Input cannot be empty!");
                }
                else if (cleanWord.Contains(" "))
                {
                    ModelState.AddModelError("Word", "Try a single word; sentences will not be processed!");
                }

                TempData["Word"] = cleanWord;
                return RedirectToAction("WordOutput");
            }
            catch (Exception ex)
            {
             Console.WriteLine(ex.ToString());   
                return View("Error");
            }
        }
        /*
         * Displays the processed word.
         * Retrieves the word from TempData, converts it to uppercase, and generates a character array.
         * If the word is not found in TempData, redirects to the Index action.
         * Passes the character array to the view for display.
         */

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