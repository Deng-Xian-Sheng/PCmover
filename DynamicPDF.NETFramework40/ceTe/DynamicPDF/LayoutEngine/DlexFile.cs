using System;
using System.IO;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x0200092D RID: 2349
	public class DlexFile
	{
		// Token: 0x06005F8B RID: 24459 RVA: 0x0035DB1C File Offset: 0x0035CB1C
		public DlexFile(string filePath)
		{
			this.j = Path.GetDirectoryName(filePath);
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
			ald a_ = new ald(fileStream, this);
			fileStream.Close();
			this.a(a_);
		}

		// Token: 0x06005F8C RID: 24460 RVA: 0x0035DBB4 File Offset: 0x0035CBB4
		public DlexFile(Stream stream)
		{
			ald a_ = new ald(stream, this);
			stream.Close();
			this.a(a_);
		}

		// Token: 0x06005F8D RID: 24461 RVA: 0x0035DC34 File Offset: 0x0035CC34
		public DlexFile(byte[] byteArray)
		{
			ald a_ = new ald(byteArray, this);
			this.a(a_);
		}

		// Token: 0x06005F8E RID: 24462 RVA: 0x0035DCB0 File Offset: 0x0035CCB0
		private void a(ald A_0)
		{
			if (A_0.x() != 616326873)
			{
				throw new DlexParseException("The document element was not found.");
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
							this.b = A_0.a7();
						}
						else
						{
							this.e = A_0.av();
						}
					}
					else
					{
						this.a = A_0.a7();
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
						this.f = A_0.a7();
					}
					else
					{
						this.c = A_0.a7();
					}
				}
				else if (num != 883378981)
				{
					if (num != 915875591)
					{
						goto IL_110;
					}
					float num2 = A_0.ar();
					if (!num2.Equals(1.2f))
					{
						throw new LayoutEngineException("Incompatible DLEX file. Only v1.2 DLEX files can be read in this version. The version of the DLEX file is " + num2 + ".");
					}
				}
				else
				{
					this.d = A_0.a7();
				}
				continue;
				IL_110:
				A_0.ac();
			}
			A_0.aa();
			if (A_0.x() == 369099151)
			{
				this.h = new FontList();
				do
				{
					this.h.a(A_0);
					A_0.aa();
				}
				while (A_0.x() == 369099151);
			}
			if (A_0.x() == 117995071)
			{
				this.i = new FontFamilyList();
				do
				{
					this.i.a(A_0);
					A_0.aa();
				}
				while (A_0.x() == 117995071);
			}
			this.g = new akz();
			this.g.a(A_0);
		}

		// Token: 0x06005F8F RID: 24463 RVA: 0x0035DE94 File Offset: 0x0035CE94
		internal string a()
		{
			return this.j;
		}

		// Token: 0x06005F90 RID: 24464 RVA: 0x0035DEAC File Offset: 0x0035CEAC
		internal FontList b()
		{
			return this.h;
		}

		// Token: 0x06005F91 RID: 24465 RVA: 0x0035DEC4 File Offset: 0x0035CEC4
		internal FontFamilyList c()
		{
			if (this.i == null)
			{
				this.i = new FontFamilyList();
			}
			return this.i;
		}

		// Token: 0x06005F92 RID: 24466 RVA: 0x0035DEF8 File Offset: 0x0035CEF8
		internal akz d()
		{
			return this.g;
		}

		// Token: 0x06005F93 RID: 24467 RVA: 0x0035DF10 File Offset: 0x0035CF10
		internal string e()
		{
			return this.a;
		}

		// Token: 0x06005F94 RID: 24468 RVA: 0x0035DF28 File Offset: 0x0035CF28
		internal string f()
		{
			return this.b;
		}

		// Token: 0x06005F95 RID: 24469 RVA: 0x0035DF40 File Offset: 0x0035CF40
		internal string g()
		{
			return this.c;
		}

		// Token: 0x06005F96 RID: 24470 RVA: 0x0035DF58 File Offset: 0x0035CF58
		internal string h()
		{
			return this.d;
		}

		// Token: 0x06005F97 RID: 24471 RVA: 0x0035DF70 File Offset: 0x0035CF70
		internal string i()
		{
			return this.f;
		}

		// Token: 0x06005F98 RID: 24472 RVA: 0x0035DF88 File Offset: 0x0035CF88
		internal bool j()
		{
			return this.e;
		}

		// Token: 0x04003125 RID: 12581
		private string a = null;

		// Token: 0x04003126 RID: 12582
		private string b = string.Empty;

		// Token: 0x04003127 RID: 12583
		private string c = string.Empty;

		// Token: 0x04003128 RID: 12584
		private string d = string.Empty;

		// Token: 0x04003129 RID: 12585
		private bool e = false;

		// Token: 0x0400312A RID: 12586
		private string f = string.Empty;

		// Token: 0x0400312B RID: 12587
		private akz g = null;

		// Token: 0x0400312C RID: 12588
		private FontList h = new FontList();

		// Token: 0x0400312D RID: 12589
		private FontFamilyList i = null;

		// Token: 0x0400312E RID: 12590
		private string j;
	}
}
