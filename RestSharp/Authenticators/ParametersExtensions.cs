using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using RestSharp.Authenticators.OAuth;

namespace RestSharp.Authenticators
{
	// Token: 0x0200005B RID: 91
	internal static class ParametersExtensions
	{
		// Token: 0x06000540 RID: 1344 RVA: 0x0000CE6E File Offset: 0x0000B06E
		[NullableContext(1)]
		internal static IEnumerable<WebPair> ToWebParameters(this IEnumerable<Parameter> p)
		{
			return from x in p
			select new WebPair(x.Name, x.Value.ToString(), false);
		}
	}
}
