using System;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x02000919 RID: 2329
	public class PagedTextSchema : XmpSchema
	{
		// Token: 0x06005EF5 RID: 24309 RVA: 0x0035B948 File Offset: 0x0035A948
		protected internal override void Draw(XmpWriter xwriter)
		{
			xwriter.BeginDescription("http://ns.adobe.com/xap/1.0/t/pg/", "xmpTPg", " ");
			xwriter.Draw("\t\t<xmpTPg:MaxPageSize>\n");
			xwriter.e().j1(xwriter);
			xwriter.Draw("\t\t</xmpTPg:MaxPageSize>\n");
			xwriter.Draw("\t\t<xmpTPg:NPages>" + xwriter.TotalPages + "</xmpTPg:NPages>\n");
			xwriter.EndDescription();
		}
	}
}
