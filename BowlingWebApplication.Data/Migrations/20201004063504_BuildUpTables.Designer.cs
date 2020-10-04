﻿// <auto-generated />
using BowlingWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BowlingWebApplication.Data.Migrations
{
    [DbContext(typeof(BowlingDbContext))]
    [Migration("20201004063504_BuildUpTables")]
    partial class BuildUpTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BowlingWebApplication.Data.Entities.Frame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CumulativeScore");

                    b.Property<int>("Delivery1Id");

                    b.Property<int>("Delivery2Id");

                    b.Property<int>("Delivery3Id");

                    b.Property<int>("StatusCode");

                    b.HasKey("Id");

                    b.ToTable("Frames");
                });
#pragma warning restore 612, 618
        }
    }
}