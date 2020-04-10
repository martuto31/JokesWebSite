namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class MyProfileController : BaseController
    {
        private IRepository<Account> accountRepository;
        private IRepository<Vicove> vicoveRepository;

        public MyProfileController(
            IRepository<Account> accountRepository,
            IRepository<Vicove> vicoveRepository)
        {
            this.accountRepository = accountRepository;
            this.vicoveRepository = vicoveRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = this.User.Identity.Name;

            var model = this.accountRepository.All()
                .FirstOrDefault(a => a.User == currentUser);

            return this.View(model);
        }
    }
}
