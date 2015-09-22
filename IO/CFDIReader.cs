/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 17/09/2015
 * Hora: 10:24 p.m.
 * 
 */
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using IsaRoGaMX.CFDI;


namespace IsaRoGaMX.IO
{
   public class CFDIReader
   {
      XmlSchemaSet esquemas;
      XmlDocument documento;
      Comprobante cfdi;
      
      /// <summary>
      /// Crea una instancia de un <see cref="CFDIReader"/>
      /// </summary>
      public CFDIReader() {
         esquemas = new XmlSchemaSet();         
         documento = new XmlDocument();
      }
      
      /// <summary>
      /// Lee un archivo XML para generar un objeto Comprobante
      /// </summary>
      /// <param name="rutaXML">Ruta del archivo XML</param>
      /// <returns></returns>
      private Comprobante LeerXML(string rutaXML){
         // Se crea el documento XML
         documento.Load(rutaXML);
         
         // Se obtiene el nodo raiz
         LeerNodos(documento.DocumentElement);
         
         // Regresamos el objeto comprobante
         return cfdi;
      }
      
      private Dictionary<string, string> leerAtributos(XmlNode nodo) {
         // Diccionario de atributos
         Dictionary<string, string> atributos = new Dictionary<string, string>();
         
         // Recorremos los atributos del nodo
         for(int i = 0; i < nodo.Attributes.Count; i++) {
            atributos.Add(nodo.Attributes[i].Name, nodo.Attributes[i].Value);
         }
         
         // Se retornan lo atributos
         return atributos;
      }
      
