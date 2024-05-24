using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A4C RID: 2636
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum VARFLAGS : short
	{
		// Token: 0x04002DED RID: 11757
		[__DynamicallyInvokable]
		VARFLAG_FREADONLY = 1,
		// Token: 0x04002DEE RID: 11758
		[__DynamicallyInvokable]
		VARFLAG_FSOURCE = 2,
		// Token: 0x04002DEF RID: 11759
		[__DynamicallyInvokable]
		VARFLAG_FBINDABLE = 4,
		// Token: 0x04002DF0 RID: 11760
		[__DynamicallyInvokable]
		VARFLAG_FREQUESTEDIT = 8,
		// Token: 0x04002DF1 RID: 11761
		[__DynamicallyInvokable]
		VARFLAG_FDISPLAYBIND = 16,
		// Token: 0x04002DF2 RID: 11762
		[__DynamicallyInvokable]
		VARFLAG_FDEFAULTBIND = 32,
		// Token: 0x04002DF3 RID: 11763
		[__DynamicallyInvokable]
		VARFLAG_FHIDDEN = 64,
		// Token: 0x04002DF4 RID: 11764
		[__DynamicallyInvokable]
		VARFLAG_FRESTRICTED = 128,
		// Token: 0x04002DF5 RID: 11765
		[__DynamicallyInvokable]
		VARFLAG_FDEFAULTCOLLELEM = 256,
		// Token: 0x04002DF6 RID: 11766
		[__DynamicallyInvokable]
		VARFLAG_FUIDEFAULT = 512,
		// Token: 0x04002DF7 RID: 11767
		[__DynamicallyInvokable]
		VARFLAG_FNONBROWSABLE = 1024,
		// Token: 0x04002DF8 RID: 11768
		[__DynamicallyInvokable]
		VARFLAG_FREPLACEABLE = 2048,
		// Token: 0x04002DF9 RID: 11769
		[__DynamicallyInvokable]
		VARFLAG_FIMMEDIATEBIND = 4096
	}
}
