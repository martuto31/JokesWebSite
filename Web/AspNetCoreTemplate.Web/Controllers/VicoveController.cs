namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data.Vicovete;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AspNetCoreTemplate.Web.ViewModels.Vicove;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> BlondinkiAsync(int? pageNumber)
        {
            var vicove = this.vicoveService.GetLatestVicove<VicoveViewModel>(10);
            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = vicove.Count();

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, 10);

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
            };

            await this.repository.AddAsync(vicove);
            await this.repository.SaveChangesAsync();

            return this.RedirectToPage("/Home");
        }

        public IActionResult Mutri()
        {
            return this.View();
        }

        public IActionResult Ludi()
        {
            return this.View();
        }

        public IActionResult Zhivotni()
        {
            return this.View();
        }

        public IActionResult BaiGanio()
        {
            return this.View();
        }

        public IActionResult IvanchoIMariika()
        {
            return this.View();
        }

        public IActionResult Laforizmi()
        {
            return this.View();
        }

        public IActionResult Mrusni()
        {
            return this.View();
        }

        public IActionResult Policai()
        {
            return this.View();
        }

        public IActionResult Piqnici()
        {
            return this.View();
        }

        public IActionResult CherenHumor()
        {
            return this.View();
        }
    }
}
