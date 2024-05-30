﻿// <auto-generated />
using System;
using BudgetKeeper.Database.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetKeeper.Database.Migrations
{
    [DbContext(typeof(BudgetDbContext))]
    [Migration("20240530144846_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("BudgetKeeper.Database.Entity.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c983e8fa-08d1-4095-873e-e9131a50b0ae"),
                            Name = "Activities"
                        },
                        new
                        {
                            Id = new Guid("7c979f16-a873-45f8-aa7c-1ba712e95494"),
                            Name = "Credit"
                        },
                        new
                        {
                            Id = new Guid("24ce6296-851b-40a9-bde1-cac9d77b2ef3"),
                            Name = "Fine"
                        },
                        new
                        {
                            Id = new Guid("37cba832-f797-49c8-85f2-6c5227098bf7"),
                            Name = "Gifts"
                        },
                        new
                        {
                            Id = new Guid("9f30e76e-dbfb-4280-ae66-6450378f0fa6"),
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("f4b67b31-58fd-4784-9528-305df36ebe64"),
                            Name = "Preservation"
                        },
                        new
                        {
                            Id = new Guid("ced59dfe-4571-4096-b006-3717a1ef13a0"),
                            Name = "Products"
                        },
                        new
                        {
                            Id = new Guid("d73b6844-dc87-46e3-9d33-0d9b4d84e483"),
                            Name = "Salary"
                        },
                        new
                        {
                            Id = new Guid("99663bad-9b23-455a-b6d1-70925b9158d9"),
                            Name = "Software"
                        },
                        new
                        {
                            Id = new Guid("c66ae73f-e3d9-4c67-8f78-3ef6b0e76bf9"),
                            Name = "Taxes"
                        },
                        new
                        {
                            Id = new Guid("3dd99611-4824-4e98-8224-0bd8534d563b"),
                            Name = "Unknown"
                        });
                });

            modelBuilder.Entity("BudgetKeeper.Database.Entity.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BudgetKeeper.Database.Entity.Transaction", b =>
                {
                    b.HasOne("BudgetKeeper.Database.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
