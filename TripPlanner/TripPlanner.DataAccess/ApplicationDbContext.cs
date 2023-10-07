using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TripPlanner.Models;
using TripPlanner.Models.Models.Message;

namespace TripPlanner.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillPicture> BillPictures { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetExpenditure> BudgetExpenditures { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<CheckListField> CheckListFields { get; set; }
        public DbSet<ContributeBudget> ContributeBudgets { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<CultureAssistance> CultureAssistances { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ParticipantBill> ParticipantBills { get; set; }
        public DbSet<ParticipantGroup> ParticipantGroups { get; set; }
        public DbSet<ParticipantTour> ParticipantTours { get; set; }
        public DbSet<OrganizerTour> OrganizerTours { get; set; }
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
                .HasMany(sc => sc.OrganizerTours)
                .WithOne(s => s.User)
                .HasForeignKey(sc => sc.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.ParticipantGroups)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.ParticipantBudgets)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.QuestionnaireVotes)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.BillSettle)
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

            modelBuilder.Entity<User>()
                .HasMany(u => u.Questionnaires)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Bills)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            // koniec realcji

            modelBuilder.Entity<User>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(s => s.Surname)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(s => s.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(s => s.Email)
                .IsRequired();
            
            modelBuilder.Entity<User>()
                .Property(s => s.Address)
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
                .HasOne(e => e.Budget)
                .WithOne(e => e.Tour)
                .HasForeignKey<Budget>(e => e.TourId)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .HasMany(sc => sc.CultureAssistances)
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
                .HasMany(u => u.Organizers)
                .WithOne()
                .HasForeignKey(u => u.TourId)
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

            modelBuilder.Entity<Tour>()
                .HasMany(u => u.Bills)
                .WithOne()
                .HasForeignKey(u => u.TourId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Tour>()
                .HasMany(u => u.Groups)
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
                .HasMany(sc => sc.Participants)
                .WithOne(s => s.Bill)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.BillId)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .HasOne(u => u.User)
                .WithMany(u => u.Bills)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .HasOne(u => u.Tour)
                .WithMany(u => u.Bills)
                .HasForeignKey(u => u.TourId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .HasMany(sc => sc.Pictures)
                .WithOne(s => s.Bill)
                .HasForeignKey(sc => sc.BillId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            // koniec realcji

            modelBuilder.Entity<Bill>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<Bill>()
                .Property(s => s.Ammount)
                .HasColumnType("decimal(6,2)")
                .IsRequired();
            #endregion

            #region BillPicture
            modelBuilder.Entity<BillPicture>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<BillPicture>()
                .Property(s => s.FilePath)
                .IsRequired();
            #endregion

            #region Budget
            modelBuilder.Entity<Budget>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Budget>()
                .HasMany(sc => sc.Contributes)
                .WithOne(s => s.Budget)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.BudgetId)
                .IsRequired();

            modelBuilder.Entity<Budget>()
                .HasMany(sc => sc.Expenditures)
                .WithOne(s => s.Budget)
                .HasForeignKey(sc => sc.BudgetId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            // koniec realcji

            modelBuilder.Entity<Budget>()
                .Property(s => s.AccountNumber)
                .IsRequired();

            modelBuilder.Entity<Budget>()
                .Property(s => s.ActualPeyments)
                .HasColumnType("decimal(7,2)")
                .IsRequired();

            modelBuilder.Entity<Budget>()
                .Property(s => s.Capital)
                .HasColumnType("decimal(7,2)")
                .IsRequired();

            modelBuilder.Entity<Budget>()
                .Property(s => s.PaymentsDeadline)
                .IsRequired();

            modelBuilder.Entity<Budget>()
                .Property(s => s.Log)
                .IsRequired();

            modelBuilder.Entity<Budget>()
                .Property(s => s.Currency)
                .IsRequired();
            #endregion

            #region BudgetExpenditure
            modelBuilder.Entity<BudgetExpenditure>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<BudgetExpenditure>()
                .Property(s => s.Cost)
                .HasColumnType("decimal(6,2)")
                .IsRequired();

            modelBuilder.Entity<BudgetExpenditure>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<BudgetExpenditure>()
                .Property(s => s.Description)
                .IsRequired();
            #endregion

            #region Chat
            modelBuilder.Entity<Chat>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Chat>()
                .HasMany(sc => sc.Questionnaires)
                .WithOne(s => s.Chat)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.ChatId)
                .IsRequired(false);

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

            #region ContributesBudget
            modelBuilder.Entity<ContributeBudget>().HasKey(sc => new { sc.BudgetId, sc.UserId});

            //relacje
            modelBuilder.Entity<ContributeBudget>()
               .HasOne(u => u.User)
               .WithMany(u => u.ParticipantBudgets)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            //koniec relacji

            modelBuilder.Entity<ContributeBudget>()
                .Property(s => s.Payment)
                .HasColumnType("decimal(6,2)")
                .IsRequired();

            modelBuilder.Entity<ContributeBudget>()
                .Property(s => s.Debt)
                .HasColumnType("decimal(6,2)")
                .IsRequired();
            #endregion

            #region Culture
            modelBuilder.Entity<Culture>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Culture>()
                .HasMany(sc => sc.Tours)
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

            #region Group
            modelBuilder.Entity<Group>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Group>()
                .HasMany(sc => sc.Participants)
                .WithOne(s => s.Group)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(sc => sc.GroupId)
                .IsRequired();

            modelBuilder.Entity<Group>()
                .HasOne(e => e.Chat)
                .WithOne(e => e.Group)
                .HasForeignKey<Chat>(e => e.GroupId)
                .IsRequired();

            modelBuilder.Entity<Group>()
               .HasOne(u => u.Tour)
               .WithMany(u => u.Groups)
               .HasForeignKey(u => u.TourId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            // koniec realcji

            modelBuilder.Entity<Group>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<Group>()
                .Property(s => s.Volume)
                .IsRequired();
            #endregion

            #region Message
            modelBuilder.Entity<Message>()
                .HasKey(e => e.Id);

            //relacje
            modelBuilder.Entity<Message>()
               .HasOne(u => u.User)
               .WithMany(u => u.Messages)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            //koniec relacji

            modelBuilder.Entity<Message>()
                .Property(s => s.Content)
                .IsRequired();

            modelBuilder.Entity<Message>()
                .Property(s => s.Date)
                .IsRequired();
            #endregion

            #region OrganizerTour
            modelBuilder.Entity<OrganizerTour>().HasKey(sc => new { sc.UserId, sc.TourId });
            
            //relacje
            modelBuilder.Entity<OrganizerTour>()
               .HasOne(u => u.Tour)
               .WithMany(u => u.Organizers)
               .HasForeignKey(u => u.TourId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            //koniec relacji
            #endregion

            #region ParticipantBill
            modelBuilder.Entity<ParticipantBill>().HasKey(sc => new { sc.UserId, sc.BillId});

            //relacje
            modelBuilder.Entity<ParticipantBill>()
               .HasOne(u => u.User)
               .WithMany(u => u.BillSettle)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            //koniec relacji

            modelBuilder.Entity<ParticipantBill>()
                .Property(s => s.Payment)
                .HasColumnType("decimal(6,2)")
                .IsRequired();
            modelBuilder.Entity<ParticipantBill>()
                .Property(s => s.Debt)
                .HasColumnType("decimal(6,2)")
                .IsRequired();
            #endregion

            #region ParticipantGroup
            modelBuilder.Entity<ParticipantGroup>().HasKey(sc => new { sc.UserId, sc.GroupId });

            //relacje
            modelBuilder.Entity<ParticipantGroup>()
               .HasOne(u => u.User)
               .WithMany(u => u.ParticipantGroups)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            //koniec relacji

            modelBuilder.Entity<ParticipantGroup>()
                .Property(s => s.IsOrganizer)
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

            modelBuilder.Entity<Questionnaire>()
               .HasOne(u => u.User)
               .WithMany(u => u.Questionnaires)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            // koniec realcji

            modelBuilder.Entity<Questionnaire>()
                .Property(s => s.Question)
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
