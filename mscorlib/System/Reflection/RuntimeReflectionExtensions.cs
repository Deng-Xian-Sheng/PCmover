using System;
using System.Collections.Generic;

namespace System.Reflection
{
	// Token: 0x020005EC RID: 1516
	[__DynamicallyInvokable]
	public static class RuntimeReflectionExtensions
	{
		// Token: 0x0600464E RID: 17998 RVA: 0x00102477 File Offset: 0x00100677
		private static void CheckAndThrow(Type t)
		{
			if (t == null)
			{
				throw new ArgumentNullException("type");
			}
			if (!(t is RuntimeType))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
		}

		// Token: 0x0600464F RID: 17999 RVA: 0x001024A5 File Offset: 0x001006A5
		private static void CheckAndThrow(MethodInfo m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("method");
			}
			if (!(m is RuntimeMethodInfo))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"));
			}
		}

		// Token: 0x06004650 RID: 18000 RVA: 0x001024D3 File Offset: 0x001006D3
		[__DynamicallyInvokable]
		public static IEnumerable<PropertyInfo> GetRuntimeProperties(this Type type)
		{
			RuntimeReflectionExtensions.CheckAndThrow(type);
			return type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x06004651 RID: 18001 RVA: 0x001024E3 File Offset: 0x001006E3
		[__DynamicallyInvokable]
		public static IEnumerable<EventInfo> GetRuntimeEvents(this Type type)
		{
			RuntimeReflectionExtensions.CheckAndThrow(type);
			return type.GetEvents(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x06004652 RID: 18002 RVA: 0x001024F3 File Offset: 0x001006F3
		[__DynamicallyInvokable]
		public static IEnumerable<MethodInfo> GetRuntimeMethods(this Type type)
		{
			RuntimeReflectionExtensions.CheckAndThrow(type);
			return type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x06004653 RID: 18003 RVA: 0x00102503 File Offset: 0x00100703
		[__DynamicallyInvokable]
		public static IEnumerable<FieldInfo> GetRuntimeFields(this Type type)
		{
			RuntimeReflectionExtensions.CheckAndThrow(type);
			return type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x06004654 RID: 18004 RVA: 0x00102513 File Offset: 0x00100713
		[__DynamicallyInvokable]
		public static PropertyInfo GetRuntimeProperty(this Type type, string name)
		{
			RuntimeReflectionExtensions.CheckAndThrow(type);
			return type.GetProperty(name);
		}

		// Token: 0x06004655 RID: 18005 RVA: 0x00102522 File Offset: 0x00100722
		[__DynamicallyInvokable]
		public static EventInfo GetRuntimeEvent(this Type type, string name)
		{
			RuntimeReflectionExtensions.CheckAndThrow(type);
			return type.GetEvent(name);
		}

		// Token: 0x06004656 RID: 18006 RVA: 0x00102531 File Offset: 0x00100731
		[__DynamicallyInvokable]
		public static MethodInfo GetRuntimeMethod(this Type type, string name, Type[] parameters)
		{
			RuntimeReflectionExtensions.CheckAndThrow(type);
			return type.GetMethod(name, parameters);
		}

		// Token: 0x06004657 RID: 18007 RVA: 0x00102541 File Offset: 0x00100741
		[__DynamicallyInvokable]
		public static FieldInfo GetRuntimeField(this Type type, string name)
		{
			RuntimeReflectionExtensions.CheckAndThrow(type);
			return type.GetField(name);
		}

		// Token: 0x06004658 RID: 18008 RVA: 0x00102550 File Offset: 0x00100750
		[__DynamicallyInvokable]
		public static MethodInfo GetRuntimeBaseDefinition(this MethodInfo method)
		{
			RuntimeReflectionExtensions.CheckAndThrow(method);
			return method.GetBaseDefinition();
		}

		// Token: 0x06004659 RID: 18009 RVA: 0x0010255E File Offset: 0x0010075E
		[__DynamicallyInvokable]
		public static InterfaceMapping GetRuntimeInterfaceMap(this TypeInfo typeInfo, Type interfaceType)
		{
			if (typeInfo == null)
			{
				throw new ArgumentNullException("typeInfo");
			}
			if (!(typeInfo is RuntimeType))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			return typeInfo.GetInterfaceMap(interfaceType);
		}

		// Token: 0x0600465A RID: 18010 RVA: 0x00102593 File Offset: 0x00100793
		[__DynamicallyInvokable]
		public static MethodInfo GetMethodInfo(this Delegate del)
		{
			if (del == null)
			{
				throw new ArgumentNullException("del");
			}
			return del.Method;
		}

		// Token: 0x04001CC7 RID: 7367
		private const BindingFlags everything = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
	}
}
