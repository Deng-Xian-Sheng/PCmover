using System;
using System.Collections;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200088C RID: 2188
	internal class IllogicalCallContext
	{
		// Token: 0x17000FED RID: 4077
		// (get) Token: 0x06005CB4 RID: 23732 RVA: 0x00145154 File Offset: 0x00143354
		private Hashtable Datastore
		{
			get
			{
				if (this.m_Datastore == null)
				{
					this.m_Datastore = new Hashtable();
				}
				return this.m_Datastore;
			}
		}

		// Token: 0x17000FEE RID: 4078
		// (get) Token: 0x06005CB5 RID: 23733 RVA: 0x0014516F File Offset: 0x0014336F
		// (set) Token: 0x06005CB6 RID: 23734 RVA: 0x00145177 File Offset: 0x00143377
		internal object HostContext
		{
			get
			{
				return this.m_HostContext;
			}
			set
			{
				this.m_HostContext = value;
			}
		}

		// Token: 0x17000FEF RID: 4079
		// (get) Token: 0x06005CB7 RID: 23735 RVA: 0x00145180 File Offset: 0x00143380
		internal bool HasUserData
		{
			get
			{
				return this.m_Datastore != null && this.m_Datastore.Count > 0;
			}
		}

		// Token: 0x06005CB8 RID: 23736 RVA: 0x0014519A File Offset: 0x0014339A
		public void FreeNamedDataSlot(string name)
		{
			this.Datastore.Remove(name);
		}

		// Token: 0x06005CB9 RID: 23737 RVA: 0x001451A8 File Offset: 0x001433A8
		public object GetData(string name)
		{
			return this.Datastore[name];
		}

		// Token: 0x06005CBA RID: 23738 RVA: 0x001451B6 File Offset: 0x001433B6
		public void SetData(string name, object data)
		{
			this.Datastore[name] = data;
		}

		// Token: 0x06005CBB RID: 23739 RVA: 0x001451C8 File Offset: 0x001433C8
		public IllogicalCallContext CreateCopy()
		{
			IllogicalCallContext illogicalCallContext = new IllogicalCallContext();
			illogicalCallContext.HostContext = this.HostContext;
			if (this.HasUserData)
			{
				IDictionaryEnumerator enumerator = this.m_Datastore.GetEnumerator();
				while (enumerator.MoveNext())
				{
					illogicalCallContext.Datastore[(string)enumerator.Key] = enumerator.Value;
				}
			}
			return illogicalCallContext;
		}

		// Token: 0x040029D0 RID: 10704
		private Hashtable m_Datastore;

		// Token: 0x040029D1 RID: 10705
		private object m_HostContext;

		// Token: 0x02000C7A RID: 3194
		internal struct Reader
		{
			// Token: 0x060070BB RID: 28859 RVA: 0x00184B2C File Offset: 0x00182D2C
			public Reader(IllogicalCallContext ctx)
			{
				this.m_ctx = ctx;
			}

			// Token: 0x17001356 RID: 4950
			// (get) Token: 0x060070BC RID: 28860 RVA: 0x00184B35 File Offset: 0x00182D35
			public bool IsNull
			{
				get
				{
					return this.m_ctx == null;
				}
			}

			// Token: 0x060070BD RID: 28861 RVA: 0x00184B40 File Offset: 0x00182D40
			[SecurityCritical]
			public object GetData(string name)
			{
				if (!this.IsNull)
				{
					return this.m_ctx.GetData(name);
				}
				return null;
			}

			// Token: 0x17001357 RID: 4951
			// (get) Token: 0x060070BE RID: 28862 RVA: 0x00184B58 File Offset: 0x00182D58
			public object HostContext
			{
				get
				{
					if (!this.IsNull)
					{
						return this.m_ctx.HostContext;
					}
					return null;
				}
			}

			// Token: 0x04003806 RID: 14342
			private IllogicalCallContext m_ctx;
		}
	}
}
