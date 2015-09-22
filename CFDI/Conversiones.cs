/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 19/09/2015
 * Hora: 11:49 p.m.
 * 
 */
using System;

namespace IsaRoGaMX
{
   public static class Conversiones
   {
      /// <summary>
      /// Convierte una estructura DateTime a una cadena en formato ISO-8601
      /// </summary>
      /// <param name="fecha">DateTime a convertir</param>
      public static string DateTimeFechaISO8601(DateTime fecha) {
         return fecha.ToString("yyyy-MM-ddTHH:mm:ss");
      }
      
      /// <summary>
      /// Convierte una cadena de fecha en formato ISO-8601 en un DateTime
      /// </summary>
      /// <param name="fecha">Cadena de fecha a convertir</param>
      public static DateTime FechaISO8601DateTime(string fecha) {
         return DateTime.Parse(fecha,  null, System.Globalization.DateTimeStyles.RoundtripKind);
      }
      
      /// <summary>
      /// Convierte un valor doble en una cadena con seis digitos decimales
      /// </summary>
      /// <param name="importe">Importe a convertir</param>
      /// <returns></returns>
      public static string Importe(double importe) {
         return importe.ToString("#.000000");
      }
   }
}
