﻿using System;

namespace System.Diagnostics.CodeAnalysis
{
	// Token: 0x0200000C RID: 12
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
	internal sealed class NotNullAttribute : Attribute
	{
	}
}
