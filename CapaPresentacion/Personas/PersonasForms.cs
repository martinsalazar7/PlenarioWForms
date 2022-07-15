using CapaNegocios;
using Entidades;

namespace CapaPresentacion
{
    public partial class PersonasForms : Form
    {
        private List<Persona> _personas;
        private bool _nuevaPersona;
        NegPersona proc;
        public PersonasForms()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            proc = new NegPersona();
            refreshdgv();
        }

        private void refreshdgv()
        {

            _nuevaPersona = false;
            _personas = proc.GetPersonas(txtBuscar.Text);
            dgvPersonas.DataSource = _personas;
          //  dgvPersonas.Columns["Telefonos"].Visible = false;
           // dgvPersonas.Columns["Id"].Visible = false;
            groupBox1.Enabled = false;
            gbGeneral.Enabled = true;

        }
        private void dgvPersonas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPersonas.CurrentRow.Index >= 0 && _personas.Count > 0)
            {
                txtName.Text = _personas[dgvPersonas.CurrentRow.Index].Nombre;
                txtCredMax.Text = _personas[dgvPersonas.CurrentRow.Index].CreditoMaximo.ToString();
                dpFechaNac.Value = _personas[dgvPersonas.CurrentRow.Index].FechaNacimiento;
            }
        }

        private void limpiar()
        {
            txtName.Text = String.Empty;
            txtCredMax.Text = String.Empty;
            dpFechaNac.Value = DateTime.Now;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _nuevaPersona = true;
            groupBox1.Enabled = true;
            gbGeneral.Enabled = false;
            limpiar();
        }
        private bool Valido()
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                error.SetError(txtName, "Debe Ingresar un Nombre");
                return false;
            }
            if (string.IsNullOrEmpty(txtCredMax.Text))
            {
                error.SetError(txtCredMax, "Debe Ingresar Credito Maximo");
                return false;

            }
            if (dpFechaNac.Value.Date == DateTime.Now.Date)
            {
                error.SetError(dpFechaNac, "Debe Ingresar una fecha de nacimiento");
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            error.Clear();
            if (_nuevaPersona)
            {
                if (Valido())
                {
                    string res = proc.AgregarPersona(txtName.Text, dpFechaNac.Value, decimal.Parse(txtCredMax.Text));
                    if (res.All(char.IsDigit))
                    {
                        MessageBox.Show("Persona guardada con exito");
                        refreshdgv();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }

            }
            else
            {
                if (Valido())
                {
                    string res = proc.ModificarPersona(txtName.Text, dpFechaNac.Value, decimal.Parse(txtCredMax.Text), _personas[dgvPersonas.CurrentRow.Index].Id);
                    if (res.All(char.IsDigit))
                    {
                        MessageBox.Show("Persona modificado con exito");
                        refreshdgv();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }

                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _nuevaPersona = false;
            groupBox1.Enabled = true;
            gbGeneral.Enabled = false;
            dgvPersonas.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            refreshdgv();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.CurrentRow.Index >= 0 && _personas.Count > 0)
            {
                if (MessageBox.Show(null, "Esta Seguro que desea borrar a:" + _personas[dgvPersonas.CurrentRow.Index].Nombre, "Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    proc.EliminarPersona(_personas[dgvPersonas.CurrentRow.Index].Id);
                    refreshdgv();
                }
            }
        }

        private void lblLimpiar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtBuscar.Text= string.Empty;
            refreshdgv();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            refreshdgv();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            Telefonos.TelefonosForms frmTel = new Telefonos.TelefonosForms(_personas[dgvPersonas.CurrentRow.Index]);
            frmTel.ShowDialog();
            refreshdgv();
        }

        private void txtCredMax_Leave(object sender, EventArgs e)
        {
            error.Clear();
            try
            {
                decimal.Parse(txtCredMax.Text);

            }
            catch (Exception)
            {
                error.SetError(txtCredMax, "Error de formato");
            }
         }

       
    }
}