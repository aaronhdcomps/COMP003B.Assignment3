using COMP003B.Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment3.Controllers
{
    public class PantsController : Controller
    {
        private static List<PantsPair> pantsStock = new List<PantsPair>();
        // GET: PantsController
        [HttpGet]
        public ActionResult Index()
        {
            return View(pantsStock);
        }


        // GET: PantsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PantsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PantsPair pantsPair)
        {
            if (ModelState.IsValid)
            {
                if (!pantsStock.Any(i => i.Id == pantsPair.Id))
                {
                    pantsStock.Add(pantsPair);
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: PantsController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
            { 
                return NotFound();
            }

            var pantsPair = pantsStock.FirstOrDefault(i => i.Id == id);

            if (pantsPair == null)
            {
                return NotFound();
            }

            return View(pantsPair);
        }

        // POST: PantsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PantsPair pantsPair)
        {
            if (id != pantsPair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            { 
                var pantsItem = pantsStock.FirstOrDefault(i => i.Id == pantsPair.Id);

                if (pantsItem != null)
                { 
                    pantsItem.Name = pantsPair.Name;
                    pantsItem.Price = pantsPair.Price;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(pantsPair);
        }

        // GET: PantsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == null)
            { 
                return NotFound(); 
            }

            var pantsPair = pantsStock.FirstOrDefault(i => i.Id == id);

            if (pantsPair == null) 
            {
                return NotFound();
            }
            return View(pantsPair);
        }

        // POST: PantsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pantsPair = pantsStock.FirstOrDefault(i => i.Id == id);
            if (pantsPair != null)
            {
                pantsStock.Remove(pantsPair);
            }
            return RedirectToAction(nameof(Index));
                        
        }
    }
}
