using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace Prism.Unity.Regions
{
	// Token: 0x02000007 RID: 7
	public class UnityRegionNavigationContentLoader : RegionNavigationContentLoader
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002688 File Offset: 0x00000888
		public UnityRegionNavigationContentLoader(IServiceLocator serviceLocator, IUnityContainer container) : base(serviceLocator)
		{
			this.container = container;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002698 File Offset: 0x00000898
		protected override IEnumerable<object> GetCandidatesFromRegion(IRegion region, string candidateNavigationContract)
		{
			if (candidateNavigationContract == null || candidateNavigationContract.Equals(string.Empty))
			{
				throw new ArgumentNullException("candidateNavigationContract");
			}
			IEnumerable<object> candidatesFromRegion = base.GetCandidatesFromRegion(region, candidateNavigationContract);
			if (!candidatesFromRegion.Any<object>())
			{
				ContainerRegistration containerRegistration = (from r in this.container.Registrations
				where candidateNavigationContract.Equals(r.Name, StringComparison.Ordinal)
				select r).FirstOrDefault<ContainerRegistration>();
				if (containerRegistration == null)
				{
					containerRegistration = (from r in this.container.Registrations
					where candidateNavigationContract.Equals(r.RegisteredType.Name, StringComparison.Ordinal)
					select r).FirstOrDefault<ContainerRegistration>();
				}
				if (containerRegistration == null)
				{
					return new object[0];
				}
				string fullName = containerRegistration.MappedToType.FullName;
				candidatesFromRegion = base.GetCandidatesFromRegion(region, fullName);
			}
			return candidatesFromRegion;
		}

		// Token: 0x04000004 RID: 4
		private IUnityContainer container;
	}
}
