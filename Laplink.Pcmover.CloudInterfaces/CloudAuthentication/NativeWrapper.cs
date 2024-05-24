using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Laplink.Pcmover.CloudAuthentication
{
	// Token: 0x0200000C RID: 12
	internal class NativeWrapper
	{
		// Token: 0x02000015 RID: 21
		[StructLayout(LayoutKind.Sequential)]
		public class POINT
		{
			// Token: 0x06000093 RID: 147 RVA: 0x00003023 File Offset: 0x00001223
			public POINT()
			{
			}

			// Token: 0x06000094 RID: 148 RVA: 0x0000302B File Offset: 0x0000122B
			public POINT(int x, int y)
			{
				this.x = x;
				this.y = y;
			}

			// Token: 0x04000031 RID: 49
			public int x;

			// Token: 0x04000032 RID: 50
			public int y;
		}

		// Token: 0x02000016 RID: 22
		[StructLayout(LayoutKind.Sequential)]
		public class OLECMD
		{
			// Token: 0x04000033 RID: 51
			[MarshalAs(UnmanagedType.U4)]
			public int cmdID;

			// Token: 0x04000034 RID: 52
			[MarshalAs(UnmanagedType.U4)]
			public int cmdf;
		}

		// Token: 0x02000017 RID: 23
		[ComVisible(true)]
		[Guid("B722BCCB-4E68-101B-A2BC-00AA00404770")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComImport]
		public interface IOleCommandTarget
		{
			// Token: 0x06000096 RID: 150
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int QueryStatus(ref Guid pguidCmdGroup, int cCmds, [In] [Out] NativeWrapper.OLECMD prgCmds, [In] [Out] IntPtr pCmdText);

			// Token: 0x06000097 RID: 151
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int Exec(IntPtr guid, int nCmdID, int nCmdexecopt, [MarshalAs(UnmanagedType.LPArray)] [In] object[] pvaIn, IntPtr pvaOut);
		}

		// Token: 0x02000018 RID: 24
		[ComVisible(true)]
		[StructLayout(LayoutKind.Sequential)]
		public class DOCHOSTUIINFO
		{
			// Token: 0x04000035 RID: 53
			[MarshalAs(UnmanagedType.U4)]
			public int cbSize = Marshal.SizeOf(typeof(NativeWrapper.DOCHOSTUIINFO));

			// Token: 0x04000036 RID: 54
			[MarshalAs(UnmanagedType.I4)]
			public int dwFlags;

			// Token: 0x04000037 RID: 55
			[MarshalAs(UnmanagedType.I4)]
			public int dwDoubleClick;

			// Token: 0x04000038 RID: 56
			[MarshalAs(UnmanagedType.I4)]
			public int dwReserved1;

			// Token: 0x04000039 RID: 57
			[MarshalAs(UnmanagedType.I4)]
			public int dwReserved2;
		}

		// Token: 0x02000019 RID: 25
		[Serializable]
		public struct MSG
		{
			// Token: 0x0400003A RID: 58
			public IntPtr hwnd;

			// Token: 0x0400003B RID: 59
			public int message;

			// Token: 0x0400003C RID: 60
			public IntPtr wParam;

			// Token: 0x0400003D RID: 61
			public IntPtr lParam;

			// Token: 0x0400003E RID: 62
			public int time;

			// Token: 0x0400003F RID: 63
			public int pt_x;

			// Token: 0x04000040 RID: 64
			public int pt_y;
		}

		// Token: 0x0200001A RID: 26
		[StructLayout(LayoutKind.Sequential)]
		public class COMRECT
		{
			// Token: 0x06000099 RID: 153 RVA: 0x00003068 File Offset: 0x00001268
			public override string ToString()
			{
				return string.Concat(new object[]
				{
					"Left = ",
					this.left,
					" Top ",
					this.top,
					" Right = ",
					this.right,
					" Bottom = ",
					this.bottom
				});
			}

			// Token: 0x0600009A RID: 154 RVA: 0x000030D8 File Offset: 0x000012D8
			public COMRECT()
			{
			}

			// Token: 0x0600009B RID: 155 RVA: 0x000030E0 File Offset: 0x000012E0
			public COMRECT(Rectangle r)
			{
				this.left = r.X;
				this.top = r.Y;
				this.right = r.Right;
				this.bottom = r.Bottom;
			}

			// Token: 0x0600009C RID: 156 RVA: 0x0000311C File Offset: 0x0000131C
			public COMRECT(int left, int top, int right, int bottom)
			{
				this.left = left;
				this.top = top;
				this.right = right;
				this.bottom = bottom;
			}

			// Token: 0x0600009D RID: 157 RVA: 0x00003141 File Offset: 0x00001341
			public static NativeWrapper.COMRECT FromXYWH(int x, int y, int width, int height)
			{
				return new NativeWrapper.COMRECT(x, y, x + width, y + height);
			}

			// Token: 0x04000041 RID: 65
			public int left;

			// Token: 0x04000042 RID: 66
			public int top;

			// Token: 0x04000043 RID: 67
			public int right;

			// Token: 0x04000044 RID: 68
			public int bottom;
		}

		// Token: 0x0200001B RID: 27
		[Guid("00000115-0000-0000-C000-000000000046")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComImport]
		public interface IOleInPlaceUIWindow
		{
			// Token: 0x0600009E RID: 158
			IntPtr GetWindow();

			// Token: 0x0600009F RID: 159
			[PreserveSig]
			int ContextSensitiveHelp(int fEnterMode);

			// Token: 0x060000A0 RID: 160
			[PreserveSig]
			int GetBorder([Out] NativeWrapper.COMRECT lprectBorder);

			// Token: 0x060000A1 RID: 161
			[PreserveSig]
			int RequestBorderSpace([In] NativeWrapper.COMRECT pborderwidths);

			// Token: 0x060000A2 RID: 162
			[PreserveSig]
			int SetBorderSpace([In] NativeWrapper.COMRECT pborderwidths);

			// Token: 0x060000A3 RID: 163
			void SetActiveObject([MarshalAs(UnmanagedType.Interface)] [In] NativeWrapper.IOleInPlaceActiveObject pActiveObject, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszObjName);
		}

		// Token: 0x0200001C RID: 28
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[Guid("00000117-0000-0000-C000-000000000046")]
		[ComImport]
		public interface IOleInPlaceActiveObject
		{
			// Token: 0x060000A4 RID: 164
			[PreserveSig]
			int GetWindow(out IntPtr hwnd);

			// Token: 0x060000A5 RID: 165
			void ContextSensitiveHelp(int fEnterMode);

			// Token: 0x060000A6 RID: 166
			[PreserveSig]
			int TranslateAccelerator([In] ref NativeWrapper.MSG lpmsg);

			// Token: 0x060000A7 RID: 167
			void OnFrameWindowActivate(bool fActivate);

			// Token: 0x060000A8 RID: 168
			void OnDocWindowActivate(int fActivate);

			// Token: 0x060000A9 RID: 169
			void ResizeBorder([In] NativeWrapper.COMRECT prcBorder, [In] NativeWrapper.IOleInPlaceUIWindow pUIWindow, bool fFrameWindow);

			// Token: 0x060000AA RID: 170
			void EnableModeless(int fEnable);
		}

		// Token: 0x0200001D RID: 29
		[StructLayout(LayoutKind.Sequential)]
		public sealed class tagOleMenuGroupWidths
		{
			// Token: 0x04000045 RID: 69
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
			public int[] widths = new int[6];
		}

		// Token: 0x0200001E RID: 30
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[Guid("00000116-0000-0000-C000-000000000046")]
		[ComImport]
		public interface IOleInPlaceFrame
		{
			// Token: 0x060000AC RID: 172
			IntPtr GetWindow();

			// Token: 0x060000AD RID: 173
			[PreserveSig]
			int ContextSensitiveHelp(int fEnterMode);

			// Token: 0x060000AE RID: 174
			[PreserveSig]
			int GetBorder([Out] NativeWrapper.COMRECT lprectBorder);

			// Token: 0x060000AF RID: 175
			[PreserveSig]
			int RequestBorderSpace([In] NativeWrapper.COMRECT pborderwidths);

			// Token: 0x060000B0 RID: 176
			[PreserveSig]
			int SetBorderSpace([In] NativeWrapper.COMRECT pborderwidths);

			// Token: 0x060000B1 RID: 177
			[PreserveSig]
			int SetActiveObject([MarshalAs(UnmanagedType.Interface)] [In] NativeWrapper.IOleInPlaceActiveObject pActiveObject, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszObjName);

			// Token: 0x060000B2 RID: 178
			[PreserveSig]
			int InsertMenus([In] IntPtr hmenuShared, [In] [Out] NativeWrapper.tagOleMenuGroupWidths lpMenuWidths);

			// Token: 0x060000B3 RID: 179
			[PreserveSig]
			int SetMenu([In] IntPtr hmenuShared, [In] IntPtr holemenu, [In] IntPtr hwndActiveObject);

			// Token: 0x060000B4 RID: 180
			[PreserveSig]
			int RemoveMenus([In] IntPtr hmenuShared);

			// Token: 0x060000B5 RID: 181
			[PreserveSig]
			int SetStatusText([MarshalAs(UnmanagedType.LPWStr)] [In] string pszStatusText);

			// Token: 0x060000B6 RID: 182
			[PreserveSig]
			int EnableModeless(bool fEnable);

			// Token: 0x060000B7 RID: 183
			[PreserveSig]
			int TranslateAccelerator([In] ref NativeWrapper.MSG lpmsg, [MarshalAs(UnmanagedType.U2)] [In] short wID);
		}

		// Token: 0x0200001F RID: 31
		[Guid("00000122-0000-0000-C000-000000000046")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComImport]
		public interface IOleDropTarget
		{
			// Token: 0x060000B8 RID: 184
			[PreserveSig]
			int OleDragEnter([MarshalAs(UnmanagedType.Interface)] [In] object pDataObj, [MarshalAs(UnmanagedType.U4)] [In] int grfKeyState, [In] NativeWrapper.POINT pt, [In] [Out] ref int pdwEffect);

			// Token: 0x060000B9 RID: 185
			[PreserveSig]
			int OleDragOver([MarshalAs(UnmanagedType.U4)] [In] int grfKeyState, [In] NativeWrapper.POINT pt, [In] [Out] ref int pdwEffect);

			// Token: 0x060000BA RID: 186
			[PreserveSig]
			int OleDragLeave();

			// Token: 0x060000BB RID: 187
			[PreserveSig]
			int OleDrop([MarshalAs(UnmanagedType.Interface)] [In] object pDataObj, [MarshalAs(UnmanagedType.U4)] [In] int grfKeyState, [In] NativeWrapper.POINT pt, [In] [Out] ref int pdwEffect);
		}

		// Token: 0x02000020 RID: 32
		[ComVisible(true)]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[Guid("BD3F23C0-D43E-11CF-893B-00AA00BDCE1A")]
		[ComImport]
		public interface IDocHostUIHandler
		{
			// Token: 0x060000BC RID: 188
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int ShowContextMenu([MarshalAs(UnmanagedType.U4)] [In] int dwID, [In] NativeWrapper.POINT pt, [MarshalAs(UnmanagedType.Interface)] [In] object pcmdtReserved, [MarshalAs(UnmanagedType.Interface)] [In] object pdispReserved);

			// Token: 0x060000BD RID: 189
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int GetHostInfo([In] [Out] NativeWrapper.DOCHOSTUIINFO info);

			// Token: 0x060000BE RID: 190
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int ShowUI([MarshalAs(UnmanagedType.I4)] [In] int dwID, [In] NativeWrapper.IOleInPlaceActiveObject activeObject, [In] NativeWrapper.IOleCommandTarget commandTarget, [In] NativeWrapper.IOleInPlaceFrame frame, [In] NativeWrapper.IOleInPlaceUIWindow doc);

			// Token: 0x060000BF RID: 191
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int HideUI();

			// Token: 0x060000C0 RID: 192
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int UpdateUI();

			// Token: 0x060000C1 RID: 193
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int EnableModeless([MarshalAs(UnmanagedType.Bool)] [In] bool fEnable);

			// Token: 0x060000C2 RID: 194
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int OnDocWindowActivate([MarshalAs(UnmanagedType.Bool)] [In] bool fActivate);

			// Token: 0x060000C3 RID: 195
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int OnFrameWindowActivate([MarshalAs(UnmanagedType.Bool)] [In] bool fActivate);

			// Token: 0x060000C4 RID: 196
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int ResizeBorder([In] NativeWrapper.COMRECT rect, [In] NativeWrapper.IOleInPlaceUIWindow doc, bool fFrameWindow);

			// Token: 0x060000C5 RID: 197
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int TranslateAccelerator([In] ref NativeWrapper.MSG msg, [In] ref Guid group, [MarshalAs(UnmanagedType.I4)] [In] int nCmdID);

			// Token: 0x060000C6 RID: 198
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int GetOptionKeyPath([MarshalAs(UnmanagedType.LPArray)] [Out] string[] pbstrKey, [MarshalAs(UnmanagedType.U4)] [In] int dw);

			// Token: 0x060000C7 RID: 199
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int GetDropTarget([MarshalAs(UnmanagedType.Interface)] [In] NativeWrapper.IOleDropTarget pDropTarget, [MarshalAs(UnmanagedType.Interface)] out NativeWrapper.IOleDropTarget ppDropTarget);

			// Token: 0x060000C8 RID: 200
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int GetExternal([MarshalAs(UnmanagedType.Interface)] out object ppDispatch);

			// Token: 0x060000C9 RID: 201
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int TranslateUrl([MarshalAs(UnmanagedType.U4)] [In] int dwTranslate, [MarshalAs(UnmanagedType.LPWStr)] [In] string strURLIn, [MarshalAs(UnmanagedType.LPWStr)] out string pstrURLOut);

			// Token: 0x060000CA RID: 202
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.I4)]
			int FilterDataObject(IDataObject pDO, out IDataObject ppDORet);
		}

		// Token: 0x02000021 RID: 33
		[Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E")]
		[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
		[ComImport]
		public interface IWebBrowser2
		{
			// Token: 0x1700001B RID: 27
			// (get) Token: 0x060000CB RID: 203
			[DispId(203)]
			object Document { [DispId(203)] [return: MarshalAs(UnmanagedType.IDispatch)] get; }

			// Token: 0x1700001C RID: 28
			// (set) Token: 0x060000CC RID: 204
			[DispId(551)]
			bool Silent { [DispId(551)] [param: MarshalAs(UnmanagedType.Bool)] set; }
		}

		// Token: 0x02000022 RID: 34
		[Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D")]
		[TypeLibType(TypeLibTypeFlags.FHidden)]
		[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
		[ComImport]
		public interface DWebBrowserEvents2
		{
			// Token: 0x060000CD RID: 205
			[DispId(102)]
			void StatusTextChange([In] string text);

			// Token: 0x060000CE RID: 206
			[DispId(108)]
			void ProgressChange([In] int progress, [In] int progressMax);

			// Token: 0x060000CF RID: 207
			[DispId(105)]
			void CommandStateChange([In] long command, [In] bool enable);

			// Token: 0x060000D0 RID: 208
			[DispId(106)]
			void DownloadBegin();

			// Token: 0x060000D1 RID: 209
			[DispId(104)]
			void DownloadComplete();

			// Token: 0x060000D2 RID: 210
			[DispId(113)]
			void TitleChange([In] string text);

			// Token: 0x060000D3 RID: 211
			[DispId(112)]
			void PropertyChange([In] string szProperty);

			// Token: 0x060000D4 RID: 212
			[DispId(250)]
			void BeforeNavigate2([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp, [In] ref object URL, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers, [In] [Out] ref bool cancel);

			// Token: 0x060000D5 RID: 213
			[DispId(251)]
			void NewWindow2([MarshalAs(UnmanagedType.IDispatch)] [In] [Out] ref object pDisp, [In] [Out] ref bool cancel);

			// Token: 0x060000D6 RID: 214
			[DispId(252)]
			void NavigateComplete2([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp, [In] ref object URL);

			// Token: 0x060000D7 RID: 215
			[DispId(259)]
			void DocumentComplete([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp, [In] ref object URL);

			// Token: 0x060000D8 RID: 216
			[DispId(253)]
			void OnQuit();

			// Token: 0x060000D9 RID: 217
			[DispId(254)]
			void OnVisible([In] bool visible);

			// Token: 0x060000DA RID: 218
			[DispId(255)]
			void OnToolBar([In] bool toolBar);

			// Token: 0x060000DB RID: 219
			[DispId(256)]
			void OnMenuBar([In] bool menuBar);

			// Token: 0x060000DC RID: 220
			[DispId(257)]
			void OnStatusBar([In] bool statusBar);

			// Token: 0x060000DD RID: 221
			[DispId(258)]
			void OnFullScreen([In] bool fullScreen);

			// Token: 0x060000DE RID: 222
			[DispId(260)]
			void OnTheaterMode([In] bool theaterMode);

			// Token: 0x060000DF RID: 223
			[DispId(262)]
			void WindowSetResizable([In] bool resizable);

			// Token: 0x060000E0 RID: 224
			[DispId(264)]
			void WindowSetLeft([In] int left);

			// Token: 0x060000E1 RID: 225
			[DispId(265)]
			void WindowSetTop([In] int top);

			// Token: 0x060000E2 RID: 226
			[DispId(266)]
			void WindowSetWidth([In] int width);

			// Token: 0x060000E3 RID: 227
			[DispId(267)]
			void WindowSetHeight([In] int height);

			// Token: 0x060000E4 RID: 228
			[DispId(263)]
			void WindowClosing([In] bool isChildWindow, [In] [Out] ref bool cancel);

			// Token: 0x060000E5 RID: 229
			[DispId(268)]
			void ClientToHostWindow([In] [Out] ref long cx, [In] [Out] ref long cy);

			// Token: 0x060000E6 RID: 230
			[DispId(269)]
			void SetSecureLockIcon([In] int secureLockIcon);

			// Token: 0x060000E7 RID: 231
			[DispId(270)]
			void FileDownload([In] [Out] ref bool cancel);

			// Token: 0x060000E8 RID: 232
			[DispId(271)]
			void NavigateError([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp, [In] ref object URL, [In] ref object frame, [In] ref object statusCode, [In] [Out] ref bool cancel);

			// Token: 0x060000E9 RID: 233
			[DispId(225)]
			void PrintTemplateInstantiation([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp);

			// Token: 0x060000EA RID: 234
			[DispId(226)]
			void PrintTemplateTeardown([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp);

			// Token: 0x060000EB RID: 235
			[DispId(227)]
			void UpdatePageStatus([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp, [In] ref object nPage, [In] ref object fDone);

			// Token: 0x060000EC RID: 236
			[DispId(272)]
			void PrivacyImpactedStateChange([In] bool bImpacted);
		}

		// Token: 0x02000023 RID: 35
		internal static class NativeMethods
		{
			// Token: 0x060000ED RID: 237
			[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
			internal static extern IntPtr GetDC(IntPtr hWnd);

			// Token: 0x060000EE RID: 238
			[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
			internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

			// Token: 0x060000EF RID: 239
			[DllImport("Gdi32.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
			internal static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

			// Token: 0x060000F0 RID: 240
			[DllImport("User32.dll", ExactSpelling = true)]
			internal static extern bool IsProcessDPIAware();
		}
	}
}
