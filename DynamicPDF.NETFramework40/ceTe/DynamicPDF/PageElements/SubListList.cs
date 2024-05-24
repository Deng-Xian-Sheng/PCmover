using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200073F RID: 1855
	public class SubListList
	{
		// Token: 0x06004B04 RID: 19204 RVA: 0x002626F9 File Offset: 0x002616F9
		internal SubListList(float A_0, float A_1, IListProperties A_2, bool A_3)
		{
			this.e = A_3;
			this.b = A_2;
			this.c = A_0;
			this.d = A_1;
			this.f = A_1;
		}

		// Token: 0x06004B05 RID: 19205 RVA: 0x00262738 File Offset: 0x00261738
		public OrderedSubList AddOrderedSubList()
		{
			int num = this.b.Level;
			num++;
			OrderedSubList orderedSubList = new OrderedSubList(this.c, this.d, this.b.Font, this.b.FontSize, this.b.BulletType, this.e);
			orderedSubList.BulletPrefix = this.b.BulletPrefix;
			orderedSubList.BulletSuffix = this.b.BulletSuffix;
			this.a(orderedSubList);
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.a.Add(orderedSubList);
			}
			else
			{
				this.a.Add(orderedSubList);
			}
			orderedSubList.a(num);
			orderedSubList.a((ListItem)this.b);
			if (((ListItem)this.b).Tag != null)
			{
				orderedSubList.Tag = ((ListItem)this.b).Tag.h();
				if (orderedSubList.Tag.g())
				{
					this.b(orderedSubList);
				}
				orderedSubList.TagOrder = ((ListItem)this.b).TagOrder;
			}
			return orderedSubList;
		}

		// Token: 0x06004B06 RID: 19206 RVA: 0x0026287C File Offset: 0x0026187C
		public OrderedSubList AddOrderedSubList(NumberingStyle nStyle)
		{
			int num = this.b.Level;
			num++;
			OrderedSubList orderedSubList = new OrderedSubList(this.c, this.d, this.b.Font, this.b.FontSize, nStyle, this.e);
			orderedSubList.BulletPrefix = this.b.BulletPrefix;
			orderedSubList.BulletSuffix = this.b.BulletSuffix;
			this.a(orderedSubList);
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.a.Add(orderedSubList);
			}
			else
			{
				this.a.Add(orderedSubList);
			}
			orderedSubList.a(num);
			orderedSubList.a((ListItem)this.b);
			if (((ListItem)this.b).Tag != null)
			{
				orderedSubList.Tag = ((ListItem)this.b).Tag.h();
				if (orderedSubList.Tag.g())
				{
					this.b(orderedSubList);
				}
				orderedSubList.TagOrder = ((ListItem)this.b).TagOrder;
			}
			return orderedSubList;
		}

		// Token: 0x06004B07 RID: 19207 RVA: 0x002629B8 File Offset: 0x002619B8
		public UnorderedSubList AddUnorderedSubList()
		{
			int num = this.b.Level;
			num++;
			UnorderedSubList unorderedSubList = new UnorderedSubList(this.c, this.d, this.b.Font, this.b.FontSize, this.a(num), this.e);
			this.a(unorderedSubList);
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.a.Add(unorderedSubList);
			}
			else
			{
				this.a.Add(unorderedSubList);
			}
			unorderedSubList.a(num);
			unorderedSubList.a((ListItem)this.b);
			if (((ListItem)this.b).Tag != null)
			{
				unorderedSubList.Tag = ((ListItem)this.b).Tag.h();
				if (unorderedSubList.Tag.g())
				{
					this.b(unorderedSubList);
				}
				unorderedSubList.TagOrder = ((ListItem)this.b).TagOrder;
			}
			return unorderedSubList;
		}

		// Token: 0x06004B08 RID: 19208 RVA: 0x00262AD4 File Offset: 0x00261AD4
		public UnorderedSubList AddUnorderedSubList(UnorderedListStyle bullet)
		{
			int num = this.b.Level;
			num++;
			UnorderedSubList unorderedSubList = new UnorderedSubList(this.c, this.d, this.b.Font, this.b.FontSize, bullet, this.e);
			this.a(unorderedSubList);
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.a.Add(unorderedSubList);
			}
			else
			{
				this.a.Add(unorderedSubList);
			}
			unorderedSubList.a(num);
			unorderedSubList.a((ListItem)this.b);
			if (((ListItem)this.b).Tag != null)
			{
				unorderedSubList.Tag = ((ListItem)this.b).Tag.h();
				if (unorderedSubList.Tag.g())
				{
					this.b(unorderedSubList);
				}
				unorderedSubList.TagOrder = ((ListItem)this.b).TagOrder;
			}
			return unorderedSubList;
		}

		// Token: 0x06004B09 RID: 19209 RVA: 0x00262BEC File Offset: 0x00261BEC
		internal void a(SubList A_0)
		{
			A_0.BulletAlign = this.b.BulletAlign;
			A_0.Font = this.b.Font;
			A_0.FontSize = this.b.FontSize;
			A_0.Leading = this.b.Leading;
			A_0.LeftIndent = this.b.LeftIndent;
			A_0.ParagraphIndent = this.b.ParagraphIndent;
			A_0.RightIndent = this.b.RightIndent;
			A_0.TextAlign = this.b.TextAlign;
			A_0.TextColor = this.b.TextColor;
			A_0.TextOutlineColor = this.b.TextOutlineColor;
			A_0.TextOutlineWidth = this.b.TextOutlineWidth;
			A_0.StrikeThrough = this.b.StrikeThrough;
			A_0.ListItemTopMargin = this.b.ListItemTopMargin;
			A_0.ListItemBottomMargin = this.b.ListItemBottomMargin;
			A_0.BulletSize = this.b.BulletSize;
			A_0.BulletAreaWidth = this.b.BulletAreaWidth;
			A_0.RightToLeft = this.b.RightToLeft;
		}

		// Token: 0x06004B0A RID: 19210 RVA: 0x00262D2C File Offset: 0x00261D2C
		internal float a(ae7 A_0)
		{
			this.h = 0;
			float num = 0f;
			int num2 = 0;
			if (A_0 != null)
			{
				object obj = A_0.e();
				if (obj != null)
				{
					num2 = (int)obj;
				}
			}
			for (int i = num2; i <= this.a.Count - 1; i++)
			{
				num += ((SubList)this.a[i]).a(A_0);
				this.h += ((SubList)this.a[i]).Items.d();
			}
			return num;
		}

		// Token: 0x06004B0B RID: 19211 RVA: 0x00262DDC File Offset: 0x00261DDC
		private UnorderedListStyle a(int A_0)
		{
			UnorderedListStyle result;
			if (A_0 == 1)
			{
				result = UnorderedListStyle.Disc;
			}
			else if (A_0 == 2)
			{
				result = UnorderedListStyle.Circle;
			}
			else if (A_0 == 3)
			{
				result = UnorderedListStyle.Square;
			}
			else
			{
				result = UnorderedListStyle.Disc;
			}
			return result;
		}

		// Token: 0x1700057E RID: 1406
		public List this[int index]
		{
			get
			{
				return (List)this.a[index];
			}
		}

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06004B0D RID: 19213 RVA: 0x00262E50 File Offset: 0x00261E50
		public int Count
		{
			get
			{
				int result;
				if (this.a == null)
				{
					result = 0;
				}
				else
				{
					result = this.a.Count;
				}
				return result;
			}
		}

		// Token: 0x06004B0E RID: 19214 RVA: 0x00262E84 File Offset: 0x00261E84
		internal ListItem a()
		{
			return ((SubList)this.a[this.a.Count - 1]).aa();
		}

		// Token: 0x06004B0F RID: 19215 RVA: 0x00262EB8 File Offset: 0x00261EB8
		internal ae7 b()
		{
			return this.g;
		}

		// Token: 0x06004B10 RID: 19216 RVA: 0x00262ED0 File Offset: 0x00261ED0
		internal int c()
		{
			return this.h;
		}

		// Token: 0x06004B11 RID: 19217 RVA: 0x00262EE8 File Offset: 0x00261EE8
		internal void a(float A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06004B12 RID: 19218 RVA: 0x00262EF4 File Offset: 0x00261EF4
		internal void a(ae7 A_0, ae7 A_1, float A_2)
		{
			this.g = A_1;
			int num = 0;
			ae7 a_ = A_0;
			if (A_0 != null)
			{
				object obj = A_0.e();
				if (obj != null)
				{
					num = (int)obj;
				}
				a_ = A_0.f();
			}
			for (int i = num; i < this.a.Count; i++)
			{
				SubList subList = (SubList)this.a[i];
				float num2 = subList.a(a_);
				int num3 = subList.Items.d();
				if (num2 > A_2 && (this.a.Count < 1 || num3 != 1 || this.f != A_2))
				{
					A_1.a(i);
					subList.c(this.f);
					subList.a(A_0, A_1, A_2);
					A_1 = subList.Items.c();
					break;
				}
				A_2 -= num2;
				A_0 = null;
			}
			this.g = A_1;
		}

		// Token: 0x06004B13 RID: 19219 RVA: 0x00263004 File Offset: 0x00262004
		internal float a(PageWriter A_0, float A_1, float A_2, float A_3, ae7 A_4)
		{
			if (this.a != null)
			{
				ae7 a_ = A_4;
				int num = 0;
				if (A_4 != null)
				{
					object obj = A_4.e();
					if (obj != null)
					{
						num = (int)obj;
					}
					a_ = A_4.f();
				}
				int count = this.a.Count;
				for (int i = num; i < count; i++)
				{
					SubList subList = (SubList)this.a[i];
					subList.c(this.f);
					float num2 = subList.a(a_);
					int num3 = subList.Items.d();
					if (num2 >= A_3 && (this.a.Count < 1 || num3 != 1 || this.f != A_3))
					{
						if (this.e)
						{
							A_2 = subList.a(A_0, A_1, A_2, A_4, A_3);
						}
						else
						{
							A_2 = subList.a(A_0, A_1 + this.b.LeftIndent, A_2, A_4, A_3);
						}
						break;
					}
					if (this.e)
					{
						A_2 = subList.a(A_0, A_1, A_2, A_4, A_3);
					}
					else
					{
						A_2 = subList.a(A_0, A_1 + this.b.LeftIndent, A_2, A_4, A_3);
					}
					A_3 -= num2;
				}
			}
			return A_2;
		}

		// Token: 0x06004B14 RID: 19220 RVA: 0x00263180 File Offset: 0x00262180
		internal void b(SubList A_0)
		{
			((StructureElement)A_0.Tag).Parent = null;
			AttributeClassList attributeClassList = new AttributeClassList();
			for (int i = 0; i < ((StructureElement)A_0.Tag).Classes.Count; i++)
			{
				AttributeClass attributeClass = ((StructureElement)A_0.Tag).Classes[i].b();
				attributeClass.a(attributeClass.a() + this.a.Count.ToString());
				attributeClassList.Add(attributeClass);
			}
			((StructureElement)A_0.Tag).a(attributeClassList);
		}

		// Token: 0x06004B15 RID: 19221 RVA: 0x0026322C File Offset: 0x0026222C
		internal ArrayList d()
		{
			return this.a;
		}

		// Token: 0x040028A8 RID: 10408
		private ArrayList a = null;

		// Token: 0x040028A9 RID: 10409
		private IListProperties b;

		// Token: 0x040028AA RID: 10410
		private float c;

		// Token: 0x040028AB RID: 10411
		private float d;

		// Token: 0x040028AC RID: 10412
		private bool e;

		// Token: 0x040028AD RID: 10413
		private float f;

		// Token: 0x040028AE RID: 10414
		private ae7 g;

		// Token: 0x040028AF RID: 10415
		private int h = 0;
	}
}
