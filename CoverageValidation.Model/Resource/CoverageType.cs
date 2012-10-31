using  CoverageValidation.Model.Resource.Enums;

namespace  CoverageValidation.Model.Resource
{
    /// <summary>
    /// Represents a type of Coverage such as Bodily Injury
    /// </summary>
    public sealed class CoverageType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoverageType"/> class. 
        /// </summary>
        /// <param name="code">Geico internal code.</param>
        /// <param name="coverageLevel">The Coverage Level of this CoverageType.</param>
        /// <param name="shortDescription">
        ///   Geico known mnemonic representing a coverage type.
        ///   <example>BI</example>
        /// </param>
        /// <param name="description">
        ///   The long form description of a coverage type.
        ///   <example>Bodily Injury</example>
        /// </param>
        public CoverageType(string code, string coverageLevel, string shortDescription, string description)
        {
            this.Code = code;
            this.CoverageLevel = coverageLevel;
            this.Mnemonic = shortDescription;
            this.Description = description;
            //this.CoveragePosition = coveragePosition;
            //this.Comment = comment;
        }

        /// <summary>
        /// Gets or sets the Geico internal code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the Geico known mnemonic representing a coverage type.
        /// </summary>
        public string Mnemonic { get; set; }

        /// <summary>
        /// Gets or sets the CoverageLevel
        /// </summary>
        public string CoverageLevel { get; set; }

        /// <summary>
        /// Gets or sets the long form description of a coverage type.
        /// </summary>
        public string Description { get; set; }

        ///// <summary>
        ///// Gets or sets the coverage type comment
        ///// </summary>
        //public string Comment { get; set; }

        ///// <summary>
        ///// Gets or sets the Coverage Position
        ///// </summary>
        //public int CoveragePosition { get; set; }
    }
}