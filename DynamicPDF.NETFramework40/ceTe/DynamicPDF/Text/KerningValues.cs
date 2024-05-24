using System;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000862 RID: 2146
	public class KerningValues
	{
		// Token: 0x060056EF RID: 22255 RVA: 0x002EB2C4 File Offset: 0x002EA2C4
		internal KerningValues(char[] A_0, short[] A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x060056F0 RID: 22256 RVA: 0x002EB2E0 File Offset: 0x002EA2E0
		public char[] Text
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x060056F1 RID: 22257 RVA: 0x002EB2F8 File Offset: 0x002EA2F8
		public short[] Spacing
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002E47 RID: 11847
		private char[] a;

		// Token: 0x04002E48 RID: 11848
		private short[] b;
	}
}
