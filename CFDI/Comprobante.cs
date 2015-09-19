/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 16/09/2015
 * Hora: 12:44 a.m.
 * 
 */
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Collections.Generic;

namespace IsaRoGaMX.CFDI
{
   public enum TipoDeComprobante { INGRESO, EGRESO, TRASLADO }
   
   public class Comprobante : baseObject {
	   Emisor emisor;
	   Receptor receptor;
	   Conceptos conceptos = new Conceptos();
	   Impuestos impuestos = new Impuestos();
	   string cadenaOriginal = string.Empty;
	   List<ComplementoComprobante> complementos;
	   XmlDocument documento;
	   const string DEFAULT_VERSION = "3.2";
	   internal static int decimales = 2;
	   internal static string formatoDecimales = "#.";
	   
	   public static void Decimales(int digitos) {
	      if(digitos > 0 && digitos < 7)
	         Comprobante.decimales = digitos;
	      else
	         throw new Exception("El t_Importe para el CFDI 3.2 especifica que debe namejar un máximo de 6 digitos");
	   }
	   
	   public void AgregarComplemento(ComplementoComprobante complemento) {
	      if(complementos == null)
	         complementos = new List<ComplementoComprobante>();
	      complementos.Add(complemento);
	   }
	   
	   internal XmlDocument Documento{
	      get {
	         // Documento XML
	      documento = new XmlDocument();
	      
	      // Declaracion del Documento XML
	      XmlDeclaration declaracion = documento.CreateXmlDeclaration("1.0", "utf-8", "");
	      documento.AppendChild(declaracion);
	      
	      // Comprobante
	      XmlElement comprobante = this.NodoXML("cfdi", "http://www.sat.gob.mx/cfd/3", documento);
	      
	      // Emisor
	      XmlElement nodoEmisor = this.Emisor.NodoXML(comprobante.Prefix, comprobante.NamespaceURI, documento);
	      comprobante.AppendChild(nodoEmisor);
	      
	      // Receptor
	      XmlElement nodoReceptor = this.Receptor.NodoXML(comprobante.Prefix, comprobante.NamespaceURI, documento);
	      comprobante.AppendChild(nodoReceptor);
	      
	      // Conceptos
	      XmlElement nodoConceptos = documento.CreateElement(comprobante.Prefix, this.Conceptos.GetType().Name, comprobante.NamespaceURI);
	      for(int i = 0; i < this.Conceptos.Elementos; i++) {
	         XmlElement nodoConcepto = this.Conceptos[i].NodoXML(comprobante.Prefix, comprobante.NamespaceURI, documento);
	         nodoConceptos.AppendChild(nodoConcepto);
	      }
	      comprobante.AppendChild(nodoConceptos);
	      
	      // Impuestos
	      XmlElement nodoImpuestos = documento.CreateElement(comprobante.Prefix, this.Impuestos.GetType().Name, comprobante.NamespaceURI);
	      
            // Retenciones
            if(this.Impuestos.Retenciones.Elementos > 0) {
               XmlElement nodoRetenciones = documento.CreateElement(comprobante.Prefix, this.Impuestos.Retenciones.GetType().Name, comprobante.NamespaceURI);
               for(int r = 0; r < this.Impuestos.Retenciones.Elementos; r++) {
                  XmlElement nodoRetencion = this.Impuestos.Retenciones[r].NodoXML(comprobante.Prefix, comprobante.NamespaceURI, documento);
                  nodoRetenciones.AppendChild(nodoRetencion);
               }
               nodoImpuestos.AppendChild(nodoRetenciones);
            }
         
            // Traslados
            if(this.Impuestos.Traslados.Elementos > 0) {
               XmlElement nodoTraslados = documento.CreateElement(comprobante.Prefix, this.Impuestos.Traslados.GetType().Name, comprobante.NamespaceURI);
               for(int t = 0; t < this.Impuestos.Traslados.Elementos; t++) {
                  XmlElement nodoTraslado = this.Impuestos.Traslados[t].NodoXML(comprobante.Prefix, comprobante.NamespaceURI, documento);
                  nodoTraslados.AppendChild(nodoTraslado);
               }
               nodoImpuestos.AppendChild(nodoTraslados);
            }
         
         // Se agrega el nodo de impuestos
	      comprobante.AppendChild(nodoImpuestos);
	      
	      // Se agrega el comprobante al documetno
	      documento.AppendChild(comprobante);
	      
	      // Regreso el documento XML
	      return documento;
	      }
	   }
	   
