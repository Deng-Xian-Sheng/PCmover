using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x02000894 RID: 2196
	[Serializable]
	internal class ContextLevelActivator : IActivator
	{
		// Token: 0x06005D11 RID: 23825 RVA: 0x00146815 File Offset: 0x00144A15
		internal ContextLevelActivator()
		{
			this.m_NextActivator = null;
		}

		// Token: 0x06005D12 RID: 23826 RVA: 0x00146824 File Offset: 0x00144A24
		internal ContextLevelActivator(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			this.m_NextActivator = (IActivator)info.GetValue("m_NextActivator", typeof(IActivator));
		}

		// Token: 0x17001002 RID: 4098
		// (get) Token: 0x06005D13 RID: 23827 RVA: 0x0014685A File Offset: 0x00144A5A
		// (set) Token: 0x06005D14 RID: 23828 RVA: 0x00146862 File Offset: 0x00144A62
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

		// Token: 0x17001003 RID: 4099
		// (get) Token: 0x06005D15 RID: 23829 RVA: 0x0014686B File Offset: 0x00144A6B
		public virtual ActivatorLevel Level
		{
			[SecurityCritical]
			get
			{
				return ActivatorLevel.Context;
			}
		}

		// Token: 0x06005D16 RID: 23830 RVA: 0x0014686E File Offset: 0x00144A6E
		[SecurityCritical]
		[ComVisible(true)]
		public virtual IConstructionReturnMessage Activate(IConstructionCallMessage ctorMsg)
		{
			ctorMsg.Activator = ctorMsg.Activator.NextActivator;
			return ActivationServices.DoCrossContextActivation(ctorMsg);
		}

		// Token: 0x040029E9 RID: 10729
		private IActivator m_NextActivator;
	}
}
