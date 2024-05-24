using System;
using System.Collections.Generic;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.PcmoverService.Infrastructure
{
	// Token: 0x02000006 RID: 6
	public class PcmoverEndpoint : LlEndpoint
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020F0 File Offset: 0x000002F0
		public static LlEndpoint CreateEndpoint(Uri uri, IEnumerable<BindingFactory> factories)
		{
			LlEndpoint llEndpoint = new LlEndpoint();
			LlUriProperties uriProperties = llEndpoint.GetUriProperties(uri);
			llEndpoint = null;
			string contractName = uriProperties.ContractName;
			if (!(contractName == "query"))
			{
				if (!(contractName == "monitor"))
				{
					if (contractName == "control")
					{
						llEndpoint = new PcmoverControlEndpoint(factories);
					}
				}
				else
				{
					llEndpoint = new PcmoverMonitorEndpoint(factories);
				}
			}
			else
			{
				llEndpoint = new PcmoverQueryEndpoint(factories);
			}
			if (llEndpoint != null)
			{
				llEndpoint.Uri = uri;
			}
			return llEndpoint;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000215F File Offset: 0x0000035F
		protected PcmoverEndpoint(IEnumerable<BindingFactory> factories, Type contractType, string contractName) : base(factories)
		{
			base.BaseName = "pcmoverservice";
			base.SetPort(Uri.UriSchemeNetTcp, 29719);
			base.Contract = new ContractInfo(contractType, contractName, "v2.0056");
		}
	}
}
