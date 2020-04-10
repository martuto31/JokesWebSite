namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data.Vicovete;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AspNetCoreTemplate.Web.ViewModels.Vicove;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Controller]
    public class VicoveController : BaseController
    {
        private readonly IVicoveService vicoveService;
        private readonly IRepository<VicForReview> vicReviewRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public VicoveController(IVicoveService vicoveService, IRepository<VicForReview> vicReviewRepository, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.vicoveService = vicoveService;
            this.vicReviewRepository = vicReviewRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> NaiPopulqrni(int? pageNumber)
        {
            var vicove = this.vicoveService.GetAllMostPopular<VicoveViewModel>();

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> NaiNovi(int? pageNumber)
        {
            var vicove = this.vicoveService.GetAllMostRecent<VicoveViewModel>();

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Blondinki(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Blondinki);
            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public IActionResult Create()
        {
            var model = new VicReviewViewModel();
            return this.View(model);
        }

        [AutoValidateAntiforgeryToken]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(VicReviewViewModel vicovee)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(vicovee);
            }

            //var result = await this.roleManager.CreateAsync(new ApplicationRole
            //{
            //    Name = "Admin",
            //});

            //var user = await this.userManager.GetUserAsync(this.User);
            //await this.userManager.AddToRoleAsync(user, "Admin");

            var vicove = new VicForReview()
            {
                Content = vicovee.Content,
                VicType = vicovee.VicType,
                CreatedOn = DateTime.UtcNow,
                Creator = this.User.Identity.Name,
                DateTime = DateTime.UtcNow,
                User = this.User.Identity.Name,
            };

            await this.vicReviewRepository.AddAsync(vicove);
            await this.vicReviewRepository.SaveChangesAsync();

            return this.RedirectToPage("/Home");
        }

        public async Task<IActionResult> Mutri(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Mutri);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Ludi(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Ludi);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Zhivotni(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Zhivotni);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> BaiGanio(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.BaiGanio);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> IvanchoIMariika(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.IvanchoIMariika);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Laforizmi(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Laforizmi);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Mrusni(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Mrusni);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Policai(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Policai);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Piqnici(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Piqnici);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> CherenHumor(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.CherenHumor);

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
