using Business.Business;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Agenda.UI.Forms
{
    public partial class Pesquisar : Form
    {
        public Pesquisar()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "")
            {
                ContatoBusiness contatoBusiness = new ContatoBusiness();
                ContatoDTO contatoDTO = contatoBusiness.PesquisarContato(txtNome.Text);

                if (contatoDTO != null)
                {
                    txtEndereco.Text = contatoDTO.Endereco;
                    txtTelefone.Text = contatoDTO.Telefone;
                    txtEmail.Text = contatoDTO.Email;
                    txtCPF.Text = contatoDTO.CPF;
                    MessageBox.Show("Contato encontrado!!");
                }
                else
                {
                    MessageBox.Show("Nenhum contato foi encontrado");
                }
            }
        }

        
    }
    }

