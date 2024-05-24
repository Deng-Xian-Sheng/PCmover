using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000111 RID: 273
	internal class ChangeNotifyEventManager
	{
		// Token: 0x06000C10 RID: 3088 RVA: 0x0002E034 File Offset: 0x0002C234
		public void Register(ShellObjectChangeTypes changeType, Delegate handler)
		{
			Delegate @delegate;
			if (!this._events.TryGetValue(changeType, out @delegate))
			{
				this._events.Add(changeType, handler);
			}
			else
			{
				@delegate = Delegate.Combine(@delegate, handler);
				this._events[changeType] = @delegate;
			}
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x0002E080 File Offset: 0x0002C280
		public void Unregister(ShellObjectChangeTypes changeType, Delegate handler)
		{
			Delegate @delegate;
			if (this._events.TryGetValue(changeType, out @delegate))
			{
				@delegate = Delegate.Remove(@delegate, handler);
				if (@delegate == null)
				{
					this._events.Remove(changeType);
				}
				else
				{
					this._events[changeType] = @delegate;
				}
			}
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x0002E0D9 File Offset: 0x0002C2D9
		public void UnregisterAll()
		{
			this._events.Clear();
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x0002E110 File Offset: 0x0002C310
		public void Invoke(object sender, ShellObjectChangeTypes changeType, EventArgs args)
		{
			changeType &= ShellObjectChangeTypes.AllEventsMask;
			foreach (ShellObjectChangeTypes key in from x in ChangeNotifyEventManager._changeOrder
			where (x & changeType) != ShellObjectChangeTypes.None
			select x)
			{
				Delegate @delegate;
				if (this._events.TryGetValue(key, out @delegate))
				{
					@delegate.DynamicInvoke(new object[]
					{
						sender,
						args
					});
				}
			}
		}

		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x06000C14 RID: 3092 RVA: 0x0002E1E0 File Offset: 0x0002C3E0
		public ShellObjectChangeTypes RegisteredTypes
		{
			get
			{
				return this._events.Keys.Aggregate(ShellObjectChangeTypes.None, (ShellObjectChangeTypes accumulator, ShellObjectChangeTypes changeType) => changeType | accumulator);
			}
		}

		// Token: 0x0400043E RID: 1086
		private static readonly ShellObjectChangeTypes[] _changeOrder = new ShellObjectChangeTypes[]
		{
			ShellObjectChangeTypes.ItemCreate,
			ShellObjectChangeTypes.ItemRename,
			ShellObjectChangeTypes.ItemDelete,
			ShellObjectChangeTypes.AttributesChange,
			ShellObjectChangeTypes.DirectoryCreate,
			ShellObjectChangeTypes.DirectoryDelete,
			ShellObjectChangeTypes.DirectoryContentsUpdate,
			ShellObjectChangeTypes.DirectoryRename,
			ShellObjectChangeTypes.Update,
			ShellObjectChangeTypes.MediaInsert,
			ShellObjectChangeTypes.MediaRemove,
			ShellObjectChangeTypes.DriveAdd,
			ShellObjectChangeTypes.DriveRemove,
			ShellObjectChangeTypes.NetShare,
			ShellObjectChangeTypes.NetUnshare,
			ShellObjectChangeTypes.ServerDisconnect,
			ShellObjectChangeTypes.SystemImageUpdate,
			ShellObjectChangeTypes.AssociationChange,
			ShellObjectChangeTypes.FreeSpace,
			ShellObjectChangeTypes.DiskEventsMask,
			ShellObjectChangeTypes.GlobalEventsMask,
			ShellObjectChangeTypes.AllEventsMask
		};

		// Token: 0x0400043F RID: 1087
		private Dictionary<ShellObjectChangeTypes, Delegate> _events = new Dictionary<ShellObjectChangeTypes, Delegate>();
	}
}
