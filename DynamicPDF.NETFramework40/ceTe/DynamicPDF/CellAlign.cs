using System;
using System.ComponentModel;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200067C RID: 1660
	[Obsolete("This enum is obsolete. Use TextAlign enum instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum CellAlign
	{
		// Token: 0x040022DC RID: 8924
		Left = 1,
		// Token: 0x040022DD RID: 8925
		Center,
		// Token: 0x040022DE RID: 8926
		Right,
		// Token: 0x040022DF RID: 8927
		Justify,
		// Token: 0x040022E0 RID: 8928
		FullJustify,
		// Token: 0x040022E1 RID: 8929
		Inherit = 0
	}
}
