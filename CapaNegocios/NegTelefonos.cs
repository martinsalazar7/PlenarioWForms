using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NegTelefonos
    {
        public List<Telefono> GetTelefonos(int id)
        {
                  DatosTelefonos dt = new();
               return dt.ObtenerTelefonos(id);

        }
        public string AgregarTel(string Tel, int id)
        {
            DatosTelefonos dt = new();
            if (dt.ValidarTelefono(Tel, id))
            {
                dt.AgregarTelefono(Tel, id);
                return "Telefono Cargado con exito";
            }
            else
            {
                return "Ya se encuentra el telefono en la persona";

            }
        }
        public string ModificarTel(string telefono, int id, int idPersona)
        {
            Telefono tel = new()
            {
                Id = id,
                Numero = telefono
            };
            DatosTelefonos dt = new();
            if (dt.ValidarTelefono(telefono, idPersona))
            {
                dt.ModificarTelefono(tel);
                return "Telefono Modificado con exito";
            }
            else
            {
                return "Error de validacion: ya se encuentra el telefono";
            }
        }
        public void EliminarTel(int id)
        {
            DatosTelefonos dt = new();
            dt.EliminarTel(id);

        }
       
    }
}
