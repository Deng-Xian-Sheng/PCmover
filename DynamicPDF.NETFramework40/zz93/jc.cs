using System;
using System.Text.RegularExpressions;

namespace zz93
{
	// Token: 0x02000170 RID: 368
	internal class jc : fd
	{
		// Token: 0x06000D57 RID: 3415 RVA: 0x00098468 File Offset: 0x00097468
		internal jc(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000D58 RID: 3416 RVA: 0x0009847C File Offset: 0x0009747C
		internal gv a()
		{
			return this.a;
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x00098494 File Offset: 0x00097494
		internal override int cv()
		{
			return 898954496;
		}

		// Token: 0x06000D5A RID: 3418 RVA: 0x000984AC File Offset: 0x000974AC
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x000984C4 File Offset: 0x000974C4
		internal override void cw(gi A_0)
		{
			if (A_0.ax())
			{
				string input = A_0.au().Trim();
				Match match = Regex.Match(input, "[A-Za-z*/%]+");
				if (match.Success)
				{
					this.a = new gv(0);
				}
				else
				{
					match = Regex.Match(input, "[^A-Za-z*/]+");
					int a_ = 0;
					if (int.TryParse(match.Value, out a_))
					{
						this.a = new gv(a_);
					}
					else
					{
						this.a = new gv(0);
					}
				}
			}
			else
			{
				string text = A_0.ah();
				this.a = new gv(0);
				if (text != null)
				{
					string text2 = text.ToLower();
					if (text2 != null)
					{
						if (text2 == "auto")
						{
							this.a.a(true);
							goto IL_10B;
						}
						if (text2 == "inherit")
						{
							this.a.d(true);
							goto IL_10B;
						}
					}
					this.a.a(true);
					IL_10B:;
				}
				else
				{
					this.a.a(true);
				}
			}
		}

		// Token: 0x040006CB RID: 1739
		private new gv a;
	}
}
