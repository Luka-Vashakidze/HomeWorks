using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace App
{
    public class DataStore
    {
        private readonly string filePath;

        public DataStore(string path)
        {
            filePath = path;
            
        }
        public List<User> LoadUsers()
        {
            try
            {
                string json = File.ReadAllText(filePath);
                if (string.IsNullOrWhiteSpace(json)) return new List<User>();

                var options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true; 
                List<User> users = JsonSerializer.Deserialize<List<User>>(json, options);
                if (users == null) users = new List<User>();

                int i = 0;
                while (i < users.Count)
                {
                    if (users[i] != null)
                    {
                        if (users[i].Balances == null) users[i].Balances = new Balances();
                        if (users[i].TransactionHistory == null) users[i].TransactionHistory = new List<Transaction>();
                    }
                    i++;
                }

                return users;
            }
            catch (Exception ex)
            {
                SimpleLogger.Log("LoadUsers error: " + ex.Message);
                return new List<User>();
            }
        }

        public User FindUserByCard(string cardNumber)
        {
            try
            {
                List<User> users = LoadUsers();
                int i = 0;
                while (i < users.Count)
                {
                    User u = users[i];
                    if (u != null && u.CardDetails != null && u.CardDetails.CardNumber == cardNumber)
                    {
                        return u;
                    }
                    i++;
                }
                return null;
            }
            catch (Exception ex)
            {
                SimpleLogger.Log("FindUserByCard error: " + ex.Message);
                return null;
            }
        }

        public void SaveUser(User user)
        {
            try
            {
                List<User> users = LoadUsers();
                int index = -1;
                int i = 0;
                while (i < users.Count)
                {
                    if (users[i] != null && users[i].CardDetails != null && users[i].CardDetails.CardNumber == user.CardDetails.CardNumber)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                if (index >= 0) users[index] = user;
                else users.Add(user);

                SaveUsers(users);
            }
            catch (Exception ex)
            {
                SimpleLogger.Log("SaveUser error: " + ex.Message);
            }
        }

        private void SaveUsers(List<User> users)
        {
            try
            {
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string json = JsonSerializer.Serialize(users, options);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                SimpleLogger.Log("SaveUsers error: " + ex.Message);
            }
        }
    }
}