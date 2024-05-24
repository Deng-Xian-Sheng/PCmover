using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000734 RID: 1844
	public abstract class ListItemList
	{
		// Token: 0x06004A27 RID: 18983 RVA: 0x0025E2D8 File Offset: 0x0025D2D8
		internal ListItemList(SubList A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06004A28 RID: 18984 RVA: 0x0025E30C File Offset: 0x0025D30C
		public ListItem Add(string item)
		{
			ListItem listItem = new ListItem(this.c.v(), this.c.m(), this.c, item);
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.a.Add(listItem);
			}
			else
			{
				this.a.Add(listItem);
			}
			if (this.c.Tag != null)
			{
				listItem.Tag = this.c.Tag.h();
				if (listItem.Tag.g())
				{
					((StructureElement)listItem.Tag).Parent = null;
					AttributeClassList attributeClassList = new AttributeClassList();
					for (int i = 0; i < ((StructureElement)listItem.Tag).Classes.Count; i++)
					{
						AttributeClass attributeClass = ((StructureElement)listItem.Tag).Classes[i].b();
						attributeClass.a(attributeClass.a() + this.a.Count.ToString());
						attributeClassList.Add(attributeClass);
					}
					((StructureElement)listItem.Tag).a(attributeClassList);
				}
				listItem.TagOrder = this.c.TagOrder;
			}
			this.b = this.c.m();
			return listItem;
		}

		// Token: 0x17000542 RID: 1346
		public ListItem this[int index]
		{
			get
			{
				return (ListItem)this.a[index];
			}
		}

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x06004A2A RID: 18986 RVA: 0x0025E4AC File Offset: 0x0025D4AC
		public int Count
		{
			get
			{
				int result;
				if (this.a != null)
				{
					result = this.a.Count;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x06004A2B RID: 18987 RVA: 0x0025E4DC File Offset: 0x0025D4DC
		internal float a(ae7 A_0)
		{
			this.e = 0;
			float num = 0f;
			int num2 = 0;
			if (this.a != null)
			{
				if (A_0 != null)
				{
					object obj = A_0.e();
					if (obj != null)
					{
						num2 = (int)obj;
					}
				}
				int num3 = this.a.Count - 1;
				for (int i = num2; i <= num3; i++)
				{
					ListItem listItem = (ListItem)this.a[i];
					float num4 = listItem.a(A_0);
					if (num4 != 0f)
					{
						num += num4;
						this.e += listItem.ad();
					}
				}
			}
			return num;
		}

		// Token: 0x06004A2C RID: 18988 RVA: 0x0025E5AC File Offset: 0x0025D5AC
		internal ListItem a()
		{
			return ((ListItem)this.a[this.a.Count - 1]).ae();
		}

		// Token: 0x06004A2D RID: 18989 RVA: 0x0025E5E0 File Offset: 0x0025D5E0
		internal float b()
		{
			return this.b;
		}

		// Token: 0x06004A2E RID: 18990 RVA: 0x0025E5F8 File Offset: 0x0025D5F8
		internal void a(float A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06004A2F RID: 18991 RVA: 0x0025E604 File Offset: 0x0025D604
		internal ae7 c()
		{
			return this.d;
		}

		// Token: 0x06004A30 RID: 18992 RVA: 0x0025E61C File Offset: 0x0025D61C
		internal int d()
		{
			return this.e;
		}

		// Token: 0x06004A31 RID: 18993 RVA: 0x0025E634 File Offset: 0x0025D634
		internal void a(ae7 A_0, ae7 A_1, float A_2)
		{
			this.d = A_1;
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
			for (int i = num; i <= this.Count - 1; i++)
			{
				ListItem listItem = this[i];
				float num2 = listItem.a(a_);
				if (num2 > A_2 && (this.b != A_2 || listItem.ad() != 1))
				{
					A_1.a(i);
					listItem.a(A_0, A_1, A_2);
					A_1 = listItem.ac();
					break;
				}
				if (i == this.Count - 1 && this.b == A_2)
				{
					A_1 = new ae7();
				}
				A_2 -= num2;
				A_0 = null;
			}
			this.d = A_1;
		}

		// Token: 0x06004A32 RID: 18994
		internal abstract float i8(PageWriter A_0, float A_1, float A_2, ae7 A_3, float A_4);

		// Token: 0x06004A33 RID: 18995 RVA: 0x0025E738 File Offset: 0x0025D738
		internal void a(PageWriter A_0, ListItem A_1, float A_2, float A_3, bool A_4)
		{
			if (A_1.SubLists.Count > 0 && !A_4 && !A_1.ag())
			{
				if (A_1.Tag == null)
				{
					StructureElement structureElement = new StructureElement(TagType.List, A_0.Page.f());
					structureElement.a(false);
					A_1.Tag = structureElement;
					((StructureElement)A_1.Tag).Order = A_1.TagOrder;
				}
				if (A_1.Tag.g())
				{
					((StructureElement)A_1.Tag).Parent = this.a(A_1, A_1.af());
					((StructureElement)A_1.Tag).a(A_0, A_1, A_2, A_3, A_0.Document.j(), false, true);
				}
				for (int i = 0; i < A_1.SubLists.Count; i++)
				{
					object obj = A_1.SubLists.d()[i];
					if (obj is OrderedSubList)
					{
						OrderedSubList orderedSubList = (OrderedSubList)obj;
						if (orderedSubList.Tag == null)
						{
							StructureElement structureElement = new StructureElement(TagType.List, A_0.Page.f());
							structureElement.a(false);
							orderedSubList.Tag = structureElement;
						}
						if (orderedSubList.Tag.g())
						{
							((StructureElement)orderedSubList.Tag).Parent = this.a(A_1, A_1.Tag);
							((StructureElement)orderedSubList.Tag).a(A_0, A_1, A_2, A_3, A_0.Document.j(), false, true);
						}
						for (int j = 0; j < orderedSubList.Items.Count; j++)
						{
							orderedSubList.Items[j].a(orderedSubList.Tag);
						}
					}
					else
					{
						UnorderedSubList unorderedSubList = (UnorderedSubList)obj;
						if (unorderedSubList.Tag == null)
						{
							unorderedSubList.Tag = new StructureElement(TagType.List, A_0.Page.f());
						}
						if (unorderedSubList.Tag.g())
						{
							((StructureElement)unorderedSubList.Tag).Parent = this.a(A_1, A_1.Tag);
							((StructureElement)unorderedSubList.Tag).a(A_0, A_1, A_2, A_3, A_0.Document.j(), false, true);
						}
						for (int j = 0; j < unorderedSubList.Items.Count; j++)
						{
							unorderedSubList.Items[j].a(unorderedSubList.Tag);
						}
					}
				}
				if (A_1.ListItemTag == null && !A_4)
				{
					if (A_1.Tag.g())
					{
						StructureElement structureElement = new StructureElement(TagType.ListItem, true);
						structureElement.a(false);
						A_1.ListItemTag = structureElement;
					}
					else
					{
						A_1.ListItemTag = A_1.Tag.h();
					}
				}
				if (!A_4)
				{
					if (A_1.ListItemTag.g())
					{
						((StructureElement)A_1.ListItemTag).Parent = this.a(A_1, A_1.Tag);
					}
				}
			}
			else if (!A_1.ag())
			{
				if (A_1.ListItemTag == null && !A_4)
				{
					if (A_1.af().g())
					{
						StructureElement structureElement = new StructureElement(TagType.ListItem, true);
						structureElement.a(false);
						A_1.ListItemTag = structureElement;
					}
					else
					{
						A_1.ListItemTag = A_1.af().h();
					}
				}
				if (!A_4)
				{
					if (A_1.ListItemTag.g())
					{
						((StructureElement)A_1.ListItemTag).e(A_0.Page.f());
						((StructureElement)A_1.ListItemTag).Parent = this.a(A_1, A_1.af());
					}
				}
			}
			if (A_1.BulletTag == null && !A_4)
			{
				if (A_1.ListItemTag.g())
				{
					StructureElement structureElement = new StructureElement(TagType.Label);
					structureElement.a(false);
					A_1.BulletTag = structureElement;
					((StructureElement)A_1.BulletTag).Order = A_1.BulletTagOrder;
				}
				else
				{
					A_1.BulletTag = A_1.ListItemTag.h();
				}
			}
			if (!A_4 && !A_1.ag())
			{
				if (A_1.BulletTag.g())
				{
					((StructureElement)A_1.BulletTag).Parent = this.a(A_1, A_1.ListItemTag);
				}
			}
			if (A_1.BodyTag == null && !A_4)
			{
				if (A_1.ListItemTag.g())
				{
					StructureElement structureElement = new StructureElement(TagType.ListBody, true);
					A_1.BodyTag = structureElement;
					structureElement.a(false);
					((StructureElement)A_1.BodyTag).Order = A_1.BodyTagOrder;
				}
				else
				{
					A_1.BodyTag = A_1.ListItemTag.h();
				}
			}
			if (!A_4 && !A_1.ag())
			{
				if (A_1.BodyTag.g())
				{
					((StructureElement)A_1.BodyTag).Parent = this.a(A_1, A_1.ListItemTag);
				}
				A_1.b(true);
			}
		}

		// Token: 0x06004A34 RID: 18996 RVA: 0x0025ECF8 File Offset: 0x0025DCF8
		private StructureElement a(ListItem A_0, Tag A_1)
		{
			StructureElement result;
			if (A_1 == null)
			{
				result = null;
			}
			else if (A_1.g())
			{
				result = (StructureElement)A_1;
			}
			else
			{
				ListItem listItem = ((SubList)A_0.ai()).ac();
				if (listItem != null)
				{
					result = this.a(listItem, listItem.af());
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x04002839 RID: 10297
		private ArrayList a = null;

		// Token: 0x0400283A RID: 10298
		private float b = 0f;

		// Token: 0x0400283B RID: 10299
		private SubList c;

		// Token: 0x0400283C RID: 10300
		private ae7 d = null;

		// Token: 0x0400283D RID: 10301
		private int e = 0;
	}
}
