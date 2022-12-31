﻿// <auto-generated />
using System;
using ASPWebAPIDemo.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASPWebAPIDemo.DAL.Migrations
{
    [DbContext(typeof(NoteContext))]
    partial class NoteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASPWebAPIDemo.DAL.DAOs.NoteDao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("ASPWebAPIDemo.DAL.DAOs.StringNotePropertyDao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("NoteID")
                        .HasColumnType("int");

                    b.Property<int>("get_dataType")
                        .HasColumnType("int");

                    b.Property<string>("get_value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("NoteID");

                    b.ToTable("StringNoteProperties");
                });

            modelBuilder.Entity("ASPWebAPIDemo.DAL.DAOs.NoteDao", b =>
                {
                    b.HasOne("ASPWebAPIDemo.DAL.DAOs.NoteDao", null)
                        .WithMany("get_children")
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("ASPWebAPIDemo.DAL.DAOs.StringNotePropertyDao", b =>
                {
                    b.HasOne("ASPWebAPIDemo.DAL.DAOs.NoteDao", null)
                        .WithMany("get_properties")
                        .HasForeignKey("NoteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASPWebAPIDemo.DAL.DAOs.NoteDao", b =>
                {
                    b.Navigation("get_children");

                    b.Navigation("get_properties");
                });
#pragma warning restore 612, 618
        }
    }
}