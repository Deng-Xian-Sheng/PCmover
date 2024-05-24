using System;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003A8 RID: 936
	internal class yi : yh
	{
		// Token: 0x060027C3 RID: 10179 RVA: 0x0016C114 File Offset: 0x0016B114
		internal yi(TiffImageData A_0, yj A_1) : base(A_1, A_0.Width, A_0.Height)
		{
			this.a = A_0;
			byte[] array = null;
			if (A_1.b(34675U))
			{
				array = A_1.m();
			}
			if (array != null)
			{
				this.b = new bn(array);
			}
		}

		// Token: 0x060027C4 RID: 10180 RVA: 0x0016C178 File Offset: 0x0016B178
		internal override void gy(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(yg.g);
			A_0.WriteName(yg.k);
			A_0.WriteName(yg.h);
			A_0.WriteName(yg.l);
			if (this.a.Interpolate)
			{
				A_0.WriteName(yg.a);
				A_0.WriteBoolean(true);
			}
			A_0.WriteName(yg.b);
			A_0.WriteNumber(this.a.Width);
			A_0.WriteName(yg.c);
			A_0.WriteNumber(this.a.Height);
			A_0.WriteName(yg.d);
			A_0.WriteNumber1();
			A_0.WriteName(yg.e);
			if (this.b != null && this.b.b() == 1)
			{
				A_0.WriteArrayOpen();
				A_0.WriteName(yg.x);
				A_0.WriteReference(this.b.a());
				A_0.WriteArrayClose();
			}
			else
			{
				A_0.WriteName(yg.f);
			}
			A_0.WriteName(yg.i);
			A_0.WriteName(yg.q);
			A_0.WriteName(yg.p);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(75);
			A_0.WriteNumber0();
			A_0.WriteName(yg.o);
			A_0.WriteNumber(this.a.Width);
			if (base.b())
			{
				A_0.WriteName(yg.m);
				A_0.WriteBoolean(true);
			}
			A_0.WriteName(yg.n);
			A_0.WriteBoolean(true);
			A_0.WriteDictionaryClose();
			A_0.WriteName(yg.j);
			A_0.ai(this.gx().Length);
			A_0.WriteDictionaryClose();
			A_0.WriteStream(this.gx(), this.gx().Length);
			A_0.WriteEndObject();
		}

		// Token: 0x0400114A RID: 4426
		private new TiffImageData a;

		// Token: 0x0400114B RID: 4427
		private new bn b = null;
	}
}
