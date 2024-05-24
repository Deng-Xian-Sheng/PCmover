using System;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003B3 RID: 947
	internal class yt : DocumentJavaScript
	{
		// Token: 0x0600281F RID: 10271 RVA: 0x00174DAD File Offset: 0x00173DAD
		internal yt(aci A_0, abj A_1) : base(A_0)
		{
			this.a = A_1;
		}

		// Token: 0x06002820 RID: 10272 RVA: 0x00174DC0 File Offset: 0x00173DC0
		public override void DrawReference(DocumentWriter writer)
		{
			if (this.a != null)
			{
				writer.WriteReferenceUnique(new yu(this.a));
			}
			else
			{
				base.DrawReference(writer);
			}
		}

		// Token: 0x06002821 RID: 10273 RVA: 0x00174DF8 File Offset: 0x00173DF8
		public override string get_JavaScript()
		{
			if (this.a != null)
			{
				this.a();
			}
			return base.JavaScript;
		}

		// Token: 0x06002822 RID: 10274 RVA: 0x00174E24 File Offset: 0x00173E24
		public override void set_JavaScript(string value)
		{
			base.JavaScript = value;
			this.a = null;
		}

		// Token: 0x06002823 RID: 10275 RVA: 0x00174E38 File Offset: 0x00173E38
		private void a()
		{
			abd abd = null;
			for (abk abk = this.a.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 659)
				{
					abd = abk.c();
				}
			}
			if (abd.hy() == ag9.c)
			{
				base.JavaScript = ((ab7)abd).kf();
			}
			else
			{
				if (abd.hy() == ag9.j)
				{
					aba aba = this.a.k().b().f().k8();
					abd = abd.h6();
					aba.lr();
				}
				if (abd.hy() == ag9.c)
				{
					base.JavaScript = ((ab7)abd).kf();
				}
				else if (abd is afj)
				{
					byte[] array = ((afj)abd).j4();
					if (array.Length > 1 && array[0] == 254 && array[1] == 255)
					{
						base.JavaScript = Encoding.BigEndianUnicode.GetString(array, 2, array.Length - 2);
					}
					else
					{
						base.JavaScript = ab2.a(array);
					}
				}
				else
				{
					base.JavaScript = string.Empty;
					this.a = null;
				}
			}
		}

		// Token: 0x040011A5 RID: 4517
		private new abj a;
	}
}
