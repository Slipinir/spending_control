namespace SpendingControl
{
    using System.Windows;

    /// <summary>
    /// 
    /// </summary>
    public class NumericUpDown : DependencyObject
    {
        #region Fields

        private decimal minimum;

        private decimal maximum;

        private decimal increment;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NumericUpDown class.
        /// </summary>
        public NumericUpDown()
        {
            this.SetDefaultValues();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of this NumericUpDown instance.
        /// </summary>
        public decimal Value
        {
            get { return Convert.ToDecimal(this.txtNum.Text); }
            set
            {
                if (value >= this.Minimum && value <= this.Maximum)
                    this.txtNum.Text = value.ToString();
                else
                    this.txtNum.Text = this.Value.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the minimum value of this NumericUpDown instance.
        /// </summary>
        [Category("Data"),
        DisplayName("Minimum"),
        Description("Indicates the minimum value for the numeric up-down cotrol.")]
        public decimal Minimum
        {
            get { return this.minimum; }
            set { this.minimum = value; }
        }

        /// <summary>
        /// Gets or sets the maximum value of this NumericUpDown instance.
        /// </summary>
        [Category("Data"),
        DisplayName("Maximum"),
        Description("Indicates the maximum value for the numeric up-down control.")]
        public decimal Maximum
        {
            get { return this.maximum; }
            set { this.maximum = value; }
        }

        /// <summary>
        /// Gets or sets the increment value of this NumericUpDown instace.
        /// </summary>
        [Category("Data"),
        DisplayName("Increment"),
        Description("Indicates the amount to increment or decrement on each button click.")]
        public decimal Increment
        {
            get { return this.increment; }
            set { this.increment = value; }
        }

        #endregion

        #region Methods

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            this.Value += this.Increment;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            this.Value -= this.Increment;
        }

        private void SetDefaultValues()
        {
            this.Value = 0;
            this.Minimum = 0;
            this.Maximum = 100;
            this.Increment = 1;
        }

        #endregion
    }
}
