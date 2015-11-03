using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Domain model extension services.
    /// </summary>
    public abstract class DomainModelExtensionServices : IDomainModelExtensionServices
    {
        private List<IDomainModelServices> externServices;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mainService">Main service</param>
        protected DomainModelExtensionServices(IDomainModelServices mainService)
        {
            this.externServices = new List<IDomainModelServices>();

            this.MainService = mainService;
        }

        /// <summary>
        /// Gets the main service.
        /// </summary>
        public IDomainModelServices MainService
        {
            get;
            private set;
        }

        /// <summary>
        /// Extern services collection.
        /// </summary>		
        public List<IDomainModelServices> ExternServices
        {
            get
            {
                return externServices;
            }
        }        

        /// <summary>
        /// Initialized known extern services.
        /// </summary>
        public abstract void Intialize();

        /// <summary>
        /// Adds an extern model service.
        /// </summary>
        /// <param name="externService">IDomainModelServices.</param>
        public void AddExternModelService(IDomainModelServices externService)
        {
            if (!this.ExternServices.Contains(externService))
                this.ExternServices.Add(externService);
        }

        /// <summary>
        /// Sets the top-most service.
        /// </summary>
        /// <param name="externService">IDomainModelServices.</param>
        public void SetTopMostService(IDomainModelServices externService)
        {
            this.MainService.TopMostService = externService;

            foreach (IDomainModelServices s in this.ExternServices)
                s.TopMostService = externService;
        }
    }
}
