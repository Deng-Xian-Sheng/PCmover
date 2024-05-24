using System;
using System.ComponentModel;

namespace CefSharp
{
	// Token: 0x02000075 RID: 117
	public interface IPostDataElement : IDisposable
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060002F7 RID: 759
		// (set) Token: 0x060002F8 RID: 760
		string File { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060002F9 RID: 761
		bool IsReadOnly { get; }

		// Token: 0x060002FA RID: 762
		void SetToEmpty();

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060002FB RID: 763
		PostDataElementType Type { get; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060002FC RID: 764
		// (set) Token: 0x060002FD RID: 765
		byte[] Bytes { get; set; }

		// Token: 0x060002FE RID: 766
		[EditorBrowsable(EditorBrowsableState.Never)]
		IPostDataElement UnWrap();
	}
}
