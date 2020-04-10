namespace AspNetCoreTemplate.Web.ViewModels
{
    using AspNetCoreTemplate.Data.Models;
    using System;

    public class VicNaDenqViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Creator { get; set; }

        public DateTime Day { get; set; }

        public int Points { get; set; }

        public VicType VicType { get; set; }
    }
}
