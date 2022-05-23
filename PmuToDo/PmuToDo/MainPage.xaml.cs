using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PmuToDo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

    }

    public class Task
    {
        public string Text { get; set; } = "None";
        public bool IsDone { get; set; } = false;
    }

    public class MainViewModel
    {
        public ObservableCollection<Task> TasksList { get; } =
            new ObservableCollection<Task>();

        public MainViewModel()
        {
            AddTask = new Command<string>((text) =>
            {
                Task task = new Task();
                task.Text = text;

                TasksList.Add(task);
            });

            RemoveTask = new Command<Task>((task) =>
            {
                TasksList.Remove(task);
            });
        }

        public Command<string> AddTask { get; set; }
        public Command<Task> RemoveTask { get; set; }

    }
}
