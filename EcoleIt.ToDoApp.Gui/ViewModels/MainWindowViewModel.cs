using EcoleIt.ToDoApp.Core.Models;
using EcoleIt.ToDoApp.Gui.Services;
using ReactiveUI;
using System.Reactive.Linq;
using System;

namespace EcoleIt.ToDoApp.Gui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase content;
        private readonly TodoItemApiProxy _proxy;

        public MainWindowViewModel(TodoItemApiProxy proxy)
        {
            _proxy = proxy;
            Content = new TodoListViewModel(_proxy.GetItems());
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public void AddItem()
        {
            var vm = new AddItemViewModel();

            Observable
                .Merge(
                    vm.Ok,
                    vm.Cancel.Select(_ => (TodoItem)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        _proxy.AddItem(model);
                    }
                    Content = new TodoListViewModel(_proxy.GetItems());
                });

            Content = vm;
        }
    }
}