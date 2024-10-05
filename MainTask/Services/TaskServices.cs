

using MainTask.Models;

namespace MainTask.Services
{
    public interface ITaskServices
    {
        void CreateTask(TaskItem task);
        List<TaskItem> GetAllTasks();
        TaskItem GetTaskById(int id);
        void UpdateTask(TaskItem task);
        void DeleteTask(int id);
    }
    public class TaskServices:ITaskServices
    {
        List<TaskItem> tasks= new List<TaskItem>();
        public void CreateTask(TaskItem task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
        }

        public List<TaskItem> GetAllTasks()
        {
            return tasks;
        }

        public TaskItem GetTaskById(int id)
        {
            return tasks.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateTask(TaskItem task)
        {
            var t=GetTaskById(task.Id);
            if(t != null)
            {
                t.Title = task.Title;
                t.Description = task.Description;
                t.IsCompleted = task.IsCompleted;
            }
        }
        public void DeleteTask(int id)
        {
            var t = GetTaskById(id);
            tasks.Remove(t);
        }
    }
}
