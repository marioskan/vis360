using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VIS360.Core.Entities;
using VIS360.Core.Interfaces;
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

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).SingleOrDefaultAsync();
            return user;
        }

        public async Task<User> SearchUser(User userModel)
        {
            var user = await _context.Users.Where(u => u.Email == userModel.Email && u.Password == userModel.Password).SingleOrDefaultAsync();
            return user;
        }

        public async Task<HttpStatusCode> AddUserBasicInfo(UserInfo info)
        {
            _context.UserInfos.Add(info);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<HttpStatusCode> AddDemographicInfo(Demographic demographic)
        {
            foreach (var roomRel in demographic.RoomateRelations)
            {
                
            }
            _context.Demographics.Add(demographic);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<HttpStatusCode> AddVirusStatus(CovidStatus status)
        {
            _context.CovidStatuses.Add(status);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<User> ReturnUser(int ID)
        {
            //var user = await _context.Users.Where(u => u.ID == ID).SingleOrDefaultAsync();
            var user = await _context.Users.Include(k => k.CovidStatuses)
                .Include(m => m.DiseaseStatements).Where(u => u.ID == ID)
                .SingleOrDefaultAsync();
            //var covidstatuses = await _context.CovidStatuses.Where(u => u.UserID == ID).ToListAsync();
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
    }
}
