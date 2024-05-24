using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000115 RID: 277
	internal static class MessageListenerFilter
	{
		// Token: 0x06000C33 RID: 3123 RVA: 0x0002EB50 File Offset: 0x0002CD50
		public static MessageListenerFilterRegistrationResult Register(Action<WindowMessageEventArgs> callback)
		{
			MessageListenerFilterRegistrationResult result;
			lock (MessageListenerFilter._registerLock)
			{
				uint message = 0U;
				MessageListenerFilter.RegisteredListener registeredListener = MessageListenerFilter._packages.FirstOrDefault((MessageListenerFilter.RegisteredListener x) => x.TryRegister(callback, out message));
				if (registeredListener == null)
				{
					registeredListener = new MessageListenerFilter.RegisteredListener();
					if (!registeredListener.TryRegister(callback, out message))
					{
						throw new ShellException(LocalizedMessages.MessageListenerFilterUnableToRegister);
					}
					MessageListenerFilter._packages.Add(registeredListener);
				}
				result = new MessageListenerFilterRegistrationResult(registeredListener.Listener.WindowHandle, message);
			}
			return result;
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x0002EC50 File Offset: 0x0002CE50
		public static void Unregister(IntPtr listenerHandle, uint message)
		{
			lock (MessageListenerFilter._registerLock)
			{
				MessageListenerFilter.RegisteredListener registeredListener = MessageListenerFilter._packages.FirstOrDefault((MessageListenerFilter.RegisteredListener x) => x.Listener.WindowHandle == listenerHandle);
				if (registeredListener == null || !registeredListener.Callbacks.Remove(message))
				{
					throw new ArgumentException(LocalizedMessages.MessageListenerFilterUnknownListenerHandle);
				}
				if (registeredListener.Callbacks.Count == 0)
				{
					registeredListener.Listener.Dispose();
					MessageListenerFilter._packages.Remove(registeredListener);
				}
			}
		}

		// Token: 0x04000455 RID: 1109
		private static readonly object _registerLock = new object();

		// Token: 0x04000456 RID: 1110
		private static List<MessageListenerFilter.RegisteredListener> _packages = new List<MessageListenerFilter.RegisteredListener>();

		// Token: 0x02000116 RID: 278
		private class RegisteredListener
		{
			// Token: 0x170007B0 RID: 1968
			// (get) Token: 0x06000C36 RID: 3126 RVA: 0x0002ED24 File Offset: 0x0002CF24
			// (set) Token: 0x06000C37 RID: 3127 RVA: 0x0002ED3B File Offset: 0x0002CF3B
			public Dictionary<uint, Action<WindowMessageEventArgs>> Callbacks { get; private set; }

			// Token: 0x170007B1 RID: 1969
			// (get) Token: 0x06000C38 RID: 3128 RVA: 0x0002ED44 File Offset: 0x0002CF44
			// (set) Token: 0x06000C39 RID: 3129 RVA: 0x0002ED5B File Offset: 0x0002CF5B
			public MessageListener Listener { get; private set; }

			// Token: 0x06000C3A RID: 3130 RVA: 0x0002ED64 File Offset: 0x0002CF64
			public RegisteredListener()
			{
				this.Callbacks = new Dictionary<uint, Action<WindowMessageEventArgs>>();
				this.Listener = new MessageListener();
				this.Listener.MessageReceived += this.MessageReceived;
			}

			// Token: 0x06000C3B RID: 3131 RVA: 0x0002EDB8 File Offset: 0x0002CFB8
			private void MessageReceived(object sender, WindowMessageEventArgs e)
			{
				Action<WindowMessageEventArgs> action;
				if (this.Callbacks.TryGetValue(e.Message.Msg, out action))
				{
					action(e);
				}
			}

			// Token: 0x06000C3C RID: 3132 RVA: 0x0002EDF4 File Offset: 0x0002CFF4
			public bool TryRegister(Action<WindowMessageEventArgs> callback, out uint message)
			{
				message = 0U;
				if ((long)this.Callbacks.Count < 64506L)
				{
					for (uint num = this._lastMessage + 1U; num != this._lastMessage; num += 1U)
					{
						if (num > 65535U)
						{
							num = 1029U;
						}
						if (!this.Callbacks.ContainsKey(num))
						{
							this._lastMessage = (message = num);
							this.Callbacks.Add(num, callback);
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x04000457 RID: 1111
			private uint _lastMessage = 1029U;
		}
	}
}
