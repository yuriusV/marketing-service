﻿// <auto-generated />
using System;
using Campaign.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Campaign.Infrastructure.Migrations;

[DbContext(typeof(CampaignContext))]
[Migration("20240624062526_Initial")]
partial class Initial
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.1")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("Campaign.Domain.Entities.Campaign", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("gen_random_uuid()");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("LastModifiedDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<int>("Priority")
                    .HasColumnType("integer");

                b.Property<string>("Query")
                    .IsRequired()
                    .HasColumnType("jsonb");

                b.Property<Guid>("TemplateId")
                    .HasColumnType("uuid");

                b.Property<TimeSpan>("Time")
                    .HasColumnType("time");

                b.HasKey("Id");

                b.HasIndex("TemplateId");

                b.ToTable("Campaigns");
            });

        modelBuilder.Entity("Campaign.Domain.Entities.CampaignActivity", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("gen_random_uuid()");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("LastModifiedDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<Guid>("TargetId")
                    .HasColumnType("uuid");

                b.HasKey("Id");

                b.HasIndex("TargetId", "CreatedDate");

                b.ToTable("Activities");
            });

        modelBuilder.Entity("Campaign.Domain.Entities.Template", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("gen_random_uuid()");

                b.Property<byte[]>("Contents")
                    .IsRequired()
                    .HasColumnType("bytea");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("LastModifiedDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Templates");
            });

        modelBuilder.Entity("Campaign.Domain.Entities.Campaign", b =>
            {
                b.HasOne("Campaign.Domain.Entities.Template", "Template")
                    .WithMany()
                    .HasForeignKey("TemplateId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Template");
            });
#pragma warning restore 612, 618
    }
}
