using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace DAL.Repositories
{
    public class ContatoRepository
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DBCloud"].ConnectionString;

        public List<ContatoDTO> ObterTodosContatos()
        {
            List<ContatoDTO> Contatos = new List<ContatoDTO>();

            try
            {
                //Abre a conexão com o banco
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Contatos", con);

                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Se tiver registros pra trazer, vai adicionando na lista de Contatos um novo objeto Contato
                    while (reader.Read())
                    {
                        Contatos.Add(new ContatoDTO()
                        {
                            Nome = reader["Nome"].ToString().Trim(),
                            Endereco = reader["Endereco"].ToString().Trim(),
                            Telefone = reader["Telefone"].ToString().Trim(),
                            Email = reader["Email"].ToString().Trim(),
                            CPF = reader["CPF"].ToString().Trim(),
                            Id = Convert.ToInt32(reader["Id"])
                        });
                    }

                    reader.Close();
                    con.Close();

                    return Contatos;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ContatoDTO PesquisarContato(string Nome)
        {
            ContatoDTO Contatos = new ContatoDTO();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    //string query = $"SELECT * FROM Contatos  WHERE Nome = '{Nome}'";

                    SqlCommand command = new SqlCommand("SELECT * FROM Contatos  WHERE Nome = @nome", sqlConnection);
                    command.Parameters.AddWithValue("@nome", Nome);

                    sqlConnection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        return new ContatoDTO()
                        {
                            Nome = reader["Nome"].ToString().Trim(),
                            Endereco = reader["Endereco"].ToString().Trim(),
                            Telefone = reader["Telefone"].ToString().Trim(),
                            Email = reader["Email"].ToString().Trim(),
                            CPF = reader["CPF"].ToString().Trim()
                        };
                    }

                    reader.Close();
                    sqlConnection.Close();

                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AdicionarContato(ContatoDTO contatoDTO)
        {
            SqlConnection sqlCon = null;
            string strCon = @"Server=DESKTOP-RFIAQI4\SQLEXPRESS;Database=AgendaDB;Integrated Security=True; TrustServerCertificate=True";
            string strSql = string.Empty;

            strSql = "insert into Contatos (Nome, Endereco, Telefone, Email, CPF) values (@nome, @endereco, @telefone, @email, @cpf)";
            sqlCon = new SqlConnection(strCon);
            SqlCommand Comando = new SqlCommand(strSql, sqlCon);

            Comando.Parameters.Add("Nome", SqlDbType.VarChar).Value = contatoDTO.Nome;
            Comando.Parameters.Add("Endereco", SqlDbType.VarChar).Value = contatoDTO.Endereco;
            Comando.Parameters.Add("Telefone", SqlDbType.VarChar).Value = contatoDTO.Telefone;
            Comando.Parameters.Add("Email", SqlDbType.VarChar).Value = contatoDTO.Email;
            Comando.Parameters.Add("CPF", SqlDbType.VarChar).Value = contatoDTO.CPF;

            try
            {
                sqlCon.Open();
                Comando.ExecuteNonQuery();


                


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
                
            {


                sqlCon.Close();
            }
        }
        public void RemoverContato(int Id)
        {

            try
            {
                SqlConnection sqlCon = null;
                string strCon = @"Server=AgendaDB.mssql.somee.com;Database=AgendaDB;User Id=bdosilva_SQLLogin_1;Password=hw4prqorp6;TrustServerCertificate=True";
                string strSql = string.Empty;
                SqlCommand Comando;
                sqlCon = new SqlConnection(strCon);
                //DELETE FROM table_name WHERE condition;
                sqlCon.Open();
                Comando = new SqlCommand("delete from Contatos where ID=@id", sqlCon);
                
                Comando.Parameters.AddWithValue("@id", Id);
                Comando.ExecuteNonQuery();
                sqlCon.Close();



            }
            catch
            {

            }
            
        }
    }
}


