namespace Command_Pattern
{
    public interface ICommand
    {
        void Call();
        void Undo();
    }
}