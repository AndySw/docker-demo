using System.Data;

namespace DockerDemo.App
{
    public interface ICommandFactory<T> 
        where T:IDbCommand, new() 
    {
        T GetCommand(string commandText);
    }
    public class CommandFactory<T> : ICommandFactory<T> 
        where T:IDbCommand, new()
    {
        public T GetCommand(string commandText){
            T command = new T();
            command.CommandText = commandText;
            return command;
        }
    }
}