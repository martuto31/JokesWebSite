namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data.Vicovete;
    using AspNetCoreTemplate.Web.Hubs;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AspNetCoreTemplate.Web.ViewModels.Vicove;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;

    [Controller]
    public class VicoveController : BaseController
    {
        private readonly IVicoveService vicoveService;
        private readonly IRepository<Vicove> repository;

        public VicoveController(IVicoveService vicoveService, IRepository<Vicove> repository)
        {
            this.vicoveService = vicoveService;
            this.repository = repository;
        }

        public async Task<IActionResult> NaiPopulqrni(int? pageNumber)
        {
            var vicove = this.vicoveService.GetAllMostPopular<VicoveViewModel>(10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> NaiNovi(int? pageNumber)
        {
            var vicove = this.vicoveService.GetAllMostRecent<VicoveViewModel>(10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Blondinki(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Blondinki, 10);
            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public IActionResult Create()
        {
            var model = new VicoveViewModel();
            return this.View(model);
        }

        // [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(VicoveViewModel vicovee)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(vicovee);
            }

            var vicove = new Vicove()
            {
                Content = vicovee.Content,
                VicType = vicovee.VicType,
                CreatedOn = DateTime.UtcNow,
                Creator = vicovee.Creator,
                DateTime = DateTime.UtcNow,
                Points = vicovee.Points,
            };

            await this.repository.AddAsync(vicove);
            await this.repository.SaveChangesAsync();

            return this.RedirectToPage("/Home");
        }

        public async Task<IActionResult> Mutri(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Mutri, 10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Ludi(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Ludi, 10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Zhivotni(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Zhivotni, 10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> BaiGanio(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.BaiGanio, 10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> IvanchoIMariika(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.IvanchoIMariika, 10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Laforizmi(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Laforizmi, 10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Mrusni(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Mrusni, 10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Policai(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Policai, 10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> Piqnici(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.Piqnici, 10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        public async Task<IActionResult> CherenHumor(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(VicType.CherenHumor, 10);

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }
    }
}
