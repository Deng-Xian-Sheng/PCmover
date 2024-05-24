using System;
using System.ComponentModel;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000677 RID: 1655
	public enum PageZoom
	{
		// Token: 0x040022AB RID: 8875
		Retain,
		// Token: 0x040022AC RID: 8876
		FitPage,
		// Token: 0x040022AD RID: 8877
		FitWidth,
		// Token: 0x040022AE RID: 8878
		FitHeight,
		// Token: 0x040022AF RID: 8879
		FitBox,
		// Token: 0x040022B0 RID: 8880
		[Obsolete("This enum value is obsolete.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		None
	}
}
