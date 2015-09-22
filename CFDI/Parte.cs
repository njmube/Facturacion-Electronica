/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 16/09/2015
 * Hora: 01:49 a.m.
 * 
 */
using System;
using System.Collections.Generic;

namespace IsaRoGaMX.CFDI
{
   public class Parte : baseObject
   {
      protected List<InformacionAduanera> infoAduanera;
      
      public Parte(decimal cantidad)
         : base() {
         atributos.Add("cantidad", cantidad.ToString("#.000000"));
      }
      
      public Parte(decimal cantidad, string unidad, string noIdentificacion, string descripcion, double valorUnitario, double importe)
         : base() {
         atributos.Add("cantidad", cantidad.ToString("#.000000"));
         atributos.Add("unidad", unidad);
         atributos.Add("noIdentificacion", noIdentificacion);
         atributos.Add("descripcion", descripcion);
         atributos.Add("valorUnitario", valorUnitario.ToString("#.000000"));
         atributos.Add("importe", importe.ToString("#.000000"));
      }
      
      public virtual double Cantidad {
         get {
            if(atributos.ContainsKey("cantidad"))
               return Convert.ToDouble(atributos["cantidad"]);
            else
               throw new Exception("Parte::cantidad no puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("cantidad"))
               atributos["cantidad"] = Conversiones.Importe(value);
            else
               atributos.Add("cantidad", Conversiones.Importe(value));
         }
      }
      
      public virtual string Unidad {
         get {
            if(atributos.ContainsKey("unidad"))
               return atributos["unidad"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("unidad"))
               atributos["unidad"] = value;
            else
               atributos.Add("unidad", value);
         }
      }
      
      public virtual string NoIdentificacion {
         get {
            if(atributos.ContainsKey("noIdentificacion"))
               return atributos["noIdentificacion"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("noIdentificacion"))
               atributos["noIdentificacion"] = value;
            else
               atributos.Add("noIdentificacion", value);
         }
      }
      
      public virtual string Descripcion {
         get {
            if(atributos.ContainsKey("descripcion"))
               return atributos["descripcion"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("descripcion"))
               atributos["descripcion"] = value;
            else
               atributos.Add("unidad", value);
         }
      }
      
      public virtual string ValorUnitario {
         get {
            if(atributos.ContainsKey("valorUnitario"))
               return atributos["valorUnitario"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("valorUnitario"))
               atributos["valorUnitario"] = value;
            else
               atributos.Add("valorUnitario", value);
         }
      }
      
      public virtual string Importe {
         get {
            if(atributos.ContainsKey("importe"))
               return atributos["importe"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("importe"))
               atributos["importe"] = value;
            else
               atributos.Add("importe", value);
         }
      }
   }
}
