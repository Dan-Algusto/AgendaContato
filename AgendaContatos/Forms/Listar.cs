
using Business.Business;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Agenda;

namespace Agenda.UI.Forms
{
    public partial class Listar : Form
    {
        public Listar()
        {
            InitializeComponent();
            dataGridView1.DataSource = ListarContatos();
        }

        public List<ContatoDTO> ListarContatos()
        {
            ContatoBusiness contatoBusiness = new ContatoBusiness();
            return contatoBusiness.ObterTodosContatos();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

            {
                if (MessageBox.Show("Deseja realmente excluir esse funcionario?", "Cuidado", //cancelar
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    MessageBox.Show("Operacao Cancelada!");
                }

                else //excluir linha da tabela, chamar a business
                {
                     int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value); //obter id selecionado na tabela
                    // chamar o business
                    ContatoBusiness contatoBusiness = new ContatoBusiness();
                    contatoBusiness.RemoverContato(Id);
                    MessageBox.Show("Usuário deletado com sucesso!");
                    dataGridView1.DataSource = ListarContatos();
                }
                //atualizar lista após mensagem para usuario que foi deletado
            }


        }
    }
}

