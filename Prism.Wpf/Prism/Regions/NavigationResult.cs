using System;

namespace Prism.Regions
{
	// Token: 0x02000020 RID: 32
	public class NavigationResult
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x00002BB8 File Offset: 0x00000DB8
		public NavigationResult(NavigationContext context, bool? result)
		{
			this.Context = context;
			this.Result = result;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00002BCE File Offset: 0x00000DCE
		public NavigationResult(NavigationContext context, Exception error)
		{
			this.Context = context;
			this.Error = error;
			this.Result = new bool?(false);
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00002BF0 File Offset: 0x00000DF0
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00002BF8 File Offset: 0x00000DF8
		public bool? Result { get; private set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00002C01 File Offset: 0x00000E01
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00002C09 File Offset: 0x00000E09
		public Exception Error { get; private set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00002C12 File Offset: 0x00000E12
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00002C1A File Offset: 0x00000E1A
		public NavigationContext Context { get; private set; }
	}
}
