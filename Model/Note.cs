namespace Assistant.model
{
    public class Note
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int id_category;

        public int Id_category
        {
            get { return id_category; }
            set { id_category = value; }
        }
        public Note() { }
        public Note(int id, string title, string description, int id_cat)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.id_category = id_cat;
        }
    }
}
