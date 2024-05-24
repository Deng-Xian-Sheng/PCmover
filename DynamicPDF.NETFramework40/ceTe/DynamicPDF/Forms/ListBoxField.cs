using System;
using zz93;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020003FC RID: 1020
	public abstract class ListBoxField : ChoiceField
	{
		// Token: 0x06002AC2 RID: 10946 RVA: 0x0018C78A File Offset: 0x0018B78A
		internal ListBoxField(string A_0, int A_1, AnnotationReaderEvents A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06002AC3 RID: 10947 RVA: 0x0018C798 File Offset: 0x0018B798
		public override bool HasValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06002AC4 RID: 10948
		public abstract void SetValues(string[] values);

		// Token: 0x06002AC5 RID: 10949
		internal abstract string[] hj();

		// Token: 0x06002AC6 RID: 10950
		internal abstract int hi(string A_0);

		// Token: 0x06002AC7 RID: 10951
		internal abstract int hh();

		// Token: 0x06002AC8 RID: 10952 RVA: 0x0018C7AC File Offset: 0x0018B7AC
		internal override bj cc()
		{
			return bj.e;
		}
	}
}
