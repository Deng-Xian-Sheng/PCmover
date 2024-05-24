using System;
using System.Reflection;

namespace System.Runtime.Serialization
{
	// Token: 0x02000737 RID: 1847
	[Serializable]
	internal class MemberHolder
	{
		// Token: 0x060051C1 RID: 20929 RVA: 0x0011FC8D File Offset: 0x0011DE8D
		internal MemberHolder(Type type, StreamingContext ctx)
		{
			this.memberType = type;
			this.context = ctx;
		}

		// Token: 0x060051C2 RID: 20930 RVA: 0x0011FCA3 File Offset: 0x0011DEA3
		public override int GetHashCode()
		{
			return this.memberType.GetHashCode();
		}

		// Token: 0x060051C3 RID: 20931 RVA: 0x0011FCB0 File Offset: 0x0011DEB0
		public override bool Equals(object obj)
		{
			if (!(obj is MemberHolder))
			{
				return false;
			}
			MemberHolder memberHolder = (MemberHolder)obj;
			return memberHolder.memberType == this.memberType && memberHolder.context.State == this.context.State;
		}

		// Token: 0x04002439 RID: 9273
		internal MemberInfo[] members;

		// Token: 0x0400243A RID: 9274
		internal Type memberType;

		// Token: 0x0400243B RID: 9275
		internal StreamingContext context;
	}
}
