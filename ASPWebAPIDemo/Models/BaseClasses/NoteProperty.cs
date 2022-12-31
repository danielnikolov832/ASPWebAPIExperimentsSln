using EFCoreRepositoriesLib;

namespace ASPWebAPIDemo.Models.BaseClasses;

public interface INotePropertyNonGeneric
{
    int ID { get; set; }
    string Name { get; set; }
    object get_valueAsObj { get; }
    NotePropertyType get_dataTypeNonGeneric { get; }
    int NoteID { get; set; }
}

public abstract class NoteProperty<T> : PrimaryKeyUser, INotePropertyNonGeneric
    where T : notnull
{
    protected NoteProperty(string name, T value, NotePropertyType dataType)
    {
        Name = name;
        get_value = value;
        get_dataType = dataType;
    }

    public string Name { get; set; }

    public abstract T get_value { get; init; }

    public NotePropertyType get_dataType { get; init; }
    public NotePropertyType get_dataTypeNonGeneric => get_dataType;

    public object get_valueAsObj => get_value;

    public int NoteID { get; set; }
}