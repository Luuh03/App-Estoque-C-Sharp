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
    public partial class frmProdutos : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();
        private MySqlCommand objCmd = new MySqlCommand();
        private MySqlDataReader objDados;
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtQuantidade.Text = "";
            txtPreco.Text = "";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text != "")
            {
                if(txtQuantidade.Text != "")
                {
                    if(txtPreco.Text != "")
                    {
                        try
                        {
                            string strSql = "Select * from tblprodutos Where prodid = " + txtId.Text;
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = strSql;
                            objDados = objCmd.ExecuteReader();
                            if (objDados.HasRows)
                            {
                                MessageBox.Show("Id existente!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtId.Focus();
                            }
                            else
                            {
                                if (!objDados.IsClosed) { objDados.Close(); }
                                strSql = "Insert into tblprodutos (prodid, prodnome, prodqtde, prodpreco) values (";
                                strSql += txtId.Text + ",";
                                strSql += "'" + txtNome.Text + "',";
                                strSql += "'" + txtQuantidade.Text + "',";
                                strSql += "'" + txtPreco.Text + "')";

                                objCmd.Connection = objCnx;
                                objCmd.CommandText = strSql;
                                objCmd.ExecuteNonQuery();
                                MessageBox.Show("Produto incluído com sucesso!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (!objDados.IsClosed) { objDados.Close(); }
                        }
                        catch (Exception Erro)
                        {
                            MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preço inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Quantidade inválida!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nome inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            try
            {
                objCnx.ConnectionString = "Server=localhost;" +
                                          "Database=bdEstoque;" +
                                          "User=root;" +
                                          "Pwd=8ASA76f675Afs5d67fs545";
                objCnx.Open();
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                try
                {
                    string strSql = "Select * from tblprodutos Where prodid = " + txtId.Text;
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSql;
                    objDados = objCmd.ExecuteReader();
                    if (!objDados.HasRows)
                    {
                        MessageBox.Show("Id inexistente!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtId.Focus();
                    }
                    else
                    {
                        objDados.Read();
                        txtNome.Text = objDados["prodnome"].ToString();
                        txtQuantidade.Text = objDados["prodqtde"].ToString();
                        txtPreco.Text = objDados["prodpreco"].ToString();
                    }
                    if (!objDados.IsClosed) { objDados.Close(); }
                }
                catch (Exception Erro)
                {
                    MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Id inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                try
                {
                    string strSql = "Select * from tblprodutos Where prodid = " + txtId.Text;
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSql;
                    objDados = objCmd.ExecuteReader();
                    if (!objDados.HasRows)
                    {
                        MessageBox.Show("Id inexistente!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtId.Focus();
                    }
                    else
                    {
                        if (!objDados.IsClosed) { objDados.Close(); }

                        if (MessageBox.Show("Deseja excluir ?", "ADO.NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = strSql;
                            objCmd.ExecuteNonQuery();
                            MessageBox.Show("Produto eliminado com sucesso!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtId.Text = "";
                            txtNome.Text = "";
                            txtQuantidade.Text = "";
                            txtPreco.Text = "";
                        }
                    }
                    if (!objDados.IsClosed) { objDados.Close(); }
                }
                catch (Exception Erro)
                {
                    MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Id inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                try
                {
                    string strSql = "Select * from tblprodutos Where prodid = " + txtId.Text;
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSql;
                    objDados = objCmd.ExecuteReader();
                    if (!objDados.HasRows)
                    {
                        MessageBox.Show("Id inexistente!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtId.Focus();
                    }
                    else
                    {
                        if (!objDados.IsClosed) { objDados.Close(); }
                        strSql = "Update tblprodutos set ";
                        strSql += "prodnome = '" + txtNome.Text + "',";
                        strSql += "prodqtde = '" + txtQuantidade.Text + "',";
                        strSql += "prodpreco = '" + txtPreco.Text + "' ";
                        strSql += "Where prodid = " + txtId.Text;

                        objCmd.Connection = objCnx;
                        objCmd.CommandText = strSql;
                        objCmd.ExecuteNonQuery();
                        MessageBox.Show("Alteração realizada com sucesso!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!objDados.IsClosed) { objDados.Close(); }
                }
                catch (Exception Erro)
                {
                    MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Id inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
