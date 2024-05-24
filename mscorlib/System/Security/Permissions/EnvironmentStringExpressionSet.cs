using System;
using System.Security.Util;

namespace System.Security.Permissions
{
	// Token: 0x020002DC RID: 732
	[Serializable]
	internal class EnvironmentStringExpressionSet : StringExpressionSet
	{
		// Token: 0x060025AC RID: 9644 RVA: 0x000895B3 File Offset: 0x000877B3
		public EnvironmentStringExpressionSet() : base(true, null, false)
		{
		}

		// Token: 0x060025AD RID: 9645 RVA: 0x000895BE File Offset: 0x000877BE
		public EnvironmentStringExpressionSet(string str) : base(true, str, false)
		{
		}

		// Token: 0x060025AE RID: 9646 RVA: 0x000895C9 File Offset: 0x000877C9
		protected override StringExpressionSet CreateNewEmpty()
		{
			return new EnvironmentStringExpressionSet();
		}

		// Token: 0x060025AF RID: 9647 RVA: 0x000895D0 File Offset: 0x000877D0
		protected override bool StringSubsetString(string left, string right, bool ignoreCase)
		{
			if (!ignoreCase)
			{
				return string.Compare(left, right, StringComparison.Ordinal) == 0;
			}
			return string.Compare(left, right, StringComparison.OrdinalIgnoreCase) == 0;
		}

		// Token: 0x060025B0 RID: 9648 RVA: 0x000895EC File Offset: 0x000877EC
		protected override string ProcessWholeString(string str)
		{
			return str;
		}

		// Token: 0x060025B1 RID: 9649 RVA: 0x000895EF File Offset: 0x000877EF
		protected override string ProcessSingleString(string str)
		{
			return str;
		}

		// Token: 0x060025B2 RID: 9650 RVA: 0x000895F2 File Offset: 0x000877F2
		[SecuritySafeCritical]
		public override string ToString()
		{
			return base.UnsafeToString();
		}
	}
}
