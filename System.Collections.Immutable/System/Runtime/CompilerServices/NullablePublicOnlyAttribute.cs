﻿using System;
using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
	// Token: 0x02000006 RID: 6
	[CompilerGenerated]
	[Embedded]
	[AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
	internal sealed class NullablePublicOnlyAttribute : Attribute
	{
		// Token: 0x06000006 RID: 6 RVA: 0x00002096 File Offset: 0x00000296
		public NullablePublicOnlyAttribute(bool A_1)
		{
			this.IncludesInternals = A_1;
		}

		// Token: 0x04000003 RID: 3
		public readonly bool IncludesInternals;
	}
}
