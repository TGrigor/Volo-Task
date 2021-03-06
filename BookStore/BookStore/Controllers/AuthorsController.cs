﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domein;

namespace BookStore.Controllers
{
    public class AuthorsController : Controller
    {
        private BookStoreDatabaseEntities db = new BookStoreDatabaseEntities();

        // GET: Authors
        public async Task<ActionResult> Index()
        {
            return View(await db.Authors.ToListAsync());
        }

        // GET: Authors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return PartialView("Error404", id.ToString());
                }
                Author author = await db.Authors.FindAsync(id);
                if (author == null)
                {
                    return PartialView("Error404", id.ToString());
                }
                return View(author);
            }
            catch
            {
                return PartialView("Error404", id.ToString());
            }

        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AuthorID,AuthorName,AuthorLastName,BirthDay,Picture")] Author author, HttpPostedFileBase image1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (image1 != null)
                    {
                        author.Picture = new byte[image1.ContentLength];
                        image1.InputStream.Read(author.Picture, 0, image1.ContentLength);
                    }
                    db.Authors.Add(author);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Create", "Books");
                }

                return View(author);
            }
            catch
            {
                return PartialView("Error404");
            }
        }

        // GET: Authors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return PartialView("Error404", id.ToString());
                }
                Author author = await db.Authors.FindAsync(id);
                if (author == null)
                {
                    return PartialView("Error404", id.ToString());
                }
                return View(author);
            }
            catch 
            {
                    return PartialView("Error404", id.ToString());
            }

        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AuthorID,AuthorName,AuthorLastName,BirthDay,Picture")] Author author, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {

                if (image1 != null)
                {
                    author.Picture = new byte[image1.ContentLength];
                    image1.InputStream.Read(author.Picture, 0, image1.ContentLength);

                }
                if (image1 == null)
                {
                    using (BookStoreDatabaseEntities db1 = new BookStoreDatabaseEntities())
                    {
                        var img = db1.Authors.Find(author.AuthorID).Picture;
                        author.Picture = img;
                    }
                }
                db.Entry(author).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return PartialView("Error404", id.ToString());
                }
                Author author = await db.Authors.FindAsync(id);
                if (author == null)
                {
                    return PartialView("Error404", id.ToString());

                }
                return View(author);

            }
            catch
            {
                return PartialView("Error404", id.ToString());
            }

        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var book = db.Books.ToList();
                var AuthorTrue = false;
                foreach (var item in book)
                {
                    if (item.AuthorID == id)
                    {
                        AuthorTrue = true;
                    }
                }
                if (!AuthorTrue)
                {
                    Author author = await db.Authors.FindAsync(id);
                    db.Authors.Remove(author);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView("Error404", id.ToString());
            }

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
