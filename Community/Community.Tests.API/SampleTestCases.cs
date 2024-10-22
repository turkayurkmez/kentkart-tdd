using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Tests.API
{

    public class TodoList
    {
        public List<Todo> Items { get; set; } = new  List<Todo>();
        public TodoList()
        {
                
        }

        internal void AddTodo(Todo item)
        {
           ArgumentNullException.ThrowIfNull(item,"item");
           Items.Add(item);
        }
    }
    public class Todo
    {
    }

    public class SampleTestCases
    {
        [Fact]
        public void Can_Get_Todos()
        {
            TodoList todoList = new TodoList ();
            var list = todoList.Items;

            Assert.NotNull(list);
            Assert.IsAssignableFrom<IEnumerable<Todo>>(list);
            Assert.Empty(list);


        }

        [Fact(Skip ="Önce olumsuz senaryolar test etilmeli...")]
        public void It_Adds_A_Todo_Item_To_List()
        {
            TodoList todoList = new TodoList();
            Todo item = null;

            todoList.AddTodo(item);

            Assert.Single(todoList.Items);


        }
        [Fact]
        public void On_null_An_Argument_Null_Error_Occurs()
        {
            TodoList todoList = new TodoList();
            Todo item = null;

            var exception = Record.Exception(() => todoList.AddTodo(item));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

    }
}
