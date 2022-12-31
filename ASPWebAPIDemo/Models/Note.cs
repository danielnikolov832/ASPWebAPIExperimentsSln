using ASPWebAPIDemo.Models.BaseClasses;
using EFCoreRepositoriesLib;

namespace ASPWebAPIDemo.Models;

public class Note : PrimaryKeyUser
{
    public Note(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public List<Note> get_children { get; init; } = new();

    public List<StringNoteProperty> get_properties { get; init; } = new();

    public int? ParentID { get; set; }
}