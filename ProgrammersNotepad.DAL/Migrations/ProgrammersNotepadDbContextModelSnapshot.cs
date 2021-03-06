﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Migrations
{
    [DbContext(typeof(ProgrammersNotepadDbContext))]
    partial class ProgrammersNotepadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProgrammersNotepad.DAL.Entities.ImageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NoteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("ImageSet");
                });

            modelBuilder.Entity("ProgrammersNotepad.DAL.Entities.NoteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FormattedText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NoteTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RawText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NoteTypeId");

                    b.ToTable("NoteSet");
                });

            modelBuilder.Entity("ProgrammersNotepad.DAL.Entities.NoteTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("NoteTypeSet");
                });

            modelBuilder.Entity("ProgrammersNotepad.DAL.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserSet");
                });

            modelBuilder.Entity("ProgrammersNotepad.DAL.Entities.ImageEntity", b =>
                {
                    b.HasOne("ProgrammersNotepad.DAL.Entities.NoteEntity", "Note")
                        .WithMany("ImageCollection")
                        .HasForeignKey("NoteId");

                    b.Navigation("Note");
                });

            modelBuilder.Entity("ProgrammersNotepad.DAL.Entities.NoteEntity", b =>
                {
                    b.HasOne("ProgrammersNotepad.DAL.Entities.NoteTypeEntity", "NoteType")
                        .WithMany("NoteCollection")
                        .HasForeignKey("NoteTypeId");

                    b.Navigation("NoteType");
                });

            modelBuilder.Entity("ProgrammersNotepad.DAL.Entities.NoteTypeEntity", b =>
                {
                    b.HasOne("ProgrammersNotepad.DAL.Entities.UserEntity", "User")
                        .WithMany("NoteTypeCollection")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProgrammersNotepad.DAL.Entities.NoteEntity", b =>
                {
                    b.Navigation("ImageCollection");
                });

            modelBuilder.Entity("ProgrammersNotepad.DAL.Entities.NoteTypeEntity", b =>
                {
                    b.Navigation("NoteCollection");
                });

            modelBuilder.Entity("ProgrammersNotepad.DAL.Entities.UserEntity", b =>
                {
                    b.Navigation("NoteTypeCollection");
                });
#pragma warning restore 612, 618
        }
    }
}
