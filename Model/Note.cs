using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant.Model
{
    internal class Note
    {
        public string Title {  get; set; }
        public string Description { get; set; }
        public Note() { }
        public Note(string title, string description) {  Title = title; Description = description; }   
    }
}
