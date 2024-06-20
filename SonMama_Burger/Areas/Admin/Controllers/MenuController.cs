using Microsoft.AspNetCore.Mvc;
using SonMama_Burger.DAL;
using SonMama_Burger.Models.Entitites;
using SonMama_Burger.Validations.MenuValidate;
using SonMama_Burger.VM.MenuVM;

namespace SonMama_Burger.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly BurgerDBContext _db;

        public MenuController(BurgerDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View(_db.Menuler.Where(x => x.AktifMi == true).ToList()) ;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuVM createMenu)
        {
            CreateMenuVMValidator validator = new();
            var valid = validator.Validate(createMenu);
            if (valid.IsValid)
            {
                Menu menu = new Menu();
                menu.Adi = createMenu.Adi;
                menu.Fiyat = createMenu.Fiyat;
                menu.AktifMi = true;
                menu.OlusturmaZamani = DateTime.Now;

                if (createMenu.Image != null && IsImage(createMenu.Image.ContentType))
                {
                    string dosyaAdi = "";
                    dosyaAdi += createMenu.Image.FileName;
                    string dosyaYolu = "wwwroot/template2/img/";
                    menu.Fotograf = "~/template2/img/" + createMenu.Image.FileName;

                    FileStream fs = new FileStream(dosyaYolu + dosyaAdi, FileMode.Create);
                    createMenu.Image.CopyTo(fs);
                    fs.Close();
                }
                //if (createMenu.Image != null && IsImage(createMenu.Image.ContentType))
                //{
                //    Guid guid = Guid.NewGuid();
                //    string dosyaAdi = $"{guid}{Path.GetExtension(createMenu.Image.FileName)}";
                //    string dosyaYolu = Path.Combine("~", "template2", "img", dosyaAdi);
                //    menu.Fotograf = dosyaAdi;

                //    // Ensure the directory exists
                //    string directoryPath = Path.GetDirectoryName(dosyaYolu);
                //    if (!Directory.Exists(directoryPath))
                //    {
                //        Directory.CreateDirectory(directoryPath);
                //    }

                //    using (var fs = new FileStream(dosyaYolu, FileMode.Create))
                //    {
                //        await createMenu.Image.CopyToAsync(fs);
                //    }
                //}

                _db.Menuler.Add(menu);
                _db.SaveChanges();
                //await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("MenuHata", item.ErrorMessage);

                }
                return View();
            }

        }

        public IActionResult Edit(int id)
        {
           
            Menu updateMenu = _db.Menuler.Find(id);

            UpdateMenuVM updateMenuVM = new UpdateMenuVM()
            {
                ID = id,
                Adi = updateMenu.Adi,
                AktifMi = updateMenu.AktifMi,
                Fiyat = updateMenu.Fiyat
            };

            return View(updateMenuVM);
        }

        [HttpPost]
        public IActionResult Edit(UpdateMenuVM updatedMenuVM)
        {
            CreateMenuVMValidator validator = new();
            var valid = validator.Validate(updatedMenuVM);
            if (valid.IsValid)
            {
                Menu updateMenu = _db.Menuler.Find(updatedMenuVM.ID);
                updateMenu.Adi = updatedMenuVM.Adi;
                updateMenu.Fiyat = updatedMenuVM.Fiyat;

                if (updatedMenuVM.Image != null && IsImage(updatedMenuVM.Image.ContentType))
                {
                    Guid guid = Guid.NewGuid();
                    string dosyaAdi = guid.ToString();
                    dosyaAdi += updatedMenuVM.Image.FileName;
                    string dosyaYolu = "wwwroot/template2/img/";
                    updateMenu.Fotograf = dosyaAdi;

                    FileStream fs = new FileStream(dosyaYolu + dosyaAdi, FileMode.Create);
                    updatedMenuVM.Image.CopyTo(fs);
                    fs.Close();
                }

                _db.Menuler.Update(updateMenu);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("MenuHata", item.ErrorMessage);
                }
                return View();
            }


        }
        public IActionResult Delete(int id)
        {
            Menu deleteMenu = _db.Menuler.Find(id);
            //deleteMenu.AktifMi = false;
            deleteMenu.ID = id;
            
            return View(deleteMenu);
        }
        [HttpPost]
        public IActionResult Delete(Menu menu)
        {
            Menu deleteMenu = _db.Menuler.Find(menu.ID);
            
            deleteMenu.AktifMi = false;
            _db.Menuler.Update(deleteMenu);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool IsImage(string contentType)
        {
            string[] allowedContentTypes = { "image/jpeg", "image/png", "image/gif" };
            return allowedContentTypes.Contains(contentType);
        }
    }
}
