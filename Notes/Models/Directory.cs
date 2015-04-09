using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes.Models
{
    public class Directory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Note> Notes { get; set; }
        public int ParentId { get; set; }
        public List<int> DirectoryIds { get; set; }

        public virtual Directory Parent { get; set; }
        public virtual ICollection<Directory> Directories { get; set; }
    }
}