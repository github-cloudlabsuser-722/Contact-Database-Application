using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            return View("~/Views/User/Index.cshtml");
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            User user = userlist.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View("~/Views/User/Create.cshtml");
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.

            User user = userlist.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View("~/Views/User/Edit.cshtml", user);
        }


        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                User existingUser = userlist.FirstOrDefault(u => u.Id == id);

                if (existingUser == null)
                {
                    return HttpNotFound();
                }

                if (TryUpdateModel(existingUser))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(user);
        }




        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            User user = userlist.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View("~/Views/User/Delete.cshtml", user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            User user = userlist.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            userlist.Remove(user);
            return RedirectToAction("Index");
        }
    }
}
