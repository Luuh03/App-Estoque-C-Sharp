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
    public partial class frmUsuarios : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();
        private MySqlCommand objCmd = new MySqlCommand();
        private MySqlDataReader objDados;
        public frmUsuarios()
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
            txtSenha.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                if(txtNome.Text != "")
                {
                    if(txtSenha.Text != "")
                    {
                        try
                        {
                            string strSql = "Select * from tblusuarios Where pesid = " + txtId.Text;
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = strSql;
                            objDados = objCmd.ExecuteReader();
                            if (objDados.HasRows)
                            {
                                MessageBox.Show("Já existe um usuário com este ID!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtId.Focus();
                            }
                            else
                            {
                                if (!objDados.IsClosed) { objDados.Close(); }
                                strSql = "Insert into tblusuarios (pesid, usrnome, usrsenha) values (";
                                strSql += txtId.Text + ",";
                                strSql += "'" + txtNome.Text + "',";
                                strSql += "'" + txtSenha.Text + "')";

                                objCmd.Connection = objCnx;
                                objCmd.CommandText = strSql;
                                objCmd.ExecuteNonQuery();
                                MessageBox.Show("Usuário criado sucesso!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Senha inválida!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Nome inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Id inválido!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                try
                {
                    string strSql = "Select * from tblusuarios Where pesid = " + txtId.Text;
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
                        txtNome.Text = objDados["usrnome"].ToString();
                        txtSenha.Text = objDados["usrsenha"].ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                try
                {
                    string strSql = "Select * from tblusuarios Where pesid = " + txtId.Text;
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
                            MessageBox.Show("Usuário eliminado com sucesso!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtId.Text = "";
                            txtNome.Text = "";
                            txtSenha.Text = "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                try
                {
                    string strSql = "Select * from tblusuarios Where pesid = " + txtId.Text;
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
                        strSql = "Update tblusuarios set ";
                        strSql += "usrnome = '" + txtNome.Text + "',";
                        strSql += "usrsenha = '" + txtSenha.Text + "' ";
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
