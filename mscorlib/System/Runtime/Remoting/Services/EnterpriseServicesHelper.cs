using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Security;

namespace System.Runtime.Remoting.Services
{
	// Token: 0x02000804 RID: 2052
	[SecurityCritical]
	[ComVisible(true)]
	public sealed class EnterpriseServicesHelper
	{
		// Token: 0x06005869 RID: 22633 RVA: 0x00137DDC File Offset: 0x00135FDC
		[SecurityCritical]
		public static object WrapIUnknownWithComObject(IntPtr punk)
		{
			return Marshal.InternalWrapIUnknownWithComObject(punk);
		}

		// Token: 0x0600586A RID: 22634 RVA: 0x00137DE4 File Offset: 0x00135FE4
		[ComVisible(true)]
		public static IConstructionReturnMessage CreateConstructionReturnMessage(IConstructionCallMessage ctorMsg, MarshalByRefObject retObj)
		{
			return new ConstructorReturnMessage(retObj, null, 0, null, ctorMsg);
		}

		// Token: 0x0600586B RID: 22635 RVA: 0x00137E00 File Offset: 0x00136000
		[SecurityCritical]
		public static void SwitchWrappers(RealProxy oldcp, RealProxy newcp)
		{
			object transparentProxy = oldcp.GetTransparentProxy();
			object transparentProxy2 = newcp.GetTransparentProxy();
			IntPtr serverContextForProxy = RemotingServices.GetServerContextForProxy(transparentProxy);
			IntPtr serverContextForProxy2 = RemotingServices.GetServerContextForProxy(transparentProxy2);
			Marshal.InternalSwitchCCW(transparentProxy, transparentProxy2);
		}
	}
}
