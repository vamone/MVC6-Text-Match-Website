using System;
using Microsoft.AspNetCore.Mvc;

using TextMatch.Website.Extension;
using TextMatch.Website.Models;
using TextMatch.Website.Utilities;

namespace TextMatch.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new TextMatchViewModel();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Index(TextMatchViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.View(model);
                }

                var indexes = TextMatchUtility.GetMatchedIndexes(model.Text, model.SubText);

                model.MatchingResult = indexes.JoinArrayIntoStringBySeparator(',');
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }
    }
}