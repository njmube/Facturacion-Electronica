/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 16/09/2015
 * Hora: 01:37 a.m.
 * 
 */
using System;
using System.Collections.Generic;

namespace IsaRoGaMX.CFDI
{
   
   public abstract class AbstractInformacionAduanera : baseObject {
      public abstract string Numero
      { get; set; }
      
      public abstract string Fecha
      { get; set; }
      
      public abstract string Aduana
      { get; set; }
   }
   
   public class InformacionAduanera : AbstractInformacionAduanera
   {
      public InformacionAduanera() : base() { }
      
      public InformacionAduanera(string numero, string fecha)
         : base() {
         atributos.Add("numero", numero);
         atributos.Add("fecha", fecha);
      }
      
      public InformacionAduanera(string numero, string fecha, string aduana)
         : base() {
         atributos.Add("numero", numero);
         atributos.Add("fecha", fecha);
         atributos.Add("aduana", aduana);
      }
      
      public override string Numero {
         get {
            if(atributos.ContainsKey("numero"))
               return atributos["numero"];
            else
               throw new Exception("InformacionAduanera::numero no puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("numero"))
               atributos["numero"] = value;
            else
               atributos.Add("numero", value);
         }
      }
      
      public override string Fecha {
         get {
            if(atributos.ContainsKey("fecha"))
               return atributos["fecha"];
            else
               throw new Exception("InformacionAduanera::fecha no puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("fecha"))
               atributos["fecha"] = value;
            else
               atributos.Add("fecha", value);
         }
      }
      
      public override string Aduana {
         get {
            if(atributos.ContainsKey("aduana"))
               return atributos["aduana"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("aduana"))
               atributos["aduana"] = value;
            else
               atributos.Add("aduana", value);
         }
      }
   }
}
