using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VIS360.Core.Entities;
using VIS360.Core.Interfaces;
using VIS360.Core.ViewModels;
using VIS360.Infrastructure;

namespace VIS360.Common.Services
{
    public class UserService : IUserService
    {
        public Context _context { get; set; }

        public UserService(Context context)
        {
            _context = context;
        }

        public async Task<HttpStatusCode> RegisterUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<User> GetUserByID(string userID)
        {
            var user = await _context.Users.Where(u => u.Ud == userID).SingleOrDefaultAsync();
            return user;
        }

        

        public async Task<HttpStatusCode> AddUserBasicInfo(UserInfo info)
        {
            _context.UserInfos.Add(info);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<Demographic> AddDemographicInfo(DemographicIndustryRoomateVM demographic)
        {
            var demo = new Demographic();
            demo.User = demographic.User;
            demo.City = demographic.City;
            demo.Country = demographic.Country;
            demo.Gender = demographic.Gender;
            demo.Age = demographic.Age;
            demo.FamilyStatus = demographic.FamilyStatus;
            demo.Work = demographic.Work;
            demo.Roommates = demographic.Roommates;
            demo.FinancialStatus = demographic.FinancialStatus;
            _context.Demographics.Add(demo);
            await _context.SaveChangesAsync();            
            await _context.SaveChangesAsync();
            return demo;
        }

        public async Task<HttpStatusCode> AddVirusStatus(CovidStatus status)
        {
            _context.CovidStatuses.Add(status);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<User> ReturnUser(string ID)
        {
            //var user = await _context.Users.Where(u => u.Ud == Ud).SingleOrDefaultAsync();
            var user = await _context.Users.Include(k => k.CovidStatuses)
                .Include(k=> k.Demographic.RoomateRelations)
                .Include(k => k.Demographic.Industries)
                .Include(k => k.OtherMembers)
                .Include(k => k.CovidStatuses)
                .Include(k => k.UserInfo)
                .Include(m => m.DiseaseStatements).Where(u =>u.Ud == ID)
                .SingleOrDefaultAsync();
            //var covidstatuses = await _context.CovidStatuses.Where(u => u.Ud == Ud).ToListAsync();
            //user.CovidStatuses = covidstatuses;
            return user;
        }

        public async Task<HttpStatusCode> AddDiseaseStatement(DiseaseStatement disease)
        {
           _context.DiseaseStatements.Add(disease);
           await _context.SaveChangesAsync();
           return HttpStatusCode.Accepted;
        }

        public async Task<HttpStatusCode> AddHelp(Help help)
        {
            _context.Helps.Add(help);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<HttpStatusCode> AddHelpOffer(HelpOffer helpOffer)
        {
            _context.HelpOffers.Add(helpOffer);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<HttpStatusCode> AddOtherMember(OtherMember member)
        {
            _context.OtherMembers.Add(member);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<HttpStatusCode> AddRelInd(List<RoomateRelation> relations, List<Industry> industries,Demographic demographic)
        {
            foreach (var rel in relations)
            {
                rel.DemographicID = demographic.UserID;
                _context.RoomateRelations.Add(rel);
            }
            foreach (var ind in industries)
            {
                ind.DemographicID = demographic.UserID;
                _context.Industries.Add(ind);
            }
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<Demographic> ReturnDemo(User user)
        {
            var demo = await _context.Demographics.Where(u => u.User == user).SingleOrDefaultAsync();
            return demo;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).SingleOrDefaultAsync();
            return user;
        }

        public async Task<List<OtherMember>> ReturnMembers(string ID)
        {
            var members = await _context.OtherMembers.Where(o => o.UserID == ID).ToListAsync();
            if (members.Count != 0)
            {
                foreach (var mem in members)
                {
                    
                }
            }
            return members;
        }
    }
}
