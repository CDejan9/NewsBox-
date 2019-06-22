using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands.WebCommand;
using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.DTO.UlogaDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.SearchesProjekat;

namespace ProjkatAsp.Web.Controllers
{
    public class KorisnikController : Controller
    {
        private readonly ProjekatASPContext _context;
        private readonly IGetKorisniciWEBCommand _getKorisniciWEB;
        private readonly IGetKorisnikGetWebCommand _getKorisnikGetWeb;
        private readonly IEditKorisnikCommand _editKorisnik;
        private readonly IDeleteKorisnikCommand _deleteKorisnik;
        private readonly IAddKorisnikCommand _addKorisnik;

        public KorisnikController(ProjekatASPContext context, IGetKorisniciWEBCommand getKorisniciWEB, IGetKorisnikGetWebCommand getKorisnikGetWeb, IEditKorisnikCommand editKorisnik, IDeleteKorisnikCommand deleteKorisnik, IAddKorisnikCommand addKorisnik)
        {
            _context = context;
            _getKorisniciWEB = getKorisniciWEB;
            _getKorisnikGetWeb = getKorisnikGetWeb;
            _editKorisnik = editKorisnik;
            _deleteKorisnik = deleteKorisnik;
            _addKorisnik = addKorisnik;
        }



        // GET: Korisnik
        public ActionResult Index(KorisnikSearch search)
        {
            var korisnici = _getKorisniciWEB.Execute(search);
            return View(korisnici);
        }

        // GET: Korisnik/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var korisnik = _getKorisnikGetWeb.Execute(id);
                return View(korisnik);
            }
            catch (Exception)
            {
                TempData["greska"] = "Greska na serveru";
                return View();
            }
        }

        // GET: Korisnik/Create
        public ActionResult Create()
        {
            ViewBag.Ulogas = (_context.Ulogas.Select(r => new UlogaGetDto
            {
                Id = r.Id,
                Naziv = r.Naziv
            }));
            return View();
        }

        // POST: Korisnik/Create
/*        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KorisnikInsertDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["greska"] = "Nisu dobri podaci";
                RedirectToAction("create");
            }
            try
            {
                _addKorisnik.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (DataAlreadyExistsException e)
            {
                TempData["greska"] = e.Message;
            }
            catch (DataNotFoundException e)
            {
                TempData["greska"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["greska"] = "Serverska greska prilikom unosa";
            }
            ViewBag.Ulogas = (_context.Ulogas.Select(u => new UlogaGetDto
            {
                Id = u.Id,
                Naziv = u.Naziv
            }));
            return View();
        }*/

        // GET: Korisnik/Edit/5
     /*   public ActionResult Edit(int id)
        {
            try
            {
                var korisnik = _getKorisnikGetWeb.Execute(id);
                ViewBag.Ulogas = (_context.Ulogas.Select(u => new UlogaGetDto
                {
                    Id = u.Id,
                    Naziv = u.Naziv
                }));
                return View(korisnik);
            }
            catch (DataNotFoundExcetion)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["greska"] = "Serverska greška prilikom dohvatanja korisnika";
                return View();
            }
        }
*/
        // POST: Korisnik/Edit/5
      /*  [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, KorisnikGetDto dto)
        {
            try
            {
                _editKorisnik.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (DataNotFoundExcetion e)
            {
                ViewBag.Ulogas = (_context.Ulogas.Select(r => new UlogaGetDto
                {
                    Id = r.Id,
                    Naziv = r.Naziv
                }));
                TempData["greska"] = e.Message;
                return View();
            }
            catch (DataAlreadyExistsException e)
            {
                ViewBag.Ulogas = (_context.Ulogas.Select(r => new UlogaGetDto
                {
                    Id = r.Id,
                    Naziv = r.Naziv
                }));
                TempData["greska"] = e.Message;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Ulogas = (_context.Ulogas.Select(r => new UlogaGetDto
                {
                    Id = r.Id,
                    Naziv = r.Naziv
                }));
                TempData["greska"] = "Serverska greška prilikom izmene korisnika";
                return View();
            }
        }*/

        // POST: Korisnik/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteKorisnik.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (DataNotFoundException e)
            {
                TempData["greska"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["greska"] = "Serverska greska prilikom brisanja korisnika";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}