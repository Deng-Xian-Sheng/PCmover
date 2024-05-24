using System;
using zz93;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x0200091C RID: 2332
	public class RightsManagementSchema : XmpSchema
	{
		// Token: 0x17000A00 RID: 2560
		// (get) Token: 0x06005EFB RID: 24315 RVA: 0x0035BB98 File Offset: 0x0035AB98
		// (set) Token: 0x06005EFC RID: 24316 RVA: 0x0035BBB0 File Offset: 0x0035ABB0
		public Uri Certificate
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x17000A01 RID: 2561
		// (get) Token: 0x06005EFD RID: 24317 RVA: 0x0035BBBC File Offset: 0x0035ABBC
		// (set) Token: 0x06005EFE RID: 24318 RVA: 0x0035BBD4 File Offset: 0x0035ABD4
		public CopyrightStatus Marked2
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x17000A02 RID: 2562
		// (get) Token: 0x06005EFF RID: 24319 RVA: 0x0035BBE0 File Offset: 0x0035ABE0
		public XmpArray Owner
		{
			get
			{
				if (this.b == null)
				{
					this.b = new XmpArray(ae9.b);
				}
				return this.b;
			}
		}

		// Token: 0x17000A03 RID: 2563
		// (get) Token: 0x06005F00 RID: 24320 RVA: 0x0035BC18 File Offset: 0x0035AC18
		public XmpLangAltList UsageTerms
		{
			get
			{
				if (this.c == null)
				{
					this.c = new XmpLangAltList();
				}
				return this.c;
			}
		}

		// Token: 0x17000A04 RID: 2564
		// (get) Token: 0x06005F01 RID: 24321 RVA: 0x0035BC50 File Offset: 0x0035AC50
		// (set) Token: 0x06005F02 RID: 24322 RVA: 0x0035BC68 File Offset: 0x0035AC68
		public Uri WebStatement
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x06005F03 RID: 24323 RVA: 0x0035BC74 File Offset: 0x0035AC74
		protected internal override void Draw(XmpWriter xwriter)
		{
			xwriter.BeginDescription("http://ns.adobe.com/xap/1.0/rights/", "xmpRights", " ");
			if (this.a != null)
			{
				xwriter.Draw("\t\t<xmpRights:Certificate>" + x7.a(this.a.ToString()) + "</xmpRights:Certificate>\n");
			}
			if (this.e != CopyrightStatus.Unknown)
			{
				xwriter.Draw("\t\t<xmpRights:Marked>");
				if (this.e == CopyrightStatus.Copyrighted)
				{
					xwriter.Draw(true);
				}
				else
				{
					xwriter.Draw(false);
				}
				xwriter.Draw("</xmpRights:Marked>\n");
			}
			if (this.b != null)
			{
				xwriter.Draw("\t\t<xmpRights:Owner>\n");
				this.b.j1(xwriter);
				xwriter.Draw("\t\t</xmpRights:Owner>\n");
			}
			if (this.c != null)
			{
				xwriter.Draw("\t\t<xmpRights:UsageTerms>\n");
				this.c.j1(xwriter);
				xwriter.Draw("\t\t</xmpRights:UsageTerms>\n");
			}
			if (this.d != null)
			{
				xwriter.Draw("\t\t<xmpRights:WebStatement>" + x7.a(this.d.ToString()) + "</xmpRights:WebStatement>\n");
			}
			xwriter.EndDescription();
		}

		// Token: 0x040030E2 RID: 12514
		private Uri a;

		// Token: 0x040030E3 RID: 12515
		private XmpArray b;

		// Token: 0x040030E4 RID: 12516
		private XmpLangAltList c;

		// Token: 0x040030E5 RID: 12517
		private Uri d;

		// Token: 0x040030E6 RID: 12518
		private CopyrightStatus e = CopyrightStatus.Unknown;
	}
}
