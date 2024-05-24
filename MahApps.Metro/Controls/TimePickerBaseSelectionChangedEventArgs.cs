using System;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200008F RID: 143
	public class TimePickerBaseSelectionChangedEventArgs<T> : RoutedEventArgs
	{
		// Token: 0x060007B0 RID: 1968 RVA: 0x0001F594 File Offset: 0x0001D794
		public TimePickerBaseSelectionChangedEventArgs(RoutedEvent eventId, T oldValue, T newValue) : base(eventId)
		{
			this.OldValue = oldValue;
			this.NewValue = newValue;
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060007B1 RID: 1969 RVA: 0x0001F5AB File Offset: 0x0001D7AB
		public T OldValue { get; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060007B2 RID: 1970 RVA: 0x0001F5B3 File Offset: 0x0001D7B3
		public T NewValue { get; }
	}
}
