using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000572 RID: 1394
	internal class ako : aif
	{
		// Token: 0x06003765 RID: 14181 RVA: 0x001DF40C File Offset: 0x001DE40C
		internal ako(rv A_0, akk A_1, akn A_2, IFormatProvider A_3, string A_4) : base(A_0, A_1)
		{
			this.a = A_2;
			this.b = A_3;
			this.c = A_4;
		}

		// Token: 0x06003766 RID: 14182 RVA: 0x001DF430 File Offset: 0x001DE430
		private object a(LayoutWriter A_0)
		{
			return this.a.a().l2(A_0, base.c());
		}

		// Token: 0x06003767 RID: 14183 RVA: 0x001DF45C File Offset: 0x001DE45C
		internal override void mm(LayoutWriter A_0, bool A_1)
		{
			A_0.a(A_1);
			object obj = this.a(A_0);
			string text;
			if (this.c != null && this.c.Length > 0)
			{
				if (obj is IFormattable)
				{
					IFormattable formattable = (IFormattable)obj;
					if (this.b == null)
					{
						text = formattable.ToString(this.c, A_0.DocumentLayout.FormatProvider);
					}
					else
					{
						text = formattable.ToString(this.c, this.b);
					}
				}
				else
				{
					text = obj.ToString();
				}
			}
			else
			{
				text = obj.ToString();
			}
			base.b().a(text.ToCharArray(), A_1);
			A_0.a(false);
		}

		// Token: 0x04001A37 RID: 6711
		private akn a;

		// Token: 0x04001A38 RID: 6712
		private IFormatProvider b;

		// Token: 0x04001A39 RID: 6713
		private string c;
	}
}
