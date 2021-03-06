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
using ControleDApi.DAL;
using ControleDApi.Models;
using System.Web.Http.Cors;

namespace ControleDApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AlimentoController : ApiController
    {
        private Context db = new Context();

        // GET: api/Alimento
        public IQueryable<Alimento> GetAlimento()
        {

            //var al = new Alimento();
            //al.Descricao = "teste";
            //al.QtdCarboidrato = (decimal)0.23;

            //db.Alimento.Add(al);
            //db.SaveChanges();

            return db.Alimento;
        }

        // GET: api/Alimento/5
        [ResponseType(typeof(Alimento))]
        public IHttpActionResult GetAlimento(int id)
        {
            Alimento alimento = db.Alimento.Find(id);
            if (alimento == null)
            {
                return NotFound();
            }

            return Ok(alimento);
        }

        // PUT: api/Alimento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlimento(int id, Alimento alimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alimento.Id)
            {
                return BadRequest();
            }

            db.Entry(alimento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlimentoExists(id))
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

        // POST: api/Alimento
        [ResponseType(typeof(Alimento))]
        public IHttpActionResult PostAlimento(Alimento alimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alimento.Add(alimento);
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Alimento/5
        [ResponseType(typeof(Alimento))]
        public IHttpActionResult DeleteAlimento(int id)
        {
            Alimento alimento = db.Alimento.Find(id);
            if (alimento == null)
            {
                return NotFound();
            }

            db.Alimento.Remove(alimento);
            db.SaveChanges();

            return Ok(alimento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlimentoExists(int id)
        {
            return db.Alimento.Count(e => e.Id == id) > 0;
        }
    }
}