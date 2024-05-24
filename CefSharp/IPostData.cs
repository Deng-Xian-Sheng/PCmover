using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CefSharp
{
	// Token: 0x02000074 RID: 116
	public interface IPostData : IDisposable
	{
		// Token: 0x060002EE RID: 750
		bool AddElement(IPostDataElement element);

		// Token: 0x060002EF RID: 751
		bool RemoveElement(IPostDataElement element);

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060002F0 RID: 752
		IList<IPostDataElement> Elements { get; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060002F1 RID: 753
		bool IsReadOnly { get; }

		// Token: 0x060002F2 RID: 754
		void RemoveElements();

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060002F3 RID: 755
		bool IsDisposed { get; }

		// Token: 0x060002F4 RID: 756
		IPostDataElement CreatePostDataElement();

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060002F5 RID: 757
		bool HasExcludedElements { get; }

		// Token: 0x060002F6 RID: 758
		[EditorBrowsable(EditorBrowsableState.Never)]
		IPostData UnWrap();
	}
}
