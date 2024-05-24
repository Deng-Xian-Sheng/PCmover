using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using ceTe.DynamicPDF.Imaging;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007E6 RID: 2022
	public class SignaturePanel
	{
		// Token: 0x06005208 RID: 21000 RVA: 0x0028C044 File Offset: 0x0028B044
		internal SignaturePanel(bool A_0, bool A_1, bool A_2, bool A_3, bool A_4, bool A_5)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = A_3;
			this.e = A_4;
			this.f = A_5;
		}

		// Token: 0x06005209 RID: 21001 RVA: 0x0028C0CC File Offset: 0x0028B0CC
		internal char[] a(Certificate A_0, Signature A_1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (this.b)
			{
				stringBuilder.AppendLine(A_0.SubjectName);
			}
			if (this.d)
			{
				stringBuilder.Append("Digitally signed by ");
				stringBuilder.Append(A_0.SubjectName);
				if (!this.g)
				{
					stringBuilder.AppendLine();
				}
				else
				{
					stringBuilder.Append(' ');
				}
			}
			if (this.a)
			{
				if (this.g)
				{
					stringBuilder.Append("DN: ");
				}
				stringBuilder.Append(A_0.Subject);
				if (!this.g)
				{
					stringBuilder.AppendLine();
				}
				else
				{
					stringBuilder.Append(' ');
				}
			}
			if (this.e && A_1.Reason != null)
			{
				if (this.g)
				{
					stringBuilder.Append("Reason: ");
				}
				stringBuilder.Append(A_1.Reason);
				if (!this.g)
				{
					stringBuilder.AppendLine();
				}
				else
				{
					stringBuilder.Append(' ');
				}
			}
			if (this.f && A_1.Location != null)
			{
				if (this.g)
				{
					stringBuilder.Append("Location: ");
				}
				stringBuilder.Append(A_1.Location);
				if (!this.g)
				{
					stringBuilder.AppendLine();
				}
				else
				{
					stringBuilder.Append(' ');
				}
			}
			if (this.c)
			{
				if (this.g)
				{
					stringBuilder.Append("Date: ");
				}
				DateTime now = DateTime.Now;
				DateTime dateTime = now.ToUniversalTime();
				stringBuilder.Append(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss "));
				if (now == dateTime)
				{
					stringBuilder.Append("Z");
				}
				else if (now > dateTime)
				{
					dateTime = new DateTime((now - dateTime).Ticks);
					stringBuilder.Append('+');
					stringBuilder.Append(dateTime.Hour.ToString("00"));
					stringBuilder.Append('\'');
					stringBuilder.Append(dateTime.Minute.ToString("00"));
					stringBuilder.Append('\'');
				}
				else
				{
					dateTime = new DateTime((dateTime - now).Ticks);
					stringBuilder.Append('-');
					stringBuilder.Append(dateTime.Hour.ToString("00"));
					stringBuilder.Append('\'');
					stringBuilder.Append(dateTime.Minute.ToString("00"));
					stringBuilder.Append('\'');
				}
				if (!this.g)
				{
					stringBuilder.AppendLine();
				}
				else
				{
					stringBuilder.Append(' ');
				}
			}
			if (this.k != null)
			{
				stringBuilder.Append(this.k);
			}
			return stringBuilder.ToString().Trim().ToCharArray();
		}

		// Token: 0x0600520A RID: 21002 RVA: 0x0028C419 File Offset: 0x0028B419
		public void HideAllText()
		{
			this.a = false;
			this.b = false;
			this.c = false;
			this.d = false;
			this.e = false;
			this.f = false;
			this.k = null;
		}

		// Token: 0x0600520B RID: 21003 RVA: 0x0028C44D File Offset: 0x0028B44D
		public void SetImage(string filePath)
		{
			this.m = ImageData.GetImage(filePath);
		}

		// Token: 0x0600520C RID: 21004 RVA: 0x0028C45C File Offset: 0x0028B45C
		public void SetImage(byte[] data)
		{
			this.m = ImageData.GetImage(data);
		}

		// Token: 0x0600520D RID: 21005 RVA: 0x0028C46B File Offset: 0x0028B46B
		public void SetImage(Stream stream)
		{
			this.m = ImageData.GetImage(stream);
		}

		// Token: 0x0600520E RID: 21006 RVA: 0x0028C47A File Offset: 0x0028B47A
		public void SetImage(ImageData imageData)
		{
			this.m = imageData;
		}

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x0600520F RID: 21007 RVA: 0x0028C484 File Offset: 0x0028B484
		// (set) Token: 0x06005210 RID: 21008 RVA: 0x0028C49C File Offset: 0x0028B49C
		public bool ShowLabels
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x06005211 RID: 21009 RVA: 0x0028C4A8 File Offset: 0x0028B4A8
		// (set) Token: 0x06005212 RID: 21010 RVA: 0x0028C4C0 File Offset: 0x0028B4C0
		public bool TextRightToLeft
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x06005213 RID: 21011 RVA: 0x0028C4CC File Offset: 0x0028B4CC
		// (set) Token: 0x06005214 RID: 21012 RVA: 0x0028C4E4 File Offset: 0x0028B4E4
		public bool ShowDistinguishedName
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

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x06005215 RID: 21013 RVA: 0x0028C4F0 File Offset: 0x0028B4F0
		// (set) Token: 0x06005216 RID: 21014 RVA: 0x0028C508 File Offset: 0x0028B508
		public bool ShowSubjectName
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

		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x06005217 RID: 21015 RVA: 0x0028C514 File Offset: 0x0028B514
		// (set) Token: 0x06005218 RID: 21016 RVA: 0x0028C52C File Offset: 0x0028B52C
		public bool ShowDate
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x06005219 RID: 21017 RVA: 0x0028C538 File Offset: 0x0028B538
		// (set) Token: 0x0600521A RID: 21018 RVA: 0x0028C550 File Offset: 0x0028B550
		public bool ShowDigitallySignedBy
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x0600521B RID: 21019 RVA: 0x0028C55C File Offset: 0x0028B55C
		// (set) Token: 0x0600521C RID: 21020 RVA: 0x0028C574 File Offset: 0x0028B574
		public bool ShowReason
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x0600521D RID: 21021 RVA: 0x0028C580 File Offset: 0x0028B580
		// (set) Token: 0x0600521E RID: 21022 RVA: 0x0028C598 File Offset: 0x0028B598
		public bool ShowLocation
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x0600521F RID: 21023 RVA: 0x0028C5A4 File Offset: 0x0028B5A4
		// (set) Token: 0x06005220 RID: 21024 RVA: 0x0028C5BC File Offset: 0x0028B5BC
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This property is obsolete. Use KeepImageProportional property instead.")]
		public bool KeepImagePropotional
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x06005221 RID: 21025 RVA: 0x0028C5C8 File Offset: 0x0028B5C8
		// (set) Token: 0x06005222 RID: 21026 RVA: 0x0028C5E0 File Offset: 0x0028B5E0
		public bool KeepImageProportional
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x06005223 RID: 21027 RVA: 0x0028C5EC File Offset: 0x0028B5EC
		// (set) Token: 0x06005224 RID: 21028 RVA: 0x0028C604 File Offset: 0x0028B604
		public bool FitImage
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x06005225 RID: 21029 RVA: 0x0028C610 File Offset: 0x0028B610
		// (set) Token: 0x06005226 RID: 21030 RVA: 0x0028C628 File Offset: 0x0028B628
		public int FontSize
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x06005227 RID: 21031 RVA: 0x0028C634 File Offset: 0x0028B634
		// (set) Token: 0x06005228 RID: 21032 RVA: 0x0028C64C File Offset: 0x0028B64C
		public string CustomMessage
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x06005229 RID: 21033 RVA: 0x0028C658 File Offset: 0x0028B658
		// (set) Token: 0x0600522A RID: 21034 RVA: 0x0028C670 File Offset: 0x0028B670
		public TextAlign TextAlign
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x0600522B RID: 21035 RVA: 0x0028C67C File Offset: 0x0028B67C
		// (set) Token: 0x0600522C RID: 21036 RVA: 0x0028C694 File Offset: 0x0028B694
		public ImageData ImageData
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
			}
		}

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x0600522D RID: 21037 RVA: 0x0028C6A0 File Offset: 0x0028B6A0
		// (set) Token: 0x0600522E RID: 21038 RVA: 0x0028C6B8 File Offset: 0x0028B6B8
		public Color TextColor
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x04002BDB RID: 11227
		private bool a;

		// Token: 0x04002BDC RID: 11228
		private bool b;

		// Token: 0x04002BDD RID: 11229
		private bool c;

		// Token: 0x04002BDE RID: 11230
		private bool d;

		// Token: 0x04002BDF RID: 11231
		private bool e;

		// Token: 0x04002BE0 RID: 11232
		private bool f;

		// Token: 0x04002BE1 RID: 11233
		private bool g = true;

		// Token: 0x04002BE2 RID: 11234
		private bool h = false;

		// Token: 0x04002BE3 RID: 11235
		private bool i = true;

		// Token: 0x04002BE4 RID: 11236
		private bool j = true;

		// Token: 0x04002BE5 RID: 11237
		private string k = null;

		// Token: 0x04002BE6 RID: 11238
		private int l = 0;

		// Token: 0x04002BE7 RID: 11239
		private ImageData m = null;

		// Token: 0x04002BE8 RID: 11240
		private TextAlign n = TextAlign.Left;

		// Token: 0x04002BE9 RID: 11241
		private Color o = RgbColor.Black;
	}
}
