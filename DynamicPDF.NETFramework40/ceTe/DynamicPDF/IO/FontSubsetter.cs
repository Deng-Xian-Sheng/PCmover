using System;
using System.Collections.Generic;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006D6 RID: 1750
	public class FontSubsetter
	{
		// Token: 0x06004390 RID: 17296 RVA: 0x002301F6 File Offset: 0x0022F1F6
		public FontSubsetter(int glyphCount)
		{
			this.a = new bool[glyphCount];
		}

		// Token: 0x06004391 RID: 17297 RVA: 0x00230223 File Offset: 0x0022F223
		public void GlyphUsed(int glyphIndex)
		{
			this.a[glyphIndex] = true;
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06004392 RID: 17298 RVA: 0x00230230 File Offset: 0x0022F230
		public bool[] GlyphsUsed
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040025A8 RID: 9640
		private bool[] a;

		// Token: 0x040025A9 RID: 9641
		internal List<ushort> b = new List<ushort>();

		// Token: 0x040025AA RID: 9642
		internal List<char[]> c = new List<char[]>();
	}
}
