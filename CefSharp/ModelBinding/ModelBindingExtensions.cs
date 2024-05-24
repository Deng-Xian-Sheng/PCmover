using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CefSharp.ModelBinding
{
	// Token: 0x020000BB RID: 187
	internal static class ModelBindingExtensions
	{
		// Token: 0x06000593 RID: 1427 RVA: 0x00008F37 File Offset: 0x00007137
		public static bool IsArray(this Type source)
		{
			return source.GetTypeInfo().BaseType == typeof(Array);
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00008F54 File Offset: 0x00007154
		public static bool IsCollection(this Type source)
		{
			Type collectionType = typeof(ICollection<>);
			return source.GetTypeInfo().IsGenericType && source.GetInterfaces().Any((Type i) => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == collectionType);
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00008FA0 File Offset: 0x000071A0
		public static bool IsEnumerable(this Type source)
		{
			Type typeFromHandle = typeof(IEnumerable<>);
			return source.GetTypeInfo().IsGenericType && source.GetGenericTypeDefinition() == typeFromHandle;
		}
	}
}
