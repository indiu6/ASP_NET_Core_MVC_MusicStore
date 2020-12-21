using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMusicStore.Models
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<Album> albums { get; set; }

        public string userName { get; set; }

        public string authenticationLevel { get; set; }

        public double cartTotal { get; set; }
    }
}
