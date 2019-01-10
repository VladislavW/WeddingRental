using System.Security.Claims;
using AutoMapper;
using Entities.Identity;
using WeddingRental.Models.User.To;
using WeddingRental.Models.Views.User;

namespace WeddingRental.Configurations.Mapping
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<Claim, ClaimViewModel>();
            CreateMap<SignUpModel, User>()
                .ForMember(d => d.UserName, mo => mo.MapFrom(sm => sm.Email))
                .ForMember(d => d.Id, mo => mo.Ignore())
                .ForMember(d => d.NormalizedUserName, mo => mo.Ignore())
                .ForMember(d => d.NormalizedEmail, mo => mo.Ignore())
                .ForMember(d => d.EmailConfirmed, mo => mo.Ignore())
                .ForMember(d => d.PasswordHash, mo => mo.Ignore())
                .ForMember(d => d.SecurityStamp, mo => mo.Ignore())
                .ForMember(d => d.ConcurrencyStamp, mo => mo.Ignore())
                .ForMember(d => d.PhoneNumber, mo => mo.Ignore())
                .ForMember(d => d.PhoneNumberConfirmed, mo => mo.Ignore())
                .ForMember(d => d.TwoFactorEnabled, mo => mo.Ignore())
                .ForMember(d => d.LockoutEnd, mo => mo.Ignore())
                .ForMember(d => d.LockoutEnabled, mo => mo.Ignore())
                .ForMember(d => d.AccessFailedCount, mo => mo.Ignore());
        }
    }
}