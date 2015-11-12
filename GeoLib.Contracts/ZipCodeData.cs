// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZipCodeData.cs" company="ABC">
//   ABC
// </copyright>
// <summary>
//   Defines the ZipCodeData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GeoLib.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The zip code data.
    /// </summary>
    [DataContract]
    public class ZipCodeData
    {
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [DataMember]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        [DataMember]
        public string ZipCode { get; set; }
    }
}
