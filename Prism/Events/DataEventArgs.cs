using System;

namespace Prism.Events
{
	// Token: 0x0200000F RID: 15
	public class DataEventArgs<TData> : EventArgs
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00002686 File Offset: 0x00000886
		public DataEventArgs(TData value)
		{
			this._value = value;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002695 File Offset: 0x00000895
		public TData Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x04000016 RID: 22
		private readonly TData _value;
	}
}
