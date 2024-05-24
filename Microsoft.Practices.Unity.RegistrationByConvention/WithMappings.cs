using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity
{
	// Token: 0x02000009 RID: 9
	public static class WithMappings
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00002AD6 File Offset: 0x00000CD6
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "implementationType", Justification = "Need to match signature Func<Type, IEnumerable<Type>>")]
		public static IEnumerable<Type> None(Type implementationType)
		{
			return WithMappings.EmptyTypes;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002AFC File Offset: 0x00000CFC
		[SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Validation done by Guard class")]
		public static IEnumerable<Type> FromMatchingInterface(Type implementationType)
		{
			Guard.ArgumentNotNull(implementationType, "implementationType");
			string matchingInterfaceName = "I" + implementationType.Name;
			Type type = WithMappings.GetImplementedInterfacesToMap(implementationType).FirstOrDefault((Type i) => string.Equals(i.Name, matchingInterfaceName, StringComparison.Ordinal));
			if (type != null)
			{
				return new Type[]
				{
					type
				};
			}
			return WithMappings.EmptyTypes;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002B75 File Offset: 0x00000D75
		public static IEnumerable<Type> FromAllInterfaces(Type implementationType)
		{
			Guard.ArgumentNotNull(implementationType, "implementationType");
			return from i in WithMappings.GetImplementedInterfacesToMap(implementationType)
			where i != typeof(IDisposable)
			select i;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002BCC File Offset: 0x00000DCC
		public static IEnumerable<Type> FromAllInterfacesInSameAssembly(Type implementationType)
		{
			Guard.ArgumentNotNull(implementationType, "implementationType");
			Assembly implementationTypeAssembly = implementationType.GetTypeInfo().Assembly;
			return from i in WithMappings.GetImplementedInterfacesToMap(implementationType)
			where i.GetTypeInfo().Assembly == implementationTypeAssembly
			select i;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002C14 File Offset: 0x00000E14
		private static IEnumerable<Type> GetImplementedInterfacesToMap(Type type)
		{
			TypeInfo typeInfo = type.GetTypeInfo();
			if (!typeInfo.IsGenericType)
			{
				return typeInfo.ImplementedInterfaces;
			}
			if (!typeInfo.IsGenericTypeDefinition)
			{
				return typeInfo.ImplementedInterfaces;
			}
			return WithMappings.FilterMatchingGenericInterfaces(typeInfo);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002E34 File Offset: 0x00001034
		private static IEnumerable<Type> FilterMatchingGenericInterfaces(TypeInfo typeInfo)
		{
			Type[] parameters = typeInfo.GenericTypeParameters;
			foreach (Type @interface in typeInfo.ImplementedInterfaces)
			{
				TypeInfo interfaceTypeInfo = @interface.GetTypeInfo();
				if (interfaceTypeInfo.IsGenericType && interfaceTypeInfo.ContainsGenericParameters && WithMappings.GenericParametersMatch(parameters, interfaceTypeInfo.GenericTypeArguments))
				{
					yield return interfaceTypeInfo.GetGenericTypeDefinition();
				}
			}
			yield break;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002E54 File Offset: 0x00001054
		private static bool GenericParametersMatch(Type[] parameters, Type[] interfaceArguments)
		{
			if (parameters.Length != interfaceArguments.Length)
			{
				return false;
			}
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i] != interfaceArguments[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04000016 RID: 22
		private static readonly Type[] EmptyTypes = new Type[0];
	}
}
