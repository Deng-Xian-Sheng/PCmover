using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200038A RID: 906
	internal class xq : rs
	{
		// Token: 0x060026AE RID: 9902 RVA: 0x001651A6 File Offset: 0x001641A6
		internal xq(xd A_0, w1 A_1) : base(A_1.c().d())
		{
			this.b = A_0;
			this.a = A_1;
		}

		// Token: 0x060026AF RID: 9903 RVA: 0x001651CC File Offset: 0x001641CC
		internal xd a()
		{
			return this.b;
		}

		// Token: 0x060026B0 RID: 9904 RVA: 0x001651E4 File Offset: 0x001641E4
		internal void a(xd A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060026B1 RID: 9905 RVA: 0x001651F0 File Offset: 0x001641F0
		internal override void e9(PageWriter A_0)
		{
			if (A_0.Document.Tag != null)
			{
				this.a(A_0);
			}
			else
			{
				xw xw = this.a.c().f();
				if (xw != null && xw.e())
				{
					xw.d().d(this.a);
					xw.f().a(this.a, true);
				}
				base.e9(A_0);
				if (this.a.d() != null)
				{
					this.a.d().b(this, A_0);
				}
				if (this.a.e() != null)
				{
					A_0.SetDimensionsShift(0f, this.a.b(), 0f, 0f);
					this.a.e().b(this, A_0);
					A_0.ResetDimensions();
				}
				this.b.f6(A_0, x5.a(this.a.c().Header.Height));
			}
		}

		// Token: 0x060026B2 RID: 9906 RVA: 0x00165310 File Offset: 0x00164310
		private void a(PageWriter A_0)
		{
			if (A_0.DocumentWriter.af() == null)
			{
				A_0.DocumentWriter.a(new StructureElement(new NamedTagType(this.a.DocumentLayout.Id, TagType.Document)));
			}
			if (A_0.k() == null)
			{
				A_0.a(new StructureElement(new NamedTagType("Page", TagType.Figure)));
				AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
				attributeObject.SetBoundingBox(A_0.Page.Dimensions.Body.Left, A_0.Page.Dimensions.Body.Top, A_0.Page.Dimensions.Body.Right, A_0.Page.Dimensions.Body.Bottom);
				A_0.k().AttributeLists.Add(attributeObject);
			}
			this.a.a().Parent = A_0.DocumentWriter.af();
			A_0.k().Parent = this.a.a();
			xw xw = this.a.c().f();
			if (xw != null && xw.e())
			{
				xw.d().d(this.a);
				xw.f().a(this.a, true);
			}
			StructureElement structureElement = A_0.k();
			base.e9(A_0);
			if (this.a.d() != null)
			{
				this.a.d().b(this, A_0);
			}
			if (this.a.e() != null)
			{
				A_0.SetDimensionsShift(0f, this.a.b(), 0f, 0f);
				this.a.e().b(this, A_0);
				A_0.ResetDimensions();
			}
			A_0.a(new StructureElement(new NamedTagType(this.a.c().Detail.Id, TagType.Section))
			{
				Parent = structureElement,
				Order = 2
			});
			this.b.f6(A_0, x5.a(this.a.c().Header.Height));
			base.Elements.Draw(A_0);
			A_0.a(structureElement);
		}

		// Token: 0x060026B3 RID: 9907 RVA: 0x0016558C File Offset: 0x0016458C
		internal void a(LayoutWriter A_0)
		{
			xw xw = this.a.c().f();
			xg xg = this.b.e();
			bool flag = this.a.c().Detail.Elements.h();
			if (xw.d().b() != 0)
			{
				while (xg != null)
				{
					if (xg.gh() || flag)
					{
						for (xx xx = xg.h(); xx != null; xx = xx.b())
						{
							sz sz = (sz)xw.g()[xx.a().fd()];
							if (sz != null)
							{
								sz.a(A_0, xg.gc());
							}
							if (flag && xx.a().cb() == 239)
							{
								((xs)xx.a()).a(A_0, this);
							}
						}
						xg = xg.e();
					}
					else
					{
						xw.d().a(A_0, xg.gc());
						xg = xg.e();
					}
				}
				for (sz.a a = xw.d().a(); a != null; a = a.b)
				{
					A_0.e1().a(a.a).fu(this);
				}
			}
			else
			{
				while (xg != null)
				{
					for (xx xx = xg.h(); xx != null; xx = xx.b())
					{
						if (flag && xx.a().cb() == 239)
						{
							((xs)xx.a()).a(A_0, this);
						}
					}
					xg = xg.e();
				}
			}
		}

		// Token: 0x060026B4 RID: 9908 RVA: 0x0016578C File Offset: 0x0016478C
		internal w1 b()
		{
			return this.a;
		}

		// Token: 0x040010D1 RID: 4305
		private new w1 a;

		// Token: 0x040010D2 RID: 4306
		private new xd b;
	}
}
