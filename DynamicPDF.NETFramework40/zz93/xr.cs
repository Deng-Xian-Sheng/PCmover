using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x0200038B RID: 907
	internal class xr : xq
	{
		// Token: 0x060026B5 RID: 9909 RVA: 0x001657A4 File Offset: 0x001647A4
		internal xr(xd A_0, w1 A_1) : base(A_0, A_1)
		{
			if (A_1.c().n() != null && A_1.c().n().d() != null)
			{
				this.a = A_1.c().n().d();
			}
			else
			{
				this.a = A_1.c().e();
			}
		}

		// Token: 0x060026B6 RID: 9910 RVA: 0x00165814 File Offset: 0x00164814
		internal override void ff(DocumentWriter A_0, int A_1, int A_2)
		{
			if (base.e() != null && base.e().a().e())
			{
				xi xi = base.e().b().a(this, A_0, A_1);
				if (xi == null)
				{
					if (this.a == null)
					{
						base.ff(A_0, A_1, A_2);
						return;
					}
				}
				else
				{
					this.a = xi.b();
				}
			}
			else if (this.a == null)
			{
				base.ff(A_0, A_1, A_2);
				return;
			}
			if (A_0.Document.j() != null)
			{
				this.a(A_0.Document.k());
				A_0.Document.j().a(this.f(), A_0.GetObjectNumber());
			}
			StructureElement structureElement = null;
			if (A_0.Document.Tag != null)
			{
				if (A_0.af() == null)
				{
					A_0.a(new StructureElement(new NamedTagType(base.b().DocumentLayout.Id, TagType.Document)));
				}
				structureElement = new StructureElement(new NamedTagType("Page", TagType.Figure));
				AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
				attributeObject.SetBoundingBox(base.Dimensions.Body.Left, base.Dimensions.Body.Bottom, base.Dimensions.Body.Right, base.Dimensions.Body.Top);
				structureElement.AttributeLists.Add(attributeObject);
				base.b().a().Parent = A_0.af();
				structureElement.Parent = base.b().a();
				StructureElement structureElement2 = new StructureElement();
				structureElement2.Parent = structureElement;
				this.b = new StructureElement(TagType.Figure);
				AttributeObject attributeObject2 = new AttributeObject(AttributeOwner.Layout);
				attributeObject2.SetBoundingBox(base.Dimensions.Body.Left, base.Dimensions.Body.Bottom, base.Dimensions.Body.Right, base.Dimensions.Body.Top);
				this.b.AttributeLists.Add(attributeObject2);
				this.b.Parent = structureElement2;
			}
			PageResources a_ = new PageResources();
			PageWriter pageWriter = new PageWriter(this, a_, A_0, A_0.u(), A_1, A_2);
			if (A_0.Document.Tag != null)
			{
				pageWriter.a(this.b.TagType);
				pageWriter.a(pageWriter.j() + 1);
				pageWriter.b(pageWriter.j());
				pageWriter.aa();
			}
			pageWriter.Write_q_(false);
			this.a(pageWriter);
			PageWriter pageWriter2 = new PageWriter(this, a_, A_0, A_0.x(), A_1, A_2);
			pageWriter2.Write_Q(false);
			if (A_0.Document.Tag != null)
			{
				pageWriter2.z();
				A_0.Document.j().e(this.b);
				pageWriter2.a(pageWriter.j());
				this.b.n().a(new cx(pageWriter.j(), this.f(), 0, A_0.ae()));
				A_0.Document.j().a(this.f(), pageWriter.j(), this.b);
				pageWriter2.a(structureElement);
			}
			this.e9(pageWriter2);
			base.b(pageWriter2);
			A_0.Document.RequireLicense(pageWriter2.r());
			A_0.Document.RequireLicense(pageWriter.r());
			if (A_0.Document.g())
			{
				pageWriter.f();
				pageWriter2.i();
				pageWriter2.w();
			}
			else
			{
				pageWriter.w();
				pageWriter2.w();
			}
			A_0.WriteName(Page.j);
			A_0.WriteArrayOpen();
			A_0.WriteReferenceUnique(pageWriter);
			if (this.a.h() != null)
			{
				if (this.a.h().hy() == ag9.e)
				{
					((abe)this.a.h()).a(A_0);
				}
				else if (this.a.h().hy() == ag9.j)
				{
					this.a.h().hz(A_0);
				}
			}
			A_0.WriteReferenceUnique(pageWriter2);
			A_0.WriteArrayClose();
			this.a(A_0, a_);
			if (pageWriter.Annotations.a() > 0 || pageWriter2.Annotations.a() > 0)
			{
				A_0.WriteName(Page.k);
				A_0.WriteArrayOpen();
				pageWriter.Annotations.a(A_0);
				pageWriter2.Annotations.a(A_0);
				A_0.WriteArrayClose();
			}
			if (pageWriter2.l() || A_0.Document.Tag != null)
			{
				A_0.Document.a(this.f() + 1);
				A_0.WriteName(Page.m);
				A_0.WriteNumber(this.f());
			}
		}

		// Token: 0x060026B7 RID: 9911 RVA: 0x00165D9C File Offset: 0x00164D9C
		private void a(PageWriter A_0)
		{
			float left = this.a.GetDimensions().Edge.Left;
			float top = this.a.GetDimensions().Edge.Top;
			int num = this.a.g() % 360;
			float xOffset;
			float yOffset;
			if (num <= -90)
			{
				if (num != -270)
				{
					if (num == -180)
					{
						goto IL_148;
					}
					if (num != -90)
					{
						return;
					}
					goto IL_1E2;
				}
			}
			else if (num <= 90)
			{
				if (num == 0)
				{
					xOffset = (base.Dimensions.Width - this.a.GetDimensions().Width) / 2f + base.Dimensions.Edge.Left - left;
					yOffset = (base.Dimensions.Edge.Height - this.a.GetDimensions().Height) / 2f + base.Dimensions.Edge.Top - top;
					A_0.Write_cm(xOffset, yOffset);
					A_0.Write_cm(1f, 0f, 0f, 1f);
					return;
				}
				if (num != 90)
				{
					return;
				}
			}
			else
			{
				if (num == 180)
				{
					goto IL_148;
				}
				if (num != 270)
				{
					return;
				}
				goto IL_1E2;
			}
			xOffset = (base.Dimensions.Width - this.a.GetDimensions().Height) / 2f + base.Dimensions.Edge.Left - top;
			yOffset = (base.Dimensions.Edge.Height + this.a.GetDimensions().Width) / 2f + base.Dimensions.Edge.Top + left;
			A_0.Write_cm(xOffset, yOffset);
			A_0.Write_cm(0f, -1f, 1f, 0f);
			return;
			IL_148:
			xOffset = (base.Dimensions.Width + this.a.GetDimensions().Width) / 2f + base.Dimensions.Edge.Left + left;
			yOffset = (base.Dimensions.Edge.Height + this.a.GetDimensions().Height) / 2f + base.Dimensions.Edge.Top + top;
			A_0.Write_cm(xOffset, yOffset);
			A_0.Write_cm(-1f, 0f, 0f, -1f);
			return;
			IL_1E2:
			xOffset = (base.Dimensions.Width + this.a.GetDimensions().Height) / 2f + base.Dimensions.Edge.Left + top;
			yOffset = (base.Dimensions.Edge.Height - this.a.GetDimensions().Width) / 2f + base.Dimensions.Edge.Top - left;
			A_0.Write_cm(xOffset, yOffset);
			A_0.Write_cm(0f, 1f, -1f, 0f);
		}

		// Token: 0x060026B8 RID: 9912 RVA: 0x001660CC File Offset: 0x001650CC
		private void a(DocumentWriter A_0, PageResources A_1)
		{
			if (A_1 == null)
			{
				if (this.a.k() != null)
				{
					this.a.k().a(A_0);
				}
			}
			else if (this.a.k() == null)
			{
				A_1.Draw(A_0);
			}
			else
			{
				this.a.k().a(A_0, A_1);
			}
		}

		// Token: 0x060026B9 RID: 9913 RVA: 0x00166144 File Offset: 0x00165144
		internal override void e9(PageWriter A_0)
		{
			if (this.a != null && this.a.k() != null)
			{
				A_0.Resources.SetStartingNameNumber(this.a.k().b());
			}
			base.e9(A_0);
		}

		// Token: 0x060026BA RID: 9914 RVA: 0x00166194 File Offset: 0x00165194
		internal override PdfPage fg()
		{
			return this.a;
		}

		// Token: 0x060026BB RID: 9915 RVA: 0x001661AC File Offset: 0x001651AC
		internal override StructureElement fh()
		{
			return this.b;
		}

		// Token: 0x040010D3 RID: 4307
		private new PdfPage a;

		// Token: 0x040010D4 RID: 4308
		private new StructureElement b = null;
	}
}
