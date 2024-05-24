using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Forms;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000654 RID: 1620
	public class BoundingBox
	{
		// Token: 0x06003D53 RID: 15699 RVA: 0x00214636 File Offset: 0x00213636
		internal BoundingBox()
		{
		}

		// Token: 0x06003D54 RID: 15700 RVA: 0x00214644 File Offset: 0x00213644
		public BoundingBox(float left, float bottom, float right, float top)
		{
			this.b = new float[]
			{
				left,
				bottom,
				right,
				top
			};
		}

		// Token: 0x06003D55 RID: 15701 RVA: 0x00214679 File Offset: 0x00213679
		public BoundingBox(Page page, float x, float y, float width, float height, float angle)
		{
			this.b = this.a(page.Dimensions, x, y, width, height, angle);
		}

		// Token: 0x06003D56 RID: 15702 RVA: 0x002146A0 File Offset: 0x002136A0
		private float[] a(PageDimensions A_0, float A_1, float A_2, float A_3, float A_4, float A_5)
		{
			float num = A_5 / 180f * 3.1415927f;
			float[] array = new float[4];
			float[] array2 = new float[4];
			array[0] = A_1;
			array2[0] = A_2;
			array[1] = A_1 + A_3 * (float)Math.Cos((double)num);
			array2[1] = A_2 + A_3 * (float)Math.Sin((double)num);
			array[2] = A_1 + A_3 * (float)Math.Cos((double)num) - A_4 * (float)Math.Sin((double)num);
			array2[2] = A_2 + A_3 * (float)Math.Sin((double)num) + A_4 * (float)Math.Cos((double)num);
			array[3] = A_1 - A_4 * (float)Math.Sin((double)num);
			array2[3] = A_2 + A_4 * (float)Math.Cos((double)num);
			Array.Sort<float>(array);
			Array.Sort<float>(array2);
			float num2 = A_0.LeftMargin + array[0];
			float num3 = A_0.Height - A_0.TopMargin - array2[3];
			float num4 = A_0.LeftMargin + array[3];
			float num5 = A_0.Height - A_0.TopMargin - array2[0];
			return new float[]
			{
				num2,
				num3,
				num4,
				num5
			};
		}

		// Token: 0x06003D57 RID: 15703 RVA: 0x002147C0 File Offset: 0x002137C0
		public void SetBBox(float left, float bottom, float right, float top)
		{
			this.b = new float[]
			{
				left,
				bottom,
				right,
				top
			};
		}

		// Token: 0x06003D58 RID: 15704 RVA: 0x002147F0 File Offset: 0x002137F0
		internal float[] a()
		{
			return this.b;
		}

		// Token: 0x06003D59 RID: 15705 RVA: 0x00214808 File Offset: 0x00213808
		internal void a(float[] A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003D5A RID: 15706 RVA: 0x00214814 File Offset: 0x00213814
		internal void a(PageWriter A_0, TaggablePageElement A_1, Row A_2, acx A_3)
		{
			float[] array = this.b;
			if (this.b == null)
			{
				if (A_1 != null)
				{
					array = this.a(A_0, A_1);
				}
				else if (A_2 != null)
				{
					array = this.a(A_0, A_2, A_3);
				}
				else
				{
					array = this.a(A_0);
				}
			}
			A_0.WriteName(BoundingBox.a);
			A_0.ae();
			A_0.h(array[0]);
			A_0.WriteSpace();
			A_0.h(array[1]);
			A_0.WriteSpace();
			A_0.h(array[2]);
			A_0.WriteSpace();
			A_0.h(array[3]);
			A_0.ad();
		}

		// Token: 0x06003D5B RID: 15707 RVA: 0x002148C4 File Offset: 0x002138C4
		internal void a(PageWriter A_0, TaggablePageElement A_1, Row2 A_2, q0 A_3)
		{
			float[] array = this.b;
			if (this.b == null)
			{
				if (A_1 != null)
				{
					array = this.a(A_0, A_1);
				}
				else if (A_2 != null)
				{
					array = this.a(A_0, A_2, A_3);
				}
				else
				{
					array = this.a(A_0);
				}
			}
			A_0.WriteName(BoundingBox.a);
			A_0.ae();
			A_0.h(array[0]);
			A_0.WriteSpace();
			A_0.h(array[1]);
			A_0.WriteSpace();
			A_0.h(array[2]);
			A_0.WriteSpace();
			A_0.h(array[3]);
			A_0.ad();
		}

		// Token: 0x06003D5C RID: 15708 RVA: 0x00214974 File Offset: 0x00213974
		private float[] a(PageWriter A_0, TaggablePageElement A_1)
		{
			byte b = A_1.cb();
			float[] result;
			switch (b)
			{
			case 32:
			{
				BarCode barCode = (BarCode)A_1;
				result = this.a(A_0.Page.Dimensions, barCode.X, barCode.Y, barCode.GetSymbolWidth(), barCode.Height, barCode.Angle);
				break;
			}
			case 33:
			{
				Dim2Barcode dim2Barcode = (Dim2Barcode)A_1;
				result = this.a(A_0.Page.Dimensions, dim2Barcode.X, dim2Barcode.Y, dim2Barcode.GetSymbolWidth(), dim2Barcode.GetSymbolHeight(), dim2Barcode.Angle);
				break;
			}
			default:
				switch (b)
				{
				case 48:
				{
					Table table = (Table)A_1;
					return this.a(A_0.Page.Dimensions, table.X, table.Y, table.GetVisibleWidth(), table.GetVisibleHeight(), table.Angle);
				}
				case 49:
				{
					Rectangle rectangle = (Rectangle)A_1;
					return this.a(A_0.Page.Dimensions, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, rectangle.Angle);
				}
				case 50:
				{
					Path path = (Path)A_1;
					return path.a(A_0, path.X, path.Y);
				}
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
				{
					Note note = (Note)A_1;
					return this.a(A_0.Page.Dimensions, note.X, note.Y, note.Width, note.Height, 0f);
				}
				case 53:
				{
					Link link = (Link)A_1;
					return this.a(A_0.Page.Dimensions, link.X, link.Y, link.Width, link.Height, 0f);
				}
				case 54:
				{
					Line line = (Line)A_1;
					return new float[]
					{
						A_0.Dimensions.LeftMargin + line.X1,
						A_0.Dimensions.Height - A_0.Dimensions.TopMargin - line.Y2,
						A_0.Dimensions.LeftMargin + line.X2,
						A_0.Dimensions.Height - A_0.Dimensions.TopMargin - line.Y1
					};
				}
				case 55:
				{
					Image image = (Image)A_1;
					return this.a(A_0.Page.Dimensions, image.X, image.Y, image.Width, image.Height, image.Angle);
				}
				case 56:
				{
					Circle circle = (Circle)A_1;
					return new float[]
					{
						A_0.Dimensions.LeftMargin + circle.X - circle.RadiusX,
						A_0.Dimensions.Height - A_0.Dimensions.TopMargin - circle.Y - circle.RadiusY,
						A_0.Dimensions.LeftMargin + circle.X + circle.RadiusX,
						A_0.Dimensions.Height - A_0.Dimensions.TopMargin - circle.Y + circle.RadiusY
					};
				}
				case 64:
				{
					FormElement formElement = (FormElement)A_1;
					return this.a(A_0.Page.Dimensions, formElement.X, formElement.Y, formElement.Width, formElement.Height, 0f);
				}
				case 65:
				{
					TextArea textArea = (TextArea)A_1;
					return this.a(A_0.Page.Dimensions, textArea.X, textArea.Y, textArea.Width, textArea.a().GetRequiredHeight(0), textArea.Angle);
				}
				case 66:
				{
					Label label = (Label)A_1;
					return this.a(A_0.Page.Dimensions, label.X, label.Y, label.Width, label.a().GetRequiredHeight(0), label.Angle);
				}
				case 67:
				{
					FormattedTextArea formattedTextArea = (FormattedTextArea)A_1;
					return this.a(A_0.Page.Dimensions, formattedTextArea.X, formattedTextArea.Y, formattedTextArea.Width, formattedTextArea.Height, formattedTextArea.Angle);
				}
				case 68:
				{
					Chart chart = (Chart)A_1;
					return this.a(A_0.Page.Dimensions, chart.X, chart.Y, chart.Width, chart.Height, chart.Angle);
				}
				default:
					if (b == 80)
					{
						Table2 table2 = (Table2)A_1;
						return this.a(A_0.Page.Dimensions, table2.X, table2.Y, table2.GetVisibleWidth(), table2.GetVisibleHeight(), table2.Angle);
					}
					break;
				}
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x06003D5D RID: 15709 RVA: 0x00214EC0 File Offset: 0x00213EC0
		private float[] a(PageWriter A_0, Row A_1, acx A_2)
		{
			return this.a(A_0.Page.Dimensions, A_2.a(), A_2.b(), A_2.d().Width, A_1.ActualRowHeight, A_2.d().Angle);
		}

		// Token: 0x06003D5E RID: 15710 RVA: 0x00214F0C File Offset: 0x00213F0C
		private float[] a(PageWriter A_0)
		{
			return new float[]
			{
				A_0.Dimensions.Edge.Left,
				A_0.Dimensions.Edge.Bottom,
				A_0.Dimensions.Edge.Right,
				A_0.Dimensions.Edge.Top
			};
		}

		// Token: 0x06003D5F RID: 15711 RVA: 0x00214F74 File Offset: 0x00213F74
		private float[] a(PageWriter A_0, Row2 A_1, q0 A_2)
		{
			return this.a(A_0.Page.Dimensions, A_2.a(), A_2.b(), A_2.d().Width, A_1.ActualRowHeight, A_2.d().Angle);
		}

		// Token: 0x0400210F RID: 8463
		private static byte[] a = new byte[]
		{
			66,
			66,
			111,
			120
		};

		// Token: 0x04002110 RID: 8464
		private float[] b;
	}
}
