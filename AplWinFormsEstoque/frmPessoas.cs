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
    public partial class frmPessoas : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();
        private MySqlCommand objCmd = new MySqlCommand();
        private MySqlDataReader objDados;
        public frmPessoas()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtFixo.Text = "";
            txtCelular.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtNome.Text != "")
            {
                if(txtEmail.Text != "")
                {
                    if(txtFixo.Text != "")
                    {
                        if(txtCelular.Text != "")
                        {
                            try
                            {
                                string strSql = "Select * from tblpessoas Where pesid = " + txtId.Text;
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
                                    strSql = "Insert into tblpessoas (pesid, pesnome, pesemail, pestelefonefixo, pestelefonecelular) values (";
                                    strSql += txtId.Text + ",";
                                    strSql += "'" + txtNome.Text + "',";
                                    strSql += "'" + txtEmail.Text + "',";
                                    strSql += "'" + txtFixo.Text + "',";
                                    strSql += "'" + txtCelular.Text + "')";

                                    objCmd.Connection = objCnx;
                                    objCmd.CommandText = strSql;
                                    objCmd.ExecuteNonQuery();
                                    MessageBox.Show("Registro incluído com sucesso!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("Número de celular inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Telefone fixo inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("E-mail inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nome inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmPessoas_Load(object sender, EventArgs e)
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
                    string strSql = "Select * from tblpessoas Where pesid = " + txtId.Text;
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
                        txtNome.Text = objDados["pesnome"].ToString();
                        txtEmail.Text = objDados["pesemail"].ToString();
                        txtFixo.Text = objDados["pestelefonefixo"].ToString();
                        txtCelular.Text = objDados["pestelefonecelular"].ToString();
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
                    string strSql = "Select * from tblpessoas Where pesid = " + txtId.Text;
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
                            MessageBox.Show("Registro Eliminado com sucesso!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtId.Text = "";
                            txtNome.Text = "";
                            txtEmail.Text = "";
                            txtFixo.Text = "";
                            txtCelular.Text = "";
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
                    string strSql = "Select * from tblpessoas Where pesid = " + txtId.Text;
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
                        strSql = "Update tblpessoas set ";
                        strSql += "pesnome = '" + txtNome.Text + "',";
                        strSql += "pesemail = '" + txtEmail.Text + "',";
                        strSql += "pestelefonefixo = '" + txtFixo.Text + "',";
                        strSql += "pestelefonecelular = '" + txtCelular.Text + "' ";
                        strSql += "Where pesid = " + txtId.Text;

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
