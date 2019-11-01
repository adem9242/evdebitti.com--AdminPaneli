using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Uygulama.Models;

namespace MVC_Uygulama.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        KuzeyYeliEntities myModel = new KuzeyYeliEntities();
        // GET: Home
        //[AllowAnonymous]
        public ActionResult Index()
        {
            List<Urunler> urunler = myModel.Urunler.ToList();
            ViewBag.Berra = myModel.Kategoriler.ToList();
            return View(urunler);
        }
        public ActionResult UrunEkle()
        {
            ViewBag.Kategoriler = myModel.Kategoriler.ToList();
            ViewBag.Tedarikciler = myModel.Tedarikciler.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler u)
        {
            //Urunler u = new Urunler();
            //u.UrunAdi = ad;
            //u.BirimFiyati = fiyat;
            //u.HedefStokDuzeyi = stok;

            myModel.Urunler.Add(u);
                myModel.SaveChanges();
               
            
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            Urunler u = myModel.Urunler.FirstOrDefault(x => x.UrunID == id);
            myModel.Urunler.Remove(u);
            myModel.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult UrunGuncelle(int id)
        {
            Urunler gUrn = myModel.Urunler.FirstOrDefault(x => x.UrunID == id);
            ViewBag.Kategoriler = myModel.Kategoriler.ToList();
            ViewBag.Tedarikciler = myModel.Tedarikciler.ToList();
            return View(gUrn);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Urunler u)
        {
            Urunler gUrn = myModel.Urunler.FirstOrDefault(x => x.UrunID == u.UrunID);
            gUrn.UrunAdi = u.UrunAdi;
            gUrn.BirimFiyati = u.BirimFiyati;
            gUrn.HedefStokDuzeyi = u.HedefStokDuzeyi;
            gUrn.KategoriID = u.KategoriID;
            gUrn.TedarikciID = u.TedarikciID;
            myModel.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UrunSatisYap(int id)
        {
            Satis_Detaylari satisurun = myModel.Satis_Detaylari.FirstOrDefault(x => x.UrunID == id);
            ViewBag.Kategoriler = myModel.Kategoriler.ToList();
            ViewBag.Tedarikciler = myModel.Tedarikciler.ToList();
            return View(satisurun);



        }
        [HttpPost]
        public ActionResult UrunSatisYap(Satis_Detaylari s)
        {
            Satis_Detaylari satisurun = myModel.Satis_Detaylari.FirstOrDefault(x => x.UrunID == s.UrunID);
            satisurun.UrunID = s.UrunID;
            satisurun.BirimFiyati = s.BirimFiyati;
            satisurun.Miktar = s.Miktar;

            return View(satisurun);



        }





        public ActionResult Admin()
        {
            return View();
        }
    }
}