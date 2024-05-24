using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Proxies
{
	// Token: 0x020007FC RID: 2044
	[SecurityCritical]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class ProxyAttribute : Attribute, IContextAttribute
	{
		// Token: 0x06005826 RID: 22566 RVA: 0x001369F0 File Offset: 0x00134BF0
		[SecurityCritical]
		public virtual MarshalByRefObject CreateInstance(Type serverType)
		{
			if (serverType == null)
			{
				throw new ArgumentNullException("serverType");
			}
			RuntimeType runtimeType = serverType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			if (!serverType.IsContextful)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Activation_MBR_ProxyAttribute"));
			}
			if (serverType.IsAbstract)
			{
				throw new RemotingException(Environment.GetResourceString("Acc_CreateAbst"));
			}
			return this.CreateInstanceInternal(runtimeType);
		}

		// Token: 0x06005827 RID: 22567 RVA: 0x00136A68 File Offset: 0x00134C68
		internal MarshalByRefObject CreateInstanceInternal(RuntimeType serverType)
		{
			return ActivationServices.CreateInstance(serverType);
		}

		// Token: 0x06005828 RID: 22568 RVA: 0x00136A70 File Offset: 0x00134C70
		[SecurityCritical]
		public virtual RealProxy CreateProxy(ObjRef objRef, Type serverType, object serverObject, Context serverContext)
		{
			RemotingProxy remotingProxy = new RemotingProxy(serverType);
			if (serverContext != null)
			{
				RealProxy.SetStubData(remotingProxy, serverContext.InternalContextID);
			}
			if (objRef != null && objRef.GetServerIdentity().IsAllocated)
			{
				remotingProxy.SetSrvInfo(objRef.GetServerIdentity(), objRef.GetDomainID());
			}
			remotingProxy.Initialized = true;
			if (!serverType.IsContextful && !serverType.IsMarshalByRef && serverContext != null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Activation_MBR_ProxyAttribute"));
			}
			return remotingProxy;
		}

		// Token: 0x06005829 RID: 22569 RVA: 0x00136AED File Offset: 0x00134CED
		[SecurityCritical]
		[ComVisible(true)]
		public bool IsContextOK(Context ctx, IConstructionCallMessage msg)
		{
			return true;
		}

		// Token: 0x0600582A RID: 22570 RVA: 0x00136AF0 File Offset: 0x00134CF0
		[SecurityCritical]
		[ComVisible(true)]
		public void GetPropertiesForNewContext(IConstructionCallMessage msg)
		{
		}
	}
}
