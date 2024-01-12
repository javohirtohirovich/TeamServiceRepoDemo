﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTierApplication.DataAccess;

#nullable disable

namespace NTierApplication.DataAccess.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20231214052552_First_Migration")]
    partial class First_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NTierApplication.DataAccess.Models.Item", b =>
                {
                    b.Property<long>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ItemId"));

                    b.Property<DateTime>("ItemDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemType")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.ToTable("Item", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
