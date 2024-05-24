using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x02000896 RID: 2198
	internal class RemotePropertyHolderAttribute : IContextAttribute
	{
		// Token: 0x06005D1C RID: 23836 RVA: 0x001468B5 File Offset: 0x00144AB5
		internal RemotePropertyHolderAttribute(IList cp)
		{
			this._cp = cp;
		}

		// Token: 0x06005D1D RID: 23837 RVA: 0x001468C4 File Offset: 0x00144AC4
		[SecurityCritical]
		[ComVisible(true)]
		public virtual bool IsContextOK(Context ctx, IConstructionCallMessage msg)
		{
			return false;
		}

		// Token: 0x06005D1E RID: 23838 RVA: 0x001468C8 File Offset: 0x00144AC8
		[SecurityCritical]
		[ComVisible(true)]
		public virtual void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
		{
			for (int i = 0; i < this._cp.Count; i++)
			{
				ctorMsg.ContextProperties.Add(this._cp[i]);
			}
		}

		// Token: 0x040029EA RID: 10730
		private IList _cp;
	}
}
