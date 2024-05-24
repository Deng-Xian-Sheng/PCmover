using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200006F RID: 111
	internal class cg : EmbeddedFile
	{
		// Token: 0x0600048D RID: 1165 RVA: 0x0004DFAB File Offset: 0x0004CFAB
		internal cg(aci A_0, abj A_1) : base(A_0)
		{
			this.d = A_1;
			this.a();
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0004DFCC File Offset: 0x0004CFCC
		private void a()
		{
			if (this.d != null)
			{
				for (abk abk = this.d.l(); abk != null; abk = abk.d())
				{
					int num = abk.a().j8();
					if (num != 326)
					{
						if (num != 1350)
						{
							if (num == 1203427)
							{
								abd abd = (ab7)abk.c();
								if (abd != null)
								{
									base.Description = ((ab7)abd).kf();
								}
							}
						}
						else
						{
							abd abd = (ab7)abk.c();
							if (abd != null)
							{
								base.FileName = ((ab7)abd).kf();
							}
						}
					}
					else if (abk.c().hy() == ag9.g)
					{
						abd abd = (abj)abk.c();
						this.a((abj)abd);
					}
				}
				this.e = true;
			}
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0004E0CC File Offset: 0x0004D0CC
		private void a(abj A_0)
		{
			if (A_0.hy() == ag9.h)
			{
				base.a(y0.a(((afj)A_0).j4(), 0, ((afj)A_0).j4().Length));
			}
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 6)
				{
					if (num != 230575108)
					{
						if (num == 277293150)
						{
							if (abk.c().hy() == ag9.g)
							{
								this.a((abj)abk.c());
							}
						}
					}
					else
					{
						string text = ((ab7)abk.c()).kf();
						text = text.Substring(2, text.Length - 2);
						if (text.Contains("'"))
						{
							text = text.Replace("'", ":").Substring(0, text.Length - 1);
							base.a(DateTime.ParseExact(text, "yyyyMMddHHmmsszzz", null));
						}
						else if (text.EndsWith("Z"))
						{
							base.a(DateTime.ParseExact(text, "yyyyMMddHHmmssZ", null));
						}
						else
						{
							base.a(DateTime.ParseExact(text, "yyyyMMddHHmmss", null));
						}
					}
				}
				else if (abk.c().hy() == ag9.j)
				{
					this.a((abj)abk.c().h6());
				}
			}
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0004E26C File Offset: 0x0004D26C
		public override void DrawReference(DocumentWriter writer)
		{
			if (this.d != null)
			{
				writer.WriteReferenceUnique(new ch(this.d));
			}
			else
			{
				base.DrawReference(writer);
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0004E2A4 File Offset: 0x0004D2A4
		public override string get_FileName()
		{
			if (!this.e)
			{
				this.a();
			}
			return base.FileName;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0004E2CD File Offset: 0x0004D2CD
		public override void set_FileName(string value)
		{
			base.FileName = value;
			this.d = null;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0004E2E0 File Offset: 0x0004D2E0
		public override string get_Description()
		{
			if (!this.e)
			{
				this.a();
			}
			return base.Description;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0004E309 File Offset: 0x0004D309
		public override void set_Description(string value)
		{
			base.Description = value;
			this.d = null;
		}

		// Token: 0x040002B2 RID: 690
		private new const string a = "yyyyMMddHHmmssZ";

		// Token: 0x040002B3 RID: 691
		private new const string b = "yyyyMMddHHmmsszzz";

		// Token: 0x040002B4 RID: 692
		private new const string c = "yyyyMMddHHmmss";

		// Token: 0x040002B5 RID: 693
		private abj d;

		// Token: 0x040002B6 RID: 694
		private bool e = false;
	}
}
