using System;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000836 RID: 2102
	[Serializable]
	internal class CrossAppDomainData
	{
		// Token: 0x17000EE9 RID: 3817
		// (get) Token: 0x060059DB RID: 23003 RVA: 0x0013CC5A File Offset: 0x0013AE5A
		internal virtual IntPtr ContextID
		{
			get
			{
				return new IntPtr((long)this._ContextID);
			}
		}

		// Token: 0x17000EEA RID: 3818
		// (get) Token: 0x060059DC RID: 23004 RVA: 0x0013CC6C File Offset: 0x0013AE6C
		internal virtual int DomainID
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this._DomainID;
			}
		}

		// Token: 0x17000EEB RID: 3819
		// (get) Token: 0x060059DD RID: 23005 RVA: 0x0013CC74 File Offset: 0x0013AE74
		internal virtual string ProcessGuid
		{
			get
			{
				return this._processGuid;
			}
		}

		// Token: 0x060059DE RID: 23006 RVA: 0x0013CC7C File Offset: 0x0013AE7C
		internal CrossAppDomainData(IntPtr ctxId, int domainID, string processGuid)
		{
			this._DomainID = domainID;
			this._processGuid = processGuid;
			this._ContextID = ctxId.ToInt64();
		}

		// Token: 0x060059DF RID: 23007 RVA: 0x0013CCB0 File Offset: 0x0013AEB0
		internal bool IsFromThisProcess()
		{
			return Identity.ProcessGuid.Equals(this._processGuid);
		}

		// Token: 0x060059E0 RID: 23008 RVA: 0x0013CCC2 File Offset: 0x0013AEC2
		[SecurityCritical]
		internal bool IsFromThisAppDomain()
		{
			return this.IsFromThisProcess() && Thread.GetDomain().GetId() == this._DomainID;
		}

		// Token: 0x040028E2 RID: 10466
		private object _ContextID = 0;

		// Token: 0x040028E3 RID: 10467
		private int _DomainID;

		// Token: 0x040028E4 RID: 10468
		private string _processGuid;
	}
}
