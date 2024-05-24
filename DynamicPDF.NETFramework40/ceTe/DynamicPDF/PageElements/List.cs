using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000732 RID: 1842
	public class List : RotatingPageElement, IArea, ICoordinate
	{
		// Token: 0x06004997 RID: 18839 RVA: 0x0025B423 File Offset: 0x0025A423
		internal List(float A_0, float A_1, float A_2, float A_3) : base(A_0, A_1, A_3)
		{
			this.a = A_2;
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06004998 RID: 18840 RVA: 0x0025B440 File Offset: 0x0025A440
		// (set) Token: 0x06004999 RID: 18841 RVA: 0x0025B45D File Offset: 0x0025A45D
		public float ListItemTopMargin
		{
			get
			{
				return this.b.ListItemTopMargin;
			}
			set
			{
				this.b.ListItemTopMargin = value;
			}
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x0600499A RID: 18842 RVA: 0x0025B470 File Offset: 0x0025A470
		// (set) Token: 0x0600499B RID: 18843 RVA: 0x0025B48D File Offset: 0x0025A48D
		public float ListItemBottomMargin
		{
			get
			{
				return this.b.ListItemBottomMargin;
			}
			set
			{
				this.b.ListItemBottomMargin = value;
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x0600499C RID: 18844 RVA: 0x0025B4A0 File Offset: 0x0025A4A0
		// (set) Token: 0x0600499D RID: 18845 RVA: 0x0025B4BD File Offset: 0x0025A4BD
		public bool StrikeThrough
		{
			get
			{
				return this.b.StrikeThrough;
			}
			set
			{
				this.b.StrikeThrough = value;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x0600499E RID: 18846 RVA: 0x0025B4D0 File Offset: 0x0025A4D0
		// (set) Token: 0x0600499F RID: 18847 RVA: 0x0025B4ED File Offset: 0x0025A4ED
		public float BulletSize
		{
			get
			{
				return this.b.BulletSize;
			}
			set
			{
				this.b.BulletSize = value;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060049A0 RID: 18848 RVA: 0x0025B500 File Offset: 0x0025A500
		// (set) Token: 0x060049A1 RID: 18849 RVA: 0x0025B51D File Offset: 0x0025A51D
		public float BulletAreaWidth
		{
			get
			{
				return this.b.BulletAreaWidth;
			}
			set
			{
				this.b.BulletAreaWidth = value;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060049A2 RID: 18850 RVA: 0x0025B530 File Offset: 0x0025A530
		// (set) Token: 0x060049A3 RID: 18851 RVA: 0x0025B54D File Offset: 0x0025A54D
		public float ParagraphIndent
		{
			get
			{
				return this.b.ParagraphIndent;
			}
			set
			{
				this.b.ParagraphIndent = value;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060049A4 RID: 18852 RVA: 0x0025B560 File Offset: 0x0025A560
		// (set) Token: 0x060049A5 RID: 18853 RVA: 0x0025B57D File Offset: 0x0025A57D
		public Align BulletAlign
		{
			get
			{
				return this.b.BulletAlign;
			}
			set
			{
				this.b.BulletAlign = value;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060049A6 RID: 18854 RVA: 0x0025B590 File Offset: 0x0025A590
		// (set) Token: 0x060049A7 RID: 18855 RVA: 0x0025B5AD File Offset: 0x0025A5AD
		public TextAlign TextAlign
		{
			get
			{
				return this.b.TextAlign;
			}
			set
			{
				this.b.TextAlign = value;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060049A8 RID: 18856 RVA: 0x0025B5C0 File Offset: 0x0025A5C0
		// (set) Token: 0x060049A9 RID: 18857 RVA: 0x0025B5DD File Offset: 0x0025A5DD
		public float LeftIndent
		{
			get
			{
				return this.b.LeftIndent;
			}
			set
			{
				this.b.LeftIndent = value;
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060049AA RID: 18858 RVA: 0x0025B5F0 File Offset: 0x0025A5F0
		// (set) Token: 0x060049AB RID: 18859 RVA: 0x0025B60D File Offset: 0x0025A60D
		public float RightIndent
		{
			get
			{
				return this.b.RightIndent;
			}
			set
			{
				this.b.RightIndent = value;
			}
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x060049AC RID: 18860 RVA: 0x0025B620 File Offset: 0x0025A620
		// (set) Token: 0x060049AD RID: 18861 RVA: 0x0025B63D File Offset: 0x0025A63D
		public Color TextColor
		{
			get
			{
				return this.b.TextColor;
			}
			set
			{
				this.b.TextColor = value;
			}
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x060049AE RID: 18862 RVA: 0x0025B650 File Offset: 0x0025A650
		// (set) Token: 0x060049AF RID: 18863 RVA: 0x0025B66D File Offset: 0x0025A66D
		public Color TextOutlineColor
		{
			get
			{
				return this.b.TextOutlineColor;
			}
			set
			{
				this.b.TextOutlineColor = value;
			}
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x060049B0 RID: 18864 RVA: 0x0025B680 File Offset: 0x0025A680
		// (set) Token: 0x060049B1 RID: 18865 RVA: 0x0025B69D File Offset: 0x0025A69D
		public float TextOutlineWidth
		{
			get
			{
				return this.b.TextOutlineWidth;
			}
			set
			{
				this.b.TextOutlineWidth = value;
			}
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x060049B3 RID: 18867 RVA: 0x0025B6C0 File Offset: 0x0025A6C0
		// (set) Token: 0x060049B2 RID: 18866 RVA: 0x0025B6AD File Offset: 0x0025A6AD
		public bool RightToLeft
		{
			get
			{
				return this.b.RightToLeft;
			}
			set
			{
				this.b.RightToLeft = value;
			}
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060049B4 RID: 18868 RVA: 0x0025B6E0 File Offset: 0x0025A6E0
		// (set) Token: 0x060049B5 RID: 18869 RVA: 0x0025B6FD File Offset: 0x0025A6FD
		public Font Font
		{
			get
			{
				return this.b.Font;
			}
			set
			{
				this.b.Font = value;
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060049B6 RID: 18870 RVA: 0x0025B710 File Offset: 0x0025A710
		// (set) Token: 0x060049B7 RID: 18871 RVA: 0x0025B72D File Offset: 0x0025A72D
		public float FontSize
		{
			get
			{
				return this.b.FontSize;
			}
			set
			{
				this.b.FontSize = value;
				this.b.Leading = this.b.Font.GetDefaultLeading(this.b.FontSize);
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060049B8 RID: 18872 RVA: 0x0025B764 File Offset: 0x0025A764
		// (set) Token: 0x060049B9 RID: 18873 RVA: 0x0025B781 File Offset: 0x0025A781
		public float Leading
		{
			get
			{
				return this.b.Leading;
			}
			set
			{
				this.b.Leading = value;
			}
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x060049BA RID: 18874 RVA: 0x0025B794 File Offset: 0x0025A794
		public ListItemList Items
		{
			get
			{
				return this.b.Items;
			}
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x060049BB RID: 18875 RVA: 0x0025B7B4 File Offset: 0x0025A7B4
		// (set) Token: 0x060049BC RID: 18876 RVA: 0x0025B7CC File Offset: 0x0025A7CC
		public float Width
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
				this.b.b(value);
			}
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x060049BD RID: 18877 RVA: 0x0025B7E4 File Offset: 0x0025A7E4
		// (set) Token: 0x060049BE RID: 18878 RVA: 0x0025B7FC File Offset: 0x0025A7FC
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
				this.b.a(value);
			}
		}

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x060049BF RID: 18879 RVA: 0x0025B814 File Offset: 0x0025A814
		// (set) Token: 0x060049C0 RID: 18880 RVA: 0x0025B834 File Offset: 0x0025A834
		public override Tag Tag
		{
			get
			{
				return this.b.Tag;
			}
			set
			{
				this.b.Tag = value;
				if (value != null && value.g())
				{
					this.d = new HybridDictionary(1);
				}
			}
		}

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x060049C1 RID: 18881 RVA: 0x0025B870 File Offset: 0x0025A870
		// (set) Token: 0x060049C2 RID: 18882 RVA: 0x0025B88D File Offset: 0x0025A88D
		public override int TagOrder
		{
			get
			{
				return this.b.TagOrder;
			}
			set
			{
				this.b.TagOrder = value;
			}
		}

		// Token: 0x060049C3 RID: 18883 RVA: 0x0025B89D File Offset: 0x0025A89D
		internal void a(SubList A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060049C4 RID: 18884 RVA: 0x0025B8A7 File Offset: 0x0025A8A7
		internal void a(ae7 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060049C5 RID: 18885 RVA: 0x0025B8B4 File Offset: 0x0025A8B4
		internal override byte cb()
		{
			return 96;
		}

		// Token: 0x060049C6 RID: 18886 RVA: 0x0025B8C8 File Offset: 0x0025A8C8
		internal HybridDictionary a()
		{
			return this.d;
		}

		// Token: 0x060049C7 RID: 18887 RVA: 0x0025B8E0 File Offset: 0x0025A8E0
		internal void a(HybridDictionary A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060049C8 RID: 18888 RVA: 0x0025B8EC File Offset: 0x0025A8EC
		protected override void DrawRotated(PageWriter writer)
		{
			if (this.b.Items.Count > 0)
			{
				if (writer.Document.Tag != null)
				{
					if (this.b.Items[0].af() == null)
					{
						if (this.Tag == null)
						{
							StructureElement structureElement = new StructureElement(TagType.List);
							structureElement.a(true);
							for (int i = 0; i < this.b.Items.Count; i++)
							{
								this.b.Items[i].a(structureElement);
							}
							if (writer.k() != null)
							{
								structureElement.Parent = writer.k();
							}
							this.Tag = structureElement;
							writer.Document.j().e((StructureElement)this.Tag);
						}
						else if (this.Tag.g())
						{
							for (int i = 0; i < this.b.Items.Count; i++)
							{
								this.b.Items[i].a(this.Tag);
							}
							if (writer.k() != null)
							{
								((StructureElement)this.Tag).Parent = writer.k();
							}
							writer.Document.j().e((StructureElement)this.Tag);
						}
					}
					if (this.Tag.g())
					{
						((StructureElement)this.Tag).a(writer, this, writer.Document.j());
					}
				}
				ListItem listItem = this.b.Items[0];
				ListItem listItem2 = this.b.aa();
				listItem2.a(true);
				if (listItem.aa() >= 1)
				{
					if (this.c != null)
					{
						this.c.d();
					}
					this.b.c(base.Height);
					this.b.a(writer, base.X, base.Y, this.c, base.Height);
				}
			}
		}

		// Token: 0x0400280C RID: 10252
		private new float a;

		// Token: 0x0400280D RID: 10253
		private SubList b;

		// Token: 0x0400280E RID: 10254
		private ae7 c;

		// Token: 0x0400280F RID: 10255
		private new HybridDictionary d = null;
	}
}
