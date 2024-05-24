using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200093B RID: 2363
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	public sealed class TypeLibVersionAttribute : Attribute
	{
		// Token: 0x0600604F RID: 24655 RVA: 0x0014BE36 File Offset: 0x0014A036
		public TypeLibVersionAttribute(int major, int minor)
		{
			this._major = major;
			this._minor = minor;
		}

		// Token: 0x170010EC RID: 4332
		// (get) Token: 0x06006050 RID: 24656 RVA: 0x0014BE4C File Offset: 0x0014A04C
		public int MajorVersion
		{
			get
			{
				return this._major;
			}
		}

		// Token: 0x170010ED RID: 4333
		// (get) Token: 0x06006051 RID: 24657 RVA: 0x0014BE54 File Offset: 0x0014A054
		public int MinorVersion
		{
			get
			{
				return this._minor;
			}
		}

		// Token: 0x04002B21 RID: 11041
		internal int _major;

		// Token: 0x04002B22 RID: 11042
		internal int _minor;
	}
}
