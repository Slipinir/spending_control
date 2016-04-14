namespace SpendingControl.ViewModels
{
    using SpendingControl.Commands;
    using SpendingControl.Models;
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    /// <summary>
    /// Represents a MainWindowViewModel class.
    /// </summary>
    public class MainWindowViewModel
    {
        #region Fields

        private Expense expense = new Expense();
        
        #endregion

        #region Contructors
        
        /// <summary>
        /// Initializes a new instance of the MainWindowViewModel class.
        /// </summary>
        public MainWindowViewModel()
        {

        }

        #endregion

        #region Properties

        public Expense Expense
        {
            get { return this.expense; }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Verifies if this MainWindowViewModel.Expense instance can be saved.
        /// </summary>
        /// <returns> An bool value indicating whether this MainWindowViewModel instance can be saved.</returns>
        public bool CanSaveExpenseExecute()
        {
            if (this.expense == null)
                return false;
            else
                return (!(string.IsNullOrEmpty(this.expense.Description) &&
                    this.expense.Quantity <= 0 &&
                    this.expense.UnitValue <= 0 &&
                    this.expense.TotalValue <= 0));
        }

        /// <summary>
        /// Save this MainWindowViewModel.Expense instance.
        /// </summary>
        public void SaveExpenseExecute()
        {
            Debug.Assert(false, "Expense saved succefully!");
        }

        /// <summary>
        /// The save expense command.
        /// </summary>
        public ICommand SaveExpense
        {
            get { return new SaveExpenseCommand(this); }
        }

        #endregion
    }
}
