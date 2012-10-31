namespace  CoverageValidation.Model.Resource
{
    /// <summary>
    /// A coverage limit
    /// </summary>
    public sealed class Limit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Limit"/> class. 
        /// </summary>
        /// <param name="code">Limit Code</param>
        /// <param name="perPerson">The Per Person limit</param>
        /// <param name="perIncident">The Per Incident limit</param>
        /// <param name="description">Long form description of a coverage limit.</param>
        /// <param name="minimum">The minimum indicator</param>
        public Limit(string code, int perPerson, int perIncident, string description, bool minimum)
        {
            this.Code = code;
            this.PerPerson = perPerson;
            this.PerIncident = perIncident;
            this.Description = description;
            this.Minimum = minimum;
           //this.Recommended = recommended;
        }

        /// <summary>
        /// Gets the Limit Code
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Gets the Per Person maximum amount
        /// </summary>
        public int PerPerson { get; private set; }

        /// <summary>
        /// Gets the Per Incident maximum amount
        /// </summary>
        public int PerIncident { get; private set; }

        /// <summary>
        /// Gets the Description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the limit is minimum
        /// </summary>
        public bool Minimum { get; private set; }

        ///// <summary>
        ///// Gets a value indicating whether the limit is recommended
        ///// </summary>
        //public bool Recommended { get; private set; }

        /// <summary>
        /// Gets the Mnemonic.
        /// </summary>
        public string Mnemonic { get; private set; }
    }
}