using System;
using System.Runtime.InteropServices;

namespace System.Resources
{
	// Token: 0x0200039D RID: 925
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class SatelliteContractVersionAttribute : Attribute
	{
		// Token: 0x06002D97 RID: 11671 RVA: 0x000AE9E4 File Offset: 0x000ACBE4
		[__DynamicallyInvokable]
		public SatelliteContractVersionAttribute(string version)
		{
			if (version == null)
			{
				throw new ArgumentNullException("version");
			}
			this._version = version;
		}

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x06002D98 RID: 11672 RVA: 0x000AEA01 File Offset: 0x000ACC01
		[__DynamicallyInvokable]
		public string Version
		{
			[__DynamicallyInvokable]
			get
			{
				return this._version;
			}
		}

		// Token: 0x0400128B RID: 4747
		private string _version;
	}
}
