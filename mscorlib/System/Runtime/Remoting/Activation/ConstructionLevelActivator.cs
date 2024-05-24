using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x02000895 RID: 2197
	[Serializable]
	internal class ConstructionLevelActivator : IActivator
	{
		// Token: 0x06005D17 RID: 23831 RVA: 0x00146887 File Offset: 0x00144A87
		internal ConstructionLevelActivator()
		{
		}

		// Token: 0x17001004 RID: 4100
		// (get) Token: 0x06005D18 RID: 23832 RVA: 0x0014688F File Offset: 0x00144A8F
		// (set) Token: 0x06005D19 RID: 23833 RVA: 0x00146892 File Offset: 0x00144A92
		public virtual IActivator NextActivator
		{
			[SecurityCritical]
			get
			{
				return null;
			}
			[SecurityCritical]
			set
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x17001005 RID: 4101
		// (get) Token: 0x06005D1A RID: 23834 RVA: 0x00146899 File Offset: 0x00144A99
		public virtual ActivatorLevel Level
		{
			[SecurityCritical]
			get
			{
				return ActivatorLevel.Construction;
			}
		}

		// Token: 0x06005D1B RID: 23835 RVA: 0x0014689C File Offset: 0x00144A9C
		[SecurityCritical]
		[ComVisible(true)]
		public virtual IConstructionReturnMessage Activate(IConstructionCallMessage ctorMsg)
		{
			ctorMsg.Activator = ctorMsg.Activator.NextActivator;
			return ActivationServices.DoServerContextActivation(ctorMsg);
		}
	}
}
