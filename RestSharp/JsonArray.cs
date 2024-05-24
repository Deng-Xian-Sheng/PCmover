using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000029 RID: 41
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[GeneratedCode("simple-json", "1.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class JsonArray : List<object>
	{
		// Token: 0x060003BA RID: 954 RVA: 0x00007321 File Offset: 0x00005521
		public JsonArray()
		{
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00007329 File Offset: 0x00005529
		public JsonArray(int capacity) : base(capacity)
		{
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00007332 File Offset: 0x00005532
		public override string ToString()
		{
			return SimpleJson.SerializeObject(this) ?? string.Empty;
		}
	}
}
