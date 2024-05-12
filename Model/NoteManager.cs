using System.IO;
using System.Text;
using System.Text.Json;

namespace Assistant.Model
{
    internal class NoteManager
    {

        //создаем новый словарь с категориями
        public Dictionary<string, List<Note>> notesByCategory = new Dictionary<string, List<Note>>();
        public void AddNote(string category, Note note)
        {
            if (!notesByCategory.ContainsKey(category))
            {
                notesByCategory[category] = new List<Note>();
            }
            notesByCategory[category].Add(note);
        }
        public void SaveNote()
        {
            Dictionary<string, List<Note>> newNote= new Dictionary<string, List<Note>>();
            if (File.Exists(MainWindow.pathNote))
            {
                string json=File.ReadAllText(MainWindow.pathNote);
                newNote=JsonSerializer.Deserialize<Dictionary<string, List<Note>>>(json);
            }
            foreach(var pair in notesByCategory)
            {
                if (!newNote.ContainsKey(pair.Key))
                {
                    newNote[pair.Key] = new List<Note>();
                }
                newNote[pair.Key].AddRange(pair.Value);
            }
            string update = JsonSerializer.Serialize(newNote, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(MainWindow.pathNote, update);

        }
        public Dictionary<string, List<Note>> LoadNotes()
        {
            if (!File.Exists(MainWindow.pathNote))
            {
                return new Dictionary<string, List<Note>>();
            }
            string json = File.ReadAllText(MainWindow.pathNote);
            notesByCategory = JsonSerializer.Deserialize<Dictionary<string, List<Note>>>(json);
            return notesByCategory;
        }

        public string GetNotes()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in notesByCategory.Keys)
            {
                sb.Append(key).AppendLine();
            }
            return sb.ToString();
        }

    }
}
