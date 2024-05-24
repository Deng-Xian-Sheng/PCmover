using System;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x02000915 RID: 2325
	public class BasicJobTicketSchema : XmpSchema
	{
		// Token: 0x170009EE RID: 2542
		// (get) Token: 0x06005ED8 RID: 24280 RVA: 0x0035B014 File Offset: 0x0035A014
		public XmpJob JobRef
		{
			get
			{
				if (this.a == null)
				{
					this.a = new XmpJob();
				}
				return this.a;
			}
		}

		// Token: 0x06005ED9 RID: 24281 RVA: 0x0035B04C File Offset: 0x0035A04C
		protected internal override void Draw(XmpWriter xwriter)
		{
			xwriter.BeginDescription("http://ns.adobe.com/xap/1.0/bj/", "xmpBJ", " ");
			xwriter.Draw("\t\t<xmpBJ:JobRef>\n");
			this.a.j1(xwriter);
			xwriter.Draw("\t\t</xmpBJ:JobRef>\n");
			xwriter.EndDescription();
		}

		// Token: 0x040030C0 RID: 12480
		private XmpJob a;
	}
}
