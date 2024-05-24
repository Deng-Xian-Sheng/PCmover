using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;

namespace ControlzEx.Standard
{
	// Token: 0x0200001E RID: 30
	internal sealed class MessageWindow : DispatcherObject, IDisposable
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000164 RID: 356 RVA: 0x0000816B File Offset: 0x0000636B
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00008173 File Offset: 0x00006373
		public IntPtr Handle { get; private set; }

		// Token: 0x06000166 RID: 358 RVA: 0x0000817C File Offset: 0x0000637C
		public MessageWindow(CS classStyle, WS style, WS_EX exStyle, Rect location, string name, WndProc callback)
		{
			this._wndProcCallback = callback;
			this._className = "MessageWindowClass+" + Guid.NewGuid().ToString();
			WNDCLASSEX wndclassex = new WNDCLASSEX
			{
				cbSize = Marshal.SizeOf(typeof(WNDCLASSEX)),
				style = classStyle,
				lpfnWndProc = MessageWindow.s_WndProc,
				hInstance = NativeMethods.GetModuleHandle(null),
				hbrBackground = NativeMethods.GetStockObject(StockObject.NULL_BRUSH),
				lpszMenuName = "",
				lpszClassName = this._className
			};
			NativeMethods.RegisterClassEx(ref wndclassex);
			GCHandle value = default(GCHandle);
			try
			{
				value = GCHandle.Alloc(this);
				IntPtr lpParam = (IntPtr)value;
				this.Handle = NativeMethods.CreateWindowEx(exStyle, this._className, name, style, (int)location.X, (int)location.Y, (int)location.Width, (int)location.Height, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, lpParam);
			}
			finally
			{
				value.Free();
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x000082A0 File Offset: 0x000064A0
		~MessageWindow()
		{
			this._Dispose(false, false);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000082D0 File Offset: 0x000064D0
		public void Dispose()
		{
			this._Dispose(true, false);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000082E0 File Offset: 0x000064E0
		private void _Dispose(bool disposing, bool isHwndBeingDestroyed)
		{
			if (this._isDisposed)
			{
				return;
			}
			this._isDisposed = true;
			IntPtr hwnd = this.Handle;
			string className = this._className;
			if (isHwndBeingDestroyed)
			{
				base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DispatcherOperationCallback((object arg) => MessageWindow._DestroyWindow(IntPtr.Zero, className)));
			}
			else if (this.Handle != IntPtr.Zero)
			{
				if (base.CheckAccess())
				{
					MessageWindow._DestroyWindow(hwnd, className);
				}
				else
				{
					base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DispatcherOperationCallback((object arg) => MessageWindow._DestroyWindow(hwnd, className)));
				}
			}
			MessageWindow.s_windowLookup.Remove(hwnd);
			this._className = null;
			this.Handle = IntPtr.Zero;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000083A8 File Offset: 0x000065A8
		private static IntPtr _WndProc(IntPtr hwnd, WM msg, IntPtr wParam, IntPtr lParam)
		{
			IntPtr result = IntPtr.Zero;
			MessageWindow messageWindow = null;
			if (msg == WM.CREATE)
			{
				messageWindow = (MessageWindow)GCHandle.FromIntPtr(((CREATESTRUCT)Marshal.PtrToStructure(lParam, typeof(CREATESTRUCT))).lpCreateParams).Target;
				MessageWindow.s_windowLookup.Add(hwnd, messageWindow);
			}
			else if (!MessageWindow.s_windowLookup.TryGetValue(hwnd, out messageWindow))
			{
				return NativeMethods.DefWindowProc(hwnd, msg, wParam, lParam);
			}
			WndProc wndProcCallback = messageWindow._wndProcCallback;
			if (wndProcCallback != null)
			{
				result = wndProcCallback(hwnd, msg, wParam, lParam);
			}
			else
			{
				result = NativeMethods.DefWindowProc(hwnd, msg, wParam, lParam);
			}
			if (msg == WM.NCDESTROY)
			{
				messageWindow._Dispose(true, true);
				GC.SuppressFinalize(messageWindow);
			}
			return result;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000844D File Offset: 0x0000664D
		private static object _DestroyWindow(IntPtr hwnd, string className)
		{
			Utility.SafeDestroyWindow(ref hwnd);
			NativeMethods.UnregisterClass(className, NativeMethods.GetModuleHandle(null));
			return null;
		}

		// Token: 0x04000134 RID: 308
		private static readonly WndProc s_WndProc = new WndProc(MessageWindow._WndProc);

		// Token: 0x04000135 RID: 309
		private static readonly Dictionary<IntPtr, MessageWindow> s_windowLookup = new Dictionary<IntPtr, MessageWindow>();

		// Token: 0x04000136 RID: 310
		private WndProc _wndProcCallback;

		// Token: 0x04000137 RID: 311
		private string _className;

		// Token: 0x04000138 RID: 312
		private bool _isDisposed;
	}
}
