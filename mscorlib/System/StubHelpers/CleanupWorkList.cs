using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x020005AA RID: 1450
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	[SecurityCritical]
	internal sealed class CleanupWorkList
	{
		// Token: 0x06004329 RID: 17193 RVA: 0x000FA274 File Offset: 0x000F8474
		public void Add(CleanupWorkListElement elem)
		{
			this.m_list.Add(elem);
		}

		// Token: 0x0600432A RID: 17194 RVA: 0x000FA284 File Offset: 0x000F8484
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void Destroy()
		{
			for (int i = this.m_list.Count - 1; i >= 0; i--)
			{
				if (this.m_list[i].m_owned)
				{
					StubHelpers.SafeHandleRelease(this.m_list[i].m_handle);
				}
			}
		}

		// Token: 0x04001BE6 RID: 7142
		private List<CleanupWorkListElement> m_list = new List<CleanupWorkListElement>();
	}
}
