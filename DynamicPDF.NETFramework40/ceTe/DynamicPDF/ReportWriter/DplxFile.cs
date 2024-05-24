using System;
using System.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000816 RID: 2070
	public class DplxFile
	{
		// Token: 0x060053D3 RID: 21459 RVA: 0x00292CF8 File Offset: 0x00291CF8
		public DplxFile(string filePath)
		{
			this.k = Path.GetDirectoryName(filePath);
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
			wd a_ = new wd(fileStream, this);
			fileStream.Close();
			this.a(a_);
		}

		// Token: 0x060053D4 RID: 21460 RVA: 0x00292D98 File Offset: 0x00291D98
		public DplxFile(Stream stream)
		{
			wd a_ = new wd(stream, this);
			stream.Close();
			this.a(a_);
		}

		// Token: 0x060053D5 RID: 21461 RVA: 0x00292E20 File Offset: 0x00291E20
		public DplxFile(byte[] byteArray)
		{
			wd a_ = new wd(byteArray, this);
			this.a(a_);
		}

		// Token: 0x060053D6 RID: 21462 RVA: 0x00292EA0 File Offset: 0x00291EA0
		private void a(wd A_0)
		{
			if (A_0.x() != 616326873)
			{
				throw new DplxParseException("The document element was not found.");
			}
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 567757341)
				{
					if (num != 2660)
					{
						if (num != 215143)
						{
							if (num != 567757341)
							{
								goto IL_110;
							}
							this.b = A_0.a5();
						}
						else
						{
							this.e = A_0.av();
						}
					}
					else
					{
						this.a = A_0.a8();
					}
				}
				else if (num <= 869671505)
				{
					if (num != 731165916)
					{
						if (num != 869671505)
						{
							goto IL_110;
						}
						this.f = A_0.a5();
					}
					else
					{
						this.c = A_0.a5();
					}
				}
				else if (num != 883378981)
				{
					if (num != 915875591)
					{
						goto IL_110;
					}
					float num2 = A_0.ar();
					if (!num2.Equals(6f))
					{
						throw new ReportWriterException("Incompatible DPLX file. Only v6.0 DPLX files can be read in this version. The version of the DPLX file is " + num2 + ".");
					}
				}
				else
				{
					this.d = A_0.a5();
				}
				continue;
				IL_110:
				A_0.ac();
			}
			A_0.aa();
			if (A_0.x() == 369099151)
			{
				this.i = new FontList();
				do
				{
					this.i.a(A_0);
					A_0.aa();
				}
				while (A_0.x() == 369099151);
			}
			if (A_0.x() == 117995071)
			{
				this.j = new FontFamilyList();
				do
				{
					this.j.a(A_0);
					A_0.aa();
				}
				while (A_0.x() == 117995071);
			}
			if (A_0.x() == 836132025)
			{
				this.g = vv.a(A_0);
				A_0.b(this.g.f());
				A_0.aa();
			}
			this.h = new vu();
			this.h.a(A_0);
		}

		// Token: 0x060053D7 RID: 21463 RVA: 0x002930C0 File Offset: 0x002920C0
		internal string a()
		{
			return this.k;
		}

		// Token: 0x060053D8 RID: 21464 RVA: 0x002930D8 File Offset: 0x002920D8
		internal FontList b()
		{
			return this.i;
		}

		// Token: 0x060053D9 RID: 21465 RVA: 0x002930F0 File Offset: 0x002920F0
		internal FontFamilyList c()
		{
			if (this.j == null)
			{
				this.j = new FontFamilyList();
			}
			return this.j;
		}

		// Token: 0x060053DA RID: 21466 RVA: 0x00293124 File Offset: 0x00292124
		internal vu d()
		{
			return this.h;
		}

		// Token: 0x060053DB RID: 21467 RVA: 0x0029313C File Offset: 0x0029213C
		internal vv e()
		{
			return this.g;
		}

		// Token: 0x060053DC RID: 21468 RVA: 0x00293154 File Offset: 0x00292154
		internal string f()
		{
			return this.a;
		}

		// Token: 0x060053DD RID: 21469 RVA: 0x0029316C File Offset: 0x0029216C
		internal string g()
		{
			return this.b;
		}

		// Token: 0x060053DE RID: 21470 RVA: 0x00293184 File Offset: 0x00292184
		internal string h()
		{
			return this.c;
		}

		// Token: 0x060053DF RID: 21471 RVA: 0x0029319C File Offset: 0x0029219C
		internal string i()
		{
			return this.d;
		}

		// Token: 0x060053E0 RID: 21472 RVA: 0x002931B4 File Offset: 0x002921B4
		internal string j()
		{
			return this.f;
		}

		// Token: 0x060053E1 RID: 21473 RVA: 0x002931CC File Offset: 0x002921CC
		internal bool k()
		{
			return this.e;
		}

		// Token: 0x04002CE5 RID: 11493
		private string a = null;

		// Token: 0x04002CE6 RID: 11494
		private string b = string.Empty;

		// Token: 0x04002CE7 RID: 11495
		private string c = string.Empty;

		// Token: 0x04002CE8 RID: 11496
		private string d = string.Empty;

		// Token: 0x04002CE9 RID: 11497
		private bool e = false;

		// Token: 0x04002CEA RID: 11498
		private string f = string.Empty;

		// Token: 0x04002CEB RID: 11499
		private vv g = null;

		// Token: 0x04002CEC RID: 11500
		private vu h = null;

		// Token: 0x04002CED RID: 11501
		private FontList i = new FontList();

		// Token: 0x04002CEE RID: 11502
		private FontFamilyList j = null;

		// Token: 0x04002CEF RID: 11503
		private string k;
	}
}
