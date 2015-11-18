// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="ABC">
//   ABC
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GeoLib.ConsoleHost
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    using GeoLib.Contracts;
    using GeoLib.Services;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            var hostGeoManager = new ServiceHost(typeof(GeoManager));

            var address = "net.tcp://localhost:3456/GeoService";
            var addressMex = "net.tcp://localhost:3456/mex";
            var binding = new NetTcpBinding();
            var contract = typeof(IGeoService);

            var behavior = new ServiceMetadataBehavior();

            hostGeoManager.Description.Behaviors.Add(behavior);

            hostGeoManager.AddServiceEndpoint(contract, binding, address);
            hostGeoManager.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), addressMex);

            hostGeoManager.Open();

            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();

            hostGeoManager.Close();
        }
    }
}
