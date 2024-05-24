using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x02000741 RID: 1857
	[ComVisible(true)]
	public struct SerializationEntry
	{
		// Token: 0x17000D87 RID: 3463
		// (get) Token: 0x0600521D RID: 21021 RVA: 0x001209B6 File Offset: 0x0011EBB6
		public object Value
		{
			get
			{
				return this.m_value;
			}
		}

		// Token: 0x17000D88 RID: 3464
		// (get) Token: 0x0600521E RID: 21022 RVA: 0x001209BE File Offset: 0x0011EBBE
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x17000D89 RID: 3465
		// (get) Token: 0x0600521F RID: 21023 RVA: 0x001209C6 File Offset: 0x0011EBC6
		public Type ObjectType
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x06005220 RID: 21024 RVA: 0x001209CE File Offset: 0x0011EBCE
		internal SerializationEntry(string entryName, object entryValue, Type entryType)
		{
			this.m_value = entryValue;
			this.m_name = entryName;
			this.m_type = entryType;
		}

		// Token: 0x04002451 RID: 9297
		private Type m_type;

		// Token: 0x04002452 RID: 9298
		private object m_value;

		// Token: 0x04002453 RID: 9299
		private string m_name;
	}
}
