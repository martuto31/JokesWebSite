namespace AspNetCoreTemplate.Web.ViewModels.Vicove
{
    using System;
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AutoMapper;

    public class VicoveViewModel : IMapFrom<Vicove>, IMapFrom<FavouriteVicove> ,IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Points { get; set; }

        public VicType VicType { get; set; }

        public string Creator { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<VicLike> VicLikes { get; set; } // = new HashSet<VicLike>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Vicove, PaginatedList<VicoveViewModel>>();
            configuration.CreateMap<FavouriteVicove, PaginatedList<VicoveViewModel>>();
        }
    }
}
