/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 16/09/2015
 * Hora: 01:43 p.m.
 * 
 */
using System;
using System.Xml;
using System.Collections.Generic;

namespace IsaRoGaMX.CFDI
{
   
   public class RegimenFiscal : baseObject {
      public RegimenFiscal(string regimenFiscal) {
         atributos.Add("Regimen", regimenFiscal);
      }
      
      public string Regimen {
         get {
            if(atributos.ContainsKey("Regimen"))
               return atributos["Regimen"];
            throw new Exception("RegimenFiscal::Regimen. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("Regimen"))
               atributos["Regimen"] = value;
            else
               atributos.Add("Regmien", value);
         }
      }
   }
   
   public class Emisor : baseObject {
      DomicilioFiscal domicilioFiscal;
      ExpedidoEn expedidoEn;
      RegimenFiscal regimenFiscal;
      
      public Emisor() : base() { }
      
      public Emisor(string rfc)
         : base() {
         atributos.Add("rfc", rfc);
      }
      
      public Emisor(string rfc, string nombre) {
         atributos.Add("rfc", rfc);
         atributos.Add("nombre", nombre);
      }
      
      /*public Emisor(string rfc, string regimen) {
         atributos.Add("rfc", rfc);
         regimenFiscal = regimen;
      }*/
      
      public Emisor(string rfc, string nombre, string regimen) {
         atributos.Add("rfc", rfc);
         atributos.Add("nombre", nombre);
         regimenFiscal = new RegimenFiscal(regimen);
      }
      
      public string RFC {
         get {
            if(atributos.ContainsKey("rfc"))
               return atributos["rfc"];
            else
               throw new Exception("Emisor::rfc. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("rfc"))
               atributos["rfc"] = value;
            else
               atributos.Add("rfc", value);
         }
      }
      
      public string Nombre {
         get {
            if(atributos.ContainsKey("nombre"))
               return atributos["nombre"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("nombre"))
               atributos["nombre"] = value;
            else
               atributos.Add("nombre", value);
         }
      }
      
      public string RegimenFiscal {
         get {
            if(regimenFiscal != null)
               return regimenFiscal.Regimen;
            return string.Empty;
         }
         set {
            if(regimenFiscal != null)
               regimenFiscal.Regimen = value;
            else
               regimenFiscal = new RegimenFiscal(value);
         }
      }
      
      public DomicilioFiscal DomicilioFiscal {
         get { return domicilioFiscal; }
         set { domicilioFiscal = value; }
      }
      
      public ExpedidoEn ExpedidoEn {
         get { return expedidoEn; }
         set { expedidoEn = value; }
      }
      
      public override XmlElement NodoXML(string prefijo, string namespaceURI, XmlDocument documento)
      {
         // Nodo Emisor
         XmlElement emisor = base.NodoXML(prefijo, namespaceURI, documento);
         
         // Nodo DomicilioFiscal
         if(domicilioFiscal != null) {
            XmlElement domicilio = domicilioFiscal.NodoXML(prefijo, namespaceURI, documento);
            emisor.AppendChild(domicilio);
         }
         
         // Nodo ExpedidoEn
         if(expedidoEn != null) {
            XmlElement expedido = expedidoEn.NodoXML(prefijo, namespaceURI, documento);
            emisor.AppendChild(expedido);
         }
         
         // Nodo RegimenFiscal
         if(regimenFiscal != null) {
            XmlElement regimen = regimenFiscal.NodoXML(prefijo, namespaceURI, documento);
            emisor.AppendChild(regimen);
         }
         
         // Regresamos el nodo emisor
         return emisor;
      }
   }
   
   public class Receptor : baseObject {
      Domicilio domicilio;
      
      public Receptor() : base() { }
      
      public Receptor(string rfc)
         : base() {
         atributos.Add("rfc", rfc);
      }
      
      public Receptor(string rfc, string nombre)
         : base() {
         atributos.Add("rfc", rfc);
         atributos.Add("nombre", nombre);
      }
      
      public Receptor(string rfc, string nombre, Domicilio domicilio)
         : base() {
         atributos.Add("rfc", rfc);
         atributos.Add("nombre", nombre);
         this.domicilio = domicilio;
      }
      
      public string RFC {
         get {
            if(atributos.ContainsKey("rfc"))
               return atributos["rfc"];
            else
               throw new Exception("Emisor::rfc. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("rfc"))
               atributos["rfc"] = value;
            else
               atributos.Add("rfc", value);
         }
      }
      
      public string Nombre {
         get {
            if(atributos.ContainsKey("nombre"))
               return atributos["nombre"];
            else
               return string.Empty;
         }
         set {
            if(atributos.ContainsKey("nombre"))
               atributos["nombre"] = value;
            else
               atributos.Add("nombre", value);
         }
      }
      
      public Domicilio Domicilio {
         get { return domicilio; }
         set { domicilio = value; }
      }
      
      public override XmlElement NodoXML(string prefijo, string namespaceURI, XmlDocument documento)
      {
         // Nodo Emisor
         XmlElement receptor = base.NodoXML(prefijo, namespaceURI, documento);
         
         // Nodo DomicilioFiscal
         if(this.domicilio != null) {
            XmlElement domicilio = this.domicilio.NodoXML(prefijo, namespaceURI, documento);
            receptor.AppendChild(domicilio);
         }
         
         // Regresamos el nodo emisor
         return receptor;
      }
   }
}
