using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosTelefonos
    {
        public DataContext _context { get; }

        public DatosTelefonos()
        {
            _context = new DataContext();
        }

        public List<Telefono> ObtenerTelefonos(int id)
        {
            return _context.Telefonos.Where(p => p.Persona.Id == id).ToList();
        }
        public Telefono ObtenerTelefono(int id)
        {
            return _context.Telefonos
                .Where(t => t.Id == id)
                .FirstOrDefault();
        }
        public void AgregarTelefono(string tel, int id)
        {
            try
            {
                Telefono telef = new Telefono()
                {
                    Numero = tel,
                    Persona= _context.Personas.Find(id)
                };
                _context.Telefonos.Add(telef);
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        public void ModificarTelefono(Telefono tel)
        {
            try
            {
                _context.Telefonos.Update(tel);
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        public void EliminarTel(int id)
        {
            try
            {
                Telefono tel= _context.Telefonos
                    .Where(t => t.Id == id)
                    .FirstOrDefault();

                _context.Telefonos.Remove(tel).ToString();
                _context.SaveChanges().ToString();
            }
            catch (Exception ex)
            {
            }
        }
        public bool ValidarTelefono(string numero, int idPersona)
        {
            if (_context.Telefonos.
                Where(p => p.Persona.Id == idPersona && p.Numero == numero)
                .ToList().Count > 0)
            {
                return false;

            }
            else 
            { 
                return true; 
            }
        }




    }
}
