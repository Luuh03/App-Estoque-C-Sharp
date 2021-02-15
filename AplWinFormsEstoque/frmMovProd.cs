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
    public partial class frmMovProd : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();
        private MySqlCommand objCmd = new MySqlCommand();
        private MySqlDataReader objDados;
        public frmMovProd()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtMovId.Text = "";
            txtProdId.Text = "";
            dtpMov.Text = "";
            txtQuantidade.Text = "";
            txtTipo.Text = "";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txtMovId.Text != "")
            {
                if(txtProdId.Text != "")
                {
                    if(txtTipo.Text != "")
                    {
                        if (txtQuantidade.Text != "")
                        {
                            try
                            {
                                string strSql = "Select * from tblmomvprodutos Where mvpid = " + txtMovId.Text;
                                objCmd.Connection = objCnx;
                                objCmd.CommandText = strSql;
                                objDados = objCmd.ExecuteReader();
                                if (objDados.HasRows)
                                {
                                    MessageBox.Show("Id existente!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtMovId.Focus();
                                }
                                else
                                {
                                    if (!objDados.IsClosed) { objDados.Close(); }
                                    strSql = "Insert into tblmomvprodutos (mvpid, prodid, mvpdata, mvptipomov, mvpqtde) values (";
                                    strSql += txtMovId.Text + ",";
                                    strSql += "'" + txtProdId.Text + "',";
                                    strSql += "'" + dtpMov.Value.Date.ToString("yyyy-MM-dd") + "',";
                                    strSql += "'" + txtTipo.Text + "',";
                                    strSql += "'" + txtQuantidade.Text + "')";

                                    objCmd.Connection = objCnx;
                                    objCmd.CommandText = strSql;
                                    objCmd.ExecuteNonQuery();
                                    MessageBox.Show("Movimentação de produto registrada com sucesso!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("Quantidade inválida!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tipo inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Id do produto inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Id da movimentação inválida!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmMovProd_Load(object sender, EventArgs e)
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
            if (txtMovId.Text != "")
            {
                try
                {
                    string strSql = "Select * from tblmomvprodutos Where mvpid = " + txtMovId.Text;
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSql;
                    objDados = objCmd.ExecuteReader();
                    if (!objDados.HasRows)
                    {
                        MessageBox.Show("Id inexistente!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMovId.Focus();
                    }
                    else
                    {
                        objDados.Read();
                        txtProdId.Text = objDados["prodid"].ToString();
                        dtpMov.Text = objDados["mvpdata"].ToString();
                        txtTipo.Text = objDados["mvptipomov"].ToString();
                        txtQuantidade.Text = objDados["mvpqtde"].ToString();
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
            if (txtMovId.Text != "")
            {
                try
                {
                    string strSql = "Select * from tblmomvprodutos Where mvpid = " + txtMovId.Text;
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSql;
                    objDados = objCmd.ExecuteReader();
                    if (!objDados.HasRows)
                    {
                        MessageBox.Show("Id inexistente!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMovId.Focus();
                    }
                    else
                    {
                        if (!objDados.IsClosed) { objDados.Close(); }

                        if (MessageBox.Show("Deseja excluir ?", "ADO.NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = strSql;
                            objCmd.ExecuteNonQuery();
                            MessageBox.Show("Registro Eliminado com sucesso!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtMovId.Text = "";
                            txtProdId.Text = "";
                            dtpMov.Text = "";
                            txtQuantidade.Text = "";
                            txtTipo.Text = "";
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
            if (txtMovId.Text != "")
            {
                try
                {
                    string strSql = "Select * from tblmomvprodutos Where mvpid = " + txtMovId.Text;
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSql;
                    objDados = objCmd.ExecuteReader();
                    if (!objDados.HasRows)
                    {
                        MessageBox.Show("Id inexistente!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMovId.Focus();
                    }
                    else
                    {
                        if (!objDados.IsClosed) { objDados.Close(); }
                        strSql = "Update tblmomvprodutos set ";
                        strSql += "prodid = '" + txtProdId.Text + "',";
                        strSql += "mvpdata = '" + dtpMov.Value.Date.ToString("yyyy-MM-dd") + "',";
                        strSql += "mvptipomov = '" + txtTipo.Text + "',";
                        strSql += "mvpqtde = '" + txtQuantidade.Text + "' ";
                        strSql += "Where mvpid = " + txtMovId.Text;

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
