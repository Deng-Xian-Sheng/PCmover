using System;

namespace System.Threading
{
	// Token: 0x020004E6 RID: 1254
	[__DynamicallyInvokable]
	public struct AsyncLocalValueChangedArgs<T>
	{
		// Token: 0x17000902 RID: 2306
		// (get) Token: 0x06003B78 RID: 15224 RVA: 0x000E2416 File Offset: 0x000E0616
		// (set) Token: 0x06003B79 RID: 15225 RVA: 0x000E241E File Offset: 0x000E061E
		[__DynamicallyInvokable]
		public T PreviousValue { [__DynamicallyInvokable] get; private set; }

		// Token: 0x17000903 RID: 2307
		// (get) Token: 0x06003B7A RID: 15226 RVA: 0x000E2427 File Offset: 0x000E0627
		// (set) Token: 0x06003B7B RID: 15227 RVA: 0x000E242F File Offset: 0x000E062F
		[__DynamicallyInvokable]
		public T CurrentValue { [__DynamicallyInvokable] get; private set; }

		// Token: 0x17000904 RID: 2308
		// (get) Token: 0x06003B7C RID: 15228 RVA: 0x000E2438 File Offset: 0x000E0638
		// (set) Token: 0x06003B7D RID: 15229 RVA: 0x000E2440 File Offset: 0x000E0640
		[__DynamicallyInvokable]
		public bool ThreadContextChanged { [__DynamicallyInvokable] get; private set; }

		// Token: 0x06003B7E RID: 15230 RVA: 0x000E2449 File Offset: 0x000E0649
		internal AsyncLocalValueChangedArgs(T previousValue, T currentValue, bool contextChanged)
		{
			this = default(AsyncLocalValueChangedArgs<T>);
			this.PreviousValue = previousValue;
			this.CurrentValue = currentValue;
			this.ThreadContextChanged = contextChanged;
		}
	}
}
