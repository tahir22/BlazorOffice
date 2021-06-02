﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Server.Models;

namespace Test.Server.Migrations
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Test.Server.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cnic")
                        .HasColumnType("int");

                    b.Property<int>("CusInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerinformationCusInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerinformationCusInfoId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Test.Server.Models.Customerinformation", b =>
                {
                    b.Property<int>("CusInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CusInfoId");

                    b.ToTable("Customerinformations");
                });

            modelBuilder.Entity("Test.Server.Models.Customer", b =>
                {
                    b.HasOne("Test.Server.Models.Customerinformation", "Customerinformation")
                        .WithMany("Customer")
                        .HasForeignKey("CustomerinformationCusInfoId");

                    b.Navigation("Customerinformation");
                });

            modelBuilder.Entity("Test.Server.Models.Customerinformation", b =>
                {
                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
