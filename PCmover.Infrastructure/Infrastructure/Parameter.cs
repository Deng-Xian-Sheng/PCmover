using System;
using System.Collections.Generic;

namespace PCmover.Infrastructure
{
	// Token: 0x02000007 RID: 7
	public class Parameter
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000031 RID: 49 RVA: 0x0000243C File Offset: 0x0000063C
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00002444 File Offset: 0x00000644
		public string ParameterName { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000033 RID: 51 RVA: 0x0000244D File Offset: 0x0000064D
		// (set) Token: 0x06000034 RID: 52 RVA: 0x00002455 File Offset: 0x00000655
		public List<string> Arguments { get; set; }

		// Token: 0x06000035 RID: 53 RVA: 0x0000245E File Offset: 0x0000065E
		public Parameter()
		{
			this.Arguments = new List<string>();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002471 File Offset: 0x00000671
		public Parameter(string ParameterName)
		{
			this.ParameterName = ParameterName;
			this.Arguments = new List<string>();
		}
	}
}
