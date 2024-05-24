using System;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000738 RID: 1848
	public class OrderedList : List
	{
		// Token: 0x06004A51 RID: 19025 RVA: 0x0025F39C File Offset: 0x0025E39C
		public OrderedList(float x, float y, float width, float height) : base(x, y, width, height)
		{
			this.a = new OrderedSubList(width, height, Font.Helvetica, 12f, this.b, this.c);
			base.a(this.a);
		}

		// Token: 0x06004A52 RID: 19026 RVA: 0x0025F404 File Offset: 0x0025E404
		internal OrderedList(float A_0, float A_1, float A_2, float A_3, ae7 A_4, OrderedSubList A_5) : base(A_0, A_1, A_2, A_3)
		{
			this.a = A_5;
			base.a(this.a);
			this.e = A_4;
			base.a(A_4);
		}

		// Token: 0x06004A53 RID: 19027 RVA: 0x0025F464 File Offset: 0x0025E464
		public OrderedList(float x, float y, float width, float height, Font font, float fontSize, NumberingStyle nStyle) : base(x, y, width, height)
		{
			this.b = nStyle;
			this.a = new OrderedSubList(width, height, font, fontSize, nStyle, this.c);
			base.a(this.a);
		}

		// Token: 0x06004A54 RID: 19028 RVA: 0x0025F4CC File Offset: 0x0025E4CC
		public OrderedList(float x, float y, float width, float height, Font font, float fontSize) : base(x, y, width, height)
		{
			this.a = new OrderedSubList(width, height, font, fontSize, this.b, this.c);
			base.a(this.a);
		}

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x06004A56 RID: 19030 RVA: 0x0025F540 File Offset: 0x0025E540
		// (set) Token: 0x06004A55 RID: 19029 RVA: 0x0025F52E File Offset: 0x0025E52E
		public string BulletPrefix
		{
			get
			{
				return this.a.BulletPrefix;
			}
			set
			{
				this.a.BulletPrefix = value;
			}
		}

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x06004A58 RID: 19032 RVA: 0x0025F570 File Offset: 0x0025E570
		// (set) Token: 0x06004A57 RID: 19031 RVA: 0x0025F55D File Offset: 0x0025E55D
		public string BulletSuffix
		{
			get
			{
				return this.a.BulletSuffix;
			}
			set
			{
				this.a.BulletSuffix = value;
			}
		}

		// Token: 0x06004A59 RID: 19033 RVA: 0x0025F590 File Offset: 0x0025E590
		public float GetRequiredHeight()
		{
			ListItem listItem = this.a.aa();
			listItem.a(true);
			float num = this.a.a(this.e);
			if (this.e != null)
			{
				this.e.d();
			}
			return num + 0.001f;
		}

		// Token: 0x06004A5A RID: 19034 RVA: 0x0025F5E8 File Offset: 0x0025E5E8
		public OrderedList GetOverFlowList()
		{
			return this.GetOverFlowList(base.X, base.Y);
		}

		// Token: 0x06004A5B RID: 19035 RVA: 0x0025F60C File Offset: 0x0025E60C
		public OrderedList GetOverFlowList(float x, float y)
		{
			OrderedList result;
			if (this.a.Items.Count > 0)
			{
				ListItem listItem = this.a.Items[0];
				if (listItem.aa() >= 1)
				{
					this.d = new ae7();
					this.a.c(this.Height);
					this.a.a(this.e, this.d, this.Height);
					this.d = this.a.ab();
					if (this.e != null)
					{
						this.e.d();
					}
					this.d.d();
					if (this.d.a() >= 1)
					{
						OrderedList orderedList = new OrderedList(x, y, base.Width, this.Height, this.d, this.a);
						orderedList.a(base.a());
						result = orderedList;
					}
					else
					{
						result = null;
					}
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x04002863 RID: 10339
		private new OrderedSubList a;

		// Token: 0x04002864 RID: 10340
		private NumberingStyle b = NumberingStyle.Numeric;

		// Token: 0x04002865 RID: 10341
		private bool c = false;

		// Token: 0x04002866 RID: 10342
		private new ae7 d = null;

		// Token: 0x04002867 RID: 10343
		private ae7 e = null;
	}
}
