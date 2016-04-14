namespace SpendingControl.Commands
{
    using SpendingControl.ViewModels;
    using System.Windows.Input;

    /// <summary>
    /// Represents a SaveExpendCommand class.
    /// </summary>
    public class SaveExpenseCommand : ICommand
    {
        #region Fields

        private MainWindowViewModel mainWindowViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the SaveExpenseCommand class.
        /// </summary>
        /// <param name="viewModel"> The viewModel that owns this SaveExpenseCommand class.</param>
        public SaveExpenseCommand(MainWindowViewModel viewModel)
        {
            this.mainWindowViewModel = viewModel;
        }

        #endregion

        #region ICommand Fields

        /// <summary>
        /// 
        /// </summary>
        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this.mainWindowViewModel.CanSaveExpenseExecute();
        }

        public void Execute(object parameter)
        {
            this.mainWindowViewModel.SaveExpenseExecute();
        }

        #endregion
    }
}
