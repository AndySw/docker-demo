using System;

namespace DockerDemo.App
{
    public interface ILogger
    {
        void Error(Exception ex);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        private readonly ConsoleColor _originalForegroundColor;

        public Logger(){
            _originalForegroundColor = Console.ForegroundColor;
        }
        public void Error(Exception ex){
            Error(ex.ToString());
        }

        public void Error(string message){
            Console.ForegroundColor = ConsoleColor.Red;    
            Console.WriteLine(message);
            RevertForegroundColor();
        }

        private void RevertForegroundColor(){
            Console.ForegroundColor = _originalForegroundColor;
        }
    }
}