using MVC_Uygulama.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Uygulama.Controllers
{
    public class UrunlerController : Controller
    {
        KuzeyYeliEntities myModel = new KuzeyYeliEntities();
        // GET: Home
        public ActionResult Index()
        {
            List<C_URUNLER> urunler = myModel.C_URUNLER.ToList();
          //  ViewBag.Berra = myModel.Kategoriler.ToList();
            return View(urunler);
        }
        public ActionResult UrunEkle()
        {
            ViewBag.Kategoriler = myModel.C_URUN_KATEGORILER.ToList();
           // ViewBag.Tedarikciler = myModel.Tedarikciler.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(C_URUNLER u,HttpPostedFileBase URUN_RESIM)
        {
            if (URUN_RESIM != null)
            {

                var filename = Path.GetFileName(URUN_RESIM.FileName);
                string filePath = "C:\\Users\\ADEM\\Desktop\\EVDEBİTTİ.COM\\evdebitti\\evdebitti\\RESİMLER\\urunresimleri\\" + filename;
                //  string filePath = yeniyol;
                URUN_RESIM.SaveAs(filePath);

                u.URUN_RESIM = "/RESİMLER/urunresimleri/" + filename;

                myModel.C_URUNLER.Add(u);
                myModel.SaveChanges();

            }
            
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

        public ActionResult Kategoriler()
        {
            List<Kategoriler> kategoriler = myModel.Kategoriler.ToList();
            return View(kategoriler);
        }
    }
}