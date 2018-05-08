using FutBotDataBaseWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Web.Http;

namespace FutBotDataBaseWebAPI.Controllers
{
    public class CreaPreguntasController : ApiController
    {
        private FutBotEntities db = new FutBotEntities();
        // GET: api/CreaPreguntas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CreaPreguntas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CreaPreguntas

        //public void Post([FromBody]string value)
        //{
        //}

        //[HandleProcessCorruptedStateExceptionsAttribute()]
        /**public HttpResponseMessage Post(vEtiquetasAleatorias sticker)
        {
            string errorMsj = string.Empty;
            int? output = 0;
            try { output = db.pCreaPreguntasxEtiqueta(sticker.IdEtiqueta); }
            catch (Exception ex) { errorMsj = ex.Message; }

            Trivia objResponse = new Trivia { Sticker = sticker };

            foreach (var pregunta in db.MiTablaPreguntasTemp)
            {
                List<AnswersTrivia> listAnswersTrivia = new List<AnswersTrivia>();
                foreach (var respuesta in db.fPreguntasAleatorias(pregunta.IdPregunta, pregunta.IdEtiqueta))
                    listAnswersTrivia.Add(new AnswersTrivia
                    {
                        Answer = respuesta.Respuesta,
                        Flag = respuesta.Bandera
                    });
                objResponse.Questions.Add(new QuestionsTrivia
                {
                    Answers = listAnswersTrivia,
                    QuestionByStickerId = pregunta.IdPreguntaXEtiqueta,
                    QuestionId = pregunta.IdPregunta,
                    Statement = pregunta.Descripcion
                });
            }
            
            HttpResponseMessage response = (output > 0) ? Request.CreateResponse(
                HttpStatusCode.Created,
                "El procedimiento cargó 3 preguntas de forma aleatoria en la tabla MiTablaPreguntasTemp") :
                Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    errorMsj);
            return response;
        }**/
        [HandleProcessCorruptedStateExceptionsAttribute()]
        public IHttpActionResult Post(vEtiquetasAleatorias sticker)
        {
            string errorMsj = string.Empty;
            int? output = 0;
            try { output = db.pCreaPreguntasxEtiqueta(sticker.IdEtiqueta); }
            catch (Exception ex) { errorMsj = ex.Message; }

            List<QuestionsTrivia> questionsResult = new List<QuestionsTrivia>() ;

            foreach (var pregunta in db.MiTablaPreguntasTemp)
            {
                List<AnswersTrivia> listAnswersTrivia = new List<AnswersTrivia>();
                foreach (var respuesta in db.fPreguntasAleatorias(pregunta.IdPregunta, pregunta.IdEtiqueta))
                    listAnswersTrivia.Add(new AnswersTrivia
                    {
                        Answer = respuesta.Respuesta,
                        Flag = respuesta.Bandera
                    });
                questionsResult.Add(new QuestionsTrivia
                {
                    Answers = listAnswersTrivia,
                    QuestionByStickerId = pregunta.IdPreguntaXEtiqueta,
                    QuestionId = pregunta.IdPregunta,
                    Statement = pregunta.Descripcion
                });
            }
            if (output > 0)
            {
                return Ok(questionsResult);
            }
            else
            {
                return InternalServerError();
            }
        }

        //// PUT: api/CreaPreguntas/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/CreaPreguntas/5
        //public void Delete(int id)
        //{
        //}
    }
}
