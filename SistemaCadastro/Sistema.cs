using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {
        int idAlterar;

        public Sistema()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
          //marcador.Height = btnCadastra.Height;
          //marcador.Top = btnCadastra.Top;
          //tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        

        private void btnBusca_Click(object sender, EventArgs e)
        {
           //marcador.Height = btnBusca.Height;
           //marcador.Top = btnBusca.Top;
           //tabControl1.SelectedTab = tabControl1.TabPages[1];
        }







        private void Sistema_Load(object sender, EventArgs e)
        {
            listaCBMesas();
            lista_gridReservas();
        }


        void lista_gridReservas()
        {
            ConectaBanco con = new ConectaBanco();
            dgReserva.DataSource = con.listaReservas();
        }

        public void listaCBMesas()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = con.listaMesas();
            cbMesaReserva.DataSource = tabelaDados;
            cbMesaReserva.DisplayMember = "tipo";
            cbMesaReserva.ValueMember = "idMesa";
            cbMesaAlterar.DataSource = tabelaDados;
            cbMesaAlterar.DisplayMember = "tipo";
            cbMesaAlterar.ValueMember = "idMesa";
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            
        }

         private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            //alterado2
            ConectaBanco con = new ConectaBanco();
            Reserva novaReserva = new Reserva();
            novaReserva.Nome = txtNomeAlterar.Text;
            novaReserva.Sobrenome = txtSobrenomeAlterar.Text;
            novaReserva.QuantidadePessoas = Convert.ToInt32(txtPessoasAlterar.Text);
            novaReserva.IdMesa = Convert.ToInt32(cbMesaAlterar.SelectedValue.ToString());
            bool retorno = con.alteraReserva(novaReserva, idAlterar);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else MessageBox.Show("Alteração Realizada com sucesso!");
           
            lista_gridReservas();


        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {
            frmAddMesa formMesa = new frmAddMesa();
            this.Hide();
            formMesa.ShowDialog();
            this.Close();
        }

        void limpaCampos()
        {
            txtNomeReserva.Clear();
            cbMesaReserva.Text = "";
            txtPessoasReserva.Clear();
            txtSobrenomeReserva.Clear();
            txtNomeReserva.Focus();
        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            //alterado2
            ConectaBanco con = new ConectaBanco();
            Reserva novaReserva = new Reserva();
            novaReserva.Nome = txtNomeReserva.Text;
            novaReserva.Sobrenome = txtSobrenomeReserva.Text;
            novaReserva.QuantidadePessoas = Convert.ToInt32(txtPessoasReserva.Text);
            novaReserva.IdMesa = Convert.ToInt32(cbMesaReserva.SelectedValue.ToString());
            bool retorno = con.insereReserva(novaReserva);
            if(retorno == false)
                MessageBox.Show(con.mensagem);

            limpaCampos();
            lista_gridReservas();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtintegrantes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSobrenomeReserva_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNomeReserva_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgBandas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            (dgReserva.DataSource as DataTable).DefaultView.RowFilter =
             string.Format("nome like '{0}%'", textBox3.Text);
        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {

            int linha = dgReserva.CurrentRow.Index;
            int id = Convert.ToInt32(
                    dgReserva.Rows[linha].Cells["idReserva"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?",
                "Remove Reserva", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deletaReserva(id);
                if (retorno == true)
                {
                    MessageBox.Show("Reserva excluida com sucesso!");
                    lista_gridReservas();
                }// fim if retorno true
                else
                    MessageBox.Show(con.mensagem);
            }// fim if Ok Cancela
            else
                MessageBox.Show("Exclusão cancelada");
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            
                int linha = dgReserva.CurrentRow.Index;// pega a linha selecionada
                idAlterar = Convert.ToInt32(
                  dgReserva.Rows[linha].Cells["idreserva"].Value.ToString());
                txtNomeAlterar.Text =
                     dgReserva.Rows[linha].Cells["nome"].Value.ToString();
                txtSobrenomeAlterar.Text =
                    dgReserva.Rows[linha].Cells["sobrenome"].Value.ToString();
                txtPessoasAlterar.Text =
                    dgReserva.Rows[linha].Cells["quantidadePessoas"].Value.ToString();
                cbMesaAlterar.Text =
                    dgReserva.Rows[linha].Cells["tipo"].Value.ToString();
                tabControl1.SelectedTab = tabAlterar;// muda aba
            

        }

        private void tabCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
