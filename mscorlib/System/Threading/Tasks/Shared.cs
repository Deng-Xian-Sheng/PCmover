using System;

namespace System.Threading.Tasks
{
	// Token: 0x0200055B RID: 1371
	internal class Shared<T>
	{
		// Token: 0x0600406B RID: 16491 RVA: 0x000F0539 File Offset: 0x000EE739
		internal Shared(T value)
		{
			this.Value = value;
		}

		// Token: 0x04001AE6 RID: 6886
		internal T Value;
	}
}
