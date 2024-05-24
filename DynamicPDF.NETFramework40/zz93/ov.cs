using System;
using System.IO;

namespace zz93
{
	// Token: 0x02000239 RID: 569
	internal class ov : d0
	{
		// Token: 0x06001A68 RID: 6760 RVA: 0x00113150 File Offset: 0x00112150
		internal ov(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 22317153)
				{
					if (num <= 368757)
					{
						if (num != 3407)
						{
							if (num != 368757)
							{
								goto IL_323;
							}
							this.a = A_0.ao();
							if (this.a != null)
							{
								this.f = this.g();
							}
						}
						else if (base.k() == null)
						{
							base.c(A_0.an());
						}
					}
					else if (num != 2235034)
					{
						if (num != 22317153)
						{
							goto IL_323;
						}
						this.e = A_0.ao();
					}
					else
					{
						this.b = A_0.ao().ToLower();
					}
				}
				else if (num <= 545266181)
				{
					if (num != 144877216)
					{
						if (num != 545266181)
						{
							goto IL_323;
						}
						if (base.l() == null)
						{
							base.a(A_0.am());
						}
					}
					else if (base.m() == null)
					{
						string text = A_0.au();
						if (text != null)
						{
							base.a(new ig(A_1.a(text.ToCharArray(), 0, text.Length)));
						}
					}
				}
				else if (num != 791474715)
				{
					if (num != 795562982)
					{
						goto IL_323;
					}
					if (x5.h(m4.a(this.c), x5.c()))
					{
						string text2 = A_0.ao();
						if (text2 != null && text2.Length > 0)
						{
							this.c = new h2(A_1.g().a(text2));
							if (this.c.a().b() == i2.c && this.c.a().b() == i2.b)
							{
								this.c = new h2(new i4(i2.c, this.c.a().a()));
							}
						}
					}
				}
				else if (x5.h(m4.a(this.d), x5.c()))
				{
					string text2 = A_0.ao();
					if (text2 != null && text2.Length > 0)
					{
						this.d = new h2(A_1.g().a(text2.ToLower()));
						if (this.d.a().b() == i2.c && this.d.a().b() == i2.b)
						{
							this.d = new h2(new i4(i2.c, this.d.a().a()));
						}
					}
				}
				continue;
				IL_323:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001A69 RID: 6761 RVA: 0x001134A4 File Offset: 0x001124A4
		internal override int cn()
		{
			return 86163053;
		}

		// Token: 0x06001A6A RID: 6762 RVA: 0x001134BC File Offset: 0x001124BC
		internal override string co()
		{
			return "object";
		}

		// Token: 0x06001A6B RID: 6763 RVA: 0x001134D3 File Offset: 0x001124D3
		internal void a(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001A6C RID: 6764 RVA: 0x001134E0 File Offset: 0x001124E0
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06001A6D RID: 6765 RVA: 0x001134F8 File Offset: 0x001124F8
		internal string b()
		{
			return this.b;
		}

		// Token: 0x06001A6E RID: 6766 RVA: 0x00113510 File Offset: 0x00112510
		internal h2 c()
		{
			return this.c;
		}

		// Token: 0x06001A6F RID: 6767 RVA: 0x00113528 File Offset: 0x00112528
		internal h2 d()
		{
			return this.d;
		}

		// Token: 0x06001A70 RID: 6768 RVA: 0x00113540 File Offset: 0x00112540
		internal string e()
		{
			return this.e;
		}

		// Token: 0x06001A71 RID: 6769 RVA: 0x00113558 File Offset: 0x00112558
		internal void a(ow A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001A72 RID: 6770 RVA: 0x00113564 File Offset: 0x00112564
		internal ow f()
		{
			return this.f;
		}

		// Token: 0x06001A73 RID: 6771 RVA: 0x0011357C File Offset: 0x0011257C
		internal ow g()
		{
			this.a = this.a.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			ow result;
			if (this.a.LastIndexOf('.') > 0)
			{
				string[] array = this.a.Split(new char[]
				{
					'/'
				});
				array = array[array.Length - 1].Split(new char[]
				{
					'.'
				});
				if (array.Length > 3)
				{
					string text = "." + array[array.Length - 1].Substring(0, 3);
					switch (text)
					{
					case ".mp3":
					case ".mpg":
					case ".mpa":
					case ".mpe":
					case ".m3u":
						return ow.a;
					case ".mp4":
					case ".wmv":
					case ".3gp":
					case ".avi":
					case ".flv":
						return ow.b;
					case ".swf":
					case ".asf":
						return ow.c;
					case ".jpg":
					case ".bmp":
					case ".jpeg":
					case ".png":
					case ".gif":
					case ".tif":
					case ".emf":
					case ".wmf":
					case ".jp2":
					case ".exif":
						return ow.d;
					}
					result = ow.e;
				}
				else
				{
					result = ow.e;
				}
			}
			else
			{
				result = ow.e;
			}
			return result;
		}

		// Token: 0x04000C03 RID: 3075
		private string a = null;

		// Token: 0x04000C04 RID: 3076
		private string b = null;

		// Token: 0x04000C05 RID: 3077
		private new h2 c = new h2(new i4(i2.a, 0f));

		// Token: 0x04000C06 RID: 3078
		private h2 d = new h2(new i4(i2.a, 0f));

		// Token: 0x04000C07 RID: 3079
		private string e = null;

		// Token: 0x04000C08 RID: 3080
		private ow f = ow.e;
	}
}
