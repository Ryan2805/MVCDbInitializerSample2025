﻿// <auto-generated />
using System;
using ClassLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCDbInitializerSample2025.Data.Migrations.ClubMigrations
{
    [DbContext(typeof(ClubsContext))]
    partial class ClubsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClassLib.Models.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubId"));

                    b.Property<string>("ClubName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<int>("adminID")
                        .HasColumnType("int");

                    b.HasKey("ClubId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("ClassLib.Models.ClubEvent", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventID"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventID");

                    b.HasIndex("ClubId");

                    b.ToTable("ClubEvent");
                });

            modelBuilder.Entity("ClassLib.Models.EventAttendnace", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AttendeeMember")
                        .HasColumnType("int");

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AttendeeMember");

                    b.HasIndex("EventID");

                    b.ToTable("EventAttendances");
                });

            modelBuilder.Entity("ClassLib.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberID"));

                    b.Property<int>("AssociatedClub")
                        .HasColumnType("int");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("approved")
                        .HasColumnType("bit");

                    b.HasKey("MemberID");

                    b.HasIndex("AssociatedClub");

                    b.HasIndex("StudentID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("ClassLib.Models.Student", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ClassLib.Models.ClubEvent", b =>
                {
                    b.HasOne("ClassLib.Models.Club", "associatedClub")
                        .WithMany("clubEvents")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("associatedClub");
                });

            modelBuilder.Entity("ClassLib.Models.EventAttendnace", b =>
                {
                    b.HasOne("ClassLib.Models.Member", "memberAttending")
                        .WithMany()
                        .HasForeignKey("AttendeeMember");

                    b.HasOne("ClassLib.Models.ClubEvent", "associatedEvent")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("associatedEvent");

                    b.Navigation("memberAttending");
                });

            modelBuilder.Entity("ClassLib.Models.Member", b =>
                {
                    b.HasOne("ClassLib.Models.Club", "myClub")
                        .WithMany("clubMembers")
                        .HasForeignKey("AssociatedClub")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLib.Models.Student", "studentMember")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("myClub");

                    b.Navigation("studentMember");
                });

            modelBuilder.Entity("ClassLib.Models.Club", b =>
                {
                    b.Navigation("clubEvents");

                    b.Navigation("clubMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
