using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiBank.Commands
{
    public class CommandHandler
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public async Task ExecuteCommands()
        {
            foreach (var command in _commands)
            {
                await command.ExecuteAsync();              }

            _commands.Clear();
        }
    }
}
