namespace Autotests.Models.Task
{
    public class EditData
    {
        public TaskData OldTaskData { get; }
        public TaskData NewTaskData { get; }

        public EditData(TaskData oldTaskData, TaskData newTaskData)
        {
            OldTaskData = oldTaskData;
            NewTaskData = newTaskData;
        }
    }
}