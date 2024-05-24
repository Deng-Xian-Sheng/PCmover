using System;
using System.Security.Principal;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200088E RID: 2190
	[Serializable]
	internal class CallContextSecurityData : ICloneable
	{
		// Token: 0x17000FF7 RID: 4087
		// (get) Token: 0x06005CD6 RID: 23766 RVA: 0x0014583B File Offset: 0x00143A3B
		// (set) Token: 0x06005CD7 RID: 23767 RVA: 0x00145843 File Offset: 0x00143A43
		internal IPrincipal Principal
		{
			get
			{
				return this._principal;
			}
			set
			{
				this._principal = value;
			}
		}

		// Token: 0x17000FF8 RID: 4088
		// (get) Token: 0x06005CD8 RID: 23768 RVA: 0x0014584C File Offset: 0x00143A4C
		internal bool HasInfo
		{
			get
			{
				return this._principal != null;
			}
		}

		// Token: 0x06005CD9 RID: 23769 RVA: 0x00145858 File Offset: 0x00143A58
		public object Clone()
		{
			return new CallContextSecurityData
			{
				_principal = this._principal
			};
		}

		// Token: 0x040029DB RID: 10715
		private IPrincipal _principal;
	}
}
