﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TheHealthyAssistant.Models;

namespace TheHealthyAssistant.Data
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>()
                            .Where(i => i.id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
    }
