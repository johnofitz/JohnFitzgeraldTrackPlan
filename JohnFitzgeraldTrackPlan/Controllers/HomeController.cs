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
                // Trim whitespace from the input word
                var word = model.Word.Trim();

                // Validate the trimmed word
                if (string.IsNullOrEmpty(word))
                {
                    // Add error message if the input is empty
                    ModelState.AddModelError("Word", "Input cannot be empty!");
                }
                else if (word.Contains(" "))
                {
                    // Add error message if the input contains spaces
                    ModelState.AddModelError("Word", "Try a single word; sentences will not be processed!");
                }

                // If model state is valid, store the word in TempData and redirect
                if (ModelState.IsValid)
                {
                    TempData["Word"] = word;
                    return RedirectToAction("WordOutput");
                }

                // If model state is not valid, return the view with validation messages
                return View(model);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.ToString());
                // Return error view in case of an exception
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

            // Retrieve the word from TempData
            string word = TempData["Word"] as string;

            // Redirect to the Index action if no word is found in TempData
            if (word == null)
            {
                return RedirectToAction("Index");
            }

            // Convert the word to uppercase and create a character array
            string upperWord = word.ToUpper();
            char[] charArray = upperWord.ToCharArray();

            // Create a new model with the character array
            var model = new DataModel { CharArray = charArray };

            // Return the view with the model
            return View(model);
        }

    }
}