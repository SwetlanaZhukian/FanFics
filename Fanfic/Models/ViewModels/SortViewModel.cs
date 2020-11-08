using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.ViewModels
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; }
        public SortState DescriptionSort { get; private set; }
        public SortState GenreSort { get; private set; }
        public SortState DateOfCreationSort { get; private set; }
        public SortState NumberOfChaptersSort { get; private set; }
        public SortState Current { get; private set; }
        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            DescriptionSort = sortOrder == SortState.DescriptionAsc ? SortState.DescriptionDesc : SortState.DescriptionAsc;
            GenreSort = sortOrder == SortState.GenreAsc ? SortState.GenreDesc : SortState.GenreAsc;
            DateOfCreationSort = sortOrder == SortState.DateOfCreationAsc ? SortState.DateOfCreationDesc : SortState.DateOfCreationAsc;
            NumberOfChaptersSort = sortOrder == SortState.NumberOfChaptersAsc ? SortState.NumberOfChaptersDesc : SortState.NumberOfChaptersAsc;
            Current = sortOrder;
        }
    }
}
