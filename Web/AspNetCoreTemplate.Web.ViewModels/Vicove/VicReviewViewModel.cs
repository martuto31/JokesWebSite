namespace AspNetCoreTemplate.Web.ViewModels.Vicove
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.Infrastructure;
    using AutoMapper;

    public class VicReviewViewModel : IMapFrom<VicForReview>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Това поле е задължително")]
        [StringLength(3500, ErrorMessage = "Съдържанието е твърде голямо")]
        public string Content { get; set; }

        public int Points { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Моля изберете категория")]
        public VicType VicType { get; set; }

        public string User { get; set; }

        public string Creator { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<VicForReview, PaginatedList<VicReviewViewModel>>();
        }
    }
}
