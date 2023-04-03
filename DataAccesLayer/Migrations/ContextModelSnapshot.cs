﻿// <auto-generated />
using System;
using DataAccesLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityLayer.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool?>("CategoryStatus")
                        .HasColumnType("bit")
                        .HasMaxLength(50);

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EntityLayer.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacttext")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("EntityLayer.Follow", b =>
                {
                    b.Property<int>("followID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TakiEdenID")
                        .HasColumnType("int");

                    b.Property<int>("TakipEdilenID")
                        .HasColumnType("int");

                    b.Property<bool>("statu")
                        .HasColumnType("bit");

                    b.HasKey("followID");

                    b.ToTable("follows");
                });

            modelBuilder.Entity("EntityLayer.Like", b =>
                {
                    b.Property<int>("LikeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Lİke_")
                        .HasColumnType("bit");

                    b.Property<int>("MakaleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("LikeID");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("EntityLayer.Makale", b =>
                {
                    b.Property<int>("MakaleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("MakaleAciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MakaleBaşlik")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("MakaleResim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("MakaleStatus")
                        .HasColumnType("bit");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("_Like")
                        .HasColumnType("int");

                    b.HasKey("MakaleID");

                    b.ToTable("Makale");
                });

            modelBuilder.Entity("EntityLayer.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("KullaniciResim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("takipcisayisi")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EntityLayer.Yorum", b =>
                {
                    b.Property<int>("YorumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MakaleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("yorum_text")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("YorumID");

                    b.ToTable("Yorum");
                });
#pragma warning restore 612, 618
        }
    }
}
