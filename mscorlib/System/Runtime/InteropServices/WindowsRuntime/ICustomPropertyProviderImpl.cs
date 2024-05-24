using System;
using System.Reflection;
using System.Security;
using System.StubHelpers;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A0B RID: 2571
	internal static class ICustomPropertyProviderImpl
	{
		// Token: 0x0600657E RID: 25982 RVA: 0x001593F0 File Offset: 0x001575F0
		internal static ICustomProperty CreateProperty(object target, string propertyName)
		{
			PropertyInfo property = target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
			if (property == null)
			{
				return null;
			}
			return new CustomPropertyImpl(property);
		}

		// Token: 0x0600657F RID: 25983 RVA: 0x00159420 File Offset: 0x00157620
		[SecurityCritical]
		internal unsafe static ICustomProperty CreateIndexedProperty(object target, string propertyName, TypeNameNative* pIndexedParamType)
		{
			Type indexedParamType = null;
			SystemTypeMarshaler.ConvertToManaged(pIndexedParamType, ref indexedParamType);
			return ICustomPropertyProviderImpl.CreateIndexedProperty(target, propertyName, indexedParamType);
		}

		// Token: 0x06006580 RID: 25984 RVA: 0x00159440 File Offset: 0x00157640
		internal static ICustomProperty CreateIndexedProperty(object target, string propertyName, Type indexedParamType)
		{
			PropertyInfo property = target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, null, new Type[]
			{
				indexedParamType
			}, null);
			if (property == null)
			{
				return null;
			}
			return new CustomPropertyImpl(property);
		}

		// Token: 0x06006581 RID: 25985 RVA: 0x0015947A File Offset: 0x0015767A
		[SecurityCritical]
		internal unsafe static void GetType(object target, TypeNameNative* pIndexedParamType)
		{
			SystemTypeMarshaler.ConvertToNative(target.GetType(), pIndexedParamType);
		}
	}
}
