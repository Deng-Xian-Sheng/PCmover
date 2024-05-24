using System;
using System.Collections.Generic;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.PcmoverService.Infrastructure
{
	// Token: 0x02000002 RID: 2
	public class DownloadEndpoint : LlEndpoint
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public DownloadEndpoint(IEnumerable<BindingFactory> factories, Type contractType, string contractName) : base(factories)
		{
			base.BaseName = "lldownload";
			base.SetPort(Uri.UriSchemeNetTcp, 29723);
			base.Contract = new ContractInfo(contractType, contractName, "v2.0056");
		}
	}
}
