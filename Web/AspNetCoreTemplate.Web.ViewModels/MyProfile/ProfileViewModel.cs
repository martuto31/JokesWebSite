namespace AspNetCoreTemplate.Web.ViewModels.MyProfile
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AspNetCoreTemplate.Data.Models;

    public class ProfileViewModel
    {
        public string User { get; set; }

        public int AllPoints { get; set; }

        public int UploadedVicove { get; set; }

        public DateTime LastOnline { get; set; }

        public ICollection<Badges> Badges { get; set; }

        public ICollection<Vicove> Vicove { get; set; }
    }
}
