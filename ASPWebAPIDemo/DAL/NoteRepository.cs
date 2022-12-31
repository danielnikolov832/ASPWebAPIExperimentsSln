using ASPWebAPIDemo.DAL.DAOs;
using ASPWebAPIDemo.Models;
using EFCoreRepositoriesLib;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ASPWebAPIDemo.DAL;

public interface INoteRepository : ICrudRepositoryWithPKBase<Note>
{
}

internal class NoteRepository : CrudRepositoryWithPKAndMapperBase<Note, NoteDao>, INoteRepository
{
    public NoteRepository(NoteContext noteContext, IMapper mapper) : base(noteContext, mapper)
    {
    }

    public override void Remove(Note root)
    {
        NoteDao entity = Adapt(root);

        foreach (NoteDao child in entity.get_children)
        {
            Remove(child);
        }

        _table.Remove(entity);
    }

    private void Remove(NoteDao root)
    {
        foreach (NoteDao child in root.get_children)
        {
            Remove(child);
        }

        _table.Remove(root);
    }

    public override bool Remove(int id)
    {
        NoteDao? root = GetNote(id);

        if (root is default(NoteDao)) return false;

        foreach (NoteDao child in root.get_children)
        {
            Remove(child);
        }

        _table.Remove(root);

        _dbContext.SaveChanges();

        return true;
    }

    private NoteDao RecursiveGetNoteData(NoteDao noteWithProps)
    {
        // This query by itself tells EF to add the found children to it
        IEnumerable<NoteDao> children = _table
            .Where(note => note.ParentID == noteWithProps.ID)
            .Include(note => note.get_properties)
            .ToList();

        foreach (NoteDao? child in children)
        {
            RecursiveGetNoteData(child);
        }

        return noteWithProps;
    }

    protected override void ApplyTransformations(IQueryable<NoteDao> entities)
    {
        // TODO Delete or add the Include(note => note.get_properties) if needed
    }

    private NoteDao? GetNote(int id)
    {
        NoteDao? note = _table
            .Where(note => note.ID == id)
            .Include(note => note.get_properties)
            .SingleOrDefault();

        return (note is not null) ? RecursiveGetNoteData(note) : null;
    }
}