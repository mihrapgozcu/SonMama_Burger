using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SonMama_Burger.DAL;
using SonMama_Burger.Models.Entitites;
using SonMama_Burger.Models.Enum;
using SonMama_Burger.VM;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SonMama_Burger.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Musteri,Admin")]
    public class SiparisController : Controller
    {
        private readonly BurgerDBContext _db;
        private readonly SiparisOlusturVM _vm;
        private readonly UserManager<AppUser> _userManager;

        public SiparisController(BurgerDBContext db, SiparisOlusturVM vm, UserManager<AppUser> userManager)
        {
            _db = db;

            _vm = new();
            _vm.Menuler = _db.Menuler.Where(x => x.AktifMi == true).ToList();
            _vm.ExtraMalzemeler = _db.ExtraMalzemeler.ToList();
            _userManager = userManager;
        }

        public IActionResult SiparisOlustur()
        {

            return View(_vm);
        }



        public List<Sepet> GetSepetIncludeMenu(int userId)
        {
            return _db.Sepettekiler.Where(x => x.UserID == userId).Include(x => x.Menu).ToList();
        }


        [HttpPost]
        public IActionResult SiparisGonder(SiparisGonderVM siparisGonderVM, Boyut boyut, int id, int userID, int adet, decimal fiyat, string sos1, string sos2)
        {

            //Menu menu = _db.Menuler.Find(siparisGonderVM.MenuID);
            Menu menu = _db.Menuler.Find(id);

            siparisGonderVM.MenuAdi = menu.Adi;
            siparisGonderVM.Fiyat = menu.Fiyat;
            if (siparisGonderVM.Boyut == Boyut.Buyuk) siparisGonderVM.Fiyat *= 1.4M;
            else if (siparisGonderVM.Boyut == Boyut.Orta) siparisGonderVM.Fiyat *= 1.2M;
            else if (siparisGonderVM.Boyut == Boyut.Kucuk) siparisGonderVM.Fiyat *= 1;
            siparisGonderVM.Fiyat *= siparisGonderVM.Adet;
            siparisGonderVM.Sos1ID = sos1;
            siparisGonderVM.Sos2ID = sos2;

            Sepet sepet = new Sepet()
            {
                
                MenuID = id,
                Adet = adet,
                Boyut = boyut,
                Fiyat = fiyat,
                UserID = userID,
                OlusturmaZamani = DateTime.Now,
                AktifMi = true


            };


            _db.Sepettekiler.Add(sepet);
            _db.SaveChanges();

            //siparisGonderVM.Sepettekiler = _db.Sepettekiler.Where(x => x.UserID == siparisGonderVM.UserID).ToList();

            siparisGonderVM.Sepettekiler = GetSepetIncludeMenu(siparisGonderVM.UserID);


            if (siparisGonderVM.Sepettekiler.Count > 1 && siparisGonderVM.ekleme == 1)
            {

                return PartialView("_SepetTemizlensinMi", siparisGonderVM);
            }

            return PartialView("_SiparisListesi", siparisGonderVM);

        }




        public IActionResult SepetiOnayla(int id)
        {
            SepetiOnaylaVM sepetiOnaylaVM = new()
            {
                Sepettekiler = _db.Sepettekiler.Where(x => x.UserID == id).ToList(),


            };

            return View(sepetiOnaylaVM);
        }

        public IActionResult SiparisOnayla(int id)
        {
            Siparis siparis = new()
            {
                UserID = id
            };

            _db.Siparisler.Add(siparis);
            _db.SaveChanges();

            List<Sepet> sepetIcerigi = _db.Sepettekiler.Where(x => x.UserID == id).ToList();
            foreach (Sepet item in sepetIcerigi)
            {
                if (item.MenuID != null)
                {
                    SiparislerMenuler siparislerMenu = new SiparislerMenuler()
                    {
                        SiparisID = siparis.ID,
                        MenuID = (int)item.MenuID,
                        Boyut = (Boyut)item.Boyut,
                        Adet = item.Adet,
                        TotalFiyat = item.Fiyat,
                        OlusturmaZamani = DateTime.Now,
                    };
                    _db.SiparislerMenuler.Add(siparislerMenu);
                    _db.Sepettekiler.Remove(item);
                    _db.SaveChanges();
                }
            }


            return RedirectToAction("Siparis");
        }



        [HttpPost]
        public IActionResult SepettenSil(SepettenSilVM sepettenSilVM)
        {
            Sepet sepet = _db.Sepettekiler.Where(x => x.ID == sepettenSilVM.sepetID).SingleOrDefault();

            if (sepet != null) // Null kontrolü ekleyin
            {
                if (sepet.Adet > 1)
                {
                    sepet.Fiyat = (sepet.Fiyat / sepet.Adet) * (sepet.Adet - 1);
                    //sepet.Fiyat = sepet.Fiyat * sepet.Adet;
                    sepet.Adet--;
                    _db.Sepettekiler.Update(sepet);
                    _db.SaveChanges();
                }
                else if (sepet.Adet == 1)
                {
                    _db.Sepettekiler.Remove(sepet);
                    _db.SaveChanges();
                }
            }

            SiparisGonderVM siparisGonderVM = new();
            siparisGonderVM.Sepettekiler = _db.Sepettekiler.Where(x => x.AktifMi == true).ToList();

            return PartialView("_SiparisListesi", siparisGonderVM);
        }






        [HttpPost]
        public IActionResult AdetArttır(SepettenSilVM sepettenSilVM)
        {
            Sepet sepet = _db.Sepettekiler.Where(x => x.ID == sepettenSilVM.sepetID).SingleOrDefault();
            sepet.Fiyat = (sepet.Fiyat / sepet.Adet) * (sepet.Adet + 1);
            sepet.Adet++;
            _db.Sepettekiler.Update(sepet);
            _db.SaveChanges();
            SiparisGonderVM siparisGonderVM = new();
            siparisGonderVM.Sepettekiler = _db.Sepettekiler.Where(x => x.AktifMi == true).ToList();
            return PartialView("_SiparisListesi", siparisGonderVM);
        }

        public IActionResult Siparis()
        {
            //var userIDClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            //int userID = int.Parse(userIDClaim.Value);

            int uyeID = int.Parse(_userManager.GetUserId(User));

            List<Siparis> siparis = _db.Siparisler.Include(x => x.SiparislerMenuler).Where(x => x.UserID == uyeID).ToList();




            return View("Siparis", siparis);
        }

        [HttpPost]
        public IActionResult SepetTemizle(SepetTemizleVM sepetTemizleVM)
        {
            int sonEklenenId = _db.Sepettekiler.Max(x => x.ID);
            foreach (Sepet item in _db.Sepettekiler.Where(x => x.UserID == sepetTemizleVM.UserID && x.ID != sonEklenenId).ToList())
            {
                _db.Sepettekiler.Remove(item);
                _db.SaveChanges();
            }
            SiparisGonderVM siparisGonderVM = new()
            {
                Sepettekiler = _db.Sepettekiler.Where(x => x.UserID == sepetTemizleVM.UserID).ToList()
            };
            return PartialView("_SiparisListesi", siparisGonderVM);
        }
        [HttpPost]
        public IActionResult SepetYukle(SepetTemizleVM sepetTemizleVM)
        {
            SiparisGonderVM siparisGonderVM = new()
            {
                Sepettekiler = _db.Sepettekiler.Where(x => x.UserID == sepetTemizleVM.UserID).ToList()
            };
            return PartialView("Siparis", siparisGonderVM);
        }

        



    }
}