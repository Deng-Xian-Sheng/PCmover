using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000938 RID: 2360
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
	[ComVisible(true)]
	public sealed class PrimaryInteropAssemblyAttribute : Attribute
	{
		// Token: 0x06006047 RID: 24647 RVA: 0x0014BDD3 File Offset: 0x00149FD3
		public PrimaryInteropAssemblyAttribute(int major, int minor)
		{
			this._major = major;
			this._minor = minor;
		}

		// Token: 0x170010E7 RID: 4327
		// (get) Token: 0x06006048 RID: 24648 RVA: 0x0014BDE9 File Offset: 0x00149FE9
		public int MajorVersion
		{
			get
			{
				return this._major;
			}
		}

		// Token: 0x170010E8 RID: 4328
		// (get) Token: 0x06006049 RID: 24649 RVA: 0x0014BDF1 File Offset: 0x00149FF1
		public int MinorVersion
		{
			get
			{
				return this._minor;
			}
		}

		// Token: 0x04002B1C RID: 11036
		internal int _major;

		// Token: 0x04002B1D RID: 11037
		internal int _minor;
	}
}
