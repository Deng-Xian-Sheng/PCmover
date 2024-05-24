using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004E5 RID: 1253
	internal interface IAsyncLocal
	{
		// Token: 0x06003B77 RID: 15223
		[SecurityCritical]
		void OnValueChanged(object previousValue, object currentValue, bool contextChanged);
	}
}
