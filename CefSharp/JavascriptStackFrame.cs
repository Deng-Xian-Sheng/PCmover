using System;

namespace CefSharp
{
	// Token: 0x02000087 RID: 135
	public class JavascriptStackFrame
	{
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x000038B3 File Offset: 0x00001AB3
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x000038BB File Offset: 0x00001ABB
		public string FunctionName { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x000038C4 File Offset: 0x00001AC4
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x000038CC File Offset: 0x00001ACC
		public int LineNumber { get; set; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060003AA RID: 938 RVA: 0x000038D5 File Offset: 0x00001AD5
		// (set) Token: 0x060003AB RID: 939 RVA: 0x000038DD File Offset: 0x00001ADD
		public int ColumnNumber { get; set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060003AC RID: 940 RVA: 0x000038E6 File Offset: 0x00001AE6
		// (set) Token: 0x060003AD RID: 941 RVA: 0x000038EE File Offset: 0x00001AEE
		public string SourceName { get; set; }
	}
}
