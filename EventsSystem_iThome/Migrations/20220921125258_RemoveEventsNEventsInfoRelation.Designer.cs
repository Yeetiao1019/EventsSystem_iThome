﻿// <auto-generated />
using System;
using EventsSystem_iThome.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventsSystem_iThome.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220921125258_RemoveEventsNEventsInfoRelation")]
    partial class RemoveEventsNEventsInfoRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventsSystem_iThome.Models.Events", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ProgressTimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProgressTimeStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SaleTimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SaleTimeStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("SimpleIntro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventsSystem_iThome.Models.EventsCategory", b =>
                {
                    b.Property<int>("EventsCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventsCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventsCategoryId");

                    b.ToTable("EventsCategory");
                });

            modelBuilder.Entity("EventsSystem_iThome.Models.EventsImage", b =>
                {
                    b.Property<int>("EventsImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.Property<string>("ImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageFileSize")
                        .HasColumnType("int");

                    b.HasKey("EventsImageId");

                    b.HasIndex("EventsId");

                    b.ToTable("EventsImage");
                });

            modelBuilder.Entity("EventsSystem_iThome.Models.EventsImageUseType", b =>
                {
                    b.Property<int>("EventsImageUseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UseTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventsImageUseTypeId");

                    b.ToTable("EventsImageUseType");
                });

            modelBuilder.Entity("EventsSystem_iThome.Models.EventsInfo", b =>
                {
                    b.Property<int>("EventsInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationLimitedQty")
                        .HasColumnType("int");

                    b.Property<int>("EventsApplicationQty")
                        .HasColumnType("int");

                    b.Property<string>("FullIntro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventsInfoId");

                    b.ToTable("EventsInfo");
                });

            modelBuilder.Entity("EventsSystem_iThome.Models.EventsImage", b =>
                {
                    b.HasOne("EventsSystem_iThome.Models.Events", "Events")
                        .WithMany("EventsImage")
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventsSystem_iThome.Models.Events", b =>
                {
                    b.Navigation("EventsImage");
                });
#pragma warning restore 612, 618
        }
    }
}
