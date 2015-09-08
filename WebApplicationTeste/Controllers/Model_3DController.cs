﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplicationTeste.Models;

namespace WebApplicationTeste.Controllers
{
    public class Model_3DController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Model_3D
        public IQueryable<Model_3D> GetModel_3D()
        {
            return db.Model_3D;
        }

        // GET: api/Model_3D/5
        [ResponseType(typeof(Model_3D))]
        public IHttpActionResult GetModel_3D(int id)
        {
            Model_3D model_3D = db.Model_3D.Find(id);
            if (model_3D == null)
            {
                return NotFound();
            }

            return Ok(model_3D);
        }

        // PUT: api/Model_3D/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModel_3D(int id, Model_3D model_3D)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model_3D.id)
            {
                return BadRequest();
            }

            db.Entry(model_3D).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Model_3DExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Model_3D
        [ResponseType(typeof(Model_3D))]
        public IHttpActionResult PostModel_3D(Model_3D model_3D)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Model_3D.Add(model_3D);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = model_3D.id }, model_3D);
        }

        // DELETE: api/Model_3D/5
        [ResponseType(typeof(Model_3D))]
        public IHttpActionResult DeleteModel_3D(int id)
        {
            Model_3D model_3D = db.Model_3D.Find(id);
            if (model_3D == null)
            {
                return NotFound();
            }

            db.Model_3D.Remove(model_3D);
            db.SaveChanges();

            return Ok(model_3D);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Model_3DExists(int id)
        {
            return db.Model_3D.Count(e => e.id == id) > 0;
        }
    }
}