using System;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003AB RID: 939
	internal class yl : yh
	{
		// Token: 0x060027E0 RID: 10208 RVA: 0x0016D310 File Offset: 0x0016C310
		internal yl(TiffImageData A_0, yj A_1) : base(A_1, A_0.Width, A_0.Height)
		{
			uint num = 0U;
			byte[] array = null;
			this.a = A_0;
			if (A_1.b(293U))
			{
				num = A_1.i();
			}
			if ((num & 2U) == 2U)
			{
				throw new ImageParsingException("Group 4 uncompressed mode is unsupported.");
			}
			if (A_1.b(34675U))
			{
				array = A_1.m();
			}
			if (array != null)
			{
				this.c = new bn(array);
			}
		}

		// Token: 0x060027E1 RID: 10209 RVA: 0x0016D3AC File Offset: 0x0016C3AC
		protected override byte[] gz(yj A_0, uint[] A_1, uint[] A_2, bool A_3)
		{
			byte[] result;
			if (A_1.Length == 1 && A_2[0] == 0U)
			{
				result = base.gz(A_0, A_1, A_2, A_3);
			}
			else
			{
				this.b = new yn(A_0, A_1, A_2, A_3, base.c(), base.d(), base.a());
				result = this.b.d();
			}
			return result;
		}

		// Token: 0x060027E2 RID: 10210 RVA: 0x0016D414 File Offset: 0x0016C414
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
			if (this.c != null && this.c.b() == 1)
			{
				A_0.WriteArrayOpen();
				A_0.WriteName(yg.x);
				A_0.WriteReference(this.c.a());
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
			A_0.WriteNumberNeg1();
			A_0.WriteName(yg.o);
			A_0.WriteNumber(this.a.Width);
			if (base.b())
			{
				A_0.WriteName(yg.m);
				A_0.WriteBoolean(true);
			}
			A_0.WriteDictionaryClose();
			if (this.b == null)
			{
				A_0.WriteName(yg.j);
				A_0.ai(this.gx().Length);
				A_0.WriteDictionaryClose();
				A_0.WriteStream(this.gx(), this.gx().Length);
			}
			else
			{
				A_0.WriteName(yg.j);
				A_0.ai(this.b.e());
				A_0.WriteDictionaryClose();
				A_0.WriteStream(this.b.d(), this.b.e());
			}
			A_0.WriteEndObject();
		}

		// Token: 0x04001159 RID: 4441
		private new TiffImageData a;

		// Token: 0x0400115A RID: 4442
		private new yn b = null;

		// Token: 0x0400115B RID: 4443
		private new bn c = null;
	}
}
