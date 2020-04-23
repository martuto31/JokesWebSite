namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data.SelectVOD;
    using AspNetCoreTemplate.Services.Data.Vicovete;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AspNetCoreTemplate.Web.ViewModels;
    using AspNetCoreTemplate.Web.ViewModels.Vicove;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IVicoveService vicoveService;
        private readonly ISelectVOD selectVODservice;
        private readonly IRepository<VicNaDenq> dailyRepo;
        private readonly IRepository<Vicove> vicoveRepository;
        private readonly IRepository<VicNaDenq> vicNaDenqRepo;

        public HomeController(
            IVicoveService vicoveService,
            IRepository<VicNaDenq> dailyRepo,
            ISelectVOD selectVODserice,
            IRepository<Vicove> vicoveRepository,
            IRepository<VicNaDenq> vicNaDenqRepo)
        {
            this.vicoveService = vicoveService;
            this.dailyRepo = dailyRepo;
            this.selectVODservice = selectVODserice;
            this.vicoveRepository = vicoveRepository;
            this.vicNaDenqRepo = vicNaDenqRepo;
        }

        public IActionResult Index()
        {
            // var vicNaDenq = this.vicoveService.VicNaDenq();

            // if (vicNaDenq == null)
            // {
            //    return this.NotFound();
            // }
            return this.View(/*vicNaDenq*/);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SelectVOD(int? pageNumber)
        {
            var vicove = this.selectVODservice.GetAllFromToday<VicoveViewModel>();

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicoveViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToDaily(int vicId)
        {
            var vic = this.vicoveRepository.All()
                .FirstOrDefault(x => x.Id == vicId);

            var checkIfAlreadyHas = this.vicNaDenqRepo.All().Any(x => x.Day == DateTime.UtcNow.Date.AddDays(1));

            // da sloja da invokeva js v gorniq controller ili da go sloja v signalR Huba
            if (checkIfAlreadyHas)
            {
                return this.Content("Вече е избран виц на деня");
            }
            else
            {
                var dailyVic = new VicNaDenq()
                {
                    Content = vic.Content,
                    Day = DateTime.UtcNow.Date.AddDays(1),
                    VicType = vic.VicType,
                    Points = vic.Points,
                    Creator = vic.Creator,
                    CreatedOn = vic.CreatedOn,
                };

                await this.vicNaDenqRepo.AddAsync(dailyVic);
                await this.vicNaDenqRepo.SaveChangesAsync();
                return this.RedirectToAction("Index");
            }
        }

        public IActionResult Create()
        {
            var model = new VicNaDenqViewModel();
            return this.View(model);
        }

        // [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(VicNaDenqViewModel daily)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(daily);
            }

            var vic = new VicNaDenq()
            {
                Content = daily.Content,
                Day = DateTime.Today,
                VicType = daily.VicType,
            };

            await this.dailyRepo.AddAsync(vic);
            await this.dailyRepo.SaveChangesAsync();

            return this.RedirectToPage("/Home/Index");
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
