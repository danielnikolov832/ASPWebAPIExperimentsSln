using ASPWebAPIDemo.Models.BaseClasses;

namespace ASPWebAPIDemo.Models;

public class StringNoteProperty : NoteProperty<string>
{
    public StringNoteProperty(string name, string value) : base(name, value, NotePropertyType.Text)
    {
    }

    public override string get_value { get; init; }
}

public class IntegerNoteProperty : NoteProperty<long>
{
    public IntegerNoteProperty(string name, long value, NotePropertyType dataType) : base(name, value, dataType)
    {
    }

    public override long get_value { get; init; }
}

public class DecimalNoteProperty : NoteProperty<decimal>
{
    public DecimalNoteProperty(string name, decimal value, NotePropertyType dataType) : base(name, value, dataType)
    {
    }

    public override decimal get_value { get; init; }
}
