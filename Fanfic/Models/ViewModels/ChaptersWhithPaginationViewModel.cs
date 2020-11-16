using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.ViewModels
{
    public class ChaptersWhithPaginationViewModel
    {
        public IEnumerable<Chapter> Chapters { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
