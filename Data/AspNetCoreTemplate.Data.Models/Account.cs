namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Account : BaseModel<int>
    {
        public string User { get; set; }

        public int AllPoints { get; set; }

        public int UploadedVicove { get; set; }

        public DateTime LastOnline { get; set; }

        public ICollection<Badges> Badges { get; set; } = new HashSet<Badges>();

        public ICollection<Vicove> Vicove { get; set; } = new HashSet<Vicove>();

        public ICollection<FavouriteVicove> FavouriteVicove { get; set; } = new List<FavouriteVicove>();

        // snimki, roli
    }
}
