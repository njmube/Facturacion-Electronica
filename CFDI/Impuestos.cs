/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 16/09/2015
 * Hora: 09:54 a.m.
 * 
 */
using System;
using System.Collections.Generic;

namespace IsaRoGaMX.CFDI
{
   public class Retencion : baseObject {
      public Retencion() : base() { }
      
      public Retencion(string impuesto, double importe) {
         atributos.Add("impuesto", impuesto);
         atributos.Add("importe", importe.ToString("#.000000"));
      }
      
      public string Impuesto {
         get {
            if(atributos.ContainsKey("impuesto"))
               return atributos["impuesto"];
            else
               throw new Exception("Retencion::impuesto no puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("impuesto"))
               atributos["impuesto"] = value;
            else
               atributos.Add("impuesto", value);
         }
      }
      
      public double Importe {
         get {
            if(atributos.ContainsKey("importe"))
               return Convert.ToDouble(atributos["importe"]);
            else
               throw new Exception("Retencion::importe no puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("importe"))
               atributos["importe"] = value.ToString("#.000000");
            else
               atributos.Add("importe", value.ToString("#.000000"));
         }
      }
   }
   
   public class Traslado : baseObject {
      public Traslado() : base() { }
      
      public Traslado(string impuesto, double importe, double tasa) {
         atributos.Add("impuesto", impuesto);
         atributos.Add("importe", importe.ToString("#.000000"));
         atributos.Add("tasa", tasa.ToString("#.000000"));
      }
      
      public string Impuesto {
         get {
            if(atributos.ContainsKey("impuesto"))
               return atributos["impuesto"];
            else
               throw new Exception("Retencion::impuesto no puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("impuesto"))
               atributos["impuesto"] = value;
            else
               atributos.Add("impuesto", value);
         }
      }
      
      public double Importe {
         get {
            if(atributos.ContainsKey("importe"))
               return Convert.ToDouble(atributos["importe"]);
            else
               throw new Exception("Retencion::importe no puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("importe"))
               atributos["importe"] = value.ToString("#.000000");
            else
               atributos.Add("importe", value.ToString("#.000000"));
         }
      }
      
      public double Tasa {
         get {
            if(atributos.ContainsKey("tasa"))
               return Convert.ToDouble(atributos["tasa"]);
            else
               throw new Exception("Retencion::tasa no puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("tasa"))
               atributos["tasa"] = value.ToString("#.000000");
            else
               atributos.Add("tasa", value.ToString("#.000000"));
         }
      }
   }
   
   public class Retenciones {
      List<Retencion> retenciones;
      
      public Retenciones() {
         retenciones = new List<Retencion>();
      }
      
      public Retencion this[int indice] {
         get {
            if(indice >= 0 && indice < retenciones.Count)
               return retenciones[indice];
            throw new Exception("Retenciones: Indice fuera de rango");
         }
      }
      
      public void Agregar(Retencion retencion) {
         retenciones.Add(retencion);
      }
      
      public void Elimina(int indice) {
         retenciones.RemoveAt(indice);
      }
      
      public int Elementos {
         get { return retenciones.Count; }
      }
   }
   
   public class Traslados {
      List<Traslado> traslados;
      
      public Traslados() {
         traslados = new List<Traslado>();
      }
      
      public Traslado this[int indice] {
         get {
            if(indice >= 0 && indice < traslados.Count)
               return traslados[indice];
            else
               throw new Exception("Retenciones: Indice fuera de rango");
         }
      }
      
      public void Agregar(Traslado retencion) {
         traslados.Add(retencion);
      }
      
      public void Elimina(int indice) {
         traslados.RemoveAt(indice);
      }
      
      public int Elementos {
         get { return traslados.Count; }
      }
   }
   
   public class Impuestos : baseObject {
      Retenciones retenciones;
      Traslados traslados;
      
      public Impuestos() : base() {
         retenciones = new Retenciones();
         traslados = new Traslados();
      }
      
      public void AgregaRetencion(Retencion retencion) {
         retenciones.Agregar(retencion);
      }
      
      public void EliminaRetencion(int indice) {
         retenciones.Elimina(indice);
      }
      
      public void AgregaTraslado(Traslado traslado) {
         traslados.Agregar(traslado);
      }
      
      public void EliminaTraslado(int indice) {
         traslados.Elimina(indice);
      }
      
      public Retenciones Retenciones {
         get { return retenciones; }
         set { retenciones = value; }
      }
      
      public Traslados Traslados {
         get { return traslados; }
         set { traslados = value; }
      }
   }
}
