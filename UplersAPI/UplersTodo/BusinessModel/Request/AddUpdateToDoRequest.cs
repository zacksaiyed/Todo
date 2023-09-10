using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Request
{
    public class AddUpdateToDoRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsDeleted { get; set; }
        public string Action { get; set; }
    }
}
