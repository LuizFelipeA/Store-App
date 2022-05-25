namespace SharedContext.Commands.Handlers;

public interface ICommandHandler<in T> where T : ICommand
{
    Task HandleAsync(T command);
}
