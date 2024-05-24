using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000405 RID: 1029
	internal class aat : Outline
	{
		// Token: 0x06002B1A RID: 11034 RVA: 0x0018EB5D File Offset: 0x0018DB5D
		internal aat(ab3 A_0) : base(A_0.c(), A_0.b(), A_0.i())
		{
			this.a = A_0;
		}

		// Token: 0x06002B1B RID: 11035 RVA: 0x0018EB90 File Offset: 0x0018DB90
		internal override void ho(DocumentWriter A_0)
		{
			if (this.b)
			{
				base.ho(A_0);
			}
			else if (this.a.d() != null)
			{
				A_0.WriteName(Outline.r);
				this.a.d().hz(A_0);
			}
		}

		// Token: 0x06002B1C RID: 11036 RVA: 0x0018EBEC File Offset: 0x0018DBEC
		internal override void hp(DocumentWriter A_0)
		{
			if (this.c)
			{
				base.hp(A_0);
			}
			else if (this.a.e() != null)
			{
				A_0.WriteName(67);
				this.a.e().hz(A_0);
			}
			this.a.a(A_0);
		}

		// Token: 0x06002B1D RID: 11037 RVA: 0x0018EC50 File Offset: 0x0018DC50
		public override string get_Text()
		{
			string result;
			if (this.b)
			{
				result = base.Text;
			}
			else
			{
				result = this.a.d().kf();
			}
			return result;
		}

		// Token: 0x06002B1E RID: 11038 RVA: 0x0018EC88 File Offset: 0x0018DC88
		public override void set_Text(string value)
		{
			this.b = true;
			base.Text = value;
		}

		// Token: 0x06002B1F RID: 11039 RVA: 0x0018EC9C File Offset: 0x0018DC9C
		public override RgbColor get_Color()
		{
			if (!this.c)
			{
				this.c = true;
				base.Color = this.a.h();
			}
			return base.Color;
		}

		// Token: 0x06002B20 RID: 11040 RVA: 0x0018ECD9 File Offset: 0x0018DCD9
		public override void set_Color(RgbColor value)
		{
			this.c = true;
			base.Color = value;
		}

		// Token: 0x040013CF RID: 5071
		private new ab3 a;

		// Token: 0x040013D0 RID: 5072
		private new bool b = false;

		// Token: 0x040013D1 RID: 5073
		private bool c = false;
	}
}
