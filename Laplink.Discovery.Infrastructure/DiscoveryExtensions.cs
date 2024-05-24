using System;
using System.Linq;
using System.ServiceModel.Discovery;
using System.Xml;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x0200000A RID: 10
	public static class DiscoveryExtensions
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00002BDB File Offset: 0x00000DDB
		public static XmlQualifiedName GetContractName(this EndpointDiscoveryMetadata edm)
		{
			if (edm == null)
			{
				return null;
			}
			return edm.ContractTypeNames.FirstOrDefault<XmlQualifiedName>();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002BED File Offset: 0x00000DED
		public static string GetFriendlyName(this EndpointDiscoveryMetadata edm)
		{
			if (edm == null)
			{
				return null;
			}
			return string.Format("{0} at {1}", edm.GetContractName(), edm.Address);
		}
	}
}
