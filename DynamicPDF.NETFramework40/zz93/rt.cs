using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002A6 RID: 678
	internal class rt : rs
	{
		// Token: 0x06001E44 RID: 7748 RVA: 0x00131A51 File Offset: 0x00130A51
		internal rt(FixedPage A_0, xf A_1) : base(A_0.d())
		{
			this.a = A_1;
			this.b = A_0;
		}

		// Token: 0x06001E45 RID: 7749 RVA: 0x00131A70 File Offset: 0x00130A70
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

		// Token: 0x06001E46 RID: 7750 RVA: 0x00131BAC File Offset: 0x00130BAC
		internal FixedPage a()
		{
			return this.b;
		}

		// Token: 0x04000D61 RID: 3425
		private new xf a;

		// Token: 0x04000D62 RID: 3426
		private new FixedPage b;
	}
}
