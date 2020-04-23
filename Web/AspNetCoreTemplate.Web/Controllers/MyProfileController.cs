namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data.MyProfile;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AspNetCoreTemplate.Web.ViewModels.MyProfile;
    using AspNetCoreTemplate.Web.ViewModels.Vicove;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class MyProfileController : BaseController
    {
        private readonly IRepository<Account> accountRepository;
        private readonly IRepository<Vicove> vicoveRepository;
        private readonly IFavVicoveService favVicoveService;

        public MyProfileController(
            IRepository<Account> accountRepository,
            IRepository<Vicove> vicoveRepository,
            IFavVicoveService favVicoveService)
        {
            this.accountRepository = accountRepository;
            this.vicoveRepository = vicoveRepository;
            this.favVicoveService = favVicoveService;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var currentUser = this.User.Identity.Name;

            var acc = this.accountRepository.All()
                .FirstOrDefault(a => a.User == currentUser);

            var vicove = this.favVicoveService.GetMyVicove<VicoveViewModel>(acc.User);

            this.ViewData["user"] = acc.User;
            this.ViewData["allPoints"] = acc.AllPoints;
            this.ViewData["uploadedVicove"] = acc.UploadedVicove;

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Favourite(int? pageNumber)
        {
            var currentUser = this.User.Identity.Name;

            var acc = this.accountRepository.All()
                .FirstOrDefault(a => a.User == currentUser);

            var vicove = this.favVicoveService.GetFavouriteVicove<VicoveViewModel>(acc.Id);

            this.ViewData["user"] = acc.User;
            this.ViewData["allPoints"] = acc.AllPoints;
            this.ViewData["uploadedVicove"] = acc.UploadedVicove;

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }
    }
}
