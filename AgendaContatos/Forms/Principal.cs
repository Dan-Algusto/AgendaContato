using Agenda.UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.DTOs;
using Business.Business;

namespace Agenda
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();


        }
        private void btnListarContatos_Click(object sender, EventArgs e)
        {
            Listar formListar = new Listar();
            formListar.Show();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar formPsquisar = new Pesquisar();
            formPsquisar.Show();
        }



       

        public void button4_Click_1(object sender, EventArgs e)
        {
            ContatoDTO contato = new ContatoDTO();
            contato.Nome = txtNome.Text;
            contato.Endereco = txtEndereco.Text;
            contato.Telefone = txtTelefone.Text;
            contato.CPF = txtCPF.Text;
            contato.Email = txtEmail.Text;

            

            ContatoBusiness contatoBusiness = new ContatoBusiness();
            contatoBusiness.CriarContato(contato);

            



        }
    }
}

