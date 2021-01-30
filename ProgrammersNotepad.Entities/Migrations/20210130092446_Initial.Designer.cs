﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgrammersNotepad.Entities;

namespace ProgrammersNotepad.Entities.Migrations
{
    [DbContext(typeof(ProgrammersNotepadDbContext))]
    [Migration("20210130092446_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ProgrammersNotepad.Entities.BaseNoteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BaseUserEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BaseUserEntityId");

                    b.ToTable("BaseNoteEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseNoteEntity");
                });

            modelBuilder.Entity("ProgrammersNotepad.Entities.BaseUserEntity", b =>
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

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProgrammersNotepad.Entities.LanguageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("ProgrammersNotepad.Entities.LanguageNoteEntity", b =>
                {
                    b.HasBaseType("ProgrammersNotepad.Entities.BaseNoteEntity");

                    b.Property<Guid?>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("LanguageId");

                    b.HasDiscriminator().HasValue("LanguageNoteEntity");
                });

            modelBuilder.Entity("ProgrammersNotepad.Entities.BaseNoteEntity", b =>
                {
                    b.HasOne("ProgrammersNotepad.Entities.BaseUserEntity", null)
                        .WithMany("ListOfNotes")
                        .HasForeignKey("BaseUserEntityId");
                });

            modelBuilder.Entity("ProgrammersNotepad.Entities.LanguageNoteEntity", b =>
                {
                    b.HasOne("ProgrammersNotepad.Entities.LanguageEntity", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("ProgrammersNotepad.Entities.BaseUserEntity", b =>
                {
                    b.Navigation("ListOfNotes");
                });
#pragma warning restore 612, 618
        }
    }
}
