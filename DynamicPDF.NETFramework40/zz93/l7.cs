using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Html;

namespace zz93
{
	// Token: 0x020001D7 RID: 471
	internal class l7 : ceTe.DynamicPDF.Action, IAnnotation
	{
		// Token: 0x0600141D RID: 5149 RVA: 0x000E03F0 File Offset: 0x000DF3F0
		internal l7()
		{
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x000E0488 File Offset: 0x000DF488
		internal l7(string A_0, HtmlArea A_1)
		{
			this.n = A_0;
			this.o = A_1;
		}

		// Token: 0x0600141F RID: 5151 RVA: 0x000E0530 File Offset: 0x000DF530
		internal new void a(PageWriter A_0, float A_1, float A_2, k4 A_3)
		{
			this.e = A_0.Dimensions.aw(A_1);
			this.g = A_0.Dimensions.ax(A_2);
			this.f = A_0.Dimensions.aw(A_1 + x5.b(A_3.aq()));
			this.h = A_0.Dimensions.ax(A_2 + x5.b(A_3.ar()));
			this.d = new Annotation(this.e, this.g, this.f, this.h, this);
			A_0.Annotations.Add(this.d);
		}

		// Token: 0x06001420 RID: 5152 RVA: 0x000E05D8 File Offset: 0x000DF5D8
		internal new void a(PageWriter A_0, float A_1, float A_2, la A_3)
		{
			this.e = A_0.Dimensions.aw(A_1);
			this.g = A_0.Dimensions.ax(A_2);
			this.f = A_0.Dimensions.aw(A_1 + x5.b(A_3.aq()));
			this.h = A_0.Dimensions.ax(A_2 + x5.b(A_3.ar()));
			this.d = new Annotation(this.e, this.g, this.f, this.h, this);
			A_0.Annotations.Add(this.d);
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x000E0680 File Offset: 0x000DF680
		public void DrawAnnotation(DocumentWriter writer)
		{
			if (this.o != null && this.o.h().ContainsKey(this.n))
			{
				this.i = x5.b(((k5)this.o.h()[this.n]).a());
				this.j = x5.b(((k5)this.o.h()[this.n]).b());
				this.o = ((k5)this.o.h()[this.n]).c();
				if (this.o != null)
				{
					if (writer.ag().ContainsKey(this.o))
					{
						writer.WriteName(this.a);
						writer.WriteName(this.b);
						writer.WriteName(this.c);
						writer.WriteArrayOpen();
						writer.WriteNumber0();
						writer.WriteNumber0();
						writer.WriteNumber0();
						writer.WriteArrayClose();
						this.k = (int)writer.ag()[this.o];
						this.Draw(writer);
					}
				}
			}
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x000E07D4 File Offset: 0x000DF7D4
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteName(this.l);
			writer.WriteArrayOpen();
			writer.WriteReference(writer.GetPageObject(this.k));
			writer.WriteName("XYZ");
			writer.WriteNumber(writer.Document.Pages[this.k - 1].Dimensions.GetPdfX(this.i));
			writer.WriteNumber(writer.Document.Pages[this.k - 1].Dimensions.GetPdfY(this.j));
			writer.WriteNumber(0);
			writer.WriteArrayClose();
		}

		// Token: 0x04000978 RID: 2424
		private new byte[] a = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};

		// Token: 0x04000979 RID: 2425
		private new byte[] b = new byte[]
		{
			76,
			105,
			110,
			107
		};

		// Token: 0x0400097A RID: 2426
		private new byte[] c = new byte[]
		{
			66,
			111,
			114,
			100,
			101,
			114
		};

		// Token: 0x0400097B RID: 2427
		private new Annotation d = null;

		// Token: 0x0400097C RID: 2428
		private float e;

		// Token: 0x0400097D RID: 2429
		private float f;

		// Token: 0x0400097E RID: 2430
		private float g;

		// Token: 0x0400097F RID: 2431
		private float h;

		// Token: 0x04000980 RID: 2432
		private float i;

		// Token: 0x04000981 RID: 2433
		private float j;

		// Token: 0x04000982 RID: 2434
		private int k = 1;

		// Token: 0x04000983 RID: 2435
		private byte[] l = new byte[]
		{
			68,
			101,
			115,
			116
		};

		// Token: 0x04000984 RID: 2436
		private byte[] m = new byte[]
		{
			84,
			121,
			112,
			101
		};

		// Token: 0x04000985 RID: 2437
		private string n;

		// Token: 0x04000986 RID: 2438
		private HtmlArea o;
	}
}
