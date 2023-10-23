using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.Models.DTO.BillDTOs
{
    public class Balance
    {
        public Balance(List<ParticipantTour> participants) 
        {
            TotalBalance = 0;   

            UserBalances.Clear();
            foreach (var participant in participants)
            {
                UserBalance userBalance = new UserBalance
                {
                    UserId = participant.UserId,
                    Due = 0,
                };

                if (participant.Nickname == null || participant.Nickname.Length == 0)
                {
                    userBalance.Name = participant.User.FullName;
                }
                else
                    userBalance.Name = participant.Nickname;

                UserBalances.Add(userBalance);
            }
        }

        public decimal TotalBalance { get; set; }
        public ICollection<UserBalance> UserBalances { get; set; } = new List<UserBalance>();
    }

    public class UserBalance
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Due { get; set; }
    }
}
