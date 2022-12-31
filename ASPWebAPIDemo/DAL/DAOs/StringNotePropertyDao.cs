using ASPWebAPIDemo.Models;
using ASPWebAPIDemo.Models.BaseClasses;
using EFCoreRepositoriesLib;

namespace ASPWebAPIDemo.DAL.DAOs
{
    public class StringNotePropertyDao : PrimaryKeyUser
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Name { get; set; }

        public string get_value { get; init; }

        public NotePropertyType get_dataType { get; init; }

        public int NoteID { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}