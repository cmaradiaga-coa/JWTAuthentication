﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiDemo.Data;

#nullable disable

namespace WebApiDemo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250319010028_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiDemo.Models.Entities.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("user_account");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Administrator",
                            Password = "AQAAAAIAAYagAAAAEF4Ym0bBfc3DPKUWx4mohkUpO0RVM3Iq62skbUVY6J9CYTOJlgWKLMY0etgNVXk0Pw==",
                            UserName = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
