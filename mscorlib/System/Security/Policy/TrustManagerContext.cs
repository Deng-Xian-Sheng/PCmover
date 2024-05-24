using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	// Token: 0x0200035C RID: 860
	[ComVisible(true)]
	public class TrustManagerContext
	{
		// Token: 0x06002A77 RID: 10871 RVA: 0x0009D132 File Offset: 0x0009B332
		public TrustManagerContext() : this(TrustManagerUIContext.Run)
		{
		}

		// Token: 0x06002A78 RID: 10872 RVA: 0x0009D13B File Offset: 0x0009B33B
		public TrustManagerContext(TrustManagerUIContext uiContext)
		{
			this.m_ignorePersistedDecision = false;
			this.m_uiContext = uiContext;
			this.m_keepAlive = false;
			this.m_persist = true;
		}

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x06002A79 RID: 10873 RVA: 0x0009D15F File Offset: 0x0009B35F
		// (set) Token: 0x06002A7A RID: 10874 RVA: 0x0009D167 File Offset: 0x0009B367
		public virtual TrustManagerUIContext UIContext
		{
			get
			{
				return this.m_uiContext;
			}
			set
			{
				this.m_uiContext = value;
			}
		}

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06002A7B RID: 10875 RVA: 0x0009D170 File Offset: 0x0009B370
		// (set) Token: 0x06002A7C RID: 10876 RVA: 0x0009D178 File Offset: 0x0009B378
		public virtual bool NoPrompt
		{
			get
			{
				return this.m_noPrompt;
			}
			set
			{
				this.m_noPrompt = value;
			}
		}

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x06002A7D RID: 10877 RVA: 0x0009D181 File Offset: 0x0009B381
		// (set) Token: 0x06002A7E RID: 10878 RVA: 0x0009D189 File Offset: 0x0009B389
		public virtual bool IgnorePersistedDecision
		{
			get
			{
				return this.m_ignorePersistedDecision;
			}
			set
			{
				this.m_ignorePersistedDecision = value;
			}
		}

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x06002A7F RID: 10879 RVA: 0x0009D192 File Offset: 0x0009B392
		// (set) Token: 0x06002A80 RID: 10880 RVA: 0x0009D19A File Offset: 0x0009B39A
		public virtual bool KeepAlive
		{
			get
			{
				return this.m_keepAlive;
			}
			set
			{
				this.m_keepAlive = value;
			}
		}

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x06002A81 RID: 10881 RVA: 0x0009D1A3 File Offset: 0x0009B3A3
		// (set) Token: 0x06002A82 RID: 10882 RVA: 0x0009D1AB File Offset: 0x0009B3AB
		public virtual bool Persist
		{
			get
			{
				return this.m_persist;
			}
			set
			{
				this.m_persist = value;
			}
		}

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x06002A83 RID: 10883 RVA: 0x0009D1B4 File Offset: 0x0009B3B4
		// (set) Token: 0x06002A84 RID: 10884 RVA: 0x0009D1BC File Offset: 0x0009B3BC
		public virtual ApplicationIdentity PreviousApplicationIdentity
		{
			get
			{
				return this.m_appId;
			}
			set
			{
				this.m_appId = value;
			}
		}

		// Token: 0x04001140 RID: 4416
		private bool m_ignorePersistedDecision;

		// Token: 0x04001141 RID: 4417
		private TrustManagerUIContext m_uiContext;

		// Token: 0x04001142 RID: 4418
		private bool m_noPrompt;

		// Token: 0x04001143 RID: 4419
		private bool m_keepAlive;

		// Token: 0x04001144 RID: 4420
		private bool m_persist;

		// Token: 0x04001145 RID: 4421
		private ApplicationIdentity m_appId;
	}
}
