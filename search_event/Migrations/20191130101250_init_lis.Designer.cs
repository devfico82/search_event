﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using search_event.Models;
using System;

namespace search_event.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191130101250_init_lis")]
    partial class init_lis
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("search_event.Models.Eavent", b =>
                {
                    b.Property<int>("EaventID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoPath");

                    b.HasKey("EaventID");

                    b.ToTable("Eavents");
                });
#pragma warning restore 612, 618
        }
    }
}
