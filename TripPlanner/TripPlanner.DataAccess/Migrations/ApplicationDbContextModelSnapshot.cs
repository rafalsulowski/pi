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
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("MessageSequence");

            modelBuilder.HasSequence("ShareSequence");

            modelBuilder.Entity("TripPlanner.Models.Models.BillModels.BillContributor", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<decimal>("Due")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("UserId", "BillId");

                    b.HasIndex("BillId");

                    b.ToTable("BillContributors");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.BillModels.Share", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [ShareSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TourId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("TripPlanner.Models.Models.CheckListModels.CheckList", b =>
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

                    b.Property<int?>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.HasIndex("UserId");

                    b.ToTable("CheckLists");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.CheckListModels.CheckListField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CheckListId")
                        .HasColumnType("int");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Multiplicity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CheckListId");

                    b.ToTable("CheckListFields");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.CultureModels.Culture", b =>
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

            modelBuilder.Entity("TripPlanner.Models.Models.CultureModels.CultureAssistance", b =>
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

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [MessageSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.HasIndex("UserId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.QuestionnaireModels.QuestionnaireAnswer", b =>
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

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.QuestionnaireModels.QuestionnaireVote", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionnaireAnswerId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "QuestionnaireAnswerId");

                    b.HasIndex("QuestionnaireAnswerId");

                    b.ToTable("QuestionnaireVotes");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.RouteModels.Route", b =>
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

                    b.Property<int?>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.HasIndex("UserId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.RouteModels.Stopover", b =>
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

            modelBuilder.Entity("TripPlanner.Models.Models.ScheduleModels.ScheduleDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("ScheduleDays");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.ScheduleModels.ScheduleEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScheduleDayId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StopTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleDayId");

                    b.ToTable("ScheduleEvents");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.TourModels.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IconPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.TourModels.ParticipantTour", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AccessionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsOrganizer")
                        .HasColumnType("bit");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "TourId");

                    b.HasIndex("TourId");

                    b.ToTable("ParticipantTours");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.TourModels.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InviteLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxParticipant")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TargetCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeatherCords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.UserModels.Friend", b =>
                {
                    b.Property<int>("Friend2Id")
                        .HasColumnType("int");

                    b.Property<int>("Friend1Id")
                        .HasColumnType("int");

                    b.HasKey("Friend2Id", "Friend1Id");

                    b.HasIndex("Friend1Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.UserModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.BillModels.Bill", b =>
                {
                    b.HasBaseType("TripPlanner.Models.Models.BillModels.Share");

                    b.Property<int>("BillType")
                        .HasColumnType("int");

                    b.Property<int>("PayerId")
                        .HasColumnType("int");

                    b.HasIndex("PayerId");

                    b.ToTable("Bills", (string)null);
                });

            modelBuilder.Entity("TripPlanner.Models.Models.BillModels.Transfer", b =>
                {
                    b.HasBaseType("TripPlanner.Models.Models.BillModels.Share");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Transfers", (string)null);
                });

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.NoticeMessage", b =>
                {
                    b.HasBaseType("TripPlanner.Models.Models.MessageModels.Message");

                    b.ToTable("NoticeMessages", (string)null);
                });

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.QuestionnaireModels.Questionnaire", b =>
                {
                    b.HasBaseType("TripPlanner.Models.Models.MessageModels.Message");

                    b.ToTable("Questionnaires", (string)null);
                });

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.TextMessage", b =>
                {
                    b.HasBaseType("TripPlanner.Models.Models.MessageModels.Message");

                    b.ToTable("TextMessages", (string)null);
                });

            modelBuilder.Entity("TripPlanner.Models.Models.BillModels.BillContributor", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.BillModels.Bill", "Bill")
                        .WithMany("Contributors")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "User")
                        .WithMany("BillContributors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.BillModels.Share", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "Creator")
                        .WithMany("Shares")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.Models.TourModels.Tour", "Tour")
                        .WithMany("Shares")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.CheckListModels.CheckList", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.TourModels.Tour", "Tour")
                        .WithMany("CheckLists")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "User")
                        .WithMany("CheckLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.CheckListModels.CheckListField", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.CheckListModels.CheckList", "CheckList")
                        .WithMany("Fields")
                        .HasForeignKey("CheckListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckList");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.CultureModels.CultureAssistance", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.CultureModels.Culture", "Culture")
                        .WithMany("CultureAssistances")
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.Models.TourModels.Tour", "Tour")
                        .WithMany("Cultures")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Culture");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.Message", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.TourModels.Tour", "Tour")
                        .WithMany("Messages")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.QuestionnaireModels.QuestionnaireAnswer", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.MessageModels.QuestionnaireModels.Questionnaire", "Questionnaire")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionnaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questionnaire");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.QuestionnaireModels.QuestionnaireVote", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.MessageModels.QuestionnaireModels.QuestionnaireAnswer", "QuestionnaireAnswer")
                        .WithMany("Votes")
                        .HasForeignKey("QuestionnaireAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "User")
                        .WithMany("QuestionnaireVotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("QuestionnaireAnswer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.RouteModels.Route", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.TourModels.Tour", "Tour")
                        .WithMany("Routes")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "User")
                        .WithMany("Routes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.RouteModels.Stopover", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.RouteModels.Route", "Route")
                        .WithMany("Stopovers")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.ScheduleModels.ScheduleDay", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.TourModels.Tour", "Tour")
                        .WithMany("Schedule")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.ScheduleModels.ScheduleEvent", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.ScheduleModels.ScheduleDay", "ScheduleDay")
                        .WithMany("Events")
                        .HasForeignKey("ScheduleDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScheduleDay");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.TourModels.Notification", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.TourModels.ParticipantTour", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.TourModels.Tour", "Tour")
                        .WithMany("Participants")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "User")
                        .WithMany("ParticipantTours")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.UserModels.Friend", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "Friend1")
                        .WithMany()
                        .HasForeignKey("Friend1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "Friend2")
                        .WithMany()
                        .HasForeignKey("Friend2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Friend1");

                    b.Navigation("Friend2");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.BillModels.Bill", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "Payer")
                        .WithMany("BillsPayed")
                        .HasForeignKey("PayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Payer");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.BillModels.Transfer", b =>
                {
                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "Recipient")
                        .WithMany("TransfersRecipient")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TripPlanner.Models.Models.UserModels.User", "Sender")
                        .WithMany("TransfersSender")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.CheckListModels.CheckList", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.CultureModels.Culture", b =>
                {
                    b.Navigation("CultureAssistances");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.QuestionnaireModels.QuestionnaireAnswer", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.RouteModels.Route", b =>
                {
                    b.Navigation("Stopovers");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.ScheduleModels.ScheduleDay", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.TourModels.Tour", b =>
                {
                    b.Navigation("CheckLists");

                    b.Navigation("Cultures");

                    b.Navigation("Messages");

                    b.Navigation("Participants");

                    b.Navigation("Routes");

                    b.Navigation("Schedule");

                    b.Navigation("Shares");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.UserModels.User", b =>
                {
                    b.Navigation("BillContributors");

                    b.Navigation("BillsPayed");

                    b.Navigation("CheckLists");

                    b.Navigation("Messages");

                    b.Navigation("Notifications");

                    b.Navigation("ParticipantTours");

                    b.Navigation("QuestionnaireVotes");

                    b.Navigation("Routes");

                    b.Navigation("Shares");

                    b.Navigation("TransfersRecipient");

                    b.Navigation("TransfersSender");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.BillModels.Bill", b =>
                {
                    b.Navigation("Contributors");
                });

            modelBuilder.Entity("TripPlanner.Models.Models.MessageModels.QuestionnaireModels.Questionnaire", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
