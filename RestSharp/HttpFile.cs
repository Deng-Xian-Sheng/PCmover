using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x0200000F RID: 15
	[NullableContext(1)]
	[Nullable(0)]
	[Obsolete("The HttpFile class will be internal in future version")]
	public class HttpFile
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000038C2 File Offset: 0x00001AC2
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x000038CA File Offset: 0x00001ACA
		public long ContentLength { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000BA RID: 186 RVA: 0x000038D3 File Offset: 0x00001AD3
		// (set) Token: 0x060000BB RID: 187 RVA: 0x000038DB File Offset: 0x00001ADB
		public Action<Stream> Writer { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000BC RID: 188 RVA: 0x000038E4 File Offset: 0x00001AE4
		// (set) Token: 0x060000BD RID: 189 RVA: 0x000038EC File Offset: 0x00001AEC
		public string FileName { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000BE RID: 190 RVA: 0x000038F5 File Offset: 0x00001AF5
		// (set) Token: 0x060000BF RID: 191 RVA: 0x000038FD File Offset: 0x00001AFD
		public string ContentType { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003906 File Offset: 0x00001B06
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x0000390E File Offset: 0x00001B0E
		public string Name { get; set; }
	}
}
