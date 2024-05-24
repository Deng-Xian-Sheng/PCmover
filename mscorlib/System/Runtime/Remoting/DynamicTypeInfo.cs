using System;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007B8 RID: 1976
	[Serializable]
	internal class DynamicTypeInfo : TypeInfo
	{
		// Token: 0x06005594 RID: 21908 RVA: 0x0012FF87 File Offset: 0x0012E187
		[SecurityCritical]
		internal DynamicTypeInfo(RuntimeType typeOfObj) : base(typeOfObj)
		{
		}

		// Token: 0x06005595 RID: 21909 RVA: 0x0012FF90 File Offset: 0x0012E190
		[SecurityCritical]
		public override bool CanCastTo(Type castType, object o)
		{
			return ((MarshalByRefObject)o).IsInstanceOfType(castType);
		}
	}
}
