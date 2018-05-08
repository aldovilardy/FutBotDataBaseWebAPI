using FutBotDataBaseWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Web.Http;

namespace FutBotDataBaseWebAPI.Controllers
{
    public class CrearMonaController : ApiController
    {
        private FutBotEntities db = new FutBotEntities();
        // GET: api/CrearMona
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CrearMona/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CrearMona
        public void Post([FromBody]string value)
        {
        }
        [HandleProcessCorruptedStateExceptionsAttribute()]
        //public IHttpActionResult Post(Photo photo)
        //{
        //    //Logica para ejecución
        //}

        // PUT: api/CrearMona/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CrearMona/5
        public void Delete(int id)
        {
        }
    }
}
