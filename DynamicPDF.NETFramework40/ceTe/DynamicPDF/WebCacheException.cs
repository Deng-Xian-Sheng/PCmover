using System;
using System.ComponentModel;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200066A RID: 1642
	[Obsolete("This class is obsolete.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class WebCacheException : Exception
	{
		// Token: 0x06003DFB RID: 15867 RVA: 0x002170E9 File Offset: 0x002160E9
		internal WebCacheException(string A_0, Exception A_1) : base(A_0, A_1)
		{
		}
	}
}
