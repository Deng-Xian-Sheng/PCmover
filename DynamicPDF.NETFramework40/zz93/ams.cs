using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020005C1 RID: 1473
	internal class ams : amq
	{
		// Token: 0x06003A58 RID: 14936 RVA: 0x001F47BC File Offset: 0x001F37BC
		internal ams(FixedPage A_0, amj A_1) : base(A_0, A_1)
		{
			this.a = A_0.Template;
		}

		// Token: 0x06003A59 RID: 14937 RVA: 0x001F47DC File Offset: 0x001F37DC
		internal override void ff(DocumentWriter A_0, int A_1, int A_2)
		{
			if (A_0.Document.Tag != null)
			{
				this.a(A_0, A_1, A_2);
			}
			else
			{
				PageResources a_ = new PageResources();
				PageWriter pageWriter = new PageWriter(this, a_, A_0, A_0.u(), A_1, A_2);
				pageWriter.Write_q_(false);
				this.a(pageWriter);
				PageWriter pageWriter2 = new PageWriter(this, a_, A_0, A_0.x(), A_1, A_2);
				pageWriter2.Write_Q(false);
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
			}
		}

		// Token: 0x06003A5A RID: 14938 RVA: 0x001F49C4 File Offset: 0x001F39C4
		private void a(DocumentWriter A_0, int A_1, int A_2)
		{
			if (A_0.Document.j() != null)
			{
				this.a(A_0.Document.k());
				A_0.Document.j().a(this.f(), A_0.GetObjectNumber());
			}
			if (A_0.af() == null)
			{
				A_0.a(new StructureElement(new NamedTagType(base.a().DocumentLayout.Id, TagType.Document)));
			}
			StructureElement structureElement = new StructureElement(new NamedTagType(base.a().Id, TagType.Figure));
			structureElement.Parent = A_0.af();
			AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
			attributeObject.SetBoundingBox(base.Dimensions.Body.Left, base.Dimensions.Body.Bottom, base.Dimensions.Body.Right, base.Dimensions.Body.Top);
			A_0.af().AttributeLists.Add(attributeObject);
			StructureElement structureElement2 = new StructureElement();
			structureElement2.Parent = structureElement;
			this.b = new StructureElement(TagType.Figure);
			AttributeObject attributeObject2 = new AttributeObject(AttributeOwner.Layout);
			attributeObject2.SetBoundingBox(base.Dimensions.Body.Left, base.Dimensions.Body.Bottom, base.Dimensions.Body.Right, base.Dimensions.Body.Top);
			this.b.AttributeLists.Add(attributeObject2);
			this.b.Parent = structureElement2;
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

		// Token: 0x06003A5B RID: 14939 RVA: 0x001F4E7C File Offset: 0x001F3E7C
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

		// Token: 0x06003A5C RID: 14940 RVA: 0x001F51AC File Offset: 0x001F41AC
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

		// Token: 0x06003A5D RID: 14941 RVA: 0x001F5224 File Offset: 0x001F4224
		internal override void e9(PageWriter A_0)
		{
			if (this.a.k() != null)
			{
				A_0.Resources.SetStartingNameNumber(this.a.k().b());
			}
			base.e9(A_0);
		}

		// Token: 0x06003A5E RID: 14942 RVA: 0x001F5268 File Offset: 0x001F4268
		internal override PdfPage fg()
		{
			return this.a;
		}

		// Token: 0x06003A5F RID: 14943 RVA: 0x001F5280 File Offset: 0x001F4280
		internal override StructureElement np()
		{
			return this.b;
		}

		// Token: 0x04001B9F RID: 7071
		private new PdfPage a;

		// Token: 0x04001BA0 RID: 7072
		private new StructureElement b = null;
	}
}
