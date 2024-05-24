using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000931 RID: 2353
	[Flags]
	[__DynamicallyInvokable]
	public enum DllImportSearchPath
	{
		// Token: 0x04002B03 RID: 11011
		[__DynamicallyInvokable]
		UseDllDirectoryForDependencies = 256,
		// Token: 0x04002B04 RID: 11012
		[__DynamicallyInvokable]
		ApplicationDirectory = 512,
		// Token: 0x04002B05 RID: 11013
		[__DynamicallyInvokable]
		UserDirectories = 1024,
		// Token: 0x04002B06 RID: 11014
		[__DynamicallyInvokable]
		System32 = 2048,
		// Token: 0x04002B07 RID: 11015
		[__DynamicallyInvokable]
		SafeDirectories = 4096,
		// Token: 0x04002B08 RID: 11016
		[__DynamicallyInvokable]
		AssemblyDirectory = 2,
		// Token: 0x04002B09 RID: 11017
		[__DynamicallyInvokable]
		LegacyBehavior = 0
	}
}
