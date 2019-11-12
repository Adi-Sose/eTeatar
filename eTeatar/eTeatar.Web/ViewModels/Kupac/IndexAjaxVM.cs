using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.Kupac
{
    public class IndexAjaxVM
    {
        public List<Avatar> Avatari { get; set; }
        public class Avatar
        {
            public int Id { get; set; }
            public string Link { get; set; }
            public bool Selected { get; set; }
        }
    }
}
