﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assistant.model
{
    internal class SQLiteAssistantRepository : IAssistantRepository
    {
        private const string connString = "Data Source = D:\\Notes.db";
        private SqliteConnection _connection;
        public SQLiteAssistantRepository(string connection=connString)
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
            }catch (Exception ex)
            {
                return false;
            }
        }
        public void AddNote(Note note)
        {
           if(!OpenConnect()) return;
            string query = "INSERT INTO note VALUES (null, @tn, @dn, @ic);";
            SqliteCommand cmd=_connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@tn", note.Title);
            cmd.Parameters.AddWithValue("@dn", note.Description);
            cmd.Parameters.AddWithValue("@ic", note.Id_category);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public void RemoveNote(Note note)
        {
            if(!OpenConnect()) return;
            string query = "DELETE FROM note WHERE id = @id;";
            SqliteCommand cmd=_connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", note.Id);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public void UpdateNote(Note note)
        {
            if(!OpenConnect()) return;
            string query = "UPDATE note SET title = @tn, description = @dn, id_category = @ic);";
            SqliteCommand cmd=_connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@tn", note.Title);
            cmd.Parameters.AddWithValue("@dn", note.Description);
            cmd.Parameters.AddWithValue("@ic", note.Id_category);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public Note GetNote(string id)
        {
            if (!OpenConnect()) return null;
            string query = "SELECT * FROM note WHERE id = @id;";
            SqliteCommand cmd = _connection.CreateCommand(); cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", id);
            SqliteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Note note = new Note()
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Description = reader.GetString(2)
            };
            return note;
        }
        public void AddCategory(Category category)
        {
            if(! OpenConnect()) return;
            string query = "INSERT INTO category VALUES (null, @t);";
            SqliteCommand cmd=_connection.CreateCommand(); cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@t", category.Title);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public void RemoveCategory(Category category)
        {
            if (! OpenConnect()) return;
            string query = "DELETE FROM category WHERE id = @id;";
            SqliteCommand cmd=_connection.CreateCommand();cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", category.Id);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public void UpdateCategory(Category category)
        {
          if(!OpenConnect()) return;
            string query = "UPDATE INTO categories SET title = @tc WHERE id = @id;";
            SqliteCommand cmd=_connection.CreateCommand();cmd.CommandText= query;
            cmd.Parameters.AddWithValue("@tc", category.Title);
            cmd.Parameters.AddWithValue("@id", category.Id);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public Category GetCategory(int  id)
        {
            if (!OpenConnect()) return null;
            string query = "SELECT * FROM category WHERE id = @id;";
            SqliteCommand cmd=_connection.CreateCommand();
            cmd.CommandText= query;
            cmd.Parameters.AddWithValue("@id", id);
            SqliteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Category category = new Category()
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
            };
            return category;
        }
    }
}
