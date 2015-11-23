// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeoClient.cs" company="ABC">
//   ABC
// </copyright>
// <summary>
//   Defines the GeoClient type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GeoLib.Proxies
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using GeoLib.Contracts;

    /// <summary>
    /// The geo client.
    /// </summary>
    public class GeoClient : ClientBase<IGeoService>, IGeoService
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
        public ZipCodeData GetZipInfo(string zip)
        {
            return this.Channel.GetZipInfo(zip);
        }

        /// <summary>
        /// The get states.
        /// </summary>
        /// <param name="primaryOnly">
        /// The primary only.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<string> GetStates(bool primaryOnly)
        {
            return this.Channel.GetStates(primaryOnly);
        }

        /// <summary>
        /// The get zips.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ZipCodeData> GetZips(string state)
        {
            return this.Channel.GetZips(state);
        }

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
        public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        {
            return this.Channel.GetZips(zip, range);
        }
    }
}
