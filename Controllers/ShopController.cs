
using System;
using System.Web.Mvc;
using BoutiqueShopTest.Models;

namespace BoutiqueShopTest.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var DBshow = new DataBaseConnection();
            var Get = DBshow.GetAllDetails();
            return View(Get);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var con = new DataBaseConnection();
            return View(new ShopEntity());
        }
        [HttpPost]
        public ActionResult Create(ShopEntity shopping)
        {
            var make = new DataBaseConnection();
            try
            {

                make.AddNewDress(shopping);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        public ActionResult Changes(int id)
        {
            //int change = Convert.ToInt32(id);
            var comp = new DataBaseConnection();
            try
            {
                var update = comp.FindDress(id);
                return View(update);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        public ActionResult Changes(ShopEntity post)
        {
            var conn = new DataBaseConnection();
            try
            {

                conn.UpdateDress(post);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ActionResult Delete(string id)
        {
            int shopnum = Convert.ToInt32(id);
            var conne = new DataBaseConnection();

            try
            {
                conne.DeleteDress(shopnum);
                return RedirectToAction("index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Show()
        {
            return View();
        }
    }
}