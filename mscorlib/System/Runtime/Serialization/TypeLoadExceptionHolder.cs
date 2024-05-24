using System;

namespace System.Runtime.Serialization
{
	// Token: 0x02000751 RID: 1873
	internal class TypeLoadExceptionHolder
	{
		// Token: 0x060052C5 RID: 21189 RVA: 0x00122ECF File Offset: 0x001210CF
		internal TypeLoadExceptionHolder(string typeName)
		{
			this.m_typeName = typeName;
		}

		// Token: 0x17000DB0 RID: 3504
		// (get) Token: 0x060052C6 RID: 21190 RVA: 0x00122EDE File Offset: 0x001210DE
		internal string TypeName
		{
			get
			{
				return this.m_typeName;
			}
		}

		// Token: 0x040024AD RID: 9389
		private string m_typeName;
	}
}
