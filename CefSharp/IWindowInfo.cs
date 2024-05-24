using System;
using System.ComponentModel;
using CefSharp.Structs;

namespace CefSharp
{
	// Token: 0x02000082 RID: 130
	public interface IWindowInfo : IDisposable
	{
		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600037C RID: 892
		// (set) Token: 0x0600037D RID: 893
		int X { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600037E RID: 894
		// (set) Token: 0x0600037F RID: 895
		int Y { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000380 RID: 896
		// (set) Token: 0x06000381 RID: 897
		int Width { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000382 RID: 898
		// (set) Token: 0x06000383 RID: 899
		int Height { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000384 RID: 900
		// (set) Token: 0x06000385 RID: 901
		uint Style { get; set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000386 RID: 902
		// (set) Token: 0x06000387 RID: 903
		uint ExStyle { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000388 RID: 904
		// (set) Token: 0x06000389 RID: 905
		IntPtr ParentWindowHandle { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600038A RID: 906
		// (set) Token: 0x0600038B RID: 907
		bool WindowlessRenderingEnabled { get; set; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600038C RID: 908
		// (set) Token: 0x0600038D RID: 909
		bool SharedTextureEnabled { get; set; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600038E RID: 910
		// (set) Token: 0x0600038F RID: 911
		bool ExternalBeginFrameEnabled { get; set; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000390 RID: 912
		// (set) Token: 0x06000391 RID: 913
		IntPtr WindowHandle { get; set; }

		// Token: 0x06000392 RID: 914
		void SetAsChild(IntPtr parentHandle);

		// Token: 0x06000393 RID: 915
		void SetAsChild(IntPtr parentHandle, Rect windowBounds);

		// Token: 0x06000394 RID: 916
		void SetAsChild(IntPtr parentHandle, int left, int top, int right, int bottom);

		// Token: 0x06000395 RID: 917
		void SetAsPopup(IntPtr parentHandle, string windowName);

		// Token: 0x06000396 RID: 918
		void SetAsWindowless(IntPtr parentHandle);

		// Token: 0x06000397 RID: 919
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindowInfo UnWrap();
	}
}
