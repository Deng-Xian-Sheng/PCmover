using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200063F RID: 1599
	public class AttributeClass
	{
		// Token: 0x06003C0E RID: 15374 RVA: 0x001FDE13 File Offset: 0x001FCE13
		public AttributeClass(string attributeClassName)
		{
			this.a = attributeClassName;
		}

		// Token: 0x06003C0F RID: 15375 RVA: 0x001FDE38 File Offset: 0x001FCE38
		internal void a(AttributeTypeList A_0)
		{
			this.b = A_0;
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06003C10 RID: 15376 RVA: 0x001FDE44 File Offset: 0x001FCE44
		public AttributeTypeList AttributeObjects
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06003C11 RID: 15377 RVA: 0x001FDE5C File Offset: 0x001FCE5C
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06003C12 RID: 15378 RVA: 0x001FDE74 File Offset: 0x001FCE74
		internal void a(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003C13 RID: 15379 RVA: 0x001FDE80 File Offset: 0x001FCE80
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			if (this.b.Count == 1)
			{
				this.b[0].j(A_0);
			}
			else
			{
				A_0.WriteArrayOpen();
				for (int i = 0; i < this.b.Count; i++)
				{
					this.b[i].j(A_0);
					A_0.ak(10);
				}
				A_0.WriteArrayClose();
			}
			A_0.WriteEndObject();
		}

		// Token: 0x06003C14 RID: 15380 RVA: 0x001FDF10 File Offset: 0x001FCF10
		internal AttributeClass a(HybridDictionary A_0)
		{
			AttributeClass attributeClass = new AttributeClass(this.a + "N");
			for (int i = 0; i < this.b.Count; i++)
			{
				if (this.b[i].Owner != AttributeOwner.UserProperties)
				{
					AttributeObject attributeObject = ((AttributeObject)this.b[i]).a(A_0);
					if (attributeObject != null)
					{
						attributeClass.b.Add(attributeObject);
					}
				}
			}
			return (attributeClass.b.Count != 0) ? attributeClass : null;
		}

		// Token: 0x06003C15 RID: 15381 RVA: 0x001FDFB8 File Offset: 0x001FCFB8
		internal AttributeClass b()
		{
			AttributeClass attributeClass = new AttributeClass(this.a());
			for (int i = 0; i < this.AttributeObjects.Count; i++)
			{
				AttributeType attributeType = this.AttributeObjects[i];
				if (this.AttributeObjects[i].Owner != AttributeOwner.UserProperties)
				{
					attributeType = ((AttributeObject)attributeType).c();
				}
				attributeClass.AttributeObjects.Add(attributeType);
			}
			return attributeClass;
		}

		// Token: 0x040020BD RID: 8381
		private string a = null;

		// Token: 0x040020BE RID: 8382
		private AttributeTypeList b = new AttributeTypeList(1);
	}
}
