using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000079 RID: 121
	internal class cn : cm
	{
		// Token: 0x06000597 RID: 1431 RVA: 0x00054074 File Offset: 0x00053074
		internal cn(dx A_0, float A_1, float A_2, Certificate A_3, DocumentWriter A_4, zh A_5) : base(A_0, A_1, A_2, A_4, A_5)
		{
			this.a = A_0;
			this.b = A_3;
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00054095 File Offset: 0x00053095
		public new void e()
		{
			this.c();
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x000540A0 File Offset: 0x000530A0
		private new void c()
		{
			SignaturePanelLayout a_ = (this.a.a().PanelLayout == SignaturePanelLayout.Auto) ? ((this.a.a().Width >= this.a.a().Height) ? SignaturePanelLayout.LeftAndRight : SignaturePanelLayout.TopAndBottom) : this.a.a().PanelLayout;
			this.a();
			this.b(a_);
			this.a(a_);
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00054114 File Offset: 0x00053114
		private new void b(SignaturePanelLayout A_0)
		{
			if (this.a.a().FullPanel.ImageData != null)
			{
				float num = 0f;
				float num2 = 0f;
				float num3 = this.a.a().Height;
				float num4 = this.a.a().Width;
				SignaturePanel signaturePanel = this.a.a().FullPanel;
				if (signaturePanel.FitImage)
				{
					if (signaturePanel.KeepImageProportional)
					{
						this.a(num4, num3, out num, out num2, signaturePanel.ImageData);
						num3 = (float)signaturePanel.ImageData.Height * num;
						num4 = (float)signaturePanel.ImageData.Width * num2;
					}
				}
				else
				{
					num3 = (float)signaturePanel.ImageData.Height;
					num4 = (float)signaturePanel.ImageData.Width;
				}
				num = base.Dimensions.GetPdfX(0f) + (this.a.a().Width - num4) / 2f;
				num2 = base.Dimensions.GetPdfY(0f) - num3 - (this.a.a().Height - num3) / 2f;
				signaturePanel.ImageData.Draw(this, num, num2, num4, num3);
			}
			if (this.a.a().LeftPanel.ImageData != null)
			{
				float num = 0f;
				float num2 = 0f;
				float num3 = (A_0 == SignaturePanelLayout.LeftAndRight) ? this.a.a().Height : (this.a.a().Height / 2f);
				float num4 = (A_0 == SignaturePanelLayout.LeftAndRight) ? (this.a.a().Width / 2f) : this.a.a().Width;
				float num5 = num3;
				float num6 = num4;
				SignaturePanel signaturePanel = this.a.a().LeftPanel;
				if (signaturePanel.FitImage)
				{
					if (signaturePanel.KeepImageProportional)
					{
						this.a(num4, num3, out num, out num2, signaturePanel.ImageData);
						num5 = (float)signaturePanel.ImageData.Height * num;
						num6 = (float)signaturePanel.ImageData.Width * num2;
					}
				}
				else
				{
					num5 = (float)signaturePanel.ImageData.Height;
					num6 = (float)signaturePanel.ImageData.Width;
				}
				num = base.Dimensions.GetPdfX(0f) + (num4 - num6) / 2f;
				num2 = base.Dimensions.GetPdfY(0f) - num5 - (num3 - num5) / 2f;
				signaturePanel.ImageData.Draw(this, num, num2, num6, num5);
			}
			if (this.a.a().RightPanel.ImageData != null)
			{
				float num = 0f;
				float num2 = 0f;
				float num3 = (A_0 == SignaturePanelLayout.LeftAndRight) ? this.a.a().Height : (this.a.a().Height / 2f);
				float num4 = (A_0 == SignaturePanelLayout.LeftAndRight) ? (this.a.a().Width / 2f) : this.a.a().Width;
				float num5 = num3;
				float num6 = num4;
				SignaturePanel signaturePanel = this.a.a().RightPanel;
				if (signaturePanel.FitImage)
				{
					if (signaturePanel.KeepImageProportional)
					{
						this.a(num4, num3, out num, out num2, signaturePanel.ImageData);
						num5 = (float)signaturePanel.ImageData.Height * num;
						num6 = (float)signaturePanel.ImageData.Width * num2;
					}
				}
				else
				{
					num5 = (float)signaturePanel.ImageData.Height;
					num6 = (float)signaturePanel.ImageData.Width;
				}
				if (A_0 == SignaturePanelLayout.LeftAndRight)
				{
					num = base.Dimensions.GetPdfX(num4 / 2f) + (this.a.a().Width - num6) / 2f;
					num2 = base.Dimensions.GetPdfY(0f) - num5 - (num3 - num5) / 2f;
				}
				else
				{
					num = base.Dimensions.GetPdfX(0f) + (num4 - num6) / 2f;
					num2 = base.Dimensions.GetPdfY(num3 / 2f) - num5 - (this.a.a().Height - num5) / 2f;
				}
				signaturePanel.ImageData.Draw(this, num, num2, num6, num5);
			}
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x000545B4 File Offset: 0x000535B4
		private new void a(float A_0, float A_1, out float A_2, out float A_3, ImageData A_4)
		{
			float num = A_0 / A_4.ScaleX / (float)A_4.Width;
			float num2 = A_1 / A_4.ScaleY / (float)A_4.Height;
			if (num > num2)
			{
				A_2 = A_4.ScaleX * num2;
				A_3 = A_4.ScaleY * num2;
			}
			else
			{
				A_2 = A_4.ScaleX * num;
				A_3 = A_4.ScaleY * num;
			}
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00054628 File Offset: 0x00053628
		private new void a()
		{
			float width = this.a.a().Width;
			float height = this.a.a().Height;
			if (this.a.a().BackgroundColor != null)
			{
				this.a.a().BackgroundColor.DrawFill(this);
				this.Write_re(0f, 0f, width, height);
				this.Write_f();
			}
			if (this.a.a().BorderColor != null)
			{
				this.a.a().BorderColor.DrawStroke(this);
			}
			if (this.a.a().BorderStyle != null)
			{
				base.a(this.a.a().BorderStyle);
				if (this.a.a().BorderStyle.a() == 85)
				{
					this.Write_s_();
				}
				else
				{
					this.Write_re(0.5f, 0.5f, width - 1f, height - 1f);
					this.Write_s_();
				}
			}
			base.Write_q_();
			this.Write_re(1f, 1f, width - 2f, height - 2f);
			base.Write_W();
			base.Write_n();
			base.Write_Q();
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00054790 File Offset: 0x00053790
		private new void a(SignaturePanelLayout A_0)
		{
			Font font = this.a.a().Font;
			base.a(true);
			base.b(font);
			base.SetTextMode();
			char[] array = this.a.a().FullPanel.a(this.b, this.a.a());
			if (array.Length > 0)
			{
				float a_ = 0f;
				float a_2 = 0f;
				float num = this.a.a().Width;
				float num2 = this.a.a().Height;
				TextLineList textLineList;
				if (this.a.a().FullPanel.FontSize > 0)
				{
					textLineList = font.GetTextLines(array, num, num2, (float)this.a.a().FullPanel.FontSize);
				}
				else
				{
					textLineList = this.a(array, font, num, num2);
				}
				textLineList.ja(this, a_, a_2, this.a.a().FullPanel.TextAlign, this.a.a().FullPanel.TextColor, null, 0f, false, this.a.a().FullPanel.TextRightToLeft, false);
			}
			array = this.a.a().LeftPanel.a(this.b, this.a.a());
			if (array.Length > 0)
			{
				float a_ = 0f;
				float a_2 = 0f;
				float num2 = (A_0 == SignaturePanelLayout.LeftAndRight) ? this.a.a().Height : (this.a.a().Height / 2f);
				float num = (A_0 == SignaturePanelLayout.LeftAndRight) ? (this.a.a().Width / 2f) : this.a.a().Width;
				TextLineList textLineList;
				if (this.a.a().LeftPanel.FontSize > 0)
				{
					textLineList = font.GetTextLines(array, num, num2, (float)this.a.a().LeftPanel.FontSize);
				}
				else
				{
					textLineList = this.a(array, font, num, num2);
				}
				textLineList.ja(this, a_, a_2, this.a.a().LeftPanel.TextAlign, this.a.a().LeftPanel.TextColor, null, 0f, false, this.a.a().LeftPanel.TextRightToLeft, false);
			}
			array = this.a.a().RightPanel.a(this.b, this.a.a());
			if (array.Length > 0)
			{
				float a_ = (A_0 == SignaturePanelLayout.LeftAndRight) ? (this.a.a().Width / 2f) : 0f;
				float a_2 = (A_0 == SignaturePanelLayout.LeftAndRight) ? 0f : (this.a.a().Height / 2f);
				float num2 = (A_0 == SignaturePanelLayout.LeftAndRight) ? this.a.a().Height : (this.a.a().Height / 2f);
				float num = (A_0 == SignaturePanelLayout.LeftAndRight) ? (this.a.a().Width / 2f) : this.a.a().Width;
				TextLineList textLineList;
				if (this.a.a().RightPanel.FontSize > 0)
				{
					textLineList = font.GetTextLines(array, num, num2, (float)this.a.a().RightPanel.FontSize);
				}
				else
				{
					textLineList = this.a(array, font, num, num2);
				}
				textLineList.ja(this, a_, a_2, this.a.a().RightPanel.TextAlign, this.a.a().RightPanel.TextColor, null, 0f, false, this.a.a().RightPanel.TextRightToLeft, false);
			}
			base.Write_ET();
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00054BB4 File Offset: 0x00053BB4
		private new TextLineList a(char[] A_0, Font A_1, float A_2, float A_3)
		{
			bool flag = true;
			int num = 1;
			int num2 = 5;
			TextLineList textLineList = null;
			while (flag && num < 1600)
			{
				textLineList = A_1.GetTextLines(A_0, A_2, A_3, (float)num);
				if (textLineList.HasOverflow())
				{
					if (num2 == 1)
					{
						textLineList = A_1.GetTextLines(A_0, A_2, A_3, (float)(--num));
						flag = false;
					}
					else
					{
						num -= num2;
						num2 = 1;
					}
				}
				else
				{
					num += num2;
				}
			}
			return textLineList;
		}

		// Token: 0x04000304 RID: 772
		private new dx a;

		// Token: 0x04000305 RID: 773
		private new Certificate b;
	}
}
