﻿// <auto-generated />
using System;
using ASP.NET_Core_Web_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP.NET_Core_Web_API.Migrations
{
    [DbContext(typeof(StorageDbContext))]
    [Migration("20221108032414_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASP.NET_Core_Web_API.Models.Implementation.Operation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Operation", (string)null);
                });

            modelBuilder.Entity("ASP.NET_Core_Web_API.Models.Implementation.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ASP.NET_Core_Web_API.Models.Implementation.Transaction", b =>
                {
                    b.HasOne("ASP.NET_Core_Web_API.Models.Implementation.Operation", "Operation")
                        .WithMany("Transactions")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("ASP.NET_Core_Web_API.Models.Implementation.Operation", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
