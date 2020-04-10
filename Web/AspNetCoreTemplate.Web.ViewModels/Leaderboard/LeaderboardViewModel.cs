namespace AspNetCoreTemplate.Web.ViewModels.Leaderboard
{
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AutoMapper;

    public class LeaderboardViewModel : IMapFrom<Leaderboard>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int? Points { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Leaderboard, PaginatedList<LeaderboardViewModel>>();
        }
    }
}
