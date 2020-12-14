using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Domain.Serivces
{
    public interface IHanaSerivce
    {
        Task<Session> PostLogin(LoginDetails loginDetails);

        Task<BusinessPartnersDto> GetBusinessPartners();

        Task<BPDetails> GetBusinessPartnersById(string id);


        Task<bool> CreateBusinessPartners(BPDetails bp);


        Task<bool> UpdateBusinessPartners(BPDetails bp);


        Task<bool>  DeleteBusinessPartners(string id);


    }
}
