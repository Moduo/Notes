using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int DirectoryId { get; set; }

        public virtual Directory Directory { get; set; }

    }
}