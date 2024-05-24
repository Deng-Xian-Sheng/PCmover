using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x0200001C RID: 28
	[NullableContext(1)]
	[Nullable(0)]
	public class NameValuePair
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x00005E72 File Offset: 0x00004072
		public NameValuePair(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x00005E88 File Offset: 0x00004088
		public string Name { get; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00005E90 File Offset: 0x00004090
		public string Value { get; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x00005E98 File Offset: 0x00004098
		public bool IsEmpty
		{
			get
			{
				return this.Name == null;
			}
		}

		// Token: 0x0400009C RID: 156
		public static NameValuePair Empty = new NameValuePair(null, null);
	}
}
