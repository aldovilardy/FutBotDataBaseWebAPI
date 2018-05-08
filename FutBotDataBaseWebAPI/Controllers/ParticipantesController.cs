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
    public class ParticipantesController : ApiController
    {
        private FutBotEntities db = new FutBotEntities();

        // GET: api/Participantes
        public IQueryable<Participantes> GetParticipantes()
        {
            return db.Participantes;
        }

        // GET: api/Participantes/5
        [ResponseType(typeof(Participantes))]
        public IHttpActionResult GetParticipantes(int id)
        {
            Participantes participantes = db.Participantes.Find(id);
            if (participantes == null)
            {
                return NotFound();
            }

            return Ok(participantes);
        }

        // PUT: api/Participantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParticipantes(int id, Participantes participantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantes.IdParticipante)
            {
                return BadRequest();
            }

            db.Entry(participantes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantesExists(id))
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

        // POST: api/Participantes
        [ResponseType(typeof(Participantes))]
        public IHttpActionResult PostParticipantes(Participantes participantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Participantes.Add(participantes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participantes.IdParticipante }, participantes);
        }

        // DELETE: api/Participantes/5
        [ResponseType(typeof(Participantes))]
        public IHttpActionResult DeleteParticipantes(int id)
        {
            Participantes participantes = db.Participantes.Find(id);
            if (participantes == null)
            {
                return NotFound();
            }

            db.Participantes.Remove(participantes);
            db.SaveChanges();

            return Ok(participantes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantesExists(int id)
        {
            return db.Participantes.Count(e => e.IdParticipante == id) > 0;
        }
    }
}