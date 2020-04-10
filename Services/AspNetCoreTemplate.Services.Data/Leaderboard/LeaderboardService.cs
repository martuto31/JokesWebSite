namespace AspNetCoreTemplate.Services.Data.Leaderboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Services.Mapping;

    public class LeaderboardService : ILeaderboardService
    {
        private readonly IRepository<Leaderboard> leaderboardRepository;

        public LeaderboardService(IRepository<Leaderboard> leaderboardRepository)
        {
            this.leaderboardRepository = leaderboardRepository;
        }

        public IQueryable<TViewModel> ShowAll<TViewModel>()
        {
            var leaderboard = this.leaderboardRepository.All()
                .OrderByDescending(x => x.Points)
                .To<TViewModel>();

            return leaderboard;
        }
    }
}
