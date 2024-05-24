using System;

namespace Prism.Regions
{
	// Token: 0x02000038 RID: 56
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class ViewSortHintAttribute : Attribute
	{
		// Token: 0x0600017E RID: 382 RVA: 0x00004DCA File Offset: 0x00002FCA
		public ViewSortHintAttribute(string hint)
		{
			this.Hint = hint;
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00004DD9 File Offset: 0x00002FD9
		// (set) Token: 0x06000180 RID: 384 RVA: 0x00004DE1 File Offset: 0x00002FE1
		public string Hint { get; private set; }
	}
}
