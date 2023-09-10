using BusinessData.Interface;
using BusinessData.Services;
using BusinessModel.Request;
using BusinessModel.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UplersTodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public ToDoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpPost("GetToDos")]
        public ActionResult<GetToDoResponse> GetTodo([FromBody] GetTodoRequest request)
        {

            var data =_todoRepository.GetTodos(request);

            return new GetToDoResponse {Todos=data };
        }

        [HttpPost("AddOrUpdateToDo")]
        public ActionResult<AddUpdateToDoResponse> AddOrUpdateToDo([FromBody]  AddUpdateToDoRequest request)
        {

            var data = _todoRepository.AddUpdateTodo(request);

            return new AddUpdateToDoResponse { IsRecordedAffected = data };
        }

        [HttpPost("DeleteToDo")]
        public ActionResult<AddUpdateToDoResponse> DeleteToDo([FromBody] AddUpdateToDoRequest request)
        {

            var data = _todoRepository.DeleteTodo(request);

            return new AddUpdateToDoResponse { IsRecordedAffected = data };
        }

        [HttpPost("UpdateTodoAsCompleted")]
        public ActionResult<AddUpdateToDoResponse> UpdateTodoAsCompleted([FromBody] AddUpdateToDoRequest request)
        {

            var data = _todoRepository.UpdateTodoAsCompleted(request);

            return new AddUpdateToDoResponse { IsRecordedAffected = data };
        }
    }
}
