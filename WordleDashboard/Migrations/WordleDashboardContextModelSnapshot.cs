﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WordleDashboard.EFContexts;

#nullable disable

namespace WordleDashboard.Migrations
{
    [DbContext(typeof(WordleDashboardContext))]
    partial class WordleDashboardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WordleDashboard.EFModels.DropdownValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DropdownId")
                        .HasColumnType("int");

                    b.Property<string>("DropdownName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DropdownValues");
                });

            modelBuilder.Entity("WordleDashboard.EFModels.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AvgGuessesPerRound")
                        .HasColumnType("int");

                    b.Property<int?>("AvgMissedEntriesPerRound")
                        .HasColumnType("int");

                    b.Property<decimal?>("AvgTotalGuesses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("FiveGuessesInRound")
                        .HasColumnType("float");

                    b.Property<double>("FourGuessesInRound")
                        .HasColumnType("float");

                    b.Property<int?>("MissedEntriesInRound")
                        .HasColumnType("int");

                    b.Property<int?>("MissedEntriesTotal")
                        .HasColumnType("int");

                    b.Property<int?>("MissesInRound")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OneGuessInRound")
                        .HasColumnType("float");

                    b.Property<int?>("OverallGamesPlayed")
                        .HasColumnType("int");

                    b.Property<int?>("Round")
                        .HasColumnType("int");

                    b.Property<decimal?>("RoundWinPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("SixGuessesInRound")
                        .HasColumnType("float");

                    b.Property<double>("ThreeGuessesInRound")
                        .HasColumnType("float");

                    b.Property<int?>("TotalGuesses")
                        .HasColumnType("int");

                    b.Property<int?>("TotalRoundTies")
                        .HasColumnType("int");

                    b.Property<int?>("TotalRoundWins")
                        .HasColumnType("int");

                    b.Property<int?>("TotalTies")
                        .HasColumnType("int");

                    b.Property<double>("TwoGuessesInRound")
                        .HasColumnType("float");

                    b.Property<decimal?>("Winpercentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("WordleDashboard.EFModels.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AmountOfGuesses")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid>("Gkey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeOfSubmission")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
