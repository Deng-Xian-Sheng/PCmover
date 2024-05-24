using System;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Shell.Interop;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000112 RID: 274
	internal class ChangeNotifyLock
	{
		// Token: 0x06000C18 RID: 3096 RVA: 0x0002E2F8 File Offset: 0x0002C4F8
		internal ChangeNotifyLock(Message message)
		{
			IntPtr ptr;
			IntPtr intPtr = ShellNativeMethods.SHChangeNotification_Lock(message.WParam, (int)message.LParam, out ptr, out this._event);
			try
			{
				Trace.TraceInformation("Message: {0}", new object[]
				{
					(ShellObjectChangeTypes)this._event
				});
				ShellNativeMethods.ShellNotifyStruct shellNotifyStruct = ptr.MarshalAs<ShellNativeMethods.ShellNotifyStruct>();
				Guid guid = new Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93");
				if (shellNotifyStruct.item1 != IntPtr.Zero && (this._event & 32768U) == 0U)
				{
					IShellItem2 shellItem;
					if (CoreErrorHelper.Succeeded(ShellNativeMethods.SHCreateItemFromIDList(shellNotifyStruct.item1, ref guid, out shellItem)))
					{
						string text;
						shellItem.GetDisplayName(ShellNativeMethods.ShellItemDesignNameOptions.FileSystemPath, out text);
						this.ItemName = text;
						Trace.TraceInformation("Item1: {0}", new object[]
						{
							this.ItemName
						});
					}
				}
				else
				{
					this.ImageIndex = shellNotifyStruct.item1.ToInt32();
				}
				if (shellNotifyStruct.item2 != IntPtr.Zero)
				{
					IShellItem2 shellItem;
					if (CoreErrorHelper.Succeeded(ShellNativeMethods.SHCreateItemFromIDList(shellNotifyStruct.item2, ref guid, out shellItem)))
					{
						string text;
						shellItem.GetDisplayName(ShellNativeMethods.ShellItemDesignNameOptions.FileSystemPath, out text);
						this.ItemName2 = text;
						Trace.TraceInformation("Item2: {0}", new object[]
						{
							this.ItemName2
						});
					}
				}
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					ShellNativeMethods.SHChangeNotification_Unlock(intPtr);
				}
			}
		}

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x06000C19 RID: 3097 RVA: 0x0002E4C8 File Offset: 0x0002C6C8
		public bool FromSystemInterrupt
		{
			get
			{
				return (this._event & 2147483648U) != 0U;
			}
		}

		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x06000C1A RID: 3098 RVA: 0x0002E4EC File Offset: 0x0002C6EC
		// (set) Token: 0x06000C1B RID: 3099 RVA: 0x0002E503 File Offset: 0x0002C703
		public int ImageIndex { get; private set; }

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x06000C1C RID: 3100 RVA: 0x0002E50C File Offset: 0x0002C70C
		// (set) Token: 0x06000C1D RID: 3101 RVA: 0x0002E523 File Offset: 0x0002C723
		public string ItemName { get; private set; }

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x0002E52C File Offset: 0x0002C72C
		// (set) Token: 0x06000C1F RID: 3103 RVA: 0x0002E543 File Offset: 0x0002C743
		public string ItemName2 { get; private set; }

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x06000C20 RID: 3104 RVA: 0x0002E54C File Offset: 0x0002C74C
		public ShellObjectChangeTypes ChangeType
		{
			get
			{
				return (ShellObjectChangeTypes)this._event;
			}
		}

		// Token: 0x04000441 RID: 1089
		private uint _event = 0U;
	}
}
