namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Models;

    public class FavouriteVicove : BaseModel<int>
    {
        public string Content { get; set; }

        public int? Points { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        public VicType VicType { get; set; }

        public string Creator { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; } = DateTime.UtcNow;

        public ICollection<VicLike> VicLikes { get; set; } = new HashSet<VicLike>(); // ako go mahna

        public int? AccountID { get; set; }

        public Account Account { get; set; }
    }
}
