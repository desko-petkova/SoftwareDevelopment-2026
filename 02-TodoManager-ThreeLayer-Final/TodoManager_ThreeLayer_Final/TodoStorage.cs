namespace TodoManager_ThreeLayer_Final
{
    internal class TodoStorage
    {
        public int NextId { get; set; } = 1;

        public List<TodoItem> Todos { get; set; } = new();
    }
}
