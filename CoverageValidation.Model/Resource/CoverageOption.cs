using System.Collections.Generic;

namespace  CoverageValidation.Model.Resource
{
    /// <summary>
    /// This class is a Coverage Option. An instance of this class
    /// holds a CoveraeType and all possible Limits and/or Deductibles
    /// for this CoverageType
    /// </summary>
    public class CoverageOption
    {
        /// <summary>
        /// Gets or sets the CoverageType
        /// </summary>
        public CoverageType CoverageType { get; set; }

        /// <summary>
        /// Gets or sets the Limits. This property can be null depending on the CovergeType
        /// </summary>
        public IEnumerable<Limit> Limits { get; set; }

        /// <summary>
        /// Gets or sets the Deductibles. This property can be null depending on the CoverageType
        /// </summary>
        public IEnumerable<Deductible> Deductibles { get; set; }
    }
}
