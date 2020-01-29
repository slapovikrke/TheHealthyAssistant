using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheHealthyAssistant.Models;

namespace TheHealthyAssistant.Data
{
    public class NoteDatabase
    {

        private SQLiteAsyncConnection _database;
        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();

        }

        public Task<List<Note>> GetUsersAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetUserAsync(int id)
        {
            return _database.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        //internal Task SaveUserAsync(User user)
        //{
        //    return _database.InsertAsync(user);
        //    //throw new NotImplementedException();
        //}

        public Task<int> SaveUserAsync(Note note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
                //throw new NotImplementedException();
            }
        }

        public Task<int> DeleteUserAsync(Note note)
        {


            return _database.DeleteAsync(note);
        }
    }
}