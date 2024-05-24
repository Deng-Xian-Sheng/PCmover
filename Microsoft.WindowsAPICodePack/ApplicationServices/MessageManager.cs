using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x0200003F RID: 63
	internal static class MessageManager
	{
		// Token: 0x06000113 RID: 275 RVA: 0x000048E4 File Offset: 0x00002AE4
		internal static void RegisterPowerEvent(Guid eventId, EventHandler eventToRegister)
		{
			MessageManager.EnsureInitialized();
			MessageManager.window.RegisterPowerEvent(eventId, eventToRegister);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000048FA File Offset: 0x00002AFA
		internal static void UnregisterPowerEvent(Guid eventId, EventHandler eventToUnregister)
		{
			MessageManager.EnsureInitialized();
			MessageManager.window.UnregisterPowerEvent(eventId, eventToUnregister);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00004910 File Offset: 0x00002B10
		private static void EnsureInitialized()
		{
			lock (MessageManager.lockObject)
			{
				if (MessageManager.window == null)
				{
					MessageManager.window = new MessageManager.PowerRegWindow();
				}
			}
		}

		// Token: 0x04000235 RID: 565
		private static object lockObject = new object();

		// Token: 0x04000236 RID: 566
		private static MessageManager.PowerRegWindow window;

		// Token: 0x02000040 RID: 64
		internal class PowerRegWindow : Form
		{
			// Token: 0x06000117 RID: 279 RVA: 0x00004970 File Offset: 0x00002B70
			internal PowerRegWindow()
			{
			}

			// Token: 0x06000118 RID: 280 RVA: 0x00004994 File Offset: 0x00002B94
			internal void RegisterPowerEvent(Guid eventId, EventHandler eventToRegister)
			{
				this.readerWriterLock.AcquireWriterLock(-1);
				if (!this.eventList.Contains(eventId))
				{
					Power.RegisterPowerSettingNotification(base.Handle, eventId);
					ArrayList arrayList = new ArrayList();
					arrayList.Add(eventToRegister);
					this.eventList.Add(eventId, arrayList);
				}
				else
				{
					ArrayList arrayList2 = (ArrayList)this.eventList[eventId];
					arrayList2.Add(eventToRegister);
				}
				this.readerWriterLock.ReleaseWriterLock();
			}

			// Token: 0x06000119 RID: 281 RVA: 0x00004A24 File Offset: 0x00002C24
			internal void UnregisterPowerEvent(Guid eventId, EventHandler eventToUnregister)
			{
				this.readerWriterLock.AcquireWriterLock(-1);
				if (this.eventList.Contains(eventId))
				{
					ArrayList arrayList = (ArrayList)this.eventList[eventId];
					arrayList.Remove(eventToUnregister);
					this.readerWriterLock.ReleaseWriterLock();
					return;
				}
				throw new InvalidOperationException(LocalizedMessages.MessageManagerHandlerNotRegistered);
			}

			// Token: 0x0600011A RID: 282 RVA: 0x00004A94 File Offset: 0x00002C94
			private static void ExecuteEvents(ArrayList eventHandlerList)
			{
				foreach (object obj in eventHandlerList)
				{
					EventHandler eventHandler = (EventHandler)obj;
					eventHandler(null, new EventArgs());
				}
			}

			// Token: 0x0600011B RID: 283 RVA: 0x00004AFC File Offset: 0x00002CFC
			protected override void WndProc(ref Message m)
			{
				if ((long)m.Msg == 536L && (long)((int)m.WParam) == 32787L)
				{
					PowerManagementNativeMethods.PowerBroadcastSetting powerBroadcastSetting = (PowerManagementNativeMethods.PowerBroadcastSetting)Marshal.PtrToStructure(m.LParam, typeof(PowerManagementNativeMethods.PowerBroadcastSetting));
					IntPtr ptr = new IntPtr(m.LParam.ToInt64() + (long)Marshal.SizeOf(powerBroadcastSetting));
					Guid powerSetting = powerBroadcastSetting.PowerSetting;
					if (powerBroadcastSetting.PowerSetting == EventManager.MonitorPowerStatus && powerBroadcastSetting.DataLength == Marshal.SizeOf(typeof(int)))
					{
						int num = (int)Marshal.PtrToStructure(ptr, typeof(int));
						PowerManager.IsMonitorOn = (num != 0);
						EventManager.monitorOnReset.Set();
					}
					if (!EventManager.IsMessageCaught(powerSetting))
					{
						MessageManager.PowerRegWindow.ExecuteEvents((ArrayList)this.eventList[powerSetting]);
					}
				}
				else
				{
					base.WndProc(ref m);
				}
			}

			// Token: 0x04000237 RID: 567
			private Hashtable eventList = new Hashtable();

			// Token: 0x04000238 RID: 568
			private ReaderWriterLock readerWriterLock = new ReaderWriterLock();
		}
	}
}
