/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 16/09/2015
 * Hora: 12:50 a.m.
 * 
 */
using System;
using System.Collections.Generic;

namespace IsaRoGaMX.CFDI
{   
   public abstract class AbstractUbicacion : baseObject {
      public abstract string Calle
      { get; set; }
      
      public abstract string NoExterior
      { get; set; }
      
      public abstract string NoInterior
      { get; set; }
      
      public abstract string Colonia
      { get; set; }
      
      public abstract string Localidad
      { get; set; }
      
      public abstract string Referencia
      { get; set; }
      
      public abstract string Municipio
      { get; set; }
      
      public abstract string Estado
      { get; set; }
      
      public abstract string Pais
      { get; set; }
      
      public abstract string CodigoPostal
      { get; set; }
   }
   
   public class UbicacionFiscal : AbstractUbicacion
   {
      public UbicacionFiscal() : base() { }
      
      public UbicacionFiscal(string calle, string municipio, string estado, string pais, string codigoPostal)
         : base() {
         atributos.Add("calle", calle);
         atributos.Add("municipio", municipio);
         atributos.Add("estado", estado);
         atributos.Add("pais", pais);
         atributos.Add("codigoPostal", codigoPostal);
      }
      
      public override string Calle {
         get {
            if(atributos.ContainsKey("calle"))
               return atributos["calle"];
            else
               throw new Exception("Ubicacion::calle no puede estar vacio.");
         }
         set {
            if(atributos.ContainsKey("calle"))
               atributos["calle"] = value;
            else
               atributos.Add("calle", value);
         }
      }
      
      public override string NoExterior {
         get {
            if(atributos.ContainsKey("noExterior"))
               return atributos["noExterior"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("noExterior"))
               atributos["noExterior"] = value;
            else
               atributos.Add("noExterior", value);
         }
      }
      
      public override string NoInterior {
         get {
            if(atributos.ContainsKey("noInterior"))
               return atributos["noInterior"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("noInterior"))
               atributos["noInterior"] = value;
            else
               atributos.Add("noInterior", value);
         }
      }
      
      public override string Colonia {
         get {
            if(atributos.ContainsKey("colonia"))
               return atributos["colonia"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("colonia"))
               atributos["colonia"] = value;
            else
               atributos.Add("colonia", value);
         }
      }
      
      public override string Localidad {
         get {
            if(atributos.ContainsKey("localidad"))
               return atributos["localidad"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("localidad"))
               atributos["localidad"] = value;
            else
               atributos.Add("localidad", value);
         }
      }
      
      public override string Referencia {
         get {
            if(atributos.ContainsKey("referencia"))
               return atributos["referencia"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("referencia"))
               atributos["referencia"] = value;
            else
               atributos.Add("referencia", value);
         }
      }
      
      public override string Municipio {
         get {
            if(atributos.ContainsKey("municipio"))
               return atributos["municipio"];
            else
               throw new Exception("Ubicacion::municipio no puede estar vacio.");
         }
         set {
            if(atributos.ContainsKey("municipio"))
               atributos["municipio"] = value;
            else
               atributos.Add("municipio", value);
         }
      }
      
      public override string Estado {
         get {
            if(atributos.ContainsKey("estado"))
               return atributos["estado"];
            else
               throw new Exception("Ubicacion::estado no puede estar vacio.");
         }
         set {
            if(atributos.ContainsKey("estado"))
               atributos["estado"] = value;
            else
               atributos.Add("estado", value);
         }
      }
      
      public override string Pais {
         get {
            if(atributos.ContainsKey("pais"))
               return atributos["pais"];
            else
               throw new Exception("Ubicacion::pais no puede estar vacio.");
         }
         set {
            if(atributos.ContainsKey("pais"))
               atributos["pais"] = value;
            else
               atributos.Add("pais", value);
         }
      }
      
      public override string CodigoPostal {
         get {
            if(atributos.ContainsKey("codigoPostal"))
               return atributos["codigoPostal"];
            else
               throw new Exception("Ubicacion::codigoPostal no puede estar vacio.");
         }
         set {
            if(atributos.ContainsKey("codigoPostal"))
               atributos["codigoPostal"] = value;
            else
               atributos.Add("codigoPostal", value);
         }
      }
   }
   
   public class Domicilio : UbicacionFiscal {
      public Domicilio() : base() { }
      
      public Domicilio(string calle, string municipio, string estado, string pais, string codigoPostal)
         : base(calle, municipio, estado, pais, codigoPostal) { }
   }
   
   public class DomicilioFiscal : UbicacionFiscal {
      public DomicilioFiscal() : base() { }
      
      public DomicilioFiscal(string calle, string municipio, string estado, string pais, string codigoPostal)
         : base(calle, municipio, estado, pais, codigoPostal) { }
   }
   
   public class ExpedidoEn : UbicacionFiscal {
      public ExpedidoEn() : base() { }
      
      public ExpedidoEn(string calle, string municipio, string estado, string pais, string codigoPostal)
         : base(calle, municipio, estado, pais, codigoPostal) { }
   }
}
