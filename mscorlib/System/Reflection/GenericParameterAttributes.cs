using System;

namespace System.Reflection
{
	// Token: 0x020005E8 RID: 1512
	[Flags]
	[__DynamicallyInvokable]
	public enum GenericParameterAttributes
	{
		// Token: 0x04001CBF RID: 7359
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x04001CC0 RID: 7360
		[__DynamicallyInvokable]
		VarianceMask = 3,
		// Token: 0x04001CC1 RID: 7361
		[__DynamicallyInvokable]
		Covariant = 1,
		// Token: 0x04001CC2 RID: 7362
		[__DynamicallyInvokable]
		Contravariant = 2,
		// Token: 0x04001CC3 RID: 7363
		[__DynamicallyInvokable]
		SpecialConstraintMask = 28,
		// Token: 0x04001CC4 RID: 7364
		[__DynamicallyInvokable]
		ReferenceTypeConstraint = 4,
		// Token: 0x04001CC5 RID: 7365
		[__DynamicallyInvokable]
		NotNullableValueTypeConstraint = 8,
		// Token: 0x04001CC6 RID: 7366
		[__DynamicallyInvokable]
		DefaultConstructorConstraint = 16
	}
}
