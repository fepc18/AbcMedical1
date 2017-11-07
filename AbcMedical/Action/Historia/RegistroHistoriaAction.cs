using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Historia.Api;
using Entities.Utilities;
using Entities.Historia;
using DAL.Historia;
using AbcMedical.Service.Historia;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Net;
namespace Action.Historia
{
    public class RegistroHistoriaAction
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        public OutGetResumenRegistrosHistorial getResumenHistorialRegistros(InGetRegistrosHistorial Input)
        {
            var response = new OutGetResumenRegistrosHistorial();
            try
            {
                var dal = new HistoriaDAL();
                response = dal.GetResumenRegistrosHistorial(Input);
            }
            catch (Exception ex)
            {
                response.State = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public OutGetRegistrosHistorial getHistorialRegistros(InGetRegistrosHistorial Input)
        {
            var response = new OutGetRegistrosHistorial();
            try
            {
                var dal = new  HistoriaDAL();
                response=dal.GetRegistrosHistorial(Input);
            }
            catch(Exception ex)
            {
                response.State = false;
                response.Message = ex.Message;
            }
            
            return response;
        }

        public Response saveRegistroHistoria(Entities.Historia.RegistroHistoria Input)
        {
            var response = new Response();
            try
            {
                  Input.Fecha = DateTime.Now;
                db.RegistroHistoria.Add(Input);
                  db.SaveChanges();
                  response.State = true;
                  response.Message = "OK";  
            }
            catch (Exception ex)
            {
                response.State = false;
                response.Message = ex.Message;
            }

            return response;
        }


        public HttpResponseMessage getPDF(string RegistroClinicoId)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var service = new PDFService();
                var registro = service.PDFRegistroHistoria(RegistroClinicoId);
                
                
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                var pdfBytes = htmlToPdf.GeneratePdf(registro);

                var stream = new MemoryStream(pdfBytes);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "RegistroClinico.pdf"
                };


            }
            catch (Exception ex)
            {
               // response.State = false;
              //  response.Message = ex.Message;
            }

            return response;
        }
    }
}