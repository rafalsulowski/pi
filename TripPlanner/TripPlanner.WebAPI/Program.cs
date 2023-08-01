
using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.DataAccess;
using TripPlanner.Services.UserService;
using Microsoft.AspNetCore.Identity;
using TripPlanner.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TripPlanner.Services.BillService;
using TripPlanner.Services.BillPictureService;
using TripPlanner.Services.BudgetService;
using TripPlanner.Services.BudgetExpenditureService;
using TripPlanner.Services.ChatService;
using TripPlanner.Services.CheckListService;
using TripPlanner.Services.CheckListFieldService;
using TripPlanner.Services.ContributeBudgetService;
using TripPlanner.Services.CultureService;
using TripPlanner.Services.CultureAssistanceService;
using TripPlanner.Services.GroupService;
using TripPlanner.Services.MessageService;
using TripPlanner.Services.OrganizerTourService;
using TripPlanner.Services.ParticipantBillService;
using TripPlanner.Services.ParticipantGroupService;
using TripPlanner.Services.ParticipantTourService;
using TripPlanner.Services.QuestionnaireService;
using TripPlanner.Services.QuestionnaireAnswerService;
using TripPlanner.Services.QuestionnaireVoteService;
using TripPlanner.Services.RouteService;
using TripPlanner.Services.StopoverService;
using TripPlanner.Services.TourService;

namespace TripPlanner.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Add services to the container.
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = AuthenticationSettings.Issuer,
                    ValidAudience = AuthenticationSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticationSettings.JwtKey))
                };
            });
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            if(System.Environment.MachineName == "RMSULOWSKR")
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("SqlConnectionString")));
            }
            else
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("SqlConnectionStringACERRS")));
            }



            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IBillRepository, BillRepository>();
            builder.Services.AddScoped<IBillPictureRepository, BillPictureRepository>();
            builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
            builder.Services.AddScoped<IBudgetExpenditureRepository, BudgetExpenditureRepository>();
            builder.Services.AddScoped<IChatRepository, ChatRepository>();
            builder.Services.AddScoped<ICheckListRepository, CheckListRepository>();
            builder.Services.AddScoped<ICheckListFieldRepository, CheckListFieldRepository>();
            builder.Services.AddScoped<IContributeBudgetRepository, ContributeBudgetRepository>();
            builder.Services.AddScoped<ICultureRepository, CultureRepository>();
            builder.Services.AddScoped<ICultureAssistanceRepository, CultureAssistanceRepository>();
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            builder.Services.AddScoped<IOrganizerTourRepository, OrganizerTourRepository>();
            builder.Services.AddScoped<IParticipantBillRepository, ParticipantBillRepository>();
            builder.Services.AddScoped<IParticipantGroupRepository, ParticipantGroupRepository>();
            builder.Services.AddScoped<IParticipantTourRepository, ParticipantTourRepository>();
            builder.Services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();
            builder.Services.AddScoped<IQuestionnaireAnswerRepository, QuestionnaireAnswerRepository>();
            builder.Services.AddScoped<IQuestionnaireVoteRepository, QuestionnaireVoteRepository>();
            builder.Services.AddScoped<IRouteRepository, RouteRepository>();
            builder.Services.AddScoped<IStopoverRepository, StopoverRepository>();
            builder.Services.AddScoped<ITourRepository, TourRepository>();


            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IBillService, BillService>();
            builder.Services.AddScoped<IBillPictureService, BillPictureService>();
            builder.Services.AddScoped<IBudgetService, BudgetService>();
            builder.Services.AddScoped<IBudgetExpenditureService, BudgetExpenditureService>();
            builder.Services.AddScoped<IChatService, ChatService>();
            builder.Services.AddScoped<ICheckListService, CheckListService>();
            builder.Services.AddScoped<ICheckListFieldService, CheckListFieldService>();
            builder.Services.AddScoped<IContributeBudgetService, ContributeBudgetService>();
            builder.Services.AddScoped<ICultureService, CultureService>();
            builder.Services.AddScoped<ICultureAssistanceService, CultureAssistanceService>();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IOrganizerTourService, OrganizerTourService>();
            builder.Services.AddScoped<IParticipantBillService, ParticipantBillService>();
            builder.Services.AddScoped<IParticipantGroupService, ParticipantGroupService>();
            builder.Services.AddScoped<IParticipantTourService, ParticipantTourService>();
            builder.Services.AddScoped<IQuestionnaireService, QuestionnaireService>();
            builder.Services.AddScoped<IQuestionnaireAnswerService, QuestionnaireAnswerService>();
            builder.Services.AddScoped<IQuestionnaireVoteService, QuestionnaireVoteService>();
            builder.Services.AddScoped<IRouteService, RouteService>();
            builder.Services.AddScoped<IStopoverService, StopoverService>();
            builder.Services.AddScoped<ITourService, TourService>();

            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}