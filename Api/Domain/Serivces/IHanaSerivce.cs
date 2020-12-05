using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Serivces
{
    public interface IHanaSerivce
    {
        Task<Session> PostLogin(LoginDetails loginDetails);

        Task<BusinessPartnersDto> GetBusinessPartners();
    }
}
