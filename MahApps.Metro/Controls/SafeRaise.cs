using System;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000080 RID: 128
	internal static class SafeRaise
	{
		// Token: 0x060006B9 RID: 1721 RVA: 0x0001C063 File Offset: 0x0001A263
		public static void Raise(EventHandler eventToRaise, object sender)
		{
			if (eventToRaise != null)
			{
				eventToRaise(sender, EventArgs.Empty);
			}
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0001C074 File Offset: 0x0001A274
		public static void Raise(EventHandler<EventArgs> eventToRaise, object sender)
		{
			SafeRaise.Raise<EventArgs>(eventToRaise, sender, EventArgs.Empty);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0001C082 File Offset: 0x0001A282
		public static void Raise<T>(EventHandler<T> eventToRaise, object sender, T args) where T : EventArgs
		{
			if (eventToRaise != null)
			{
				eventToRaise(sender, args);
			}
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x0001C08F File Offset: 0x0001A28F
		public static void Raise<T>(EventHandler<T> eventToRaise, object sender, SafeRaise.GetEventArgs<T> getEventArgs) where T : EventArgs
		{
			if (eventToRaise != null)
			{
				eventToRaise(sender, getEventArgs());
			}
		}

		// Token: 0x02000105 RID: 261
		// (Invoke) Token: 0x06000B32 RID: 2866
		public delegate T GetEventArgs<T>() where T : EventArgs;
	}
}
