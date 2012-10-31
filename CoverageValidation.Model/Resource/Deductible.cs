namespace  CoverageValidation.Model.Resource
{
    /// <summary>
    /// The is the Resource Model for a Deductible
    /// </summary>
    public sealed class Deductible
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Deductible"/> class. 
        /// </summary>
        /// <param name="code">The Deductible Code</param>
        /// <param name="amount">The Deductible Amount</param>
        /// <param name="description">The Description</param>
        /// <param name="mnemonic">The Mnemonic</param>
        public Deductible(string code, int amount, string description, string mnemonic)
        {
            this.Code = code;
            this.Amount = amount;
            this.Description = description;
            this.Mnemonic = mnemonic;
        }

        /// <summary>
        /// Gets the Deductible Code
        /// </summary>
        public string Code { get; private set; }
        
        /// <summary>
        /// Gets the Deductible Amount
        /// </summary>
        public int Amount { get; private set; }
        
        /// <summary>
        /// Gets the Deductible Description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the Mnemonic.
        /// </summary>
        public string Mnemonic { get; private set; }

    }
}
