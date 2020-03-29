using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VIS360.Core.Entities;

namespace VIS360.Core.Interfaces
{
    public interface IUserService
    {
        Task<HttpStatusCode> RegisterUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> SearchUser(User userModel);
        Task<User> ReturnUser(int ID);
        Task<HttpStatusCode> AddUserBasicInfo(UserInfo info);
        Task<HttpStatusCode> AddDemographicInfo(Demographic demographic);
        Task<HttpStatusCode> AddVirusStatus(CovidStatus status);
        Task<HttpStatusCode> AddDiseaseStatement(DiseaseStatement disease);
        Task<HttpStatusCode> AddHelp(Help help);
        Task<HttpStatusCode> AddHelpOffer(HelpOffer helpOffer);
    }
}
