using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudApp.Models;
using CrudApp.Bll;
namespace CrudApp.Controllers
{
    public class ArticleController : Controller
    {
         [HttpGet]
        public IActionResult Index()
        {
                    
            return View(ArticleBll.SeletAllArticles());
        }
        
        [HttpPost]
         public IActionResult Index(string KeyWord)
        {
           if(String.IsNullOrEmpty(KeyWord))
                return View(null);
            return View(ArticleBll.SearchArticles(KeyWord));
        }    
        public IActionResult Show(int? Reference)
        {
            if (Reference == null)
            {
                return NotFound();
            }
            
            var Article = ArticleBll.SelectArticle(Reference.Value);
            if (Article == null)
            {
                return NotFound();
            }
            
            return View(Article);
        }
        public IActionResult Edit(int? Reference)
        {
             if (Reference == null)
            {
                return NotFound();
            }
            
            var Article = ArticleBll.SelectArticle(Reference.Value);
            if (Article == null)
            {
                return NotFound();
            }
            
            return View(Article);
        }
        public IActionResult Update([Bind] Article P)
        {
            ArticleBll.Update(P);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? Reference)
        {
            if (Reference == null)
            {
                return NotFound();
            }
            
            ArticleBll.Delete(Reference.Value);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Store([Bind] Article P)
        {
            ArticleBll.Insert(P);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
