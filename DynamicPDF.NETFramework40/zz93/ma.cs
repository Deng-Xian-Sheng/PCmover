using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020001DC RID: 476
	internal class ma : ceTe.DynamicPDF.Action, IAnnotation
	{
		// Token: 0x06001445 RID: 5189 RVA: 0x000E110C File Offset: 0x000E010C
		internal ma()
		{
		}

		// Token: 0x06001446 RID: 5190 RVA: 0x000E119C File Offset: 0x000E019C
		internal ma(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001447 RID: 5191 RVA: 0x000E1234 File Offset: 0x000E0234
		internal new string a()
		{
			return this.a;
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x000E124C File Offset: 0x000E024C
		internal new void a(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x000E1258 File Offset: 0x000E0258
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteName(65);
			writer.WriteDictionaryOpen();
			writer.WriteName(ceTe.DynamicPDF.Action.a);
			writer.WriteName(this.b);
			writer.WriteName(83);
			writer.WriteName(this.c);
			writer.WriteName(this.c);
			writer.WriteText(this.a);
			writer.WriteDictionaryClose();
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x000E12C8 File Offset: 0x000E02C8
		internal new void a(PageWriter A_0, float A_1, float A_2, k4 A_3)
		{
			this.h = A_0.Dimensions.aw(A_1);
			this.j = A_0.Dimensions.ax(A_2);
			this.i = A_0.Dimensions.aw(A_1 + x5.b(A_3.a()));
			this.k = A_0.Dimensions.ax(A_2 + x5.b(A_3.ar()));
			this.g = new Annotation(this.h, this.j, this.i, this.k, this);
			A_0.Annotations.Add(this.g);
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x000E1370 File Offset: 0x000E0370
		internal new void a(PageWriter A_0, float A_1, float A_2, la A_3)
		{
			this.h = A_0.Dimensions.aw(A_1);
			this.j = A_0.Dimensions.ax(A_2);
			this.i = A_0.Dimensions.aw(A_1 + x5.b(A_3.aq()));
			this.k = A_0.Dimensions.ax(A_2 + x5.b(A_3.ar()));
			this.g = new Annotation(this.h, this.j, this.i, this.k, this);
			A_0.Annotations.Add(this.g);
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x000E1418 File Offset: 0x000E0418
		public void DrawAnnotation(DocumentWriter writer)
		{
			writer.WriteName(this.d);
			writer.WriteName(this.e);
			writer.WriteName(this.f);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteArrayClose();
			if (this != null)
			{
				this.Draw(writer);
			}
		}

		// Token: 0x04000993 RID: 2451
		private new string a;

		// Token: 0x04000994 RID: 2452
		private new byte[] b = new byte[]
		{
			65,
			99,
			116,
			105,
			111,
			110
		};

		// Token: 0x04000995 RID: 2453
		private new byte[] c = new byte[]
		{
			85,
			82,
			73
		};

		// Token: 0x04000996 RID: 2454
		private new byte[] d = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};

		// Token: 0x04000997 RID: 2455
		private byte[] e = new byte[]
		{
			76,
			105,
			110,
			107
		};

		// Token: 0x04000998 RID: 2456
		private byte[] f = new byte[]
		{
			66,
			111,
			114,
			100,
			101,
			114
		};

		// Token: 0x04000999 RID: 2457
		private Annotation g = null;

		// Token: 0x0400099A RID: 2458
		private float h;

		// Token: 0x0400099B RID: 2459
		private float i;

		// Token: 0x0400099C RID: 2460
		private float j;

		// Token: 0x0400099D RID: 2461
		private float k;
	}
}
