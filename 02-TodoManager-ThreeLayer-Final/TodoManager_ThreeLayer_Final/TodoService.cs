namespace TodoManager_ThreeLayer_Final
{
    internal class TodoService
    {  
        private readonly TodoStorage storage;
        private readonly FileStorage fileStorage;

        public TodoService(FileStorage file)
        {
            fileStorage = file;
            storage = fileStorage.Load();
        }

        public IReadOnlyList<TodoItem> GetAll()
        {
            return storage.Todos.AsReadOnly();
        }

        public void Add( string title, string description, DateTime dueDate)
        {          
            TodoItem todoItem = new TodoItem(storage.NextId, title, description, dueDate);

            storage.Todos.Add(todoItem);
            storage.NextId++;

            fileStorage.Save(storage);
        }

        public TodoItem FindById(int id)
        {   
            foreach (TodoItem todo in storage.Todos)
            {
                if (todo.Id == id)
                {
                    return todo;    
                }
            }
           
            return null;          
        }

        public void Complete(int id)
        {
            TodoItem todo = FindById(id);

            if (todo == null)
                throw new ArgumentException("Няма задача с такова ID");

            todo.Completed();

            fileStorage.Save(storage);
        }

        public void Delete(int id)
        {
            TodoItem todo = FindById(id);

            if (todo == null)
                throw new ArgumentException("Няма задача с такова ID");

            storage.Todos.Remove(todo);
            fileStorage.Save(storage);

        }
    }
}
