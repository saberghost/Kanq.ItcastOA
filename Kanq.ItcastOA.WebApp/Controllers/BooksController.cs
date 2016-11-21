using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kanq.ItcastOA.IBLL;
using Kanq.ItcastOA.Model;

namespace Kanq.ItcastOA.WebApp.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public IBooksService BooksService { get; set; }
        public ActionResult Index()
        {
            BooksService.AddEntity(new Books
            {
                Author = "SSS",
                AurhorDescription = "4",
                CategoryId = 4,
                Clicks = 4,
                ContentDescription = "4",
                EditorComment = "3",
                ISBN = "sss",
                PublishDate = DateTime.Now,
                PublisherId = 4,
                Title = "4",
                TOC = "4",
                UnitPrice = 99,
                WordsCount = 1
            });
            return View();
        }
    }
}