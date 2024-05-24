using System;
using zz93;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020003F8 RID: 1016
	public abstract class ComboBoxField : ChoiceField
	{
		// Token: 0x06002A6A RID: 10858 RVA: 0x0018A943 File Offset: 0x00189943
		internal ComboBoxField(string A_0, int A_1, AnnotationReaderEvents A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06002A6B RID: 10859 RVA: 0x0018A954 File Offset: 0x00189954
		public override bool HasValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06002A6C RID: 10860
		internal abstract string[] hg();

		// Token: 0x06002A6D RID: 10861 RVA: 0x0018A968 File Offset: 0x00189968
		internal override bj cc()
		{
			return bj.c;
		}
	}
}
