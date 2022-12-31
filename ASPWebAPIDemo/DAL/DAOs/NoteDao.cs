using ASPWebAPIDemo.Models;
using ASPWebAPIDemo.Models.BaseClasses;
using EFCoreRepositoriesLib;

namespace ASPWebAPIDemo.DAL.DAOs
{
    public class NoteDao : PrimaryKeyUser
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Name { get; set; }

        public List<NoteDao> get_children { get; init; } = new();

        public List<StringNotePropertyDao> get_properties { get; init; } = new();

        public int? ParentID { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
