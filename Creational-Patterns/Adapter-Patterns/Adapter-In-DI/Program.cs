using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Features.Metadata;

namespace Adapter_In_DI
{
    public interface ICommand
    {
        void Execute();
    }

    public class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening a file");
        }
    }

    public class SaveComamnd : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving a file");
        }
    }


    public class Button
    {
        private ICommand _command;
        private string _name;

        public Button(ICommand command, string name)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
            _name = name;
        }

        public void Click()
        {
            _command.Execute();
        }

        public void PrintMe() => Console.WriteLine($"I'm a button {_name}");
    }

    public class Editor
    {
        private readonly IEnumerable<Button> _buttons;

        public Editor(IEnumerable<Button> buttons)
        {
            _buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
        }

        public IEnumerable<Button> Buttons => _buttons;

        public void ClickAll()
        {
            foreach (var button in _buttons)
            {
                button.Click();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<SaveComamnd>().As<ICommand>()
                .WithMetadata("Name", "Save");
            containerBuilder.RegisterType<OpenCommand>().As<ICommand>()
                .WithMetadata("Name", "Open");
            containerBuilder.RegisterAdapter<Meta<ICommand>, Button>(meta =>
                new Button(meta.Value, (string) meta.Metadata["Name"]));

            containerBuilder.RegisterType<Editor>();

            using var container = containerBuilder.Build();
            var editor = container.Resolve<Editor>();

            foreach (var editorButton in editor.Buttons)
            {
                editorButton.PrintMe();
                editorButton.Click();
            }
        }
    }
}