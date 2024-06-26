﻿using Microsoft.Data.Sqlite;

namespace Assistant.model
{
    internal class SQLiteAssistantRepository : IAssistantRepository
    {
        private const string connString = "Data Source = D:\\Notes.db";
        private SqliteConnection _connection;
        public SQLiteAssistantRepository(string connection = connString)
        {
            _connection = new SqliteConnection(connString);
        }
        public bool OpenConnect()
        {
            try
            {
                _connection.Open();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CloseConnect()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void AddNote(Note note)
        {
            if (!OpenConnect()) return;
            string query = "INSERT INTO note VALUES (null, @tn, @dn, @ic);";
            SqliteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@tn", note.Title);
            cmd.Parameters.AddWithValue("@dn", note.Description);
            cmd.Parameters.AddWithValue("@ic", note.Id_category);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public void RemoveNote(Note note)
        {
            if (!OpenConnect()) return;
            string query = "DELETE FROM note WHERE id = @id;";
            SqliteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", note.Id);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public void UpdateNote(Note note)
        {
            if (!OpenConnect()) return;
            string query = "UPDATE note SET title = @tn, description = @dn, id_category = @ic where id = @id";
            SqliteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@tn", note.Title);
            cmd.Parameters.AddWithValue("@dn", note.Description);
            cmd.Parameters.AddWithValue("@ic", note.Id_category);
            cmd.Parameters.AddWithValue("@id", note.Id);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public Note GetNote(string title)
        {
            if (!OpenConnect()) return null;
            string query = "SELECT * FROM note WHERE title = @t;";
            SqliteCommand cmd = _connection.CreateCommand(); cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@t", title);
            using (SqliteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Note()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2)
                    };
                }
                else
                {
                    return null;
                }
            }
        }
        public void AddCategory(Category category)
        {
            if (!OpenConnect()) return;
            string query = "INSERT INTO category VALUES (null, @t);";
            SqliteCommand cmd = _connection.CreateCommand(); cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@t", category.Title);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public void RemoveCategory(Category category)
        {
            if (!OpenConnect()) return;
            string queryDeleteNotes = "delete from note where id_category = @cid";
            SqliteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = queryDeleteNotes;
            cmd.Parameters.AddWithValue("@cid", category.Id);
            cmd.ExecuteNonQuery();
            string query = "DELETE from category where title = @t";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@t", category.Title);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public void UpdateCategory(Category category)
        {
            if (!OpenConnect()) return;
            string query = "UPDATE category SET title = @nt WHERE id = @id;";
            SqliteCommand cmd = _connection.CreateCommand(); cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nt", category.Title);
            cmd.Parameters.AddWithValue("@id", category.Id);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public Category GetCategory(string title)
        {
            if (!OpenConnect()) return null;
            string query = "SELECT * FROM category WHERE title = @t;";
            SqliteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@t", title);

            using (SqliteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Category()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                    };
                }
                else
                {
                    return null;
                }
            }
        }
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            if (!OpenConnect()) return categories;
            string query = "SELECT * FROM category; ";
            SqliteCommand command = _connection.CreateCommand();
            command.CommandText = query;
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    categories.Add(new Category()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                    });
                }
                return categories;
            }
        }
        public List<Note> GetAllNotes()
        {
            List<Note> notes = new List<Note>();
            if (!OpenConnect()) return notes;
            string query = "SELECT * FROM note; ";
            SqliteCommand command = _connection.CreateCommand();
            command.CommandText = query;
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    notes.Add(new Note()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        Id_category = reader.GetInt32(3)
                    });
                }
                return notes;
            }
        }
        public List<Note> SelectedCategory(Category category)
        {
            List<Note> notes = new List<Note>();
            if (!OpenConnect()) return notes;

        string selectQuery = @"
        SELECT n.id, n.title, n.description, n.id_category
        FROM note n
        INNER JOIN category c ON n.id_category = c.id
        WHERE c.title = @categoryTitle";

            using (SqliteCommand command = new SqliteCommand(selectQuery, _connection))
            {
                command.Parameters.AddWithValue("@categoryTitle", category.Title);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notes.Add(new Note()
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Id_category = reader.GetInt32(3)
                        });
                    }
                }
            }

            return notes;
        }
    }

}


