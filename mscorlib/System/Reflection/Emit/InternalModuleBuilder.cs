using System;

namespace System.Reflection.Emit
{
	// Token: 0x0200064F RID: 1615
	internal sealed class InternalModuleBuilder : RuntimeModule
	{
		// Token: 0x06004C03 RID: 19459 RVA: 0x00113119 File Offset: 0x00111319
		private InternalModuleBuilder()
		{
		}

		// Token: 0x06004C04 RID: 19460 RVA: 0x00113121 File Offset: 0x00111321
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is InternalModuleBuilder)
			{
				return this == obj;
			}
			return obj.Equals(this);
		}

		// Token: 0x06004C05 RID: 19461 RVA: 0x0011313C File Offset: 0x0011133C
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
