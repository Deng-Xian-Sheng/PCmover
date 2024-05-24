using System;
using System.Text;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004BA RID: 1210
	internal class afn : ab7
	{
		// Token: 0x060031C7 RID: 12743 RVA: 0x001BD112 File Offset: 0x001BC112
		internal afn(agp A_0, abi A_1, int A_2, int A_3, int A_4, bool A_5)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = (short)A_3;
			this.e = A_4;
		}

		// Token: 0x060031C8 RID: 12744 RVA: 0x001BD144 File Offset: 0x001BC144
		internal override string kf()
		{
			string result;
			if (this.h)
			{
				result = this.f;
			}
			else
			{
				this.g = this.kg();
				if (this.g.Length > 1 && this.g[0] == 254 && this.g[1] == 255)
				{
					this.f = Encoding.BigEndianUnicode.GetString(this.g, 2, this.g.Length - 2);
				}
				else
				{
					this.f = ab2.a(this.g);
				}
				this.h = true;
				result = this.f;
			}
			return result;
		}

		// Token: 0x060031C9 RID: 12745 RVA: 0x001BD1F4 File Offset: 0x001BC1F4
		internal override byte[] kg()
		{
			byte[] result;
			if (this.g != null)
			{
				result = this.g;
			}
			else
			{
				agx agx = this.a.a(this.c, (int)this.d);
				this.g = agx.f(this.e);
				this.a.a(agx);
				if (this.b.h2())
				{
					if (this.b.b().g() != null && !this.b.b().g().at())
					{
						this.e = this.b.h1(this.g, 0, this.g.Length);
						if (this.e != 0)
						{
							Array.Resize<byte>(ref this.g, this.e);
						}
					}
				}
				result = this.g;
			}
			return result;
		}

		// Token: 0x060031CA RID: 12746 RVA: 0x001BD2E0 File Offset: 0x001BC2E0
		private byte[] a(agx A_0)
		{
			byte[] result;
			if (this.g != null)
			{
				result = this.g;
			}
			else
			{
				A_0.c(this.c, (int)this.d);
				this.g = A_0.f(this.e);
				if (this.b.h2())
				{
					if (this.b.b().g() != null && !this.b.b().g().at())
					{
						this.e = this.b.h1(this.g, 0, this.g.Length);
						if (this.e != 0)
						{
							Array.Resize<byte>(ref this.g, this.e);
						}
					}
				}
				result = this.g;
			}
			return result;
		}

		// Token: 0x060031CB RID: 12747 RVA: 0x001BD3BC File Offset: 0x001BC3BC
		internal override byte[] kh()
		{
			byte[] result;
			if (this.g != null)
			{
				result = this.g;
			}
			else
			{
				agx agx = this.a.a(this.c, (int)this.d);
				this.g = agx.f(this.e);
				this.a.a(agx);
				result = this.g;
			}
			return result;
		}

		// Token: 0x060031CC RID: 12748 RVA: 0x001BD424 File Offset: 0x001BC424
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				agx a_ = A_0.a(this.a);
				this.h9(a_, A_0);
			}
		}

		// Token: 0x060031CD RID: 12749 RVA: 0x001BD458 File Offset: 0x001BC458
		internal override void h9(agx A_0, DocumentWriter A_1)
		{
			if (base.p())
			{
				A_0.c(this.c, (int)this.d);
				if (this.b.h2() || A_1.Document.Security != null)
				{
					A_1.WriteText(this.a(A_0));
				}
				else
				{
					A_0.c(this.c, (int)this.d);
					A_0.c(A_1, this.e);
				}
			}
		}

		// Token: 0x04001742 RID: 5954
		private agp a;

		// Token: 0x04001743 RID: 5955
		private abi b;

		// Token: 0x04001744 RID: 5956
		private int c;

		// Token: 0x04001745 RID: 5957
		private short d;

		// Token: 0x04001746 RID: 5958
		private int e;

		// Token: 0x04001747 RID: 5959
		private string f;

		// Token: 0x04001748 RID: 5960
		private byte[] g;

		// Token: 0x04001749 RID: 5961
		private bool h;
	}
}
