namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data.Leaderboard;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AspNetCoreTemplate.Web.ViewModels.Leaderboard;
    using AspNetCoreTemplate.Web.ViewModels.Vicove;
    using Microsoft.AspNetCore.Mvc;

    public class LeaderboardController : BaseController
    {
        private readonly ILeaderboardService leaderboardService;

        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            this.leaderboardService = leaderboardService;
        }

        public async Task<IActionResult> LeaderboardShow(int? pageNumber)
        {
            var leaderboard = this.leaderboardService.ShowAll<LeaderboardViewModel>();

            var model = await PaginatedList<LeaderboardViewModel>.CreateAsync(leaderboard, pageNumber ?? 1, 10);

            return this.View(model);
        }
    }
}
