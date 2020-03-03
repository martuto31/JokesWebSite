namespace AspNetCoreTemplate.Web.ViewModels.Vicove
{
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AutoMapper;

    public class VicoveViewModel : IMapFrom<Vicove>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public int Points { get; set; }

        public VicType VicType { get; set; }

        public string Creator { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Vicove, PaginatedList<VicoveViewModel>>();
        }
    }
}
