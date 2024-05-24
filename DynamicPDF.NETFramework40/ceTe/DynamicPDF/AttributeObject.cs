using System;
using System.Collections;
using System.Collections.Specialized;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine.Layout;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Forms;
using ceTe.DynamicPDF.ReportWriter.Layout;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000642 RID: 1602
	public class AttributeObject : AttributeType
	{
		// Token: 0x06003C22 RID: 15394 RVA: 0x001FE1B8 File Offset: 0x001FD1B8
		public AttributeObject(AttributeOwner attributeOwner)
		{
			if (attributeOwner == AttributeOwner.UserProperties)
			{
				throw new GeneratorException("UserProperties cannot be used as owner for AttributeObject");
			}
			this.l = attributeOwner;
		}

		// Token: 0x06003C23 RID: 15395 RVA: 0x001FE208 File Offset: 0x001FD208
		internal HybridDictionary b()
		{
			return this.m;
		}

		// Token: 0x06003C24 RID: 15396 RVA: 0x001FE220 File Offset: 0x001FD220
		internal override int i()
		{
			return this.m.Count;
		}

		// Token: 0x06003C25 RID: 15397 RVA: 0x001FE240 File Offset: 0x001FD240
		internal AttributeObject c()
		{
			AttributeObject attributeObject = new AttributeObject(this.l);
			attributeObject.n = this.n;
			attributeObject.o = this.o;
			object[] array = new object[this.m.Count];
			object[] array2 = new object[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			this.m.Values.CopyTo(array2, 0);
			for (int i = 0; i < this.m.Count; i++)
			{
				attributeObject.m.Add(array[i], array2[i]);
			}
			return attributeObject;
		}

		// Token: 0x06003C26 RID: 15398 RVA: 0x001FE2F4 File Offset: 0x001FD2F4
		internal void a(TaggablePageElement A_0, PageWriter A_1)
		{
			if (A_0 == null)
			{
				this.a();
			}
			else
			{
				byte b = A_0.cb();
				switch (b)
				{
				case 32:
					this.a((BarCode)A_0, A_1);
					break;
				case 33:
					this.a((Dim2Barcode)A_0, A_1);
					break;
				case 34:
					this.a((StackedGS1DataBar)A_0, A_1);
					break;
				case 35:
				case 36:
				case 37:
				case 38:
				case 39:
				case 40:
				case 41:
				case 42:
				case 43:
				case 44:
				case 45:
				case 46:
				case 47:
				case 58:
				case 59:
				case 60:
				case 61:
				case 62:
				case 63:
					break;
				case 48:
					this.a((Table)A_0, A_1);
					break;
				case 49:
					this.a((Rectangle)A_0, A_1);
					break;
				case 50:
					this.a((Path)A_0, A_1);
					break;
				case 51:
					this.a((PageNumberingLabel)A_0, A_1);
					break;
				case 52:
					this.a((Note)A_0, A_1);
					break;
				case 53:
					this.a((Link)A_0, A_1);
					break;
				case 54:
					this.a((Line)A_0, A_1);
					break;
				case 55:
					this.a((Image)A_0, A_1);
					break;
				case 56:
					this.a((Circle)A_0, A_1);
					break;
				case 57:
					this.a((BackgroundImage)A_0, A_1);
					break;
				case 64:
					this.a((FormElement)A_0, A_1);
					break;
				case 65:
					this.a((TextArea)A_0, A_1);
					break;
				case 66:
					this.a((Label)A_0, A_1);
					break;
				case 67:
					this.a((FormattedTextArea)A_0, A_1);
					break;
				case 68:
					this.a((Chart)A_0, A_1);
					break;
				case 69:
					this.a((ceTe.DynamicPDF.ReportWriter.Layout.LayoutTextArea)A_0, null, A_1);
					break;
				case 70:
					this.a(null, (xy)A_0, A_1);
					break;
				default:
					if (b != 80)
					{
						if (b == 96)
						{
							this.a((List)A_0, A_1);
						}
					}
					else
					{
						this.a((Table2)A_0, A_1);
					}
					break;
				}
			}
		}

		// Token: 0x06003C27 RID: 15399 RVA: 0x001FE564 File Offset: 0x001FD564
		internal void a(float A_0, float A_1, float A_2, TextLineList A_3, PageWriter A_4)
		{
			if (this.m.Contains(Attribute.BBox) && this.m[Attribute.BBox] == null)
			{
				this.m[Attribute.BBox] = new AttributeObject.b(new BoundingBox(A_4.Page, A_4.Dimensions.a3(A_4.Page.Dimensions, A_0, A_1), A_4.Dimensions.a4(A_4.Page.Dimensions, A_0, A_1), A_3.Width, A_2, 0f).a());
			}
			if (this.m.Contains(Attribute.Height) && this.m[Attribute.Height] == null)
			{
				this.m[Attribute.Height] = new AttributeObject.d(A_2);
			}
			if (this.m.Contains(Attribute.Width) && this.m[Attribute.Width] == null)
			{
				this.m[Attribute.Width] = new AttributeObject.d(A_3.Width);
			}
		}

		// Token: 0x06003C28 RID: 15400 RVA: 0x001FE6CC File Offset: 0x001FD6CC
		private void a()
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					this.m[array[i]] = this.a(array[i], null);
				}
			}
		}

		// Token: 0x06003C29 RID: 15401 RVA: 0x001FE750 File Offset: 0x001FD750
		private object a(Attribute A_0, PageWriter A_1)
		{
			switch (A_0)
			{
			case Attribute.WritingMode:
				return new AttributeObject.g(WritingMode.LrTb);
			case Attribute.BorderColor:
				return new AttributeObject.b(new float[]
				{
					1f,
					1f,
					1f
				});
			case Attribute.BorderThickness:
				return new AttributeObject.d(0f);
			case Attribute.Color:
			{
				float[] a_ = new float[3];
				return new AttributeObject.b(a_);
			}
			case Attribute.StartIndent:
				return new AttributeObject.d(0f);
			case Attribute.EndIndent:
				return new AttributeObject.d(0f);
			case Attribute.TextIndent:
				return new AttributeObject.d(0f);
			case Attribute.TextAlign:
				return new AttributeObject.g(TextAlignAttribute.Start);
			case Attribute.BlockAlign:
				return new AttributeObject.g(BlockAlign.Before);
			case Attribute.InlineAlign:
				return new AttributeObject.g(InlineAlign.Start);
			case Attribute.TBorderStyle:
				return new AttributeObject.g(BorderStyleAttribute.None);
			case Attribute.TPadding:
				return new AttributeObject.d(0f);
			case Attribute.LineHeight:
				return new AttributeObject.g(LineHeight.Normal);
			case Attribute.TextDecorationColor:
			{
				float[] a_ = new float[3];
				return new AttributeObject.b(a_);
			}
			case Attribute.TextDecorationThickness:
				return new AttributeObject.d(0f);
			case Attribute.GlyphOrientationVertical:
				return new AttributeObject.f("Auto");
			case Attribute.RubyAlign:
				return new AttributeObject.g(RubyAlign.Distribute);
			case Attribute.RubyPosition:
				return new AttributeObject.g(RubyPosition.Before);
			case Attribute.Role:
			case Attribute.Desc:
				break;
			case Attribute.Checked:
				return new AttributeObject.g(Checked.off);
			case Attribute.ListNumbering:
				return new AttributeObject.g(ListNumbering.None);
			case Attribute.RowSpan:
				return new AttributeObject.e(1);
			case Attribute.ColSpan:
				return new AttributeObject.e(1);
			case Attribute.Headers:
				return new AttributeObject.f("Header");
			case Attribute.Scope:
				return new AttributeObject.g(Scope.Row);
			default:
				switch (A_0)
				{
				case Attribute.Placement:
					return new AttributeObject.g(Placement.Inline);
				case Attribute.BackgroundColor:
					return new AttributeObject.b(new float[]
					{
						1f,
						1f,
						1f
					});
				case Attribute.BorderStyle:
					return new AttributeObject.g(BorderStyleAttribute.None);
				case Attribute.Padding:
					return new AttributeObject.d(0f);
				case Attribute.SpaceBefore:
					return new AttributeObject.d(0f);
				case Attribute.SpaceAfter:
					return new AttributeObject.d(0f);
				case Attribute.BBox:
					throw new GeneratorException("Default Bounding Box cannot be specified");
				case Attribute.Width:
					return new AttributeObject.f("Auto");
				case Attribute.Height:
					return new AttributeObject.f("Auto");
				case Attribute.BaselineShift:
					return new AttributeObject.d(0f);
				case Attribute.TextDecorationType:
					return new AttributeObject.g(TextDecorationType.None);
				case Attribute.ColumnCount:
					return new AttributeObject.e(1);
				case Attribute.ColumnWidths:
					return new AttributeObject.d((A_1 != null) ? A_1.Dimensions.Body.Width : 0f);
				case Attribute.ColumnGap:
					return new AttributeObject.d(0f);
				}
				break;
			}
			return new AttributeObject.f(string.Empty);
		}

		// Token: 0x06003C2A RID: 15402 RVA: 0x001FEAA1 File Offset: 0x001FDAA1
		public void SetPlacement()
		{
			this.n = true;
			this.a(Attribute.Placement);
		}

		// Token: 0x06003C2B RID: 15403 RVA: 0x001FEAB7 File Offset: 0x001FDAB7
		public void SetPlacement(Placement placement)
		{
			this.a(Attribute.Placement, placement);
		}

		// Token: 0x06003C2C RID: 15404 RVA: 0x001FEACC File Offset: 0x001FDACC
		public void SetWritingMode()
		{
			this.n = true;
			this.a(Attribute.WritingMode);
		}

		// Token: 0x06003C2D RID: 15405 RVA: 0x001FEADF File Offset: 0x001FDADF
		public void SetWritingMode(WritingMode attributeValue)
		{
			this.a(Attribute.WritingMode, attributeValue);
		}

		// Token: 0x06003C2E RID: 15406 RVA: 0x001FEAF1 File Offset: 0x001FDAF1
		public void SetBackgroundColor()
		{
			this.n = true;
			this.a(Attribute.BackgroundColor);
		}

		// Token: 0x06003C2F RID: 15407 RVA: 0x001FEB08 File Offset: 0x001FDB08
		public void SetBackgroundColor(RgbColor rgbColor)
		{
			this.a(Attribute.BackgroundColor, new float[]
			{
				rgbColor.R,
				rgbColor.G,
				rgbColor.B
			});
		}

		// Token: 0x06003C30 RID: 15408 RVA: 0x001FEB48 File Offset: 0x001FDB48
		public void SetBackgroundColor(float red, float green, float blue)
		{
			if (red < 0f || red > 1f || green < 0f || green > 1f || blue < 0f || blue > 1f)
			{
				throw new GeneratorException("RBG values must be from 0.0 to 1.0.");
			}
			this.a(Attribute.BackgroundColor, new float[]
			{
				red,
				green,
				blue
			});
		}

		// Token: 0x06003C31 RID: 15409 RVA: 0x001FEBBD File Offset: 0x001FDBBD
		public void SetBorderColor()
		{
			this.n = true;
			this.a(Attribute.BorderColor);
		}

		// Token: 0x06003C32 RID: 15410 RVA: 0x001FEBD0 File Offset: 0x001FDBD0
		public void SetBorderColor(float red, float green, float blue)
		{
			if (red < 0f || red > 1f || green < 0f || green > 1f || blue < 0f || blue > 1f)
			{
				throw new GeneratorException("RBG values must be from 0.0 to 1.0.");
			}
			this.a(Attribute.BorderColor, new float[]
			{
				red,
				green,
				blue
			});
		}

		// Token: 0x06003C33 RID: 15411 RVA: 0x001FEC44 File Offset: 0x001FDC44
		public void SetBorderColor(RgbColor rgbColor)
		{
			this.a(Attribute.BorderColor, new float[]
			{
				rgbColor.R,
				rgbColor.G,
				rgbColor.B
			});
		}

		// Token: 0x06003C34 RID: 15412 RVA: 0x001FEC80 File Offset: 0x001FDC80
		public void SetBorderColor(RgbColor beforeEdge, RgbColor afterEdge, RgbColor startEdge, RgbColor endEdge)
		{
			this.a(Attribute.BorderColor, new RgbColor[]
			{
				beforeEdge,
				afterEdge,
				startEdge,
				endEdge
			});
		}

		// Token: 0x06003C35 RID: 15413 RVA: 0x001FECB0 File Offset: 0x001FDCB0
		public void SetBorderStyle()
		{
			this.n = true;
			this.a(Attribute.BorderStyle);
		}

		// Token: 0x06003C36 RID: 15414 RVA: 0x001FECC6 File Offset: 0x001FDCC6
		public void SetBorderStyle(BorderStyleAttribute allEdgesValue)
		{
			this.a(Attribute.BorderStyle, allEdgesValue);
		}

		// Token: 0x06003C37 RID: 15415 RVA: 0x001FECDC File Offset: 0x001FDCDC
		public void SetBorderStyle(BorderStyleAttribute beforeEdge, BorderStyleAttribute afterEdge, BorderStyleAttribute startEdge, BorderStyleAttribute endEdge)
		{
			this.a(Attribute.BorderStyle, new string[]
			{
				beforeEdge.ToString(),
				afterEdge.ToString(),
				startEdge.ToString(),
				endEdge.ToString()
			});
		}

		// Token: 0x06003C38 RID: 15416 RVA: 0x001FED37 File Offset: 0x001FDD37
		public void SetBorderThickness()
		{
			this.n = true;
			this.a(Attribute.BorderThickness);
		}

		// Token: 0x06003C39 RID: 15417 RVA: 0x001FED4A File Offset: 0x001FDD4A
		public void SetBorderThickness(float allEdgesValue)
		{
			this.a(Attribute.BorderThickness, allEdgesValue);
		}

		// Token: 0x06003C3A RID: 15418 RVA: 0x001FED58 File Offset: 0x001FDD58
		public void SetBorderThickness(float beforeEdge, float afterEdge, float startEdge, float endEdge)
		{
			this.a(Attribute.BorderThickness, new float[]
			{
				beforeEdge,
				afterEdge,
				startEdge,
				endEdge
			});
		}

		// Token: 0x06003C3B RID: 15419 RVA: 0x001FED88 File Offset: 0x001FDD88
		public void SetColor()
		{
			this.n = true;
			this.a(Attribute.Color);
		}

		// Token: 0x06003C3C RID: 15420 RVA: 0x001FED9C File Offset: 0x001FDD9C
		public void SetColor(RgbColor rgbColor)
		{
			this.a(Attribute.Color, new float[]
			{
				rgbColor.R,
				rgbColor.G,
				rgbColor.B
			});
		}

		// Token: 0x06003C3D RID: 15421 RVA: 0x001FEDD8 File Offset: 0x001FDDD8
		public void SetColor(float red, float green, float blue)
		{
			if (red < 0f || red > 1f || green < 0f || green > 1f || blue < 0f || blue > 1f)
			{
				throw new GeneratorException("RBG values must be from 0.0 to 1.0.");
			}
			this.a(Attribute.Color, new float[]
			{
				red,
				green,
				blue
			});
		}

		// Token: 0x06003C3E RID: 15422 RVA: 0x001FEE4A File Offset: 0x001FDE4A
		public void SetPadding()
		{
			this.n = true;
			this.a(Attribute.Padding);
		}

		// Token: 0x06003C3F RID: 15423 RVA: 0x001FEE60 File Offset: 0x001FDE60
		public void SetPadding(float allEdges)
		{
			this.a(Attribute.Padding, allEdges);
		}

		// Token: 0x06003C40 RID: 15424 RVA: 0x001FEE70 File Offset: 0x001FDE70
		public void SetPadding(float beforeEdge, float afterEdge, float startEdge, float endEdge)
		{
			this.a(Attribute.Padding, new float[]
			{
				beforeEdge,
				afterEdge,
				startEdge,
				endEdge
			});
		}

		// Token: 0x06003C41 RID: 15425 RVA: 0x001FEEA3 File Offset: 0x001FDEA3
		public void SetSpaceBefore()
		{
			this.n = true;
			this.a(Attribute.SpaceBefore);
		}

		// Token: 0x06003C42 RID: 15426 RVA: 0x001FEEB9 File Offset: 0x001FDEB9
		public void SetSpaceBefore(float spaceBefore)
		{
			this.a(Attribute.SpaceBefore, spaceBefore);
		}

		// Token: 0x06003C43 RID: 15427 RVA: 0x001FEEC9 File Offset: 0x001FDEC9
		public void SetSpaceAfter()
		{
			this.n = true;
			this.a(Attribute.SpaceAfter);
		}

		// Token: 0x06003C44 RID: 15428 RVA: 0x001FEEDF File Offset: 0x001FDEDF
		public void SetSpaceAfter(float spaceAfter)
		{
			this.a(Attribute.SpaceAfter, spaceAfter);
		}

		// Token: 0x06003C45 RID: 15429 RVA: 0x001FEEEF File Offset: 0x001FDEEF
		public void SetStartIndent()
		{
			this.n = true;
			this.a(Attribute.StartIndent);
		}

		// Token: 0x06003C46 RID: 15430 RVA: 0x001FEF02 File Offset: 0x001FDF02
		public void SetStartIndent(float startIndent)
		{
			this.a(Attribute.StartIndent, startIndent);
		}

		// Token: 0x06003C47 RID: 15431 RVA: 0x001FEF0F File Offset: 0x001FDF0F
		public void SetEndIndent()
		{
			this.n = true;
			this.a(Attribute.EndIndent);
		}

		// Token: 0x06003C48 RID: 15432 RVA: 0x001FEF22 File Offset: 0x001FDF22
		public void SetEndIndent(float endIndent)
		{
			this.a(Attribute.EndIndent, endIndent);
		}

		// Token: 0x06003C49 RID: 15433 RVA: 0x001FEF2F File Offset: 0x001FDF2F
		public void SetTextIndent()
		{
			this.n = true;
			this.a(Attribute.TextIndent);
		}

		// Token: 0x06003C4A RID: 15434 RVA: 0x001FEF42 File Offset: 0x001FDF42
		public void SetTextIndent(float textIndent)
		{
			this.a(Attribute.TextIndent, textIndent);
		}

		// Token: 0x06003C4B RID: 15435 RVA: 0x001FEF4F File Offset: 0x001FDF4F
		public void SetTextAlign()
		{
			this.n = true;
			this.a(Attribute.TextAlign);
		}

		// Token: 0x06003C4C RID: 15436 RVA: 0x001FEF62 File Offset: 0x001FDF62
		public void SetTextAlign(TextAlignAttribute textAlign)
		{
			this.a(Attribute.TextAlign, textAlign);
		}

		// Token: 0x06003C4D RID: 15437 RVA: 0x001FEF74 File Offset: 0x001FDF74
		public void SetBoundingBox()
		{
			this.n = true;
			this.a(Attribute.BBox);
		}

		// Token: 0x06003C4E RID: 15438 RVA: 0x001FEF8C File Offset: 0x001FDF8C
		public void SetBoundingBox(float left, float bottom, float right, float top)
		{
			this.a(Attribute.BBox, new float[]
			{
				left,
				bottom,
				right,
				top
			});
		}

		// Token: 0x06003C4F RID: 15439 RVA: 0x001FEFC0 File Offset: 0x001FDFC0
		public void SetBoundingBox(BoundingBox bBox)
		{
			if (bBox.a() == null)
			{
				throw new GeneratorException(" Values for bounding box are not set");
			}
			this.a(Attribute.BBox, bBox.a());
		}

		// Token: 0x06003C50 RID: 15440 RVA: 0x001FEFFB File Offset: 0x001FDFFB
		public void SetWidth()
		{
			this.n = true;
			this.a(Attribute.Width);
		}

		// Token: 0x06003C51 RID: 15441 RVA: 0x001FF011 File Offset: 0x001FE011
		public void SetAutoWidth()
		{
			this.a(Attribute.Width, "Auto");
		}

		// Token: 0x06003C52 RID: 15442 RVA: 0x001FF025 File Offset: 0x001FE025
		public void SetWidth(float width)
		{
			this.a(Attribute.Width, width);
		}

		// Token: 0x06003C53 RID: 15443 RVA: 0x001FF035 File Offset: 0x001FE035
		public void SetHeight()
		{
			this.n = true;
			this.a(Attribute.Height);
		}

		// Token: 0x06003C54 RID: 15444 RVA: 0x001FF04B File Offset: 0x001FE04B
		public void SetAutoHeight()
		{
			this.a(Attribute.Height, "Auto");
		}

		// Token: 0x06003C55 RID: 15445 RVA: 0x001FF05F File Offset: 0x001FE05F
		public void SetHeight(float height)
		{
			this.a(Attribute.Height, height);
		}

		// Token: 0x06003C56 RID: 15446 RVA: 0x001FF06F File Offset: 0x001FE06F
		public void SetBlockAlign()
		{
			this.n = true;
			this.a(Attribute.BlockAlign);
		}

		// Token: 0x06003C57 RID: 15447 RVA: 0x001FF082 File Offset: 0x001FE082
		public void SetBlockAlign(BlockAlign blockAlign)
		{
			this.a(Attribute.BlockAlign, blockAlign);
		}

		// Token: 0x06003C58 RID: 15448 RVA: 0x001FF094 File Offset: 0x001FE094
		public void SetInlineAlign()
		{
			this.n = true;
			this.a(Attribute.InlineAlign);
		}

		// Token: 0x06003C59 RID: 15449 RVA: 0x001FF0A7 File Offset: 0x001FE0A7
		public void SetInlineAlign(InlineAlign inlineAlign)
		{
			this.a(Attribute.InlineAlign, inlineAlign);
		}

		// Token: 0x06003C5A RID: 15450 RVA: 0x001FF0B9 File Offset: 0x001FE0B9
		public void SetTableCellBorderStyle()
		{
			this.n = true;
			this.a(Attribute.TBorderStyle);
		}

		// Token: 0x06003C5B RID: 15451 RVA: 0x001FF0CC File Offset: 0x001FE0CC
		public void SetTableCellBorderStyle(BorderStyleAttribute tBorderStyle)
		{
			this.a(Attribute.TBorderStyle, tBorderStyle);
		}

		// Token: 0x06003C5C RID: 15452 RVA: 0x001FF0E0 File Offset: 0x001FE0E0
		public void SetTableCellBorderStyle(BorderStyleAttribute beforeEdge, BorderStyleAttribute afterEdge, BorderStyleAttribute startEdge, BorderStyleAttribute endEdge)
		{
			this.a(Attribute.BorderStyle, new string[]
			{
				beforeEdge.ToString(),
				afterEdge.ToString(),
				startEdge.ToString(),
				endEdge.ToString()
			});
		}

		// Token: 0x06003C5D RID: 15453 RVA: 0x001FF13B File Offset: 0x001FE13B
		public void SetTableCellPadding()
		{
			this.n = true;
			this.a(Attribute.TPadding);
		}

		// Token: 0x06003C5E RID: 15454 RVA: 0x001FF14E File Offset: 0x001FE14E
		public void SetTableCellPadding(float allEdges)
		{
			this.a(Attribute.Padding, allEdges);
		}

		// Token: 0x06003C5F RID: 15455 RVA: 0x001FF160 File Offset: 0x001FE160
		public void SetTableCellPadding(float beforeEdge, float afterEdge, float startEdge, float endEdge)
		{
			this.a(Attribute.Padding, new float[]
			{
				beforeEdge,
				afterEdge,
				startEdge,
				endEdge
			});
		}

		// Token: 0x06003C60 RID: 15456 RVA: 0x001FF193 File Offset: 0x001FE193
		public void SetLineHeight()
		{
			this.n = true;
			this.a(Attribute.LineHeight);
		}

		// Token: 0x06003C61 RID: 15457 RVA: 0x001FF1A6 File Offset: 0x001FE1A6
		public void SetLineHeight(LineHeight lineHeight)
		{
			this.a(Attribute.LineHeight, lineHeight);
		}

		// Token: 0x06003C62 RID: 15458 RVA: 0x001FF1B8 File Offset: 0x001FE1B8
		public void SetLineHeight(float lineHeight)
		{
			this.a(Attribute.LineHeight, lineHeight);
		}

		// Token: 0x06003C63 RID: 15459 RVA: 0x001FF1C5 File Offset: 0x001FE1C5
		public void SetBaselineShift()
		{
			this.n = true;
			this.a(Attribute.BaselineShift);
		}

		// Token: 0x06003C64 RID: 15460 RVA: 0x001FF1DB File Offset: 0x001FE1DB
		public void SetBaselineShift(float baselineShift)
		{
			this.a(Attribute.BaselineShift, baselineShift);
		}

		// Token: 0x06003C65 RID: 15461 RVA: 0x001FF1EB File Offset: 0x001FE1EB
		public void SetTextDecorationType()
		{
			this.n = true;
			this.a(Attribute.TextDecorationType);
		}

		// Token: 0x06003C66 RID: 15462 RVA: 0x001FF201 File Offset: 0x001FE201
		public void SetTextDecorationType(TextDecorationType textDecorationType)
		{
			this.a(Attribute.TextDecorationType, textDecorationType);
		}

		// Token: 0x06003C67 RID: 15463 RVA: 0x001FF216 File Offset: 0x001FE216
		public void SetTextDecorationColor()
		{
			this.n = true;
			this.a(Attribute.TextDecorationColor);
		}

		// Token: 0x06003C68 RID: 15464 RVA: 0x001FF22C File Offset: 0x001FE22C
		public void SetTextDecorationColor(RgbColor rgbColor)
		{
			this.a(Attribute.TextDecorationColor, new float[]
			{
				rgbColor.R,
				rgbColor.G,
				rgbColor.B
			});
		}

		// Token: 0x06003C69 RID: 15465 RVA: 0x001FF268 File Offset: 0x001FE268
		public void SetTextDecorationColor(float red, float green, float blue)
		{
			if (red < 0f || red > 1f || green < 0f || green > 1f || blue < 0f || blue > 1f)
			{
				throw new GeneratorException("RBG values must be from 0.0 to 1.0.");
			}
			this.a(Attribute.TextDecorationColor, new float[]
			{
				red,
				green,
				blue
			});
		}

		// Token: 0x06003C6A RID: 15466 RVA: 0x001FF2DA File Offset: 0x001FE2DA
		public void SetTextDecorationThickness()
		{
			this.n = true;
			this.a(Attribute.TextDecorationThickness);
		}

		// Token: 0x06003C6B RID: 15467 RVA: 0x001FF2ED File Offset: 0x001FE2ED
		public void SetTextDecorationThickness(float textDecorationThickness)
		{
			this.a(Attribute.TextDecorationThickness, textDecorationThickness);
		}

		// Token: 0x06003C6C RID: 15468 RVA: 0x001FF2FA File Offset: 0x001FE2FA
		public void SetColumnCount()
		{
			this.n = true;
			this.a(Attribute.ColumnCount);
		}

		// Token: 0x06003C6D RID: 15469 RVA: 0x001FF310 File Offset: 0x001FE310
		public void SetColumnCount(int columnCount)
		{
			this.a(Attribute.ColumnCount, columnCount);
		}

		// Token: 0x06003C6E RID: 15470 RVA: 0x001FF320 File Offset: 0x001FE320
		public void SetColumnWidths()
		{
			this.n = true;
			this.a(Attribute.ColumnWidths);
		}

		// Token: 0x06003C6F RID: 15471 RVA: 0x001FF336 File Offset: 0x001FE336
		public void SetColumnWidths(float columnWidths)
		{
			this.a(Attribute.ColumnWidths, columnWidths);
		}

		// Token: 0x06003C70 RID: 15472 RVA: 0x001FF346 File Offset: 0x001FE346
		public void SetColumnWidths(float[] columnWidths)
		{
			this.a(Attribute.ColumnWidths, columnWidths);
		}

		// Token: 0x06003C71 RID: 15473 RVA: 0x001FF356 File Offset: 0x001FE356
		public void SetColumnGap()
		{
			this.n = true;
			this.a(Attribute.ColumnGap);
		}

		// Token: 0x06003C72 RID: 15474 RVA: 0x001FF36C File Offset: 0x001FE36C
		public void SetColumnGap(float columnGap)
		{
			this.a(Attribute.ColumnGap, columnGap);
		}

		// Token: 0x06003C73 RID: 15475 RVA: 0x001FF37C File Offset: 0x001FE37C
		public void SetColumnGap(float[] columnGap)
		{
			this.a(Attribute.ColumnGap, columnGap);
		}

		// Token: 0x06003C74 RID: 15476 RVA: 0x001FF38C File Offset: 0x001FE38C
		public void SetGlyphOrientationVertical()
		{
			this.n = true;
			this.a(Attribute.GlyphOrientationVertical);
		}

		// Token: 0x06003C75 RID: 15477 RVA: 0x001FF39F File Offset: 0x001FE39F
		public void SetAutoGlyphOrientationVertical()
		{
			this.a(Attribute.GlyphOrientationVertical, "Auto");
		}

		// Token: 0x06003C76 RID: 15478 RVA: 0x001FF3B0 File Offset: 0x001FE3B0
		public void SetAutoGlyphOrientationVertical(int angle)
		{
			if (angle % 90 == 0 && -180 >= angle && angle <= 360)
			{
				this.a(Attribute.GlyphOrientationVertical, angle);
				return;
			}
			throw new GeneratorException(" Angle should be multiple of 90 and between -180 and +360");
		}

		// Token: 0x06003C77 RID: 15479 RVA: 0x001FF3F3 File Offset: 0x001FE3F3
		public void SetRubyAlign()
		{
			this.n = true;
			this.a(Attribute.RubyAlign);
		}

		// Token: 0x06003C78 RID: 15480 RVA: 0x001FF406 File Offset: 0x001FE406
		public void SetRubyAlign(RubyAlign rubyAlign)
		{
			this.a(Attribute.RubyAlign, rubyAlign);
		}

		// Token: 0x06003C79 RID: 15481 RVA: 0x001FF418 File Offset: 0x001FE418
		public void SetRubyPosition()
		{
			this.n = true;
			this.a(Attribute.RubyPosition);
		}

		// Token: 0x06003C7A RID: 15482 RVA: 0x001FF42B File Offset: 0x001FE42B
		public void SetRubyPosition(RubyPosition rubyPosition)
		{
			this.a(Attribute.RubyPosition, rubyPosition);
		}

		// Token: 0x06003C7B RID: 15483 RVA: 0x001FF43D File Offset: 0x001FE43D
		public void SetRole(Role role)
		{
			this.a(Attribute.Role, role);
		}

		// Token: 0x06003C7C RID: 15484 RVA: 0x001FF44F File Offset: 0x001FE44F
		public void SetChecked()
		{
			this.n = true;
			this.a(Attribute.Checked);
		}

		// Token: 0x06003C7D RID: 15485 RVA: 0x001FF462 File Offset: 0x001FE462
		public void SetChecked(Checked checkedValue)
		{
			this.a(Attribute.Checked, checkedValue);
		}

		// Token: 0x06003C7E RID: 15486 RVA: 0x001FF474 File Offset: 0x001FE474
		public void SetDescription(string desc)
		{
			this.a(Attribute.Desc, desc);
		}

		// Token: 0x06003C7F RID: 15487 RVA: 0x001FF481 File Offset: 0x001FE481
		public void SetListNumbering()
		{
			this.n = true;
			this.a(Attribute.ListNumbering);
		}

		// Token: 0x06003C80 RID: 15488 RVA: 0x001FF494 File Offset: 0x001FE494
		public void SetListNumbering(ListNumbering listNumbering)
		{
			this.a(Attribute.ListNumbering, listNumbering);
		}

		// Token: 0x06003C81 RID: 15489 RVA: 0x001FF4A6 File Offset: 0x001FE4A6
		public void SetRowSpan()
		{
			this.n = true;
			this.a(Attribute.RowSpan);
		}

		// Token: 0x06003C82 RID: 15490 RVA: 0x001FF4B9 File Offset: 0x001FE4B9
		public void SetRowSpan(int rowSpan)
		{
			this.a(Attribute.RowSpan, rowSpan);
		}

		// Token: 0x06003C83 RID: 15491 RVA: 0x001FF4C6 File Offset: 0x001FE4C6
		public void SetColumnSpan()
		{
			this.n = true;
			this.a(Attribute.ColSpan);
		}

		// Token: 0x06003C84 RID: 15492 RVA: 0x001FF4D9 File Offset: 0x001FE4D9
		public void SetColumnSpan(int colSpan)
		{
			this.a(Attribute.ColSpan, colSpan);
		}

		// Token: 0x06003C85 RID: 15493 RVA: 0x001FF4E6 File Offset: 0x001FE4E6
		public void SetHeaders()
		{
			this.n = true;
			this.a(Attribute.Headers);
		}

		// Token: 0x06003C86 RID: 15494 RVA: 0x001FF4F9 File Offset: 0x001FE4F9
		public void SetHeaders(string[] headers)
		{
			this.a(Attribute.Headers, headers);
		}

		// Token: 0x06003C87 RID: 15495 RVA: 0x001FF506 File Offset: 0x001FE506
		public void SetScope()
		{
			this.n = true;
			this.a(Attribute.Scope);
		}

		// Token: 0x06003C88 RID: 15496 RVA: 0x001FF519 File Offset: 0x001FE519
		public void SetScope(Scope scope)
		{
			this.a(Attribute.Scope, scope);
		}

		// Token: 0x06003C89 RID: 15497 RVA: 0x001FF52B File Offset: 0x001FE52B
		public void SetSummary(string summary)
		{
			this.a(Attribute.Summary, summary);
		}

		// Token: 0x06003C8A RID: 15498 RVA: 0x001FF538 File Offset: 0x001FE538
		private void a(Attribute A_0)
		{
			if (this.m.Contains(A_0))
			{
				this.m[A_0] = null;
			}
			else
			{
				this.m.Add(A_0, null);
			}
		}

		// Token: 0x06003C8B RID: 15499 RVA: 0x001FF588 File Offset: 0x001FE588
		private void a(Attribute A_0, object A_1)
		{
			if (this.m.Contains(A_0))
			{
				this.m[A_0] = new AttributeObject.g(A_1);
			}
			else
			{
				this.m.Add(A_0, new AttributeObject.g(A_1));
			}
		}

		// Token: 0x06003C8C RID: 15500 RVA: 0x001FF5E4 File Offset: 0x001FE5E4
		private void a(Attribute A_0, float[] A_1)
		{
			if (this.m.Contains(A_0))
			{
				this.m[A_0] = new AttributeObject.b(A_1);
			}
			else
			{
				this.m.Add(A_0, new AttributeObject.b(A_1));
			}
		}

		// Token: 0x06003C8D RID: 15501 RVA: 0x001FF640 File Offset: 0x001FE640
		private void a(Attribute A_0, float A_1)
		{
			if (this.m.Contains(A_0))
			{
				this.m[A_0] = new AttributeObject.d(A_1);
			}
			else
			{
				this.m.Add(A_0, new AttributeObject.d(A_1));
			}
		}

		// Token: 0x06003C8E RID: 15502 RVA: 0x001FF69C File Offset: 0x001FE69C
		private void a(Attribute A_0, int A_1)
		{
			if (this.m.Contains(A_0))
			{
				this.m[A_0] = new AttributeObject.e(A_1);
			}
			else
			{
				this.m.Add(A_0, new AttributeObject.e(A_1));
			}
		}

		// Token: 0x06003C8F RID: 15503 RVA: 0x001FF6F8 File Offset: 0x001FE6F8
		private void a(Attribute A_0, string A_1)
		{
			if (this.m.Contains(A_0))
			{
				this.m[A_0] = new AttributeObject.f(A_1);
			}
			else
			{
				this.m.Add(A_0, new AttributeObject.f(A_1));
			}
		}

		// Token: 0x06003C90 RID: 15504 RVA: 0x001FF754 File Offset: 0x001FE754
		private void a(Attribute A_0, string[] A_1)
		{
			if (this.m.Contains(A_0))
			{
				this.m[A_0] = new AttributeObject.c(A_1);
			}
			else
			{
				this.m.Add(A_0, new AttributeObject.c(A_1));
			}
		}

		// Token: 0x06003C91 RID: 15505 RVA: 0x001FF7B0 File Offset: 0x001FE7B0
		private void a(Attribute A_0, RgbColor[] A_1)
		{
			if (this.m.Contains(A_0))
			{
				this.m[A_0] = new AttributeObject.h(A_1);
			}
			else
			{
				this.m.Add(A_0, new AttributeObject.h(A_1));
			}
		}

		// Token: 0x06003C92 RID: 15506 RVA: 0x001FF80C File Offset: 0x001FE80C
		internal override void j(DocumentWriter A_0)
		{
			if (this.m.Count > 0)
			{
				A_0.WriteDictionaryOpen();
				A_0.WriteName(79);
				switch (this.l)
				{
				case AttributeOwner.Layout:
					A_0.WriteName(AttributeObject.a);
					break;
				case AttributeOwner.List:
					A_0.WriteName(AttributeObject.b);
					break;
				case AttributeOwner.PrintField:
					A_0.WriteName(AttributeObject.c);
					break;
				case AttributeOwner.Table:
					A_0.WriteName(AttributeObject.d);
					break;
				case AttributeOwner.XML_1_00:
					A_0.WriteName(AttributeObject.e);
					break;
				case AttributeOwner.HTML_3_20:
					A_0.WriteName(AttributeObject.f);
					break;
				case AttributeOwner.HTML_4_01:
					A_0.WriteName(AttributeObject.g);
					break;
				case AttributeOwner.OEB_1_00:
					A_0.WriteName(AttributeObject.h);
					break;
				case AttributeOwner.RTF_1_05:
					A_0.WriteName(AttributeObject.i);
					break;
				case AttributeOwner.CSS_1_00:
					A_0.WriteName(AttributeObject.j);
					break;
				case AttributeOwner.CSS_2_00:
					A_0.WriteName(AttributeObject.k);
					break;
				}
				IDictionaryEnumerator enumerator = this.m.GetEnumerator();
				while (enumerator.MoveNext())
				{
					A_0.WriteName(enumerator.Key.ToString());
					((AttributeObject.a)enumerator.Value).l(A_0);
				}
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x06003C93 RID: 15507 RVA: 0x001FF964 File Offset: 0x001FE964
		internal AttributeObject a(HybridDictionary A_0)
		{
			AttributeObject attributeObject = new AttributeObject(this.Owner);
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			foreach (Attribute attribute in array)
			{
				if (attribute > (Attribute)200)
				{
					if (A_0 != null && A_0[attribute] == this.m[attribute])
					{
						attributeObject.m.Add(attribute, null);
						attributeObject.n = true;
					}
					else
					{
						attributeObject.m.Add(attribute, this.m[attribute]);
						if (this.m[attribute] == null)
						{
							attributeObject.n = true;
						}
					}
				}
			}
			return (attributeObject.m.Count != 0) ? attributeObject : null;
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06003C94 RID: 15508 RVA: 0x001FFA90 File Offset: 0x001FEA90
		public override AttributeOwner Owner
		{
			get
			{
				return this.l;
			}
		}

		// Token: 0x06003C95 RID: 15509 RVA: 0x001FFAA8 File Offset: 0x001FEAA8
		internal bool d()
		{
			return this.n;
		}

		// Token: 0x06003C96 RID: 15510 RVA: 0x001FFAC0 File Offset: 0x001FEAC0
		internal void b(TaggablePageElement A_0, PageWriter A_1)
		{
			byte b = A_0.cb();
			switch (b)
			{
			case 32:
				this.a(A_1, (BarCode)A_0);
				break;
			case 33:
				this.a(A_1, (Dim2Barcode)A_0);
				break;
			case 34:
				this.a(A_1, (StackedGS1DataBar)A_0);
				break;
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 58:
			case 59:
			case 60:
			case 61:
			case 62:
			case 63:
				break;
			case 48:
				this.a(A_1, (Table)A_0);
				break;
			case 49:
				this.a(A_1, (Rectangle)A_0);
				break;
			case 50:
				this.a(A_1, (Path)A_0);
				break;
			case 51:
				this.a(A_1, (PageNumberingLabel)A_0);
				break;
			case 52:
				this.a(A_1, (Note)A_0);
				break;
			case 53:
				this.a(A_1, (Link)A_0);
				break;
			case 54:
				this.a(A_1, (Line)A_0);
				break;
			case 55:
				this.a(A_1, (Image)A_0);
				break;
			case 56:
				this.a(A_1, (Circle)A_0);
				break;
			case 57:
				this.a(A_1, (BackgroundImage)A_0);
				break;
			case 64:
				this.a(A_1, (FormElement)A_0);
				break;
			case 65:
				this.a(A_1, (TextArea)A_0);
				break;
			case 66:
				this.a(A_1, (Label)A_0);
				break;
			case 67:
				this.a(A_1, (FormattedTextArea)A_0);
				break;
			case 68:
				this.a(A_1, (Chart)A_0);
				break;
			case 69:
				this.a(A_1, (ceTe.DynamicPDF.ReportWriter.Layout.LayoutTextArea)A_0, null);
				break;
			case 70:
				this.a(A_1, null, (xy)A_0);
				break;
			default:
				if (b != 80)
				{
					if (b == 96)
					{
						this.a(A_1, (List)A_0);
					}
				}
				else
				{
					this.a(A_1, (Table2)A_0);
				}
				break;
			}
		}

		// Token: 0x06003C97 RID: 15511 RVA: 0x001FFD18 File Offset: 0x001FED18
		private void a(PageWriter A_0, PageNumberingLabel A_1)
		{
			if (A_1.Underline)
			{
				if (this.m[Attribute.TextDecorationType] == null)
				{
					this.m[Attribute.TextDecorationType] = this.a(A_1, A_0, Attribute.TextDecorationType);
				}
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.TextAlign] == null)
				{
					this.m[Attribute.TextAlign] = this.a(A_1, A_0, Attribute.TextAlign);
				}
				if (this.m[Attribute.StartIndent] == null)
				{
					this.m[Attribute.StartIndent] = this.a(A_1, A_0, Attribute.StartIndent);
				}
				if (this.m[Attribute.EndIndent] == null)
				{
					this.m[Attribute.EndIndent] = this.a(A_1, A_0, Attribute.EndIndent);
				}
			}
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, b);
			}
			else
			{
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (!((StructureElement)A_1.Tag).o().Contains(300))
			{
				object value = this.a(A_1, A_0, Attribute.Height);
				((StructureElement)A_1.Tag).o().Add(300, b);
				((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
			}
			else
			{
				this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
			}
			if (!((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
			{
				object value = this.a(A_1, A_0, Attribute.Width);
				((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
			}
			else
			{
				this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
			}
			this.o = true;
		}

		// Token: 0x06003C98 RID: 15512 RVA: 0x001FFFC0 File Offset: 0x001FEFC0
		private void a(PageNumberingLabel A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object obj = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = obj;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								AttributeObject.b value = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, A_0.Angle).a());
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, value);
								}
								if (obj == null && array[i] == Attribute.Height)
								{
									obj = new AttributeObject.d(A_0.Height);
								}
								else if (obj == null && array[i] == Attribute.Width)
								{
									obj = new AttributeObject.d(A_0.Width);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
						}
						else
						{
							obj = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = obj;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					AttributeObject.b a_2 = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, A_0.Angle).a());
					a_ = this.a((StructureElement)A_0.Tag, array[i], a_2, a_);
				}
			}
		}

		// Token: 0x06003C99 RID: 15513 RVA: 0x00200324 File Offset: 0x001FF324
		private object a(PageNumberingLabel A_0, PageWriter A_1, Attribute A_2)
		{
			switch (A_2)
			{
			case Attribute.Color:
			{
				RgbColor rgbColor = A_0.TextColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.StartIndent:
				return new AttributeObject.d(A_1.Page.Dimensions.Edge.Left + A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y));
			case Attribute.EndIndent:
				return new AttributeObject.d(A_1.Page.Dimensions.Width - (A_1.Page.Dimensions.Edge.Left + A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y) + A_0.Width));
			case Attribute.TextIndent:
				break;
			case Attribute.TextAlign:
				switch (A_0.Align)
				{
				case TextAlign.Left:
					return new AttributeObject.g(TextAlignAttribute.Start);
				case TextAlign.Center:
					return new AttributeObject.g(TextAlignAttribute.Center);
				case TextAlign.Right:
					return new AttributeObject.g(TextAlignAttribute.End);
				case TextAlign.Justify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				case TextAlign.FullJustify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				default:
					return string.Empty;
				}
				break;
			default:
				if (A_2 == Attribute.TextDecorationColor)
				{
					RgbColor rgbColor = A_0.TextColor.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				switch (A_2)
				{
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, A_0.Angle).a());
				case Attribute.Width:
					return new AttributeObject.d(A_0.Width);
				case Attribute.Height:
					return new AttributeObject.d(A_0.Height);
				case Attribute.TextDecorationType:
					return new AttributeObject.g(A_0.Underline ? TextDecorationType.Underline : TextDecorationType.None);
				}
				break;
			}
			return this.a(A_2, A_1);
		}

		// Token: 0x06003C9A RID: 15514 RVA: 0x002005EC File Offset: 0x001FF5EC
		private void a(PageWriter A_0, BackgroundImage A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003C9B RID: 15515 RVA: 0x0020099C File Offset: 0x001FF99C
		private object a(BackgroundImage A_0, PageWriter A_1, Attribute A_2)
		{
			float num;
			float num2;
			float a_;
			float a_2;
			if (A_0.UseMargins)
			{
				num = A_1.Dimensions.Body.Width - (float)A_0.RightPadding - (float)A_0.LeftPadding;
				num2 = A_1.Dimensions.Body.Height - (float)A_0.TopPadding - (float)A_0.BottomPadding;
				a_ = (float)A_0.LeftPadding;
				a_2 = (float)A_0.TopPadding;
			}
			else
			{
				num = A_1.Dimensions.Edge.Width - (float)A_0.RightPadding - (float)A_0.LeftPadding;
				num2 = A_1.Dimensions.Edge.Height - (float)A_0.TopPadding - (float)A_0.BottomPadding;
				a_ = A_1.Dimensions.Edge.Left + (float)A_0.LeftPadding;
				a_2 = A_1.Dimensions.Edge.Top + (float)A_0.TopPadding;
			}
			object result;
			switch (A_2)
			{
			case Attribute.BBox:
				result = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, a_, a_2), A_1.Dimensions.a4(A_1.Page.Dimensions, a_, a_2), num, num2, 0f).a());
				break;
			case Attribute.Width:
				result = new AttributeObject.d(num);
				break;
			case Attribute.Height:
				result = new AttributeObject.d(num2);
				break;
			default:
				result = this.a(A_2, A_1);
				break;
			}
			return result;
		}

		// Token: 0x06003C9C RID: 15516 RVA: 0x00200B18 File Offset: 0x001FFB18
		private void a(BackgroundImage A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003C9D RID: 15517 RVA: 0x00200D64 File Offset: 0x001FFD64
		private void a(PageWriter A_0, List A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003C9E RID: 15518 RVA: 0x00201114 File Offset: 0x00200114
		private object a(List A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			if (A_2 != Attribute.WritingMode)
			{
				switch (A_2)
				{
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, A_0.Angle).a());
				case Attribute.Width:
					return new AttributeObject.d(A_0.Width);
				case Attribute.Height:
					return new AttributeObject.d(A_0.Height);
				case Attribute.TextDecorationType:
					return new AttributeObject.g(A_0.StrikeThrough ? TextDecorationType.LineThrough : TextDecorationType.None);
				}
				result = this.a(A_2, A_1);
			}
			else
			{
				result = new AttributeObject.g(A_0.RightToLeft ? WritingMode.RlTb : WritingMode.LrTb);
			}
			return result;
		}

		// Token: 0x06003C9F RID: 15519 RVA: 0x0020121C File Offset: 0x0020021C
		private void a(List A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								AttributeObject.b value2 = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Page.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, A_0.Angle).a());
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, value2);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					AttributeObject.b a_2 = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, A_0.Angle).a());
					a_ = this.a((StructureElement)A_0.Tag, array[i], a_2, a_);
				}
			}
		}

		// Token: 0x06003CA0 RID: 15520 RVA: 0x00201538 File Offset: 0x00200538
		private void a(PageWriter A_0, Dim2Barcode A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CA1 RID: 15521 RVA: 0x002018E8 File Offset: 0x002008E8
		private object a(Dim2Barcode A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			if (A_2 != Attribute.Color)
			{
				switch (A_2)
				{
				case Attribute.BBox:
					result = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.GetSymbolWidth(), A_0.GetSymbolHeight(), A_0.Angle).a());
					break;
				case Attribute.Width:
					result = new AttributeObject.d(A_0.GetSymbolWidth());
					break;
				case Attribute.Height:
					result = new AttributeObject.d(A_0.GetSymbolHeight());
					break;
				default:
					result = this.a(A_2, A_1);
					break;
				}
			}
			else
			{
				RgbColor rgbColor = A_0.Color.m();
				result = new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			return result;
		}

		// Token: 0x06003CA2 RID: 15522 RVA: 0x002019EC File Offset: 0x002009EC
		private void a(Dim2Barcode A_0, PageWriter A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CA3 RID: 15523 RVA: 0x00201C38 File Offset: 0x00200C38
		private void a(PageWriter A_0, BarCode A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Height))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CA4 RID: 15524 RVA: 0x00201FE8 File Offset: 0x00200FE8
		private void a(PageWriter A_0, StackedGS1DataBar A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Height))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CA5 RID: 15525 RVA: 0x00202398 File Offset: 0x00201398
		private object a(BarCode A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			if (A_2 != Attribute.Color)
			{
				switch (A_2)
				{
				case Attribute.BBox:
					result = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.GetSymbolWidth(), A_0.Height, A_0.Angle).a());
					break;
				case Attribute.Width:
					result = new AttributeObject.d(A_0.GetSymbolWidth());
					break;
				case Attribute.Height:
					result = new AttributeObject.d(A_0.Height);
					break;
				default:
					result = this.a(A_2, A_1);
					break;
				}
			}
			else
			{
				RgbColor rgbColor = A_0.Color.m();
				result = new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			return result;
		}

		// Token: 0x06003CA6 RID: 15526 RVA: 0x0020249C File Offset: 0x0020149C
		private object a(StackedGS1DataBar A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			if (A_2 != Attribute.Color)
			{
				switch (A_2)
				{
				case Attribute.BBox:
					result = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.GetSymbolWidth(), A_0.GetSymbolHeight(), A_0.Angle).a());
					break;
				case Attribute.Width:
					result = new AttributeObject.d(A_0.GetSymbolWidth());
					break;
				case Attribute.Height:
					result = new AttributeObject.d(A_0.GetSymbolHeight());
					break;
				default:
					result = this.a(A_2, A_1);
					break;
				}
			}
			else
			{
				RgbColor rgbColor = A_0.Color.m();
				result = new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			return result;
		}

		// Token: 0x06003CA7 RID: 15527 RVA: 0x002025A0 File Offset: 0x002015A0
		private void a(BarCode A_0, PageWriter A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CA8 RID: 15528 RVA: 0x002027EC File Offset: 0x002017EC
		private void a(StackedGS1DataBar A_0, PageWriter A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CA9 RID: 15529 RVA: 0x00202A38 File Offset: 0x00201A38
		private void a(PageWriter A_0, Chart A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (A_1.Tag == null || (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox)))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				if (A_1.Tag != null)
				{
					((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
				}
			}
			else if (A_1.Tag != null && this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag != null && A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (A_1.Tag == null || (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300)))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(300, b);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (A_1.Tag == null || (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width)))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CAA RID: 15530 RVA: 0x00202E6C File Offset: 0x00201E6C
		private object a(Chart A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			switch (A_2)
			{
			case Attribute.BorderColor:
			{
				RgbColor rgbColor = A_0.BackgroundColor.m();
				result = new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
				break;
			}
			case Attribute.BorderThickness:
				result = new AttributeObject.d(A_0.BorderWidth);
				break;
			default:
				if (A_2 != Attribute.TextDecorationColor)
				{
					switch (A_2)
					{
					case Attribute.BackgroundColor:
					{
						RgbColor rgbColor = A_0.BackgroundColor.m();
						return new AttributeObject.b(new float[]
						{
							rgbColor.R,
							rgbColor.G,
							rgbColor.B
						});
					}
					case Attribute.BorderStyle:
						if (A_0.BorderStyle == LineStyle.Solid)
						{
							return new AttributeObject.g(BorderStyleAttribute.Solid);
						}
						if (A_0.BorderStyle == LineStyle.Dots)
						{
							return new AttributeObject.g(BorderStyleAttribute.Dotted);
						}
						return new AttributeObject.g(BorderStyleAttribute.Dashed);
					case Attribute.BBox:
						return new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, A_0.Angle).a());
					case Attribute.Width:
						return new AttributeObject.d(A_0.Width);
					case Attribute.Height:
						return new AttributeObject.d(A_0.Height);
					}
					result = this.a(A_2, A_1);
				}
				else
				{
					RgbColor rgbColor = A_0.TextColor.m();
					result = new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				break;
			}
			return result;
		}

		// Token: 0x06003CAB RID: 15531 RVA: 0x00203078 File Offset: 0x00202078
		private void a(Chart A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CAC RID: 15532 RVA: 0x002032C4 File Offset: 0x002022C4
		private void a(PageWriter A_0, Path A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CAD RID: 15533 RVA: 0x00203674 File Offset: 0x00202674
		private object a(Path A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			if (A_2 != Attribute.BorderColor)
			{
				if (A_2 != Attribute.BackgroundColor)
				{
					switch (A_2)
					{
					case Attribute.BBox:
						result = new AttributeObject.b(A_0.a(A_1, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y)));
						break;
					case Attribute.Width:
					{
						float[] array = A_0.a(A_1, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y));
						result = new AttributeObject.d(array[2] - array[0]);
						break;
					}
					case Attribute.Height:
					{
						float[] array = A_0.a(A_1, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y));
						result = new AttributeObject.d(array[3] - array[1]);
						break;
					}
					default:
						result = this.a(A_2, A_1);
						break;
					}
				}
				else
				{
					RgbColor rgbColor = A_0.FillColor.m();
					result = new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
			}
			else
			{
				RgbColor rgbColor = A_0.FillColor.m();
				result = new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			return result;
		}

		// Token: 0x06003CAE RID: 15534 RVA: 0x00203844 File Offset: 0x00202844
		private void a(Path A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CAF RID: 15535 RVA: 0x00203A90 File Offset: 0x00202A90
		private void a(PageWriter A_0, Line A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CB0 RID: 15536 RVA: 0x00203E40 File Offset: 0x00202E40
		private object a(Line A_0, PageWriter A_1, Attribute A_2)
		{
			switch (A_2)
			{
			case Attribute.BorderColor:
			{
				RgbColor rgbColor = A_0.Color.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.BorderThickness:
				break;
			case Attribute.Color:
			{
				RgbColor rgbColor = A_0.Color.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			default:
				switch (A_2)
				{
				case Attribute.BackgroundColor:
				{
					RgbColor rgbColor = A_0.Color.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				case Attribute.BorderStyle:
					if (A_0.Style == LineStyle.Solid)
					{
						return new AttributeObject.g(BorderStyleAttribute.Solid);
					}
					if (A_0.Style == LineStyle.Dots)
					{
						return new AttributeObject.g(BorderStyleAttribute.Dotted);
					}
					return new AttributeObject.g(BorderStyleAttribute.Dashed);
				case Attribute.BBox:
					return new AttributeObject.b(new float[]
					{
						A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X1, A_0.Y1),
						A_1.Page.Dimensions.Height - A_1.Page.Dimensions.TopMargin - A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X2, A_0.Y2),
						A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X2, A_0.Y2),
						A_1.Page.Dimensions.Height - A_1.Page.Dimensions.TopMargin - A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X1, A_0.Y1)
					});
				case Attribute.Width:
					return new AttributeObject.d(A_0.Y2 - A_0.Y1);
				case Attribute.Height:
					return new AttributeObject.d(A_0.X2 - A_0.X1);
				}
				break;
			}
			return this.a(A_2, A_1);
		}

		// Token: 0x06003CB1 RID: 15537 RVA: 0x002040E0 File Offset: 0x002030E0
		private void a(Line A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CB2 RID: 15538 RVA: 0x0020432C File Offset: 0x0020332C
		private void a(PageWriter A_0, Circle A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CB3 RID: 15539 RVA: 0x002046DC File Offset: 0x002036DC
		private object a(Circle A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			switch (A_2)
			{
			case Attribute.BorderColor:
			{
				RgbColor rgbColor = A_0.BorderColor.m();
				result = new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
				break;
			}
			case Attribute.BorderThickness:
				result = new AttributeObject.d(A_0.BorderWidth);
				break;
			default:
				switch (A_2)
				{
				case Attribute.BackgroundColor:
				{
					RgbColor rgbColor = A_0.FillColor.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				case Attribute.BorderStyle:
					if (A_0.BorderStyle == LineStyle.Solid)
					{
						return new AttributeObject.g(BorderStyleAttribute.Solid);
					}
					if (A_0.BorderStyle == LineStyle.Dots)
					{
						return new AttributeObject.g(BorderStyleAttribute.Dotted);
					}
					return new AttributeObject.g(BorderStyleAttribute.Dashed);
				case Attribute.BBox:
					return new AttributeObject.b(new float[]
					{
						A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y) - A_0.RadiusX,
						A_1.Page.Dimensions.Height - A_1.Page.Dimensions.TopMargin - A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y) - A_0.RadiusY,
						A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y) + A_0.RadiusX,
						A_1.Page.Dimensions.Height - A_1.Page.Dimensions.TopMargin - A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y) + A_0.RadiusY
					});
				case Attribute.Width:
					return new AttributeObject.d(2f * A_0.RadiusX);
				case Attribute.Height:
					return new AttributeObject.d(2f * A_0.RadiusY);
				}
				result = this.a(A_2, A_1);
				break;
			}
			return result;
		}

		// Token: 0x06003CB4 RID: 15540 RVA: 0x00204968 File Offset: 0x00203968
		private void a(Circle A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CB5 RID: 15541 RVA: 0x00204BB4 File Offset: 0x00203BB4
		private void a(PageWriter A_0, Rectangle A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CB6 RID: 15542 RVA: 0x00204F64 File Offset: 0x00203F64
		private object a(Rectangle A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			switch (A_2)
			{
			case Attribute.BorderColor:
			{
				RgbColor rgbColor = A_0.BorderColor.m();
				result = new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
				break;
			}
			case Attribute.BorderThickness:
				result = new AttributeObject.d(A_0.BorderWidth);
				break;
			default:
				switch (A_2)
				{
				case Attribute.BackgroundColor:
				{
					RgbColor rgbColor = A_0.FillColor.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				case Attribute.BorderStyle:
					if (A_0.BorderStyle == LineStyle.Solid)
					{
						return new AttributeObject.g(BorderStyleAttribute.Solid);
					}
					if (A_0.BorderStyle == LineStyle.Dots)
					{
						return new AttributeObject.g(BorderStyleAttribute.Dotted);
					}
					return new AttributeObject.g(BorderStyleAttribute.Dashed);
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, A_0.Angle).a());
				case Attribute.Width:
					return new AttributeObject.d(A_0.Width);
				case Attribute.Height:
					return new AttributeObject.d(A_0.Height);
				}
				result = this.a(A_2, A_1);
				break;
			}
			return result;
		}

		// Token: 0x06003CB7 RID: 15543 RVA: 0x0020512C File Offset: 0x0020412C
		private void a(Rectangle A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CB8 RID: 15544 RVA: 0x00205378 File Offset: 0x00204378
		internal void a(PageWriter A_0, ListItem A_1, float A_2, float A_3, bool A_4)
		{
			if (A_4)
			{
				if (this.m[Attribute.StartIndent] == null)
				{
					this.m[Attribute.StartIndent] = this.a(A_1, A_2, A_3, A_0, Attribute.StartIndent);
				}
				if (this.m[Attribute.SpaceAfter] == null)
				{
					this.m[Attribute.SpaceAfter] = this.a(A_1, A_2, A_3, A_0, Attribute.SpaceAfter);
				}
				if (this.m[Attribute.EndIndent] == null)
				{
					this.m[Attribute.EndIndent] = this.a(A_1, A_2, A_3, A_0, Attribute.EndIndent);
				}
				AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_2, A_3, A_0, Attribute.BBox);
				if (!((StructureElement)A_1.ListItemTag).o().Contains(Attribute.BBox))
				{
					((StructureElement)A_1.ListItemTag).o().Add(Attribute.BBox, b);
				}
				else
				{
					this.a((StructureElement)A_1.ListItemTag, Attribute.BBox, b, false);
				}
				if (!((StructureElement)A_1.ListItemTag).o().Contains(300))
				{
					object value = this.a(A_1, A_2, A_3, A_0, Attribute.Height);
					((StructureElement)A_1.ListItemTag).o().Add(300, b);
					((StructureElement)A_1.ListItemTag).o().Add(Attribute.Height, value);
				}
				else
				{
					this.a((StructureElement)A_1.ListItemTag, Attribute.Height, b, false);
				}
				if (!((StructureElement)A_1.ListItemTag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_2, A_3, A_0, Attribute.Width);
					((StructureElement)A_1.ListItemTag).o().Add(Attribute.Width, value);
				}
				else
				{
					this.a((StructureElement)A_1.ListItemTag, Attribute.Width, b, true);
				}
				this.o = true;
			}
			else
			{
				if (A_1.Tag != null)
				{
					AttributeObject.b b = new AttributeObject.b(new BoundingBox(A_0.Page, A_0.Dimensions.a3(A_0.Page.Dimensions, A_2, A_3), A_0.Dimensions.a4(A_0.Page.Dimensions, A_2, A_3), A_1.h(), A_1.a(null), 0f).a());
					if (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
					{
						this.m[Attribute.BBox] = b;
						((StructureElement)A_1.Tag).o().Add(Attribute.BBox, b);
					}
					else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox] && this.m[Attribute.BBox] != null)
					{
						this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
						this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
					}
					if (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300))
					{
						object value = new AttributeObject.d(A_1.a(null));
						this.m[Attribute.Height] = value;
						((StructureElement)A_1.Tag).o().Add(300, b);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
					}
					else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height] && this.m[Attribute.Height] != null)
					{
						this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
						this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
					}
					if (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
					{
						object value = new AttributeObject.d(A_1.h());
						this.m[Attribute.Width] = value;
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
					}
					else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width] && this.m[Attribute.Width] != null)
					{
						this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
						this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
					}
					this.o = true;
				}
				if (this.m[Attribute.TextDecorationType] == null)
				{
					this.m[Attribute.TextDecorationType] = this.a(A_1, A_2, A_3, A_0, Attribute.TextDecorationType);
				}
			}
		}

		// Token: 0x06003CB9 RID: 15545 RVA: 0x00205A3C File Offset: 0x00204A3C
		private object a(ListItem A_0, float A_1, float A_2, PageWriter A_3, Attribute A_4)
		{
			switch (A_4)
			{
			case Attribute.WritingMode:
				return new AttributeObject.g(A_0.RightToLeft ? WritingMode.RlTb : WritingMode.LrTb);
			case Attribute.BorderColor:
			case Attribute.BorderThickness:
			case Attribute.BlockAlign:
			case Attribute.InlineAlign:
			case Attribute.TBorderStyle:
			case Attribute.TPadding:
				break;
			case Attribute.Color:
			{
				RgbColor rgbColor = A_0.TextColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.StartIndent:
				return new AttributeObject.d(A_3.Page.Dimensions.LeftMargin + A_3.Dimensions.a3(A_3.Page.Dimensions, A_1, A_2));
			case Attribute.EndIndent:
				return new AttributeObject.d(A_3.Page.Dimensions.Width - (A_3.Page.Dimensions.Edge.Left + A_3.Page.Dimensions.LeftMargin + A_3.Dimensions.a3(A_3.Page.Dimensions, A_1, A_2) + A_0.h()));
			case Attribute.TextIndent:
				return new AttributeObject.d(A_0.ParagraphIndent);
			case Attribute.TextAlign:
				switch (A_0.TextAlign)
				{
				case TextAlign.Left:
					return new AttributeObject.g(TextAlignAttribute.Start);
				case TextAlign.Center:
					return new AttributeObject.g(TextAlignAttribute.Center);
				case TextAlign.Right:
					return new AttributeObject.g(TextAlignAttribute.End);
				case TextAlign.Justify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				case TextAlign.FullJustify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				default:
					return null;
				}
				break;
			case Attribute.LineHeight:
				return new AttributeObject.d(A_0.Leading);
			case Attribute.TextDecorationColor:
			{
				RgbColor rgbColor = A_0.TextColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			default:
				switch (A_4)
				{
				case Attribute.SpaceAfter:
					return new AttributeObject.d(A_0.s() + A_0.u());
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_3.Page, A_3.Dimensions.a3(A_3.Page.Dimensions, A_1, A_2), A_3.Dimensions.a4(A_3.Page.Dimensions, A_1, A_2), A_0.h(), (float)A_0.ah().Count * A_0.Leading, 0f).a());
				case Attribute.Width:
					return new AttributeObject.d(A_0.h());
				case Attribute.Height:
					return new AttributeObject.d(A_0.z());
				case Attribute.TextDecorationType:
					return new AttributeObject.g(A_0.StrikeThrough ? TextDecorationType.LineThrough : (A_0.Underline ? TextDecorationType.Underline : TextDecorationType.None));
				}
				break;
			}
			return this.a(A_4, A_3);
		}

		// Token: 0x06003CBA RID: 15546 RVA: 0x00205D70 File Offset: 0x00204D70
		internal void b(PageWriter A_0, ListItem A_1, float A_2, float A_3, bool A_4)
		{
			if (A_4)
			{
				Attribute[] array = new Attribute[this.m.Count];
				this.m.Keys.CopyTo(array, 0);
				AttributeObject.b b = new AttributeObject.b(new BoundingBox(A_0.Page, A_0.Dimensions.a3(A_0.Page.Dimensions, A_2, A_3), A_0.Dimensions.a4(A_0.Page.Dimensions, A_2, A_3), A_1.h(), A_1.a(null), 0f).a());
				bool a_ = false;
				for (int i = 0; i < array.Length; i++)
				{
					if (this.m[array[i]] == null)
					{
						if (array[i] == Attribute.BBox)
						{
							this.m[array[i]] = b;
							if (!((StructureElement)A_1.Tag).o().Contains(array[i]))
							{
								((StructureElement)A_1.Tag).o().Add(array[i], b);
							}
						}
						else if (array[i] == Attribute.Height)
						{
							AttributeObject.d value = new AttributeObject.d(A_1.a(null));
							this.m[array[i]] = value;
							if (!((StructureElement)A_1.Tag).o().Contains(300))
							{
								((StructureElement)A_1.Tag).o().Add(300, b);
								((StructureElement)A_1.Tag).o().Add(array[i], value);
							}
						}
						else if (array[i] == Attribute.Width)
						{
							AttributeObject.d value2 = new AttributeObject.d(A_1.h());
							this.m[array[i]] = value2;
							if (!((StructureElement)A_1.Tag).o().Contains(300))
							{
								((StructureElement)A_1.Tag).o().Add(300, b);
							}
							if (!((StructureElement)A_1.Tag).o().Contains(array[i]))
							{
								((StructureElement)A_1.Tag).o().Add(array[i], value2);
							}
						}
						else
						{
							this.m[array[i]] = this.a(A_1, A_2, A_3, A_0, array[i]);
						}
					}
					else if (!this.o && ((StructureElement)A_1.Tag).o().Contains(array[i]))
					{
						a_ = this.a((StructureElement)A_1.Tag, array[i], b, a_);
					}
				}
			}
			else
			{
				Attribute[] array = new Attribute[this.m.Count];
				this.m.Keys.CopyTo(array, 0);
				bool a_ = false;
				for (int i = 0; i < array.Length; i++)
				{
					if (this.m[array[i]] == null)
					{
						object value3 = this.a(A_1, A_2, A_3, A_0, array[i]);
						this.m[array[i]] = value3;
						if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
						{
							if (!((StructureElement)A_1.ListItemTag).o().Contains(array[i]))
							{
								if (array[i] == Attribute.BBox)
								{
									((StructureElement)A_1.ListItemTag).o().Add(array[i], value3);
								}
								else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
								{
									AttributeObject.b value4 = (AttributeObject.b)this.a(A_1, A_2, A_3, A_0, Attribute.BBox);
									if (!((StructureElement)A_1.ListItemTag).o().Contains(300))
									{
										((StructureElement)A_1.ListItemTag).o().Add(300, value4);
									}
									((StructureElement)A_1.ListItemTag).o().Add(array[i], value3);
								}
							}
							else
							{
								value3 = ((StructureElement)A_1.ListItemTag).o()[array[i]];
								this.m[array[i]] = value3;
							}
						}
					}
					else if (!this.o && ((StructureElement)A_1.ListItemTag).o().Contains(array[i]))
					{
						AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_2, A_3, A_0, Attribute.BBox);
						a_ = this.a((StructureElement)A_1.ListItemTag, array[i], b, a_);
					}
				}
			}
		}

		// Token: 0x06003CBB RID: 15547 RVA: 0x00206304 File Offset: 0x00205304
		internal void a(PageWriter A_0, TextArea A_1)
		{
			if (this.m[Attribute.LineHeight] == null)
			{
				this.m[Attribute.LineHeight] = this.a(A_1, A_0, Attribute.LineHeight);
			}
			if (A_1.Underline)
			{
				HybridDictionary hybridDictionary = this.m;
				if (hybridDictionary[Attribute.TextDecorationType] == null)
				{
					hybridDictionary[Attribute.TextDecorationType] = this.a(A_1, A_0, Attribute.TextDecorationType);
				}
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.TextAlign] == null)
				{
					this.m[Attribute.TextAlign] = this.a(A_1, A_0, Attribute.TextAlign);
				}
				if (this.m[Attribute.StartIndent] == null)
				{
					this.m[Attribute.StartIndent] = this.a(A_1, A_0, Attribute.StartIndent);
				}
				if (this.m[Attribute.EndIndent] == null)
				{
					this.m[Attribute.EndIndent] = this.a(A_1, A_0, Attribute.EndIndent);
				}
			}
			if (A_1.Tag != null)
			{
				AttributeObject.b b = new AttributeObject.b(new BoundingBox(A_0.Page, A_0.Dimensions.a3(A_0.Page.Dimensions, A_1.X, A_1.Y), A_0.Dimensions.a4(A_0.Page.Dimensions, A_1.X, A_1.Y), A_1.Width, A_1.a().GetRequiredHeight(0), A_1.Angle).a());
				if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
				{
					((StructureElement)A_1.Tag).o().Add(Attribute.BBox, b);
				}
				else
				{
					this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
				}
				if (!((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = new AttributeObject.d(A_1.a().GetRequiredHeight(0));
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else
				{
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (!((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = new AttributeObject.d(A_1.Width);
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else
				{
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
				this.o = true;
			}
		}

		// Token: 0x06003CBC RID: 15548 RVA: 0x00206654 File Offset: 0x00205654
		private void a(TextArea A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object obj = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = obj;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								if (obj == null)
								{
									obj = new AttributeObject.b(new BoundingBox(A_1.Page, A_0.X, A_0.Y, A_0.Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
								}
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								AttributeObject.b value = new AttributeObject.b(new BoundingBox(A_1.Page, A_0.X, A_0.Y, A_0.Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, value);
								}
								if (obj == null && array[i] == Attribute.Height)
								{
									obj = new AttributeObject.d((float)A_0.a().Count * A_0.Leading);
								}
								else if (obj == null && array[i] == Attribute.Width)
								{
									obj = new AttributeObject.d(A_0.Width);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
						}
						else
						{
							obj = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = obj;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					AttributeObject.b a_2 = new AttributeObject.b(new BoundingBox(A_1.Page, A_0.X, A_0.Y, A_0.Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
					a_ = this.a((StructureElement)A_0.Tag, array[i], a_2, a_);
				}
			}
		}

		// Token: 0x06003CBD RID: 15549 RVA: 0x002069BC File Offset: 0x002059BC
		private object a(TextArea A_0, PageWriter A_1, Attribute A_2)
		{
			switch (A_2)
			{
			case Attribute.WritingMode:
				return new AttributeObject.g(A_0.RightToLeft ? WritingMode.RlTb : WritingMode.LrTb);
			case Attribute.BorderColor:
			case Attribute.BorderThickness:
			case Attribute.BlockAlign:
			case Attribute.InlineAlign:
			case Attribute.TBorderStyle:
			case Attribute.TPadding:
				break;
			case Attribute.Color:
			{
				RgbColor rgbColor = A_0.TextColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.StartIndent:
				return new AttributeObject.d(A_1.Page.Dimensions.Edge.Left + A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y));
			case Attribute.EndIndent:
				return new AttributeObject.d(A_1.Page.Dimensions.Width - (A_1.Page.Dimensions.Edge.Left + A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y) + A_0.Width));
			case Attribute.TextIndent:
				return new AttributeObject.d(A_0.ParagraphIndent);
			case Attribute.TextAlign:
				switch (A_0.Align)
				{
				case TextAlign.Left:
					return new AttributeObject.g(TextAlignAttribute.Start);
				case TextAlign.Center:
					return new AttributeObject.g(TextAlignAttribute.Center);
				case TextAlign.Right:
					return new AttributeObject.g(TextAlignAttribute.End);
				case TextAlign.Justify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				case TextAlign.FullJustify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				default:
					return new AttributeObject.f(string.Empty);
				}
				break;
			case Attribute.LineHeight:
				return new AttributeObject.d(A_0.Leading);
			case Attribute.TextDecorationColor:
			{
				RgbColor rgbColor = A_0.TextColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			default:
				switch (A_2)
				{
				case Attribute.SpaceBefore:
					return new AttributeObject.d(A_0.ParagraphSpacing);
				case Attribute.SpaceAfter:
					return new AttributeObject.d(A_0.ParagraphSpacing);
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
				case Attribute.Width:
					return new AttributeObject.d(A_0.Width);
				case Attribute.Height:
					return new AttributeObject.d((float)A_0.a().Count * A_0.Leading);
				case Attribute.TextDecorationType:
					return new AttributeObject.g(A_0.Underline ? TextDecorationType.Underline : TextDecorationType.None);
				}
				break;
			}
			return this.a(A_2, A_1);
		}

		// Token: 0x06003CBE RID: 15550 RVA: 0x00206D28 File Offset: 0x00205D28
		internal void a(PageWriter A_0, ceTe.DynamicPDF.ReportWriter.Layout.LayoutTextArea A_1, xy A_2)
		{
			if (this.m[Attribute.LineHeight] == null)
			{
				this.m[Attribute.LineHeight] = this.a(A_1, A_2, A_0, Attribute.LineHeight);
			}
			if ((A_1 != null && A_1.Underline) || (A_2 != null && A_2.e()))
			{
				HybridDictionary hybridDictionary = this.m;
				if (hybridDictionary[Attribute.TextDecorationType] == null)
				{
					hybridDictionary[Attribute.TextDecorationType] = this.a(A_1, A_2, A_0, Attribute.TextDecorationType);
				}
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.TextAlign] == null)
				{
					this.m[Attribute.TextAlign] = this.a(A_1, A_2, A_0, Attribute.TextAlign);
				}
				if (this.m[Attribute.StartIndent] == null)
				{
					this.m[Attribute.StartIndent] = this.a(A_1, A_2, A_0, Attribute.StartIndent);
				}
				if (this.m[Attribute.EndIndent] == null)
				{
					this.m[Attribute.EndIndent] = this.a(A_1, A_2, A_0, Attribute.EndIndent);
				}
			}
			if (A_1 != null)
			{
				if (A_1.Tag != null)
				{
					AttributeObject.b b = new AttributeObject.b(new BoundingBox(A_0.Page, A_0.Dimensions.a3(A_0.Page.Dimensions, A_1.X, A_1.Y), A_0.Dimensions.a4(A_0.Page.Dimensions, A_1.X, A_1.Y), A_1.a().Width, A_1.a().GetRequiredHeight(0), A_1.Angle).a());
					if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
					{
						((StructureElement)A_1.Tag).o().Add(Attribute.BBox, b);
					}
					else
					{
						this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
					}
					if (!((StructureElement)A_1.Tag).o().Contains(300))
					{
						object value = new AttributeObject.d(A_1.a().GetRequiredHeight(0));
						((StructureElement)A_1.Tag).o().Add(300, b);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
					}
					else
					{
						this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
					}
					if (!((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
					{
						object value = new AttributeObject.d(A_1.a().Width);
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
					}
					else
					{
						this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
					}
					this.o = true;
				}
			}
			else if (A_2.Tag != null)
			{
				AttributeObject.b b = new AttributeObject.b(new BoundingBox(A_0.Page, A_0.Dimensions.a3(A_0.Page.Dimensions, A_2.X, A_2.Y), A_0.Dimensions.a4(A_0.Page.Dimensions, A_2.X, A_2.Y), A_2.a().Width, A_2.a().GetRequiredHeight(0), A_2.Angle).a());
				if (!((StructureElement)A_2.Tag).o().Contains(Attribute.BBox))
				{
					((StructureElement)A_2.Tag).o().Add(Attribute.BBox, b);
				}
				else
				{
					this.a((StructureElement)A_2.Tag, Attribute.BBox, b, false);
				}
				if (!((StructureElement)A_2.Tag).o().Contains(300))
				{
					object value = new AttributeObject.d(A_2.a().GetRequiredHeight(0));
					((StructureElement)A_2.Tag).o().Add(300, b);
					((StructureElement)A_2.Tag).o().Add(Attribute.Height, value);
				}
				else
				{
					this.a((StructureElement)A_2.Tag, Attribute.Height, b, false);
				}
				if (!((StructureElement)A_2.Tag).o().Contains(Attribute.Width))
				{
					object value = new AttributeObject.d(A_2.a().Width);
					((StructureElement)A_2.Tag).o().Add(Attribute.Width, value);
				}
				else
				{
					this.a((StructureElement)A_2.Tag, Attribute.Width, b, true);
				}
				this.o = true;
			}
		}

		// Token: 0x06003CBF RID: 15551 RVA: 0x002072B0 File Offset: 0x002062B0
		private void a(ceTe.DynamicPDF.ReportWriter.Layout.LayoutTextArea A_0, xy A_1, PageWriter A_2)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			bool a_ = false;
			if (A_0 != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (this.m[array[i]] == null)
					{
						object obj = this.a(A_0, A_1, A_2, array[i]);
						this.m[array[i]] = obj;
						if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
						{
							if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
							{
								if (array[i] == Attribute.BBox)
								{
									if (obj == null)
									{
										obj = new AttributeObject.b(new BoundingBox(A_2.Page, A_0.X, A_0.Y, A_0.a().Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
									}
									((StructureElement)A_0.Tag).o().Add(array[i], obj);
								}
								else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
								{
									AttributeObject.b value = new AttributeObject.b(new BoundingBox(A_2.Page, A_0.X, A_0.Y, A_0.a().Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
									if (!((StructureElement)A_0.Tag).o().Contains(300))
									{
										((StructureElement)A_0.Tag).o().Add(300, value);
									}
									if (obj == null && array[i] == Attribute.Height)
									{
										obj = new AttributeObject.d((float)A_0.a().Count * A_0.Leading);
									}
									else if (obj == null && array[i] == Attribute.Width)
									{
										obj = new AttributeObject.d(A_0.a().Width);
									}
									((StructureElement)A_0.Tag).o().Add(array[i], obj);
								}
							}
							else
							{
								obj = ((StructureElement)A_0.Tag).o()[array[i]];
								this.m[array[i]] = obj;
							}
						}
					}
					else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
					{
						AttributeObject.b a_2 = new AttributeObject.b(new BoundingBox(A_2.Page, A_0.X, A_0.Y, A_0.a().Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
						a_ = this.a((StructureElement)A_0.Tag, array[i], a_2, a_);
					}
				}
			}
			else
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (this.m[array[i]] == null)
					{
						object obj = this.a(A_0, A_1, A_2, array[i]);
						this.m[array[i]] = obj;
						if ((array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height) && !((StructureElement)A_1.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								if (obj == null)
								{
									obj = new AttributeObject.b(new BoundingBox(A_2.Page, A_0.X, A_0.Y, A_0.a().Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
								}
								((StructureElement)A_1.Tag).o().Add(array[i], obj);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								AttributeObject.b value = new AttributeObject.b(new BoundingBox(A_2.Page, A_1.X, A_1.Y, A_1.a().Width, A_1.a().GetRequiredHeight(0), A_1.Angle).a());
								if (!((StructureElement)A_1.Tag).o().Contains(300))
								{
									((StructureElement)A_1.Tag).o().Add(300, value);
								}
								if (obj == null && array[i] == Attribute.Height)
								{
									obj = new AttributeObject.d(A_1.a().GetRequiredHeight(0));
								}
								else if (obj == null && array[i] == Attribute.Width)
								{
									obj = new AttributeObject.d(A_1.a().Width);
								}
								((StructureElement)A_1.Tag).o().Add(array[i], obj);
							}
						}
					}
					else if (!this.o && ((StructureElement)A_1.Tag).o().Contains(array[i]))
					{
						AttributeObject.b a_2 = new AttributeObject.b(new BoundingBox(A_2.Page, A_1.X, A_1.Y, A_1.a().Width, A_1.a().GetRequiredHeight(0), A_1.Angle).a());
						a_ = this.a((StructureElement)A_1.Tag, array[i], a_2, a_);
					}
				}
			}
		}

		// Token: 0x06003CC0 RID: 15552 RVA: 0x00207940 File Offset: 0x00206940
		private object a(ceTe.DynamicPDF.ReportWriter.Layout.LayoutTextArea A_0, xy A_1, PageWriter A_2, Attribute A_3)
		{
			if (A_0 != null)
			{
				switch (A_3)
				{
				case Attribute.WritingMode:
					return new AttributeObject.g(A_0.RightToLeft ? WritingMode.RlTb : WritingMode.LrTb);
				case Attribute.BorderColor:
				case Attribute.BorderThickness:
				case Attribute.BlockAlign:
				case Attribute.InlineAlign:
				case Attribute.TBorderStyle:
				case Attribute.TPadding:
					break;
				case Attribute.Color:
				{
					RgbColor rgbColor = A_0.TextColor.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				case Attribute.StartIndent:
					return new AttributeObject.d(A_2.Page.Dimensions.Edge.Left + A_2.Page.Dimensions.LeftMargin + A_2.Dimensions.a3(A_2.Page.Dimensions, A_0.X, A_0.Y));
				case Attribute.EndIndent:
					return new AttributeObject.d(A_2.Page.Dimensions.Width - (A_2.Page.Dimensions.Edge.Left + A_2.Page.Dimensions.LeftMargin + A_2.Dimensions.a3(A_2.Page.Dimensions, A_0.X, A_0.Y) + A_0.a().Width));
				case Attribute.TextIndent:
					return new AttributeObject.d(A_0.ParagraphIndent);
				case Attribute.TextAlign:
					switch (A_0.Align)
					{
					case TextAlign.Left:
						return new AttributeObject.g(TextAlignAttribute.Start);
					case TextAlign.Center:
						return new AttributeObject.g(TextAlignAttribute.Center);
					case TextAlign.Right:
						return new AttributeObject.g(TextAlignAttribute.End);
					case TextAlign.Justify:
						return new AttributeObject.g(TextAlignAttribute.Justify);
					case TextAlign.FullJustify:
						return new AttributeObject.g(TextAlignAttribute.Justify);
					default:
						goto IL_6F2;
					}
					break;
				case Attribute.LineHeight:
					return new AttributeObject.d(A_0.Leading);
				case Attribute.TextDecorationColor:
				{
					RgbColor rgbColor = A_0.TextColor.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				default:
					switch (A_3)
					{
					case Attribute.SpaceBefore:
						return new AttributeObject.d(A_0.ParagraphSpacing);
					case Attribute.SpaceAfter:
						return new AttributeObject.d(A_0.ParagraphSpacing);
					case Attribute.BBox:
						return new AttributeObject.b(new BoundingBox(A_2.Page, A_2.Dimensions.a3(A_2.Page.Dimensions, A_0.X, A_0.Y), A_2.Dimensions.a4(A_2.Page.Dimensions, A_0.X, A_0.Y), A_0.a().Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
					case Attribute.Width:
						return new AttributeObject.d(A_0.a().Width);
					case Attribute.Height:
						return new AttributeObject.d((float)A_0.a().Count * A_0.Leading);
					case Attribute.TextDecorationType:
						return new AttributeObject.g(A_0.Underline ? TextDecorationType.Underline : TextDecorationType.None);
					}
					break;
				}
				return this.a(A_3, A_2);
			}
			switch (A_3)
			{
			case Attribute.WritingMode:
				return new AttributeObject.g(WritingMode.LrTb);
			case Attribute.BorderColor:
			case Attribute.BorderThickness:
			case Attribute.BlockAlign:
			case Attribute.InlineAlign:
			case Attribute.TBorderStyle:
			case Attribute.TPadding:
				break;
			case Attribute.Color:
			{
				RgbColor rgbColor = A_1.d().m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.StartIndent:
				return new AttributeObject.d(A_2.Page.Dimensions.Edge.Left + A_2.Page.Dimensions.LeftMargin + A_2.Dimensions.a3(A_2.Page.Dimensions, A_1.X, A_1.Y));
			case Attribute.EndIndent:
				return new AttributeObject.d(A_2.Page.Dimensions.Width - (A_2.Page.Dimensions.Edge.Left + A_2.Page.Dimensions.LeftMargin + A_2.Dimensions.a3(A_2.Page.Dimensions, A_1.X, A_1.Y) + A_1.a().Width));
			case Attribute.TextIndent:
				return new AttributeObject.d(A_1.a().ParagraphIndent);
			case Attribute.TextAlign:
				switch (A_1.b())
				{
				case TextAlign.Left:
					return new AttributeObject.g(TextAlignAttribute.Start);
				case TextAlign.Center:
					return new AttributeObject.g(TextAlignAttribute.Center);
				case TextAlign.Right:
					return new AttributeObject.g(TextAlignAttribute.End);
				case TextAlign.Justify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				case TextAlign.FullJustify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				default:
					goto IL_6F2;
				}
				break;
			case Attribute.LineHeight:
				return new AttributeObject.d(A_1.a().Leading);
			case Attribute.TextDecorationColor:
			{
				RgbColor rgbColor = A_1.d().m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			default:
				switch (A_3)
				{
				case Attribute.SpaceBefore:
					return new AttributeObject.d(A_1.a().ParagraphSpacing);
				case Attribute.SpaceAfter:
					return new AttributeObject.d(A_1.a().ParagraphSpacing);
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_2.Page, A_2.Dimensions.a3(A_2.Page.Dimensions, A_1.X, A_1.Y), A_2.Dimensions.a4(A_2.Page.Dimensions, A_1.X, A_1.Y), A_1.a().Width, A_1.a().GetRequiredHeight(0), A_1.Angle).a());
				case Attribute.Width:
					return new AttributeObject.d(A_1.a().Width);
				case Attribute.Height:
					return new AttributeObject.d(A_1.a().GetRequiredHeight(0));
				case Attribute.TextDecorationType:
					return new AttributeObject.g(A_1.e() ? TextDecorationType.Underline : TextDecorationType.None);
				}
				break;
			}
			return this.a(A_3, A_2);
			IL_6F2:
			return string.Empty;
		}

		// Token: 0x06003CC1 RID: 15553 RVA: 0x00208048 File Offset: 0x00207048
		internal void a(PageWriter A_0, ceTe.DynamicPDF.LayoutEngine.Layout.LayoutTextArea A_1, am7 A_2)
		{
			if (this.m[Attribute.LineHeight] == null)
			{
				this.m[Attribute.LineHeight] = this.a(A_1, A_2, A_0, Attribute.LineHeight);
			}
			if ((A_1 != null && A_1.Underline) || (A_2 != null && A_2.e()))
			{
				HybridDictionary hybridDictionary = this.m;
				if (hybridDictionary[Attribute.TextDecorationType] == null)
				{
					hybridDictionary[Attribute.TextDecorationType] = this.a(A_1, A_2, A_0, Attribute.TextDecorationType);
				}
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.TextAlign] == null)
				{
					this.m[Attribute.TextAlign] = this.a(A_1, A_2, A_0, Attribute.TextAlign);
				}
				if (this.m[Attribute.StartIndent] == null)
				{
					this.m[Attribute.StartIndent] = this.a(A_1, A_2, A_0, Attribute.StartIndent);
				}
				if (this.m[Attribute.EndIndent] == null)
				{
					this.m[Attribute.EndIndent] = this.a(A_1, A_2, A_0, Attribute.EndIndent);
				}
			}
			if (A_1 != null)
			{
				if (A_1.Tag != null)
				{
					AttributeObject.b b = new AttributeObject.b(new BoundingBox(A_0.Page, A_0.Dimensions.a3(A_0.Page.Dimensions, A_1.X, A_1.Y), A_0.Dimensions.a4(A_0.Page.Dimensions, A_1.X, A_1.Y), A_1.a().Width, A_1.a().GetRequiredHeight(0), A_1.Angle).a());
					if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
					{
						((StructureElement)A_1.Tag).o().Add(Attribute.BBox, b);
					}
					else
					{
						this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
					}
					if (!((StructureElement)A_1.Tag).o().Contains(300))
					{
						object value = new AttributeObject.d(A_1.a().GetRequiredHeight(0));
						((StructureElement)A_1.Tag).o().Add(300, b);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
					}
					else
					{
						this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
					}
					if (!((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
					{
						object value = new AttributeObject.d(A_1.a().Width);
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
					}
					else
					{
						this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
					}
					this.o = true;
				}
			}
			else if (A_2.Tag != null)
			{
				AttributeObject.b b = new AttributeObject.b(new BoundingBox(A_0.Page, A_0.Dimensions.a3(A_0.Page.Dimensions, A_2.X, A_2.Y), A_0.Dimensions.a4(A_0.Page.Dimensions, A_2.X, A_2.Y), A_2.a().Width, A_2.a().GetRequiredHeight(0), A_2.Angle).a());
				if (!((StructureElement)A_2.Tag).o().Contains(Attribute.BBox))
				{
					((StructureElement)A_2.Tag).o().Add(Attribute.BBox, b);
				}
				else
				{
					this.a((StructureElement)A_2.Tag, Attribute.BBox, b, false);
				}
				if (!((StructureElement)A_2.Tag).o().Contains(300))
				{
					object value = new AttributeObject.d(A_2.a().GetRequiredHeight(0));
					((StructureElement)A_2.Tag).o().Add(300, b);
					((StructureElement)A_2.Tag).o().Add(Attribute.Height, value);
				}
				else
				{
					this.a((StructureElement)A_2.Tag, Attribute.Height, b, false);
				}
				if (!((StructureElement)A_2.Tag).o().Contains(Attribute.Width))
				{
					object value = new AttributeObject.d(A_2.a().Width);
					((StructureElement)A_2.Tag).o().Add(Attribute.Width, value);
				}
				else
				{
					this.a((StructureElement)A_2.Tag, Attribute.Width, b, true);
				}
				this.o = true;
			}
		}

		// Token: 0x06003CC2 RID: 15554 RVA: 0x002085D0 File Offset: 0x002075D0
		private void a(ceTe.DynamicPDF.LayoutEngine.Layout.LayoutTextArea A_0, am7 A_1, PageWriter A_2)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			bool a_ = false;
			if (A_0 != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (this.m[array[i]] == null)
					{
						object obj = this.a(A_0, A_1, A_2, array[i]);
						this.m[array[i]] = obj;
						if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
						{
							if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
							{
								if (array[i] == Attribute.BBox)
								{
									if (obj == null)
									{
										obj = new AttributeObject.b(new BoundingBox(A_2.Page, A_0.X, A_0.Y, A_0.a().Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
									}
									((StructureElement)A_0.Tag).o().Add(array[i], obj);
								}
								else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
								{
									AttributeObject.b value = new AttributeObject.b(new BoundingBox(A_2.Page, A_0.X, A_0.Y, A_0.a().Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
									if (!((StructureElement)A_0.Tag).o().Contains(300))
									{
										((StructureElement)A_0.Tag).o().Add(300, value);
									}
									if (obj == null && array[i] == Attribute.Height)
									{
										obj = new AttributeObject.d((float)A_0.a().Count * A_0.Leading);
									}
									else if (obj == null && array[i] == Attribute.Width)
									{
										obj = new AttributeObject.d(A_0.a().Width);
									}
									((StructureElement)A_0.Tag).o().Add(array[i], obj);
								}
							}
							else
							{
								obj = ((StructureElement)A_0.Tag).o()[array[i]];
								this.m[array[i]] = obj;
							}
						}
					}
					else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
					{
						AttributeObject.b a_2 = new AttributeObject.b(new BoundingBox(A_2.Page, A_0.X, A_0.Y, A_0.a().Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
						a_ = this.a((StructureElement)A_0.Tag, array[i], a_2, a_);
					}
				}
			}
			else
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (this.m[array[i]] == null)
					{
						object obj = this.a(A_0, A_1, A_2, array[i]);
						this.m[array[i]] = obj;
						if ((array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height) && !((StructureElement)A_1.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								if (obj == null)
								{
									obj = new AttributeObject.b(new BoundingBox(A_2.Page, A_0.X, A_0.Y, A_0.a().Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
								}
								((StructureElement)A_1.Tag).o().Add(array[i], obj);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								AttributeObject.b value = new AttributeObject.b(new BoundingBox(A_2.Page, A_1.X, A_1.Y, A_1.a().Width, A_1.a().GetRequiredHeight(0), A_1.Angle).a());
								if (!((StructureElement)A_1.Tag).o().Contains(300))
								{
									((StructureElement)A_1.Tag).o().Add(300, value);
								}
								if (obj == null && array[i] == Attribute.Height)
								{
									obj = new AttributeObject.d(A_1.a().GetRequiredHeight(0));
								}
								else if (obj == null && array[i] == Attribute.Width)
								{
									obj = new AttributeObject.d(A_1.a().Width);
								}
								((StructureElement)A_1.Tag).o().Add(array[i], obj);
							}
						}
					}
					else if (!this.o && ((StructureElement)A_1.Tag).o().Contains(array[i]))
					{
						AttributeObject.b a_2 = new AttributeObject.b(new BoundingBox(A_2.Page, A_1.X, A_1.Y, A_1.a().Width, A_1.a().GetRequiredHeight(0), A_1.Angle).a());
						a_ = this.a((StructureElement)A_1.Tag, array[i], a_2, a_);
					}
				}
			}
		}

		// Token: 0x06003CC3 RID: 15555 RVA: 0x00208C60 File Offset: 0x00207C60
		private object a(ceTe.DynamicPDF.LayoutEngine.Layout.LayoutTextArea A_0, am7 A_1, PageWriter A_2, Attribute A_3)
		{
			if (A_0 != null)
			{
				switch (A_3)
				{
				case Attribute.WritingMode:
					return new AttributeObject.g(A_0.RightToLeft ? WritingMode.RlTb : WritingMode.LrTb);
				case Attribute.BorderColor:
				case Attribute.BorderThickness:
				case Attribute.BlockAlign:
				case Attribute.InlineAlign:
				case Attribute.TBorderStyle:
				case Attribute.TPadding:
					break;
				case Attribute.Color:
				{
					RgbColor rgbColor = A_0.TextColor.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				case Attribute.StartIndent:
					return new AttributeObject.d(A_2.Page.Dimensions.Edge.Left + A_2.Page.Dimensions.LeftMargin + A_2.Dimensions.a3(A_2.Page.Dimensions, A_0.X, A_0.Y));
				case Attribute.EndIndent:
					return new AttributeObject.d(A_2.Page.Dimensions.Width - (A_2.Page.Dimensions.Edge.Left + A_2.Page.Dimensions.LeftMargin + A_2.Dimensions.a3(A_2.Page.Dimensions, A_0.X, A_0.Y) + A_0.a().Width));
				case Attribute.TextIndent:
					return new AttributeObject.d(A_0.ParagraphIndent);
				case Attribute.TextAlign:
					switch (A_0.Align)
					{
					case TextAlign.Left:
						return new AttributeObject.g(TextAlignAttribute.Start);
					case TextAlign.Center:
						return new AttributeObject.g(TextAlignAttribute.Center);
					case TextAlign.Right:
						return new AttributeObject.g(TextAlignAttribute.End);
					case TextAlign.Justify:
						return new AttributeObject.g(TextAlignAttribute.Justify);
					case TextAlign.FullJustify:
						return new AttributeObject.g(TextAlignAttribute.Justify);
					default:
						goto IL_6F2;
					}
					break;
				case Attribute.LineHeight:
					return new AttributeObject.d(A_0.Leading);
				case Attribute.TextDecorationColor:
				{
					RgbColor rgbColor = A_0.TextColor.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				default:
					switch (A_3)
					{
					case Attribute.SpaceBefore:
						return new AttributeObject.d(A_0.ParagraphSpacing);
					case Attribute.SpaceAfter:
						return new AttributeObject.d(A_0.ParagraphSpacing);
					case Attribute.BBox:
						return new AttributeObject.b(new BoundingBox(A_2.Page, A_2.Dimensions.a3(A_2.Page.Dimensions, A_0.X, A_0.Y), A_2.Dimensions.a4(A_2.Page.Dimensions, A_0.X, A_0.Y), A_0.a().Width, (float)A_0.a().Count * A_0.Leading, A_0.Angle).a());
					case Attribute.Width:
						return new AttributeObject.d(A_0.a().Width);
					case Attribute.Height:
						return new AttributeObject.d((float)A_0.a().Count * A_0.Leading);
					case Attribute.TextDecorationType:
						return new AttributeObject.g(A_0.Underline ? TextDecorationType.Underline : TextDecorationType.None);
					}
					break;
				}
				return this.a(A_3, A_2);
			}
			switch (A_3)
			{
			case Attribute.WritingMode:
				return new AttributeObject.g(WritingMode.LrTb);
			case Attribute.BorderColor:
			case Attribute.BorderThickness:
			case Attribute.BlockAlign:
			case Attribute.InlineAlign:
			case Attribute.TBorderStyle:
			case Attribute.TPadding:
				break;
			case Attribute.Color:
			{
				RgbColor rgbColor = A_1.d().m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.StartIndent:
				return new AttributeObject.d(A_2.Page.Dimensions.Edge.Left + A_2.Page.Dimensions.LeftMargin + A_2.Dimensions.a3(A_2.Page.Dimensions, A_1.X, A_1.Y));
			case Attribute.EndIndent:
				return new AttributeObject.d(A_2.Page.Dimensions.Width - (A_2.Page.Dimensions.Edge.Left + A_2.Page.Dimensions.LeftMargin + A_2.Dimensions.a3(A_2.Page.Dimensions, A_1.X, A_1.Y) + A_1.a().Width));
			case Attribute.TextIndent:
				return new AttributeObject.d(A_1.a().ParagraphIndent);
			case Attribute.TextAlign:
				switch (A_1.b())
				{
				case TextAlign.Left:
					return new AttributeObject.g(TextAlignAttribute.Start);
				case TextAlign.Center:
					return new AttributeObject.g(TextAlignAttribute.Center);
				case TextAlign.Right:
					return new AttributeObject.g(TextAlignAttribute.End);
				case TextAlign.Justify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				case TextAlign.FullJustify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				default:
					goto IL_6F2;
				}
				break;
			case Attribute.LineHeight:
				return new AttributeObject.d(A_1.a().Leading);
			case Attribute.TextDecorationColor:
			{
				RgbColor rgbColor = A_1.d().m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			default:
				switch (A_3)
				{
				case Attribute.SpaceBefore:
					return new AttributeObject.d(A_1.a().ParagraphSpacing);
				case Attribute.SpaceAfter:
					return new AttributeObject.d(A_1.a().ParagraphSpacing);
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_2.Page, A_2.Dimensions.a3(A_2.Page.Dimensions, A_1.X, A_1.Y), A_2.Dimensions.a4(A_2.Page.Dimensions, A_1.X, A_1.Y), A_1.a().Width, A_1.a().GetRequiredHeight(0), A_1.Angle).a());
				case Attribute.Width:
					return new AttributeObject.d(A_1.a().Width);
				case Attribute.Height:
					return new AttributeObject.d(A_1.a().GetRequiredHeight(0));
				case Attribute.TextDecorationType:
					return new AttributeObject.g(A_1.e() ? TextDecorationType.Underline : TextDecorationType.None);
				}
				break;
			}
			return this.a(A_3, A_2);
			IL_6F2:
			return string.Empty;
		}

		// Token: 0x06003CC4 RID: 15556 RVA: 0x00209368 File Offset: 0x00208368
		internal void a(PageWriter A_0, Label A_1)
		{
			if (this.m[Attribute.LineHeight] == null)
			{
				this.m[Attribute.LineHeight] = this.a(A_1, A_0, Attribute.LineHeight);
			}
			if (A_1.Underline)
			{
				HybridDictionary hybridDictionary = this.m;
				if (hybridDictionary[Attribute.TextDecorationType] == null)
				{
					hybridDictionary[Attribute.TextDecorationType] = this.a(A_1, A_0, Attribute.TextDecorationType);
				}
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.TextAlign] == null)
				{
					this.m[Attribute.TextAlign] = this.a(A_1, A_0, Attribute.TextAlign);
				}
				if (this.m[Attribute.StartIndent] == null)
				{
					this.m[Attribute.StartIndent] = this.a(A_1, A_0, Attribute.StartIndent);
				}
				if (this.m[Attribute.EndIndent] == null)
				{
					this.m[Attribute.EndIndent] = this.a(A_1, A_0, Attribute.EndIndent);
				}
			}
			if (A_1.Tag != null)
			{
				AttributeObject.b b = new AttributeObject.b(new BoundingBox(A_0.Page, A_0.Dimensions.a3(A_0.Page.Dimensions, A_1.X, A_1.Y), A_0.Dimensions.a4(A_0.Page.Dimensions, A_1.X, A_1.Y), A_1.Width, A_1.a().GetRequiredHeight(0), A_1.Angle).a());
				if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
				{
					((StructureElement)A_1.Tag).o().Add(Attribute.BBox, b);
				}
				else
				{
					this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
				}
				if (!((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else
				{
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (!((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else
				{
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
				this.o = true;
			}
		}

		// Token: 0x06003CC5 RID: 15557 RVA: 0x002096B8 File Offset: 0x002086B8
		private void a(Label A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object obj = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = obj;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								if (obj == null)
								{
									obj = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.a().GetRequiredHeight(0), A_0.Angle).a());
								}
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								AttributeObject.b value = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.a().GetRequiredHeight(0), A_0.Angle).a());
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, value);
								}
								if (obj == null && array[i] == Attribute.Height)
								{
									obj = new AttributeObject.d(A_0.a().GetRequiredHeight(0));
								}
								else if (obj == null && array[i] == Attribute.Width)
								{
									obj = new AttributeObject.d(A_0.Width);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
						}
						else
						{
							obj = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = obj;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					AttributeObject.b a_2 = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.a().GetRequiredHeight(0), A_0.Angle).a());
					a_ = this.a((StructureElement)A_0.Tag, array[i], a_2, a_);
				}
			}
		}

		// Token: 0x06003CC6 RID: 15558 RVA: 0x00209AB4 File Offset: 0x00208AB4
		private object a(Label A_0, PageWriter A_1, Attribute A_2)
		{
			switch (A_2)
			{
			case Attribute.WritingMode:
				return new AttributeObject.g(A_0.RightToLeft ? WritingMode.RlTb : WritingMode.LrTb);
			case Attribute.BorderColor:
			case Attribute.BorderThickness:
			case Attribute.TextIndent:
				break;
			case Attribute.Color:
			{
				RgbColor rgbColor = A_0.TextColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.StartIndent:
				return new AttributeObject.d(A_1.Page.Dimensions.Edge.Left + A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y));
			case Attribute.EndIndent:
				return new AttributeObject.d(A_1.Page.Dimensions.Width - (A_1.Page.Dimensions.Edge.Left + A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y) + A_0.Width));
			case Attribute.TextAlign:
				switch (A_0.Align)
				{
				case TextAlign.Left:
					return new AttributeObject.g(TextAlignAttribute.Start);
				case TextAlign.Center:
					return new AttributeObject.g(TextAlignAttribute.Center);
				case TextAlign.Right:
					return new AttributeObject.g(TextAlignAttribute.End);
				case TextAlign.Justify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				case TextAlign.FullJustify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				default:
					return new AttributeObject.f(string.Empty);
				}
				break;
			default:
				switch (A_2)
				{
				case Attribute.LineHeight:
					return new AttributeObject.d(A_0.a().Leading);
				case Attribute.TextDecorationColor:
				{
					RgbColor rgbColor = A_0.TextColor.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				default:
					switch (A_2)
					{
					case Attribute.BBox:
						return new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.a().GetRequiredHeight(0), A_0.Angle).a());
					case Attribute.Width:
						return new AttributeObject.d(A_0.Width);
					case Attribute.Height:
						return new AttributeObject.d(A_0.a().GetRequiredHeight(0));
					case Attribute.TextDecorationType:
						return new AttributeObject.g(A_0.Underline ? TextDecorationType.Underline : TextDecorationType.None);
					}
					break;
				}
				break;
			}
			return this.a(A_2, A_1);
		}

		// Token: 0x06003CC7 RID: 15559 RVA: 0x00209DD4 File Offset: 0x00208DD4
		private void a(PageWriter A_0, FormattedTextArea A_1)
		{
			if (this.m[Attribute.LineHeight] == null)
			{
				this.m[Attribute.LineHeight] = this.a(A_1, A_0, Attribute.LineHeight);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (this.m[Attribute.TextAlign] == null)
				{
					this.m[Attribute.TextAlign] = this.a(A_1, A_0, Attribute.TextAlign);
				}
				if (this.m[Attribute.StartIndent] == null)
				{
					this.m[Attribute.StartIndent] = this.a(A_1, A_0, Attribute.StartIndent);
				}
				if (this.m[Attribute.EndIndent] == null)
				{
					this.m[Attribute.EndIndent] = this.a(A_1, A_0, Attribute.EndIndent);
				}
			}
			if (A_1.Tag != null)
			{
				AttributeObject.b b = new AttributeObject.b(new BoundingBox(A_0.Page, A_0.Dimensions.a3(A_0.Page.Dimensions, A_1.X, A_1.Y), A_0.Dimensions.a4(A_0.Page.Dimensions, A_1.X, A_1.Y), A_1.Width, A_1.Height, A_1.Angle).a());
				if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
				{
					((StructureElement)A_1.Tag).o().Add(Attribute.BBox, b);
				}
				else
				{
					this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
				}
				if (!((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = new AttributeObject.d(A_1.Height);
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else
				{
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (!((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = new AttributeObject.d(A_1.Width);
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else
				{
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
				this.o = true;
			}
		}

		// Token: 0x06003CC8 RID: 15560 RVA: 0x0020A0CC File Offset: 0x002090CC
		private object a(FormattedTextArea A_0, PageWriter A_1, Attribute A_2)
		{
			switch (A_2)
			{
			case Attribute.Color:
			{
				RgbColor rgbColor = A_0.Style.Font.Color.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.StartIndent:
				return new AttributeObject.d(A_1.Page.Dimensions.Edge.Left + A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y));
			case Attribute.EndIndent:
				return new AttributeObject.d(A_1.Page.Dimensions.Width - (A_1.Page.Dimensions.Edge.Left + A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y) + A_0.Width));
			case Attribute.TextIndent:
				return new AttributeObject.d(A_0.Style.Paragraph.Indent);
			case Attribute.TextAlign:
				switch (A_0.Style.Paragraph.Align)
				{
				case TextAlign.Left:
					return new AttributeObject.g(TextAlignAttribute.Start);
				case TextAlign.Center:
					return new AttributeObject.g(TextAlignAttribute.Center);
				case TextAlign.Right:
					return new AttributeObject.g(TextAlignAttribute.End);
				case TextAlign.Justify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				case TextAlign.FullJustify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				default:
					return string.Empty;
				}
				break;
			case Attribute.BlockAlign:
			case Attribute.InlineAlign:
			case Attribute.TBorderStyle:
			case Attribute.TPadding:
				break;
			case Attribute.LineHeight:
				return new AttributeObject.d(A_0.c().a(0).h());
			case Attribute.TextDecorationColor:
			{
				RgbColor rgbColor = A_0.Style.Font.Color.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			default:
				switch (A_2)
				{
				case Attribute.SpaceBefore:
					return new AttributeObject.d(A_0.Style.Paragraph.SpacingBefore);
				case Attribute.SpaceAfter:
					return new AttributeObject.d(A_0.Style.Paragraph.SpacingAfter);
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, A_0.Angle).a());
				case Attribute.Width:
					return new AttributeObject.d(A_0.Width);
				case Attribute.Height:
					return new AttributeObject.d(A_0.Height);
				case Attribute.TextDecorationType:
					return new AttributeObject.g(A_0.Style.Underline ? TextDecorationType.Underline : TextDecorationType.None);
				}
				break;
			}
			return this.a(A_2, A_1);
		}

		// Token: 0x06003CC9 RID: 15561 RVA: 0x0020A440 File Offset: 0x00209440
		private void a(FormattedTextArea A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object obj = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = obj;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								if (obj == null)
								{
									obj = new AttributeObject.b(new BoundingBox(A_1.Page, A_0.X, A_0.Y, A_0.Width, A_0.Height, A_0.Angle).a());
								}
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								AttributeObject.b value = new AttributeObject.b(new BoundingBox(A_1.Page, A_0.X, A_0.Y, A_0.Width, A_0.Height, A_0.Angle).a());
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, value);
								}
								if (obj == null && array[i] == Attribute.Height)
								{
									obj = new AttributeObject.d(A_0.Height);
								}
								else if (obj == null && array[i] == Attribute.Width)
								{
									obj = new AttributeObject.d(A_0.Width);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
						}
						else
						{
							obj = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = obj;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					AttributeObject.b a_2 = new AttributeObject.b(new BoundingBox(A_1.Page, A_0.X, A_0.Y, A_0.Width, A_0.Height, A_0.Angle).a());
					a_ = this.a((StructureElement)A_0.Tag, array[i], a_2, a_);
				}
			}
		}

		// Token: 0x06003CCA RID: 15562 RVA: 0x0020A774 File Offset: 0x00209774
		private void a(PageWriter A_0, FormElement A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (!((StructureElement)A_1.Tag).o().Contains(300))
			{
				object value = this.a(A_1, A_0, Attribute.Height);
				((StructureElement)A_1.Tag).o().Add(300, b);
				((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
			}
			else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
			{
				this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
				this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
			}
			if (!((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
			{
				object value = this.a(A_1, A_0, Attribute.Width);
				((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
			}
			else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
			{
				this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
				this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
			}
			this.o = true;
		}

		// Token: 0x06003CCB RID: 15563 RVA: 0x0020AA70 File Offset: 0x00209A70
		private void a(FormElement A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CCC RID: 15564 RVA: 0x0020ACBC File Offset: 0x00209CBC
		private object a(FormElement A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			if (A_2 != Attribute.BorderColor)
			{
				if (A_2 != Attribute.TextDecorationColor)
				{
					switch (A_2)
					{
					case Attribute.BackgroundColor:
					{
						RgbColor rgbColor = A_0.BackgroundColor.m();
						return new AttributeObject.b(new float[]
						{
							rgbColor.R,
							rgbColor.G,
							rgbColor.B
						});
					}
					case Attribute.BorderStyle:
						if (A_0.BorderStyle == BorderStyle.Dashed)
						{
							return new AttributeObject.g(BorderStyleAttribute.Dashed);
						}
						if (A_0.BorderStyle == BorderStyle.Solid)
						{
							return new AttributeObject.g(BorderStyleAttribute.Solid);
						}
						if (A_0.BorderStyle == BorderStyle.Inset)
						{
							return new AttributeObject.g(BorderStyleAttribute.Inset);
						}
						return this.a(Attribute.BorderStyle, A_1);
					case Attribute.BBox:
						return new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, 0f).a());
					case Attribute.Width:
						return new AttributeObject.d(A_0.Width);
					case Attribute.Height:
						return new AttributeObject.d(A_0.Height);
					}
					result = this.a(A_2, A_1);
				}
				else
				{
					RgbColor rgbColor = A_0.TextColor.m();
					result = new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
			}
			else
			{
				RgbColor rgbColor = A_0.BorderColor.m();
				result = new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			return result;
		}

		// Token: 0x06003CCD RID: 15565 RVA: 0x0020AED4 File Offset: 0x00209ED4
		private void a(PageWriter A_0, Link A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (!((StructureElement)A_1.Tag).o().Contains(300))
			{
				object value = this.a(A_1, A_0, Attribute.Height);
				((StructureElement)A_1.Tag).o().Add(300, b);
				((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
			}
			else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
			{
				this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
				this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
			}
			if (!((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
			{
				object value = this.a(A_1, A_0, Attribute.Width);
				((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
			}
			else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
			{
				this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
				this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
			}
			this.o = true;
		}

		// Token: 0x06003CCE RID: 15566 RVA: 0x0020B1D0 File Offset: 0x0020A1D0
		private void a(Link A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CCF RID: 15567 RVA: 0x0020B41C File Offset: 0x0020A41C
		private object a(Link A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			switch (A_2)
			{
			case Attribute.BBox:
				result = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, 0f).a());
				break;
			case Attribute.Width:
				result = new AttributeObject.d(A_0.Width);
				break;
			case Attribute.Height:
				result = new AttributeObject.d(A_0.Height);
				break;
			default:
				result = this.a(A_2, A_1);
				break;
			}
			return result;
		}

		// Token: 0x06003CD0 RID: 15568 RVA: 0x0020B4E0 File Offset: 0x0020A4E0
		private void a(PageWriter A_0, Note A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
			}
			else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (!((StructureElement)A_1.Tag).o().Contains(300))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					((StructureElement)A_1.Tag).o().Add(300, b);
					((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
				}
				else if (this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (!((StructureElement)A_1.Tag).o().Contains(Attribute.Width))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
				}
				else if (this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CD1 RID: 15569 RVA: 0x0020B7F8 File Offset: 0x0020A7F8
		private void a(Note A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CD2 RID: 15570 RVA: 0x0020BA44 File Offset: 0x0020AA44
		private object a(Note A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			if (A_2 != Attribute.Color)
			{
				switch (A_2)
				{
				case Attribute.BBox:
					result = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, 0f).a());
					break;
				case Attribute.Width:
					result = new AttributeObject.d(A_0.Width);
					break;
				case Attribute.Height:
					result = new AttributeObject.d(A_0.Height);
					break;
				default:
					result = this.a(A_2, A_1);
					break;
				}
			}
			else
			{
				RgbColor rgbColor = A_0.Color.m();
				result = new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			return result;
		}

		// Token: 0x06003CD3 RID: 15571 RVA: 0x0020BB48 File Offset: 0x0020AB48
		private void a(PageWriter A_0, Image A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (A_1.Tag == null || (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox)))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				if (A_1.Tag != null)
				{
					((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
				}
			}
			else if (A_1.Tag != null && this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a((StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (A_0.Document.Tag != null && A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (A_1.Tag == null || (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300)))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(300, b);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (A_1.Tag == null || (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width)))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CD4 RID: 15572 RVA: 0x0020BF7C File Offset: 0x0020AF7C
		private object a(Image A_0, PageWriter A_1, Attribute A_2)
		{
			object result;
			switch (A_2)
			{
			case Attribute.BBox:
				result = new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.Width, A_0.Height, A_0.Angle).a());
				break;
			case Attribute.Width:
				result = new AttributeObject.d(A_0.Width);
				break;
			case Attribute.Height:
				result = new AttributeObject.d(A_0.Height);
				break;
			default:
				result = this.a(A_2, A_1);
				break;
			}
			return result;
		}

		// Token: 0x06003CD5 RID: 15573 RVA: 0x0020C040 File Offset: 0x0020B040
		private void a(Image A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CD6 RID: 15574 RVA: 0x0020C28C File Offset: 0x0020B28C
		private void a(PageWriter A_0, Table A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (A_1.Tag == null || (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox)))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				if (A_1.Tag != null)
				{
					((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
				}
			}
			else if (A_1.Tag != null && this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a(A_1, (StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (this.m[Attribute.BorderThickness] == null)
			{
				object value = this.a(A_1, A_0, Attribute.BorderThickness);
				this.m[Attribute.BorderThickness] = value;
			}
			if (this.m[Attribute.BorderColor] == null)
			{
				object value = this.a(A_1, A_0, Attribute.BorderColor);
				this.m[Attribute.BorderColor] = value;
			}
			if (A_0.Document.Tag != null && A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (A_1.Tag == null || (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Height)))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(300, b);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a(A_1, (StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (A_1.Tag == null || (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width)))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a(A_1, (StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CD7 RID: 15575 RVA: 0x0020C73C File Offset: 0x0020B73C
		private object a(Table A_0, PageWriter A_1, Attribute A_2)
		{
			switch (A_2)
			{
			case Attribute.BorderColor:
			{
				RgbColor rgbColor = A_0.BorderColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.BorderThickness:
				return new AttributeObject.d(A_0.BorderWidth);
			case Attribute.Color:
			{
				RgbColor rgbColor = A_0.TextColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.StartIndent:
			case Attribute.TextIndent:
			case Attribute.TextAlign:
			case Attribute.BlockAlign:
			case Attribute.InlineAlign:
			case Attribute.LineHeight:
				break;
			case Attribute.EndIndent:
				return new AttributeObject.d(A_1.Page.Dimensions.Width - (A_1.Page.Dimensions.Edge.Left + A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y) + A_0.GetVisibleWidth()));
			case Attribute.TBorderStyle:
				return new AttributeObject.g(BorderStyleAttribute.Solid);
			case Attribute.TPadding:
				return new AttributeObject.d(A_0.Padding);
			case Attribute.TextDecorationColor:
			{
				RgbColor rgbColor = A_0.TextColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			default:
				switch (A_2)
				{
				case Attribute.BackgroundColor:
				{
					RgbColor rgbColor = A_0.BackgroundColor.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				case Attribute.BorderStyle:
					return new AttributeObject.g(BorderStyleAttribute.Solid);
				case Attribute.Padding:
					return new AttributeObject.d(A_0.Padding);
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.GetVisibleWidth(), A_0.GetVisibleHeight(), A_0.Angle).a());
				case Attribute.Width:
					return new AttributeObject.d(A_0.GetVisibleWidth());
				case Attribute.Height:
					return new AttributeObject.d(A_0.GetVisibleHeight());
				}
				break;
			}
			return this.a(A_2, A_1);
		}

		// Token: 0x06003CD8 RID: 15576 RVA: 0x0020C9F0 File Offset: 0x0020B9F0
		private void a(Table A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value;
					if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
					{
						if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], value);
							}
						}
						else
						{
							value = ((StructureElement)A_0.Tag).o()[array[i]];
							this.m[array[i]] = value;
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a(A_0, (StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CD9 RID: 15577 RVA: 0x0020CC3C File Offset: 0x0020BC3C
		internal void a(acx A_0, Cell A_1, bool A_2)
		{
			if (A_2)
			{
				if (this.m[Attribute.LineHeight] == null)
				{
					this.m[Attribute.LineHeight] = this.a(A_1, A_0, Attribute.LineHeight, A_2);
				}
				if (A_1.Underline)
				{
					if (this.m[Attribute.TextDecorationType] == null)
					{
						this.m[Attribute.TextDecorationType] = this.a(A_1, A_0, Attribute.TextDecorationType, A_2);
					}
				}
				if (A_0.c().Document.Tag.IncludeLayoutAttributes)
				{
					if (this.m[Attribute.TextAlign] == null)
					{
						this.m[Attribute.TextAlign] = this.a(A_1, A_0, Attribute.TextAlign, A_2);
					}
					if (this.m[Attribute.StartIndent] == null)
					{
						this.m[Attribute.StartIndent] = this.a(A_1, A_0, Attribute.StartIndent, A_2);
					}
					if (this.m[Attribute.EndIndent] == null)
					{
						this.m[Attribute.EndIndent] = this.a(A_1, A_0, Attribute.EndIndent, A_2);
					}
				}
			}
			else if (A_0.c().Document.Tag != null)
			{
				AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox, A_2);
				if (A_1.Tag != null)
				{
					if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
					{
						object value = this.a(A_1, A_0, Attribute.BBox, A_2);
						((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
					}
					else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
					{
						this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
						this.b((StructureElement)A_1.Tag, Attribute.BBox, b, false);
					}
				}
				if (A_1.Tag == null || (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300)))
				{
					object value = this.a(A_1, A_0, Attribute.Height, A_2);
					this.m[Attribute.Height] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(300, b);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.b((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (A_1.Tag == null || (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width)))
				{
					object value = this.a(A_1, A_0, Attribute.Width, A_2);
					this.m[Attribute.Width] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.b((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
				this.o = true;
			}
		}

		// Token: 0x06003CDA RID: 15578 RVA: 0x0020D18C File Offset: 0x0020C18C
		private object a(Cell A_0, acx A_1, Attribute A_2, bool A_3)
		{
			PageWriter a_ = A_1.c();
			object result;
			if (A_3)
			{
				TextLineList textLineList = A_0.j();
				if (A_2 <= Attribute.TextAlign)
				{
					if (A_2 == Attribute.WritingMode)
					{
						return new AttributeObject.g(A_0.RightToLeft ? WritingMode.RlTb : WritingMode.LrTb);
					}
					switch (A_2)
					{
					case Attribute.Color:
					{
						RgbColor rgbColor = A_0.TextColor.m();
						return new AttributeObject.b(new float[]
						{
							rgbColor.R,
							rgbColor.G,
							rgbColor.B
						});
					}
					case Attribute.TextIndent:
						return new AttributeObject.d(textLineList.ParagraphIndent);
					case Attribute.TextAlign:
						switch (A_0.Align)
						{
						case CellAlign.Left:
							return new AttributeObject.g(TextAlignAttribute.Start);
						case CellAlign.Center:
							return new AttributeObject.g(TextAlignAttribute.Center);
						case CellAlign.Right:
							return new AttributeObject.g(TextAlignAttribute.End);
						case CellAlign.Justify:
							return new AttributeObject.g(TextAlignAttribute.Justify);
						case CellAlign.FullJustify:
							return new AttributeObject.g(TextAlignAttribute.Justify);
						default:
							return string.Empty;
						}
						break;
					}
				}
				else
				{
					switch (A_2)
					{
					case Attribute.LineHeight:
						return new AttributeObject.d(textLineList.Leading);
					case Attribute.TextDecorationColor:
					{
						RgbColor rgbColor = A_0.TextColor.m();
						return new AttributeObject.b(new float[]
						{
							rgbColor.R,
							rgbColor.G,
							rgbColor.B
						});
					}
					default:
						switch (A_2)
						{
						case Attribute.BackgroundColor:
						{
							RgbColor rgbColor = A_0.BackgroundColor.m();
							return new AttributeObject.b(new float[]
							{
								rgbColor.R,
								rgbColor.G,
								rgbColor.B
							});
						}
						case Attribute.SpaceBefore:
							return new AttributeObject.d(textLineList.ParagraphSpacing);
						case Attribute.SpaceAfter:
							return new AttributeObject.d(textLineList.ParagraphSpacing);
						case Attribute.Width:
							return new AttributeObject.d(textLineList.Width);
						case Attribute.Height:
							return textLineList.l() ? null : new AttributeObject.d(textLineList.GetRequiredHeight(0));
						case Attribute.TextDecorationType:
							return new AttributeObject.g(A_0.Underline ? TextDecorationType.Underline : TextDecorationType.None);
						}
						break;
					}
				}
				result = this.a(A_2, a_);
			}
			else
			{
				if (A_2 <= Attribute.TPadding)
				{
					switch (A_2)
					{
					case Attribute.BorderColor:
					{
						RgbColor rgbColor = A_1.d().BorderColor.m();
						return new AttributeObject.b(new float[]
						{
							rgbColor.R,
							rgbColor.G,
							rgbColor.B
						});
					}
					case Attribute.BorderThickness:
						return new AttributeObject.d(A_1.d().BorderWidth);
					default:
						switch (A_2)
						{
						case Attribute.TBorderStyle:
							return new AttributeObject.g(BorderStyleAttribute.Solid);
						case Attribute.TPadding:
							return new AttributeObject.d(A_0.Padding);
						}
						break;
					}
				}
				else
				{
					switch (A_2)
					{
					case Attribute.RowSpan:
						return new AttributeObject.e(A_0.RowSpan);
					case Attribute.ColSpan:
						return new AttributeObject.e(A_0.ColumnSpan);
					default:
						switch (A_2)
						{
						case Attribute.BackgroundColor:
						{
							RgbColor rgbColor = A_0.BackgroundColor.m();
							return new AttributeObject.b(new float[]
							{
								rgbColor.R,
								rgbColor.G,
								rgbColor.B
							});
						}
						case Attribute.BorderStyle:
							return new AttributeObject.g(BorderStyleAttribute.Solid);
						case Attribute.Padding:
							return new AttributeObject.d(A_0.Padding);
						case Attribute.BBox:
							return new AttributeObject.b(new BoundingBox(A_1.c().Page, A_1.a() + A_0.Padding, A_1.b() + A_0.Padding, A_0.Width - A_0.Padding * 2f, A_0.Height - A_0.Padding * 2f, A_1.d().Angle).a());
						case Attribute.Width:
							return new AttributeObject.d(A_0.Width);
						case Attribute.Height:
							return new AttributeObject.d(A_0.Height);
						}
						break;
					}
				}
				result = this.a(A_2, a_);
			}
			return result;
		}

		// Token: 0x06003CDB RID: 15579 RVA: 0x0020D640 File Offset: 0x0020C640
		internal void a(Cell A_0, acx A_1, bool A_2)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox, false);
			bool a_ = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value = this.a(A_0, A_1, array[i], A_2);
					this.m[array[i]] = value;
					if ((array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height) && !((StructureElement)A_0.Tag).o().Contains(array[i]))
					{
						if (array[i] == Attribute.BBox)
						{
							((StructureElement)A_0.Tag).o().Add(array[i], value);
						}
						else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
						{
							if (!((StructureElement)A_0.Tag).o().Contains(300))
							{
								((StructureElement)A_0.Tag).o().Add(300, b);
							}
							((StructureElement)A_0.Tag).o().Add(array[i], value);
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					this.b((StructureElement)A_0.Tag, array[i], b, a_);
				}
			}
		}

		// Token: 0x06003CDC RID: 15580 RVA: 0x0020D854 File Offset: 0x0020C854
		private bool b(StructureElement A_0, Attribute A_1, AttributeObject.b A_2, bool A_3)
		{
			switch (A_1)
			{
			case Attribute.BBox:
			{
				AttributeObject.b b = (AttributeObject.b)A_0.o()[A_1];
				((AttributeObject.b)A_0.o()[A_1]).a(AttributeObject.a(b.a(), A_2.a()));
				break;
			}
			case Attribute.Width:
			case Attribute.Height:
			{
				AttributeObject.b b = (AttributeObject.b)A_0.o()[300];
				if (!A_3)
				{
					b.a(AttributeObject.a(b.a(), A_2.a()));
					A_3 = true;
				}
				if (A_1 == Attribute.Height)
				{
					AttributeObject.d d = (AttributeObject.d)A_0.o()[A_1];
					d.a(b.a()[3] - b.a()[1]);
				}
				else if (A_1 == Attribute.Width)
				{
					AttributeObject.d d2 = (AttributeObject.d)A_0.o()[A_1];
					d2.a(b.a()[2] - b.a()[0]);
				}
				break;
			}
			}
			return A_3;
		}

		// Token: 0x06003CDD RID: 15581 RVA: 0x0020D99C File Offset: 0x0020C99C
		private object a(Row A_0, acx A_1, Attribute A_2)
		{
			PageWriter a_ = A_1.c();
			object result;
			switch (A_2)
			{
			case Attribute.BorderColor:
			{
				RgbColor rgbColor = A_1.d().BorderColor.m();
				result = new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
				break;
			}
			case Attribute.BorderThickness:
				result = new AttributeObject.d(A_1.d().BorderWidth);
				break;
			default:
				switch (A_2)
				{
				case Attribute.TBorderStyle:
					result = new AttributeObject.g(BorderStyleAttribute.Solid);
					break;
				case Attribute.TPadding:
					result = new AttributeObject.d(A_0.Padding);
					break;
				default:
					switch (A_2)
					{
					case Attribute.BackgroundColor:
					{
						RgbColor rgbColor = A_0.BackgroundColor.m();
						return new AttributeObject.b(new float[]
						{
							rgbColor.R,
							rgbColor.G,
							rgbColor.B
						});
					}
					case Attribute.BorderStyle:
						return new AttributeObject.g(BorderStyleAttribute.Solid);
					case Attribute.Padding:
						return new AttributeObject.d(A_0.Padding);
					case Attribute.BBox:
						return new AttributeObject.b(new BoundingBox(A_1.c().Page, A_1.a(), A_1.b(), A_1.d().Width, A_0.ActualRowHeight, A_1.d().Angle).a());
					case Attribute.Width:
					{
						float num = 0f;
						Table table = A_1.d();
						if (A_0.Tag == null)
						{
							num = table.GetVisibleWidth();
						}
						else
						{
							for (int i = 0; i < table.e() + table.RepeatRowHeaderCount; i++)
							{
								num += table.Columns[i].Width;
							}
						}
						return new AttributeObject.d(num);
					}
					case Attribute.Height:
						return new AttributeObject.d(A_0.Height);
					}
					result = this.a(A_2, a_);
					break;
				}
				break;
			}
			return result;
		}

		// Token: 0x06003CDE RID: 15582 RVA: 0x0020DBC0 File Offset: 0x0020CBC0
		internal void a(acx A_0, Row A_1)
		{
			if (A_1.Tag != null && A_1.Tag.g())
			{
				AttributeObject.b value = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
				if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
				{
					object value2 = this.a(A_1, A_0, Attribute.BBox);
					((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value2);
				}
				else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
				{
					this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
					this.a(A_0, A_1, Attribute.BBox);
				}
				if (A_1.Tag == null || (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300)))
				{
					object value2 = this.a(A_1, A_0, Attribute.Height);
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(300, value);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value2);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a(A_0, A_1, Attribute.Height);
				}
				if (A_1.Tag == null || (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width)))
				{
					object value2 = this.a(A_1, A_0, Attribute.Width);
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value2);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a(A_0, A_1, Attribute.Width);
				}
			}
		}

		// Token: 0x06003CDF RID: 15583 RVA: 0x0020DF3C File Offset: 0x0020CF3C
		internal void a(Row A_0, acx A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b value = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					object value2 = this.a(A_0, A_1, array[i]);
					this.m[array[i]] = value2;
					if ((array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height) && !((StructureElement)A_0.Tag).o().Contains(array[i]))
					{
						if (array[i] == Attribute.BBox)
						{
							((StructureElement)A_0.Tag).o().Add(array[i], value2);
						}
						else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
						{
							if (!((StructureElement)A_0.Tag).o().Contains(300))
							{
								((StructureElement)A_0.Tag).o().Add(300, value);
							}
							((StructureElement)A_0.Tag).o().Add(array[i], value2);
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					this.a(A_1, A_0, array[i]);
				}
			}
		}

		// Token: 0x06003CE0 RID: 15584 RVA: 0x0020E13C File Offset: 0x0020D13C
		private void a(acx A_0, Row A_1, Attribute A_2)
		{
			StructureElement structureElement = (StructureElement)A_1.Tag;
			float[] a_ = new BoundingBox(A_0.c().Page, A_0.a(), A_0.b(), A_0.d().Width, A_1.ActualRowHeight, A_0.d().Angle).a();
			switch (A_2)
			{
			case Attribute.BBox:
			{
				AttributeObject.b b = (AttributeObject.b)structureElement.o()[A_2];
				((AttributeObject.b)structureElement.o()[A_2]).a(AttributeObject.a(b.a(), a_));
				break;
			}
			case Attribute.Width:
			{
				float num = 0f;
				Table table = A_0.d();
				for (int i = table.d(); i < table.e() + table.RepeatRowHeaderCount; i++)
				{
					num += table.Columns[i].Width;
				}
				((AttributeObject.d)structureElement.o()[A_2]).a(num + ((AttributeObject.d)structureElement.o()[A_2]).a());
				break;
			}
			case Attribute.Height:
			{
				AttributeObject.b b = (AttributeObject.b)structureElement.o()[300];
				b.a(AttributeObject.a(b.a(), a_));
				AttributeObject.d d = (AttributeObject.d)structureElement.o()[A_2];
				d.a(b.a()[3] - b.a()[1]);
				break;
			}
			}
		}

		// Token: 0x06003CE1 RID: 15585 RVA: 0x0020E2E8 File Offset: 0x0020D2E8
		private bool a(Table A_0, StructureElement A_1, Attribute A_2, AttributeObject.b A_3, bool A_4)
		{
			switch (A_2)
			{
			case Attribute.BBox:
			{
				float[] a_ = ((AttributeObject.b)A_1.o()[A_2]).a();
				((AttributeObject.b)A_1.o()[A_2]).a(AttributeObject.a(a_, A_3.a()));
				break;
			}
			case Attribute.Width:
			{
				float num = 0f;
				if (((StructureElement)A_0.Tag).n().b() > A_0.Rows.Count)
				{
					if (!this.o)
					{
						num = A_0.GetVisibleWidth();
					}
				}
				else
				{
					for (int i = A_0.d(); i < A_0.e() + A_0.RepeatRowHeaderCount; i++)
					{
						num += A_0.Columns[i].Width;
					}
				}
				((AttributeObject.d)A_1.o()[A_2]).a(num + ((AttributeObject.d)A_1.o()[A_2]).a());
				break;
			}
			case Attribute.Height:
			{
				float num2 = 0f;
				if (((StructureElement)A_0.Tag).n().b() <= A_0.Rows.Count)
				{
					if (!this.o)
					{
						num2 = A_0.GetVisibleHeight();
					}
				}
				else
				{
					for (int j = A_0.b(); j <= A_0.c() + A_0.RepeatColumnHeaderCount; j++)
					{
						if (j < A_0.Rows.Count)
						{
							num2 += A_0.Rows[j].ActualRowHeight;
						}
					}
				}
				((AttributeObject.d)A_1.o()[A_2]).a(num2 + ((AttributeObject.d)A_1.o()[A_2]).a());
				break;
			}
			}
			return A_4;
		}

		// Token: 0x06003CE2 RID: 15586 RVA: 0x0020E504 File Offset: 0x0020D504
		private void a(PageWriter A_0, Table2 A_1)
		{
			AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
			if (A_1.Tag == null || (this.m[Attribute.BBox] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.BBox)))
			{
				object value = this.a(A_1, A_0, Attribute.BBox);
				this.m[Attribute.BBox] = value;
				if (A_1.Tag != null)
				{
					((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
				}
			}
			else if (A_1.Tag != null && this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
			{
				this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
				this.a(A_1, (StructureElement)A_1.Tag, Attribute.BBox, b, false);
			}
			if (this.m[Attribute.BorderThickness] == null)
			{
				object value = this.a(A_1, A_0, Attribute.BorderThickness);
				this.m[Attribute.BorderThickness] = value;
			}
			if (this.m[Attribute.BorderColor] == null)
			{
				object value = this.a(A_1, A_0, Attribute.BorderColor);
				this.m[Attribute.BorderColor] = value;
			}
			if (A_0.Document.Tag != null && A_0.Document.Tag.IncludeLayoutAttributes)
			{
				if (A_1.Tag == null || (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Height)))
				{
					object value = this.a(A_1, A_0, Attribute.Height);
					this.m[Attribute.Height] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(300, b);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a(A_1, (StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (A_1.Tag == null || (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width)))
				{
					object value = this.a(A_1, A_0, Attribute.Width);
					this.m[Attribute.Width] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a(A_1, (StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
			}
			this.o = true;
		}

		// Token: 0x06003CE3 RID: 15587 RVA: 0x0020E9B4 File Offset: 0x0020D9B4
		private object a(Table2 A_0, PageWriter A_1, Attribute A_2)
		{
			switch (A_2)
			{
			case Attribute.BorderColor:
			{
				if (!A_0.CellDefault.Border.b())
				{
					return new AttributeObject.h(new RgbColor[]
					{
						A_0.CellDefault.Border.Top.b(),
						A_0.CellDefault.Border.Bottom.b(),
						A_0.CellDefault.Border.Left.b(),
						A_0.CellDefault.Border.Right.b()
					});
				}
				if (A_0.CellDefault.Border.Top.Color == null)
				{
					return null;
				}
				RgbColor rgbColor = A_0.CellDefault.Border.Top.Color.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.BorderThickness:
				if (A_0.CellDefault.Border.d())
				{
					return new AttributeObject.d(A_0.CellDefault.Border.Top.Width.Value);
				}
				return new AttributeObject.b(new float[]
				{
					A_0.CellDefault.Border.Top.a(),
					A_0.CellDefault.Border.Bottom.a(),
					A_0.CellDefault.Border.Left.a(),
					A_0.CellDefault.Border.Right.a()
				});
			case Attribute.Color:
			{
				RgbColor rgbColor = A_0.CellDefault.TextColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.StartIndent:
			case Attribute.TextIndent:
			case Attribute.TextAlign:
			case Attribute.BlockAlign:
			case Attribute.InlineAlign:
			case Attribute.LineHeight:
				goto IL_5B3;
			case Attribute.EndIndent:
				return new AttributeObject.d(A_1.Page.Dimensions.Width - (A_1.Page.Dimensions.Edge.Left + A_1.Page.Dimensions.LeftMargin + A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y) + A_0.GetVisibleWidth()));
			case Attribute.TBorderStyle:
				goto IL_4D0;
			case Attribute.TPadding:
				break;
			case Attribute.TextDecorationColor:
			{
				RgbColor rgbColor = A_0.CellDefault.TextColor.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			default:
				switch (A_2)
				{
				case Attribute.BackgroundColor:
				{
					if (A_0.CellDefault.BackgroundColor == null)
					{
						return null;
					}
					RgbColor rgbColor = A_0.CellDefault.BackgroundColor.m();
					return new AttributeObject.b(new float[]
					{
						rgbColor.R,
						rgbColor.G,
						rgbColor.B
					});
				}
				case Attribute.BorderStyle:
					goto IL_4D0;
				case Attribute.Padding:
					break;
				case Attribute.SpaceBefore:
				case Attribute.SpaceAfter:
					goto IL_5B3;
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_1.Page, A_1.Dimensions.a3(A_1.Page.Dimensions, A_0.X, A_0.Y), A_1.Dimensions.a4(A_1.Page.Dimensions, A_0.X, A_0.Y), A_0.GetVisibleWidth(), A_0.GetVisibleHeight(), A_0.Angle).a());
				case Attribute.Width:
					return new AttributeObject.d(A_0.GetVisibleWidth());
				case Attribute.Height:
					return new AttributeObject.d(A_0.GetVisibleHeight());
				default:
					goto IL_5B3;
				}
				break;
			}
			if (!A_0.CellDefault.Padding.a())
			{
				return new AttributeObject.b(new float[]
				{
					A_0.CellDefault.Padding.d(),
					A_0.CellDefault.Padding.e(),
					A_0.CellDefault.Padding.c(),
					A_0.CellDefault.Padding.b()
				});
			}
			if (A_0.CellDefault.Padding.Top == null)
			{
				return null;
			}
			return new AttributeObject.d(A_0.CellDefault.Padding.Top.Value);
			IL_4D0:
			if (!A_0.CellDefault.Border.c())
			{
				return new AttributeObject.c(new string[]
				{
					A_0.CellDefault.Border.Top.c(),
					A_0.CellDefault.Border.Bottom.c(),
					A_0.CellDefault.Border.Left.c(),
					A_0.CellDefault.Border.Right.c()
				});
			}
			if (A_0.CellDefault.Border.Top.LineStyle == null)
			{
				return null;
			}
			return new AttributeObject.g(A_0.CellDefault.Border.Top.LineStyle.a());
			IL_5B3:
			return this.a(A_2, A_1);
		}

		// Token: 0x06003CE4 RID: 15588 RVA: 0x0020EF80 File Offset: 0x0020DF80
		private void a(Table2 A_0, PageWriter A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			bool a_ = false;
			int i = 0;
			while (i < array.Length)
			{
				if (this.m[array[i]] == null)
				{
					object obj = this.a(A_0, A_1, array[i]);
					if (obj == null)
					{
						this.m.Remove(array[i]);
					}
					else
					{
						this.m[array[i]] = obj;
						if (array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height)
						{
							if (!((StructureElement)A_0.Tag).o().Contains(array[i]))
							{
								if (array[i] == Attribute.BBox)
								{
									((StructureElement)A_0.Tag).o().Add(array[i], obj);
								}
								else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
								{
									if (!((StructureElement)A_0.Tag).o().Contains(300))
									{
										((StructureElement)A_0.Tag).o().Add(300, b);
									}
									((StructureElement)A_0.Tag).o().Add(array[i], obj);
								}
							}
							else
							{
								obj = ((StructureElement)A_0.Tag).o()[array[i]];
								this.m[array[i]] = obj;
							}
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					a_ = this.a(A_0, (StructureElement)A_0.Tag, array[i], b, a_);
				}
				IL_252:
				i++;
				continue;
				goto IL_252;
			}
		}

		// Token: 0x06003CE5 RID: 15589 RVA: 0x0020F1F4 File Offset: 0x0020E1F4
		internal void a(q0 A_0, Cell2 A_1, bool A_2)
		{
			if (A_2)
			{
				if (this.m[Attribute.LineHeight] == null)
				{
					this.m[Attribute.LineHeight] = this.a(A_1, A_0, Attribute.LineHeight, A_2);
				}
				if (A_1.Underline != null)
				{
					if (A_1.n().f().Value)
					{
						if (this.m[Attribute.TextDecorationType] == null)
						{
							this.m[Attribute.TextDecorationType] = this.a(A_1, A_0, Attribute.TextDecorationType, A_2);
						}
					}
				}
				else if (this.m[Attribute.TextDecorationType] == null)
				{
					this.m.Remove(Attribute.TextDecorationType);
				}
				if (A_0.c().Document.Tag.IncludeLayoutAttributes)
				{
					if (A_1.n() != null && A_1.n().j() != null)
					{
						if (this.m[Attribute.TextAlign] == null)
						{
							this.m[Attribute.TextAlign] = this.a(A_1, A_0, Attribute.TextAlign, A_2);
						}
					}
					else if (this.m[Attribute.TextAlign] == null)
					{
						this.m.Remove(Attribute.TextAlign);
					}
					if (this.m[Attribute.StartIndent] == null)
					{
						this.m[Attribute.StartIndent] = this.a(A_1, A_0, Attribute.StartIndent, A_2);
					}
					if (this.m[Attribute.EndIndent] == null)
					{
						this.m[Attribute.EndIndent] = this.a(A_1, A_0, Attribute.EndIndent, A_2);
					}
				}
			}
			else if (A_0.c().Document.Tag != null)
			{
				AttributeObject.b b = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox, A_2);
				if (A_1.Tag != null)
				{
					if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
					{
						object value = this.a(A_1, A_0, Attribute.BBox, A_2);
						((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value);
					}
					else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
					{
						this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
						this.b((StructureElement)A_1.Tag, Attribute.BBox, b, false);
					}
				}
				if (A_1.Tag == null || (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300)))
				{
					object value = this.a(A_1, A_0, Attribute.Height, A_2);
					this.m[Attribute.Height] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(300, b);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.b((StructureElement)A_1.Tag, Attribute.Height, b, false);
				}
				if (A_1.Tag == null || (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width)))
				{
					object value = this.a(A_1, A_0, Attribute.Width, A_2);
					this.m[Attribute.Width] = value;
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.b((StructureElement)A_1.Tag, Attribute.Width, b, true);
				}
				this.o = true;
			}
		}

		// Token: 0x06003CE6 RID: 15590 RVA: 0x0020F7FC File Offset: 0x0020E7FC
		private object a(Cell2 A_0, q0 A_1, Attribute A_2, bool A_3)
		{
			PageWriter a_ = A_1.c();
			object result;
			if (A_3)
			{
				TextLineList textLineList = A_0.o();
				if (A_2 <= Attribute.TextAlign)
				{
					if (A_2 != Attribute.WritingMode)
					{
						switch (A_2)
						{
						case Attribute.Color:
						{
							if (A_0.n() == null)
							{
								return null;
							}
							RgbColor rgbColor = A_0.n().i().m();
							return new AttributeObject.b(new float[]
							{
								rgbColor.R,
								rgbColor.G,
								rgbColor.B
							});
						}
						case Attribute.TextIndent:
							return new AttributeObject.d(textLineList.ParagraphIndent);
						case Attribute.TextAlign:
						{
							if (A_0.n() == null)
							{
								return null;
							}
							TextAlign? textAlign = A_0.n().j();
							if (textAlign == null)
							{
								return null;
							}
							textAlign = A_0.n().j();
							TextAlign valueOrDefault = textAlign.GetValueOrDefault();
							if (textAlign != null)
							{
								switch (valueOrDefault)
								{
								case TextAlign.Left:
									return new AttributeObject.g(TextAlignAttribute.Start);
								case TextAlign.Center:
									return new AttributeObject.g(TextAlignAttribute.Center);
								case TextAlign.Right:
									return new AttributeObject.g(TextAlignAttribute.End);
								case TextAlign.Justify:
									return new AttributeObject.g(TextAlignAttribute.Justify);
								case TextAlign.FullJustify:
									return new AttributeObject.g(TextAlignAttribute.Justify);
								}
							}
							return new AttributeObject.f(string.Empty);
						}
						}
					}
					else
					{
						if (A_0.n() == null)
						{
							return null;
						}
						return new AttributeObject.g(A_0.n().e().Value ? WritingMode.RlTb : WritingMode.LrTb);
					}
				}
				else
				{
					switch (A_2)
					{
					case Attribute.LineHeight:
						return new AttributeObject.d(textLineList.Leading);
					case Attribute.TextDecorationColor:
					{
						if (A_0.n() == null)
						{
							return null;
						}
						RgbColor rgbColor = A_0.n().i().m();
						return new AttributeObject.b(new float[]
						{
							rgbColor.R,
							rgbColor.G,
							rgbColor.B
						});
					}
					default:
						switch (A_2)
						{
						case Attribute.SpaceBefore:
							return new AttributeObject.d(textLineList.ParagraphSpacing);
						case Attribute.SpaceAfter:
							return new AttributeObject.d(textLineList.ParagraphSpacing);
						case Attribute.Width:
							return new AttributeObject.d(textLineList.Width);
						case Attribute.Height:
							return textLineList.l() ? null : new AttributeObject.d(textLineList.GetRequiredHeight(0));
						case Attribute.TextDecorationType:
							if (A_0.n() == null)
							{
								return null;
							}
							return new AttributeObject.g(A_0.n().f().Value ? TextDecorationType.Underline : TextDecorationType.None);
						}
						break;
					}
				}
				result = this.a(A_2, a_);
			}
			else
			{
				float num = A_0.Padding.a() ? ((A_0.Padding.Top == null) ? 0f : A_0.Padding.Top.Value) : ((A_0.Padding.Value == null) ? 0f : A_0.Padding.Value.Value);
				if (A_2 <= Attribute.TPadding)
				{
					switch (A_2)
					{
					case Attribute.BorderColor:
					{
						if (!A_0.Border.b())
						{
							return new AttributeObject.h(new RgbColor[]
							{
								A_0.Border.Top.b(),
								A_0.Border.Bottom.b(),
								A_0.Border.Left.b(),
								A_0.Border.Right.b()
							});
						}
						if (A_0.Border.Top.Color == null)
						{
							return null;
						}
						RgbColor rgbColor = A_0.Border.Top.Color.m();
						return new AttributeObject.b(new float[]
						{
							rgbColor.R,
							rgbColor.G,
							rgbColor.B
						});
					}
					case Attribute.BorderThickness:
						if (!A_0.Border.d())
						{
							return new AttributeObject.b(new float[]
							{
								A_0.Border.Top.a(),
								A_0.Border.Bottom.a(),
								A_0.Border.Left.a(),
								A_0.Border.Right.a()
							});
						}
						if (A_0.Border.Top.Width == null)
						{
							return null;
						}
						return new AttributeObject.d(A_0.Border.Top.Width.Value);
					default:
						switch (A_2)
						{
						case Attribute.TBorderStyle:
							goto IL_5ED;
						case Attribute.TPadding:
							break;
						default:
							goto IL_85F;
						}
						break;
					}
				}
				else
				{
					switch (A_2)
					{
					case Attribute.RowSpan:
						return new AttributeObject.e(A_0.RowSpan);
					case Attribute.ColSpan:
						return new AttributeObject.e(A_0.ColumnSpan);
					default:
						switch (A_2)
						{
						case Attribute.BackgroundColor:
						{
							if (A_0.n() == null || A_0.n().l() == null)
							{
								return null;
							}
							RgbColor rgbColor = A_0.n().l().m();
							return new AttributeObject.b(new float[]
							{
								rgbColor.R,
								rgbColor.G,
								rgbColor.B
							});
						}
						case Attribute.BorderStyle:
							goto IL_5ED;
						case Attribute.Padding:
							break;
						case Attribute.SpaceBefore:
						case Attribute.SpaceAfter:
							goto IL_85F;
						case Attribute.BBox:
							return new AttributeObject.b(new BoundingBox(A_1.c().Page, A_1.a() + num, A_1.b() + num, A_0.Width - num * 2f, A_0.Height - num * 2f, A_1.d().Angle).a());
						case Attribute.Width:
							return new AttributeObject.d(A_0.Width);
						case Attribute.Height:
							return new AttributeObject.d(A_0.Height);
						default:
							goto IL_85F;
						}
						break;
					}
				}
				if (!A_0.Padding.a())
				{
					return new AttributeObject.b(new float[]
					{
						A_0.Padding.d(),
						A_0.Padding.e(),
						A_0.Padding.c(),
						A_0.Padding.b()
					});
				}
				if (A_0.Padding.Top == null)
				{
					return null;
				}
				return new AttributeObject.d(A_0.Padding.Top.Value);
				IL_5ED:
				if (!A_0.Border.c())
				{
					return new AttributeObject.c(new string[]
					{
						A_0.Border.Top.c(),
						A_0.Border.Bottom.c(),
						A_0.Border.Left.c(),
						A_0.Border.Right.c()
					});
				}
				if (A_0.Border.Top.LineStyle == null)
				{
					return null;
				}
				return new AttributeObject.g(A_0.Border.Top.LineStyle.a());
				IL_85F:
				result = this.a(A_2, a_);
			}
			return result;
		}

		// Token: 0x06003CE7 RID: 15591 RVA: 0x00210084 File Offset: 0x0020F084
		internal void a(Cell2 A_0, q0 A_1, bool A_2)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b b = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox, false);
			bool a_ = false;
			int i = 0;
			while (i < array.Length)
			{
				if (this.m[array[i]] == null)
				{
					object obj = this.a(A_0, A_1, array[i], A_2);
					if (obj == null)
					{
						this.m.Remove(array[i]);
					}
					else
					{
						this.m[array[i]] = obj;
						if ((array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height) && !((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, b);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					this.b((StructureElement)A_0.Tag, array[i], b, a_);
				}
				IL_21A:
				i++;
				continue;
				goto IL_21A;
			}
		}

		// Token: 0x06003CE8 RID: 15592 RVA: 0x002102C0 File Offset: 0x0020F2C0
		private object a(Row2 A_0, q0 A_1, Attribute A_2)
		{
			PageWriter a_ = A_1.c();
			object result;
			switch (A_2)
			{
			case Attribute.BorderColor:
				if (A_0.CellDefault.Border.b())
				{
					if (A_0.CellDefault.Border.Top.Color == null)
					{
						result = null;
					}
					else
					{
						RgbColor rgbColor = A_0.CellDefault.Border.Top.Color.m();
						result = new AttributeObject.b(new float[]
						{
							rgbColor.R,
							rgbColor.G,
							rgbColor.B
						});
					}
				}
				else
				{
					result = new AttributeObject.h(new RgbColor[]
					{
						A_0.CellDefault.Border.Top.b(),
						A_0.CellDefault.Border.Bottom.b(),
						A_0.CellDefault.Border.Left.b(),
						A_0.CellDefault.Border.Right.b()
					});
				}
				break;
			case Attribute.BorderThickness:
				if (A_0.CellDefault.Border.d())
				{
					if (A_0.CellDefault.Border.Top.Width == null)
					{
						result = null;
					}
					else
					{
						result = new AttributeObject.d(A_0.CellDefault.Border.Top.Width.Value);
					}
				}
				else
				{
					result = new AttributeObject.b(new float[]
					{
						A_0.CellDefault.Border.Top.a(),
						A_0.CellDefault.Border.Bottom.a(),
						A_0.CellDefault.Border.Left.a(),
						A_0.CellDefault.Border.Right.a()
					});
				}
				break;
			default:
				switch (A_2)
				{
				case Attribute.TBorderStyle:
					goto IL_264;
				case Attribute.TPadding:
					break;
				default:
					switch (A_2)
					{
					case Attribute.BackgroundColor:
					{
						if (A_0.CellDefault.BackgroundColor == null)
						{
							return null;
						}
						RgbColor rgbColor = A_0.CellDefault.BackgroundColor.m();
						return new AttributeObject.b(new float[]
						{
							rgbColor.R,
							rgbColor.G,
							rgbColor.B
						});
					}
					case Attribute.BorderStyle:
						goto IL_264;
					case Attribute.Padding:
						goto IL_195;
					case Attribute.BBox:
						return new AttributeObject.b(new BoundingBox(A_1.c().Page, A_1.a(), A_1.b(), A_1.d().Width, A_0.ActualRowHeight, A_1.d().Angle).a());
					case Attribute.Width:
					{
						float num = 0f;
						Table2 table = A_1.d();
						if (A_0.Tag == null)
						{
							num = table.GetVisibleWidth();
						}
						else
						{
							for (int i = 0; i < table.j() + table.RepeatRowHeaderCount; i++)
							{
								num += table.Columns[i].Width;
							}
						}
						return new AttributeObject.d(num);
					}
					case Attribute.Height:
						return new AttributeObject.d(A_0.Height);
					}
					return this.a(A_2, a_);
				}
				IL_195:
				if (!A_0.CellDefault.Padding.a())
				{
					result = new AttributeObject.b(new float[]
					{
						A_0.CellDefault.Padding.d(),
						A_0.CellDefault.Padding.e(),
						A_0.CellDefault.Padding.c(),
						A_0.CellDefault.Padding.b()
					});
					break;
				}
				if (A_0.CellDefault.Padding.Top == null)
				{
					result = null;
					break;
				}
				result = new AttributeObject.d(A_0.CellDefault.Padding.Top.Value);
				break;
				IL_264:
				if (A_0.CellDefault.Border.c())
				{
					if (A_0.CellDefault.Border.Top.LineStyle == null)
					{
						result = null;
					}
					else
					{
						result = new AttributeObject.g(A_0.CellDefault.Border.Top.LineStyle.a());
					}
				}
				else
				{
					result = new AttributeObject.c(new string[]
					{
						A_0.CellDefault.Border.Top.c(),
						A_0.CellDefault.Border.Bottom.c(),
						A_0.CellDefault.Border.Left.c(),
						A_0.CellDefault.Border.Right.c()
					});
				}
				break;
			}
			return result;
		}

		// Token: 0x06003CE9 RID: 15593 RVA: 0x00210824 File Offset: 0x0020F824
		internal void a(q0 A_0, Row2 A_1)
		{
			if (A_1.Tag != null && A_1.Tag.g())
			{
				AttributeObject.b value = (AttributeObject.b)this.a(A_1, A_0, Attribute.BBox);
				if (!((StructureElement)A_1.Tag).o().Contains(Attribute.BBox))
				{
					object value2 = this.a(A_1, A_0, Attribute.BBox);
					((StructureElement)A_1.Tag).o().Add(Attribute.BBox, value2);
				}
				else if (this.m[Attribute.BBox] == ((StructureElement)A_1.Tag).o()[Attribute.BBox])
				{
					this.m[Attribute.BBox] = ((StructureElement)A_1.Tag).o()[Attribute.BBox];
					this.a(A_0, A_1, Attribute.BBox);
				}
				if (A_1.Tag == null || (this.m[Attribute.Height] == null && !((StructureElement)A_1.Tag).o().Contains(300)))
				{
					object value2 = this.a(A_1, A_0, Attribute.Height);
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(300, value);
						((StructureElement)A_1.Tag).o().Add(Attribute.Height, value2);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Height] == ((StructureElement)A_1.Tag).o()[Attribute.Height])
				{
					this.m[Attribute.Height] = ((StructureElement)A_1.Tag).o()[Attribute.Height];
					this.a(A_0, A_1, Attribute.Height);
				}
				if (A_1.Tag == null || (this.m[Attribute.Width] == null && !((StructureElement)A_1.Tag).o().Contains(Attribute.Width)))
				{
					object value2 = this.a(A_1, A_0, Attribute.Width);
					if (A_1.Tag != null)
					{
						((StructureElement)A_1.Tag).o().Add(Attribute.Width, value2);
					}
				}
				else if (A_1.Tag != null && this.m[Attribute.Width] == ((StructureElement)A_1.Tag).o()[Attribute.Width])
				{
					this.m[Attribute.Width] = ((StructureElement)A_1.Tag).o()[Attribute.Width];
					this.a(A_0, A_1, Attribute.Width);
				}
			}
		}

		// Token: 0x06003CEA RID: 15594 RVA: 0x00210BA0 File Offset: 0x0020FBA0
		internal void a(Row2 A_0, q0 A_1)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			AttributeObject.b value = (AttributeObject.b)this.a(A_0, A_1, Attribute.BBox);
			int i = 0;
			while (i < array.Length)
			{
				if (this.m[array[i]] == null)
				{
					object obj = this.a(A_0, A_1, array[i]);
					if (obj == null)
					{
						this.m.Remove(array[i]);
					}
					else
					{
						this.m[array[i]] = obj;
						if ((array[i] == Attribute.BBox || array[i] == Attribute.Width || array[i] == Attribute.Height) && !((StructureElement)A_0.Tag).o().Contains(array[i]))
						{
							if (array[i] == Attribute.BBox)
							{
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
							else if (array[i] == Attribute.Height || array[i] == Attribute.Width)
							{
								if (!((StructureElement)A_0.Tag).o().Contains(300))
								{
									((StructureElement)A_0.Tag).o().Add(300, value);
								}
								((StructureElement)A_0.Tag).o().Add(array[i], obj);
							}
						}
					}
				}
				else if (!this.o && ((StructureElement)A_0.Tag).o().Contains(array[i]))
				{
					this.a(A_1, A_0, array[i]);
				}
				IL_206:
				i++;
				continue;
				goto IL_206;
			}
		}

		// Token: 0x06003CEB RID: 15595 RVA: 0x00210DC8 File Offset: 0x0020FDC8
		internal void a(q0 A_0, Row2 A_1, Attribute A_2)
		{
			StructureElement structureElement = (StructureElement)A_1.Tag;
			float[] a_ = new BoundingBox(A_0.c().Page, A_0.a(), A_0.b(), A_0.d().Width, A_1.ActualRowHeight, A_0.d().Angle).a();
			switch (A_2)
			{
			case Attribute.BBox:
			{
				AttributeObject.b b = (AttributeObject.b)structureElement.o()[A_2];
				((AttributeObject.b)structureElement.o()[A_2]).a(AttributeObject.a(b.a(), a_));
				break;
			}
			case Attribute.Width:
			{
				float num = 0f;
				Table2 table = A_0.d();
				for (int i = table.i(); i < table.j() + table.RepeatRowHeaderCount; i++)
				{
					num += table.Columns[i].Width;
				}
				((AttributeObject.d)structureElement.o()[A_2]).a(num + ((AttributeObject.d)structureElement.o()[A_2]).a());
				break;
			}
			case Attribute.Height:
			{
				AttributeObject.b b = (AttributeObject.b)structureElement.o()[300];
				b.a(AttributeObject.a(b.a(), a_));
				AttributeObject.d d = (AttributeObject.d)structureElement.o()[A_2];
				d.a(b.a()[3] - b.a()[1]);
				break;
			}
			}
		}

		// Token: 0x06003CEC RID: 15596 RVA: 0x00210F74 File Offset: 0x0020FF74
		private bool a(Table2 A_0, StructureElement A_1, Attribute A_2, AttributeObject.b A_3, bool A_4)
		{
			switch (A_2)
			{
			case Attribute.BBox:
			{
				float[] a_ = ((AttributeObject.b)A_1.o()[A_2]).a();
				((AttributeObject.b)A_1.o()[A_2]).a(AttributeObject.a(a_, A_3.a()));
				break;
			}
			case Attribute.Width:
			{
				float num = 0f;
				if (((StructureElement)A_0.Tag).n().b() > A_0.Rows.Count)
				{
					if (!this.o)
					{
						num = A_0.GetVisibleWidth();
					}
				}
				else
				{
					for (int i = A_0.i(); i < A_0.j() + A_0.RepeatRowHeaderCount; i++)
					{
						num += A_0.Columns[i].Width;
					}
				}
				((AttributeObject.d)A_1.o()[A_2]).a(num + ((AttributeObject.d)A_1.o()[A_2]).a());
				break;
			}
			case Attribute.Height:
			{
				float num2 = 0f;
				if (((StructureElement)A_0.Tag).n().b() <= A_0.Rows.Count)
				{
					if (!this.o)
					{
						num2 = A_0.GetVisibleHeight();
					}
				}
				else
				{
					for (int j = A_0.g(); j <= A_0.h() + A_0.RepeatColumnHeaderCount; j++)
					{
						if (j < A_0.Rows.Count)
						{
							num2 += A_0.Rows[j].ActualRowHeight;
						}
					}
				}
				((AttributeObject.d)A_1.o()[A_2]).a(num2 + ((AttributeObject.d)A_1.o()[A_2]).a());
				break;
			}
			}
			return A_4;
		}

		// Token: 0x06003CED RID: 15597 RVA: 0x00211190 File Offset: 0x00210190
		internal void a(FormattedTextAreaStyle A_0, TaggablePageElement A_1, PageWriter A_2, float A_3, float A_4, float A_5, float A_6)
		{
			Attribute[] array = new Attribute[this.m.Count];
			this.m.Keys.CopyTo(array, 0);
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m[array[i]] == null)
				{
					this.m[array[i]] = this.a(A_0, (FormattedTextArea)A_1, A_2, A_3, A_4, A_5, array[i], A_6);
				}
			}
		}

		// Token: 0x06003CEE RID: 15598 RVA: 0x00211224 File Offset: 0x00210224
		private object a(FormattedTextAreaStyle A_0, FormattedTextArea A_1, PageWriter A_2, float A_3, float A_4, float A_5, Attribute A_6, float A_7)
		{
			switch (A_6)
			{
			case Attribute.Color:
			{
				RgbColor rgbColor = A_0.Font.Color.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			case Attribute.StartIndent:
				return new AttributeObject.d(A_2.Page.Dimensions.Edge.Left + A_2.Page.Dimensions.LeftMargin + A_2.Dimensions.a3(A_2.Page.Dimensions, A_4, A_5));
			case Attribute.EndIndent:
				return new AttributeObject.d(A_2.Page.Dimensions.Width - (A_2.Page.Dimensions.Edge.Left + A_2.Page.Dimensions.LeftMargin + A_2.Dimensions.a3(A_2.Page.Dimensions, A_4, A_5) + A_7));
			case Attribute.TextIndent:
				return new AttributeObject.d(A_0.Paragraph.Indent);
			case Attribute.TextAlign:
				switch (A_0.Paragraph.Align)
				{
				case TextAlign.Left:
					return new AttributeObject.g(TextAlignAttribute.Start);
				case TextAlign.Center:
					return new AttributeObject.g(TextAlignAttribute.Center);
				case TextAlign.Right:
					return new AttributeObject.g(TextAlignAttribute.End);
				case TextAlign.Justify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				case TextAlign.FullJustify:
					return new AttributeObject.g(TextAlignAttribute.Justify);
				default:
					return string.Empty;
				}
				break;
			case Attribute.BlockAlign:
			case Attribute.InlineAlign:
			case Attribute.TBorderStyle:
			case Attribute.TPadding:
				break;
			case Attribute.LineHeight:
				return new AttributeObject.d(A_0.Line.Leading);
			case Attribute.TextDecorationColor:
			{
				RgbColor rgbColor = A_0.Font.Color.m();
				return new AttributeObject.b(new float[]
				{
					rgbColor.R,
					rgbColor.G,
					rgbColor.B
				});
			}
			default:
				switch (A_6)
				{
				case Attribute.SpaceBefore:
					return new AttributeObject.d(A_0.Paragraph.SpacingBefore);
				case Attribute.SpaceAfter:
					return new AttributeObject.d(A_0.Paragraph.SpacingAfter);
				case Attribute.BBox:
					return new AttributeObject.b(new BoundingBox(A_2.Page, A_2.Dimensions.a3(A_2.Page.Dimensions, A_4, A_5), A_2.Dimensions.a4(A_2.Page.Dimensions, A_4, A_5), A_7, A_3, A_1.Angle).a());
				case Attribute.Width:
					return new AttributeObject.d(A_7);
				case Attribute.Height:
					return new AttributeObject.d(A_3);
				}
				break;
			}
			return this.a(A_6, A_2);
		}

		// Token: 0x06003CEF RID: 15599 RVA: 0x00211510 File Offset: 0x00210510
		internal void a(FormattedTextAreaStyle A_0)
		{
			if (A_0.Underline || A_0.TextRise != 0f)
			{
				if (A_0.Underline)
				{
					if (this.m[Attribute.TextDecorationType] == null)
					{
						this.SetTextDecorationType(TextDecorationType.Underline);
					}
				}
				if (A_0.TextRise != 0f)
				{
					if (this.m[Attribute.BaselineShift] == null)
					{
						this.SetBaselineShift(A_0.TextRise);
					}
				}
			}
		}

		// Token: 0x06003CF0 RID: 15600 RVA: 0x002115B4 File Offset: 0x002105B4
		private bool a(StructureElement A_0, Attribute A_1, AttributeObject.b A_2, bool A_3)
		{
			switch (A_1)
			{
			case Attribute.BBox:
			{
				AttributeObject.b b = (AttributeObject.b)A_0.o()[A_1];
				if (b != null)
				{
					b.a(AttributeObject.a(b.a(), A_2.a()));
				}
				break;
			}
			case Attribute.Width:
			case Attribute.Height:
			{
				AttributeObject.b b = (AttributeObject.b)A_0.o()[300];
				if (!A_3)
				{
					b.a(AttributeObject.a(b.a(), A_2.a()));
					A_3 = true;
				}
				if (A_1 == Attribute.Height)
				{
					AttributeObject.d d = (AttributeObject.d)A_0.o()[A_1];
					d.a(b.a()[3] - b.a()[1]);
				}
				else if (A_1 == Attribute.Width)
				{
					AttributeObject.d d2 = (AttributeObject.d)A_0.o()[A_1];
					d2.a(b.a()[2] - b.a()[0]);
				}
				break;
			}
			}
			return A_3;
		}

		// Token: 0x06003CF1 RID: 15601 RVA: 0x002116F0 File Offset: 0x002106F0
		private static float[] a(float[] A_0, float[] A_1)
		{
			float[] result;
			if (A_0 == null && A_1 != null)
			{
				result = A_1;
			}
			else if (A_0 != null && A_1 == null)
			{
				result = A_0;
			}
			else
			{
				float[] array = new float[4];
				if (A_0[0] < 0f && A_1[0] < 0f)
				{
					array[0] = ((A_0[0] > A_1[0]) ? A_0[0] : A_1[0]);
				}
				else
				{
					array[0] = ((A_0[0] > A_1[0]) ? A_1[0] : A_0[0]);
				}
				if (A_0[1] < 0f && A_1[1] < 0f)
				{
					array[1] = ((A_0[1] > A_1[1]) ? A_0[1] : A_1[1]);
				}
				else
				{
					array[1] = ((A_0[1] > A_1[1]) ? A_1[1] : A_0[1]);
				}
				if (A_0[2] < 0f && A_1[2] < 0f)
				{
					array[2] = ((A_0[2] > A_1[2]) ? A_1[2] : A_0[2]);
				}
				else
				{
					array[2] = ((A_0[2] > A_1[2]) ? A_0[2] : A_1[2]);
				}
				if (A_0[3] < 0f && A_1[3] < 0f)
				{
					array[3] = ((A_0[3] > A_1[3]) ? A_1[3] : A_0[3]);
				}
				else
				{
					array[3] = ((A_0[3] > A_1[3]) ? A_0[3] : A_1[3]);
				}
				result = array;
			}
			return result;
		}

		// Token: 0x040020C1 RID: 8385
		private static byte[] a = new byte[]
		{
			76,
			97,
			121,
			111,
			117,
			116
		};

		// Token: 0x040020C2 RID: 8386
		private static byte[] b = new byte[]
		{
			76,
			105,
			115,
			116
		};

		// Token: 0x040020C3 RID: 8387
		private static byte[] c = new byte[]
		{
			80,
			114,
			105,
			110,
			116,
			70,
			105,
			101,
			108,
			100
		};

		// Token: 0x040020C4 RID: 8388
		private static byte[] d = new byte[]
		{
			84,
			97,
			98,
			108,
			101
		};

		// Token: 0x040020C5 RID: 8389
		private static byte[] e = new byte[]
		{
			88,
			77,
			76,
			45,
			49,
			46,
			48,
			48
		};

		// Token: 0x040020C6 RID: 8390
		private static byte[] f = new byte[]
		{
			72,
			84,
			77,
			76,
			45,
			51,
			46,
			50,
			48
		};

		// Token: 0x040020C7 RID: 8391
		private static byte[] g = new byte[]
		{
			72,
			84,
			77,
			76,
			45,
			52,
			46,
			48,
			49
		};

		// Token: 0x040020C8 RID: 8392
		private static byte[] h = new byte[]
		{
			79,
			69,
			66,
			45,
			49,
			46,
			48,
			48
		};

		// Token: 0x040020C9 RID: 8393
		private static byte[] i = new byte[]
		{
			82,
			84,
			70,
			45,
			49,
			46,
			48,
			53
		};

		// Token: 0x040020CA RID: 8394
		private new static byte[] j = new byte[]
		{
			67,
			83,
			83,
			45,
			49,
			46,
			48,
			48
		};

		// Token: 0x040020CB RID: 8395
		private static byte[] k = new byte[]
		{
			67,
			83,
			83,
			45,
			50,
			46,
			48,
			48
		};

		// Token: 0x040020CC RID: 8396
		private AttributeOwner l;

		// Token: 0x040020CD RID: 8397
		private HybridDictionary m = new HybridDictionary();

		// Token: 0x040020CE RID: 8398
		private bool n = false;

		// Token: 0x040020CF RID: 8399
		private bool o = false;

		// Token: 0x02000643 RID: 1603
		private abstract class a
		{
			// Token: 0x06003CF3 RID: 15603
			internal abstract void l(DocumentWriter A_0);

			// Token: 0x06003CF4 RID: 15604
			internal abstract byte k();
		}

		// Token: 0x02000644 RID: 1604
		private class b : AttributeObject.a
		{
			// Token: 0x06003CF6 RID: 15606 RVA: 0x0021196A File Offset: 0x0021096A
			internal b(float[] A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06003CF7 RID: 15607 RVA: 0x00211984 File Offset: 0x00210984
			internal float[] a()
			{
				return this.a;
			}

			// Token: 0x06003CF8 RID: 15608 RVA: 0x0021199C File Offset: 0x0021099C
			internal void a(float[] A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06003CF9 RID: 15609 RVA: 0x002119A8 File Offset: 0x002109A8
			internal override byte k()
			{
				return 53;
			}

			// Token: 0x06003CFA RID: 15610 RVA: 0x002119BC File Offset: 0x002109BC
			internal override void l(DocumentWriter A_0)
			{
				A_0.WriteArrayOpen();
				for (int i = 0; i < this.a.Length; i++)
				{
					A_0.WriteNumber(this.a[i]);
				}
				A_0.WriteArrayClose();
			}

			// Token: 0x040020D0 RID: 8400
			private float[] a = null;
		}

		// Token: 0x02000645 RID: 1605
		private class c : AttributeObject.a
		{
			// Token: 0x06003CFB RID: 15611 RVA: 0x00211A00 File Offset: 0x00210A00
			internal c(string[] A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06003CFC RID: 15612 RVA: 0x00211A1C File Offset: 0x00210A1C
			internal override byte k()
			{
				return 54;
			}

			// Token: 0x06003CFD RID: 15613 RVA: 0x00211A30 File Offset: 0x00210A30
			internal override void l(DocumentWriter A_0)
			{
				A_0.WriteArrayOpen();
				for (int i = 0; i < this.a.Length; i++)
				{
					A_0.WriteText(this.a[i]);
				}
				A_0.WriteArrayClose();
			}

			// Token: 0x040020D1 RID: 8401
			private string[] a = null;
		}

		// Token: 0x02000646 RID: 1606
		private class d : AttributeObject.a
		{
			// Token: 0x06003CFE RID: 15614 RVA: 0x00211A74 File Offset: 0x00210A74
			internal d(float A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06003CFF RID: 15615 RVA: 0x00211A94 File Offset: 0x00210A94
			internal float a()
			{
				return this.a;
			}

			// Token: 0x06003D00 RID: 15616 RVA: 0x00211AAC File Offset: 0x00210AAC
			internal void a(float A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06003D01 RID: 15617 RVA: 0x00211AB8 File Offset: 0x00210AB8
			internal override byte k()
			{
				return 50;
			}

			// Token: 0x06003D02 RID: 15618 RVA: 0x00211ACC File Offset: 0x00210ACC
			internal override void l(DocumentWriter A_0)
			{
				A_0.WriteNumber(this.a);
			}

			// Token: 0x040020D2 RID: 8402
			private float a = 0f;
		}

		// Token: 0x02000647 RID: 1607
		private class e : AttributeObject.a
		{
			// Token: 0x06003D03 RID: 15619 RVA: 0x00211ADC File Offset: 0x00210ADC
			internal e(int A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06003D04 RID: 15620 RVA: 0x00211AF8 File Offset: 0x00210AF8
			internal override byte k()
			{
				return 49;
			}

			// Token: 0x06003D05 RID: 15621 RVA: 0x00211B0C File Offset: 0x00210B0C
			internal override void l(DocumentWriter A_0)
			{
				A_0.WriteNumber(this.a);
			}

			// Token: 0x040020D3 RID: 8403
			private int a = 0;
		}

		// Token: 0x02000648 RID: 1608
		private class f : AttributeObject.a
		{
			// Token: 0x06003D06 RID: 15622 RVA: 0x00211B1C File Offset: 0x00210B1C
			internal f(string A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06003D07 RID: 15623 RVA: 0x00211B38 File Offset: 0x00210B38
			internal override byte k()
			{
				return 51;
			}

			// Token: 0x06003D08 RID: 15624 RVA: 0x00211B4C File Offset: 0x00210B4C
			internal override void l(DocumentWriter A_0)
			{
				A_0.an(this.a);
			}

			// Token: 0x040020D4 RID: 8404
			private string a = null;
		}

		// Token: 0x02000649 RID: 1609
		private class g : AttributeObject.a
		{
			// Token: 0x06003D09 RID: 15625 RVA: 0x00211B5C File Offset: 0x00210B5C
			internal g(object A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06003D0A RID: 15626 RVA: 0x00211B78 File Offset: 0x00210B78
			internal override byte k()
			{
				return 55;
			}

			// Token: 0x06003D0B RID: 15627 RVA: 0x00211B8C File Offset: 0x00210B8C
			internal override void l(DocumentWriter A_0)
			{
				A_0.WriteName(this.a.ToString());
			}

			// Token: 0x040020D5 RID: 8405
			private object a = null;
		}

		// Token: 0x0200064A RID: 1610
		private class h : AttributeObject.a
		{
			// Token: 0x06003D0C RID: 15628 RVA: 0x00211BA1 File Offset: 0x00210BA1
			internal h(RgbColor[] A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06003D0D RID: 15629 RVA: 0x00211BBC File Offset: 0x00210BBC
			internal override byte k()
			{
				return 56;
			}

			// Token: 0x06003D0E RID: 15630 RVA: 0x00211BD0 File Offset: 0x00210BD0
			internal override void l(DocumentWriter A_0)
			{
				if (this.a == null)
				{
					A_0.WriteNull();
				}
				else
				{
					A_0.WriteArrayOpen();
					for (int i = 0; i <= 3; i++)
					{
						A_0.WriteArrayOpen();
						A_0.WriteNumber(this.a[i].R);
						A_0.WriteNumber(this.a[i].G);
						A_0.WriteNumber(this.a[i].B);
						A_0.WriteArrayClose();
					}
					A_0.WriteArrayClose();
				}
			}

			// Token: 0x040020D6 RID: 8406
			private RgbColor[] a = null;
		}
	}
}
