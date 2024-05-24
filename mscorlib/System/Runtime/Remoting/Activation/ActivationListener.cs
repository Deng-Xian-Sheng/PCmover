using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x02000892 RID: 2194
	internal class ActivationListener : MarshalByRefObject, IActivator
	{
		// Token: 0x06005D05 RID: 23813 RVA: 0x001466E4 File Offset: 0x001448E4
		[SecurityCritical]
		public override object InitializeLifetimeService()
		{
			return null;
		}

		// Token: 0x17000FFE RID: 4094
		// (get) Token: 0x06005D06 RID: 23814 RVA: 0x001466E7 File Offset: 0x001448E7
		// (set) Token: 0x06005D07 RID: 23815 RVA: 0x001466EA File Offset: 0x001448EA
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

		// Token: 0x17000FFF RID: 4095
		// (get) Token: 0x06005D08 RID: 23816 RVA: 0x001466F1 File Offset: 0x001448F1
		public virtual ActivatorLevel Level
		{
			[SecurityCritical]
			get
			{
				return ActivatorLevel.AppDomain;
			}
		}

		// Token: 0x06005D09 RID: 23817 RVA: 0x001466F8 File Offset: 0x001448F8
		[SecurityCritical]
		[ComVisible(true)]
		public virtual IConstructionReturnMessage Activate(IConstructionCallMessage ctorMsg)
		{
			if (ctorMsg == null || RemotingServices.IsTransparentProxy(ctorMsg))
			{
				throw new ArgumentNullException("ctorMsg");
			}
			ctorMsg.Properties["Permission"] = "allowed";
			string activationTypeName = ctorMsg.ActivationTypeName;
			if (!RemotingConfigHandler.IsActivationAllowed(activationTypeName))
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Activation_PermissionDenied"), ctorMsg.ActivationTypeName));
			}
			Type activationType = ctorMsg.ActivationType;
			if (activationType == null)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_BadType"), ctorMsg.ActivationTypeName));
			}
			return ActivationServices.GetActivator().Activate(ctorMsg);
		}
	}
}
