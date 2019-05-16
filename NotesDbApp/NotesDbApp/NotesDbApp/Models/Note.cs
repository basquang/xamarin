using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesDbApp.Models
{
    public class Note
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
