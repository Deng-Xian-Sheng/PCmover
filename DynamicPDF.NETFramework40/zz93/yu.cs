using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003B5 RID: 949
	internal class yu : Resource
	{
		// Token: 0x0600282D RID: 10285 RVA: 0x0017508B File Offset: 0x0017408B
		internal yu(abj A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600282E RID: 10286 RVA: 0x0017509D File Offset: 0x0017409D
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			this.a.hz(writer);
			writer.WriteEndObject();
		}

		// Token: 0x040011A8 RID: 4520
		private new abj a;
	}
}
