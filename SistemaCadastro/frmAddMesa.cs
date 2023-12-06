using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class frmAddMesa : Form
    {
        public frmAddMesa()
        {
            InitializeComponent();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Sistema formSistema = new Sistema();
            formSistema.Show();
            this.Close();
        
        }

        private void BtnConfirmaMesa_Click(object sender, EventArgs e)
        {
            // Confirma Cadastro
           
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.insereMesa(txtAddMesa.Text);
                if (retorno == false)
                    MessageBox.Show(con.mensagem);
                else
                    MessageBox.Show("Mesa adicionada com sucesso");
                txtAddMesa.Clear();
                txtAddMesa.Focus();
        }
    }
}
