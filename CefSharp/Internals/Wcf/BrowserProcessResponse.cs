using System;
using System.Runtime.Serialization;

namespace CefSharp.Internals.Wcf
{
	// Token: 0x020000ED RID: 237
	[DataContract]
	[KnownType(typeof(bool[]))]
	[KnownType(typeof(byte[]))]
	[KnownType(typeof(short[]))]
	[KnownType(typeof(int[]))]
	[KnownType(typeof(long[]))]
	[KnownType(typeof(ushort[]))]
	[KnownType(typeof(uint[]))]
	[KnownType(typeof(ulong[]))]
	[KnownType(typeof(float[]))]
	[KnownType(typeof(double[]))]
	[KnownType(typeof(string[]))]
	public class BrowserProcessResponse
	{
		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x0000B91C File Offset: 0x00009B1C
		// (set) Token: 0x06000707 RID: 1799 RVA: 0x0000B924 File Offset: 0x00009B24
		[DataMember]
		public string Message { get; set; }

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x0000B92D File Offset: 0x00009B2D
		// (set) Token: 0x06000709 RID: 1801 RVA: 0x0000B935 File Offset: 0x00009B35
		[DataMember]
		public bool Success { get; set; }

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x0600070A RID: 1802 RVA: 0x0000B93E File Offset: 0x00009B3E
		// (set) Token: 0x0600070B RID: 1803 RVA: 0x0000B946 File Offset: 0x00009B46
		[DataMember]
		public object Result { get; set; }
	}
}
