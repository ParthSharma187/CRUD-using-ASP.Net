using Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (studentsEntities obj = new studentsEntities())
                return View(obj.stds.ToList());

        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            using (studentsEntities db = new studentsEntities())
            {
                std data = db.stds.ToList().FirstOrDefault(x => x.id == id);
                return View(data);
            }
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(std jj)
        {
            try
            {
                // TODO: Add insert logic here
                using (studentsEntities records = new studentsEntities())
                {
                    records.stds.Add(jj);
                    records.SaveChanges();

                    return RedirectToAction("Index");

                }
            }
            catch
            {
                return View();
            }

        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            using (studentsEntities db = new studentsEntities())
            {
                std data = db.stds.ToList().FirstOrDefault(x => x.id == id);
                return View(data);
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, std objStudent)
        {
            try
            {
                using (studentsEntities db = new studentsEntities())
                {
                    std data = db.stds.ToList().FirstOrDefault(x => x.id == id);

                    data.academic_session = objStudent.academic_session;
                    data.academic_term = objStudent.academic_term;
                    data.category = objStudent.category;
                    data.class_abbrev = objStudent.class_abbrev;
                    data.class_group = objStudent.class_group;
                    data.class_name = objStudent.class_name;
                    data.student_mark = objStudent.student_mark;
                    data.student_name = objStudent.student_name;
                    data.student_regno = objStudent.student_regno;
                    data.subject_name = objStudent.subject_name;

                    db.SaveChanges();

                    return RedirectToAction("Index");

                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (studentsEntities db = new studentsEntities())
            {
                std data = db.stds.ToList().FirstOrDefault(x => x.id == id);
                return View(data);
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (studentsEntities db = new studentsEntities())
                {
                    std data = db.stds.ToList().FirstOrDefault(x => x.id == id);
                    db.stds.Remove(data);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
