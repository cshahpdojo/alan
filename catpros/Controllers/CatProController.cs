using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using catpros.Models;
using Microsoft.EntityFrameworkCore;

namespace catpros.Controllers
{
    public class CatProController : Controller
    {
        private CatProsContext db;

        public CatProController(CatProsContext context)
        {
            db = context;
        }

        [HttpGet("category")]
        public IActionResult CategoryIndex()
        {
            List<Category> cats = db.categories.ToList();
            ViewBag.cats = cats;
            return View("catdex");
        }

        [HttpGet("product")]
        public IActionResult ProductIndex()
        {
            List<Product> pros = db.products.ToList();
            ViewBag.pros = pros;
            return View("prodex");
        }

        [Route("")]
        public IActionResult Index()
        {
            return RedirectToAction("ProductIndex");
        }

        [HttpPost("products")]
        public IActionResult CreateProduct(Product input)
        {
            // validatethebiz!
            if(ModelState.IsValid)
            {
                // add2db
                db.products.Add(input);
                System.Console.WriteLine("You got to here!");
                db.SaveChanges();
                input = new Product();
            }
            return View("prodex", input);
        }

        [HttpPost("categories")]
        public IActionResult CreateCategory(Category input)
        {
            Category data;
            if(ModelState.IsValid)
            {
                db.categories.Add(input);
                System.Console.WriteLine("Got HItherh");
                db.SaveChanges();
                data = new Category();
            }else{
                data = input;
            }
            return View("catdex", data);
        }


        [HttpGet("products/{id}")]
        public IActionResult ShowProduct(int id)
        {
            Product pro = db.products.Include(p => p.Associations).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == id);
            ViewBag.cats = db.categories.ToList();
            return View(pro);
        }


        [HttpPost("Associations")]
        public IActionResult CreateAssociation(int cat, int pro)
        {
            System.Console.WriteLine("Hey got the biz!");
            System.Console.WriteLine(cat.ToString());
            System.Console.WriteLine(pro.ToString());
            Association bob = new Association{ProductId=pro, CategoryId=cat};
            db.associations.Add(bob);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
