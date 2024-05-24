using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000338 RID: 824
	internal class vl : q4
	{
		// Token: 0x06002370 RID: 9072 RVA: 0x00150B68 File Offset: 0x0014FB68
		internal vl(rv A_0, vi A_1, vk A_2, IFormatProvider A_3, string A_4) : base(A_0, A_1)
		{
			this.a = A_2;
			this.b = A_3;
			this.c = A_4;
		}

		// Token: 0x06002371 RID: 9073 RVA: 0x00150B8C File Offset: 0x0014FB8C
		private object a(LayoutWriter A_0)
		{
			return this.a.a().et(A_0, base.c());
		}

		// Token: 0x06002372 RID: 9074 RVA: 0x00150BB8 File Offset: 0x0014FBB8
		internal override void d7(LayoutWriter A_0, bool A_1)
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

		// Token: 0x04000F3C RID: 3900
		private vk a;

		// Token: 0x04000F3D RID: 3901
		private IFormatProvider b;

		// Token: 0x04000F3E RID: 3902
		private string c;
	}
}
