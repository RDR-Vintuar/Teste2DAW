using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teste2DAW.Models;

namespace Teste2DAW.Controllers
{
    public class AlugersController : Controller
    {
        private ProjectoDB db = new ProjectoDB();

        public ActionResult Inicio() {

            return View();
        }

        public JsonResult getCopiaBoas() {
            var Copias = db.copias.Where(c => c.EstadoID.Equals(1)).ToList();

            return Json(Copias.Count(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCopiaRazoaveis()
        {
            var Copias = db.copias.Where(c => c.EstadoID.Equals(2)).ToList();

            return Json(Copias.Count(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getCopiaMas()
        {
            var Copias = db.copias.Where(c => c.EstadoID.Equals(2)).ToList();

            return Json(Copias.Count(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Lista() {


            return View();
        }

        public JsonResult GetFilme()
        {

            var Filmes = db.filmes.ToList(); //OrderBy(c => c.Designacao).Select(x => new
            // {
            //     FilmeID = x.FilmeID,
            //     Designacao = x.Designacao

            // }).ToList();
            return Json(Filmes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCopias(int FilmeID)
        {

            var Copias = db.copias.Where(c => c.FilmeID.Equals(FilmeID)).OrderBy(c => c.CopiaID).Select(x => new
            {
                CopiaID = x.CopiaID                

            }).ToList();
            return Json(Copias, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Register(Aluger questao)
        {
            string mensagem = "Salvou";
            questao.FuncionarioID = 1;
            questao.dataEmpretimo = DateTime.Now;
            
            db.aluger.Add(questao);
            db.SaveChanges();
            //  return RedirectToAction("Index");
            return new JsonResult { Data = questao.AlugerID, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }       

        //opcao---------------------------------------------------------------------------------------------------
        public JsonResult save(AlugerCopias data)
        {

            db.alugercopias.Add(data);
            Copia copia = db.copias.Find(data.CopiaID);
            copia.disponivel = false;
            db.Entry(copia).State = EntityState.Modified;
            db.SaveChanges();
            return null;
        }

        public JsonResult getOpcoes(int questaoID)
        {
            var copiasAluger = db.alugercopias.Where(c => c.AlugerID.Equals(questaoID)).Select(x => new
            {
                CopiaID = x.CopiaID,
                filme = x.Copia.Filme.Titulo

            }).ToList();
            return Json(copiasAluger, JsonRequestBehavior.AllowGet);
        }


        public JsonResult update(AlugerCopias copia)
        {
            db.Entry(copia).State = EntityState.Modified;
            db.SaveChanges();
            return null;
        }


        public JsonResult deleteOpcao(AlugerCopias data)
        {
            AlugerCopias opcao = db.alugercopias.Find(data.CopiaID);
            db.alugercopias.Remove(opcao);
            db.SaveChanges();
            return null;
        }
        //opcao------------------------------------------------------------------------------------------------------


        public JsonResult GetUtente()
        {

            var niveis = db.utentes.OrderBy(c => c.Nome).Select(x => new
            {
                UtenteID = x.UtenteID,
                Nome = x.Nome

            }).ToList();
            return Json(niveis, JsonRequestBehavior.AllowGet);
        }

        // GET: Alugers
        public ActionResult Index()
        {
            var aluger = db.aluger.Include(a => a.Funcionario).Include(a => a.Utente);
            return View(aluger.ToList());
        }

        // GET: Alugers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluger aluger = db.aluger.Find(id);
            if (aluger == null)
            {
                return HttpNotFound();
            }
            return View(aluger);
        }

        // GET: Alugers/Create
        public ActionResult Create()
        {
            ViewBag.CopiaID = new SelectList(db.copias, "CopiaID", "CopiaID");
            ViewBag.FuncionarioID = new SelectList(db.funcionarios, "FuncionarioID", "Nome");
            ViewBag.UtenteID = new SelectList(db.utentes, "UtenteID", "Nome");
            return View();
        }

        // POST: Alugers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlugerID,FuncionarioID,UtenteID,CopiaID,dataEmpretimo,dataEmtrega,devolvida,Multa")] Aluger aluger)
        {
            if (ModelState.IsValid)
            {
                db.aluger.Add(aluger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            ViewBag.FuncionarioID = new SelectList(db.funcionarios, "FuncionarioID", "Nome", aluger.FuncionarioID);
            ViewBag.UtenteID = new SelectList(db.utentes, "UtenteID", "Nome", aluger.UtenteID);
            return View(aluger);
        }

        // GET: Alugers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluger aluger = db.aluger.Find(id);
            if (aluger == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.FuncionarioID = new SelectList(db.funcionarios, "FuncionarioID", "Nome", aluger.FuncionarioID);
            ViewBag.UtenteID = new SelectList(db.utentes, "UtenteID", "Nome", aluger.UtenteID);
            return View(aluger);
        }

        // POST: Alugers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlugerID,FuncionarioID,UtenteID,CopiaID,dataEmpretimo,dataEmtrega,devolvida,Multa")] Aluger aluger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.FuncionarioID = new SelectList(db.funcionarios, "FuncionarioID", "Nome", aluger.FuncionarioID);
            ViewBag.UtenteID = new SelectList(db.utentes, "UtenteID", "Nome", aluger.UtenteID);
            return View(aluger);
        }

        // GET: Alugers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluger aluger = db.aluger.Find(id);
            if (aluger == null)
            {
                return HttpNotFound();
            }
            return View(aluger);
        }

        // POST: Alugers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluger aluger = db.aluger.Find(id);
            db.aluger.Remove(aluger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
