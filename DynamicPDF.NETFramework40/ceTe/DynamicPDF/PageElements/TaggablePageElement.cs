using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000284 RID: 644
	public abstract class TaggablePageElement : PageElement
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06001C9E RID: 7326 RVA: 0x0012562C File Offset: 0x0012462C
		// (set) Token: 0x06001C9F RID: 7327 RVA: 0x00125644 File Offset: 0x00124644
		public virtual Tag Tag
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06001CA0 RID: 7328 RVA: 0x00125650 File Offset: 0x00124650
		// (set) Token: 0x06001CA1 RID: 7329 RVA: 0x00125668 File Offset: 0x00124668
		public virtual int TagOrder
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x06001CA2 RID: 7330 RVA: 0x00125674 File Offset: 0x00124674
		internal void a(StructureElement A_0, bool A_1, StructureElement A_2, bool A_3)
		{
			if (this.a == null)
			{
				StructureElement structureElement = null;
				byte b = this.cb();
				switch (b)
				{
				case 32:
					structureElement = Tag.Figure;
					break;
				case 33:
					structureElement = Tag.Figure;
					break;
				default:
					switch (b)
					{
					case 48:
						structureElement = Tag.Table;
						break;
					case 49:
						structureElement = Tag.Figure;
						break;
					case 50:
						structureElement = Tag.Figure;
						break;
					case 51:
					case 57:
					case 58:
					case 59:
					case 60:
					case 61:
					case 62:
					case 63:
						break;
					case 52:
						structureElement = Tag.Note;
						break;
					case 53:
						structureElement = Tag.Link;
						break;
					case 54:
						structureElement = Tag.Figure;
						break;
					case 55:
						structureElement = Tag.Figure;
						break;
					case 56:
						structureElement = Tag.Figure;
						break;
					case 64:
						structureElement = Tag.Form;
						break;
					case 65:
						structureElement = Tag.Paragraph;
						break;
					case 66:
						structureElement = Tag.Paragraph;
						break;
					case 67:
						structureElement = Tag.Paragraph;
						break;
					case 68:
						structureElement = Tag.Figure;
						break;
					default:
						if (b == 80)
						{
							structureElement = Tag.Table;
						}
						break;
					}
					break;
				}
				this.a = structureElement;
				structureElement.IncludeDefaultAttributes = true;
				structureElement.Order = this.b;
				structureElement.Parent = A_0;
			}
			else if (A_1)
			{
				if (this.a.g())
				{
					if (A_3 && ((StructureElement)this.a).Parent == A_0)
					{
						this.a = Tag.Artifact;
					}
					else
					{
						StructureElement structureElement2 = (StructureElement)A_2.h();
						if (structureElement2.r() != null)
						{
							structureElement2.a(structureElement2.AttributeLists.a());
							structureElement2.AttributeLists.b();
						}
						if (structureElement2.q() != null)
						{
							structureElement2.a(structureElement2.Classes.a());
							structureElement2.Classes.b();
						}
						StructureElement structureElement = structureElement2;
						while (structureElement.Parent != null)
						{
							structureElement.Parent = (StructureElement)structureElement.Parent.h();
							structureElement = structureElement.Parent;
						}
						structureElement.Parent = A_0;
						structureElement2.a(null);
						this.a = structureElement2;
					}
				}
			}
			else if (this.a.g())
			{
				StructureElement structureElement = (StructureElement)this.a;
				while (structureElement.Parent != null)
				{
					structureElement = structureElement.Parent;
				}
				structureElement.Parent = A_0;
			}
		}

		// Token: 0x06001CA3 RID: 7331 RVA: 0x00125910 File Offset: 0x00124910
		internal override bool b4()
		{
			return true;
		}

		// Token: 0x06001CA4 RID: 7332 RVA: 0x00125924 File Offset: 0x00124924
		public override void Draw(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				writer.Document.RequireLicense(3);
			}
		}

		// Token: 0x04000CF1 RID: 3313
		private new Tag a;

		// Token: 0x04000CF2 RID: 3314
		private int b = 0;
	}
}
