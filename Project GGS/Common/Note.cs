using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GGS
{
    class Note
    {
        //gotovo
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Dataa { get; set; }
        public int Level  { get; set; }

        public Note()
        {
        }
        public Note(int id, string title, string description, string dataa, int level)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Dataa = dataa;
            this.Level = level;
        }

    }
}
