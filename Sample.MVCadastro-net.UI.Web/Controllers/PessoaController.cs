using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.MVCadastro_net.UI.Web.Models;
using Sample.MVCadastro_net.UI.Web.ViewModels;
using Sample.MVCadastro_net.UI.Web.Funcoes;

namespace Sample.MVCadastro_net.UI.Web.Controllers
{
    public class PessoaController : Controller
    {
        //
        // GET: /Pessoa/

        public ActionResult Index()
        {
            PessoaViewModel model = Session["ModelView"] as PessoaViewModel;

            if (model == null)
            {
                model = new PessoaViewModel();

                //TODO: Excluir teste
                PessoaFisica pessoaFisica = new PessoaFisica();
                pessoaFisica.PessoaId = new Guid();
                pessoaFisica.Nome = "Rodrigo Lessa";
                pessoaFisica.CPF = "09073067723";

                PessoaJuridica pessoaJuridica = new PessoaJuridica();
                pessoaJuridica.PessoaId = new Guid();
                pessoaJuridica.Nome = "Rodrigo S/A";
                pessoaJuridica.CNPJ = "07753542000184";

                model.ListaPessoaFisica.Add(pessoaFisica);
                model.ListaPessoaJuridica.Add(pessoaJuridica);

                Session["ModelView"] = model;
            }

            return View(model);
        }

        //
        // GET: /Pessoa/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Pessoa/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Pessoa/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Pessoa/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Pessoa/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pessoa/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Pessoa/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult Salvar(string Tipo, string Nome, string Documento)
        {
            PessoaViewModel model = Session["ModelView"] as PessoaViewModel;

            if (model == null)
                model = new PessoaViewModel();

            if (Tipo == "Fisica")
            {
                PessoaFisica novaPessoa = new PessoaFisica();
                novaPessoa.PessoaId = new Guid();
                novaPessoa.Nome = Nome;
                novaPessoa.CPF = Documento;

                model.ListaPessoaFisica.Add(novaPessoa);
            }
            else
            {
                PessoaJuridica novaPessoa = new PessoaJuridica();
                novaPessoa.PessoaId = new Guid();
                novaPessoa.Nome = Nome;
                novaPessoa.CNPJ = Documento;

                model.ListaPessoaJuridica.Add(novaPessoa);
            }

            Session["ModelView"] = model;

            return Json(new { Success = true, hasRegister = (model.ListaPessoaFisica.Count > 0), html = RenderViewFuncoes.RenderPartialToString("~/Views/Pessoa/Grid.ascx", model), Message = "Salvo com sucesso!" }, JsonRequestBehavior.AllowGet);
        }
    }
}
