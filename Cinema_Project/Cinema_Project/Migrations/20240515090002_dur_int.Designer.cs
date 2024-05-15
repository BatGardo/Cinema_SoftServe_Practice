﻿// <auto-generated />
using System;
using Cinema_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cinema_Project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240515090002_dur_int")]
    partial class dur_int
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cinema_Project.Models.Actor", b =>
                {
                    b.Property<int>("ActorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("actor_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ActorID"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthdate");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.HasKey("ActorID");

                    b.ToTable("actor");
                });

            modelBuilder.Entity("Cinema_Project.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Cinema_Project.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("GenreId");

                    b.ToTable("genre");
                });

            modelBuilder.Entity("Cinema_Project.Models.Hall", b =>
                {
                    b.Property<int>("HallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("hall_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HallId"));

                    b.Property<int>("HallNumber")
                        .HasColumnType("integer")
                        .HasColumnName("hall_number");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("boolean")
                        .HasColumnName("is_reserved");

                    b.Property<int>("SeatCount")
                        .HasColumnType("integer")
                        .HasColumnName("seat_count");

                    b.HasKey("HallId");

                    b.ToTable("hall");
                });

            modelBuilder.Entity("Cinema_Project.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MovieId"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Duration")
                        .HasColumnType("integer")
                        .HasColumnName("duration");

                    b.Property<float>("Rating")
                        .HasColumnType("real")
                        .HasColumnName("rating");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("release_date");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("MovieId");

                    b.ToTable("movie");
                });

            modelBuilder.Entity("Cinema_Project.Models.MovieActor", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    b.Property<int>("ActorId")
                        .HasColumnType("integer")
                        .HasColumnName("actor_id");

                    b.Property<int>("MovieActorId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_actor_id");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("movie_actor");
                });

            modelBuilder.Entity("Cinema_Project.Models.MovieGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    b.Property<int>("MovieGenreId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_genre_id");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("movie_genre");
                });

            modelBuilder.Entity("Cinema_Project.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("seat_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SeatId"));

                    b.Property<int>("HallId")
                        .HasColumnType("integer")
                        .HasColumnName("hall_id");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("boolean")
                        .HasColumnName("is_reserved");

                    b.Property<int>("RowNumber")
                        .HasColumnType("integer")
                        .HasColumnName("row_number");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer")
                        .HasColumnName("seat_number");

                    b.HasKey("SeatId");

                    b.HasIndex("HallId");

                    b.ToTable("seat");
                });

            modelBuilder.Entity("Cinema_Project.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ticket_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TicketId"));

                    b.Property<int>("Hall")
                        .HasColumnType("integer")
                        .HasColumnName("hall");

                    b.Property<int>("HallId")
                        .HasColumnType("integer")
                        .HasColumnName("hall_id");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    b.Property<string>("Price")
                        .HasColumnType("text")
                        .HasColumnName("price");

                    b.Property<DateTime>("Showtime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("showtime");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("TicketId");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("ticket");
                });

            modelBuilder.Entity("Cinema_Project.Models.Trailer", b =>
                {
                    b.Property<int>("TrailerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("trailer_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TrailerId"));

                    b.Property<int>("MovieId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("TrailerId");

                    b.HasIndex("MovieId");

                    b.ToTable("trailer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Cinema_Project.Models.MovieActor", b =>
                {
                    b.HasOne("Cinema_Project.Models.Actor", "Actor")
                        .WithMany("MovieActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema_Project.Models.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Cinema_Project.Models.MovieGenre", b =>
                {
                    b.HasOne("Cinema_Project.Models.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema_Project.Models.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Cinema_Project.Models.Seat", b =>
                {
                    b.HasOne("Cinema_Project.Models.Hall", null)
                        .WithMany("Seats")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cinema_Project.Models.Ticket", b =>
                {
                    b.HasOne("Cinema_Project.Models.Hall", null)
                        .WithMany("Tickets")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema_Project.Models.Movie", null)
                        .WithMany("Tickets")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema_Project.Models.AppUser", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cinema_Project.Models.Trailer", b =>
                {
                    b.HasOne("Cinema_Project.Models.Movie", "Movie")
                        .WithMany("Trailers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Cinema_Project.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Cinema_Project.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema_Project.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Cinema_Project.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cinema_Project.Models.Actor", b =>
                {
                    b.Navigation("MovieActors");
                });

            modelBuilder.Entity("Cinema_Project.Models.AppUser", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Cinema_Project.Models.Genre", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("Cinema_Project.Models.Hall", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Cinema_Project.Models.Movie", b =>
                {
                    b.Navigation("MovieActors");

                    b.Navigation("MovieGenres");

                    b.Navigation("Tickets");

                    b.Navigation("Trailers");
                });
#pragma warning restore 612, 618
        }
    }
}
