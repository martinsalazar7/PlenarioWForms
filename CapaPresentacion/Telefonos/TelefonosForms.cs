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

namespace CapaPresentacion.Telefonos
{
    public partial class TelefonosForms : Form
    {
        private Persona _persona;
        private bool _nuevoTel;
        private CapaNegocios.NegTelefonos proc;
       
        public TelefonosForms(Persona persona)
        {
            InitializeComponent();
            _persona = persona;
            proc = new CapaNegocios.NegTelefonos();
        }
        private void refreshdgv()
        {
            _persona.Telefonos = proc.GetTelefonos(_persona.Id);
            _nuevoTel = false;
            dgvTelefonos.DataSource = _persona.Telefonos.ToList();
            dgvTelefonos.Columns["Persona"].Visible = false;
            dgvTelefonos.Columns["Id"].Visible = false;
            groupBox1.Enabled = false;
            dgvTelefonos.Enabled = true;

        }
        private void limpiar()
        {
            txtName.Text = String.Empty;
        }
        private void TelefonosForms_Load(object sender, EventArgs e)
        {
            lblNombre.Text = _persona.Nombre;
            refreshdgv();
        }

        private void dgvTelefonos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTelefonos.CurrentRow.Index >= 0 && _persona.Telefonos.Count > 0)
            {
                txtName.Text= _persona.Telefonos[dgvTelefonos.CurrentRow.Index].Numero;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _nuevoTel = true;
            groupBox1.Enabled = true;
            limpiar();
        }
        private bool Valido()
        {
           if(string.IsNullOrEmpty(txtName.Text))
            {
                return false;
            }
            return true;
        }
        
        //.Telefonos[dgvTelefonos.CurrentRow.Index].Id
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            error.Clear();
            if (_nuevoTel)
            {
                if (Valido())
                {
                    MessageBox.Show(proc.AgregarTel(txtName.Text,_persona.Id));
                    refreshdgv();
                    
                }

            }
            else
            {
                if (Valido())
                {
                    MessageBox.Show(proc.ModificarTel(txtName.Text, _persona.Telefonos[dgvTelefonos.CurrentRow.Index].Id,_persona.Id));

                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _nuevoTel = true;
            groupBox1.Enabled = true;
            limpiar();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _nuevoTel = false;
            groupBox1.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTelefonos.CurrentRow.Index >= 0 && _persona.Telefonos.Count > 0)
            {
                if (MessageBox.Show(null, "Esta Seguro que desea borrar el numero:" + _persona.Telefonos[dgvTelefonos.CurrentRow.Index].Numero, "Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    proc.EliminarTel(_persona.Telefonos[dgvTelefonos.CurrentRow.Index].Id);
                    refreshdgv();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            refreshdgv();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
