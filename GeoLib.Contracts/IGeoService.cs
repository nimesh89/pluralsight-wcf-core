// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGeoService.cs" company="ABC">
//   ABC
// </copyright>
// <summary>
//   Defines the IGeoService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GeoLib.Contracts
{
    using System.Collections.Generic;
    using System.ServiceModel;

    /// <summary>
    /// The GeoService interface.
    /// </summary>
    [ServiceContract]
    public interface IGeoService
    {
        /// <summary>
        /// The get zip info.
        /// </summary>
        /// <param name="zip">
        /// The zip.
        /// </param>
        /// <returns>
        /// The <see cref="ZipCodeData"/>.
        /// </returns>
        [OperationContract]
        ZipCodeData GetZipInfo(string zip);

        /// <summary>
        /// The get states.
        /// </summary>
        /// <param name="primaryOnly">
        /// The primary only.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        [OperationContract]
        IEnumerable<string> GetStates(bool primaryOnly);

        /// <summary>
        /// The get zips.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        [OperationContract(Name = "GetZipsByState")]
        IEnumerable<ZipCodeData> GetZips(string state);

        /// <summary>
        /// The get zips.
        /// </summary>
        /// <param name="zip">
        /// The zip.
        /// </param>
        /// <param name="range">
        /// The range.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        [OperationContract(Name = "GetZipsForRange")]
        IEnumerable<ZipCodeData> GetZips(string zip, int range);
    }
}
