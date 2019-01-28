using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class CifradoController : Controller
    {
        // GET: CifradoFacil
        public ActionResult CifradoFacil()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CifradoFacil(String texto, String resultado, String accion)
        {
            String cifrado = this.CifradoTexto(texto);
            if(accion.ToUpper() == "CIFRAR")
            {
                ViewBag.Resultado = cifrado;
            } else
            {
                //COMPARAMOS EL RESULTADO CON EL CIFRADO
                if (cifrado == resultado)
                {
                    ViewBag.Mensaje = "Los datos son iguales";
                } else
                {
                    ViewBag.Mensaje = "Los datos son DISTINTOS...";
                }
            }
            return View();
        }


        public ActionResult CifradoEficiente()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CifradoEficiente(String contenido, String salt, int numHash, String resultado, int op)
        {
            String cifrado = this.EncriptarClick(contenido, salt, numHash);
            if(op == 1)
            {
               
                ViewBag.Resultado = cifrado;
            } else
            {
                if (this.ComprobarClick(contenido, salt, numHash, resultado))
                {
                    ViewBag.comprobacion = "Son iguales";
                } else
                {
                    ViewBag.comprobacion = "No son iguales";
                }
            }

            return View();
        }

        public byte[] Encriptar(string contenido, string salt, int numhash)
        {
            //REALIZAMOS LA COMBINACION DE ENCRIPTADO CON SU SALT
            string textocompleto = contenido + salt;
            //DECLARAMOS EL OBJETO SHA256
            SHA256Managed objsha = new SHA256Managed();
            byte[] bytesalida = null;
            try
            {
                //CONVERTIMOS EL TEXTO A BYTES
                bytesalida = Encoding.UTF8.GetBytes(textocompleto);
                //Convert.FromBase64String(textocompleto);
                //ENCRIPTAMOS EL TEXTO 1000 VECES
                for (int i = 0; i < numhash; i++)
                {
                    bytesalida = objsha.ComputeHash(bytesalida);
                }
            }
            finally
            {
                objsha.Clear();
            }
            //DEVOLVEMOS LOS BYTES DE SALIDA
            return bytesalida;
        }

        private String EncriptarClick(String cont, String slt, int numHash)
        {
            String contenido = cont;
            String salt = slt;
            int numencriptaciones = numHash;
            byte[] datosencriptados = this.Encriptar(contenido, salt, numencriptaciones);
            String textofinal = Encoding.UTF8.GetString(datosencriptados);
            return textofinal;
        }

        private bool ComprobarClick(String cont, String slt, int numHash, String resultado)
        {
            String contenido = cont;
            String salt = slt;
            int numencriptaciones = numHash;
            byte[] datosencriptados = this.Encriptar(contenido, salt, numencriptaciones);
            String textofinal = Encoding.UTF8.GetString(datosencriptados);

            if (textofinal != resultado)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

            public String CifradoTexto(String texto)
            {
                byte[] entrada;
                byte[] salida;
                UnicodeEncoding encoding = new UnicodeEncoding();
                //CONVERTIMOS EL TEXTO A BYTES
                entrada = encoding.GetBytes(texto);
                SHA1Managed objetocifrado = new SHA1Managed();
                //MEDIANTE EL OBJETO DE CIFRADO, CONVERTIMOS A NIVEL DE BYTE
                salida = objetocifrado.ComputeHash(entrada);
                //CONVERTIMOS LOS BYTES A TEXTO
                String resultado = encoding.GetString(salida);
                return resultado;
            }


        }
    }