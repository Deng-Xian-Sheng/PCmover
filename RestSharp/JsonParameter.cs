using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x0200001F RID: 31
	[NullableContext(1)]
	[Nullable(0)]
	public class JsonParameter : Parameter
	{
		// Token: 0x06000309 RID: 777 RVA: 0x000060E3 File Offset: 0x000042E3
		public JsonParameter(string name, object value) : base(name, value, ParameterType.RequestBody)
		{
			base.DataFormat = DataFormat.Json;
			base.ContentType = "application/json";
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00006100 File Offset: 0x00004300
		public JsonParameter(string name, object value, string contentType) : base(name, value, ParameterType.RequestBody)
		{
			base.DataFormat = DataFormat.Json;
			base.ContentType = (contentType ?? "application/json");
		}
	}
}