	   public Emisor Emisor {
	      get { return emisor; }
	      set { emisor = value; }
	   }
	   
	   public Receptor Receptor {
	      get { return receptor; }
	      set { receptor = value; }
	   }
	   
	   public Comprobante() : base() { }
	   
	   /// <summary>
	   /// Crea una instancia de un <see cref="Comprobante"/> con sus atributos minimos obligatorios
	   /// </summary>
	   public Comprobante(DateTime fecha, string formaDePago,  
	                      double subTotal, double total, TipoDeComprobante tipoDeComprobante, 
	                      string metodoDePago, string LugarExpedicion, Emisor emisor, Receptor receptor) {
	      if(emisor == null)
	         throw new Exception("Comprobante::Comprobante. Emisor no puede ser nulo");
	      if(receptor == null)
	         throw new Exception("Comprobante::Comprobante. Receptor no puede ser nulo");
	      atributos.Add("version", DEFAULT_VERSION);
	      atributos.Add("fecha", Comprobante.FechaISO8601(fecha));
	      atributos.Add("formaDePago", formaDePago);
	      atributos.Add("subTotal", subTotal.ToString("#.000000"));
	      atributos.Add("total", total.ToString("#.000000"));
	      atributos.Add("tipoDeComprobante", tipoDeComprobante.ToString().ToLower());
	      atributos.Add("metodoDePago", metodoDePago);
	      atributos.Add("LugarExpedicion", LugarExpedicion);
	      this.emisor = emisor;
	      this.receptor = receptor;
	   }
	   
	   /// <summary>
	   /// Crea una instancia de un <see cref="Comprobante"/> con sus atributos obligatorios y algunos opcionales
	   /// </summary>
	   public Comprobante(string serie, string folio, DateTime fecha, string sello, string formaDePago, 
	                      string noCertificado,string certificado, string condicionesDePago, double subTotal, 
	                      double total,TipoDeComprobante tipoDeComprobante, string metodoDePago, string LugarExpedicion,
	                      Emisor emisor, Receptor receptor) {
	      if(emisor == null)
	         throw new Exception("Comprobante::Comprobante. Emisor no puede ser nulo");
	      if(receptor == null)
	         throw new Exception("Comprobante::Comprobante. Receptor no puede ser nulo");
	      atributos.Add("version", DEFAULT_VERSION);
	      atributos.Add("serie", serie);
	      atributos.Add("folio", folio);
	      atributos.Add("fecha", Comprobante.FechaISO8601(fecha));
	      atributos.Add("sello", sello);
	      atributos.Add("formaDePago", formaDePago);
	      atributos.Add("noCertificado", noCertificado);
	      atributos.Add("certificado", certificado);
	      atributos.Add("condicionesDePago", condicionesDePago);
	      atributos.Add("subTotal", subTotal.ToString("#.000000"));
	      atributos.Add("total", total.ToString("#.000000"));
	      atributos.Add("tipoDeComprobante", tipoDeComprobante.ToString().ToLower());
	      atributos.Add("metodoDePago", metodoDePago);
	      atributos.Add("LugarExpedicion", LugarExpedicion);
	      this.emisor = emisor;
	      this.receptor = receptor;
	   }
	   
