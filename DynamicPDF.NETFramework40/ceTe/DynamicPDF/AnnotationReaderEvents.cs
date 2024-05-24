using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000638 RID: 1592
	public class AnnotationReaderEvents
	{
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06003B74 RID: 15220 RVA: 0x001FC61C File Offset: 0x001FB61C
		// (set) Token: 0x06003B75 RID: 15221 RVA: 0x001FC634 File Offset: 0x001FB634
		public OutlineAnnotationAction MouseUp
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

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06003B76 RID: 15222 RVA: 0x001FC640 File Offset: 0x001FB640
		// (set) Token: 0x06003B77 RID: 15223 RVA: 0x001FC658 File Offset: 0x001FB658
		public OutlineAnnotationAction MouseDown
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06003B78 RID: 15224 RVA: 0x001FC664 File Offset: 0x001FB664
		// (set) Token: 0x06003B79 RID: 15225 RVA: 0x001FC67C File Offset: 0x001FB67C
		public OutlineAnnotationAction MouseEnter
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06003B7A RID: 15226 RVA: 0x001FC688 File Offset: 0x001FB688
		// (set) Token: 0x06003B7B RID: 15227 RVA: 0x001FC6A0 File Offset: 0x001FB6A0
		public OutlineAnnotationAction MouseExit
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06003B7C RID: 15228 RVA: 0x001FC6AC File Offset: 0x001FB6AC
		// (set) Token: 0x06003B7D RID: 15229 RVA: 0x001FC6C4 File Offset: 0x001FB6C4
		public OutlineAnnotationAction OnBlur
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06003B7E RID: 15230 RVA: 0x001FC6D0 File Offset: 0x001FB6D0
		// (set) Token: 0x06003B7F RID: 15231 RVA: 0x001FC6E8 File Offset: 0x001FB6E8
		public OutlineAnnotationAction OnFocus
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x04002079 RID: 8313
		private OutlineAnnotationAction a;

		// Token: 0x0400207A RID: 8314
		private OutlineAnnotationAction b;

		// Token: 0x0400207B RID: 8315
		private OutlineAnnotationAction c;

		// Token: 0x0400207C RID: 8316
		private OutlineAnnotationAction d;

		// Token: 0x0400207D RID: 8317
		private OutlineAnnotationAction e;

		// Token: 0x0400207E RID: 8318
		private OutlineAnnotationAction f;
	}
}
