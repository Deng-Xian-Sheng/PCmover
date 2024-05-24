using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005BF RID: 1471
	internal class amq : amp
	{
		// Token: 0x06003A4A RID: 14922 RVA: 0x001F4353 File Offset: 0x001F3353
		internal amq(FixedPage A_0, amj A_1) : base(A_0.d())
		{
			this.a = A_1;
			this.b = A_0;
		}

		// Token: 0x06003A4B RID: 14923 RVA: 0x001F4374 File Offset: 0x001F3374
		internal override void e9(PageWriter A_0)
		{
			if (A_0.Document.Tag != null)
			{
				if (A_0.DocumentWriter.af() == null)
				{
					A_0.DocumentWriter.a(new StructureElement(new NamedTagType(this.b.DocumentLayout.Id, TagType.Document)));
				}
				if (A_0.k() == null)
				{
					StructureElement structureElement = new StructureElement(new NamedTagType(this.b.Id, TagType.Figure));
					A_0.a(structureElement);
					structureElement.Parent = A_0.DocumentWriter.af();
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.SetBoundingBox(A_0.Page.Dimensions.Body.Left, A_0.Page.Dimensions.Body.Bottom, A_0.Page.Dimensions.Body.Right, A_0.Page.Dimensions.Body.Top);
					A_0.k().AttributeLists.Add(attributeObject);
				}
			}
			base.e9(A_0);
			this.a.a(A_0);
		}

		// Token: 0x06003A4C RID: 14924 RVA: 0x001F44B0 File Offset: 0x001F34B0
		internal FixedPage a()
		{
			return this.b;
		}

		// Token: 0x04001B9B RID: 7067
		private new amj a;

		// Token: 0x04001B9C RID: 7068
		private new FixedPage b;
	}
}
