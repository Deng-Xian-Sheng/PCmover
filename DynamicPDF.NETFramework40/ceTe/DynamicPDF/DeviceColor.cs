using System;
using System.Text;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200066C RID: 1644
	public abstract class DeviceColor : Color
	{
		// Token: 0x06003E08 RID: 15880 RVA: 0x002174E7 File Offset: 0x002164E7
		public override void DrawStroke(PageWriter writer)
		{
			this.DrawStroke(writer);
		}

		// Token: 0x06003E09 RID: 15881 RVA: 0x002174F2 File Offset: 0x002164F2
		public override void DrawFill(PageWriter writer)
		{
			this.DrawFill(writer);
		}

		// Token: 0x06003E0A RID: 15882
		public abstract void ToStringBuilder(StringBuilder stringBuilder);

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06003E0B RID: 15883
		public abstract int Components { get; }

		// Token: 0x06003E0C RID: 15884
		internal abstract void gr(DocumentWriter A_0);

		// Token: 0x06003E0D RID: 15885 RVA: 0x00217500 File Offset: 0x00216500
		internal new void a(StringBuilder A_0, float A_1)
		{
			int i = (int)(A_1 * 10000f);
			if (i <= 0)
			{
				A_0.Append('0');
			}
			else if (i >= 10000)
			{
				A_0.Append('1');
			}
			else
			{
				bool flag = false;
				int num = 1000;
				A_0.Append('.');
				while (i > 0)
				{
					int num2 = (int)((byte)(i / num));
					A_0.Append((char)(num2 + 48));
					flag = true;
					i -= num2 * num;
					num /= 10;
				}
				if (!flag)
				{
					A_0[A_0.Length - 1] = '0';
				}
			}
		}
	}
}
