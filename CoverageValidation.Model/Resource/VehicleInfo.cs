namespace  CoverageValidation.Model.Resource
{
    /// <summary>
    /// This class represents Vehicle information as it pertains to a Package Criteria
    /// </summary>
    public sealed class VehicleInfo
    {
        /// <summary>
        /// Gets or sets the vehicle Id. This is just an identifier
        /// that identifies one vehicle from another. This identifier
        /// is specific to calling applications
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the vehicle type code
        /// </summary>
        public string VehicleTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the Vehicle Symbol code
        /// </summary>
        public string VehicleSymbolCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Vehicle is leased or not
        /// </summary>
        public bool IsLeased { get; set; }

        /// <summary>
        /// Gets or sets the Model year of the vehicle
        /// </summary>
        public int ModelYear { get; set; }
    }
}
