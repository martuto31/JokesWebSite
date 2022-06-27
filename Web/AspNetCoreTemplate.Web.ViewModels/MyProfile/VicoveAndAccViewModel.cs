namespace AspNetCoreTemplate.Web.ViewModels.MyProfile
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AutoMapper;

    public class VicoveAndAccViewModel : IMapFrom<Vicove>, IMapFrom<Account>, IHaveCustomMappings
    {
        public Account Account { get; set; }

        public IQueryable<Vicove> Vicove { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Vicove, PaginatedList<VicoveAndAccViewModel>>();
            configuration.CreateMap<Account, PaginatedList<VicoveAndAccViewModel>>();
        }
    }
}
