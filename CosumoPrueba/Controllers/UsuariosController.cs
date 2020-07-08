using CosumoPrueba.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CosumoPrueba.Controllers
{
  
    public class UsuariosController : Controller
    {
        //URL de mi localhost
        string BaseURL = "https://localhost:44369/";
        
        // GET: Usuarios  
        public async Task<ActionResult> Index()
        {
            List<UsuarioModel> EmpInfo = new List<UsuarioModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Usuarios/");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<UsuarioModel>>(EmpResponse);
                }
            }
            return View(EmpInfo);
        }


        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(UsuarioModel usuarios)
        {  
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseURL + "api/Usuarios");
                    var postTask = client.PostAsJsonAsync<UsuarioModel>("usuarios", usuarios);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "Error");
                return View(usuarios);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioModel usuarios = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                var responseTask = client.GetAsync("api/Usuarios/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuarioModel>();
                    readTask.Wait();
                    usuarios = readTask.Result;
                }
            }


            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioModel usuarios)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var putTask = client.PutAsJsonAsync($"api/Usuarios/{usuarios.Id}", usuarios);
                    putTask.Wait();
                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }      
                return View(usuarios);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioModel usuarios = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                var responseTask = client.GetAsync("api/Usuarios/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuarioModel>();
                    readTask.Wait();
                    usuarios = readTask.Result;
                }
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UsuarioModel usuarios)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseURL);
                    var deleteTask = client.GetAsync("api/Usuarios/" + id.ToString());
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(usuarios);
            }
            catch
            {
                return View();
            }
        }
    }
}
