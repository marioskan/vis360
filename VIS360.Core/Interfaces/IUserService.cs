﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VIS360.Core.Entities;
using VIS360.Core.ViewModels;

namespace VIS360.Core.Interfaces
{
    public interface IUserService
    {
        Task<HttpStatusCode> RegisterUser(User user);
        Task<User> GetUserByID(string userID);        
        Task<User> GetUserByEmail(string email);
        Task<User> ReturnUser(string ID);
        Task<HttpStatusCode> AddUserBasicInfo(UserInfo info);
        Task<Demographic> AddDemographicInfo(DemographicIndustryRoomateVM demographic);
        Task<HttpStatusCode> AddVirusStatus(CovidStatus status);
        Task<HttpStatusCode> AddDiseaseStatement(DiseaseStatement disease);
        Task<HttpStatusCode> AddHelp(Help help);
        Task<HttpStatusCode> AddHelpOffer(HelpOffer helpOffer);
        Task<HttpStatusCode> AddOtherMember(OtherMember member);
        Task<HttpStatusCode> AddRelInd(List<RoomateRelation> relations, List<Industry> industries,Demographic demographic);
        Task<Demographic> ReturnDemo(User user);
        Task<List<OtherMember>> ReturnMembers(string ID);
    }
}
