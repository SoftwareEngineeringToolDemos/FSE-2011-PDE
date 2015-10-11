using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface specifies the model element extensions services, which 
    /// define extensions (imported libraries), which services can be accessed
    /// through the extension services.
    /// </summary>
    public interface IDomainModelExtensionServices
    {
        /// <summary>
        /// Extern services collection.
        /// </summary>		
        List<IDomainModelServices> ExternServices
        {
            get;
        }

        /// <summary>
        /// Gets the main service.
        /// </summary>
        IDomainModelServices MainService
        {
            get;
        }


        /// <summary>
        /// Initialized known extern services.
        /// </summary>
        void Intialize();

        /// <summary>
        /// Adds an extern model service.
        /// </summary>
        /// <param name="externService">IDomainModelServices.</param>
        void AddExternModelService(IDomainModelServices externService);

        /// <summary>
        /// Sets the top-most service.
        /// </summary>
        /// <param name="externService">IDomainModelServices.</param>
        void SetTopMostService(IDomainModelServices externService);
    }
}
