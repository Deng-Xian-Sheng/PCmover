using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000637 RID: 1591
	public abstract class OutlineAnnotationAction : Action
	{
		// Token: 0x06003B71 RID: 15217 RVA: 0x001FC5EC File Offset: 0x001FB5EC
		internal OutlineAnnotationAction()
		{
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06003B72 RID: 15218 RVA: 0x001FC5F8 File Offset: 0x001FB5F8
		// (set) Token: 0x06003B73 RID: 15219 RVA: 0x001FC610 File Offset: 0x001FB610
		public OutlineAnnotationAction NextAction
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x04002078 RID: 8312
		private new OutlineAnnotationAction a;
	}
}
