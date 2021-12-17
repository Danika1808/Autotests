namespace Autotests.Models.Task
{
    public class TaskData
    {
        public string Title { get; set; }

        public TaskData()
        {
        }
        
        public TaskData(string title)
        {
            Title = title;
        }
    }
}