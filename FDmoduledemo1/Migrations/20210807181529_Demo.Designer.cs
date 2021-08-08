﻿// <auto-generated />
using System;
using FDmoduledemo1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FDmoduledemo1.Migrations
{
    [DbContext(typeof(FDmoduledemo1Context))]
    [Migration("20210807181529_Demo")]
    partial class Demo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FDmoduledemo1.Models.AccountUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SAns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sques")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AccountUser");
                });

            modelBuilder.Entity("FDmoduledemo1.Models.FDTable", b =>
                {
                    b.Property<int>("FdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountUserUserId")
                        .HasColumnType("int");

                    b.Property<double>("FdInMoney")
                        .HasColumnType("float");

                    b.Property<double>("FdInvMon")
                        .HasColumnType("float");

                    b.Property<double>("FdMAmount")
                        .HasColumnType("float");

                    b.Property<double>("Month")
                        .HasColumnType("float");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("n")
                        .HasColumnType("int");

                    b.HasKey("FdId");

                    b.HasIndex("AccountUserUserId");

                    b.ToTable("FDTable");
                });

            modelBuilder.Entity("FDmoduledemo1.Models.RD", b =>
                {
                    b.Property<int>("RdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountUserUserId")
                        .HasColumnType("int");

                    b.Property<double>("FdInMoney")
                        .HasColumnType("float");

                    b.Property<double>("FdMAmount")
                        .HasColumnType("float");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<double>("RdInvMon")
                        .HasColumnType("float");

                    b.Property<double>("Time")
                        .HasColumnType("float");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("n")
                        .HasColumnType("int");

                    b.HasKey("RdId");

                    b.HasIndex("AccountUserUserId");

                    b.ToTable("RD");
                });

            modelBuilder.Entity("FDmoduledemo1.Models.FDTable", b =>
                {
                    b.HasOne("FDmoduledemo1.Models.AccountUser", "AccountUser")
                        .WithMany()
                        .HasForeignKey("AccountUserUserId");

                    b.Navigation("AccountUser");
                });

            modelBuilder.Entity("FDmoduledemo1.Models.RD", b =>
                {
                    b.HasOne("FDmoduledemo1.Models.AccountUser", "AccountUser")
                        .WithMany()
                        .HasForeignKey("AccountUserUserId");

                    b.Navigation("AccountUser");
                });
#pragma warning restore 612, 618
        }
    }
}
