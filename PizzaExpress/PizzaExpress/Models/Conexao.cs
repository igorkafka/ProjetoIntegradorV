﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzaExpress.Models
{
    public class Conexao
    {
        private SqlConnection Conectar()
        {
            string stringConexao = @"Data Source=DESKTOP-TC5QN9P;Initial Catalog=PizzaExpress;User ID=sa;Password=evangelion;Min Pool Size=5;Max Pool Size=250; Connect Timeout=3";

            SqlConnection conexao = new SqlConnection(stringConexao);
            conexao.Open();

            return conexao;
        }

        public int ExecutarCrud(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            int id = Convert.ToInt32(comando.ExecuteScalar());
           
            con.Close();
            return id;

            
        }

        public SqlDataReader ExecutarSelect(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            SqlDataReader DR = comando.ExecuteReader(CommandBehavior.CloseConnection);
            return DR;
        }
    }
}