using CapaNegocios;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenarioWForms
{
    public partial class PersonasForms : Form
    {
        public PersonasForms()
        {
            InitializeComponent();
            NegPersona cp = new();
            ICollection<Persona> pers = cp.GetPersonas();
            dataGridView1.DataSource = pers;
        }

        private void PersonasForms_Load(object sender, EventArgs e)
        {
         
        }
    }
}
