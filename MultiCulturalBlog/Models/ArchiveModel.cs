using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiCulturalBlog.Models
{
    public class ArchiveModel
    {
        public string Year { get; set; }
        public int Count { get; set; }
        public List<MonthModel> Months { get; set; }
    }

    public class MonthModel
    {
        public string Month { get; set; }
        public int Count { get; set; }
    }
}
