using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.ViewModels
{
    public class UsersWithPaginationViewModel
    {
        public IEnumerable<UsersViewModel> Users { get; set; } 
        public PageViewModel PageViewModel { get; set; }
    }
}
