using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosPersonas
    {
        public DataContext _context { get; }

        public DatosPersonas()
        {
            _context = new DataContext();
        }

        public ICollection<Persona> Obtenerpersonas(string? filtro)
        {
            if (string.IsNullOrEmpty(filtro))
            {
                return _context.Personas
                    .Include(t => t.Telefonos)
                    .ToList();
            }
            else
            {
                return _context.Personas
                    .Include(t => t.Telefonos)
                    .Where(p=>p.Nombre.Contains(filtro))
                    .ToList();

            }
        }
        public string AgregarPersona(Persona persona)
        {
            try
            {
                _context.Personas.Add(persona).ToString();
                return _context.SaveChanges().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }
        public string ModificarPersona(Persona persona)
        {
            try
            {
                _context.Personas.Update(persona).ToString();
                return _context.SaveChanges().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string EliminarPersona(int id)
        {
            try
            {
                Persona persona = _context.Personas
                    .Include(t => t.Telefonos)
                    .Where(p=>p.Id==id)
                    .FirstOrDefault();

                _context.Personas.Remove(persona).ToString();
                return _context.SaveChanges().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}