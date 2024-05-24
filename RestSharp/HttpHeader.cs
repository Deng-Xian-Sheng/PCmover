using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000010 RID: 16
	[NullableContext(1)]
	[Nullable(0)]
	public class HttpHeader
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x0000391F File Offset: 0x00001B1F
		public HttpHeader(string name, [Nullable(2)] string value)
		{
			this.Name = name;
			this.Value = (value ?? "");
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000393E File Offset: 0x00001B3E
		public HttpHeader(string name, [Nullable(2)] object value) : this(name, (value != null) ? value.ToString() : null)
		{
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003953 File Offset: 0x00001B53
		[Obsolete("Use parameterized constructor")]
		public HttpHeader()
		{
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x0000395B File Offset: 0x00001B5B
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00003963 File Offset: 0x00001B63
		public string Name { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x0000396C File Offset: 0x00001B6C
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x00003974 File Offset: 0x00001B74
		public string Value { get; set; }
	}
}
