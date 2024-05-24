using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x02000738 RID: 1848
	[AttributeUsage(AttributeTargets.Field, Inherited = false)]
	[ComVisible(true)]
	public sealed class OptionalFieldAttribute : Attribute
	{
		// Token: 0x17000D74 RID: 3444
		// (get) Token: 0x060051C5 RID: 20933 RVA: 0x0011FD06 File Offset: 0x0011DF06
		// (set) Token: 0x060051C6 RID: 20934 RVA: 0x0011FD0E File Offset: 0x0011DF0E
		public int VersionAdded
		{
			get
			{
				return this.versionAdded;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentException(Environment.GetResourceString("Serialization_OptionalFieldVersionValue"));
				}
				this.versionAdded = value;
			}
		}

		// Token: 0x0400243C RID: 9276
		private int versionAdded = 1;
	}
}
