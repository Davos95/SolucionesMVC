using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace ConceptosMVC.Controllers
{
    public class CorreoController : Controller
    {
        // GET: Correo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String destinatario, String asunto, String mensaje, HttpPostedFileBase fichero)
        {
            MailMessage mail = new MailMessage();
            String cuenta = ConfigurationManager.AppSettings["correo"];
            String password = ConfigurationManager.AppSettings["password"];
            mail.From = new MailAddress(cuenta);
            mail.To.Add(destinatario);
            mail.Subject = asunto;
            mail.Body = mensaje;

            //NECESITAMOS ENVIAR ADJUNTOS
            //SUBIR LOS ADJUNTOS A NUESTRO SERVIDOR
            //NECESITAMOS LA RUTA FISICA DE NUESTRO SERVIDOR
            String ruta = Server.MapPath("../Temporal");
            //PARA SALVAR EL FICHERO
            fichero.SaveAs(ruta + "\\" + fichero.FileName);
            Attachment adjunto = new Attachment(ruta + "\\" + fichero.FileName);
            mail.Attachments.Add(adjunto);

            //CONFIGURACION SMTP
            SmtpClient cliente = new SmtpClient();
            cliente.Host = "smtp.gmail.com";
            cliente.Port = 25;
            cliente.EnableSsl = true;
            cliente.UseDefaultCredentials = true;
            cliente.Credentials = new NetworkCredential(cuenta, password);
            cliente.Send(mail);
            ViewBag.Mensaje = "Correo enviado";

            return View();
        }
    }
}