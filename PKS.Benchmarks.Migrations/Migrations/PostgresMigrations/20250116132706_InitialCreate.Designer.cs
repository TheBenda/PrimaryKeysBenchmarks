﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PKS.Benchmarks.Migrations.Data;

#nullable disable

namespace PKS.Benchmarks.Migrations.Migrations.PostgresMigrations
{
    [DbContext(typeof(BenchmarksDbContext))]
    [Migration("20250116132706_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PKS.Benchmarks.Domain.Entities.CombinedTable", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CreatedOn" }, "IX_CombinedPerson_CreatedOn");

                    b.ToTable("CombinedTables");
                });

            modelBuilder.Entity("PKS.Benchmarks.Domain.Entities.IntTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("IntTables");
                });

            modelBuilder.Entity("PKS.Benchmarks.Domain.Entities.UlidBinaryTable", b =>
                {
                    b.Property<byte[]>("Id")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("UlidBinaryTables");
                });

            modelBuilder.Entity("PKS.Benchmarks.Domain.Entities.UlidStringTable", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.HasKey("Id");

                    b.ToTable("UlidStringTables");
                });

            modelBuilder.Entity("PKS.Benchmarks.Domain.Entities.UuidV4Table", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("UuidV4Tables");
                });

            modelBuilder.Entity("PKS.Benchmarks.Domain.Entities.UuidV7Table", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("UuidV7Tables");
                });
#pragma warning restore 612, 618
        }
    }
}
