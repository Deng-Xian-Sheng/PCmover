using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000074 RID: 116
	internal class ck : AreaDimensions
	{
		// Token: 0x060004C4 RID: 1220 RVA: 0x0004F818 File Offset: 0x0004E818
		internal ck(float A_0, float A_1) : base(new Dimensions(0f, 0f, A_0, A_1))
		{
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0004F834 File Offset: 0x0004E834
		internal override float aw(float A_0)
		{
			return this.GetPdfX(A_0);
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0004F850 File Offset: 0x0004E850
		internal override float ax(float A_0)
		{
			return this.GetPdfY(A_0);
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0004F869 File Offset: 0x0004E869
		internal override AreaDimensions ay()
		{
			throw new GeneratorException("AppearanceStreamDimensions do not have a Parent.");
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0004F878 File Offset: 0x0004E878
		internal override float az()
		{
			return 1f;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0004F890 File Offset: 0x0004E890
		internal override float a0()
		{
			return 1f;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0004F8A7 File Offset: 0x0004E8A7
		internal override void a1(OperatorWriter A_0)
		{
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0004F8AA File Offset: 0x0004E8AA
		internal override void a2(OperatorWriter A_0)
		{
		}
	}
}
