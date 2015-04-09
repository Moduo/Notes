using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Notes.Models;
using System.Data.Entity;

namespace Notes.DAL
{
    public class ApplicationInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var directories = new List<Directory>
            {
                new Directory{Id = 0, Name="First"},
                new Directory{Id = 1, Name="Second"},
                new Directory{Id = 2, Name="Third"},
                new Directory{Id = 3, Name="Fourth"}
            };

            directories.ForEach(g => context.Directories.Add(g));
            context.SaveChanges();

            var notes = new List<Note>
            {
                new Note{Id = 0, Text = "Note in group First", DirectoryId=1},
                new Note{Id = 1, Text= "Another note in group First", DirectoryId=1},
                new Note{Id = 2, Text= "Note in group Second", DirectoryId=2}

            };

            notes.ForEach(n => context.Notes.Add(n));
            context.SaveChanges();
        }
    }
}