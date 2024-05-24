using System;

namespace QRCoder.Extensions
{
	// Token: 0x0200001B RID: 27
	public class StringValueAttribute : Attribute
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00006C4B File Offset: 0x00004E4B
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x00006C53 File Offset: 0x00004E53
		public string StringValue { get; protected set; }

		// Token: 0x060000A3 RID: 163 RVA: 0x00006C5C File Offset: 0x00004E5C
		public StringValueAttribute(string value)
		{
			this.StringValue = value;
		}
	}
}
