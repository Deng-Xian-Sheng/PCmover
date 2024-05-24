using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200091D RID: 2333
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	public sealed class ImportedFromTypeLibAttribute : Attribute
	{
		// Token: 0x06006003 RID: 24579 RVA: 0x0014B646 File Offset: 0x00149846
		public ImportedFromTypeLibAttribute(string tlbFile)
		{
			this._val = tlbFile;
		}

		// Token: 0x170010D9 RID: 4313
		// (get) Token: 0x06006004 RID: 24580 RVA: 0x0014B655 File Offset: 0x00149855
		public string Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A6E RID: 10862
		internal string _val;
	}
}
