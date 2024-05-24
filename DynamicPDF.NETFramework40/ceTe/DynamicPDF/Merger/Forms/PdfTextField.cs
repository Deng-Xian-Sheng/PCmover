using System;
using ceTe.DynamicPDF.Forms;
using zz93;

namespace ceTe.DynamicPDF.Merger.Forms
{
	// Token: 0x02000704 RID: 1796
	public class PdfTextField : PdfFormField
	{
		// Token: 0x0600463A RID: 17978 RVA: 0x0023E5A8 File Offset: 0x0023D5A8
		internal PdfTextField(PdfForm A_0, int A_1, PdfFormField A_2, abj A_3) : base(A_0, A_1, A_2, A_3)
		{
			for (abk abk = A_3.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num == 226984715)
				{
					this.a = (abw)abk.c().h6();
				}
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x0600463B RID: 17979 RVA: 0x0023E618 File Offset: 0x0023D618
		public int MaximumLength
		{
			get
			{
				int result;
				if (this.a != null)
				{
					result = this.a.kd();
				}
				else if (base.Parent is PdfTextField)
				{
					result = ((PdfTextField)base.Parent).MaximumLength;
				}
				else
				{
					result = -1;
				}
				return result;
			}
		}

		// Token: 0x0600463C RID: 17980 RVA: 0x0023E670 File Offset: 0x0023D670
		public override string GetDefaultValue()
		{
			string result;
			if (base.v() == null)
			{
				result = string.Empty;
			}
			else
			{
				result = ((ab7)base.v()).kf();
			}
			return result;
		}

		// Token: 0x0600463D RID: 17981 RVA: 0x0023E6AC File Offset: 0x0023D6AC
		public override string GetValue()
		{
			return this.Text;
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x0600463E RID: 17982 RVA: 0x0023E6C4 File Offset: 0x0023D6C4
		public string Text
		{
			get
			{
				string result;
				if (base.u() == null)
				{
					result = string.Empty;
				}
				else
				{
					result = ((ab7)base.u()).kf();
				}
				return result;
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x0600463F RID: 17983 RVA: 0x0023E700 File Offset: 0x0023D700
		public override Font Font
		{
			get
			{
				if (base.Font == null)
				{
					this.a(base.s());
				}
				return base.Font;
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06004640 RID: 17984 RVA: 0x0023E738 File Offset: 0x0023D738
		public override bool Multiline
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.Multiline);
				}
				else
				{
					result = ((base.m() & 4096) == 4096);
				}
				return result;
			}
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06004641 RID: 17985 RVA: 0x0023E790 File Offset: 0x0023D790
		public override bool Password
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.Password);
				}
				else
				{
					result = ((base.m() & 8192) == 8192);
				}
				return result;
			}
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06004642 RID: 17986 RVA: 0x0023E7E8 File Offset: 0x0023D7E8
		public override bool FileSelect
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.FileSelect);
				}
				else
				{
					result = ((base.m() & 1048576) == 1048576);
				}
				return result;
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06004643 RID: 17987 RVA: 0x0023E840 File Offset: 0x0023D840
		public override bool DoNotSpellCheck
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.DoNotSpellCheck);
				}
				else
				{
					result = ((base.m() & 4194304) == 4194304);
				}
				return result;
			}
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06004644 RID: 17988 RVA: 0x0023E898 File Offset: 0x0023D898
		public override bool DoNotScroll
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.DoNotScroll);
				}
				else
				{
					result = ((base.m() & 8388608) == 8388608);
				}
				return result;
			}
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06004645 RID: 17989 RVA: 0x0023E8F0 File Offset: 0x0023D8F0
		public override bool Comb
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.Comb);
				}
				else
				{
					result = ((base.m() & 16777216) == 16777216);
				}
				return result;
			}
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06004646 RID: 17990 RVA: 0x0023E948 File Offset: 0x0023D948
		public override bool RichText
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.RichText);
				}
				else
				{
					result = ((base.m() & 33554432) == 33554432);
				}
				return result;
			}
		}

		// Token: 0x06004647 RID: 17991 RVA: 0x0023E9A0 File Offset: 0x0023D9A0
		internal override FormField hm(int A_0)
		{
			return new aap(this, A_0);
		}

		// Token: 0x06004648 RID: 17992 RVA: 0x0023E9BC File Offset: 0x0023D9BC
		internal void a(abj A_0)
		{
			if (A_0 != null)
			{
				if (base.Font == null)
				{
					for (abk abk = A_0.l(); abk != null; abk = abk.d())
					{
						int num = abk.a().j8();
						if (num != 14)
						{
							if (num != 1768372)
							{
								if (num == 308085382)
								{
									this.a((abj)abk.c().h6());
								}
							}
							else if (base.Font == null)
							{
								abj abj = (abj)abk.c().h6();
								for (abk abk2 = abj.l(); abk2 != null; abk2 = abk2.d())
								{
									if (abk2.c().hy() == ag9.j)
									{
										c2 c = new c2(abk2.c());
										base.Font = c;
										base.Form.a(abk2.a().j9(), c);
									}
								}
							}
						}
						else
						{
							this.a((abj)abk.c().h6());
						}
					}
				}
			}
		}

		// Token: 0x040026DF RID: 9951
		private new abw a = null;
	}
}
