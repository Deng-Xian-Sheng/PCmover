using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	// Token: 0x02000333 RID: 819
	[ComVisible(false)]
	public abstract class IdentityReference
	{
		// Token: 0x060028F2 RID: 10482 RVA: 0x00096FFF File Offset: 0x000951FF
		internal IdentityReference()
		{
		}

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x060028F3 RID: 10483
		public abstract string Value { get; }

		// Token: 0x060028F4 RID: 10484
		public abstract bool IsValidTargetType(Type targetType);

		// Token: 0x060028F5 RID: 10485
		public abstract IdentityReference Translate(Type targetType);

		// Token: 0x060028F6 RID: 10486
		public abstract override bool Equals(object o);

		// Token: 0x060028F7 RID: 10487
		public abstract override int GetHashCode();

		// Token: 0x060028F8 RID: 10488
		public abstract override string ToString();

		// Token: 0x060028F9 RID: 10489 RVA: 0x00097008 File Offset: 0x00095208
		public static bool operator ==(IdentityReference left, IdentityReference right)
		{
			return (left == null && right == null) || (left != null && right != null && left.Equals(right));
		}

		// Token: 0x060028FA RID: 10490 RVA: 0x00097030 File Offset: 0x00095230
		public static bool operator !=(IdentityReference left, IdentityReference right)
		{
			return !(left == right);
		}
	}
}
