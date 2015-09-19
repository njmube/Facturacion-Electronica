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
   /// Description of MyClass.
   /// </summary>
   public class CFDIWriter
   {
      Comprobante cfdi;
      
      public CFDIWriter(Comprobante cfdi){
         if(cfdi != null)
            this.cfdi = cfdi;
         else
            throw new Exception("CFDIWriter::(Combrobante). Parametro cfdi nulo");
      }
      
      public void EscribeXML(string rutaXML) {      
	      // Se escribe el XML
	      cfdi.Documento.Save(rutaXML);
      }
   }
}