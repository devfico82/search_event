using System.Collections.Generic;
using search_event.Models;

namespace search_event.Models.ViewModels
{
    public class EaventsListViewModel
    {
        public IEnumerable<Eavent> Eavents { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}