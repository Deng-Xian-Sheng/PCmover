using System;
using System.Collections;
using System.ComponentModel;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200073E RID: 1854
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This class is obsolete. Use Row2List class instead.", false)]
	public class RowList : IEnumerable
	{
		// Token: 0x06004AF7 RID: 19191 RVA: 0x002621F2 File Offset: 0x002611F2
		internal RowList()
		{
		}

		// Token: 0x06004AF8 RID: 19192 RVA: 0x00262208 File Offset: 0x00261208
		public Row Add()
		{
			return this.Add(0f, null, float.MinValue, null, null);
		}

		// Token: 0x06004AF9 RID: 19193 RVA: 0x00262230 File Offset: 0x00261230
		public Row Add(float height)
		{
			return this.Add(height, null, float.MinValue, null, null);
		}

		// Token: 0x06004AFA RID: 19194 RVA: 0x00262254 File Offset: 0x00261254
		public Row Add(Font font, float size)
		{
			return this.Add(0f, font, size, null, null);
		}

		// Token: 0x06004AFB RID: 19195 RVA: 0x00262278 File Offset: 0x00261278
		public Row Add(float height, Font font, float size)
		{
			return this.Add(height, font, size, null, null);
		}

		// Token: 0x06004AFC RID: 19196 RVA: 0x00262298 File Offset: 0x00261298
		public Row Add(Font font, float size, Color textColor, Color backColor)
		{
			return this.Add(0f, font, size, textColor, backColor);
		}

		// Token: 0x06004AFD RID: 19197 RVA: 0x002622BC File Offset: 0x002612BC
		public Row Add(float height, Font font, float size, Color textColor, Color backColor)
		{
			Row row = new Row(this.b, height, font, size, textColor, backColor);
			this.a.Add(row);
			this.b.v = true;
			return row;
		}

		// Token: 0x06004AFE RID: 19198 RVA: 0x002622FC File Offset: 0x002612FC
		internal void a(acx A_0, bool A_1)
		{
			if (A_0.d().a().n > 0 && A_0.d().b() > 0)
			{
				int num = A_0.d().a().n - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = i;
					A_0.d().a().a(num2);
					num2 += A_0.d().a().b[num2].a() - 1;
					if (num2 > num)
					{
						num = num2;
					}
					this[i].a(A_0, A_1, i);
				}
			}
			for (int j = A_0.d().b(); j <= A_0.d().c(); j++)
			{
				this[j].a(A_0, A_1, j);
			}
		}

		// Token: 0x06004AFF RID: 19199 RVA: 0x002623F4 File Offset: 0x002613F4
		internal void b(acx A_0, bool A_1)
		{
			PageWriter pageWriter = A_0.c();
			StructureElement structureElement = null;
			if (A_1)
			{
				if (pageWriter.Document.Tag != null)
				{
					if (A_0.d().Tag == null)
					{
						structureElement = new StructureElement(TagType.Table);
					}
					else
					{
						structureElement = (StructureElement)A_0.d().Tag;
					}
					if (pageWriter.k() != null)
					{
						structureElement.Parent = pageWriter.k();
					}
					if (this.b.n > 0)
					{
						this.b.ab = false;
					}
				}
			}
			if (A_0.d().a().n > 0 && A_0.d().b() > 0)
			{
				int num = A_0.d().a().n - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = i;
					A_0.d().a().a(num2);
					num2 += A_0.d().a().b[num2].a() - 1;
					if (num2 > num)
					{
						num = num2;
					}
					this[i].a(A_0, A_1, i, structureElement);
				}
			}
			for (int j = A_0.d().b(); j <= A_0.d().c(); j++)
			{
				if (A_0.c().Document.Tag != null)
				{
					if (!this.b.ab && A_1)
					{
						if (this.b.n - j <= 0)
						{
							this.b.ab = true;
						}
					}
				}
				this[j].a(A_0, A_1, j, structureElement);
			}
			if (A_1)
			{
				if (pageWriter.Document.Tag != null)
				{
					if (A_0.d().Tag == null)
					{
						AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
						attributeObject.b(A_0.d(), pageWriter);
						structureElement.AttributeLists.Add(attributeObject);
					}
					else
					{
						((StructureElement)A_0.d().Tag).a(pageWriter, A_0.d(), pageWriter.Document.j());
					}
				}
			}
		}

		// Token: 0x1700057C RID: 1404
		public Row this[int index]
		{
			get
			{
				return (Row)this.a[index];
			}
		}

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06004B01 RID: 19201 RVA: 0x002626B4 File Offset: 0x002616B4
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x06004B02 RID: 19202 RVA: 0x002626D1 File Offset: 0x002616D1
		internal void a(acy A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06004B03 RID: 19203 RVA: 0x002626DC File Offset: 0x002616DC
		public IEnumerator GetEnumerator()
		{
			return this.a.GetEnumerator();
		}

		// Token: 0x040028A6 RID: 10406
		private ArrayList a = new ArrayList();

		// Token: 0x040028A7 RID: 10407
		private acy b;
	}
}
