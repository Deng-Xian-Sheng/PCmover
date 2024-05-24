using System;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007EC RID: 2028
	public abstract class ChoiceField : FormElement
	{
		// Token: 0x06005268 RID: 21096 RVA: 0x0028D54D File Offset: 0x0028C54D
		protected ChoiceField(string name, float x, float y, float width, float height) : base(name, x, y, width, height)
		{
		}

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x06005269 RID: 21097 RVA: 0x0028D584 File Offset: 0x0028C584
		// (set) Token: 0x0600526A RID: 21098 RVA: 0x0028D59C File Offset: 0x0028C59C
		public Font Font
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

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x0600526B RID: 21099 RVA: 0x0028D5A8 File Offset: 0x0028C5A8
		// (set) Token: 0x0600526C RID: 21100 RVA: 0x0028D5C0 File Offset: 0x0028C5C0
		public float FontSize
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

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x0600526D RID: 21101 RVA: 0x0028D5CC File Offset: 0x0028C5CC
		// (set) Token: 0x0600526E RID: 21102 RVA: 0x0028D5E4 File Offset: 0x0028C5E4
		public bool NoExport
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

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x0600526F RID: 21103 RVA: 0x0028D5F0 File Offset: 0x0028C5F0
		public ChoiceItemList Items
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x04002C0B RID: 11275
		private new Font a = null;

		// Token: 0x04002C0C RID: 11276
		private float b = 0f;

		// Token: 0x04002C0D RID: 11277
		private bool c = false;

		// Token: 0x04002C0E RID: 11278
		private new ChoiceItemList d = new ChoiceItemList();
	}
}
