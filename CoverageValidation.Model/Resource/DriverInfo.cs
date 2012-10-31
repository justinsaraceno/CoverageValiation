using System;

namespace  CoverageValidation.Model.Resource
{
    /// <summary>
    /// This class contains a Driver's Information as it pertains to Package Criteria
    /// </summary>
    public class DriverInfo
    {
        /// <summary>
        /// Gets or sets a value indicating whether a drivers has HasDui.
        /// If a driver has (or has had) a DUI then this property is set
        /// to true. If this property is set to true then the DuiDate
        /// property must be set as well
        /// </summary>
        public bool HasDui { get; set; }

        /// <summary>
        /// Gets or sets DuiDate. This the date on which the Dui was Issued
        /// </summary>
        public DateTime DuiDate { get; set; }
    }
}
