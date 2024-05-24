using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000050 RID: 80
	internal class bo : Resource
	{
		// Token: 0x060002AF RID: 687 RVA: 0x0003E164 File Offset: 0x0003D164
		internal bo(GoToAction A_0)
		{
			this.a = A_0.a();
			this.b = A_0.b();
			this.c = A_0;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0003E190 File Offset: 0x0003D190
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(83);
			writer.WriteName(bo.i);
			writer.WriteName(68);
			writer.WriteArrayOpen();
			writer.WriteReferenceShallow(writer.GetPageObject(this.b));
			switch (this.a)
			{
			case PageZoom.Retain:
				writer.WriteName(bo.j);
				writer.WriteNull();
				writer.WriteNull();
				writer.WriteNull();
				break;
			case PageZoom.FitPage:
				writer.WriteName(bo.e);
				break;
			case PageZoom.FitWidth:
				writer.WriteName(bo.f);
				break;
			case PageZoom.FitHeight:
				writer.WriteName(bo.g);
				break;
			case PageZoom.FitBox:
				writer.WriteName(bo.h);
				break;
			}
			writer.WriteArrayClose();
			if (this.c.NextAction != null)
			{
				writer.WriteName(bo.d);
				this.c.NextAction.Draw(writer);
			}
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x040001E4 RID: 484
		private new PageZoom a;

		// Token: 0x040001E5 RID: 485
		private new int b;

		// Token: 0x040001E6 RID: 486
		private new GoToAction c;

		// Token: 0x040001E7 RID: 487
		private new static byte[] d = new byte[]
		{
			78,
			101,
			120,
			116
		};

		// Token: 0x040001E8 RID: 488
		private new static byte[] e = new byte[]
		{
			70,
			105,
			116
		};

		// Token: 0x040001E9 RID: 489
		private new static byte[] f = new byte[]
		{
			70,
			105,
			116,
			72
		};

		// Token: 0x040001EA RID: 490
		private new static byte[] g = new byte[]
		{
			70,
			105,
			116,
			86
		};

		// Token: 0x040001EB RID: 491
		private new static byte[] h = new byte[]
		{
			70,
			105,
			116,
			66
		};

		// Token: 0x040001EC RID: 492
		private new static byte[] i = new byte[]
		{
			71,
			111,
			84,
			111
		};

		// Token: 0x040001ED RID: 493
		private static byte[] j = new byte[]
		{
			88,
			89,
			90
		};
	}
}
