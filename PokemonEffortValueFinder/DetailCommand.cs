using System.Windows.Input;

namespace PokemonEffortValueFinder
{
    public class DetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public async void Execute(object parameter)
        {
            string detailUrl = parameter.ToString();

            if (string.IsNullOrWhiteSpace(detailUrl)) 
            {
                return;
            }
            await Browser.OpenAsync(detailUrl);
        }
    }
}