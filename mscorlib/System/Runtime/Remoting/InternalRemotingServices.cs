using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007CA RID: 1994
	[SecurityCritical]
	[ComVisible(true)]
	public class InternalRemotingServices
	{
		// Token: 0x0600567F RID: 22143 RVA: 0x00132FFD File Offset: 0x001311FD
		[SecurityCritical]
		[Conditional("_LOGGING")]
		public static void DebugOutChnl(string s)
		{
			Message.OutToUnmanagedDebugger("CHNL:" + s + "\n");
		}

		// Token: 0x06005680 RID: 22144 RVA: 0x00133014 File Offset: 0x00131214
		[Conditional("_LOGGING")]
		public static void RemotingTrace(params object[] messages)
		{
		}

		// Token: 0x06005681 RID: 22145 RVA: 0x00133016 File Offset: 0x00131216
		[Conditional("_DEBUG")]
		public static void RemotingAssert(bool condition, string message)
		{
		}

		// Token: 0x06005682 RID: 22146 RVA: 0x00133018 File Offset: 0x00131218
		[SecurityCritical]
		[CLSCompliant(false)]
		public static void SetServerIdentity(MethodCall m, object srvID)
		{
			((IInternalMessage)m).ServerIdentityObject = (ServerIdentity)srvID;
		}

		// Token: 0x06005683 RID: 22147 RVA: 0x00133034 File Offset: 0x00131234
		internal static RemotingMethodCachedData GetReflectionCachedData(MethodBase mi)
		{
			RuntimeMethodInfo runtimeMethodInfo;
			if ((runtimeMethodInfo = (mi as RuntimeMethodInfo)) != null)
			{
				return runtimeMethodInfo.RemotingCache;
			}
			RuntimeConstructorInfo runtimeConstructorInfo;
			if ((runtimeConstructorInfo = (mi as RuntimeConstructorInfo)) != null)
			{
				return runtimeConstructorInfo.RemotingCache;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeReflectionObject"));
		}

		// Token: 0x06005684 RID: 22148 RVA: 0x00133082 File Offset: 0x00131282
		internal static RemotingTypeCachedData GetReflectionCachedData(RuntimeType type)
		{
			return type.RemotingCache;
		}

		// Token: 0x06005685 RID: 22149 RVA: 0x0013308C File Offset: 0x0013128C
		internal static RemotingCachedData GetReflectionCachedData(MemberInfo mi)
		{
			MethodBase mi2;
			if ((mi2 = (mi as MethodBase)) != null)
			{
				return InternalRemotingServices.GetReflectionCachedData(mi2);
			}
			RuntimeType type;
			if ((type = (mi as RuntimeType)) != null)
			{
				return InternalRemotingServices.GetReflectionCachedData(type);
			}
			RuntimeFieldInfo runtimeFieldInfo;
			if ((runtimeFieldInfo = (mi as RuntimeFieldInfo)) != null)
			{
				return runtimeFieldInfo.RemotingCache;
			}
			SerializationFieldInfo serializationFieldInfo;
			if ((serializationFieldInfo = (mi as SerializationFieldInfo)) != null)
			{
				return serializationFieldInfo.RemotingCache;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeReflectionObject"));
		}

		// Token: 0x06005686 RID: 22150 RVA: 0x0013310C File Offset: 0x0013130C
		internal static RemotingCachedData GetReflectionCachedData(RuntimeParameterInfo reflectionObject)
		{
			return reflectionObject.RemotingCache;
		}

		// Token: 0x06005687 RID: 22151 RVA: 0x00133114 File Offset: 0x00131314
		[SecurityCritical]
		public static SoapAttribute GetCachedSoapAttribute(object reflectionObject)
		{
			MemberInfo memberInfo = reflectionObject as MemberInfo;
			RuntimeParameterInfo runtimeParameterInfo = reflectionObject as RuntimeParameterInfo;
			if (memberInfo != null)
			{
				return InternalRemotingServices.GetReflectionCachedData(memberInfo).GetSoapAttribute();
			}
			if (runtimeParameterInfo != null)
			{
				return InternalRemotingServices.GetReflectionCachedData(runtimeParameterInfo).GetSoapAttribute();
			}
			return null;
		}
	}
}
