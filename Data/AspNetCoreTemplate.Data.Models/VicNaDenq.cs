namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Models;

    public class VicNaDenq : BaseModel<int>
    {
        [Required]
        public string Content { get; set; }

        public string Creator { get; set; }

        [DataType(DataType.Date)]
        public DateTime Day { get; set; }

        public int? Points { get; set; }

        public VicType VicType { get; set; }
    }
}
