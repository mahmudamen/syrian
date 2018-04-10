using Syrian.Models;
using Syrian.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Syrian.Controllers
{
   // [AuthorizeRoles("Admin")]
    public class AdminController : Controller
    {
        SyDB db = new SyDB();
        public ActionResult Index()
        {
            ViewBag.itmtype = new SelectList(db.TypeList, "TypID", "TypName");
            return View();
        }
        public ActionResult cash()
        {
            ViewBag.itmtype = new SelectList(db.TypeList, "TypID", "TypName");
            return View();
        }
        public JsonResult lastshift()
        {

            var query = db.Shft
            .Count();
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        public JsonResult gdate()
        {
            var query = DateTime.Now;
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        public JsonResult adshf(bool a)
        {
            Shft bi = new Shft();
            bi.ShID = db.Shft.ToList().LastOrDefault().ShID + 1 ;
            bi.ShftDate = DateTime.Now ;
            bi.ShftT = a;
            db.Shft.Add(bi);
            db.SaveChanges();
            return Json(new { Success = true },JsonRequestBehavior.AllowGet);
           
        }
        public JsonResult Tlist()
        {
            SyDB db = new SyDB();
            var query = db.ItmList.Where(x => x.ItmType == 1 && x.IsActive == true)
            .Select(p => new { p.ItemID, p.ItmName,p.ItmPrice });
            return Json(new { aaData = query }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Konafa()
        {
            SyDB db = new SyDB();
            var query = db.ItmList.Where(x => x.ItmType == 2 && x.IsActive == true)
                .Select(p => new { p.ItemID, p.ItmName, p.ItmPrice });
            return Json(new { aaData = query }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ordprint(int? id )
        {
            SyDB db = new SyDB();
            if (id == null)
            {
                // id = db.OrdList.LastOrDefault().OrdID ;
                var h = db.OrdList.Max(b => (int?)b.OrdID);

                var query = db.orditm.Where(x => x.ordfk == h)
                .Select(p => new { p.ser, p.ItmList.ItmName, p.price, p.qty , p.totval});
                return Json(new { aaData = query }, JsonRequestBehavior.AllowGet);
            }
            { 
            var query = db.orditm.Where(x => x.ordfk == id)
                .Select(p => new { p.ser, p.ItmList.ItmName, p.price , p.qty , p.totval});
            return Json(new { aaData = query }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ORDlst()
        {
            SyDB db = new SyDB();
            var m = db.OrdList.ToList().LastOrDefault().GuestName;
            //var query = db.OrdList.Where(x => x.OrdID == m )
            //    .Select(s => s.GuestName);
            return Json(m , JsonRequestBehavior.AllowGet);
        }
        public JsonResult ORDlstnum()
        {
            SyDB db = new SyDB();
            var m = db.OrdList.ToList().LastOrDefault().OrderFk;
            //var query = db.OrdList.Where(x => x.OrdID == m )
            //    .Select(s => s.GuestName);
            return Json(m, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Ordpk()
        {
            SyDB db = new SyDB();
            var m = db.OrdList.ToList().LastOrDefault().OrdID;
            //var query = db.OrdList.Where(x => x.OrdID == m )
            //    .Select(s => s.GuestName);
            return Json(m, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Totfuc(int? id)
        {
            SyDB db = new SyDB();
           var query = db.orditm
            .Where(p => p.createdate == DateTime.Today)
            .Sum(c => (decimal?)c.totval) ?? 0;
            return Json(query,JsonRequestBehavior.AllowGet);
        }
        public JsonResult adORD( string gsname , int shvt    )
        {
            SyDB db = new SyDB();
           var ca  = db.OrdList.ToList().LastOrDefault().OrdID + 1;
       //     var dk = db.OrdList.Where(x => x.shitfk == shvt).s + 1;
            var ddd = db.OrdList.Where(x => x.shitfk == shvt).Max(b => (int?)b.OrderFk) + 1 ?? 1;



            OrdList bi = new OrdList();
            bi.OrdID = ca ;
            bi.shitfk = shvt;
            bi.GuestName = gsname  ;
            bi.OrdDate = DateTime.Now;
            bi.OrderFk = ddd ;
            bi.IsActive = true;
            db.OrdList.Add(bi);
            db.SaveChanges();
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult aditm(int itmfk ,int  ordfk ,decimal pr , int shi , int cby )
        {
            SyDB db = new SyDB();
            var ca = db.orditm.ToList().LastOrDefault().ser + 1;
            //     var dk = db.OrdList.Where(x => x.shitfk == shvt).s + 1;
            //var ddd = db.OrdList.Where(x => x.shitfk == shvt).Max(b => (int?)b.OrderFk) + 1 ?? 1;
            orditm bi = new orditm();
            bi.ser = ca;
            bi.ordfk = ordfk;
            bi.itemfk = itmfk;
            bi.price = pr;
            bi.qty = 1;
            bi.totval = pr * 1 ;
            bi.createdate = DateTime.Now;
            bi.shid = shi;
            bi.createby = cby;
            db.orditm.Add(bi);
            db.SaveChanges();
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}