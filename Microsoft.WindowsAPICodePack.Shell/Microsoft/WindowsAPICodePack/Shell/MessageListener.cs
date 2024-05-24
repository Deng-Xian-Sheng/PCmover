using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.WindowsAPICodePack.Shell.Interop;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000113 RID: 275
	internal class MessageListener : IDisposable
	{
		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000C21 RID: 3105 RVA: 0x0002E564 File Offset: 0x0002C764
		// (remove) Token: 0x06000C22 RID: 3106 RVA: 0x0002E5A0 File Offset: 0x0002C7A0
		public event EventHandler<WindowMessageEventArgs> MessageReceived;

		// Token: 0x06000C23 RID: 3107 RVA: 0x0002E5DC File Offset: 0x0002C7DC
		public MessageListener()
		{
			lock (MessageListener._threadlock)
			{
				if (MessageListener._windowThread == null)
				{
					MessageListener._windowThread = new Thread(new ThreadStart(this.ThreadMethod));
					MessageListener._windowThread.SetApartmentState(ApartmentState.STA);
					MessageListener._windowThread.Name = "ShellObjectWatcherMessageListenerHelperThread";
					lock (MessageListener._crossThreadWindowLock)
					{
						MessageListener._windowThread.Start();
						Monitor.Wait(MessageListener._crossThreadWindowLock);
					}
					MessageListener._firstWindowHandle = this.WindowHandle;
				}
				else
				{
					this.CrossThreadCreateWindow();
				}
				if (this.WindowHandle == IntPtr.Zero)
				{
					throw new ShellException(LocalizedMessages.MessageListenerCannotCreateWindow, Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()));
				}
				MessageListener._listeners.Add(this.WindowHandle, this);
			}
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x0002E6F0 File Offset: 0x0002C8F0
		private void CrossThreadCreateWindow()
		{
			if (MessageListener._firstWindowHandle == IntPtr.Zero)
			{
				throw new InvalidOperationException(LocalizedMessages.MessageListenerNoWindowHandle);
			}
			lock (MessageListener._crossThreadWindowLock)
			{
				CoreNativeMethods.PostMessage(MessageListener._firstWindowHandle, (WindowMessage)1025, IntPtr.Zero, IntPtr.Zero);
				Monitor.Wait(MessageListener._crossThreadWindowLock);
			}
			this.WindowHandle = MessageListener._tempHandle;
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x0002E77C File Offset: 0x0002C97C
		private static void RegisterWindowClass()
		{
			WindowClassEx windowClassEx = default(WindowClassEx);
			windowClassEx.ClassName = "MessageListenerClass";
			windowClassEx.WndProc = MessageListener.wndProc;
			windowClassEx.Size = (uint)Marshal.SizeOf(typeof(WindowClassEx));
			uint num = ShellObjectWatcherNativeMethods.RegisterClassEx(ref windowClassEx);
			if (num == 0U)
			{
				throw new ShellException(LocalizedMessages.MessageListenerClassNotRegistered, Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()));
			}
			MessageListener._atom = num;
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x0002E7F0 File Offset: 0x0002C9F0
		private static IntPtr CreateWindow()
		{
			return ShellObjectWatcherNativeMethods.CreateWindowEx(0, "MessageListenerClass", "MessageListenerWindow", 0, 0, 0, 0, 0, new IntPtr(-3), IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x0002E830 File Offset: 0x0002CA30
		private void ThreadMethod()
		{
			lock (MessageListener._crossThreadWindowLock)
			{
				MessageListener._running = true;
				if (MessageListener._atom == 0U)
				{
					MessageListener.RegisterWindowClass();
				}
				this.WindowHandle = MessageListener.CreateWindow();
				Monitor.Pulse(MessageListener._crossThreadWindowLock);
			}
			while (MessageListener._running)
			{
				Message message;
				if (ShellObjectWatcherNativeMethods.GetMessage(out message, IntPtr.Zero, 0U, 0U))
				{
					ShellObjectWatcherNativeMethods.DispatchMessage(ref message);
				}
			}
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x0002E8CC File Offset: 0x0002CACC
		private static int WndProc(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam)
		{
			if (msg != 2U)
			{
				if (msg != 1025U)
				{
					MessageListener messageListener;
					if (MessageListener._listeners.TryGetValue(hwnd, out messageListener))
					{
						Message msg2 = new Message(hwnd, msg, wparam, lparam, 0, default(NativePoint));
						messageListener.MessageReceived.SafeRaise(messageListener, new WindowMessageEventArgs(msg2));
					}
				}
				else
				{
					lock (MessageListener._crossThreadWindowLock)
					{
						MessageListener._tempHandle = MessageListener.CreateWindow();
						Monitor.Pulse(MessageListener._crossThreadWindowLock);
					}
				}
			}
			return ShellObjectWatcherNativeMethods.DefWindowProc(hwnd, msg, wparam, lparam);
		}

		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x06000C29 RID: 3113 RVA: 0x0002E980 File Offset: 0x0002CB80
		// (set) Token: 0x06000C2A RID: 3114 RVA: 0x0002E997 File Offset: 0x0002CB97
		public IntPtr WindowHandle { get; private set; }

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x06000C2B RID: 3115 RVA: 0x0002E9A0 File Offset: 0x0002CBA0
		public static bool Running
		{
			get
			{
				return MessageListener._running;
			}
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x0002E9BC File Offset: 0x0002CBBC
		~MessageListener()
		{
			this.Dispose(false);
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x0002E9F0 File Offset: 0x0002CBF0
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x0002EA04 File Offset: 0x0002CC04
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				lock (MessageListener._threadlock)
				{
					MessageListener._listeners.Remove(this.WindowHandle);
					if (MessageListener._listeners.Count == 0)
					{
						CoreNativeMethods.PostMessage(this.WindowHandle, WindowMessage.Destroy, IntPtr.Zero, IntPtr.Zero);
					}
				}
			}
		}

		// Token: 0x04000445 RID: 1093
		public const uint CreateWindowMessage = 1025U;

		// Token: 0x04000446 RID: 1094
		public const uint DestroyWindowMessage = 1026U;

		// Token: 0x04000447 RID: 1095
		public const uint BaseUserMessage = 1029U;

		// Token: 0x04000448 RID: 1096
		private const string MessageWindowClassName = "MessageListenerClass";

		// Token: 0x04000449 RID: 1097
		private static readonly object _threadlock = new object();

		// Token: 0x0400044A RID: 1098
		private static uint _atom;

		// Token: 0x0400044B RID: 1099
		private static Thread _windowThread = null;

		// Token: 0x0400044C RID: 1100
		private static volatile bool _running = false;

		// Token: 0x0400044D RID: 1101
		private static ShellObjectWatcherNativeMethods.WndProcDelegate wndProc = new ShellObjectWatcherNativeMethods.WndProcDelegate(MessageListener.WndProc);

		// Token: 0x0400044E RID: 1102
		private static Dictionary<IntPtr, MessageListener> _listeners = new Dictionary<IntPtr, MessageListener>();

		// Token: 0x0400044F RID: 1103
		private static IntPtr _firstWindowHandle = IntPtr.Zero;

		// Token: 0x04000450 RID: 1104
		private static readonly object _crossThreadWindowLock = new object();

		// Token: 0x04000451 RID: 1105
		private static IntPtr _tempHandle = IntPtr.Zero;
	}
}
