using System;
using System.ComponentModel;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020006D1 RID: 1745
	[Obsolete("This enum is obsolete.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum FormFieldFlags
	{
		// Token: 0x0400258B RID: 9611
		None,
		// Token: 0x0400258C RID: 9612
		ReadOnly,
		// Token: 0x0400258D RID: 9613
		Required,
		// Token: 0x0400258E RID: 9614
		NoExport = 4,
		// Token: 0x0400258F RID: 9615
		Multiline = 4096,
		// Token: 0x04002590 RID: 9616
		Password = 8192,
		// Token: 0x04002591 RID: 9617
		NoToggleToOff = 16384,
		// Token: 0x04002592 RID: 9618
		Radio = 32768,
		// Token: 0x04002593 RID: 9619
		Pushbutton = 65536,
		// Token: 0x04002594 RID: 9620
		Combo = 131072,
		// Token: 0x04002595 RID: 9621
		Edit = 262144,
		// Token: 0x04002596 RID: 9622
		Sort = 524288,
		// Token: 0x04002597 RID: 9623
		FileSelect = 1048576,
		// Token: 0x04002598 RID: 9624
		MultiSelect = 2097152,
		// Token: 0x04002599 RID: 9625
		DoNotSpellCheck = 4194304,
		// Token: 0x0400259A RID: 9626
		DoNotScroll = 8388608,
		// Token: 0x0400259B RID: 9627
		Comb = 16777216,
		// Token: 0x0400259C RID: 9628
		RadiosInUnison = 33554432,
		// Token: 0x0400259D RID: 9629
		CommitOnSelChange = 67108864,
		// Token: 0x0400259E RID: 9630
		RichText = 134217728
	}
}
