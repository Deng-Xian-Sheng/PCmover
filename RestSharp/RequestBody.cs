using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000020 RID: 32
	[NullableContext(1)]
	[Nullable(0)]
	public class RequestBody
	{
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600030B RID: 779 RVA: 0x00006122 File Offset: 0x00004322
		public string ContentType { get; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600030C RID: 780 RVA: 0x0000612A File Offset: 0x0000432A
		public string Name { get; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600030D RID: 781 RVA: 0x00006132 File Offset: 0x00004332
		public object Value { get; }

		// Token: 0x0600030E RID: 782 RVA: 0x0000613A File Offset: 0x0000433A
		[Obsolete("The RestBody constructor will be internal in future versions")]
		public RequestBody(string contentType, string name, object value)
		{
			this.ContentType = contentType;
			this.Name = name;
			this.Value = value;
		}
	}
}
