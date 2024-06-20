using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SonMama_Burger.DAL;
using SonMama_Burger.Models.Entitites;
using SonMama_Burger.Validations.ExtraMalzeme;
using SonMama_Burger.VM.ExtraMalzemeVM;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SonMama_Burger.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExtraMalzemeController : Controller
	{
        private readonly BurgerDBContext _db;

        public ExtraMalzemeController(BurgerDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
		{
			return View(_db.ExtraMalzemeler.Where(x=>x.AktifMi == true).ToList());
		}
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateExtraMalzemeVM createExtraMalzeme)
        {
            
            if (ModelState.IsValid)
            {
                ExtraMalzeme extraMalzeme = new ExtraMalzeme();
                extraMalzeme.Adi = createExtraMalzeme.Adi;
                extraMalzeme.Fiyat = createExtraMalzeme.Fiyat;
                extraMalzeme.OlusturmaZamani = DateTime.Now;
                extraMalzeme.AktifMi = true;
                extraMalzeme.Cesit = createExtraMalzeme.Cesit;

                _db.ExtraMalzemeler.Add(extraMalzeme);
                _db.SaveChanges();
                return RedirectToAction("Index", "ExtraMalzeme");
            }
            else
            {
               
                return View("Create");
            }

        }
        public IActionResult Edit(int id)
        {
            ExtraMalzeme extraMalzeme = _db.ExtraMalzemeler.Find(id);

            UpdateExtraMalzemeVM updateExtraMalzemeVM = new UpdateExtraMalzemeVM()
            {
                Adi = extraMalzeme.Adi,
                Fiyat = extraMalzeme.Fiyat,
                Cesit = extraMalzeme.Cesit,
                AktifMi = extraMalzeme.AktifMi

            };
            return View(updateExtraMalzemeVM);

        }

        [HttpPost]
        public IActionResult Edit(UpdateExtraMalzemeVM updateExtraMalzemeVM)
        {
            //CreateExtraMalzemeVMValidator validator = new();
            //var valid = validator.Validate(updateExtraMalzemeVM);
            //if (valid.IsValid)
            //{
            //    ExtraMalzeme extraMalzeme = _db.ExtraMalzemeler.Find(updateExtraMalzemeVM.ID);
            //    extraMalzeme.Adi = updateExtraMalzemeVM.Adi;
            //    extraMalzeme.Fiyat = updateExtraMalzemeVM.Fiyat;
            //    extraMalzeme.Cesit = updateExtraMalzemeVM.Cesit;
            //    extraMalzeme.GuncellemeZamani = DateTime.Now;

            //    _db.ExtraMalzemeler.Update(extraMalzeme);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var item in valid.Errors)
            //    {
            //        ModelState.AddModelError("ExtraMalzemeHata", item.ErrorMessage);
            //    }
            //    return View();
            //}
            if (ModelState.IsValid)
            {
                ExtraMalzeme sos = _db.ExtraMalzemeler.Find(updateExtraMalzemeVM.ID);
                sos.Adi = updateExtraMalzemeVM.Adi;
                sos.Fiyat = updateExtraMalzemeVM.Fiyat;
                sos.GuncellemeZamani = DateTime.Now;
                sos.Cesit = updateExtraMalzemeVM.Cesit;
                sos.AktifMi = updateExtraMalzemeVM.AktifMi;



                _db.ExtraMalzemeler.Update(sos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {

            ExtraMalzeme deleteExtraMalzeme = _db.ExtraMalzemeler.Find(id);
            deleteExtraMalzeme.AktifMi = false;
            deleteExtraMalzeme.SilinmeZamani = DateTime.Now;
            _db.ExtraMalzemeler.Update(deleteExtraMalzeme);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(ExtraMalzeme extraMalzeme)
        {
            ExtraMalzeme deleteExtraMalzeme = _db.ExtraMalzemeler.Find(extraMalzeme.ID);

            deleteExtraMalzeme.AktifMi = false;
            _db.ExtraMalzemeler.Update(deleteExtraMalzeme);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

