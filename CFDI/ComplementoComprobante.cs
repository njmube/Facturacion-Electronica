/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 19/09/2015
 * Hora: 12:20 a.m.
 * 
 */
using System;
using System.Collections.Generic;

namespace IsaRoGaMX.CFDI
{
   public abstract class ComplementoComprobante : baseObject
   { }
   
   #region Timbre Fiscal Digital
   
   public class TimbreFiscalDigital : ComplementoComprobante {
      public TimbreFiscalDigital() :base() { }
      
      public TimbreFiscalDigital(string version, string uuid, DateTime fechaTimbrado, string selloCFD, string noCertificadoSAT, string selloSAT) {
         atributos.Add("version", version);
         atributos.Add("UUID", uuid);
         atributos.Add("FechaTimbrado", Conversiones.DateTimeFechaISO8601(fechaTimbrado));
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
   
   #endregion
   
   #region Complementos Nomina 
   
   #region Percepciones
   
   public class Percepciones : baseObject {
      List<Percepcion> percepciones;
      
      public Percepciones() : base() {
         percepciones = new List<Percepcion>();
      }
      
      public Percepciones(double totalGravado, double totalExento, List<Percepcion> percepciones)
         : base() {
         atributos.Add("TotalGravado", totalGravado.ToString());
         atributos.Add("TotalExento", totalExento.ToString());
         this.percepciones = percepciones;
      }
      
      public void Agregar(Percepcion percepcion) {
         percepciones.Add(percepcion);
      }
      
      public void Eliminar(int indice) {
         if(indice >= 0 && indice < percepciones.Count)
            percepciones.RemoveAt(indice);
         else
            throw new Exception("Percepciones::[indice]. Indice fuera de rango");
      }
      
      public Percepcion this[int indice] {
         get {
            if(indice >= 0 && indice < percepciones.Count)
               return percepciones[indice];
            throw new Exception("Percepciones::[indice]. Indice fuera de rango");
         }
      }
      
      public double TotalGravado {
         get {
            if(atributos.ContainsKey("TotalGravado"))
               return Convert.ToDouble(atributos["TotalGravado"]);
            throw new Exception("Percepciones::TotalGravado. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("TotalGravado"))
               atributos["TotalGravado"] = value.ToString();
            else
               atributos.Add("TotalGravado", value.ToString());
         }
      }
      
      public double TotalExento{
         get {
            if(atributos.ContainsKey("TotalExento"))
               return Convert.ToDouble(atributos["TotalExento"]);
            throw new Exception("Percepciones::TotalExento. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("TotalExento"))
               atributos["TotalExento"] = value.ToString();
            else
               atributos.Add("TotalGravado", value.ToString());
         }
      }
      
      public int Elementos {
         get { return percepciones.Count; }
      }
   }
   
   public class Percepcion : baseObject {
      public Percepcion() : base() { }
      
      public Percepcion(int tipoPercepcion, string clave, string concepto, double importeGravado, double importeExento) 
         :base() {
         atributos.Add("TipoPercepcion", tipoPercepcion.ToString());
         atributos.Add("Clave", clave);
         atributos.Add("Concepto", concepto);
         atributos.Add("ImporteGravado", importeGravado.ToString("#.000000"));
         atributos.Add("ImporteExento", importeExento.ToString("#.000000"));
      }
      
      public int TipoPercepcion {
         get {
            if(atributos.ContainsKey("TipoPercepcion"))
               return Convert.ToInt32(atributos["TipoPercepcion"]);
            throw new Exception("Percepcion::TipoPercepcion. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("TipoPercepcion"))
               atributos["TipoPercepcion"] =  value.ToString();
            else
               atributos.Add("TipoPercepcion", value.ToString());
         }
      }
      
      public string Clave {
         get {
            if(atributos.ContainsKey("Clave"))
               return atributos["Clave"];
            throw new Exception("Percepcion::Clave. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("Clave"))
               atributos["Clave"] = value;
            else
               atributos.Add("Clave", value);
         }
      }
      
      public string Concepto {
         get {
            if(atributos.ContainsKey("Concepto"))
               return atributos["Concepto"];
            throw new Exception("Percepcion::Concepto. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("Concepto"))
               atributos["Concepto"] = value;
            else
               atributos.Add("Concepto", value);
         }
      }
      
      public double ImporteGravado {
         get {
            if(atributos.ContainsKey("ImporteGravado"))
               return Convert.ToDouble(atributos["ImporteGravado"]);
            throw new Exception("Percepcion::ImporteGravado. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("ImporteGravado"))
               atributos["ImporteGravado"] = value.ToString("#.000000");
            else
               atributos.Add("ImporteGravado", value.ToString("#.000000"));
         }
      }
      
      public double ImporteExento {
         get {
            if(atributos.ContainsKey("ImporteExento"))
               return Convert.ToDouble(atributos["ImporteExento"]);
            throw new Exception("Percepcion::ImporteExento. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("ImporteExento"))
               atributos["ImporteExento"] = value.ToString("#.000000");
            else
               atributos.Add("ImporteExento", value.ToString("#.000000"));
         }
      }
   }
   
   #endregion
   
   #region Deducciones
   
   public class Deducciones : baseObject {
      List<Deduccion> deducciones;
      
      public Deducciones() : base() {
         deducciones = new List<Deduccion>();
      }
      
      public Deducciones(double totalGravado, double totalExento, List<Deduccion> deducciones)
         : base() {
         atributos.Add("TotalGravado", totalGravado.ToString());
         atributos.Add("TotalExento", totalExento.ToString());
         this.deducciones = deducciones;
      }
      
      public void Agregar(Deduccion deduccion) {
         deducciones.Add(deduccion);
      }
      
      public void Eliminar(int indice) {
         if(indice >= 0 && indice < deducciones.Count)
            deducciones.RemoveAt(indice);
         else
            throw new Exception("Deducciones::[indice]. Indice fuera de rango");
      }
      
      public Deduccion this[int indice] {
         get {
            if(indice >= 0 && indice < deducciones.Count)
               return deducciones[indice];
            throw new Exception("Deducciones::[indice]. Indice fuera de rango");
         }
      }
      
      public double TotalGravado {
         get {
            if(atributos.ContainsKey("TotalGravado"))
               return Convert.ToDouble(atributos["TotalGravado"]);
            throw new Exception("Percepciones::TotalGravado. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("TotalGravado"))
               atributos["TotalGravado"] = value.ToString();
            else
               atributos.Add("TotalGravado", value.ToString());
         }
      }
      
      public double TotalExento{
         get {
            if(atributos.ContainsKey("TotalExento"))
               return Convert.ToDouble(atributos["TotalExento"]);
            throw new Exception("Percepciones::TotalExento. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("TotalExento"))
               atributos["TotalExento"] = value.ToString();
            else
               atributos.Add("TotalGravado", value.ToString());
         }
      }
      
      public int Elementos {
         get { return deducciones.Count; }
      }
   }
   
   public class Deduccion : baseObject {
      public Deduccion() : base() { }
      
      public Deduccion(int tipoDeduccion, string clave, string concepto, double importeGravado, double importeExento) 
         :base() {
         atributos.Add("TipoDeduccion", tipoDeduccion.ToString());
         atributos.Add("Clave", clave);
         atributos.Add("Concepto", concepto);
         atributos.Add("ImporteGravado", importeGravado.ToString("#.000000"));
         atributos.Add("ImporteExento", importeExento.ToString("#.000000"));
      }
      
      public int TipoPercepcion {
         get {
            if(atributos.ContainsKey("TipoPercepcion"))
               return Convert.ToInt32(atributos["TipoPercepcion"]);
            throw new Exception("Percepcion::TipoPercepcion. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("TipoPercepcion"))
               atributos["TipoPercepcion"] =  value.ToString();
            else
               atributos.Add("TipoPercepcion", value.ToString());
         }
      }
      
      public string Clave {
         get {
            if(atributos.ContainsKey("Clave"))
               return atributos["Clave"];
            throw new Exception("Percepcion::Clave. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("Clave"))
               atributos["Clave"] = value;
            else
               atributos.Add("Clave", value);
         }
      }
      
      public string Concepto {
         get {
            if(atributos.ContainsKey("Concepto"))
               return atributos["Concepto"];
            throw new Exception("Percepcion::Concepto. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("Concepto"))
               atributos["Concepto"] = value;
            else
               atributos.Add("Concepto", value);
         }
      }
      
      public double ImporteGravado {
         get {
            if(atributos.ContainsKey("ImporteGravado"))
               return Convert.ToDouble(atributos["ImporteGravado"]);
            throw new Exception("Percepcion::ImporteGravado. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("ImporteGravado"))
               atributos["ImporteGravado"] = value.ToString("#.000000");
            else
               atributos.Add("ImporteGravado", value.ToString("#.000000"));
         }
      }
      
      public double ImporteExento {
         get {
            if(atributos.ContainsKey("ImporteExento"))
               return Convert.ToDouble(atributos["ImporteExento"]);
            throw new Exception("Percepcion::ImporteExento. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("ImporteExento"))
               atributos["ImporteExento"] = value.ToString("#.000000");
            else
               atributos.Add("ImporteExento", value.ToString("#.000000"));
         }
      }
   }
   
   #endregion
   
   #region Incapacidades
   
   public class Incapacidad : baseObject {
      public Incapacidad() : base() { }
      
      public Incapacidad(double diasIncapacidad, int tipoIncapacidad, double descuento) {
         atributos.Add("DiasIncapacidad", diasIncapacidad.ToString());
         atributos.Add("TipoIncapacidad", tipoIncapacidad.ToString());
         atributos.Add("Decuento", descuento.ToString("#.000000"));
      }
      
      public double DiasIncapacidad {
         get {
            if(atributos.ContainsKey("DiasIncapacidad"))
               return Convert.ToDouble(atributos["DiasIncapacidad"]);
            throw new Exception("Incapacidad::DiasIncapacidad. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("DiasIncapacidad"))
               atributos["DiasIncapacidad"] = value.ToString();
            else
               atributos.Add("DiasIncapacidad", value.ToString());
         }
      }
      
      public int TipoIncapacidad {
         get {
            if(atributos.ContainsKey("TipoIncapacidad"))
               return Convert.ToInt32(atributos["TipoIncapacidad"]);
            throw new Exception("Incapacidad::TipoIncapacidad. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("TipoIncapacidad"))
               atributos["TipoIncapacidad"] = value.ToString();
            else
               atributos.Add("TipoIncapacidad", value.ToString());
         }
      }
      
      public double Decuento {
         get {
            if(atributos.ContainsKey("Decuento"))
               return Convert.ToDouble(atributos["Decuento"]);
            throw new Exception("Incapacidad::Decuento. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("Decuento"))
               atributos["Decuento"] = value.ToString();
            else
               atributos.Add("Decuento", value.ToString());
         }
      }
   }
   
   public class Incapacidades {
         List<Incapacidad> incapacidades;
         
         public Incapacidades() {
            incapacidades = new List<Incapacidad>();
         }
         
         public Incapacidad this[int indice] {
            get {
               if(indice >= 0 && indice < incapacidades.Count)
                  return incapacidades[indice];
               throw new Exception("Incapacidades:[indice]. Indice fuera de rango");
            }
         }
         
         public void Agregar(Incapacidad incapacidad) {
            incapacidades.Add(incapacidad);
         }
         
         public void Eliminar(int indice) {
            if(indice >= 0 && indice < incapacidades.Count)
               incapacidades.RemoveAt(indice);
            else
               throw new Exception("Incapacidades:Eliminar(). Indice fuera de rango");
         }
         
         public int Elementos {
            get { return incapacidades.Count; }
         }
      }
   
   #endregion
   
   #region HorasExtras
   
   public class HorasExtra : baseObject {
      public HorasExtra() : base() { }
      
      public HorasExtra(int dias, string tipoHoras, int horasExtra, double importePagado)
         : base() {
         atributos.Add("Dias", dias.ToString());
         atributos.Add("TipoHoras", tipoHoras);
         atributos.Add("HorasExtra", horasExtra.ToString());
         atributos.Add("ImportePagado", importePagado.ToString("#.000000"));
      }
      
      public int Dias {
         get {
            if(atributos.ContainsKey("Dias"))
               return Convert.ToInt32(atributos["Dias"]);
            throw new Exception("HorasExtra::Dias. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("Dias"))
               atributos["Dias"] = value.ToString();
            else
               atributos.Add("Dias", value.ToString());
         }
      }
      
      public string TipoHoras {
         get {
            if(atributos.ContainsKey("TipoHoras"))
               return atributos["TipoHoras"];
            throw new Exception("HorasExtra::TipoHoras. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("TipoHoras"))
               atributos["TipoHoras"] = value;
            else
               atributos.Add("TipoHoras", value);
         }
      }
      
      public int Horas {
         get {
            if(atributos.ContainsKey("HorasExtra"))
               return Convert.ToInt32(atributos["HorasExtra"]);
            throw new Exception("HorasExtra::HorasExtra. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("HorasExtra"))
               atributos["HorasExtra"] = value.ToString();
            else
               atributos.Add("HorasExtra", value.ToString());
         }
      }
      
      public double ImportePagado {
         get {
            if(atributos.ContainsKey("ImportePagado"))
               return Convert.ToDouble(atributos["ImportePagado"]);
            throw new Exception("HorasExtra::ImportePagado. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("ImportePagado"))
               atributos["ImportePagado"] = value.ToString();
            else
               atributos.Add("ImportePagado", value.ToString());
         }
      }
   }
   
   public class HorasExtras {
         List<HorasExtra> horasExtra;
         
         public HorasExtras() {
            horasExtra = new List<HorasExtra>();
         }
         
         public HorasExtra this[int indice] {
            get {
               if(indice >= 0 && indice < horasExtra.Count)
                  return horasExtra[indice];
               throw new Exception("HorasExtras:[indice]. Indice fuera de rango");
            }
         }
         
         public void Agregar(HorasExtra horasExtra) {
            this.horasExtra.Add(horasExtra);
         }
         
         public void Eliminar(int indice) {
            if(indice >= 0 && indice < horasExtra.Count)
               horasExtra.RemoveAt(indice);
            else
               throw new Exception("HorasExtras:Eliminar(). Indice fuera de rango");
         }
         
         public int Elementos {
            get { return horasExtra.Count; }
         }
      }
   
   #endregion
   
   public class Nomina : ComplementoComprobante {
      Percepciones percepciones;
      Deducciones deducciones;
      Incapacidades incapacidades;
      HorasExtras horasExtras;
      
      public Nomina() : base() {
         atributos.Add("Version", "1.1");
      }
      
      public Nomina(string version, string numEmpleado, string curp, string tipoRegimen, DateTime fechaPago, DateTime fechaInicial, DateTime fechaFinal, double numDiasPagados, string periodicidadPago) {
         atributos.Add("Version", "1.1");
         atributos.Add("NumEmpleado", numEmpleado);
         atributos.Add("CURP", curp);
         atributos.Add("TipoRegimen", tipoRegimen);
         atributos.Add("FechaPago", Conversiones.DateTimeFechaISO8601(fechaPago));
         atributos.Add("FechaInicialPago", Conversiones.DateTimeFechaISO8601(fechaInicial));
         atributos.Add("FechaFinalPago", Conversiones.DateTimeFechaISO8601(fechaFinal));
         atributos.Add("NumDiasPagados", numDiasPagados.ToString());
         atributos.Add("PeriodicidadPago", periodicidadPago);
      }
      
      public string Version {
         get {
            if(atributos.ContainsKey("Version"))
               return atributos["Version"];
            throw new Exception("Nomina::Version. No puede estar vacio");
         }
      }
      
      public string RegistroPatronal {
         get {
            if(atributos.ContainsKey("RegistroPatronal"))
               return atributos["RegistroPatronal"];
            return string.Empty;
         }
         set {
            if(atributos.ContainsKey("RegistroPatronal"))
               atributos["RegistroPatronal"] = value;
            else
               atributos.Add("RegistroPatronal", value);
         }
      }
      
      public string NumEmpleado {
         get {
            if(atributos.ContainsKey("NumEmpleado"))
               return atributos["NumEmpleado"];
            throw new Exception("Nomina::NumEmpleado. No puede estar vacio");
         }
      }
      
      public string CURP {
         get {
            if(atributos.ContainsKey("CURP"))
               return atributos["CURP"];
            throw new Exception("Nomina::CURP. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("CURP"))
               atributos["CURP"] = value;
            else
               atributos.Add("CURP", value);
         }
      }
      
      public string TipoRegimen {
         get {
            if(atributos.ContainsKey("TipoRegimen"))
               return atributos["TipoRegimen"];
            throw new Exception("Nomina::TipoRegimen. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("TipoRegimen"))
               atributos["TipoRegimen"] = value;
            else
               atributos.Add("TipoRegimen", value);
         }
      }
      
      public string NumSeguridadSocial {
         get {
            if(atributos.ContainsKey("NumSeguridadSocial"))
               return atributos["NumSeguridadSocial"];
            return string.Empty;
         }
         set {
            if(atributos.ContainsKey("NumSeguridadSocial"))
               atributos["NumSeguridadSocial"] = value;
            else
               atributos.Add("NumSeguridadSocial", value);
         }
      }
      
      public string FechaPagoString {
         get {
            if(atributos.ContainsKey("FechaPago"))
               return atributos["FechaPago"];
            throw new Exception("Nomina::FechaPago. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("FechaPago"))
               atributos["FechaPago"] = value;
            else
               atributos.Add("FechaPago", value);
         }
      }
      
      public DateTime FechaPagoDateTime {
         get {
            if(atributos.ContainsKey("FechaPago"))
               return Conversiones.FechaISO8601DateTime(atributos["FechaPago"]);
            throw new Exception("Nomina::FechaPago. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("FechaPago"))
               atributos["FechaPago"] = Conversiones.DateTimeFechaISO8601(value);
            else
               atributos.Add("FechaPago", Conversiones.DateTimeFechaISO8601(value));
         }
      }
      
      public string FechaInicialPagoString {
         get {
            if(atributos.ContainsKey("FechaInicialPago"))
               return atributos["FechaInicialPago"];
            throw new Exception("Nomina::FechaInicialPago. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("FechaInicialPago"))
               atributos["FechaInicialPago"] = value;
            else
               atributos.Add("FechaInicialPago", value);
         }
      }
      
      public DateTime FechaInicialPagoDateTime {
         get {
            if(atributos.ContainsKey("FechaInicialPago"))
               return Conversiones.FechaISO8601DateTime(atributos["FechaInicialPago"]);
            throw new Exception("Nomina::FechaInicialPago. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("FechaInicialPago"))
               atributos["FechaInicialPago"] = Conversiones.DateTimeFechaISO8601(value);
            else
               atributos.Add("FechaInicialPago", Conversiones.DateTimeFechaISO8601(value));
         }
      }
      
      public string FechaFinalPagoString {
         get {
            if(atributos.ContainsKey("FechaFinalPago"))
               return atributos["FechaFinalPago"];
            throw new Exception("Nomina::FechaFinalPago. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("FechaFinalPago"))
               atributos["FechaFinalPago"] = value;
            else
               atributos.Add("FechaFinalPago", value);
         }
      }
      
      public DateTime FechaFinalPagoDateTime {
         get {
            if(atributos.ContainsKey("FechaFinalPago"))
               return Conversiones.FechaISO8601DateTime(atributos["FechaFinalPago"]);
            throw new Exception("Nomina::FechaFinalPago. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("FechaFinalPago"))
               atributos["FechaFinalPago"] = Conversiones.DateTimeFechaISO8601(value);
            else
               atributos.Add("FechaFinalPago", Conversiones.DateTimeFechaISO8601(value));
         }
      }
      
      public double NumDiasPagados {
         get {
            if(atributos.ContainsKey("NumDiasPagados"))
               return Convert.ToDouble(atributos["NumDiasPagados"]);
            throw new Exception("Nomina::NumDiasPagados. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("NumDiasPagados"))
               atributos["NumDiasPagados"] = value.ToString();
            else
               atributos.Add("NumDiasPagados", value.ToString());
         }
      }
      
      public string Departamento {
         get {
            if(atributos.ContainsKey("Departamento"))
               return atributos["Departamento"];
            return string.Empty;
         }
         set {
            if(atributos.ContainsKey("Departamento"))
               atributos["Departamento"] = value;
            else
               atributos.Add("Departamento", value);
         }
      }
      
      public string CLABE {
         get {
            if(atributos.ContainsKey("CLABE"))
               return atributos["CLABE"];
            return string.Empty;
         }
         set {
            if(atributos.ContainsKey("CLABE"))
               atributos["CLABE"] = value;
            else
               atributos.Add("CLABE", value);
         }
      }
      
      public int Banco {
         get {
            if(atributos.ContainsKey("Banco"))
               return Convert.ToInt32(atributos["Banco"]);
            return -1;
         }
         set {
            if(atributos.ContainsKey("Banco"))
               atributos["Banco"] = value.ToString();
            else
               atributos.Add("Banco", value.ToString());
         }
      }
      
      public string FechaInicioRelLaboralString {
         get {
            if(atributos.ContainsKey("FechaInicioRelLaboral"))
               return atributos["FechaInicioRelLaboral"];
            return string.Empty;
         }
         set {
            if(atributos.ContainsKey("FechaInicioRelLaboral"))
               atributos["FechaInicioRelLaboral"] = value;
            else
               atributos.Add("FechaInicioRelLaboral", value);
         }
      }
      
      public DateTime FechaInicioRelLaboralDateTime {
         get {
            if(atributos.ContainsKey("FechaInicioRelLaboral"))
               return Conversiones.FechaISO8601DateTime(atributos["FechaInicioRelLaboral"]);
            return DateTime.MinValue;
         }
         set {
            if(atributos.ContainsKey("FechaInicioRelLaboral"))
               atributos["FechaInicioRelLaboral"] = Conversiones.DateTimeFechaISO8601(value);
            else
               atributos.Add("FechaInicioRelLaboral", Conversiones.DateTimeFechaISO8601(value));
         }
      }
      
      public int Antiguedad {
         get {
            if(atributos.ContainsKey("Antiguedad"))
               return Convert.ToInt32(atributos["Antiguedad"]);
            return -1;
         }
         set {
            if(atributos.ContainsKey("Antiguedad"))
               atributos["Antiguedad"] = value.ToString();
            else
               atributos.Add("Antiguedad", value.ToString());
         }
      }
      
      public string Puesto {
         get {
            if(atributos.ContainsKey("Puesto"))
               return atributos["Puesto"];
            return string.Empty;
         }
         set {
            if(atributos.ContainsKey("Puesto"))
               atributos["Puesto"] = value;
            else
               atributos.Add("Puesto", value);
         }
      }
      
      public string TipoContrato {
         get {
            if(atributos.ContainsKey("TipoContrato"))
               return atributos["TipoContrato"];
            return string.Empty;
         }
         set {
            if(atributos.ContainsKey("TipoContrato"))
               atributos["TipoContrato"] = value;
            else
               atributos.Add("TipoContrato", value);
         }
      }
      
      public string TipoJornada {
         get {
            if(atributos.ContainsKey("TipoJornada"))
               return atributos["TipoJornada"];
            return string.Empty;
         }
         set {
            if(atributos.ContainsKey("TipoJornada"))
               atributos["TipoJornada"] = value;
            else
               atributos.Add("TipoJornada", value);
         }
      }
      
      public string PeriodicidadPago {
         get {
            if(atributos.ContainsKey("PeriodicidadPago"))
               return atributos["PeriodicidadPago"];
            throw new Exception("Nomina:PeriodicidadPago. No puede estar vacio");
         }
         set {
            if(atributos.ContainsKey("PeriodicidadPago"))
               atributos["PeriodicidadPago"] = value;
            else
               atributos.Add("PeriodicidadPago", value);
         }
      }
      
      public string SalarioBasoCotApor {
         get {
            if(atributos.ContainsKey("SalarioBasoCotApor"))
               return atributos["SalarioBasoCotApor"];
            return string.Empty;
         }
         set {
            if(atributos.ContainsKey("SalarioBasoCotApor"))
               atributos["SalarioBasoCotApor"] = value;
            else
               atributos.Add("SalarioBasoCotApor", value);
         }
      }
      
      public int RiesgoPuesto {
         get {
            if(atributos.ContainsKey("RiesgoPuesto"))
               return Convert.ToInt32(atributos["RiesgoPuesto"]);
            return -1;
         }
         set {
            if(atributos.ContainsKey("RiesgoPuesto"))
               atributos["RiesgoPuesto"] = value.ToString();
            else
               atributos.Add("RiesgoPuesto", value.ToString());
         }
      }
      
      public string SalarioDiarioIntegrado {
         get {
            if(atributos.ContainsKey("SalarioDiarioIntegrado"))
               return atributos["SalarioDiarioIntegrado"];
            return string.Empty;
         }
         set {
            if(atributos.ContainsKey("SalarioDiarioIntegrado"))
               atributos["SalarioDiarioIntegrado"] = value;
            else
               atributos.Add("SalarioDiarioIntegrado", value);
         }
      }
      
      public Percepciones Percepciones {
         get { return percepciones; }
         set { percepciones = value; }
      }
      
      public Deducciones Deducciones {
         get { return deducciones; }
         set { deducciones = value; }
      }
      
      public Incapacidades Incapacidades {
         get { return incapacidades; }
         set { incapacidades = value; }
      }
      
      public HorasExtras HorasExtras {
         get { return horasExtras; }
         set { horasExtras = value; }
      }
   }
   
   #endregion
}
