using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AplWinFormsEstoque
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void sairDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            tssMensagem.Text = "Bem vindo ao app de Estoque!";
        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPessoas objPessoas = new frmPessoas();
            objPessoas.ShowDialog();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios objUsuarios = new frmUsuarios();
            objUsuarios.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutos objProdutos = new frmProdutos();
            objProdutos.ShowDialog();
        }

        private void movimentaçãoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovProd objMovProd = new frmMovProd();
            objMovProd.ShowDialog();
        }

        private void DataHora_Tick(object sender, EventArgs e)
        {
            tssData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tssHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processo.StartInfo.FileName = "Calc.Exe";
            processo.Start();
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e){
            processo.StartInfo.FileName = @"C:\Program Files\Microsoft Office\root\Office16\Excel.Exe";
            processo.Start();
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processo.StartInfo.FileName = @"C:\Program Files\Microsoft Office\root\Office16\WinWord.Exe";
            processo.Start();
        }
    }
}
