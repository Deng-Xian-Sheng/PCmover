using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000919 RID: 2329
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	public sealed class LCIDConversionAttribute : Attribute
	{
		// Token: 0x06005FFD RID: 24573 RVA: 0x0014B608 File Offset: 0x00149808
		public LCIDConversionAttribute(int lcid)
		{
			this._val = lcid;
		}

		// Token: 0x170010D7 RID: 4311
		// (get) Token: 0x06005FFE RID: 24574 RVA: 0x0014B617 File Offset: 0x00149817
		public int Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A6C RID: 10860
		internal int _val;
	}
}
