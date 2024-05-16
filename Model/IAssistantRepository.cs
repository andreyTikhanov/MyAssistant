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
        void AddNote();
        void RemoveNote();
        void UpdateNote();

    }
}
