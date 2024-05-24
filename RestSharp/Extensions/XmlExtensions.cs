using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace RestSharp.Extensions
{
	// Token: 0x02000051 RID: 81
	public static class XmlExtensions
	{
		// Token: 0x060004F9 RID: 1273 RVA: 0x0000C6D8 File Offset: 0x0000A8D8
		[NullableContext(1)]
		public static XName AsNamespaced(this string name, string @namespace)
		{
			XName result = name;
			if (@namespace.HasValue())
			{
				result = XName.Get(name, @namespace);
			}
			return result;
		}
	}
}
