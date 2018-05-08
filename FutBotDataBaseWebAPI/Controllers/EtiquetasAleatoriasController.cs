using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FutBotDataBaseWebAPI.Models;

namespace FutBotDataBaseWebAPI.Controllers
{
    public class EtiquetasAleatoriasController : ApiController
    {
        private FutBotEntities db = new FutBotEntities();

        // GET: api/EtiquetasAleatorias
        public IQueryable<vEtiquetasAleatorias> GetvEtiquetasAleatorias()
        {
            return db.vEtiquetasAleatorias;
        }

        // GET: api/EtiquetasAleatorias/5
        [ResponseType(typeof(vEtiquetasAleatorias))]
        public IHttpActionResult GetvEtiquetasAleatorias(int id)
        {
            vEtiquetasAleatorias vEtiquetasAleatorias = db.vEtiquetasAleatorias.Find(id);
            if (vEtiquetasAleatorias == null)
            {
                return NotFound();
            }

            return Ok(vEtiquetasAleatorias);
        }

        // PUT: api/EtiquetasAleatorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvEtiquetasAleatorias(int id, vEtiquetasAleatorias vEtiquetasAleatorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vEtiquetasAleatorias.IdEtiqueta)
            {
                return BadRequest();
            }

            db.Entry(vEtiquetasAleatorias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vEtiquetasAleatoriasExists(id))
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

        // POST: api/EtiquetasAleatorias
        [ResponseType(typeof(vEtiquetasAleatorias))]
        public IHttpActionResult PostvEtiquetasAleatorias(vEtiquetasAleatorias vEtiquetasAleatorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vEtiquetasAleatorias.Add(vEtiquetasAleatorias);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vEtiquetasAleatoriasExists(vEtiquetasAleatorias.IdEtiqueta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vEtiquetasAleatorias.IdEtiqueta }, vEtiquetasAleatorias);
        }

        // DELETE: api/EtiquetasAleatorias/5
        [ResponseType(typeof(vEtiquetasAleatorias))]
        public IHttpActionResult DeletevEtiquetasAleatorias(int id)
        {
            vEtiquetasAleatorias vEtiquetasAleatorias = db.vEtiquetasAleatorias.Find(id);
            if (vEtiquetasAleatorias == null)
            {
                return NotFound();
            }

            db.vEtiquetasAleatorias.Remove(vEtiquetasAleatorias);
            db.SaveChanges();

            return Ok(vEtiquetasAleatorias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vEtiquetasAleatoriasExists(int id)
        {
            return db.vEtiquetasAleatorias.Count(e => e.IdEtiqueta == id) > 0;
        }
    }
}