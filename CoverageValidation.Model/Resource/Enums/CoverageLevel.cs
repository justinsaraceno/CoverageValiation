using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  CoverageValidation.Model.Resource.Enums
{
    /// <summary>
    /// This enum contains the posible Coverage Levels
    /// </summary>
    public enum CoverageLevel
    { 
        /// <summary>
        /// Indicates this CoverageTypeLevel is a Policy level
        /// </summary>
        Policy,

        /// <summary>
        /// Indicates this CoverageTypeLevel is a Vehicle level
        /// </summary>
        Vehicle
    }
}
