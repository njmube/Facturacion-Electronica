/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 17/09/2015
 * Hora: 10:23 p.m.
 * 
 */
using System;
using System.Xml;
using IsaRoGaMX.CFDI;

namespace IsaRoGaMX.IO
{
   /// <summary>
   /// Escritor de documentos CFDI
   /// </summary>
   public class CFDIWriter
   {
      // Objeto comprobante a escribir
      Comprobante cfdi;
      
      /// <summary>
      /// Crea una instancia de CFDIWriter apartir de un comprobante
      /// </summary>
      /// <param name="cfdi">Comprobante a escribir</param>
      public CFDIWriter(Comprobante cfdi){
         if(cfdi != null)
            this.cfdi = cfdi;
         else
            throw new Exception("CFDIWriter::(Combrobante). Parametro cfdi nulo");
      }
      
      /// <summary>
      /// Escribe el archivo XML de un CFDI
      /// </summary>
      /// <param name="rutaXML">Ruta absoluta del donde se escribirá el CFDI</param>
      public void EscribeXML(string rutaXML) {      
	      // Se escribe el XML
	      cfdi.Documento.Save(rutaXML);
      }
   }
}