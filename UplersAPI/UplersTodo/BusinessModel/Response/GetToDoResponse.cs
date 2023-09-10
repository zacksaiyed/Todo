using BusinessModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Response
{
    public class GetToDoResponse
    {
        public List<GetToDoViewModel> Todos { get; set; }
    }
}
