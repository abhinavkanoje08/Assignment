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
using MyApp.Models;
using System.Web.Routing;
namespace MyApp.Controllers
{
    public class ClientsController : ApiController
    {
        private MyAppContext db = new MyAppContext();

    

        // GET: api/Clients/5
        [ResponseType(typeof(Clients))]
        public IHttpActionResult GetClients(int id)
        {
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClients(int id, Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clients.Cid)
            {
                return BadRequest();
            }

            db.Entry(clients).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Clients))]
        public IHttpActionResult PostClients(Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(clients);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clients.Cid }, clients);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Clients))]
        public IHttpActionResult DeleteClients(int id)
        {
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return NotFound();
            }

            db.Clients.Remove(clients);
            db.SaveChanges();

            return Ok(clients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientsExists(int id)
        {
            return db.Clients.Count(e => e.Cid == id) > 0;
        }

        [Route("api/Clients/")]
        // GET: api/Clients
        public IQueryable<Clients> GetClients()
        {
            return db.Clients.Include(s => s.clientAdd).Take(5);
        }


        [Route("api/Clients/{name}/{lname}")]
        [ResponseType(typeof(Clients))]
        public IHttpActionResult GetTotalClients(string name, string lname)
        {

            IList<Clients> obj = null;
            {
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lname))
                {
                    obj = db.Clients.Include(z => z.clientAdd).Where(s => (s.FirstName.Contains(name)) &&
                    s.LastName.Contains(lname)).ToList();
                }

                if (obj == null)
                {
                    return NotFound();
                }

                return Ok(obj);
            }
        }

        [Route("api/Clients/{name}")]
        [ResponseType(typeof(Clients))]
        public IHttpActionResult GetTotalClient(string name)
        {
            IList<Clients> obj1 = null;
            {
                obj1 = db.Clients.Include(z => z.clientAdd).Where(s => (s.FirstName.Contains(name)) ||
               s.LastName.Contains(name)).ToList();

                if (obj1 == null)
                {
                    return NotFound();
                }

                return Ok(obj1);

            }

        } 
        
    }
}