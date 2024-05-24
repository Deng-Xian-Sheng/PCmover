using System;
using System.Collections.Generic;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000016 RID: 22
	public class PcmoverObjectComparer<T> : EqualityComparer<T> where T : IPCmoverObject
	{
		// Token: 0x0600007A RID: 122 RVA: 0x000040F0 File Offset: 0x000022F0
		public override int GetHashCode(T pcmObj)
		{
			return pcmObj.Id.GetHashCode();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00004112 File Offset: 0x00002312
		public override bool Equals(T pcmObj1, T pcmObj2)
		{
			return pcmObj1.Id == pcmObj2.Id;
		}
	}
}
