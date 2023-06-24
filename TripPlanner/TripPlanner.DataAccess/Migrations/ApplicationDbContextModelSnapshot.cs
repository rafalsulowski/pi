﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripPlanner.DataAccess;

#nullable disable

namespace TripPlanner.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TripPlanner.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Ammount")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.HasIndex("UserId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("TripPlanner.Models.BillPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("BillPictures");
                });

            modelBuilder.Entity("TripPlanner.Models.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ActualPeyments")
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal>("Capital")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Log")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentsDeadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId")
                        .IsUnique();

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("TripPlanner.Models.BudgetExpenditure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("BudgetExpenditures");
                });

            modelBuilder.Entity("TripPlanner.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .IsUnique();

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("TripPlanner.Models.CheckList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.HasIndex("UserId");

                    b.ToTable("CheckLists");
                });

            modelBuilder.Entity("TripPlanner.Models.CheckListField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CheckListId")
                        .HasColumnType("int");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<int>("Multiplicity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CheckListId");

                    b.ToTable("CheckListFields");
                });

            modelBuilder.Entity("TripPlanner.Models.ContributeBudget", b =>
                {
                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Debt")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("Payment")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("BudgetId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ContributeBudgets");
                });

            modelBuilder.Entity("TripPlanner.Models.Culture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeograpInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Goverment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageAssistance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manners")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProperBehaviour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cultures");
                });

            modelBuilder.Entity("TripPlanner.Models.CultureAssistance", b =>
                {
                    b.Property<int>("CultureId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrincipal")
                        .HasColumnType("bit");

                    b.HasKey("CultureId", "TourId");

                    b.HasIndex("TourId");

                    b.ToTable("CultureAssistances");
                });

            modelBuilder.Entity("TripPlanner.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("TripPlanner.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TripPlanner.Models.OrganizeTour", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TourId");

                    b.HasIndex("TourId");

                    b.ToTable("OrganizeTours");
                });

            modelBuilder.Entity("TripPlanner.Models.ParticipantBill", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<decimal>("Debt")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("Payment")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("UserId", "BillId");

                    b.HasIndex("BillId");

                    b.ToTable("ParticipantBills");
                });

            modelBuilder.Entity("TripPlanner.Models.ParticipantGroup", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOrganizer")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("ParticipantGroups");
                });

            modelBuilder.Entity("TripPlanner.Models.ParticipantTour", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TourId");

                    b.HasIndex("TourId");

                    b.ToTable("ParticipantTours");
                });

            modelBuilder.Entity("TripPlanner.Models.Questionnaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("TourId");

                    b.HasIndex("UserId");

                    b.ToTable("Questionnaires");
                });

            modelBuilder.Entity("TripPlanner.Models.QuestionnaireAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionnaireId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("QuestionnaireAnswers");
                });

            modelBuilder.Entity("TripPlanner.Models.QuestionnaireVote", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionnaireAnswerId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "QuestionnaireAnswerId");

                    b.HasIndex("QuestionnaireAnswerId");

                    b.ToTable("QuestionnaireVotes");
                });

            modelBuilder.Entity("TripPlanner.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArriveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ArriveLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.HasIndex("UserId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("TripPlanner.Models.Stopover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BreakTime")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Stopovers");
                });

            modelBuilder.Entity("TripPlanner.Models.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxParticipant")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TargetCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TripPlanner.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TripPlanner.Models.Bill", b =>
                {
                    b.HasOne("TripPlanner.Models.Tour", "Tour")
                        .WithMany("Bills")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.BillPicture", b =>
                {
                    b.HasOne("TripPlanner.Models.Bill", "Bill")
                        .WithMany("Pictures")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bill");
                });

            modelBuilder.Entity("TripPlanner.Models.Budget", b =>
                {
                    b.HasOne("TripPlanner.Models.Tour", "Tour")
                        .WithOne("Budget")
                        .HasForeignKey("TripPlanner.Models.Budget", "TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TripPlanner.Models.BudgetExpenditure", b =>
                {
                    b.HasOne("TripPlanner.Models.Budget", "Budget")
                        .WithMany("Expenditures")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("TripPlanner.Models.Chat", b =>
                {
                    b.HasOne("TripPlanner.Models.Group", "Group")
                        .WithOne("Chat")
                        .HasForeignKey("TripPlanner.Models.Chat", "GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("TripPlanner.Models.CheckList", b =>
                {
                    b.HasOne("TripPlanner.Models.Tour", "Tour")
                        .WithMany("CheckLists")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("CheckLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.CheckListField", b =>
                {
                    b.HasOne("TripPlanner.Models.CheckList", "CheckList")
                        .WithMany("Fields")
                        .HasForeignKey("CheckListId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CheckList");
                });

            modelBuilder.Entity("TripPlanner.Models.ContributeBudget", b =>
                {
                    b.HasOne("TripPlanner.Models.Budget", "Budget")
                        .WithMany("Contributes")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("ParticipantBudgets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.CultureAssistance", b =>
                {
                    b.HasOne("TripPlanner.Models.Culture", "Culture")
                        .WithMany("Tours")
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.Tour", "Tour")
                        .WithMany("CultureAssistances")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Culture");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TripPlanner.Models.Group", b =>
                {
                    b.HasOne("TripPlanner.Models.Tour", "Tour")
                        .WithMany("Groups")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TripPlanner.Models.Message", b =>
                {
                    b.HasOne("TripPlanner.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.OrganizeTour", b =>
                {
                    b.HasOne("TripPlanner.Models.Tour", "Tour")
                        .WithMany("Organizers")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("OrganizerTours")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.ParticipantBill", b =>
                {
                    b.HasOne("TripPlanner.Models.Bill", "Bill")
                        .WithMany("Participants")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("BillSettle")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.ParticipantGroup", b =>
                {
                    b.HasOne("TripPlanner.Models.Group", "Group")
                        .WithMany("Participants")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("ParticipantGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.ParticipantTour", b =>
                {
                    b.HasOne("TripPlanner.Models.Tour", "Tour")
                        .WithMany("Participants")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("ParticipantTours")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.Questionnaire", b =>
                {
                    b.HasOne("TripPlanner.Models.Chat", "Chat")
                        .WithMany("Questionnaires")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TripPlanner.Models.Tour", "Tour")
                        .WithMany("Questionnaires")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("Questionnaires")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.QuestionnaireAnswer", b =>
                {
                    b.HasOne("TripPlanner.Models.Questionnaire", "Questionnaire")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionnaireId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Questionnaire");
                });

            modelBuilder.Entity("TripPlanner.Models.QuestionnaireVote", b =>
                {
                    b.HasOne("TripPlanner.Models.QuestionnaireAnswer", "QuestionnaireAnswer")
                        .WithMany("Votes")
                        .HasForeignKey("QuestionnaireAnswerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("QuestionnaireVotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("QuestionnaireAnswer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.Route", b =>
                {
                    b.HasOne("TripPlanner.Models.Tour", "Tour")
                        .WithMany("Routes")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.User", "User")
                        .WithMany("Routes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.Stopover", b =>
                {
                    b.HasOne("TripPlanner.Models.Route", "Route")
                        .WithMany("Stopovers")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TripPlanner.Models.Bill", b =>
                {
                    b.Navigation("Participants");

                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("TripPlanner.Models.Budget", b =>
                {
                    b.Navigation("Contributes");

                    b.Navigation("Expenditures");
                });

            modelBuilder.Entity("TripPlanner.Models.Chat", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Questionnaires");
                });

            modelBuilder.Entity("TripPlanner.Models.CheckList", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("TripPlanner.Models.Culture", b =>
                {
                    b.Navigation("Tours");
                });

            modelBuilder.Entity("TripPlanner.Models.Group", b =>
                {
                    b.Navigation("Chat");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("TripPlanner.Models.Questionnaire", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("TripPlanner.Models.QuestionnaireAnswer", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("TripPlanner.Models.Route", b =>
                {
                    b.Navigation("Stopovers");
                });

            modelBuilder.Entity("TripPlanner.Models.Tour", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Budget");

                    b.Navigation("CheckLists");

                    b.Navigation("CultureAssistances");

                    b.Navigation("Groups");

                    b.Navigation("Organizers");

                    b.Navigation("Participants");

                    b.Navigation("Questionnaires");

                    b.Navigation("Routes");
                });

            modelBuilder.Entity("TripPlanner.Models.User", b =>
                {
                    b.Navigation("BillSettle");

                    b.Navigation("Bills");

                    b.Navigation("CheckLists");

                    b.Navigation("Messages");

                    b.Navigation("OrganizerTours");

                    b.Navigation("ParticipantBudgets");

                    b.Navigation("ParticipantGroups");

                    b.Navigation("ParticipantTours");

                    b.Navigation("QuestionnaireVotes");

                    b.Navigation("Questionnaires");

                    b.Navigation("Routes");
                });
#pragma warning restore 612, 618
        }
    }
}
