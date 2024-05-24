using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000004 RID: 4
	public static class EventHandlerExtensionMethods
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00002160 File Offset: 0x00000360
		public static void SafeRaise(this EventHandler eventHandler, object sender)
		{
			if (eventHandler != null)
			{
				eventHandler(sender, EventArgs.Empty);
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002188 File Offset: 0x00000388
		public static void SafeRaise<T>(this EventHandler<T> eventHandler, object sender, T args) where T : EventArgs
		{
			if (eventHandler != null)
			{
				eventHandler(sender, args);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021A9 File Offset: 0x000003A9
		public static void SafeRaise(this EventHandler<EventArgs> eventHandler, object sender)
		{
			eventHandler.SafeRaise(sender, EventArgs.Empty);
		}
	}
}
