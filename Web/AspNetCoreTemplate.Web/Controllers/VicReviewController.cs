namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data.Vicovete;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AspNetCoreTemplate.Web.ViewModels.Vicove;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Admin")]
    public class VicReviewController : BaseController
    {
        // Da mi zarejda na dadena stranica vsichkite vicove za review i da ima buton udobri,
        // iztrii, s koito da kachvash ili da iztrivash vicovete, kato kachvash, vzimash vica ot review i otiva v realnoto db
        private readonly IRepository<VicForReview> vicReviewRepository;
        private readonly IRepository<Vicove> vicoveRepository;
        private readonly IVicForUploadService vicForUploadService;

        public VicReviewController(IRepository<VicForReview> vicReviewRepository, IRepository<Vicove> vicoveRepository, IVicForUploadService vicForUploadService)
        {
            this.vicReviewRepository = vicReviewRepository;
            this.vicoveRepository = vicoveRepository;
            this.vicForUploadService = vicForUploadService;
        }

        //public async Task<IActionResult> Delete(int? vicId)
        //{
        //    int viccId;
        //    if (vicId.HasValue)
        //    {
        //        viccId = vicId.Value;
        //    }
        //    else
        //    {
        //        viccId = 1;
        //    }

        //    var vic = this.vicReviewRepository.All()
        //        .FirstOrDefault(x => x.Id == viccId);

        //    this.vicReviewRepository.Delete(vic);
        //    await this.vicReviewRepository.SaveChangesAsync();

        //    return this.Ok();
        //}

        //public async Task<IActionResult> UploadVic(int? vicId)
        //{
        //    int viccId;
        //    if (vicId.HasValue)
        //    {
        //        viccId = vicId.Value;
        //    }
        //    else
        //    {
        //        viccId = 1;
        //    }

        //    var vic = this.vicReviewRepository.All()
        //        .FirstOrDefault(x => x.Id == viccId);

        //    var vicForRealDb = new Vicove()
        //    {
        //        Content = vic.Content,
        //        CreatedOn = vic.CreatedOn,
        //        Creator = vic.Creator,
        //        DateTime = vic.DateTime,
        //        VicType = vic.VicType,
        //        Points = 0,
        //    };

        //    await this.vicoveRepository.AddAsync(vicForRealDb);
        //    await this.vicoveRepository.SaveChangesAsync();

        //    this.vicReviewRepository.Delete(vic);
        //    await this.vicReviewRepository.SaveChangesAsync();

        //    return this.Ok();
        //}

        public async Task<IActionResult> ShowAllForReview(int? pageNumber)
        {
            var vicove = this.vicForUploadService.GetAllForUpload<VicReviewViewModel>();

            if (vicove == null)
            {
                return this.NotFound();
            }

            int pageSize = 10;

            var model = await PaginatedList<VicReviewViewModel>.CreateAsync(vicove, pageNumber ?? 1, pageSize);

            return this.View(model);
        }
    }
}
