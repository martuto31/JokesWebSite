namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Data.Common.Models;

    public class VicForReview : BaseModel<int>
    {
        [Required]
        [MaxLength(300)]
        public string Content { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        public VicType VicType { get; set; }

        public string User { get; set; }

        public string Creator { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
