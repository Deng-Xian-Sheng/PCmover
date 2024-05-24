using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004E4 RID: 1252
	[__DynamicallyInvokable]
	public sealed class AsyncLocal<T> : IAsyncLocal
	{
		// Token: 0x06003B72 RID: 15218 RVA: 0x000E2373 File Offset: 0x000E0573
		[__DynamicallyInvokable]
		public AsyncLocal()
		{
		}

		// Token: 0x06003B73 RID: 15219 RVA: 0x000E237B File Offset: 0x000E057B
		[SecurityCritical]
		[__DynamicallyInvokable]
		public AsyncLocal(Action<AsyncLocalValueChangedArgs<T>> valueChangedHandler)
		{
			this.m_valueChangedHandler = valueChangedHandler;
		}

		// Token: 0x17000901 RID: 2305
		// (get) Token: 0x06003B74 RID: 15220 RVA: 0x000E238C File Offset: 0x000E058C
		// (set) Token: 0x06003B75 RID: 15221 RVA: 0x000E23B3 File Offset: 0x000E05B3
		[__DynamicallyInvokable]
		public T Value
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				object localValue = ExecutionContext.GetLocalValue(this);
				if (localValue != null)
				{
					return (T)((object)localValue);
				}
				return default(T);
			}
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			set
			{
				ExecutionContext.SetLocalValue(this, value, this.m_valueChangedHandler != null);
			}
		}

		// Token: 0x06003B76 RID: 15222 RVA: 0x000E23CC File Offset: 0x000E05CC
		[SecurityCritical]
		void IAsyncLocal.OnValueChanged(object previousValueObj, object currentValueObj, bool contextChanged)
		{
			T previousValue = (previousValueObj == null) ? default(T) : ((T)((object)previousValueObj));
			T currentValue = (currentValueObj == null) ? default(T) : ((T)((object)currentValueObj));
			this.m_valueChangedHandler(new AsyncLocalValueChangedArgs<T>(previousValue, currentValue, contextChanged));
		}

		// Token: 0x0400195F RID: 6495
		[SecurityCritical]
		private readonly Action<AsyncLocalValueChangedArgs<T>> m_valueChangedHandler;
	}
}
