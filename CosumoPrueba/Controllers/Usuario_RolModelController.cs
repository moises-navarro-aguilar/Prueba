using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CosumoPrueba.Data;
using CosumoPrueba.Models;
using Newtonsoft.Json;

namespace CosumoPrueba.Controllers
{
    public class Usuario_RolModelController : Controller
    {
        string BaseURL = "https://localhost:44369/";

        // GET: Usuarios  
        public async Task<ActionResult> Index()
        {
            List<Usuario_RolModel> EmpInfo = new List<Usuario_RolModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Usuario_Rol/");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Usuario_RolModel>>(EmpResponse);
                }
            }
            return View(EmpInfo);
        }

        // GET: RolModels/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario_RolModel URol)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseURL + "api/Usuario_Rol");
                    var postTask = client.PostAsJsonAsync<Usuario_RolModel>("Usuario_Rol", URol);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "Error");
                return View(URol);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario_RolModel URol = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                var responseTask = client.GetAsync("api/Usuario_Rol/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Usuario_RolModel>();
                    readTask.Wait();
                    URol = readTask.Result;
                }
            }


            return View(URol);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario_RolModel URol)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var putTask = client.PutAsJsonAsync($"api/Usuario_Rol/{URol.Id}", URol);
                    putTask.Wait();
                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(URol);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario_RolModel URol = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                var responseTask = client.GetAsync("api/Usuario_Rol/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Usuario_RolModel>();
                    readTask.Wait();
                    URol = readTask.Result;
                }
            }
            return View(URol);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Usuario_RolModel URol)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseURL);
                    var deleteTask = client.GetAsync("api/Usuario_Rol/" + id.ToString());
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(URol);
            }
            catch
            {
                return View();
            }
        }
    }
}
