using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005C8 RID: 1480
	internal class amz : amp
	{
		// Token: 0x06003A8D RID: 14989 RVA: 0x001F5FCA File Offset: 0x001F4FCA
		internal amz(amg A_0, al2 A_1) : base(A_1.c().e())
		{
			this.b = A_0;
			this.a = A_1;
		}

		// Token: 0x06003A8E RID: 14990 RVA: 0x001F5FF0 File Offset: 0x001F4FF0
		internal amg a()
		{
			return this.b;
		}

		// Token: 0x06003A8F RID: 14991 RVA: 0x001F6008 File Offset: 0x001F5008
		internal void a(amg A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003A90 RID: 14992 RVA: 0x001F6014 File Offset: 0x001F5014
		internal override void e9(PageWriter A_0)
		{
			if (A_0.Document.Tag != null)
			{
				this.a(A_0);
			}
			else
			{
				and and = this.a.c().h();
				if (and != null && and.e())
				{
					and.d().d(this.a);
					and.f().a(this.a, true);
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
				this.b.nh(A_0, x5.a(this.a.c().Header.Height));
			}
		}

		// Token: 0x06003A91 RID: 14993 RVA: 0x001F6134 File Offset: 0x001F5134
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
			and and = this.a.c().h();
			if (and != null && and.e())
			{
				and.d().d(this.a);
				and.f().a(this.a, true);
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
			this.b.nh(A_0, x5.a(this.a.c().Header.Height));
			base.Elements.Draw(A_0);
			A_0.a(structureElement);
		}

		// Token: 0x06003A92 RID: 14994 RVA: 0x001F63B0 File Offset: 0x001F53B0
		internal void a(LayoutWriter A_0)
		{
			and and = this.a.c().h();
			amk amk = this.b.e();
			bool flag = this.a.c().Detail.Elements.h();
			if (and.d().b() != 0)
			{
				while (amk != null)
				{
					if (amk.ns() || flag)
					{
						for (am6 am = amk.h(); am != null; am = am.b())
						{
							ahs ahs = (ahs)and.g()[am.a().fd()];
							if (ahs != null)
							{
								ahs.a(A_0, amk.nn());
							}
							if (flag && am.a().cb() == 239)
							{
								((am1)am.a()).a(A_0, this);
							}
						}
						amk = amk.e();
					}
					else
					{
						and.d().a(A_0, amk.nn());
						amk = amk.e();
					}
				}
				for (ahs.a a = and.d().a(); a != null; a = a.b)
				{
					A_0.m4().a(a.a).mk(this);
				}
			}
			else
			{
				while (amk != null)
				{
					for (am6 am = amk.h(); am != null; am = am.b())
					{
						if (flag && am.a().cb() == 239)
						{
							((am1)am.a()).a(A_0, this);
						}
					}
					amk = amk.e();
				}
			}
		}

		// Token: 0x06003A93 RID: 14995 RVA: 0x001F65B0 File Offset: 0x001F55B0
		internal al2 b()
		{
			return this.a;
		}

		// Token: 0x04001BAA RID: 7082
		private new al2 a;

		// Token: 0x04001BAB RID: 7083
		private new amg b;
	}
}
