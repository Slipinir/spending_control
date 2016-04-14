namespace SpendingControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Represents an Expense class.
    /// </summary>
    public class Expense : IDataErrorInfo, INotifyPropertyChanged
    {
        #region Fields

        private int id;

        private string description;

        private int quantity;

        private decimal unitValue;

        private decimal totalValue;

        private DateTime dateTimeSpent;

        #endregion

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the Expense class.
        /// </summary>
        public Expense()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the id of this Expense instance.
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.SetField(ref this.id, value, "ID"); }
        }

        /// <summary>
        /// Gets or sets the description of this Expense instance.
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set { this.SetField(ref this.description, value, "Description"); }
        }

        /// <summary>
        /// Gets or sets the quantity of this Expense instance.
        /// </summary>
        public int Quantity
        {
            get { return this.quantity; }
            set { this.SetField(ref this.quantity, value, "Quantity"); }
        }

        /// <summary>
        /// Gets or sets the unit value of this Expense instance.
        /// </summary>
        public decimal UnitValue
        {
            get { return this.unitValue; }
            set { this.SetField(ref this.unitValue, value, "UnitValue"); }
        }

        /// <summary>
        /// Gets or sets the description of this Expense instance.
        /// </summary>
        public decimal TotalValue
        {
            get { return this.totalValue; }
            set { this.SetField(ref this.totalValue, value, "TotalValue"); }
        }

        /// <summary>
        /// Gets or sets the date time spent of this Expense instance.
        /// </summary>
        public DateTime DateTimeSpent
        {
            get { return this.dateTimeSpent; }
            set { this.SetField(ref this.dateTimeSpent, value, "DateTimeSpent"); }
        }

        #endregion

        #region INotifyPropertyChanged Fields

        /// <summary>
        /// Property changed envet.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Comunicates that a property has been changed.
        /// </summary>
        /// <param name="propertyName"> The property's name.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// A set field method.
        /// </summary>
        /// <typeparam name="T"> The field type.</typeparam>
        /// <param name="field"> The field of this Expense instance.</param>
        /// <param name="value"> The value passed to the field of this Expense instance.</param>
        /// <param name="propertyName"> The property's name of this Expense instance.</param>
        /// <returns> A bool value that indicates wheter the filed and value types are equals.</returns>
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region IDataErrorInfo Fields

        /// <summary>
        /// Gets the error.
        /// </summary>
        public string Error
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the validation error of this Expense instance.
        /// </summary>
        /// <param name="propertyName"> The property name to be validated.</param>
        /// <returns> Returns a string with the validation error. If there's one.</returns>
        public string this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion

        #region Validation

        /// <summary>
        /// A string array with all validated properties.
        /// </summary>
        private readonly string[] ValidatedProperties =
        {
            "ID",
            "Description",
            "Quantity",
            "UnitValue",
            "TotalValue",
            "DateTimeSpent"
        };

        /// <summary>
        /// A private method to get the validation error.
        /// </summary>
        /// <param name="propertyName"> The property name to validate.</param>
        /// <returns> The validation error.</returns>
        private string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(this.ValidatedProperties, propertyName) < 0)
                return null;

            switch (propertyName)
            {
                case "ID":
                    return this.ValidateID();
                case "Description":
                    return this.ValidateDescription();
                case "Quantity":
                    return this.ValidateQuantity();
                case "UnitValue":
                    return this.ValidateUnitValue();
                case "TotalValue":
                    return this.ValidateTotalValue();
                case "DateTimeSpent":
                    return this.ValidateDateTimeSpent();
            }

            return null;
        }

        /// <summary>
        /// A private method to validate the id of this Expense instance.
        /// </summary>
        /// <returns> The validation error. If there isn't, returns null.</returns>
        private string ValidateID()
        {
            if (this.ID <= 0)
                return "ID value invalid. It must be positive!";
            else
                return null;
        }

        /// <summary>
        /// A private method to validate the description of this Expense instance.
        /// </summary>
        /// <returns> The validation error. If there isn't, returns null.</returns>
        private string ValidateDescription()
        {
            if (string.IsNullOrEmpty(this.Description))
                return "Description value must be filled!";
            else
                return null;
        }

        /// <summary>
        /// A private method to validate the quantity of this Expense instance.
        /// </summary>
        /// <returns> The validation error. If there isn't, returns null.</returns>
        private string ValidateQuantity()
        {
            if (this.Quantity <= 0)
                return "Quantity value invalid. It must be positive!";
            else
                return null;
        }

        /// <summary>
        /// A private method to validate the unit value of this Expense instance.
        /// </summary>
        /// <returns> The validation error. If there isn't, returns null.</returns>
        private string ValidateUnitValue()
        {
            if (this.UnitValue <= 0)
                return "Unit value invalid. It must be positive!";
            else
                return null;
        }

        /// <summary>
        /// A private method to validate the total value of this Expense instance.
        /// </summary>
        /// <returns> The validation error. If there isn't, returns null.</returns>
        private string ValidateTotalValue()
        {
            if (this.TotalValue <= 0)
                return "Total value invalid. It must be positive!";
            else
                return null;
        }

        /// <summary>
        /// A private method to validate the date time spent of this Expense instance.
        /// </summary>
        /// <returns> The validation error. If there isn't, returns null.</returns>
        private string ValidateDateTimeSpent()
        {
            if (this.DateTimeSpent < DateTime.Today)
                return "Date time spent invalid. It must be of today!";
            else
                return null;
        }

        #endregion
    }
}
