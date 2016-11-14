using Microsoft.AspNetCore.Mvc;

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
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var array = TextMatchUtility.GetMatchedIndexes(model.Text, model.SubText);

            string matchingResults = null;

            for (int i = 0; i < array.Length; i++)
            {
                matchingResults = matchingResults + array[i];

                if (i + 1 < array.Length)
                {
                    matchingResults = matchingResults + ",";
                }
            }

            model.MatchingResult = matchingResults; 

            return this.View(model);
        }
    }
}