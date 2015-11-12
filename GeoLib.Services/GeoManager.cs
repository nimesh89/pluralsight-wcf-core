// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeoManager.cs" company="ABC">
//   ABC
// </copyright>
// <summary>
//   Defines the GeoManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GeoLib.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using GeoLib.Contracts;
    using GeoLib.Data;

    /// <summary>
    /// The geo manager.
    /// </summary>
    public class GeoManager : IGeoService
    {
        /// <summary>
        /// The zip code repository.
        /// </summary>
        private IZipCodeRepository zipCodeRepository;

        /// <summary>
        /// The state repository.
        /// </summary>
        private IStateRepository stateRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoManager"/> class.
        /// </summary>
        public GeoManager()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoManager"/> class.
        /// </summary>
        /// <param name="zipCodeRepository">
        /// The zip code repository.
        /// </param>
        public GeoManager(IZipCodeRepository zipCodeRepository)
        {
            this.zipCodeRepository = zipCodeRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoManager"/> class.
        /// </summary>
        /// <param name="stateRepository">
        /// The state repository.
        /// </param>
        public GeoManager(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoManager"/> class.
        /// </summary>
        /// <param name="zipCodeRepository">
        /// The zip code repository.
        /// </param>
        /// <param name="stateRepository">
        /// The state repository.
        /// </param>
        public GeoManager(IZipCodeRepository zipCodeRepository, IStateRepository stateRepository)
        {
            this.zipCodeRepository = zipCodeRepository;
            this.stateRepository = stateRepository;
        }

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
            ZipCodeData zipCodeData = null;
            this.zipCodeRepository = this.zipCodeRepository ?? new ZipCodeRepository();
            var zipCodeEntity = this.zipCodeRepository.GetByZip(zip);
            if (zipCodeEntity != null)
            {
                zipCodeData = new ZipCodeData()
                                  {
                                      City = zipCodeEntity.City,
                                      State = zipCodeEntity.State.Abbreviation,
                                      ZipCode = zipCodeEntity.Zip
                                  };
            }

            return zipCodeData;
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
            List<string> stateData = new List<string>();
            this.stateRepository = this.stateRepository ?? new StateRepository();
            IEnumerable<State> states = this.stateRepository.Get(primaryOnly);
            if (states != null)
            {
                stateData = states.Select(state => state.Abbreviation).ToList();
            }

            return stateData;
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
            List<ZipCodeData> zipCodeData = null;
            this.zipCodeRepository = this.zipCodeRepository ?? new ZipCodeRepository();
            var zipCodeEntity = this.zipCodeRepository.GetByState(state);
            if (zipCodeEntity != null)
            {
                zipCodeData =
                    zipCodeEntity.Select(
                        code =>
                        new ZipCodeData()
                            {
                                City = code.City,
                                State = code.State.Abbreviation,
                                ZipCode = code.Zip
                            }).ToList();
            }

            return zipCodeData;
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
            List<ZipCodeData> zipCodeData = null;
            this.zipCodeRepository = this.zipCodeRepository ?? new ZipCodeRepository();
            var zipObj = this.zipCodeRepository.GetByZip(zip);
            var zipCodeEntity = this.zipCodeRepository.GetZipsForRange(zipObj, range);
            if (zipCodeEntity != null)
            {
                zipCodeData =
                    zipCodeEntity.Select(
                        code =>
                        new ZipCodeData()
                        {
                            City = code.City,
                            State = code.State.Abbreviation,
                            ZipCode = code.Zip
                        }).ToList();
            }

            return zipCodeData;
        }
    }
}