	   /// <summary>
	   /// Crea una instancia de un <see cref="Comprobante"/> con sus atributos obligatorios y opcionales especificadno un tipo de cambio y moneda
	   /// </summary>
	   public Comprobante(string serie, string folio, DateTime fecha, string sello, string formaDePago, 
	                      string noCertificado,string certificado, string condicionesDePago, double subTotal, 
	                      string TipoCambio, string Moneda, double total,TipoDeComprobante tipoDeComprobante, 
	                      string metodoDePago, string LugarExpedicion, Emisor emisor, Receptor receptor) {
	      if(emisor == null)
	         throw new Exception("Comprobante::Comprobante. Emisor no puede ser nulo");
	      if(receptor == null)
	         throw new Exception("Comprobante::Comprobante. Receptor no puede ser nulo");
	      atributos.Add("version", DEFAULT_VERSION);
	      atributos.Add("serie", serie);
	      atributos.Add("folio", folio);
	      atributos.Add("fecha", Comprobante.FechaISO8601(fecha));
	      atributos.Add("sello", sello);
	      atributos.Add("formaDePago", formaDePago);
	      atributos.Add("noCertificado", noCertificado);
	      atributos.Add("certificado", certificado);
	      atributos.Add("condicionesDePago", condicionesDePago);
	      atributos.Add("subTotal", subTotal.ToString("#.000000"));
	      atributos.Add("TipoCambio", TipoCambio);
	      atributos.Add("Moneda", Moneda);
	      atributos.Add("total", total.ToString("#.000000"));
	      atributos.Add("tipoDeComprobante", tipoDeComprobante.ToString().ToLower());
	      atributos.Add("metodoDePago", metodoDePago);
	      atributos.Add("LugarExpedicion", LugarExpedicion);
	      this.emisor = emisor;
	      this.receptor = receptor;
	   }
	   
	   /*// <summary>
	   /// Crea una instancia de un <see cref="Comprobante"/> con sus atributos obligatorios y opcionales especificando un descuento
	   /// </summary>
	   public Comprobante(string serie, string folio, DateTime fecha, string sello, string formaDePago, 
	                      string noCertificado,string certificado, string condicionesDePago, double subTotal, 
	                      string descuento, string motivoDescuento, double total,TipoDeComprobante tipoDeComprobante, 
	                      string metodoDePago, string LugarExpedicion, Emisor emisor, Receptor receptor) {
	      if(emisor == null)
	         throw new Exception("Comprobante::Comprobante. Emisor no puede ser nulo");
	      if(receptor == null)
	         throw new Exception("Comprobante::Comprobante. Receptor no puede ser nulo");
	      atributos.Add("serie", serie);
	      atributos.Add("folio", folio);
	      atributos.Add("fecha", fecha.ToString("yyyy-MM-ddTHH:mm:ss"));
	      atributos.Add("sello", sello);
	      atributos.Add("formaDePago", formaDePago);
	      atributos.Add("noCertificado", noCertificado);
	      atributos.Add("certificado", certificado);
	      atributos.Add("condicionesDePago", condicionesDePago);
	      atributos.Add("subTotal", subTotal.ToString("#.000000"));
	      atributos.Add("descuento", descuento);
	      atributos.Add("motivoDescuento", motivoDescuento);
	      atributos.Add("total", total.ToString("#.000000"));
	      atributos.Add("tipoDeComprobante", tipoDeComprobante.ToString().ToLower());
	      atributos.Add("metodoDePago", metodoDePago);
	      atributos.Add("LugarExpedicion", LugarExpedicion);
	   }*/
	   
	   public Conceptos Conceptos {
	      get { return conceptos; }
	      set { conceptos = value; }
	   }
	   
	   public Impuestos Impuestos {
	      get { return impuestos; }
	      set { impuestos = value; }
	   }
	   
	   public string Version {
	      get {
	         if(atributos.ContainsKey("version"))
	            return atributos["version"];
	         return DEFAULT_VERSION;
	      }
	   }
	   
	   public string Serie {
	      get {
	         if(atributos.ContainsKey("serie"))
	            return atributos["serie"];
	         return string.Empty;
	      }
	      set {
	         if(atributos.ContainsKey("serie"))
	            atributos["serie"] = value;
	         else
	            atributos.Add("serie", value);
	      }
	   }
	   
	   public string Folio {
	      get {
	         if(atributos.ContainsKey("folio"))
	            return atributos["folio"];
	         return string.Empty;
	      }
	      set {
	         if(atributos.ContainsKey("folio"))
	            atributos["folio"] = value;
	         else
	            atributos.Add("folio", value);
	      }
	   }
	   
