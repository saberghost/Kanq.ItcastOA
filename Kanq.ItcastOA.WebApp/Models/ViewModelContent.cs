using Kanq.ItcastOA.WebApp.Models.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kanq.ItcastOA.WebApp.Models
{
    public class ViewModelContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentDescription { get; set; }
        public LuceneEnum LuceneEnum { get; set; }
    }
}