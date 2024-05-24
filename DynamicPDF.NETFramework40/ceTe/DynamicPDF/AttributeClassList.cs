using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000640 RID: 1600
	public class AttributeClassList
	{
		// Token: 0x06003C16 RID: 15382 RVA: 0x001FE036 File Offset: 0x001FD036
		internal AttributeClassList()
		{
			this.a = new AttributeClass[1];
		}

		// Token: 0x06003C17 RID: 15383 RVA: 0x001FE05B File Offset: 0x001FD05B
		internal AttributeClassList(int A_0)
		{
			this.a = new AttributeClass[A_0];
		}

		// Token: 0x06003C18 RID: 15384 RVA: 0x001FE080 File Offset: 0x001FD080
		public void Add(AttributeClass attributeType)
		{
			if (this.b == this.a.Length)
			{
				AttributeClass[] array = new AttributeClass[this.a.Length * 2];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = attributeType;
		}

		// Token: 0x1700012F RID: 303
		public AttributeClass this[int index]
		{
			get
			{
				return this.a[index];
			}
		}

		// Token: 0x06003C1A RID: 15386 RVA: 0x001FE102 File Offset: 0x001FD102
		internal void a(int A_0, AttributeClass A_1)
		{
			this.a[A_0] = A_1;
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06003C1B RID: 15387 RVA: 0x001FE110 File Offset: 0x001FD110
		public int Count
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06003C1C RID: 15388 RVA: 0x001FE128 File Offset: 0x001FD128
		internal AttributeClassList a()
		{
			AttributeClassList attributeClassList = new AttributeClassList(this.b);
			this.a.CopyTo(attributeClassList.a, 0);
			attributeClassList.b = this.b;
			return attributeClassList;
		}

		// Token: 0x06003C1D RID: 15389 RVA: 0x001FE168 File Offset: 0x001FD168
		internal void b()
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].AttributeObjects.b();
			}
		}

		// Token: 0x040020BF RID: 8383
		private AttributeClass[] a = null;

		// Token: 0x040020C0 RID: 8384
		private int b = 0;
	}
}