	   public string FechaString {
	      get {
	         if(atributos.ContainsKey("fecha"))
	            return atributos["fecha"];
	         throw new Exception("Comprobante::fecha. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("fecha"))
	            atributos["fecha"] = value;
	         else
	            atributos.Add("fecha", value);
	      }
	   }
	   
	   public DateTime FechaDateTime {
	      get {
	         if(atributos.ContainsKey("fecha"))
	            return DateTime.Parse(atributos["fecha"],  null, System.Globalization.DateTimeStyles.RoundtripKind);
	         throw new Exception("Comprobante::fecha. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("fecha"))
	            atributos["fecha"] = value.ToString("yyyy-MM-ddTHH:mm:ss");
	         else
	            atributos.Add("fecha", value.ToString("yyyy-MM-ddTHH:mm:ss"));
	      }
	   }
	   
	   public string Sello {
	      get {
	         if(atributos.ContainsKey("sello"))
	            return atributos["sello"];
	         throw new Exception("Comprobante::sello. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("sello"))
	            atributos["sello"] = value;
	         else
	            atributos.Add("sello", value);
	      }
	   }
	   
	   public string FormaDePago {
	      get {
	         if(atributos.ContainsKey("formaDePago"))
	            return atributos["formaDePago"];
	         throw new Exception("Comprobante::formaDePago. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("formaDePago"))
	            atributos["formaDePago"] = value;
	         else
	            atributos.Add("formaDePago", value);
	      }
	   }
	   
	   public string NoCertificado {
	      get {
	         if(atributos.ContainsKey("noCertificado"))
	            return atributos["noCertificado"];
	         throw new Exception("Comprobante::noCertificado. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("noCertificado"))
	            atributos["noCertificado"] = value;
	         else
	            atributos.Add("noCertificado", value);
	      }
	   }
	   
	   public string Certificado {
	      get {
	         if(atributos.ContainsKey("certificado"))
	            return atributos["certificado"];
	         throw new Exception("Comprobante::certificado. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("certificado"))
	            atributos["certificado"] = value;
	         else
	            atributos.Add("certificado", value);
	      }
	   }
	   
	   public string CondicionesDePago {
	      get {
	         if(atributos.ContainsKey("condicionesDePago"))
	            return atributos["condicionesDePago"];
	         else
	            return string.Empty;
	      }
	      set {
	         if(atributos.ContainsKey("condicionesDePago"))
	            atributos["condicionesDePago"] = value;
	         else
	            atributos.Add("condicionesDePago", value);
	      }
	   }
	   
	   public double SubTotal {
	      get {
	         if(atributos.ContainsKey("subTotal"))
	            return Convert.ToDouble(atributos["subTotal"]);
	         else
	            throw new Exception("Comprobante::subTotal. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("subTotal"))
	            atributos["subTotal"] = value.ToString("#.000000");
	         else
	            atributos.Add("subTotal", value.ToString("#.000000"));
	      }
	   }
	   
	   public double Descuento {
	      get {
	         if(atributos.ContainsKey("descuento"))
	            return Convert.ToDouble(atributos["descuento"]);
	         return 0.0;
	      }
	      set {
	         if(atributos.ContainsKey("descuento"))
	            atributos["descuento"] = value.ToString("#.000000");
	         else
	            atributos.Add("descuento", value.ToString("#.000000"));
	      }
	   }
	   
	   public string MotivoDescuento {
	      get {
	         if(atributos.ContainsKey("motivoDescuento"))
	            return atributos["motivoDescuento"];
	         else
	            return string.Empty;
	      }
	      set {
	         if(atributos.ContainsKey("motivoDescuento"))
	            atributos["motivoDescuento"] = value;
	         else
	            atributos.Add("motivoDescuento", value);
	      }
	   }
	   
	   public string TipoCambio {
	      get {
	         if(atributos.ContainsKey("TipoCambio"))
	            return atributos["TipoCambio"];
	         else
	            return string.Empty;
	      }
	      set {
	         if(atributos.ContainsKey("TipoCambio"))
	            atributos["TipoCambio"] = value;
	         else
	            atributos.Add("TipoCambio", value);
	      }
	   }
	   
	   public string Moneda {
	      get {
	         if(atributos.ContainsKey("Moneda"))
	            return atributos["Moneda"];
	         else
	            return string.Empty;
	      }
	      set {
	         if(atributos.ContainsKey("Moneda"))
	            atributos["Moneda"] = value;
	         else
	            atributos.Add("Moneda", value);
	      }
	   }
	   
	   public double Total {
	      get {
	         if(atributos.ContainsKey("total"))
	            return Convert.ToDouble(atributos["total"]);
	         throw new Exception("Comprobante::total. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("total"))
	            atributos["total"] = value.ToString("#.000000");
	         else
	            atributos.Add("total", value.ToString("#.000000"));
	      }
	   }
	   
	   public TipoDeComprobante TipoDeComprobante {
	      get {
	         if(atributos.ContainsKey("tipoDeComprobante"))
	            return (TipoDeComprobante) Enum.Parse(typeof(TipoDeComprobante), atributos["tipoDeComprobante"].ToUpper(), true);
	         throw new Exception("Comprobante::tipoDeComprobante. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("tipoDeComprobante"))
	            atributos["tipoDeComprobante"] = value.ToString().ToLower();
	         else
	            atributos.Add("tipoDeComprobante", value.ToString().ToLower());
	      }
	   }
	   
	   public string MetodoDePago {
	      get {
	         if(atributos.ContainsKey("metodoDePago"))
	            return atributos["metodoDePago"];
	         else
	            throw new Exception("Comprobante::metodoDePago. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("metodoDePago"))
	            atributos["metodoDePago"] = value;
	         else
	            atributos.Add("metodoDePago", value);
	      }
	   }
	   
	   public string LugarExpedicion {
	      get {
	         if(atributos.ContainsKey("LugarExpedicion"))
	            return atributos["LugarExpedicion"];
	         else
	            throw new Exception("Comprobante::LugarExpedicion. No puede estar vacio");
	      }
	      set {
	         if(atributos.ContainsKey("LugarExpedicion"))
	            atributos["LugarExpedicion"] = value;
	         else
	            atributos.Add("LugarExpedicion", value);
	      }
	   }
	   
	   public string NumCtaPago {
	      get {
	         if(atributos.ContainsKey("NumCtaPago"))
	            return atributos["NumCtaPago"];
	         else
	            return string.Empty;
	      }
	      set {
	         if(atributos.ContainsKey("NumCtaPago"))
	            atributos["NumCtaPago"] = value;
	         else
	            atributos.Add("NumCtaPago", value);
	      }
	   }
	   
	   public string FolioFiscalOrig {
	      get {
	         if(atributos.ContainsKey("FolioFiscalOrig"))
	            return atributos["FolioFiscalOrig"];
	         else
	            return string.Empty;
	      }
	      set {
	         if(atributos.ContainsKey("FolioFiscalOrig"))
	            atributos["FolioFiscalOrig"] = value;
	         else
	            atributos.Add("FolioFiscalOrig", value);
	      }
	   }
	   
	   public string SerieFolioFiscalOrig {
	      get {
	         if(atributos.ContainsKey("SerieFolioFiscalOrig"))
	            return atributos["SerieFolioFiscalOrig"];
	         else
	            return string.Empty;
	      }
	      set {
	         if(atributos.ContainsKey("SerieFolioFiscalOrig"))
	            atributos["SerieFolioFiscalOrig"] = value;
	         else
	            atributos.Add("SerieFolioFiscalOrig", value);
	      }
	   }
	   
	   public string FechaFolioFiscalOrigString {
	      get {
	         if(atributos.ContainsKey("FechaFolioFiscalOrig"))
	            return atributos["FechaFolioFiscalOrig"];
	         return string.Empty;
	      }
	      set {
	         if(atributos.ContainsKey("FechaFolioFiscalOrig"))
	            atributos["FechaFolioFiscalOrig"] = value;
	         else
	            atributos.Add("FechaFolioFiscalOrig", value);
	      }
	   }
	   
	   public DateTime FechaFolioFiscalOrigDateTime {
	      get {
	         if(atributos.ContainsKey("FechaFolioFiscalOrig"))
	            return DateTime.Parse(atributos["FechaFolioFiscalOrig"],  null, System.Globalization.DateTimeStyles.RoundtripKind);
	         return DateTime.MinValue;
	      }
	      set {
	         if(atributos.ContainsKey("FechaFolioFiscalOrig"))
	            atributos["FechaFolioFiscalOrig"] = Comprobante.FechaISO8601(value);
	         else
	            atributos.Add("FechaFolioFiscalOrig", Comprobante.FechaISO8601(value));
	      }
	   }
	   
	   public double MontoFolioFiscalOrig {
	      get {
	         if(atributos.ContainsKey("MontoFolioFiscalOrig"))
	            return Convert.ToDouble(atributos["MontoFolioFiscalOrig"]);
	         else
	            return 0.0;
	      }
	      set {
	         if(atributos.ContainsKey("MontoFolioFiscalOrig"))
	            atributos["MontoFolioFiscalOrig"] = value.ToString("#.000000");
	         else
	            atributos.Add("MontoFolioFiscalOrig", value.ToString("#.000000"));
	      }
	   }
	   
	   public string CadenaOriginal {
	      get { return cadenaOriginal; }
	   }
	   
      public override XmlElement NodoXML(string prefijo, string namespaceURI, XmlDocument documento)
      {
         // Nodo XML con los atributos de comprobante
         XmlElement comprobante = base.NodoXML(prefijo, namespaceURI, documento);
         
         // Se crea el SchemaLocation
         XmlAttribute schemaLocation = documento.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
         schemaLocation.Value = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd";
         
         // Se agrega el SchemaLocation
         comprobante.Attributes.Append(schemaLocation);
         
         // Se retorna el comprobante
         return comprobante;
      }
      
      /// <summary>
      /// Crea la cadena original y sella el comprobante actual
      /// </summary>
      /// <param name="rutaXSLT">Ruta del archivo XSLT usado para calcular la cadena original</param>
      /// <param name="key">Ruta del archivo KEY</param>
      /// <param name="cert">Ruta del archivo CER</param>
      /// <param name="passwrd">Contraseña del archivo KEY</param>
      public void sellarComprobante(string rutaXSLT, string key, string cert, string passwrd) {
         // Objeto OpenSSLKey
         opensslkey ossl = new opensslkey();
         
         // Se genera la cadena original
         cadenaOriginal = this.generaCadenaOriginal(rutaXSLT);
         
         // Se genera el numero de certificado y el certificado
         string certificado = "";
         string noCertificado = "";
         ossl.CertificateData(cert, out certificado, out noCertificado);
         
         // Se firma el comprobante
         this.Sello = ossl.SignString(key, passwrd, cadenaOriginal);
         this.Certificado = certificado;
         this.NoCertificado = noCertificado;
      }
      
      /// <see cref="http://solucionfactible.com/sfic/capitulos/timbrado/cadena_original.jsp"/>
      /// <seealso cref="http://stackoverflow.com/questions/2384306/how-to-transform-xml-as-a-string-w-o-using-files-in-net/2389628#2389628"/>
      private string generaCadenaOriginal(string rutaXSLT) {         
         // Fuente: 
         StringReader sri = new StringReader(Documento.OuterXml);
         XmlReader xri = XmlReader.Create(sri);
         XslCompiledTransform xslt = new XslCompiledTransform();
         xslt.Load(rutaXSLT);
         StringWriter sw = new StringWriter();
         XmlTextWriter myWriter = new XmlTextWriter(sw);
         
         //Aplicando transformacion
         xslt.Transform(xri, myWriter);
         
         //Resultado
         return sw.ToString();
            
      }
      
      public static string FechaISO8601(DateTime fecha) {
         return fecha.ToString("yyyy-MM-ddTHH:mm:ss");
      }
	}
}