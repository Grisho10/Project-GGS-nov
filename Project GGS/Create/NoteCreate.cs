using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Project_GGS
{
    class NoteCreate
    {
        private NoteDate general = new NoteDate();

        public List<Note> GetAll()
        {
            return general.GetAll();
        }
        public Note Get(int id)
        {
            return general.Get(id);
        }
        public void Add(Note note)
        {
            general.Add(note);
        }
        public void Update(Note note)
        {
            general.Update(note);
        }
        public void Delete(int id)
        {
            general.Delete(id);
        }
        public List<Note> Longest() 
        {
            return general.Longest();
        }
        public List<Note> Between(string startdata,string enddata)
        {
            return general.Between(startdata, enddata);
        }
        public List<Note> OfLevel(int level)
        {
            return general.OfLevel(level);
        }

    }
}
