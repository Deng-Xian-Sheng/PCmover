using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200096A RID: 2410
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TypeLibImporterFlags
	{
		// Token: 0x04002B96 RID: 11158
		None = 0,
		// Token: 0x04002B97 RID: 11159
		PrimaryInteropAssembly = 1,
		// Token: 0x04002B98 RID: 11160
		UnsafeInterfaces = 2,
		// Token: 0x04002B99 RID: 11161
		SafeArrayAsSystemArray = 4,
		// Token: 0x04002B9A RID: 11162
		TransformDispRetVals = 8,
		// Token: 0x04002B9B RID: 11163
		PreventClassMembers = 16,
		// Token: 0x04002B9C RID: 11164
		SerializableValueClasses = 32,
		// Token: 0x04002B9D RID: 11165
		ImportAsX86 = 256,
		// Token: 0x04002B9E RID: 11166
		ImportAsX64 = 512,
		// Token: 0x04002B9F RID: 11167
		ImportAsItanium = 1024,
		// Token: 0x04002BA0 RID: 11168
		ImportAsAgnostic = 2048,
		// Token: 0x04002BA1 RID: 11169
		ReflectionOnlyLoading = 4096,
		// Token: 0x04002BA2 RID: 11170
		NoDefineVersionResource = 8192,
		// Token: 0x04002BA3 RID: 11171
		ImportAsArm = 16384
	}
}
