using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x02000086 RID: 134
	[DataContract]
	[KnownType(typeof(object[]))]
	[KnownType(typeof(JavascriptCallback))]
	[KnownType(typeof(Dictionary<string, object>))]
	public class JavascriptResponse
	{
		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00003878 File Offset: 0x00001A78
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x00003880 File Offset: 0x00001A80
		[DataMember]
		public string Message { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00003889 File Offset: 0x00001A89
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x00003891 File Offset: 0x00001A91
		[DataMember]
		public bool Success { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x0000389A File Offset: 0x00001A9A
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x000038A2 File Offset: 0x00001AA2
		[DataMember]
		public object Result { get; set; }
	}
}
