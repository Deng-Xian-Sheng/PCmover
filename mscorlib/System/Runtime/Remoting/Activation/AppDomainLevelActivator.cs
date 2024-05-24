using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x02000893 RID: 2195
	[Serializable]
	internal class AppDomainLevelActivator : IActivator
	{
		// Token: 0x06005D0B RID: 23819 RVA: 0x001467A2 File Offset: 0x001449A2
		internal AppDomainLevelActivator(string remActivatorURL)
		{
			this.m_RemActivatorURL = remActivatorURL;
		}

		// Token: 0x06005D0C RID: 23820 RVA: 0x001467B1 File Offset: 0x001449B1
		internal AppDomainLevelActivator(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			this.m_NextActivator = (IActivator)info.GetValue("m_NextActivator", typeof(IActivator));
		}

		// Token: 0x17001000 RID: 4096
		// (get) Token: 0x06005D0D RID: 23821 RVA: 0x001467E7 File Offset: 0x001449E7
		// (set) Token: 0x06005D0E RID: 23822 RVA: 0x001467EF File Offset: 0x001449EF
		public virtual IActivator NextActivator
		{
			[SecurityCritical]
			get
			{
				return this.m_NextActivator;
			}
			[SecurityCritical]
			set
			{
				this.m_NextActivator = value;
			}
		}

		// Token: 0x17001001 RID: 4097
		// (get) Token: 0x06005D0F RID: 23823 RVA: 0x001467F8 File Offset: 0x001449F8
		public virtual ActivatorLevel Level
		{
			[SecurityCritical]
			get
			{
				return ActivatorLevel.AppDomain;
			}
		}

		// Token: 0x06005D10 RID: 23824 RVA: 0x001467FC File Offset: 0x001449FC
		[SecurityCritical]
		[ComVisible(true)]
		public virtual IConstructionReturnMessage Activate(IConstructionCallMessage ctorMsg)
		{
			ctorMsg.Activator = this.m_NextActivator;
			return ActivationServices.GetActivator().Activate(ctorMsg);
		}

		// Token: 0x040029E7 RID: 10727
		private IActivator m_NextActivator;

		// Token: 0x040029E8 RID: 10728
		private string m_RemActivatorURL;
	}
}
