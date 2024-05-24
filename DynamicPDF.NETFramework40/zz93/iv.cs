using System;

namespace zz93
{
	// Token: 0x0200015F RID: 351
	internal class iv : fd
	{
		// Token: 0x06000CF9 RID: 3321 RVA: 0x00095EA0 File Offset: 0x00094EA0
		internal iv()
		{
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x00095EB2 File Offset: 0x00094EB2
		internal iv(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x00095ECC File Offset: 0x00094ECC
		internal go a()
		{
			return this.a;
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x00095EE4 File Offset: 0x00094EE4
		internal void a(go A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x00095EF0 File Offset: 0x00094EF0
		internal override int cv()
		{
			return 510035525;
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x00095F08 File Offset: 0x00094F08
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x00095F20 File Offset: 0x00094F20
		internal bool b()
		{
			return this.b;
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x00095F38 File Offset: 0x00094F38
		internal override void cw(gi A_0)
		{
			string text;
			if (!A_0.a8())
			{
				text = A_0.ai();
			}
			else
			{
				text = A_0.a9();
				if (text != null)
				{
					this.b = A_0.f(text);
				}
			}
			while (A_0.aw())
			{
				if (!A_0.a8())
				{
					text = A_0.ai();
				}
				else
				{
					text = A_0.a9();
					if (text != null)
					{
						this.b = A_0.f(text);
					}
				}
			}
			if (text != null && this.b)
			{
				string text2 = text.ToLower().Trim();
				if (text2 != null)
				{
					if (text2 == "inherit")
					{
						this.a = new go("null");
						this.a.d(true);
						goto IL_1F7;
					}
				}
				if (text != string.Empty && text[0] != '/')
				{
					if (text[0] != '#')
					{
						this.a = new go(text.Trim());
						this.b = true;
					}
					else if (text[0] == '#' && (text.Length == 4 || text.Length == 7))
					{
						if (text.Length == 4)
						{
							char[] array = new char[7];
							int num = 0;
							array[0] = text[0];
							num++;
							for (int i = 1; i < array.Length; i++)
							{
								if (i % 2 == 0)
								{
									array[i] = text[num];
									num++;
								}
								else
								{
									array[i] = text[num];
								}
							}
							text = new string(array);
						}
						this.b = true;
						this.a = new go(text);
					}
					else
					{
						this.b = false;
					}
				}
				IL_1F7:;
			}
		}

		// Token: 0x040006A8 RID: 1704
		private new go a;

		// Token: 0x040006A9 RID: 1705
		private bool b = true;
	}
}
