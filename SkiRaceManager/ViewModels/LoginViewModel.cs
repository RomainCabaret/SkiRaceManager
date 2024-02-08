﻿using MySql.Data.MySqlClient;
using SkiRaceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRaceManager.ViewModels
{
    internal static class LoginViewModel
    {
        public static bool ConnectUser(string login, string password)
        {
            string query = $"SELECT * FROM `account` WHERE `login` = @login AND `password` = @password";

            MySqlConnection connection = DbContext.CreateConnexion();
            connection.Open();


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Ajouter les paramètres avec leurs valeurs
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Account.Id = int.Parse(reader["id"].ToString());
                        Account.Login = reader["login"].ToString();
                        Account.Password = reader["password"].ToString();
                        Account.ProfilePicture = reader["profilePicture"].ToString();
                        Account.Rank = reader["rank"].ToString();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}