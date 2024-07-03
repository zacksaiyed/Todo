using BusinessData.Interface;
using BusinessModel.Request;
using BusinessModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Services
{
    public class UndoRepo : ITodoRepository
    {
        public bool AddUpdateTodo(AddUpdateToDoRequest todo)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTodo(AddUpdateToDoRequest todo)
        {
            throw new NotImplementedException();
        }

        public List<GetToDoViewModel> GetTodos(GetTodoRequest request)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTodoAsCompleted(AddUpdateToDoRequest request)
        {
            throw new NotImplementedException();
        }
    }

   
}
