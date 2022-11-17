using ContactMVCProject.Context;
using ContactMVCProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactMVCProject.Controllers
{
    public class ContactController : Controller
    {
        //Leitura do DB
        private readonly AgendaContext _agendaContext;

        public ContactController(AgendaContext agendaContext)
        {
            _agendaContext = agendaContext;
        }

        // GET: ContactController
        public ActionResult Index()
        {
            var contacts = _agendaContext.Contacts.ToList();
            return View(contacts);
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            var contacts = _agendaContext.Contacts.Find(id);

            if (contacts == null)
                return RedirectToAction(nameof(Index));

            return View(contacts);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactModel contacts)
        {
            if (ModelState.IsValid)
            {
                _agendaContext.Contacts.Add(contacts);
                _agendaContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
                return View(contacts);
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            var contacts = _agendaContext.Contacts.Find(id);

            if (contacts == null)
                return RedirectToAction(nameof(Index));

            return View(contacts);
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactModel contact)
        {
            var databaseContact = _agendaContext.Contacts.Find(contact.Id);

                databaseContact.Name = contact.Name;
                databaseContact.Telefone = contact.Telefone;
                databaseContact.Ativo = contact.Ativo;

            _agendaContext.Contacts.Update(databaseContact);
            _agendaContext.SaveChanges(true);

            return RedirectToAction(nameof(Index));
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            var contacts = _agendaContext.Contacts.Find(id);

            if (contacts == null)
                return RedirectToAction(nameof(Index));

            return View(contacts);
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ContactModel contact)
        {
            var databaseContact = _agendaContext.Contacts.Find(contact.Id);

            _agendaContext.Contacts.Remove(databaseContact);
            _agendaContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
