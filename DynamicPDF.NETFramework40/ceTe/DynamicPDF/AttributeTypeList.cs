using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200064C RID: 1612
	public class AttributeTypeList
	{
		// Token: 0x06003D0F RID: 15631 RVA: 0x00211C68 File Offset: 0x00210C68
		internal AttributeTypeList()
		{
			this.a = new AttributeType[3];
		}

		// Token: 0x06003D10 RID: 15632 RVA: 0x00211C8D File Offset: 0x00210C8D
		internal AttributeTypeList(int A_0)
		{
			this.a = new AttributeType[A_0];
		}

		// Token: 0x06003D11 RID: 15633 RVA: 0x00211CB4 File Offset: 0x00210CB4
		public void Add(AttributeType attributeType)
		{
			if (this.b == this.a.Length)
			{
				AttributeType[] array = new AttributeType[this.a.Length * 2];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = attributeType;
		}

		// Token: 0x17000133 RID: 307
		public AttributeType this[int index]
		{
			get
			{
				return this.a[index];
			}
		}

		// Token: 0x06003D13 RID: 15635 RVA: 0x00211D36 File Offset: 0x00210D36
		internal void a(int A_0, AttributeType A_1)
		{
			this.a[A_0] = A_1;
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06003D14 RID: 15636 RVA: 0x00211D44 File Offset: 0x00210D44
		public int Count
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06003D15 RID: 15637 RVA: 0x00211D5C File Offset: 0x00210D5C
		internal AttributeTypeList a()
		{
			AttributeTypeList attributeTypeList = new AttributeTypeList(this.a.Length);
			this.a.CopyTo(attributeTypeList.a, 0);
			attributeTypeList.b = this.b;
			return attributeTypeList;
		}

		// Token: 0x06003D16 RID: 15638 RVA: 0x00211D9C File Offset: 0x00210D9C
		internal void b()
		{
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].Owner == AttributeOwner.UserProperties)
				{
					this.a[i] = this.a[i];
				}
				else
				{
					this.a[i] = ((AttributeObject)this.a[i]).c();
				}
			}
		}

		// Token: 0x040020E4 RID: 8420
		private AttributeType[] a = null;

		// Token: 0x040020E5 RID: 8421
		private int b = 0;
	}
}
