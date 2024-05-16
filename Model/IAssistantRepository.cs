using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant.model
{
    internal interface IAssistantRepository
    {
        bool OpenConnect();
        bool CloseConnect();
        void AddNote(Note note);
        void RemoveNote(Note note);
        void UpdateNote(Note note );
        void AddCategory(Category category);
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
        Note GetNote(string id);
        Category GetCategory(int id);

    }
}
