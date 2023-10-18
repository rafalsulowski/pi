using Microsoft.EntityFrameworkCore;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.BillModels;
using TripPlanner.Models.Models.CheckListModels;
using TripPlanner.Models.Models.CultureModels;
using TripPlanner.Models.Models.MessageModels;
using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;
using TripPlanner.Models.Models.RouteModels;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<BillContributor> BillContributors { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<CheckListField> CheckListFields { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ParticipantTour> ParticipantTours { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<QuestionnaireAnswer> QuestionnaireAnswers { get; set; }
        public DbSet<QuestionnaireVote> QuestionnaireVotes { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Stopover> Stopovers { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<User>()
                .HasMany(sc => sc.ParticipantTours)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(sc => sc.Shares)
                .WithOne(s => s.Creator)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.CreatorId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(sc => sc.BillContributors)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(sc => sc.BillsPayed)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.QuestionnaireVotes)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.CheckLists)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Routes)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Questionnaires)
            //    .WithOne()
            //    .HasForeignKey(u => u.UserId)
            //    .OnDelete(DeleteBehavior.NoAction)
            //    .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            // koniec realcji

            modelBuilder.Entity<User>()
                .Property(s => s.FullName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(s => s.City)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(s => s.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(s => s.Email)
                .IsRequired();
            
            modelBuilder.Entity<User>()
                .Property(s => s.FullAddress)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(s => s.DateOfBirth)
                .IsRequired();
            #endregion

            #region Tour
            modelBuilder.Entity<Tour>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Tour>()
                .HasOne(e => e.Chat)
                .WithOne(e => e.Tour)
                .HasForeignKey<Chat>(e => e.TourId)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .HasMany(sc => sc.Cultures)
                .WithOne(s => s.Tour)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.TourId)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .HasMany(sc => sc.Shares)
                .WithOne(s => s.Tour)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.TourId)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .HasMany(sc => sc.Participants)
                .WithOne(s => s.Tour)
                .HasForeignKey(sc => sc.TourId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .HasMany(u => u.CheckLists)
                .WithOne()
                .HasForeignKey(u => u.TourId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .HasMany(u => u.Routes)
                .WithOne()
                .HasForeignKey(u => u.TourId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .HasMany(u => u.Questionnaires)
                .WithOne()
                .HasForeignKey(u => u.TourId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            // koniec realcji

            modelBuilder.Entity<Tour>()
                .Property(s => s.StartDate)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .Property(s => s.MaxParticipant)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .Property(s => s.EndDate)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .Property(s => s.TargetCountry)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .Property(s => s.Title)
                .IsRequired();
            #endregion

            #region Bill
            modelBuilder.Entity<Bill>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Bill>()
                .HasMany(sc => sc.Contributors)
                .WithOne(s => s.Bill)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.BillId)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .HasOne(sc => sc.Payer)
                .WithOne(sc => sc.Bill)
                .HasForeignKey<BillContributor>(sc => sc.BillId)
                .IsRequired(); //TODO sprawdzic czy dziala
            // koniec realcji

            modelBuilder.Entity<Bill>()
                .Property(s => s.CreatedDate)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .Property(s => s.BillType)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .Property(s => s.ImageFilePath)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .Property(s => s.Value)
                .IsRequired();
            #endregion

            #region Transfer
            modelBuilder.Entity<Transfer>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Transfer>()
                .HasOne(sc => sc.Sender)
                .WithOne(sc => sc.Transfer)
                .HasForeignKey<TransferContributor>(sc => sc.TransferId)
                .IsRequired(); //TODO sprawdzic czy dziala

            modelBuilder.Entity<Transfer>()
                .HasOne(sc => sc.Recipient)
                .WithOne(sc => sc.Transfer)
                .HasForeignKey<TransferContributor>(sc => sc.TransferId)
                .IsRequired(); //TODO sprawdzic czy dziala
            // koniec realcji

            modelBuilder.Entity<Bill>()
                .Property(s => s.CreatedDate)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .Property(s => s.BillType)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .Property(s => s.ImageFilePath)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .Property(s => s.Value)
                .IsRequired();
            #endregion

            #region BillContributor
            modelBuilder.Entity<BillContributor>().HasKey(sc => new { sc.UserId, sc.BillId });

            modelBuilder.Entity<BillContributor>()
                .Property(s => s.Value)
                .IsRequired();
            #endregion

            #region TransferContributor
            modelBuilder.Entity<TransferContributor>().HasKey(sc => new { sc.UserId, sc.TransferId});
            #endregion

            #region Chat
            modelBuilder.Entity<Chat>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Chat>()
                .HasMany(sc => sc.Messages)
                .WithOne(s => s.Chat)
                .HasForeignKey(sc => sc.ChatId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            // koniec realcji
            #endregion

            #region CheckList
            modelBuilder.Entity<CheckList>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<CheckList>()
                .HasMany(sc => sc.Fields)
                .WithOne(s => s.CheckList)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.CheckListId)
                .IsRequired();

            modelBuilder.Entity<CheckList>()
                .HasOne(u => u.User)
                .WithMany(u => u.CheckLists)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<CheckList>()
                .HasOne(u => u.Tour)
                .WithMany(u => u.CheckLists)
                .HasForeignKey(u => u.TourId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            // koniec realcji

            modelBuilder.Entity<CheckList>()
                .Property(s => s.IsPublic)
                .IsRequired();

            modelBuilder.Entity<CheckList>()
                .Property(s => s.Name)
                .IsRequired();
            #endregion

            #region CheckListField
            modelBuilder.Entity<CheckListField>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<CheckListField>()
                .Property(s => s.IsChecked)
                .IsRequired();

            modelBuilder.Entity<CheckListField>()
                .Property(s => s.Multiplicity)
                .IsRequired();

            modelBuilder.Entity<CheckListField>()
                .Property(s => s.Name)
                .IsRequired();
            #endregion

            #region Culture
            modelBuilder.Entity<Culture>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Culture>()
                .HasMany(sc => sc.CultureAssistances)
                .WithOne(s => s.Culture)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.CultureId)
                .IsRequired();
            // koniec realcji

            modelBuilder.Entity<Culture>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<Culture>()
                .Property(s => s.Description)
                .IsRequired();

            modelBuilder.Entity<Culture>()
                .Property(s => s.Country)
                .IsRequired();

            modelBuilder.Entity<Culture>()
                .Property(s => s.Religion)
                .IsRequired();

            modelBuilder.Entity<Culture>()
                .Property(s => s.Goverment)
                .IsRequired();

            modelBuilder.Entity<Culture>()
                .Property(s => s.GeograpInformation)
                .IsRequired();

            modelBuilder.Entity<Culture>()
                .Property(s => s.Manners)
                .IsRequired();

            modelBuilder.Entity<Culture>()
                .Property(s => s.LanguageAssistance)
                .IsRequired();

            modelBuilder.Entity<Culture>()
                .Property(s => s.ProperBehaviour)
                .IsRequired();
            #endregion

            #region CultureAssistance
            modelBuilder.Entity<CultureAssistance>().HasKey(sc => new { sc.CultureId, sc.TourId });

            modelBuilder.Entity<CultureAssistance>()
                .Property(s => s.IsPrincipal)
                .IsRequired();
            #endregion

            #region TextMessage
            modelBuilder.Entity<TextMessage>()
                .HasKey(e => e.Id);

            //relacje
            //koniec relacji

            modelBuilder.Entity<TextMessage>()
                .Property(s => s.Content)
                .IsRequired();

            modelBuilder.Entity<TextMessage>()
                .Property(s => s.Date)
                .IsRequired();
            #endregion

            #region NoticeMessage
            modelBuilder.Entity<NoticeMessage>()
                .HasKey(e => e.Id);

            //relacje
            //koniec relacji

            modelBuilder.Entity<NoticeMessage>()
                .Property(s => s.Content)
                .IsRequired();

            modelBuilder.Entity<NoticeMessage>()
                .Property(s => s.Date)
                .IsRequired();
            #endregion

            #region ParticipantTour
            modelBuilder.Entity<ParticipantTour>().HasKey(sc => new { sc.UserId, sc.TourId });
            #endregion

            #region Questionnaire
            modelBuilder.Entity<Questionnaire>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Questionnaire>()
                .HasMany(sc => sc.Answers)
                .WithOne(s => s.Questionnaire)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.QuestionnaireId)
                .IsRequired();

            modelBuilder.Entity<Questionnaire>()
               .HasOne(u => u.Tour)
               .WithMany(u => u.Questionnaires)
               .HasForeignKey(u => u.TourId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();

            //modelBuilder.Entity<Questionnaire>()
            //   .HasOne(u => u.User)
            //   .WithMany(u => u.Questionnaires)
            //   .HasForeignKey(u => u.UserId)
            //   .OnDelete(DeleteBehavior.NoAction)
            //   .IsRequired();
            // koniec realcji

            modelBuilder.Entity<Questionnaire>()
                .Property(s => s.Content)
                .IsRequired();

            modelBuilder.Entity<Questionnaire>()
                .Property(s => s.Date)
                .IsRequired();
            #endregion

            #region QuestionnaireAnswer
            modelBuilder.Entity<QuestionnaireAnswer>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<QuestionnaireAnswer>()
                .HasMany(sc => sc.Votes)
                .WithOne(s => s.QuestionnaireAnswer)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.QuestionnaireAnswerId)
                .IsRequired();
            // koniec realcji

            modelBuilder.Entity<QuestionnaireAnswer>()
                .Property(s => s.Answer)
                .IsRequired();
            #endregion

            #region QuestionnaireVote
            modelBuilder.Entity<QuestionnaireVote>().HasKey(sc => new { sc.UserId, sc.QuestionnaireAnswerId });

            //relacje
            modelBuilder.Entity<QuestionnaireVote>()
               .HasOne(u => u.User)
               .WithMany(u => u.QuestionnaireVotes)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            //koniec relacji
            #endregion

            #region Route
            modelBuilder.Entity<Route>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Route>()
                .HasMany(sc => sc.Stopovers)
                .WithOne(s => s.Route)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.RouteId)
                .IsRequired();

            modelBuilder.Entity<Route>()
               .HasOne(u => u.User)
               .WithMany(u => u.Routes)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();

            modelBuilder.Entity<Route>()
               .HasOne(u => u.Tour)
               .WithMany(u => u.Routes)
               .HasForeignKey(u => u.TourId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            // koniec realcji

            modelBuilder.Entity<Route>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<Route>()
                .Property(s => s.StartLocation)
                .IsRequired();

            modelBuilder.Entity<Route>()
                .Property(s => s.StartDate)
                .IsRequired();

            modelBuilder.Entity<Route>()
                .Property(s => s.ArriveDate)
                .IsRequired();

            modelBuilder.Entity<Route>()
                .Property(s => s.ArriveLocation)
                .IsRequired();
            #endregion

            #region Stopover
            modelBuilder.Entity<Stopover>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Stopover>()
                .Property(s => s.BreakTime)
                .IsRequired();

            modelBuilder.Entity<Stopover>()
                .Property(s => s.Description)
                .IsRequired();

            modelBuilder.Entity<Stopover>()
                .Property(s => s.Location)
                .IsRequired();

            modelBuilder.Entity<Stopover>()
                .Property(s => s.Name)
                .IsRequired();
            #endregion
        }
    }
}
