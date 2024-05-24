using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x020002A9 RID: 681
	internal class rw : FormattedTextArea, ru, rv
	{
		// Token: 0x06001E49 RID: 7753 RVA: 0x00131BC4 File Offset: 0x00130BC4
		internal rw(rw A_0) : base(A_0)
		{
			this.a = A_0.fd();
			this.b = A_0.fe();
		}

		// Token: 0x06001E4A RID: 7754 RVA: 0x00131BE8 File Offset: 0x00130BE8
		internal rw(FormattedRecordArea A_0, char[] A_1) : base(A_0, A_1)
		{
			this.a = A_0.gk();
			this.b = A_0.Splittable;
		}

		// Token: 0x06001E4B RID: 7755 RVA: 0x00131C0D File Offset: 0x00130C0D
		internal rw(rw A_0, float A_1, float A_2, float A_3) : base(A_0, A_1, A_2, A_3)
		{
			this.a = A_0.fd();
			this.b = A_0.fe();
		}

		// Token: 0x06001E4C RID: 7756 RVA: 0x00131C38 File Offset: 0x00130C38
		void ru.a(acm A_0)
		{
			float num = new FormattedTextArea.b(this, base.b().ToCharArray(), 0).b(0);
			if (num > this.Height)
			{
				A_0.a(x5.a(this.Y), x5.a(this.Y + this.Height), x5.a(num - this.Height));
				this.Height = num;
			}
		}

		// Token: 0x06001E4D RID: 7757 RVA: 0x00131CAD File Offset: 0x00130CAD
		void rv.a(char[] A_0, bool A_1)
		{
			base.a(false);
			base.a(new string(A_0));
		}

		// Token: 0x06001E4E RID: 7758 RVA: 0x00131CC8 File Offset: 0x00130CC8
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (this.fe())
			{
				this.a(x5.b(A_0));
				if (base.e() == 0)
				{
					base.a(false);
					result = w0.c;
				}
				else
				{
					result = x5.a(base.c().b(0, base.e()));
				}
			}
			else
			{
				result = w0.c;
			}
			return result;
		}

		// Token: 0x06001E4F RID: 7759 RVA: 0x00131D3C File Offset: 0x00130D3C
		internal override PageElement fb(x5 A_0)
		{
			float height = this.Height;
			base.a(false);
			this.Height = x5.b(A_0) + 0.001f;
			base.a(true);
			PageElement result;
			if (base.HasOverflowText())
			{
				rw rw = new rw(this, this.X, 0f, height - this.Height);
				result = rw;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06001E50 RID: 7760 RVA: 0x00131DA8 File Offset: 0x00130DA8
		internal void a(float A_0)
		{
			if (!base.g() || !base.h().Equals(base.Style))
			{
				base.a(new FormattedTextAreaStyle(base.Style));
				base.a(new FormattedTextArea.b(this, base.b().ToCharArray(), 0));
				base.b(0);
				base.b(0f);
				base.c(base.c().b(A_0, 0));
				base.c(base.c().b(0));
				base.a(true);
			}
			if (base.g())
			{
				base.c(base.c().b(A_0, base.d()));
			}
		}

		// Token: 0x06001E51 RID: 7761 RVA: 0x00131E70 File Offset: 0x00130E70
		internal override PageElement fc()
		{
			return new rw(this);
		}

		// Token: 0x06001E52 RID: 7762 RVA: 0x00131E88 File Offset: 0x00130E88
		internal override short fd()
		{
			return this.a;
		}

		// Token: 0x06001E53 RID: 7763 RVA: 0x00131EA0 File Offset: 0x00130EA0
		internal override bool fe()
		{
			return this.b;
		}

		// Token: 0x04000D63 RID: 3427
		private new short a;

		// Token: 0x04000D64 RID: 3428
		private new bool b;
	}
}
