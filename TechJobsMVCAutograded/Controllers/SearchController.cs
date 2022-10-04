using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded.Data;
using TechJobsMVCAutograded.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVCAutograded.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3 - Create an action method to process a search request and render the updated search views.

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs = new List<Job>();
            if (searchTerm.Equals("all") || searchTerm.Equals(null) || searchTerm.Equals(""))
            {
                jobs = JobData.FindAll();
            }
            else
            {
               jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = $"Search Condition: ${ListController.ColumnChoices[searchType]} Search Term: ${searchTerm}";
            return View(jobs);

        }
    }
}
