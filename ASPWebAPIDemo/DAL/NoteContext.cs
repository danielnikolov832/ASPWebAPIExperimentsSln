using ASPWebAPIDemo.DAL.DAOs;
using ASPWebAPIDemo.Models;
using ASPWebAPIDemo.Models.BaseClasses;
using Microsoft.EntityFrameworkCore;

namespace ASPWebAPIDemo.DAL;

internal class NoteContext : DbContext
{
	private const int _maxLengthOfNoteNames = 200;
	private const int _maxLengthOfPropertyNames = 200;

	public NoteContext(DbContextOptions options)
		: base(options)
	{
	}

	public DbSet<NoteDao> Notes { get; set; }
	public DbSet<StringNotePropertyDao> StringNoteProperties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<NoteDao>(builder =>
		{
			builder.HasMany(note => note.get_properties)
				.WithOne()
				.HasForeignKey(property => property.NoteID)
				.IsRequired();

			builder.HasMany(note => note.get_children)
				.WithOne()
				.HasForeignKey(note => note.ParentID)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Property(note => note.Name)
				.IsRequired()
				.HasMaxLength(_maxLengthOfNoteNames);
		});

		modelBuilder.Entity<StringNotePropertyDao>(builder =>
		{
			builder.Property(noteProperty => noteProperty.Name)
				.IsRequired()
				.HasMaxLength(_maxLengthOfPropertyNames);

			builder.Property(noteProperty => noteProperty.get_dataType)
				.IsRequired();
		});

		base.OnModelCreating(modelBuilder);
	}
}