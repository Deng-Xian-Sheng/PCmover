using System;
using zz93;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x02000916 RID: 2326
	public class BasicSchema : XmpSchema
	{
		// Token: 0x06005EDA RID: 24282 RVA: 0x0035B09C File Offset: 0x0035A09C
		internal BasicSchema()
		{
		}

		// Token: 0x170009EF RID: 2543
		// (get) Token: 0x06005EDB RID: 24283 RVA: 0x0035B0A8 File Offset: 0x0035A0A8
		public XmpArray Advisory
		{
			get
			{
				if (this.a == null)
				{
					this.a = new XmpArray(ae9.b);
				}
				return this.a;
			}
		}

		// Token: 0x170009F0 RID: 2544
		// (get) Token: 0x06005EDC RID: 24284 RVA: 0x0035B0E0 File Offset: 0x0035A0E0
		// (set) Token: 0x06005EDD RID: 24285 RVA: 0x0035B0F8 File Offset: 0x0035A0F8
		public string Nickname
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170009F1 RID: 2545
		// (get) Token: 0x06005EDE RID: 24286 RVA: 0x0035B104 File Offset: 0x0035A104
		public XmpThumbnail Thumbnails
		{
			get
			{
				if (this.d == null)
				{
					this.d = new XmpThumbnail();
				}
				return this.d;
			}
		}

		// Token: 0x06005EDF RID: 24287 RVA: 0x0035B13C File Offset: 0x0035A13C
		protected internal override void Draw(XmpWriter xwriter)
		{
			xwriter.BeginDescription("http://ns.adobe.com/xap/1.0/", "xmp", " ");
			if (this.a != null)
			{
				xwriter.Draw("\t\t<xmp:Advisory>\n");
				this.a.j1(xwriter);
				xwriter.Draw("\t\t</xmp:Advisory>\n");
			}
			this.b = xwriter.d();
			xwriter.Draw("\t\t<xmp:CreatorTool>" + x7.a(this.b) + "</xmp:CreatorTool>\n");
			DateTime creationDate = xwriter.h().CreationDate;
			DateTime modifiedDate = xwriter.h().ModifiedDate;
			xwriter.Draw("\t\t<xmp:CreateDate>" + x6.a(creationDate) + "</xmp:CreateDate>\n");
			xwriter.Draw("\t\t<xmp:MetadataDate>" + x6.a(creationDate) + "</xmp:MetadataDate>\n");
			xwriter.Draw("\t\t<xmp:ModifyDate>" + x6.a(modifiedDate) + "</xmp:ModifyDate>\n");
			if (this.c != null)
			{
				xwriter.Draw("\t\t<xmp:Nickname>" + x7.a(this.c) + "</xmp:Nickname>\n");
			}
			if (this.d != null)
			{
				xwriter.Draw("\t\t<xmp:Thumbnails>\n");
				this.d.j1(xwriter);
				xwriter.Draw("\t\t</xmp:Thumbnails>\n");
			}
			xwriter.EndDescription();
		}

		// Token: 0x040030C1 RID: 12481
		private XmpArray a;

		// Token: 0x040030C2 RID: 12482
		private string b;

		// Token: 0x040030C3 RID: 12483
		private string c;

		// Token: 0x040030C4 RID: 12484
		private XmpThumbnail d;
	}
}
