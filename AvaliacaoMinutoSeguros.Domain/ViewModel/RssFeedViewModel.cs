using System.Collections.Generic;

namespace AvaliacaoMinutoSeguros.Domain.ViewModel
{
    public class RssFeedViewModel
    {
        public RssFeedViewModel()
        {
            Items = new List<ItemViewModel>();
        }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public List<ItemViewModel> Items { get; set; }
    }
}
