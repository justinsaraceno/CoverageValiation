namespace  CoverageValidation.Model.Resource
{
    /// <summary>
    /// Represents the selection of a coverage type and limit.
    /// </summary>
    public sealed class Coverage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coverage"/> class. 
        /// </summary>
        /// <param name="coverageType">
        /// The coverage type
        /// </param>
        /// <param name="limit">
        /// The Coverage Limit
        /// </param>
        /// <param name="deductible">
        /// The Coverage Deductible
        /// </param>
        /// <param name="vehicleId">
        /// The vehicle Id.
        /// </param>
        public Coverage(CoverageType coverageType, Limit limit, Deductible deductible, int vehicleId)
        {
            this.CoverageType = coverageType;
            this.Limit = limit;
            this.Deductible = deductible;
            this.VehicleId = vehicleId;
        }

        /// <summary>
        /// Gets the coverage type
        /// </summary>
        public CoverageType CoverageType { get; private set; }

        /// <summary>
        /// Gets the limit
        /// </summary>
        public Limit Limit { get; private set; }

        /// <summary>
        /// Gets the Deductible
        /// </summary>
        public Deductible Deductible { get; private set; }

        /// <summary>
        /// Gets the vehicle id.
        /// </summary>
        public int VehicleId { get; private set; }
    }
}