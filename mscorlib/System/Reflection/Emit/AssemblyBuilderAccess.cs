using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x0200062D RID: 1581
	[ComVisible(true)]
	[Flags]
	[Serializable]
	public enum AssemblyBuilderAccess
	{
		// Token: 0x04001E76 RID: 7798
		Run = 1,
		// Token: 0x04001E77 RID: 7799
		Save = 2,
		// Token: 0x04001E78 RID: 7800
		RunAndSave = 3,
		// Token: 0x04001E79 RID: 7801
		ReflectionOnly = 6,
		// Token: 0x04001E7A RID: 7802
		RunAndCollect = 9
	}
}
