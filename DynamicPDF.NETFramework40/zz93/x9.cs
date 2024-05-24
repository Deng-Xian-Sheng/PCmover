using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200039F RID: 927
	internal class x9 : Resource
	{
		// Token: 0x0600278A RID: 10122 RVA: 0x0016B187 File Offset: 0x0016A187
		internal x9(DocumentJavaScriptList A_0, abj A_1, EmbeddedFileList A_2)
		{
			this.a = A_0;
			this.c = A_1;
			this.d = A_2;
		}

		// Token: 0x0600278B RID: 10123 RVA: 0x0016B1A8 File Offset: 0x0016A1A8
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			if (this.a != null)
			{
				writer.WriteName(x9.b);
				writer.WriteReferenceUnique(this.a);
			}
			if (this.d != null)
			{
				writer.WriteName(x9.e);
				writer.WriteReferenceUnique(this.d);
			}
			if (this.c != null)
			{
				this.c.b(writer);
			}
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x0400111D RID: 4381
		private new DocumentJavaScriptList a;

		// Token: 0x0400111E RID: 4382
		private new static byte[] b = new byte[]
		{
			74,
			97,
			118,
			97,
			83,
			99,
			114,
			105,
			112,
			116
		};

		// Token: 0x0400111F RID: 4383
		private new abj c;

		// Token: 0x04001120 RID: 4384
		private new EmbeddedFileList d;

		// Token: 0x04001121 RID: 4385
		private new static byte[] e = new byte[]
		{
			69,
			109,
			98,
			101,
			100,
			100,
			101,
			100,
			70,
			105,
			108,
			101,
			115
		};
	}
}
