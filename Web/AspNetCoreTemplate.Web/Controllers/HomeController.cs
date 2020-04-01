namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
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
        private readonly IRepository<VicNaDenq> dailyRepo;

        public HomeController(IVicoveService vicoveService, IRepository<VicNaDenq> dailyRepo)
        {
            this.vicoveService = vicoveService;
            this.dailyRepo = dailyRepo;
        }

        public IActionResult Index()
        {
            var vicNaDenq = this.vicoveService.VicNaDenq();

            if (vicNaDenq == null)
            {
                return this.NotFound();
            }

            return this.View(vicNaDenq);
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
