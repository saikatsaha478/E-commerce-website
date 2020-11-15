using Bidly.Dal;
using Bidly.Models;
using Bidly.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bidly.Controllers
{
    public class AdminController : Controller
    {
        public GenerixUnitofWork _unitofwork = new GenerixUnitofWork();
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories()
        {
            List<Tbl_category> allcategories = _unitofwork.GetRepositoryInstance<Tbl_category>().GetallRecordsuearable().Where(i => i.Is_Delete == false).ToList();
            return View(allcategories);
        }

        public ActionResult Addcategory()
        {
            return Updatecategory(0);
        }

        public ActionResult Updatecategory(int categoryid)
        {
            category_detail cd;
            if (categoryid != null)
            {
                cd = JsonConvert.DeserializeObject<category_detail>(JsonConvert.SerializeObject(_unitofwork.GetRepositoryInstance<Tbl_category>().GetFirstorDefault(categoryid)));
            }
            else
            {
                cd = new category_detail();
            }
            return View("UpdateCategory", cd);
        }

        public ActionResult product()
        {
            return View(_unitofwork.GetRepositoryInstance<Tbl_product>().GetProduct());
        }

        public ActionResult productedit(int productid)
        {
            return View(_unitofwork.GetRepositoryInstance<Tbl_product>().GetFirstorDefault(productid));
        }

        [HttpPost]
        public ActionResult productedit(Tbl_product tbl)
        {
            _unitofwork.GetRepositoryInstance<Tbl_product>().Update(tbl);
            return RedirectToAction("product");
        }

        public ActionResult productAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult productAdd(Tbl_product tbl)
        {
            _unitofwork.GetRepositoryInstance<Tbl_product>().Add(tbl);
            return RedirectToAction("product");
        }
    }
}