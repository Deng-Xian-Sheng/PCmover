using System;
using System.ComponentModel;
using System.Threading;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200011C RID: 284
	public class ShellObjectWatcher : IDisposable
	{
		// Token: 0x06000C50 RID: 3152 RVA: 0x0002F008 File Offset: 0x0002D208
		public ShellObjectWatcher(ShellObject shellObject, bool recursive)
		{
			if (shellObject == null)
			{
				throw new ArgumentNullException("shellObject");
			}
			if (this._context == null)
			{
				this._context = new SynchronizationContext();
				SynchronizationContext.SetSynchronizationContext(this._context);
			}
			this._shellObject = shellObject;
			this._recursive = recursive;
			MessageListenerFilterRegistrationResult messageListenerFilterRegistrationResult = MessageListenerFilter.Register(new Action<WindowMessageEventArgs>(this.OnWindowMessageReceived));
			this._listenerHandle = messageListenerFilterRegistrationResult.WindowHandle;
			this._message = messageListenerFilterRegistrationResult.Message;
		}

		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x06000C51 RID: 3153 RVA: 0x0002F0B0 File Offset: 0x0002D2B0
		// (set) Token: 0x06000C52 RID: 3154 RVA: 0x0002F0CA File Offset: 0x0002D2CA
		public bool Running
		{
			get
			{
				return this._running;
			}
			private set
			{
				this._running = value;
			}
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x0002F0D8 File Offset: 0x0002D2D8
		public void Start()
		{
			if (!this.Running)
			{
				ShellNativeMethods.SHChangeNotifyEntry shchangeNotifyEntry = default(ShellNativeMethods.SHChangeNotifyEntry);
				shchangeNotifyEntry.recursively = this._recursive;
				shchangeNotifyEntry.pIdl = this._shellObject.PIDL;
				this._registrationId = ShellNativeMethods.SHChangeNotifyRegister(this._listenerHandle, ShellNativeMethods.ShellChangeNotifyEventSource.InterruptLevel | ShellNativeMethods.ShellChangeNotifyEventSource.ShellLevel | ShellNativeMethods.ShellChangeNotifyEventSource.NewDelivery, this._manager.RegisteredTypes, this._message, 1, ref shchangeNotifyEntry);
				if (this._registrationId == 0U)
				{
					throw new Win32Exception(LocalizedMessages.ShellObjectWatcherRegisterFailed);
				}
				this.Running = true;
			}
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x0002F16C File Offset: 0x0002D36C
		public void Stop()
		{
			if (this.Running)
			{
				if (this._registrationId > 0U)
				{
					ShellNativeMethods.SHChangeNotifyDeregister(this._registrationId);
					this._registrationId = 0U;
				}
				this.Running = false;
			}
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0002F1D0 File Offset: 0x0002D3D0
		private void OnWindowMessageReceived(WindowMessageEventArgs e)
		{
			if (e.Message.Msg == this._message)
			{
				this._context.Send(delegate(object x)
				{
					this.ProcessChangeNotificationEvent(e);
				}, null);
			}
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0002F23C File Offset: 0x0002D43C
		private void ThrowIfRunning()
		{
			if (this.Running)
			{
				throw new InvalidOperationException(LocalizedMessages.ShellObjectWatcherUnableToChangeEvents);
			}
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x0002F264 File Offset: 0x0002D464
		protected virtual void ProcessChangeNotificationEvent(WindowMessageEventArgs e)
		{
			if (this.Running)
			{
				if (e == null)
				{
					throw new ArgumentNullException("e");
				}
				ChangeNotifyLock changeNotifyLock = new ChangeNotifyLock(e.Message);
				ShellObjectChangeTypes changeType = changeNotifyLock.ChangeType;
				ShellObjectNotificationEventArgs args;
				if (changeType != ShellObjectChangeTypes.ItemRename)
				{
					if (changeType == ShellObjectChangeTypes.SystemImageUpdate)
					{
						args = new SystemImageUpdatedEventArgs(changeNotifyLock);
						goto IL_6B;
					}
					if (changeType != ShellObjectChangeTypes.DirectoryRename)
					{
						args = new ShellObjectChangedEventArgs(changeNotifyLock);
						goto IL_6B;
					}
				}
				args = new ShellObjectRenamedEventArgs(changeNotifyLock);
				IL_6B:
				this._manager.Invoke(this, changeNotifyLock.ChangeType, args);
			}
		}

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000C58 RID: 3160 RVA: 0x0002F2F0 File Offset: 0x0002D4F0
		// (remove) Token: 0x06000C59 RID: 3161 RVA: 0x0002F30C File Offset: 0x0002D50C
		public event EventHandler<ShellObjectNotificationEventArgs> AllEvents
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.AllEventsMask, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.AllEventsMask, value);
			}
		}

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000C5A RID: 3162 RVA: 0x0002F328 File Offset: 0x0002D528
		// (remove) Token: 0x06000C5B RID: 3163 RVA: 0x0002F344 File Offset: 0x0002D544
		public event EventHandler<ShellObjectNotificationEventArgs> GlobalEvents
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.GlobalEventsMask, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.GlobalEventsMask, value);
			}
		}

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000C5C RID: 3164 RVA: 0x0002F360 File Offset: 0x0002D560
		// (remove) Token: 0x06000C5D RID: 3165 RVA: 0x0002F37C File Offset: 0x0002D57C
		public event EventHandler<ShellObjectNotificationEventArgs> DiskEvents
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.DiskEventsMask, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.DiskEventsMask, value);
			}
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000C5E RID: 3166 RVA: 0x0002F398 File Offset: 0x0002D598
		// (remove) Token: 0x06000C5F RID: 3167 RVA: 0x0002F3B0 File Offset: 0x0002D5B0
		public event EventHandler<ShellObjectRenamedEventArgs> ItemRenamed
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.ItemRename, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.ItemRename, value);
			}
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06000C60 RID: 3168 RVA: 0x0002F3C8 File Offset: 0x0002D5C8
		// (remove) Token: 0x06000C61 RID: 3169 RVA: 0x0002F3E0 File Offset: 0x0002D5E0
		public event EventHandler<ShellObjectChangedEventArgs> ItemCreated
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.ItemCreate, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.ItemCreate, value);
			}
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000C62 RID: 3170 RVA: 0x0002F3F8 File Offset: 0x0002D5F8
		// (remove) Token: 0x06000C63 RID: 3171 RVA: 0x0002F410 File Offset: 0x0002D610
		public event EventHandler<ShellObjectChangedEventArgs> ItemDeleted
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.ItemDelete, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.ItemDelete, value);
			}
		}

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06000C64 RID: 3172 RVA: 0x0002F428 File Offset: 0x0002D628
		// (remove) Token: 0x06000C65 RID: 3173 RVA: 0x0002F444 File Offset: 0x0002D644
		public event EventHandler<ShellObjectChangedEventArgs> Updated
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.Update, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.Update, value);
			}
		}

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06000C66 RID: 3174 RVA: 0x0002F460 File Offset: 0x0002D660
		// (remove) Token: 0x06000C67 RID: 3175 RVA: 0x0002F47C File Offset: 0x0002D67C
		public event EventHandler<ShellObjectChangedEventArgs> DirectoryUpdated
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.DirectoryContentsUpdate, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.DirectoryContentsUpdate, value);
			}
		}

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06000C68 RID: 3176 RVA: 0x0002F498 File Offset: 0x0002D698
		// (remove) Token: 0x06000C69 RID: 3177 RVA: 0x0002F4B4 File Offset: 0x0002D6B4
		public event EventHandler<ShellObjectRenamedEventArgs> DirectoryRenamed
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.DirectoryRename, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.DirectoryRename, value);
			}
		}

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06000C6A RID: 3178 RVA: 0x0002F4D0 File Offset: 0x0002D6D0
		// (remove) Token: 0x06000C6B RID: 3179 RVA: 0x0002F4E8 File Offset: 0x0002D6E8
		public event EventHandler<ShellObjectChangedEventArgs> DirectoryCreated
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.DirectoryCreate, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.DirectoryCreate, value);
			}
		}

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000C6C RID: 3180 RVA: 0x0002F500 File Offset: 0x0002D700
		// (remove) Token: 0x06000C6D RID: 3181 RVA: 0x0002F519 File Offset: 0x0002D719
		public event EventHandler<ShellObjectChangedEventArgs> DirectoryDeleted
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.DirectoryDelete, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.DirectoryDelete, value);
			}
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000C6E RID: 3182 RVA: 0x0002F532 File Offset: 0x0002D732
		// (remove) Token: 0x06000C6F RID: 3183 RVA: 0x0002F54B File Offset: 0x0002D74B
		public event EventHandler<ShellObjectChangedEventArgs> MediaInserted
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.MediaInsert, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.MediaInsert, value);
			}
		}

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000C70 RID: 3184 RVA: 0x0002F564 File Offset: 0x0002D764
		// (remove) Token: 0x06000C71 RID: 3185 RVA: 0x0002F57D File Offset: 0x0002D77D
		public event EventHandler<ShellObjectChangedEventArgs> MediaRemoved
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.MediaRemove, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.MediaRemove, value);
			}
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x06000C72 RID: 3186 RVA: 0x0002F596 File Offset: 0x0002D796
		// (remove) Token: 0x06000C73 RID: 3187 RVA: 0x0002F5B2 File Offset: 0x0002D7B2
		public event EventHandler<ShellObjectChangedEventArgs> DriveAdded
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.DriveAdd, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.DriveAdd, value);
			}
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06000C74 RID: 3188 RVA: 0x0002F5CE File Offset: 0x0002D7CE
		// (remove) Token: 0x06000C75 RID: 3189 RVA: 0x0002F5EA File Offset: 0x0002D7EA
		public event EventHandler<ShellObjectChangedEventArgs> DriveRemoved
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.DriveRemove, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.DriveRemove, value);
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06000C76 RID: 3190 RVA: 0x0002F606 File Offset: 0x0002D806
		// (remove) Token: 0x06000C77 RID: 3191 RVA: 0x0002F622 File Offset: 0x0002D822
		public event EventHandler<ShellObjectChangedEventArgs> FolderNetworkShared
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.NetShare, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.NetShare, value);
			}
		}

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06000C78 RID: 3192 RVA: 0x0002F63E File Offset: 0x0002D83E
		// (remove) Token: 0x06000C79 RID: 3193 RVA: 0x0002F65A File Offset: 0x0002D85A
		public event EventHandler<ShellObjectChangedEventArgs> FolderNetworkUnshared
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.NetUnshare, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.NetUnshare, value);
			}
		}

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06000C7A RID: 3194 RVA: 0x0002F676 File Offset: 0x0002D876
		// (remove) Token: 0x06000C7B RID: 3195 RVA: 0x0002F692 File Offset: 0x0002D892
		public event EventHandler<ShellObjectChangedEventArgs> ServerDisconnected
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.ServerDisconnect, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.ServerDisconnect, value);
			}
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000C7C RID: 3196 RVA: 0x0002F6AE File Offset: 0x0002D8AE
		// (remove) Token: 0x06000C7D RID: 3197 RVA: 0x0002F6CA File Offset: 0x0002D8CA
		public event EventHandler<ShellObjectChangedEventArgs> SystemImageChanged
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.SystemImageUpdate, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.SystemImageUpdate, value);
			}
		}

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06000C7E RID: 3198 RVA: 0x0002F6E6 File Offset: 0x0002D8E6
		// (remove) Token: 0x06000C7F RID: 3199 RVA: 0x0002F702 File Offset: 0x0002D902
		public event EventHandler<ShellObjectChangedEventArgs> FreeSpaceChanged
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.FreeSpace, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.FreeSpace, value);
			}
		}

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06000C80 RID: 3200 RVA: 0x0002F71E File Offset: 0x0002D91E
		// (remove) Token: 0x06000C81 RID: 3201 RVA: 0x0002F73A File Offset: 0x0002D93A
		public event EventHandler<ShellObjectChangedEventArgs> FileTypeAssociationChanged
		{
			add
			{
				this.ThrowIfRunning();
				this._manager.Register(ShellObjectChangeTypes.AssociationChange, value);
			}
			remove
			{
				this.ThrowIfRunning();
				this._manager.Unregister(ShellObjectChangeTypes.AssociationChange, value);
			}
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x0002F758 File Offset: 0x0002D958
		protected virtual void Dispose(bool disposing)
		{
			this.Stop();
			this._manager.UnregisterAll();
			if (this._listenerHandle != IntPtr.Zero)
			{
				MessageListenerFilter.Unregister(this._listenerHandle, this._message);
			}
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x0002F7A4 File Offset: 0x0002D9A4
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x0002F7B8 File Offset: 0x0002D9B8
		~ShellObjectWatcher()
		{
			this.Dispose(false);
		}

		// Token: 0x04000461 RID: 1121
		private ShellObject _shellObject;

		// Token: 0x04000462 RID: 1122
		private bool _recursive;

		// Token: 0x04000463 RID: 1123
		private ChangeNotifyEventManager _manager = new ChangeNotifyEventManager();

		// Token: 0x04000464 RID: 1124
		private IntPtr _listenerHandle;

		// Token: 0x04000465 RID: 1125
		private uint _message;

		// Token: 0x04000466 RID: 1126
		private uint _registrationId;

		// Token: 0x04000467 RID: 1127
		private volatile bool _running;

		// Token: 0x04000468 RID: 1128
		private SynchronizationContext _context = SynchronizationContext.Current;
	}
}
