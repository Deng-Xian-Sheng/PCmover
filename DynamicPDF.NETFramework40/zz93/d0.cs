using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x020000B0 RID: 176
	internal abstract class d0
	{
		// Token: 0x06000857 RID: 2135 RVA: 0x00075AF3 File Offset: 0x00074AF3
		internal d0()
		{
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00075B24 File Offset: 0x00074B24
		internal string k()
		{
			return this.c;
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00075B3C File Offset: 0x00074B3C
		internal void c(string A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00075B48 File Offset: 0x00074B48
		internal string[] l()
		{
			return this.a;
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00075B60 File Offset: 0x00074B60
		internal void a(string[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00075B6C File Offset: 0x00074B6C
		internal ig m()
		{
			return this.b;
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00075B84 File Offset: 0x00074B84
		internal void a(ig A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00075B90 File Offset: 0x00074B90
		internal List<int> n()
		{
			return this.d;
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00075BA8 File Offset: 0x00074BA8
		internal void a(List<int> A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00075BB4 File Offset: 0x00074BB4
		internal List<string> o()
		{
			return this.e;
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00075BCC File Offset: 0x00074BCC
		internal void c(kg A_0)
		{
			string text = A_0.a0();
			if (this.e == null)
			{
				this.e = new List<string>();
			}
			if (text != null && text != string.Empty)
			{
				string text2 = A_0.ao();
				if (text2 != null && text2 != string.Empty)
				{
					this.e.Add(text + "=" + text2);
				}
				else
				{
					this.e.Add(text);
				}
			}
			else
			{
				A_0.at();
			}
		}

		// Token: 0x06000862 RID: 2146
		internal abstract int cn();

		// Token: 0x06000863 RID: 2147
		internal abstract string co();

		// Token: 0x0400047F RID: 1151
		private string[] a = null;

		// Token: 0x04000480 RID: 1152
		private ig b = null;

		// Token: 0x04000481 RID: 1153
		private string c = null;

		// Token: 0x04000482 RID: 1154
		private List<int> d = null;

		// Token: 0x04000483 RID: 1155
		private List<string> e = null;
	}
}
