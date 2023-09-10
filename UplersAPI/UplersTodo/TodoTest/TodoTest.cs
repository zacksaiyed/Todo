using BusinessData.Interface;
using BusinessModel.Request;
using BusinessModel.ViewModel;
using Moq;
using System.Security.Cryptography;
using UplersTodo.Controllers;

namespace TodoTest
{
    public class TodoTest
    {

        public Mock<ITodoRepository> mock = new Mock<ITodoRepository>();

        [Fact]
        public void GetTodoByTitle()


        {
            GetTodoRequest request = new GetTodoRequest()
            {
                Title = "Go to gym"
            };

            var data = new List<GetToDoViewModel>() {
                new GetToDoViewModel()
                {
                    Id = 13,
                    IsCompleted = true,
                    Title="Go to gym"
                }
            };

            mock.Setup(x => x.GetTodos(request)).Returns(data);
            ToDoController toDoController = new ToDoController(mock.Object);
            var result = toDoController.GetTodo(request);
            Assert.Equal(1, result?.Value?.Todos.Count());
        }

        [Fact]
        public void AddToDo()


        {
            AddUpdateToDoRequest request = new AddUpdateToDoRequest()
            {
                Id = 0,
                Action = "I",
                Title = GenerateRandomString(5)

            };

            mock.Setup(x => x.AddUpdateTodo(request)).Returns(true);
            ToDoController toDoController = new ToDoController(mock.Object);
            var result = toDoController.AddOrUpdateToDo(request);
            Assert.Equal(true, result?.Value?.IsRecordedAffected);
        }

        [Fact]
        public void UpdateTodoTitle()
        {
            AddUpdateToDoRequest request = new AddUpdateToDoRequest()
            {
                Id = 17,
                Action = "U",
                Title = GenerateRandomString(5)

            };

            mock.Setup(x => x.AddUpdateTodo(request)).Returns(true);
            ToDoController toDoController = new ToDoController(mock.Object);
            var result = toDoController.AddOrUpdateToDo(request);
            Assert.Equal(true, result?.Value?.IsRecordedAffected);
        }

        [Fact]
        public void UpdateTodoAsCompleted()
        {
            AddUpdateToDoRequest request = new AddUpdateToDoRequest()
            {
                Id = 17,
                Action = "",
                Title = ""

            };

            mock.Setup(x => x.UpdateTodoAsCompleted(request)).Returns(true);
            ToDoController toDoController = new ToDoController(mock.Object);
            var result = toDoController.UpdateTodoAsCompleted(request);
            Assert.Equal(true, result?.Value?.IsRecordedAffected);
        }

        [Fact]
        public void DeleteTodo()
        {
            AddUpdateToDoRequest request = new AddUpdateToDoRequest()
            {
                Id = 17,
                Action = "",
                Title = ""

            };

            mock.Setup(x => x.DeleteTodo(request)).Returns(true);
            ToDoController toDoController = new ToDoController(mock.Object);
            var result = toDoController.DeleteToDo(request);
            Assert.Equal(true, result?.Value?.IsRecordedAffected);
        }


        private string GenerateRandomString(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes)
                    .Substring(0, length) // Truncate to the desired length
                    .Replace('/', '_')   // Replace '/' and '+' with safe characters
                    .Replace('+', '-');
            }
        }
    }
}