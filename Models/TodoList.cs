namespace TPTodoList.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}
