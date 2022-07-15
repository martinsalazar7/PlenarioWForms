using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NegPersona
    {
        public List<Persona> GetPersonas(string? filtro)
        {
            DatosPersonas dt = new();
            return dt.Obtenerpersonas(filtro).ToList();
        }
        public string AgregarPersona(string nombre, DateTime fechaNacimiento, decimal creditoMaximo)
        {
            Persona persona = new()
            {
                Nombre = nombre,
                FechaNacimiento = fechaNacimiento,
                CreditoMaximo = creditoMaximo
            };
            DatosPersonas dt = new ();
            return dt.AgregarPersona(persona);
        }
        public string ModificarPersona( string nombre, DateTime fechaNacimiento, decimal creditoMaximo, int id)
        {
            Persona persona = new()
            {
                Id=id,
                Nombre = nombre,
                FechaNacimiento = fechaNacimiento,
                CreditoMaximo = creditoMaximo
            };
            DatosPersonas dt = new();
            return dt.ModificarPersona(persona);
        }
        public string EliminarPersona(int id)
        {
            DatosPersonas dt = new();
            return dt.EliminarPersona(id);

        }

    }
}