      private void LeerNodos(XmlNode padre) {         
         // Procesamos el nodo
         switch(padre.Prefix) {
               case "cfdi": {
                  switch(padre.LocalName) {
                     case "Comprobante":
                        cfdi = new Comprobante();
                        cfdi.atributos = leerAtributos(padre);
                        break;
                     case "Emisor":
                        cfdi.Emisor = new Emisor();
                        cfdi.Emisor.atributos = leerAtributos(padre);
                        break;
                     case "DomicilioFiscal":
                        cfdi.Emisor.DomicilioFiscal = new DomicilioFiscal();
                        cfdi.Emisor.DomicilioFiscal.atributos = leerAtributos(padre);
                        break;
                     case "ExpedidoEn":
                        cfdi.Emisor.ExpedidoEn = new ExpedidoEn();
                        cfdi.Emisor.ExpedidoEn.atributos = leerAtributos(padre);
                        break;
                     case "RegimenFiscal":
                        cfdi.Emisor.RegimenFiscal = padre.Attributes["Regimen"].Value;
                        break;
                     case "Receptor":
                        cfdi.Receptor = new Receptor();
                        cfdi.Receptor.atributos = leerAtributos(padre);
                        break;
                     case "Domicilio":
                        cfdi.Receptor.Domicilio = new Domicilio();
                        cfdi.Receptor.Domicilio.atributos = leerAtributos(padre);
                        break;
                     case "Conceptos":
                        cfdi.Conceptos = new Conceptos();
                        break;
                     case "Concepto":
                        Concepto concepto = new Concepto();
                        concepto.atributos = leerAtributos(padre);
                        cfdi.Conceptos.Agregar(concepto);
                        break;
                     case "Impuestos":
                        cfdi.Impuestos = new Impuestos();
                        cfdi.Impuestos.atributos = leerAtributos(padre);
                        break;
                     case "Traslados":
                        cfdi.Impuestos.Traslados = new Traslados();
                        break;
                     case "Traslado":
                        Traslado traslado = new Traslado();
                        traslado.atributos = leerAtributos(padre);
                        cfdi.Impuestos.Traslados.Agregar(traslado);
                        break;
                     case "Retenciones":
                        cfdi.Impuestos.Retenciones = new Retenciones();
                        break;
                     case "Retencion":
                        Retencion retencion = new Retencion();
                        retencion.atributos = leerAtributos(padre);
                        cfdi.Impuestos.Retenciones.Agregar(retencion);
                        break;
                     }
                  break;
               }
               case "tfd": {
                  switch(padre.LocalName) {
                        case "TimbreFiscalDigital":
                        TimbreFiscalDigital timbre = new TimbreFiscalDigital();
                        timbre.atributos = leerAtributos(padre);
                        cfdi.AgregarComplemento(timbre);
                        break;
                  }
                  break;
               }
               case "nomina": {
                  switch(padre.LocalName) {
                        case "Nomina":
                        Nomina nomina = new Nomina();
                        nomina.atributos = leerAtributos(padre);
                        cfdi.AgregarComplemento(nomina);
                        break;
                     case "Percepciones":
                        Percepciones percepciones = new Percepciones();
                        percepciones.atributos = leerAtributos(padre);
                        cfdi.Nomina.Percepciones = percepciones;
                        break;
                     case "Percepcion":
                        Percepcion percepcion = new Percepcion();
                        percepcion.atributos = leerAtributos(padre);
                        cfdi.Nomina.Percepciones.Agregar(percepcion);
                        break;
                     case "Deducciones":
                        Deducciones deducciones = new Deducciones();
                        deducciones.atributos = leerAtributos(padre);
                        cfdi.Nomina.Deducciones = deducciones;
                        break;
                     case "Deduccion":
                        Deduccion deduccion = new Deduccion();
                        deduccion.atributos = leerAtributos(padre);
                        cfdi.Nomina.Deducciones.Agregar(deduccion);
                        break;
                     case "Incapacidades":
                        cfdi.Nomina.Incapacidades = new Incapacidades();
                        break;
                     case "Incapacidad":
                        Incapacidad incapacidad = new Incapacidad();
                        incapacidad.atributos = leerAtributos(padre);
                        cfdi.Nomina.Incapacidades.Agregar(incapacidad);
                        break;
                     case "HorasExtras":
                        cfdi.Nomina.HorasExtras = new HorasExtras();
                        break;
                     case "HorasExtra":
                        HorasExtra horasExtra = new HorasExtra();
                        horasExtra.atributos = leerAtributos(padre);
                        cfdi.Nomina.HorasExtras.Agregar(horasExtra);
                        break;
                  }
                  break;
               }
               case "ecc": {
                  switch(padre.LocalName) {
                        case "EstadoDeCuentaCombustible":
                        EstadoDeCuentaCombustible edoCta = new EstadoDeCuentaCombustible();
                        edoCta.atributos = leerAtributos(padre);
                        cfdi.AgregarComplemento(edoCta);
                        break;
                     case "Conceptos":
                        cfdi.EstadoDeCuentaCombustible.conceptos = new ConceptosEstadoDeCuentaCombustibles();
                        break;
                     case "ConceptoEstadoDeCuentaCombustible":
                        ConceptoEstadoDeCuenta concepto = new ConceptoEstadoDeCuenta();
                        concepto.atributos = leerAtributos(padre);
                        cfdi.EstadoDeCuentaCombustible.Agregar(concepto);
                        break;
                     case "Traslados":
                        cfdi.EstadoDeCuentaCombustible.conceptos[cfdi.EstadoDeCuentaCombustible.conceptos.Elementos - 1].traslados = new TrasladosConceptosEstadoDeCuentaCombustible();
                        break;
                     case "Traslado":
                        TrasladoEstadoDeCuentaCombustible traslado = new TrasladoEstadoDeCuentaCombustible();
                        traslado.atributos = leerAtributos(padre);
                        cfdi.EstadoDeCuentaCombustible.conceptos[cfdi.EstadoDeCuentaCombustible.conceptos.Elementos - 1].AgregaTraslado(traslado);
                        break;
                  }
                  break;
               }
         }
         
         // Procesamos los nodos hijos
         for(int i = 0; i < padre.ChildNodes.Count; i++) {
            if(padre.ChildNodes[i].NodeType == XmlNodeType.Element) {
               LeerNodos(padre.ChildNodes[i]);
            }
         }
      }
      
      /// <summary>
      /// Valida un Comprobante XML con el XSD especificado
      /// </summary>
      /// <param name="rutaXML">Ruta del archivo XML</param>
      /// <param name="rutaXSD">Ruta del archivo XSD</param>
      public Comprobante LeerXML(string rutaXML, string rutaXSD) {
         documento = new XmlDocument();
         documento.Load(rutaXML);
         Validar(rutaXSD);
         return LeerXML(rutaXML);
      }
      
      /// <summary>
      /// Valida el documento XML actual con el XSD especificado
      /// </summary>
      /// <param name="rutaXSD">Ruta del archivo XSD</param>
      private void Validar(string rutaXSD){
         esquemas.Add(XmlSchema.Read(XmlReader.Create(rutaXSD), ValidationCallback));
         documento.Schemas = esquemas;
         documento.Validate((o, e) => {
                               throw new Exception("ERROR: " + e.Message);
                      });
      }
      
      /// <summary>
      /// Evento que atrapa los errores encontrados en el XML encontrados por el XSD
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="args"></param>
      static void ValidationCallback(object sender, ValidationEventArgs args) {
         switch(args.Severity) {
            case XmlSeverityType.Warning:
               throw new Exception("ADVERTENCIA: " + args.Message);
            case XmlSeverityType.Error:
               throw new Exception("ERROR: " + args.Message);
         }
      }
   }
}
