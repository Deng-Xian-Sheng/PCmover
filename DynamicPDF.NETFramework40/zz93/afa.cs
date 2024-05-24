using System;
using ceTe.DynamicPDF.Xmp;

namespace zz93
{
	// Token: 0x020004AC RID: 1196
	internal class afa : XmpDataType
	{
		// Token: 0x06003177 RID: 12663 RVA: 0x001BB8D3 File Offset: 0x001BA8D3
		internal afa()
		{
		}

		// Token: 0x06003178 RID: 12664 RVA: 0x001BB8DE File Offset: 0x001BA8DE
		internal afa(float A_0, float A_1, string A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06003179 RID: 12665 RVA: 0x001BB900 File Offset: 0x001BA900
		internal override void j1(XmpWriter A_0)
		{
			A_0.BeginDescription("http:ns.adobe.com/xap/1.0/sType/Dimensions#", "stDim");
			A_0.Draw("\t\t\t\t<stDim:w>" + this.a + "</stDim:w>\n");
			A_0.Draw("\t\t\t\t<stDim:h>" + this.b + "</stDim:h>\n");
			A_0.Draw("\t\t\t\t<stDim:unit>" + this.c + "</stDim:unit>\n");
			A_0.Draw("\t\t\t</rdf:Description>\n");
		}

		// Token: 0x0400170D RID: 5901
		private float a;

		// Token: 0x0400170E RID: 5902
		private float b;

		// Token: 0x0400170F RID: 5903
		private string c;
	}
}
