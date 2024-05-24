using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000011 RID: 17
	[NullableContext(1)]
	[Nullable(0)]
	public class HttpParameter
	{
		// Token: 0x060000CA RID: 202 RVA: 0x0000397D File Offset: 0x00001B7D
		[NullableContext(2)]
		public HttpParameter([Nullable(1)] string name, string value, string contentType = null)
		{
			this.Name = name;
			this.ContentType = contentType;
			this.Value = (value ?? "");
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000039A3 File Offset: 0x00001BA3
		[NullableContext(2)]
		public HttpParameter([Nullable(1)] string name, object value, string contentType = null) : this(name, (value != null) ? value.ToString() : null, contentType)
		{
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000039B9 File Offset: 0x00001BB9
		[Obsolete("Use parameterized constructor")]
		public HttpParameter()
		{
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000CD RID: 205 RVA: 0x000039C1 File Offset: 0x00001BC1
		// (set) Token: 0x060000CE RID: 206 RVA: 0x000039C9 File Offset: 0x00001BC9
		public string Name { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000CF RID: 207 RVA: 0x000039D2 File Offset: 0x00001BD2
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x000039DA File Offset: 0x00001BDA
		public string Value { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x000039E3 File Offset: 0x00001BE3
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x000039EB File Offset: 0x00001BEB
		[Nullable(2)]
		public string ContentType { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
