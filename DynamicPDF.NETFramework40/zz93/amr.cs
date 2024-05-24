using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020005C0 RID: 1472
	internal class amr : FormattedTextArea, ru, rv
	{
		// Token: 0x06003A4D RID: 14925 RVA: 0x001F44C8 File Offset: 0x001F34C8
		internal amr(amr A_0) : base(A_0)
		{
			this.a = A_0.fd();
			this.b = A_0.fe();
		}

		// Token: 0x06003A4E RID: 14926 RVA: 0x001F44EC File Offset: 0x001F34EC
		internal amr(FormattedRecordArea A_0, char[] A_1) : base(A_0, A_1)
		{
			this.a = A_0.nw();
			this.b = A_0.Splittable;
		}

		// Token: 0x06003A4F RID: 14927 RVA: 0x001F4511 File Offset: 0x001F3511
		internal amr(amr A_0, float A_1, float A_2, float A_3) : base(A_0, A_1, A_2, A_3)
		{
			this.a = A_0.fd();
			this.b = A_0.fe();
		}

		// Token: 0x06003A50 RID: 14928 RVA: 0x001F453C File Offset: 0x001F353C
		void ru.a(acm A_0)
		{
			float num = new FormattedTextArea.b(this, base.b().ToCharArray(), 0).b(0);
			if (num > this.Height)
			{
				A_0.a(x5.a(this.Y), x5.a(this.Y + this.Height), x5.a(num - this.Height));
				this.Height = num;
			}
		}

		// Token: 0x06003A51 RID: 14929 RVA: 0x001F45B1 File Offset: 0x001F35B1
		void rv.a(char[] A_0, bool A_1)
		{
			base.a(false);
			base.a(new string(A_0));
		}

		// Token: 0x06003A52 RID: 14930 RVA: 0x001F45CC File Offset: 0x001F35CC
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (this.fe())
			{
				this.a(x5.b(A_0));
				if (base.e() == 0)
				{
					base.a(false);
					result = al1.c;
				}
				else
				{
					result = x5.a(base.c().b(0, base.e()));
				}
			}
			else
			{
				result = al1.c;
			}
			return result;
		}

		// Token: 0x06003A53 RID: 14931 RVA: 0x001F4640 File Offset: 0x001F3640
		internal override PageElement fb(x5 A_0)
		{
			float height = this.Height;
			base.a(false);
			this.Height = x5.b(A_0) + 0.001f;
			base.a(true);
			PageElement result;
			if (base.HasOverflowText())
			{
				amr amr = new amr(this, this.X, 0f, height - this.Height);
				result = amr;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06003A54 RID: 14932 RVA: 0x001F46AC File Offset: 0x001F36AC
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

		// Token: 0x06003A55 RID: 14933 RVA: 0x001F4774 File Offset: 0x001F3774
		internal override PageElement fc()
		{
			return new amr(this);
		}

		// Token: 0x06003A56 RID: 14934 RVA: 0x001F478C File Offset: 0x001F378C
		internal override short fd()
		{
			return this.a;
		}

		// Token: 0x06003A57 RID: 14935 RVA: 0x001F47A4 File Offset: 0x001F37A4
		internal override bool fe()
		{
			return this.b;
		}

		// Token: 0x04001B9D RID: 7069
		private new short a;

		// Token: 0x04001B9E RID: 7070
		private new bool b;
	}
}
