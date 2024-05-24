using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x0200060A RID: 1546
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum PortableExecutableKinds
	{
		// Token: 0x04001DA8 RID: 7592
		NotAPortableExecutableImage = 0,
		// Token: 0x04001DA9 RID: 7593
		ILOnly = 1,
		// Token: 0x04001DAA RID: 7594
		Required32Bit = 2,
		// Token: 0x04001DAB RID: 7595
		PE32Plus = 4,
		// Token: 0x04001DAC RID: 7596
		Unmanaged32Bit = 8,
		// Token: 0x04001DAD RID: 7597
		[ComVisible(false)]
		Preferred32Bit = 16
	}
}
