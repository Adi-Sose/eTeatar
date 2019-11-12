using System;
using System.Collections.Generic;
using System.Text;

namespace eTeatar.Data.Models
{
    public class Avatar:IIsDeleted
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public bool IsDeleted { get; set; }
    }
}
