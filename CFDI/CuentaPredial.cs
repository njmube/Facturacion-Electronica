/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 16/09/2015
 * Hora: 01:45 a.m.
 * 
 */
using System;

namespace IsaRoGaMX.CFDI
{
   public class CuentaPredial : baseObject
   {
      public CuentaPredial(string numero)
         : base() {
         atributos.Add("numero", numero);
      }
      
      public virtual string Numero{
         get { return atributos["numero"]; }
      }
   }
}
