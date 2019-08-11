﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PowerFeedback.Api.Models;

namespace PowerFeedback.Api.Migrations
{
    [DbContext(typeof(PfDbContext))]
    partial class PfDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PowerFeedback.Api.DTOs.ContactRequest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<int>("ContactType");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Name");

                    b.Property<DateTime>("RequestDate");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("PowerFeedback.Api.DTOs.Sentiment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactId");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId")
                        .IsUnique()
                        .HasFilter("[ContactId] IS NOT NULL");

                    b.ToTable("Sentiments");
                });

            modelBuilder.Entity("PowerFeedback.Api.DTOs.Sentiment", b =>
                {
                    b.HasOne("PowerFeedback.Api.DTOs.ContactRequest", "Contact")
                        .WithOne("Sentiment")
                        .HasForeignKey("PowerFeedback.Api.DTOs.Sentiment", "ContactId");
                });
#pragma warning restore 612, 618
        }
    }
}
