using BusinessData.Interface;
using BusinessEntities;
using BusinessModel.Request;
using BusinessModel.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Services
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }
        public bool AddUpdateTodo(AddUpdateToDoRequest request)
        {
            var id = new SqlParameter("@Id", request.Id);
            var title = new SqlParameter("@Title", request.Title ?? (object)DBNull.Value);
            var action = new SqlParameter("@Action", request.Action ?? (object)DBNull.Value);

            int value = _context.Database.ExecuteSqlRaw("EXEC USP_AddOrUpdateTitle @Id,@Title,@Action", id, title,action);

            return value > 0;
        }

        public bool DeleteTodo(AddUpdateToDoRequest request)
        {
            var id = new SqlParameter("@Id", request.Id);
            int value = _context.Database.ExecuteSqlRaw("EXEC USP_DeleteTodo @Id", id);
            return value > 0;

        }

        public bool UpdateTodoAsCompleted(AddUpdateToDoRequest request)
        {
            var id = new SqlParameter("@Id", request.Id);
            int value = _context.Database.ExecuteSqlRaw("EXEC USP_UpdateTodoAsCompleted @Id", id);
            return value > 0;

        }

        List<GetToDoViewModel> ITodoRepository.GetTodos(GetTodoRequest request)
        {
            List<GetToDoViewModel> todoList = new List<GetToDoViewModel>();
            var title = new SqlParameter("@Title", request.Title ?? (object)DBNull.Value);
            var data = _context.Todo.FromSqlRaw<TodoEntity>("EXEC USP_GetAllTodoOrByTitle @Title", title).ToList();

            if ((data.Any()))
            {
                foreach (var item in data)
                {
                    todoList.Add(new GetToDoViewModel()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        IsCompleted= (bool)item.IsCompleted
                    });
                }
            }

            return todoList;
        }

    }
}
