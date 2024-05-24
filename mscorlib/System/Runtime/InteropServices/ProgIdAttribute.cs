using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200091C RID: 2332
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	[ComVisible(true)]
	public sealed class ProgIdAttribute : Attribute
	{
		// Token: 0x06006001 RID: 24577 RVA: 0x0014B62F File Offset: 0x0014982F
		public ProgIdAttribute(string progId)
		{
			this._val = progId;
		}

		// Token: 0x170010D8 RID: 4312
		// (get) Token: 0x06006002 RID: 24578 RVA: 0x0014B63E File Offset: 0x0014983E
		public string Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A6D RID: 10861
		internal string _val;
	}
}
