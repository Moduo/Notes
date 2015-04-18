using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Notes.Models;
using System.Data.Entity;

namespace Notes.DAL
{
    public class ApplicationInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var directories = new List<Directory>
            {
                new Directory{Id = 0, Name="Root", ParentId = 0},
                new Directory{Id = 1, Name="Second", ParentId = 0},
                new Directory{Id = 2, Name="Third", ParentId = 0},
                new Directory{Id = 3, Name="Fourth", ParentId = 0},
                new Directory{Id = 4, Name="Fifth", ParentId = 1},
                new Directory{Id = 5, Name="Sixth", ParentId = 1},
                new Directory{Id = 6, Name="Seventh", ParentId = 2},
                new Directory{Id = 7, Name="Eighth", ParentId = 5},
                new Directory{Id = 8, Name="Nineth", ParentId = 5}
            };

            directories.ForEach(g => context.Directories.Add(g));
            context.SaveChanges();

            var notes = new List<Note>
            {
                new Note{Id = 0, Text = "Note in group Second", DirectoryId=1},
                new Note{Id = 1, Text= "Another note in group Second", DirectoryId=1},
                new Note{Id = 2, Text= "Note in group Third", DirectoryId=2}

            };

            notes.ForEach(n => context.Notes.Add(n));
            context.SaveChanges();
        }
    }
}