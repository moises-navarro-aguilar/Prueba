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
    public class RolModelsController : Controller
    {
  
        string BaseURL = "https://localhost:44369/";

        // GET: Usuarios  
        public async Task<ActionResult> Index()
        {
            List<RolModel> EmpInfo = new List<RolModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Rols/");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<RolModel>>(EmpResponse);
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
        public ActionResult Create(RolModel roles)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseURL + "api/Rols");
                    var postTask = client.PostAsJsonAsync<RolModel>("usuarios", roles);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "Error");
                return View(roles);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            RolModel roles = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                var responseTask = client.GetAsync("api/Rols/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RolModel>();
                    readTask.Wait();
                    roles = readTask.Result;
                }
            }


            return View(roles);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(RolModel roles)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var putTask = client.PutAsJsonAsync($"api/Usuarios/{roles.Id}", roles);
                    putTask.Wait();
                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(roles);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            RolModel roles = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                var responseTask = client.GetAsync("api/Rols/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RolModel>();
                    readTask.Wait();
                    roles = readTask.Result;
                }
            }
            return View(roles);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RolModel roles)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseURL);
                    var deleteTask = client.GetAsync("api/Rols/" + id.ToString());
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(roles);
            }
            catch
            {
                return View();
            }
        }
    }
}
