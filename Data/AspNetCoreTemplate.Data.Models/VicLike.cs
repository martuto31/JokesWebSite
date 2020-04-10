namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class VicLike
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VicId { get; set; } // ?

        public string UserAgent { get; set; }

        public string IPAdress { get; set; }

        [Required]
        public bool UserLike { get; set; }

        public Vicove Vic { get; set; }
    }
}
