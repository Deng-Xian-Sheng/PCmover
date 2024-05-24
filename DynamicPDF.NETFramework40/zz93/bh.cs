using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000048 RID: 72
	internal class bh : Resource
	{
		// Token: 0x06000291 RID: 657 RVA: 0x0003DD24 File Offset: 0x0003CD24
		internal bh(string A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0003DD78 File Offset: 0x0003CD78
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(bh.d);
			writer.WriteName(this.a);
			writer.WriteText(this.c);
			writer.WriteName(this.b);
			writer.WriteText(this.c);
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x040001B0 RID: 432
		private new byte[] a = new byte[]
		{
			70
		};

		// Token: 0x040001B1 RID: 433
		private new byte[] b = new byte[]
		{
			85,
			70
		};

		// Token: 0x040001B2 RID: 434
		private new string c = "";

		// Token: 0x040001B3 RID: 435
		private new static byte[] d = new byte[]
		{
			70,
			105,
			108,
			101,
			115,
			112,
			101,
			99
		};
	}
}
