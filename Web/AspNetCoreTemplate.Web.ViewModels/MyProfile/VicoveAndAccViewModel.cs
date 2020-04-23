namespace AspNetCoreTemplate.Web.ViewModels.MyProfile
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AutoMapper;

    public class VicoveAndAccViewModel : IMapFrom<Vicove>, IMapFrom<Account>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public int? Points { get; set; }

        public VicType VicType { get; set; }

        public string Creator { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public ICollection<VicLike> VicLikes { get; set; } = new HashSet<VicLike>(); // ako go mahna

        public int? AccountID { get; set; }

        public Account Account { get; set; }

        public string User { get; set; }

        public int AllPoints { get; set; }

        public int UploadedVicove { get; set; }

        public DateTime LastOnline { get; set; }

        public ICollection<Badges> Badges { get; set; }

        public ICollection<Vicove> Vicove { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Vicove, PaginatedList<VicoveAndAccViewModel>>();
            configuration.CreateMap<Account, PaginatedList<VicoveAndAccViewModel>>();
        }
    }
}
