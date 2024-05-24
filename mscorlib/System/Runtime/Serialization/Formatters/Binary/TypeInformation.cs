using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x020007A4 RID: 1956
	internal sealed class TypeInformation
	{
		// Token: 0x17000DE0 RID: 3552
		// (get) Token: 0x060054E7 RID: 21735 RVA: 0x0012DF6A File Offset: 0x0012C16A
		internal string FullTypeName
		{
			get
			{
				return this.fullTypeName;
			}
		}

		// Token: 0x17000DE1 RID: 3553
		// (get) Token: 0x060054E8 RID: 21736 RVA: 0x0012DF72 File Offset: 0x0012C172
		internal string AssemblyString
		{
			get
			{
				return this.assemblyString;
			}
		}

		// Token: 0x17000DE2 RID: 3554
		// (get) Token: 0x060054E9 RID: 21737 RVA: 0x0012DF7A File Offset: 0x0012C17A
		internal bool HasTypeForwardedFrom
		{
			get
			{
				return this.hasTypeForwardedFrom;
			}
		}

		// Token: 0x060054EA RID: 21738 RVA: 0x0012DF82 File Offset: 0x0012C182
		internal TypeInformation(string fullTypeName, string assemblyString, bool hasTypeForwardedFrom)
		{
			this.fullTypeName = fullTypeName;
			this.assemblyString = assemblyString;
			this.hasTypeForwardedFrom = hasTypeForwardedFrom;
		}

		// Token: 0x04002707 RID: 9991
		private string fullTypeName;

		// Token: 0x04002708 RID: 9992
		private string assemblyString;

		// Token: 0x04002709 RID: 9993
		private bool hasTypeForwardedFrom;
	}
}
