using System;
using System.Collections.Generic;
using System.Data.SqlClient; //pertence ao  SqlConnection
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {   //abrir conexao
            SqlConnection minhaConexao =
                //data source = nome do servido banco Security=SSPI seguraça do windows Catalog= nome do banco
                new SqlConnection(@"data source = DESKTOP-22894CJ;Integrated Security=SSPI;Initial Catalog=aulaADO");

            minhaConexao.Open();

            //fazendo update

            string strQueryUpdate = "UPDATE ALUNO SET Nome = 'Nicolas' WHERE AlunoId = 1"; //criei uma variavel com minha query
            SqlCommand cmdComandoUpdate = new SqlCommand(strQueryUpdate, minhaConexao); //criei um objeto cmdComandoUpdate que passo a variavel da minha query select e da conexao
            cmdComandoUpdate.ExecuteNonQuery(); // execulta cmdComandoUpdate

            //fazendo Delete

            string strQueryDelete = "DELETE FROM ALUNO WHERE AlunoId = 1"; //criei uma variavel com minha query
            SqlCommand cmdComandoDelete = new SqlCommand(strQueryDelete, minhaConexao); //criei um objeto cmdComandoUpdate que passo a variavel da minha query select e da conexao
            cmdComandoDelete.ExecuteNonQuery(); // execulta cmdComandoUpdate

            //fazendo Create

            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome da mae do aluno: ");
            string mae = Console.ReadLine();

            Console.Write("Digite a data: ");
            string data = Console.ReadLine();

            string strQueryInsert = String.Format("INSERT INTO ALUNO (Nome, Mae, DataNascimento) VALUES('{0}','{1}','{2}')", nome, mae, data); //criei uma variavel com minha query
            SqlCommand cmdComandoInsert = new SqlCommand(strQueryInsert, minhaConexao); //criei um objeto cmdComandoUpdate que passo a variavel da minha query select e da conexao
            cmdComandoInsert.ExecuteNonQuery(); // execulta cmdComandoUpdate

            //fazendo um read

            string strQuerySelet = "SELECT * FROM Aluno"; //criei uma variavel com minha query
            SqlCommand cmdComandoSelect = new SqlCommand(strQuerySelet, minhaConexao); //criei um objeto cmdComandoSelect que passo a variavel da minha query select e da conexao
            SqlDataReader dados = cmdComandoSelect.ExecuteReader(); // em SqlDataReader execulta cmdComandoSelect

            while (dados.Read()) //enquanto houver dados ele lista
            {
                // perguntas que vai ser exibida "Id:{0}, Nome:{1}, Mae:{2}, DataNascimento:{3}"
                // Repostas que vao ser buscadas dados["AlunoId"], dados["Nome"], dados["Mae"], dados["DataNascimento"]
                Console.WriteLine("Id:{0}, Nome:{1}, Mae:{2}, DataNascimento:{3}", dados["AlunoId"], dados["Nome"], dados["Mae"], dados["DataNascimento"]);
                
            }
            Console.ReadLine();
        }
    }
}
