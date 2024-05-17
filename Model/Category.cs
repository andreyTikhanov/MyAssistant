namespace Assistant.model
{
    public class Category
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
        public Category() { }
        public Category(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
    }
}
