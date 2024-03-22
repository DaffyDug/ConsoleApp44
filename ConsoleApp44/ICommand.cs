public interface ICommand
{
    public string Description { get; }
    public void Run();
}
