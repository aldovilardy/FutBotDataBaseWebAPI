using FutBotDataBaseWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
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
        //public void Post([FromBody]string value)
        //{
        //}
        [HandleProcessCorruptedStateExceptionsAttribute()]
        public HttpResponseMessage Post(Photo photo)
        {
            string Name_Photo_input = string.Empty;
            string sticker_photo_input = string.Empty;
            string sticker_photo_output = string.Empty;
            string mask = string.Empty;
            string temp = string.Empty;
            string comand0 = string.Empty;
            string comand1 = string.Empty;
            string comand2 = string.Empty;
            string originaImagelURI = string.Empty;
            string newImageURI = string.Empty;
            Process process = new Process();
            try
            {
                Name_Photo_input = Path.GetFileNameWithoutExtension(photo.Name) + DateTime.Now.Ticks + ".png";
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(photo.ContentUrl), AppDomain.CurrentDomain.BaseDirectory + @"Content\Public\" + Name_Photo_input);
                }
                sticker_photo_input = AppDomain.CurrentDomain.BaseDirectory + @"Content\Public\" + Name_Photo_input;
                sticker_photo_output = AppDomain.CurrentDomain.BaseDirectory + @"Content\Public\" + Path.GetFileNameWithoutExtension(Name_Photo_input) + "_sticker.png";
                mask = AppDomain.CurrentDomain.BaseDirectory + @"Content\Public\mask_col.png";
                temp = AppDomain.CurrentDomain.BaseDirectory + @"Content\Public\outtemp" + DateTime.Now.Ticks + ".png";

                //Definicion y ejecucion de comandos
                comand0 = $"mogrify -auto-orient -quality 100% {sticker_photo_input}";
                comand1 = "convert " + mask + @" ( " + sticker_photo_input + @" -resize 1536x2048^ ) -compose overlay -composite " + mask + " -composite " + temp;
                comand2 = "convert " + temp + @" -font Whitney-Semibold -weight 700  -pointsize 70 -draw ""fill black text 300,1860 '" + photo.UserName.ToUpper() + @"'"" "
                + @" -pointsize 50 -draw ""gravity northeast fill black text 100,1900 '" + ConfigurationManager.AppSettings["EventName"].ToString() + @"'"""
                + @" -pointsize 50 -draw ""gravity northeast fill black text 800,1710 '" + DateTime.Now.ToShortDateString() + @"'"""
                + @" -pointsize 50 -draw ""gravity northeast fill black text 200,315 '" + DateTime.Now.Year + @"'"" "
                + sticker_photo_output;

                process = Process.Start("CMD.exe", "/c " + comand0);
                process.WaitForExit();
                process = Process.Start("CMD.exe", "/c " + comand1);
                process.WaitForExit();
                process = Process.Start("CMD.exe", "/c " + comand2);
                process.WaitForExit();

                //Definición de URL
                originaImagelURI = Request.RequestUri.AbsoluteUri.Replace("api/CrearMona", "") + "Content/Public/" + Name_Photo_input;
                newImageURI = Request.RequestUri.AbsoluteUri.Replace("api/CrearMona", "") + "Content/Public/" + Path.GetFileNameWithoutExtension(Name_Photo_input) + "_sticker.png";

                return Request.CreateResponse(HttpStatusCode.OK, new  AnswerMona { url = originaImagelURI, FotoChromo = newImageURI });
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed,"Hola soy un error :"+ exc.Message);
            }
        }

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
