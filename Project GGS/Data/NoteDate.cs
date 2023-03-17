using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GGS
{
    class NoteDate
    {
        public List<Note> GetAll()
        {
            var noteList = new List<Note>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM note", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Note(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4)
                        );

                        noteList.Add(product);
                    }
                }
                connection.Close();
            }
            return noteList;
        }   
        public Note Get(int id)
        {
            Note note = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM note WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        note = new Note(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetInt32(4)
                        );
                    }
                }
                connection.Close();
            }
            return note;
        }
        public void Add(Note note)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO note (Title, Description, Dataa, Level) VALUES(@title, @description, @dataa, @level)", connection);
                command.Parameters.AddWithValue("title", note.Title);
                command.Parameters.AddWithValue("description", note.Description);
                command.Parameters.AddWithValue("dataa", note.Dataa);
                command.Parameters.AddWithValue("level", note.Level);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Update(Note note)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("UPDATE note SET Title=@title, Description=@description, Dataa=@dataa, Level=@level WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", note.Id);
                command.Parameters.AddWithValue("title", note.Title);
                command.Parameters.AddWithValue("description", note.Description);
                command.Parameters.AddWithValue("dataa", note.Dataa);
                command.Parameters.AddWithValue("level", note.Level);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("DELETE note WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}
