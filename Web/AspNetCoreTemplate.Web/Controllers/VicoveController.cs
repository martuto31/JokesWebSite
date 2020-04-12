namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Linq;
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

        public string PointsSort { get; set; }

        public string DateSort { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }

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

        public async Task<IActionResult> Blondinki(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Blondinki);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.Blondinki);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.Blondinki);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.Blondinki);
                    break;
            }

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

        public async Task<IActionResult> Mutri(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Mutri);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.Mutri);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.Mutri);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.Mutri);
                    break;
            }

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Ludi(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Ludi);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.Ludi);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.Ludi);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.Ludi);
                    break;
            }

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Zhivotni(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Zhivotni);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.Zhivotni);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.Zhivotni);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.Zhivotni);
                    break;
            }

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> BaiGanio(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.BaiGanio);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.BaiGanio);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.BaiGanio);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.BaiGanio);
                    break;
            }

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> IvanchoIMariika(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.IvanchoIMariika);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.IvanchoIMariika);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.IvanchoIMariika);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.IvanchoIMariika);
                    break;
            }

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Laforizmi(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Laforizmi);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.Laforizmi);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.Laforizmi);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.Laforizmi);
                    break;
            }

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Mrusni(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Mrusni);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.Mrusni);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.Mrusni);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.Mrusni);
                    break;
            }

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Policai(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Policai);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.Policai);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.Policai);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.Policai);
                    break;
            }

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Piqnici(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Piqnici);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.Piqnici);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.Piqnici);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.Piqnici);
                    break;
            }

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> CherenHumor(int? pageNumber, string s)
        {
            this.DateSort = string.IsNullOrEmpty(s) ? "date_desc" : string.Empty;
            this.PointsSort = s == "Points" ? "points_desc" : string.Empty;
            IQueryable<VicoveViewModel> vicove;
            switch (s)
            {
                case "date_desc":
                    vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.CherenHumor);
                    break;
                case "Points":
                    vicove = this.vicoveService.GetByLowestPoints<VicoveViewModel>(VicType.CherenHumor);
                    break;
                case "points_desc":
                    vicove = this.vicoveService.GetByMostPoints<VicoveViewModel>(VicType.CherenHumor);
                    break;
                default:
                    vicove = this.vicoveService.GetNewestVicove<VicoveViewModel>(VicType.CherenHumor);
                    break;
            }

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
