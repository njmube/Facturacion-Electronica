/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 19/09/2015
 * Hora: 12:20 a.m.
 * 
 */
using System;

namespace IsaRoGaMX.CFDI
{
   public abstract class ComplementoComprobante : baseObject
   { }
   
   public class TimbreFiscalDigital : ComplementoComprobante {
      public TimbreFiscalDigital() :base() { }
      
      public TimbreFiscalDigital(string version, string uuid, DateTime fechaTimbrado, string selloCFD, string noCertificadoSAT, string selloSAT) {
         atributos.Add("version", version);
         atributos.Add("UUID", uuid);
         atributos.Add("FechaTimbrado", Comprobante.FechaISO8601(fechaTimbrado));
         atributos.Add("selloCFD", selloCFD);
         atributos.Add("noCertificadoSAT", noCertificadoSAT);
         atributos.Add("selloSAT", selloSAT);
      }
      
      public string Version {
         get {
            if(atributos.ContainsKey("version"))
               return atributos["version"];
            throw new Exception(this.GetType().Name + "::version. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("version"))
               atributos["version"] = value;
            else
               atributos.Add("version", value);
         }
      }
      
      public string UUID {
         get {
            if(atributos.ContainsKey("UUID"))
               return atributos["UUID"];
            throw new Exception(this.GetType().Name + "::UUID. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("UUID"))
               atributos["UUID"] = value;
            else
               atributos.Add("UUID", value);
         }
      }
      
      public string FechaTimbrado {
         get {
            if(atributos.ContainsKey("FechaTimbrado"))
               return atributos["FechaTimbrado"];
            throw new Exception(this.GetType().Name + "::FechaTimbrado. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("FechaTimbrado"))
               atributos["FechaTimbrado"] = value;
            else
               atributos.Add("FechaTimbrado", value);
         }
      }
      
      public string SelloCFD {
         get {
            if(atributos.ContainsKey("selloCFD"))
               return atributos["selloCFD"];
            throw new Exception(this.GetType().Name + "::selloCFD. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("selloCFD"))
               atributos["selloCFD"] = value;
            else
               atributos.Add("selloCFD", value);
         }
      }
      
      public string NoCertificadoSAT {
         get {
            if(atributos.ContainsKey("noCertificadoSAT"))
               return atributos["noCertificadoSAT"];
            throw new Exception(this.GetType().Name + "::noCertificadoSAT. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("noCertificadoSAT"))
               atributos["noCertificadoSAT"] = value;
            else
               atributos.Add("noCertificadoSAT", value);
         }
      }
      
      public string SelloSAT {
         get {
            if(atributos.ContainsKey("selloSAT"))
               return atributos["selloSAT"];
            throw new Exception(this.GetType().Name + "::selloSAT. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("selloSAT"))
               atributos["selloSAT"] = value;
            else
               atributos.Add("selloSAT", value);
         }
      }
   }
}
