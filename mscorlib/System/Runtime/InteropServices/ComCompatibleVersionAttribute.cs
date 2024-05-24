using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200093C RID: 2364
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	public sealed class ComCompatibleVersionAttribute : Attribute
	{
		// Token: 0x06006052 RID: 24658 RVA: 0x0014BE5C File Offset: 0x0014A05C
		public ComCompatibleVersionAttribute(int major, int minor, int build, int revision)
		{
			this._major = major;
			this._minor = minor;
			this._build = build;
			this._revision = revision;
		}

		// Token: 0x170010EE RID: 4334
		// (get) Token: 0x06006053 RID: 24659 RVA: 0x0014BE81 File Offset: 0x0014A081
		public int MajorVersion
		{
			get
			{
				return this._major;
			}
		}

		// Token: 0x170010EF RID: 4335
		// (get) Token: 0x06006054 RID: 24660 RVA: 0x0014BE89 File Offset: 0x0014A089
		public int MinorVersion
		{
			get
			{
				return this._minor;
			}
		}

		// Token: 0x170010F0 RID: 4336
		// (get) Token: 0x06006055 RID: 24661 RVA: 0x0014BE91 File Offset: 0x0014A091
		public int BuildNumber
		{
			get
			{
				return this._build;
			}
		}

		// Token: 0x170010F1 RID: 4337
		// (get) Token: 0x06006056 RID: 24662 RVA: 0x0014BE99 File Offset: 0x0014A099
		public int RevisionNumber
		{
			get
			{
				return this._revision;
			}
		}

		// Token: 0x04002B23 RID: 11043
		internal int _major;

		// Token: 0x04002B24 RID: 11044
		internal int _minor;

		// Token: 0x04002B25 RID: 11045
		internal int _build;

		// Token: 0x04002B26 RID: 11046
		internal int _revision;
	}
}
