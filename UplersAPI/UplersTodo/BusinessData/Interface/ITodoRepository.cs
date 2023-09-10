using BusinessEntities;
using BusinessModel.Request;
using BusinessModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interface
{
     public interface ITodoRepository
    {
        List<GetToDoViewModel> GetTodos(GetTodoRequest request);

        bool DeleteTodo(AddUpdateToDoRequest todo);
        bool AddUpdateTodo(AddUpdateToDoRequest todo);

        bool UpdateTodoAsCompleted(AddUpdateToDoRequest request);
    }
}
