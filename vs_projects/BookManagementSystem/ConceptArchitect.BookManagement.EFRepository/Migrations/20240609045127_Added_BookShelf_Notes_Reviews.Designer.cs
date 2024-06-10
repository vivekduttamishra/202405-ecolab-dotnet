﻿// <auto-generated />
using System;
using ConceptArchitect.BookManagement.EFRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConceptArchitect.BookManagement.EFRepository.Migrations
{
    [DbContext(typeof(BooksContext))]
    [Migration("20240609045127_Added_BookShelf_Notes_Reviews")]
    partial class Added_BookShelf_Notes_Reviews
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConceptArchitect.BookManagement.Author", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photograph")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.Book", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CoverPage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.BookNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("BookShelfItemId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BookShelfItemId");

                    b.HasIndex("UserEmail");

                    b.ToTable("BookNotes");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.BookShelfItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BookId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserEmail");

                    b.ToTable("BookShelfItems");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserEmail");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.Book", b =>
                {
                    b.HasOne("ConceptArchitect.BookManagement.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.BookNote", b =>
                {
                    b.HasOne("ConceptArchitect.BookManagement.Book", null)
                        .WithMany("Notes")
                        .HasForeignKey("BookId");

                    b.HasOne("ConceptArchitect.BookManagement.BookShelfItem", null)
                        .WithMany("Notes")
                        .HasForeignKey("BookShelfItemId");

                    b.HasOne("ConceptArchitect.BookManagement.User", "User")
                        .WithMany()
                        .HasForeignKey("UserEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.BookShelfItem", b =>
                {
                    b.HasOne("ConceptArchitect.BookManagement.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConceptArchitect.BookManagement.User", null)
                        .WithMany("BookShelf")
                        .HasForeignKey("UserEmail");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.Review", b =>
                {
                    b.HasOne("ConceptArchitect.BookManagement.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId");

                    b.HasOne("ConceptArchitect.BookManagement.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.Book", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.BookShelfItem", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("ConceptArchitect.BookManagement.User", b =>
                {
                    b.Navigation("BookShelf");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
