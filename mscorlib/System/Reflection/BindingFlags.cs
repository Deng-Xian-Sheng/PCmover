using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005CF RID: 1487
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum BindingFlags
	{
		// Token: 0x04001C29 RID: 7209
		Default = 0,
		// Token: 0x04001C2A RID: 7210
		[__DynamicallyInvokable]
		IgnoreCase = 1,
		// Token: 0x04001C2B RID: 7211
		[__DynamicallyInvokable]
		DeclaredOnly = 2,
		// Token: 0x04001C2C RID: 7212
		[__DynamicallyInvokable]
		Instance = 4,
		// Token: 0x04001C2D RID: 7213
		[__DynamicallyInvokable]
		Static = 8,
		// Token: 0x04001C2E RID: 7214
		[__DynamicallyInvokable]
		Public = 16,
		// Token: 0x04001C2F RID: 7215
		[__DynamicallyInvokable]
		NonPublic = 32,
		// Token: 0x04001C30 RID: 7216
		[__DynamicallyInvokable]
		FlattenHierarchy = 64,
		// Token: 0x04001C31 RID: 7217
		InvokeMethod = 256,
		// Token: 0x04001C32 RID: 7218
		CreateInstance = 512,
		// Token: 0x04001C33 RID: 7219
		GetField = 1024,
		// Token: 0x04001C34 RID: 7220
		SetField = 2048,
		// Token: 0x04001C35 RID: 7221
		GetProperty = 4096,
		// Token: 0x04001C36 RID: 7222
		SetProperty = 8192,
		// Token: 0x04001C37 RID: 7223
		PutDispProperty = 16384,
		// Token: 0x04001C38 RID: 7224
		PutRefDispProperty = 32768,
		// Token: 0x04001C39 RID: 7225
		[__DynamicallyInvokable]
		ExactBinding = 65536,
		// Token: 0x04001C3A RID: 7226
		SuppressChangeType = 131072,
		// Token: 0x04001C3B RID: 7227
		[__DynamicallyInvokable]
		OptionalParamBinding = 262144,
		// Token: 0x04001C3C RID: 7228
		IgnoreReturn = 16777216
	}
}
