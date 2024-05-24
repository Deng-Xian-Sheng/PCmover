using System;
using System.ComponentModel;
using CefSharp.Core;
using CefSharp.Structs;

namespace CefSharp
{
	// Token: 0x02000010 RID: 16
	public class WindowInfo : IWindowInfo, IDisposable
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600011E RID: 286 RVA: 0x0000339E File Offset: 0x0000159E
		// (set) Token: 0x0600011F RID: 287 RVA: 0x000033AB File Offset: 0x000015AB
		public int X
		{
			get
			{
				return this.windowInfo.X;
			}
			set
			{
				this.windowInfo.X = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000120 RID: 288 RVA: 0x000033B9 File Offset: 0x000015B9
		// (set) Token: 0x06000121 RID: 289 RVA: 0x000033C6 File Offset: 0x000015C6
		public int Y
		{
			get
			{
				return this.windowInfo.Y;
			}
			set
			{
				this.windowInfo.Y = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000122 RID: 290 RVA: 0x000033D4 File Offset: 0x000015D4
		// (set) Token: 0x06000123 RID: 291 RVA: 0x000033E1 File Offset: 0x000015E1
		public int Width
		{
			get
			{
				return this.windowInfo.Width;
			}
			set
			{
				this.windowInfo.Width = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000124 RID: 292 RVA: 0x000033EF File Offset: 0x000015EF
		// (set) Token: 0x06000125 RID: 293 RVA: 0x000033FC File Offset: 0x000015FC
		public int Height
		{
			get
			{
				return this.windowInfo.Height;
			}
			set
			{
				this.windowInfo.Height = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000126 RID: 294 RVA: 0x0000340A File Offset: 0x0000160A
		// (set) Token: 0x06000127 RID: 295 RVA: 0x00003417 File Offset: 0x00001617
		public uint Style
		{
			get
			{
				return this.windowInfo.Style;
			}
			set
			{
				this.windowInfo.Style = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00003425 File Offset: 0x00001625
		// (set) Token: 0x06000129 RID: 297 RVA: 0x00003432 File Offset: 0x00001632
		public uint ExStyle
		{
			get
			{
				return this.windowInfo.ExStyle;
			}
			set
			{
				this.windowInfo.ExStyle = value;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00003440 File Offset: 0x00001640
		// (set) Token: 0x0600012B RID: 299 RVA: 0x0000344D File Offset: 0x0000164D
		public IntPtr ParentWindowHandle
		{
			get
			{
				return this.windowInfo.ParentWindowHandle;
			}
			set
			{
				this.windowInfo.ParentWindowHandle = value;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600012C RID: 300 RVA: 0x0000345B File Offset: 0x0000165B
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00003468 File Offset: 0x00001668
		public bool WindowlessRenderingEnabled
		{
			get
			{
				return this.windowInfo.WindowlessRenderingEnabled;
			}
			set
			{
				this.windowInfo.WindowlessRenderingEnabled = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00003476 File Offset: 0x00001676
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00003483 File Offset: 0x00001683
		public bool SharedTextureEnabled
		{
			get
			{
				return this.windowInfo.SharedTextureEnabled;
			}
			set
			{
				this.windowInfo.SharedTextureEnabled = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00003491 File Offset: 0x00001691
		// (set) Token: 0x06000131 RID: 305 RVA: 0x0000349E File Offset: 0x0000169E
		public bool ExternalBeginFrameEnabled
		{
			get
			{
				return this.windowInfo.ExternalBeginFrameEnabled;
			}
			set
			{
				this.windowInfo.ExternalBeginFrameEnabled = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000132 RID: 306 RVA: 0x000034AC File Offset: 0x000016AC
		// (set) Token: 0x06000133 RID: 307 RVA: 0x000034B9 File Offset: 0x000016B9
		public IntPtr WindowHandle
		{
			get
			{
				return this.windowInfo.WindowHandle;
			}
			set
			{
				this.windowInfo.WindowHandle = value;
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000034C7 File Offset: 0x000016C7
		public void Dispose()
		{
			this.windowInfo.Dispose();
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000034D4 File Offset: 0x000016D4
		public void SetAsChild(IntPtr parentHandle)
		{
			this.windowInfo.SetAsChild(parentHandle);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000034E2 File Offset: 0x000016E2
		public void SetAsChild(IntPtr parentHandle, Rect windowBounds)
		{
			this.windowInfo.SetAsChild(parentHandle, windowBounds);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000034F1 File Offset: 0x000016F1
		public void SetAsChild(IntPtr parentHandle, int left, int top, int right, int bottom)
		{
			this.windowInfo.SetAsChild(parentHandle, left, top, right, bottom);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00003505 File Offset: 0x00001705
		public void SetAsPopup(IntPtr parentHandle, string windowName)
		{
			this.windowInfo.SetAsPopup(parentHandle, windowName);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00003514 File Offset: 0x00001714
		public void SetAsWindowless(IntPtr parentHandle)
		{
			this.windowInfo.SetAsWindowless(parentHandle);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00003522 File Offset: 0x00001722
		public static IWindowInfo Create()
		{
			return new WindowInfo();
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00003529 File Offset: 0x00001729
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IWindowInfo UnWrap()
		{
			return this.windowInfo;
		}

		// Token: 0x0400000D RID: 13
		private WindowInfo windowInfo = new WindowInfo();
	}
}
