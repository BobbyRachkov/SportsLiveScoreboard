﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsLiveScoreboard.Data;

namespace SportsLiveScoreboard.Data.Migrations
{
    [DbContext(typeof(SportsDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Competitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompetitorFromMatchId");

                    b.Property<bool>("IsActualPerson");

                    b.Property<bool>("IsTheWinnerOfMatch");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("CompetitorFromMatchId");

                    b.HasIndex("RoomId");

                    b.ToTable("Competitors");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Event", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<bool>("IsActive");

                    b.Property<string>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Game.Models.GameRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventId");

                    b.Property<string>("SportName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("GameRooms");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Game.Models.Match", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Competitor1Id");

                    b.Property<int>("Competitor2Id");

                    b.Property<int?>("GameRoomId");

                    b.Property<bool>("IsGamePlayable");

                    b.Property<bool>("IsPeriodPlayable");

                    b.Property<bool>("IsPlayedForTime");

                    b.Property<bool>("IsSetPlayable");

                    b.Property<int?>("LoserId");

                    b.Property<int>("MaxGamesCount");

                    b.Property<int>("MaxSetsCount");

                    b.Property<int>("PeriodNumber");

                    b.Property<int?>("PointsId");

                    b.Property<int>("Status");

                    b.Property<int?>("WinnerId");

                    b.HasKey("Id");

                    b.HasIndex("Competitor1Id");

                    b.HasIndex("Competitor2Id");

                    b.HasIndex("GameRoomId");

                    b.HasIndex("LoserId");

                    b.HasIndex("PointsId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Game.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Competitor1");

                    b.Property<int>("Competitor2");

                    b.Property<string>("MatchId");

                    b.Property<string>("MatchId1");

                    b.Property<int>("SequentialNumber");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("MatchId1");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Identity.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.UserEvents", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("EventId");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvents");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Identity.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Identity.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsLiveScoreboard.Data.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Competitor", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Game.Models.Match", "CompetitorFromMatch")
                        .WithMany()
                        .HasForeignKey("CompetitorFromMatchId");

                    b.HasOne("SportsLiveScoreboard.Data.Models.Game.Models.GameRoom", "Room")
                        .WithMany("Competitors")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Event", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Identity.User", "Owner")
                        .WithMany("Events")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Game.Models.GameRoom", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Event", "Event")
                        .WithMany("Rooms")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Game.Models.Match", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Competitor", "Competitor1")
                        .WithMany("MatchesAsCompetitor1")
                        .HasForeignKey("Competitor1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SportsLiveScoreboard.Data.Models.Competitor", "Competitor2")
                        .WithMany("MatchesAsCompetitor2")
                        .HasForeignKey("Competitor2Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SportsLiveScoreboard.Data.Models.Game.Models.GameRoom")
                        .WithMany("Matches")
                        .HasForeignKey("GameRoomId");

                    b.HasOne("SportsLiveScoreboard.Data.Models.Competitor", "Loser")
                        .WithMany("Losses")
                        .HasForeignKey("LoserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SportsLiveScoreboard.Data.Models.Game.Models.Score", "Points")
                        .WithMany()
                        .HasForeignKey("PointsId");

                    b.HasOne("SportsLiveScoreboard.Data.Models.Competitor", "Winner")
                        .WithMany("Wins")
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.Game.Models.Score", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Game.Models.Match")
                        .WithMany("Games")
                        .HasForeignKey("MatchId");

                    b.HasOne("SportsLiveScoreboard.Data.Models.Game.Models.Match")
                        .WithMany("Sets")
                        .HasForeignKey("MatchId1");
                });

            modelBuilder.Entity("SportsLiveScoreboard.Data.Models.UserEvents", b =>
                {
                    b.HasOne("SportsLiveScoreboard.Data.Models.Event", "Event")
                        .WithMany("Moderators")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsLiveScoreboard.Data.Models.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
