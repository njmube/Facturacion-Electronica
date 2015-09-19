/*
 * Creado en SharpDevelop
 * Autor: IsaRoGaMX
 * Fecha: 16/09/2015
 * Hora: 12:52 a.m.
 * 
 */
using System.Collections.Generic;
using System.Xml;

namespace IsaRoGaMX.CFDI
{
   public abstract class baseObject
   {
      internal protected Dictionary<string, string> atributos = new Dictionary<string, string>();
      
      public virtual XmlElement NodoXML(string prefijo, string namespaceURI, XmlDocument documento) {         
         // Elemento a retornar
         XmlElement elemento = (XmlElement)documento.CreateNode(XmlNodeType.Element, prefijo, GetType().Name, namespaceURI);
         
         // Se agregan los atributos
         foreach(KeyValuePair<string, string> atributo in atributos) {
            /*double aux;
            if(double.TryParse(atributo.Value, out aux))
               elemento.SetAttribute(atributo.Key, aux.ToString(Comprobante.formatoDecimales.PadRight(Comprobante.formatoDecimales.Length + Comprobante.decimales, '0')));
            else*/
               elemento.SetAttribute(atributo.Key, atributo.Value);
         }
         
         // Se retorna el elemento
         return elemento;
      }
   }
}
