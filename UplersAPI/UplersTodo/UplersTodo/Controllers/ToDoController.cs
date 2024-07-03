using BusinessData.Interface;
using BusinessData.Services;
using BusinessModel.Request;
using BusinessModel.Response;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using UplersTodo.Extension;

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

            ITodoRepository todoRepository = new UndoRepo();

            todoRepository.AddUpdateTodo(null);

            var data = _todoRepository.GetTodos(request);

            return new GetToDoResponse { Todos = data };
        }

        [HttpPost("AddOrUpdateToDo")]
        public ActionResult<AddUpdateToDoResponse> AddOrUpdateToDo([FromBody] AddUpdateToDoRequest request)
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

        [HttpPost("GetLeaftLinkCustomer")]
        public IActionResult GetLeaftLinkCustomer()
        {
            var client = new RestClient("https://www.leaflink.com/api/v2/customers/");
            var rpaRequest = new RestRequest("https://www.leaflink.com/api/v2/customers/", Method.Get);
            rpaRequest.AddParameter(Parameter.CreateParameter("limit", "500", ParameterType.QueryString));
            rpaRequest.AddParameter(Parameter.CreateParameter("offset", "500", ParameterType.QueryString));

            rpaRequest.AddHeader("Authorization", "App 6078c8a92fdec44c32c9f276eb8a57770c11337c7b83e6c2f58788129302e486");
            rpaRequest.AddHeader("Content-Type", "application/json");

            var rpaResponse = client.Execute(rpaRequest);


            var root = JObject.Parse(rpaResponse.Content);

            var data = JsonConvert.DeserializeObject<Root>(rpaResponse.Content);

            var excelData = ExcelHelper.CreateExcelFile(data);

            return File(
          excelData,
          "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
          "customers.xlsx"
             );


        }


        [HttpPost("GetLeafLinkInovice")]
        public IActionResult GetLeafLinkInovice()
        {
            var client = new RestClient("https://www.leaflink.com/api/v2/orders-received/");
            var rpaRequest = new RestRequest("https://www.leaflink.com/api/v2/orders-received/", Method.Get);
            rpaRequest.AddParameter(Parameter.CreateParameter("limit", "500", ParameterType.QueryString));
            

            rpaRequest.AddHeader("Authorization", "App 6078c8a92fdec44c32c9f276eb8a57770c11337c7b83e6c2f58788129302e486");
            rpaRequest.AddHeader("Content-Type", "application/json");

            var rpaResponse = client.Execute(rpaRequest);


            var root = JObject.Parse(rpaResponse.Content);

            var data = JsonConvert.DeserializeObject<OrderResponse>(rpaResponse.Content);

            var excelData = ExcelHelper.CreateInvoiceExcelFile(data);

            return File(
          excelData,
          "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
          "Invoice.xlsx"
             );


        }
    }
}
