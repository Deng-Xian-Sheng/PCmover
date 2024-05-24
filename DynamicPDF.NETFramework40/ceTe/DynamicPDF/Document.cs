using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using ceTe.DynamicPDF.Cryptography;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements.Html;
using ceTe.DynamicPDF.Xmp;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000670 RID: 1648
	public class Document
	{
		// Token: 0x06003F58 RID: 16216 RVA: 0x0021B7B4 File Offset: 0x0021A7B4
		static Document()
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Document.b = executingAssembly.GetName().Version;
			Document.c = Document.b.Revision;
			Document.e = "DynamicPDF for .NET v";
			string text = Document.b.ToString();
			Document.e += text.Remove(text.Length - 6);
			if (Document.c > 0)
			{
				Document.e = Document.e + " (Build " + Document.c.ToString() + ")";
			}
			Document.d = Document.e.ToCharArray();
			NameValueCollection appSettings = ConfigurationManager.AppSettings;
			string text2 = appSettings["ceTe.DynamicPDF.Document.DefaultPdfVersion"];
			if (text2 != null)
			{
				GlobalSettings.DefaultOutputPdfVersion = (PdfVersion)((int)(decimal.Parse(text2, CultureInfo.InvariantCulture) * 10m));
			}
			text2 = appSettings["ceTe.DynamicPDF.Document.DefaultPdfFormat"];
			if (text2 != null)
			{
				GlobalSettings.DefaultOutputPdfFormat = (PdfFormat)Enum.Parse(typeof(PdfFormat), text2, true);
			}
			bool flag = Convert.ToBoolean(appSettings["ceTe.DynamicPDF.Document.UseLegacyTextHeightCalculations"]);
			if (flag)
			{
				GlobalSettings.UseLegacyTextHeightCalculations = flag;
			}
		}

		// Token: 0x06003F59 RID: 16217 RVA: 0x0021BDF0 File Offset: 0x0021ADF0
		public Document()
		{
			this.bg = new SectionList(this);
		}

		// Token: 0x06003F5A RID: 16218 RVA: 0x0021BF64 File Offset: 0x0021AF64
		public static bool AddLicense(string licenseKey)
		{
			return aae.e(licenseKey);
		}

		// Token: 0x06003F5B RID: 16219 RVA: 0x0021BF7C File Offset: 0x0021AF7C
		public static Document FromHtml(Stream stream, PageDimensions dimensions, HtmlAreaPadding padding)
		{
			Document document = new Document();
			float num = dimensions.Width - (dimensions.LeftMargin + dimensions.RightMargin);
			float num2 = dimensions.Height - (dimensions.TopMargin + dimensions.BottomMargin);
			float width = num - (padding.Left + padding.Right);
			float height = num2 - (padding.Top + padding.Bottom);
			HtmlArea htmlArea = new HtmlArea(stream, padding.Left, padding.Top, width, height);
			do
			{
				Page page = new Page(dimensions);
				page.Elements.Add(htmlArea);
				htmlArea = htmlArea.GetOverflowHtmlArea(padding.Left, padding.Top, height);
				document.Pages.Add(page);
			}
			while (htmlArea != null);
			return document;
		}

		// Token: 0x06003F5C RID: 16220 RVA: 0x0021C048 File Offset: 0x0021B048
		public static Document FromHtml(Stream stream, PageDimensions dimensions, Uri baseHref)
		{
			Document document = new Document();
			float width = dimensions.Width - (dimensions.LeftMargin + dimensions.RightMargin);
			float height = dimensions.Height - (dimensions.TopMargin + dimensions.BottomMargin);
			HtmlArea htmlArea = new HtmlArea(stream, 0f, 0f, baseHref, width, height);
			do
			{
				Page page = new Page(dimensions);
				page.Elements.Add(htmlArea);
				htmlArea = htmlArea.GetOverflowHtmlArea(0f, 0f, height);
				document.Pages.Add(page);
			}
			while (htmlArea != null);
			return document;
		}

		// Token: 0x06003F5D RID: 16221 RVA: 0x0021C0E8 File Offset: 0x0021B0E8
		public static Document FromHtml(Stream stream, PageDimensions dimensions, HtmlAreaPadding padding, Uri baseHref)
		{
			Document document = new Document();
			float num = dimensions.Width - (dimensions.LeftMargin + dimensions.RightMargin);
			float num2 = dimensions.Height - (dimensions.TopMargin + dimensions.BottomMargin);
			float width = num - (padding.Left + padding.Right);
			float height = num2 - (padding.Top + padding.Bottom);
			HtmlArea htmlArea = new HtmlArea(stream, padding.Left, padding.Top, baseHref, width, height);
			do
			{
				Page page = new Page(dimensions);
				page.Elements.Add(htmlArea);
				htmlArea = htmlArea.GetOverflowHtmlArea(padding.Left, padding.Top, height);
				document.Pages.Add(page);
			}
			while (htmlArea != null);
			return document;
		}

		// Token: 0x06003F5E RID: 16222 RVA: 0x0021C1B4 File Offset: 0x0021B1B4
		public static Document FromHtml(string filePath, PageDimensions dimensions, HtmlAreaPadding padding)
		{
			Document document = new Document();
			Uri uri = new Uri(filePath);
			float num = dimensions.Width - (dimensions.LeftMargin + dimensions.RightMargin);
			float num2 = dimensions.Height - (dimensions.TopMargin + dimensions.BottomMargin);
			float width = num - (padding.Left + padding.Right);
			float height = num2 - (padding.Top + padding.Bottom);
			HtmlArea htmlArea = new HtmlArea(uri, padding.Left, padding.Top, width, height);
			do
			{
				Page page = new Page(dimensions);
				page.Elements.Add(htmlArea);
				htmlArea = htmlArea.GetOverflowHtmlArea(padding.Left, padding.Top, height);
				document.Pages.Add(page);
			}
			while (htmlArea != null);
			return document;
		}

		// Token: 0x06003F5F RID: 16223 RVA: 0x0021C288 File Offset: 0x0021B288
		public static Document FromHtml(string filePath, PageDimensions dimensions, Uri baseHref)
		{
			Document document = new Document();
			float width = dimensions.Width - (dimensions.LeftMargin + dimensions.RightMargin);
			float height = dimensions.Height - (dimensions.TopMargin + dimensions.BottomMargin);
			Uri uri = new Uri(filePath);
			HtmlArea htmlArea = new HtmlArea(uri, 0f, 0f, baseHref, width, height);
			do
			{
				Page page = new Page(dimensions);
				page.Elements.Add(htmlArea);
				htmlArea = htmlArea.GetOverflowHtmlArea(0f, 0f, height);
				document.Pages.Add(page);
			}
			while (htmlArea != null);
			return document;
		}

		// Token: 0x06003F60 RID: 16224 RVA: 0x0021C334 File Offset: 0x0021B334
		public static Document FromHtml(string filePath, PageDimensions dimensions, HtmlAreaPadding padding, Uri baseHref)
		{
			Document document = new Document();
			Uri uri = new Uri(filePath);
			float num = dimensions.Width - (dimensions.LeftMargin + dimensions.RightMargin);
			float num2 = dimensions.Height - (dimensions.TopMargin + dimensions.BottomMargin);
			float width = num - (padding.Left + padding.Right);
			float height = num2 - (padding.Top + padding.Bottom);
			HtmlArea htmlArea = new HtmlArea(uri, padding.Left, padding.Top, baseHref, width, height);
			do
			{
				Page page = new Page(dimensions);
				page.Elements.Add(htmlArea);
				htmlArea = htmlArea.GetOverflowHtmlArea(padding.Left, padding.Top, height);
				document.Pages.Add(page);
			}
			while (htmlArea != null);
			return document;
		}

		// Token: 0x06003F61 RID: 16225 RVA: 0x0021C408 File Offset: 0x0021B408
		public static Document FromHtml(Uri uri, PageDimensions dimensions, HtmlAreaPadding padding)
		{
			Document document = new Document();
			float num = dimensions.Width - (dimensions.LeftMargin + dimensions.RightMargin);
			float num2 = dimensions.Height - (dimensions.TopMargin + dimensions.BottomMargin);
			float width = num - (padding.Left + padding.Right);
			float height = num2 - (padding.Top + padding.Bottom);
			HtmlArea htmlArea = new HtmlArea(uri, padding.Left, padding.Top, width, height);
			do
			{
				Page page = new Page(dimensions);
				page.Elements.Add(htmlArea);
				htmlArea = htmlArea.GetOverflowHtmlArea(padding.Left, padding.Top, height);
				document.Pages.Add(page);
			}
			while (htmlArea != null);
			return document;
		}

		// Token: 0x06003F62 RID: 16226 RVA: 0x0021C4D4 File Offset: 0x0021B4D4
		public static Document FromHtml(Uri uri, PageDimensions dimensions, Uri baseHref)
		{
			Document document = new Document();
			float width = dimensions.Width - (dimensions.LeftMargin + dimensions.RightMargin);
			float height = dimensions.Height - (dimensions.TopMargin + dimensions.BottomMargin);
			HtmlArea htmlArea = new HtmlArea(uri, 0f, 0f, baseHref, width, height);
			do
			{
				Page page = new Page(dimensions);
				page.Elements.Add(htmlArea);
				htmlArea = htmlArea.GetOverflowHtmlArea(0f, 0f, height);
				document.Pages.Add(page);
			}
			while (htmlArea != null);
			return document;
		}

		// Token: 0x06003F63 RID: 16227 RVA: 0x0021C574 File Offset: 0x0021B574
		public static Document FromHtml(Uri uri, PageDimensions dimensions, HtmlAreaPadding padding, Uri baseHref)
		{
			Document document = new Document();
			float num = dimensions.Width - (dimensions.LeftMargin + dimensions.RightMargin);
			float num2 = dimensions.Height - (dimensions.TopMargin + dimensions.BottomMargin);
			float width = num - (padding.Left + padding.Right);
			float height = num2 - (padding.Top + padding.Bottom);
			HtmlArea htmlArea = new HtmlArea(uri, padding.Left, padding.Top, baseHref, width, height);
			do
			{
				Page page = new Page(dimensions);
				page.Elements.Add(htmlArea);
				document.Pages.Add(page);
				htmlArea = htmlArea.GetOverflowHtmlArea(padding.Left, padding.Top, height);
			}
			while (htmlArea != null);
			return document;
		}

		// Token: 0x06003F64 RID: 16228 RVA: 0x0021C640 File Offset: 0x0021B640
		public byte[] Draw()
		{
			MemoryStream memoryStream = new MemoryStream();
			this.Draw(memoryStream);
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Seek(0L, SeekOrigin.Begin);
			memoryStream.Read(array, 0, array.Length);
			memoryStream.Close();
			return array;
		}

		// Token: 0x06003F65 RID: 16229 RVA: 0x0021C68C File Offset: 0x0021B68C
		public void Draw(string filePath)
		{
			bool flag = false;
			FileStream fileStream = new FileStream(filePath, FileMode.Create);
			try
			{
				this.Draw(fileStream);
				flag = true;
			}
			finally
			{
				fileStream.Close();
				if (!flag)
				{
					try
					{
						File.Delete(filePath);
					}
					catch (Exception)
					{
					}
				}
			}
		}

		// Token: 0x06003F66 RID: 16230 RVA: 0x0021C6F4 File Offset: 0x0021B6F4
		public void Draw(Stream stream)
		{
			if (this.aw.a())
			{
				this.ca = null;
			}
			if (this.ca != null && this.cb == null)
			{
				this.RequireLicense(3);
				this.cb = new r2();
			}
			if (this.Security != null && this.PdfVersion < this.Security.u())
			{
				this.PdfVersion = this.Security.u();
			}
			if (this.Security is RC4128Security && !this.Security.e() && !this.Security.c())
			{
				throw new GeneratorException("Encryption of metadata can be excluded only if UseCryptFilter property is true.");
			}
			if (this.ci == null || this.ci.Count == 0)
			{
				DocumentWriter documentWriter = DocumentWriter.a(stream, this, this.bj);
				documentWriter.Draw();
			}
			else
			{
				MemoryStream memoryStream = new MemoryStream();
				DocumentWriter documentWriter = DocumentWriter.a(memoryStream, this, this.bj);
				documentWriter.a(new cr[this.ci.Count]);
				if (this.PdfVersion == PdfVersion.v1_3 || this.PdfVersion == PdfVersion.v1_4)
				{
					this.PdfVersion = PdfVersion.v1_5;
				}
				documentWriter.Draw();
				int num = (int)memoryStream.Position;
				for (int i = 0; i < this.ci.Count; i++)
				{
					if (documentWriter.ad()[i].c() != null)
					{
						memoryStream.Position = (long)documentWriter.ad()[i].e();
						memoryStream.WriteByte(91);
						memoryStream.WriteByte(48);
						memoryStream.WriteByte(32);
						string text = documentWriter.ad()[i].d().ToString();
						memoryStream.Write(Encoding.ASCII.GetBytes(text), 0, text.Length);
						memoryStream.WriteByte(32);
						text = (documentWriter.ad()[i].d() + documentWriter.ad()[i].g()).ToString();
						memoryStream.Write(Encoding.ASCII.GetBytes(text), 0, text.Length);
						memoryStream.WriteByte(32);
						text = (num - (documentWriter.ad()[i].d() + documentWriter.ad()[i].g())).ToString();
						memoryStream.Write(Encoding.ASCII.GetBytes(text), 0, text.Length);
						memoryStream.WriteByte(93);
						byte[] array = new byte[num - documentWriter.ad()[i].g()];
						byte[] buffer = memoryStream.GetBuffer();
						Array.Copy(buffer, 0, array, 0, documentWriter.ad()[i].d());
						Array.Copy(buffer, documentWriter.ad()[i].d() + documentWriter.ad()[i].g(), array, documentWriter.ad()[i].d(), num - (documentWriter.ad()[i].d() + documentWriter.ad()[i].g()));
						ContentInfo contentInfo = new ContentInfo(array);
						SignedCms signedCms = new SignedCms(contentInfo, true);
						CmsSigner cmsSigner = new CmsSigner(documentWriter.ad()[i].c());
						cmsSigner.IncludeOption = X509IncludeOption.EndCertOnly;
						signedCms.ComputeSignature(cmsSigner, documentWriter.ad()[i].a());
						byte[] array2 = signedCms.Encode();
						if (documentWriter.ad()[i].f() != null && documentWriter.ad()[i].f().Url != string.Empty)
						{
							int num2 = documentWriter.ad()[i].c().PrivateKey.KeySize / 8;
							byte[] array3 = new byte[num2];
							Array.Copy(array2, array2.Length - num2, array3, 0, num2);
							SHA1 sha = SHA1.Create();
							byte[] a_ = sha.ComputeHash(array3);
							sp sp = new sp();
							byte[] rawData = sp.a(a_, "1.3.14.3.2.26", documentWriter.ad()[i].f());
							AsnEncodedData asnEncodedData = new AsnEncodedData(new Oid("1.2.840.113549.1.9.16.2.14"), rawData);
							cmsSigner.UnsignedAttributes.Add(asnEncodedData);
							signedCms.ComputeSignature(cmsSigner);
							array2 = signedCms.Encode();
						}
						byte[] array4 = zz93.cl.a(array2);
						memoryStream.Position = (long)documentWriter.ad()[i].d();
						memoryStream.WriteByte(60);
						memoryStream.Write(array4, 0, array4.Length);
						int num3 = (int)((long)(documentWriter.ad()[i].d() + documentWriter.ad()[i].g()) - memoryStream.Position - 1L);
						for (int j = 0; j < num3; j++)
						{
							memoryStream.WriteByte(48);
						}
						memoryStream.WriteByte(62);
						memoryStream.Flush();
					}
				}
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06003F67 RID: 16231 RVA: 0x0021CC60 File Offset: 0x0021BC60
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ARL()
		{
			return this.bc;
		}

		// Token: 0x06003F68 RID: 16232 RVA: 0x0021CC78 File Offset: 0x0021BC78
		public void DrawToWeb()
		{
			HttpContext httpContext = HttpContext.Current;
			this.a(httpContext.Request, httpContext.Response, false, "DynamicPDF.pdf", false);
		}

		// Token: 0x06003F69 RID: 16233 RVA: 0x0021CCA8 File Offset: 0x0021BCA8
		public void DrawToWeb(string downloadAsFileName)
		{
			HttpContext httpContext = HttpContext.Current;
			this.a(httpContext.Request, httpContext.Response, false, downloadAsFileName, false);
		}

		// Token: 0x06003F6A RID: 16234 RVA: 0x0021CCD4 File Offset: 0x0021BCD4
		public void DrawToWeb(string downloadAsFileName, bool forceDownload)
		{
			HttpContext httpContext = HttpContext.Current;
			this.a(httpContext.Request, httpContext.Response, false, downloadAsFileName, forceDownload);
		}

		// Token: 0x06003F6B RID: 16235 RVA: 0x0021CD00 File Offset: 0x0021BD00
		[Obsolete("This method is obsolete. Use DrawToWeb() or Draw() method instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public WebCacheItem DrawToWebCache(string fileName)
		{
			this.RequireLicense(3);
			WebCacheItem webCacheItem = new WebCacheItem(fileName);
			this.Draw(webCacheItem.FilePath);
			return webCacheItem;
		}

		// Token: 0x06003F6C RID: 16236 RVA: 0x0021CD30 File Offset: 0x0021BD30
		internal void a(HttpRequest A_0, HttpResponse A_1, bool A_2, string A_3, bool A_4)
		{
			A_1.ClearHeaders();
			A_1.ClearContent();
			A_1.ContentType = "application/pdf";
			A_1.Charset = string.Empty;
			if (!A_2)
			{
				if (!A_0.IsSecureConnection)
				{
					A_1.Cache.SetCacheability(HttpCacheability.Private);
					A_1.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
				}
				A_1.Cache.SetExpires(DateTime.Now.AddSeconds(10.0));
			}
			if (A_4)
			{
				A_1.AddHeader("Content-Disposition", "attachment; filename=\"" + A_3 + "\"");
			}
			else
			{
				A_1.AddHeader("Content-Disposition", "inline; filename=\"" + A_3 + "\"");
			}
			this.Draw(A_1.OutputStream);
			if (A_1.IsClientConnected)
			{
				A_1.Flush();
				A_1.SuppressContent = true;
			}
		}

		// Token: 0x06003F6D RID: 16237 RVA: 0x0021CE23 File Offset: 0x0021BE23
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RequireLicense(int level)
		{
			this.bc |= level;
		}

		// Token: 0x06003F6E RID: 16238 RVA: 0x0021CE34 File Offset: 0x0021BE34
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RequireLicense()
		{
			this.RequireLicense(1);
		}

		// Token: 0x06003F6F RID: 16239 RVA: 0x0021CE40 File Offset: 0x0021BE40
		public void Sign(string fieldName, Certificate certificate)
		{
			if (this.ci == null)
			{
				this.ci = new Hashtable();
				bg value = new bg(certificate, null);
				this.ci.Add(fieldName, value);
				return;
			}
			throw new GeneratorException("Certificate already added for signing");
		}

		// Token: 0x06003F70 RID: 16240 RVA: 0x0021CE8C File Offset: 0x0021BE8C
		public void Sign(string fieldName, Certificate certificate, TimestampServer timestampServer)
		{
			if (this.ci == null)
			{
				this.ci = new Hashtable();
				bg value = new bg(certificate, timestampServer);
				this.ci.Add(fieldName, value);
				return;
			}
			throw new GeneratorException("Document is already signed. Multiple certificates are not allowed");
		}

		// Token: 0x06003F71 RID: 16241 RVA: 0x0021CED8 File Offset: 0x0021BED8
		public void Sign(string fieldName, Certificate certificate, bool timeStamp)
		{
			if (this.ci == null)
			{
				this.ci = new Hashtable();
				TimestampServer a_ = null;
				if (timeStamp && certificate.TimestampServerUrl != string.Empty)
				{
					a_ = new TimestampServer(certificate.TimestampServerUrl);
				}
				bg value = new bg(certificate, a_);
				this.ci.Add(fieldName, value);
				return;
			}
			throw new GeneratorException("Document is already signed. Multiple certificates are not allowed");
		}

		// Token: 0x06003F72 RID: 16242 RVA: 0x0021CF50 File Offset: 0x0021BF50
		public void Certify(string fieldName, Certificate certificate, CertifyingPermission permissions)
		{
			this.Sign(fieldName, certificate);
			this.cj = permissions;
		}

		// Token: 0x06003F73 RID: 16243 RVA: 0x0021CF63 File Offset: 0x0021BF63
		public void Certify(string fieldName, Certificate certificate, TimestampServer timestampServer, CertifyingPermission permission)
		{
			this.Sign(fieldName, certificate, timestampServer);
			this.cj = permission;
		}

		// Token: 0x06003F74 RID: 16244 RVA: 0x0021CF78 File Offset: 0x0021BF78
		public void Certify(string fieldName, Certificate certificate, bool timeStamp, CertifyingPermission permission)
		{
			this.Sign(fieldName, certificate, timeStamp);
			this.cj = permission;
		}

		// Token: 0x06003F75 RID: 16245 RVA: 0x0021CF90 File Offset: 0x0021BF90
		internal CertifyingPermission b()
		{
			return this.cj;
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06003F76 RID: 16246 RVA: 0x0021CFA8 File Offset: 0x0021BFA8
		// (set) Token: 0x06003F77 RID: 16247 RVA: 0x0021CFBF File Offset: 0x0021BFBF
		[Obsolete("This property is obsolete. Use GlobalSettings class instead.")]
		public static PdfFormat DefaultPdfFormat
		{
			get
			{
				return GlobalSettings.DefaultOutputPdfFormat;
			}
			set
			{
				GlobalSettings.DefaultOutputPdfFormat = value;
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06003F78 RID: 16248 RVA: 0x0021CFCC File Offset: 0x0021BFCC
		// (set) Token: 0x06003F79 RID: 16249 RVA: 0x0021CFE3 File Offset: 0x0021BFE3
		[Obsolete("This property is obsolete. Use GlobalSettings class instead.")]
		public static PdfVersion DefaultPdfVersion
		{
			get
			{
				return GlobalSettings.DefaultOutputPdfVersion;
			}
			set
			{
				GlobalSettings.DefaultOutputPdfVersion = value;
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06003F7A RID: 16250 RVA: 0x0021CFF0 File Offset: 0x0021BFF0
		public ViewerPreferences ViewerPreferences
		{
			get
			{
				return this.bd;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06003F7B RID: 16251 RVA: 0x0021D008 File Offset: 0x0021C008
		// (set) Token: 0x06003F7C RID: 16252 RVA: 0x0021D020 File Offset: 0x0021C020
		public Template Template
		{
			get
			{
				return this.be;
			}
			set
			{
				this.be = value;
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06003F7D RID: 16253 RVA: 0x0021D02C File Offset: 0x0021C02C
		// (set) Token: 0x06003F7E RID: 16254 RVA: 0x0021D044 File Offset: 0x0021C044
		public Template StampTemplate
		{
			get
			{
				return this.bf;
			}
			set
			{
				this.bf = value;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06003F7F RID: 16255 RVA: 0x0021D050 File Offset: 0x0021C050
		public SectionList Sections
		{
			get
			{
				return this.bg;
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06003F80 RID: 16256 RVA: 0x0021D068 File Offset: 0x0021C068
		// (set) Token: 0x06003F81 RID: 16257 RVA: 0x0021D080 File Offset: 0x0021C080
		public PdfFormat PdfFormat
		{
			get
			{
				return this.bj;
			}
			set
			{
				this.bj = value;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06003F82 RID: 16258 RVA: 0x0021D08C File Offset: 0x0021C08C
		// (set) Token: 0x06003F83 RID: 16259 RVA: 0x0021D1DF File Offset: 0x0021C1DF
		public PdfXVersion PdfXVersion
		{
			get
			{
				PdfXVersion result;
				if (this.b6 == null)
				{
					result = this.b3;
				}
				else
				{
					string text = this.b6.kf();
					switch (text)
					{
					case "PDF/X-3:2003":
						return PdfXVersion.PDF_X_3_2003;
					case "PDF/X-3:2002":
						return PdfXVersion.PDF_X_3_2002;
					case "PDF/X-2:2003":
						return PdfXVersion.PDF_X_2_2003;
					case "PDF/X-1:2001":
						if (this.b7 == null)
						{
							return PdfXVersion.PDF_X_1_2001;
						}
						if (this.b7.kf() == "PDF/X-1a:2001")
						{
							return PdfXVersion.PDF_X_1a_2001;
						}
						if (this.b7.kf() == "PDF/X-1a:2003")
						{
							return PdfXVersion.PDF_X_1a_2003;
						}
						return PdfXVersion.PDF_X_1_2001;
					case "PDF/X-1a:2001":
						return PdfXVersion.PDF_X_1a_2001;
					case "PDF/X-1a:2003":
						return PdfXVersion.PDF_X_1a_2003;
					case "PDF/X-1:1999":
						return PdfXVersion.PDF_X_1_1999;
					}
					result = PdfXVersion.None;
				}
				return result;
			}
			set
			{
				this.b6 = null;
				this.b7 = null;
				this.b3 = value;
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06003F84 RID: 16260 RVA: 0x0021D1F8 File Offset: 0x0021C1F8
		// (set) Token: 0x06003F85 RID: 16261 RVA: 0x0021D210 File Offset: 0x0021C210
		public Trapped Trapped
		{
			get
			{
				return this.b4;
			}
			set
			{
				this.b4 = value;
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06003F86 RID: 16262 RVA: 0x0021D21C File Offset: 0x0021C21C
		// (set) Token: 0x06003F87 RID: 16263 RVA: 0x0021D234 File Offset: 0x0021C234
		public DocumentPackage Package
		{
			get
			{
				return this.bq;
			}
			set
			{
				this.bq = value;
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06003F88 RID: 16264 RVA: 0x0021D240 File Offset: 0x0021C240
		public DocumentReaderEvents ReaderEvents
		{
			get
			{
				DocumentReaderEvents result;
				if (this.bp == null)
				{
					this.bp = new DocumentReaderEvents();
					result = this.bp;
				}
				else
				{
					result = this.bp;
				}
				return result;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06003F89 RID: 16265 RVA: 0x0021D280 File Offset: 0x0021C280
		public OutputIntentList OutputIntents
		{
			get
			{
				if (this.b5 == null)
				{
					this.b5 = new OutputIntentList();
				}
				return this.b5;
			}
		}

		// Token: 0x06003F8A RID: 16266 RVA: 0x0021D2B4 File Offset: 0x0021C2B4
		private void c(DocumentWriter A_0)
		{
			if (this.a4 != null)
			{
				A_0.WriteName(Document.h);
				A_0.WriteText(this.a4);
			}
			if (this.a6 != null)
			{
				A_0.WriteName(Document.i);
				A_0.WriteText(this.a6);
			}
			if (this.a7 != null)
			{
				A_0.WriteName(Document.j);
				A_0.WriteText(this.a7);
			}
			if (this.a8 != null)
			{
				A_0.WriteName(Document.k);
				A_0.WriteText(this.a8);
			}
			if (this.a9 != null)
			{
				A_0.WriteName(Document.l);
				A_0.WriteText(this.a9);
			}
			A_0.WriteName(Document.m);
			if (this.a5 != null)
			{
				A_0.WriteText(this.a5);
			}
			else
			{
				A_0.WriteText(Document.e);
			}
			A_0.WriteName(Document.n);
			string str = A_0.CreationDate.ToString("yyyyMMddHHmmsszzz").Replace(':', '\'');
			A_0.WriteText("D:" + str + "'");
			A_0.WriteName(Document.o);
			str = A_0.ModifiedDate.ToString("yyyyMMddHHmmsszzz").Replace(':', '\'');
			A_0.WriteText("D:" + str + "'");
			if (this.b5 != null)
			{
				if (this.b4 != Trapped.Unknown)
				{
					A_0.WriteName(Document.bt);
					if (this.b4 == Trapped.True)
					{
						A_0.WriteName(Document.bu);
					}
					else
					{
						A_0.WriteName(Document.bv);
					}
				}
				if (this.b6 == null)
				{
					switch (this.b3)
					{
					case PdfXVersion.PDF_X_1_1999:
						A_0.WriteName(Document.br);
						A_0.WriteText(Document.b2);
						break;
					case PdfXVersion.PDF_X_1_2001:
						A_0.WriteName(Document.br);
						A_0.WriteText(Document.bx);
						break;
					case PdfXVersion.PDF_X_1a_2001:
						A_0.WriteName(Document.br);
						A_0.WriteText(Document.bx);
						A_0.WriteName(Document.bs);
						A_0.WriteText(Document.by);
						break;
					case PdfXVersion.PDF_X_1a_2003:
						A_0.WriteName(Document.br);
						A_0.WriteText(Document.bw);
						break;
					case PdfXVersion.PDF_X_2_2003:
						A_0.WriteName(Document.br);
						A_0.WriteText(Document.b1);
						break;
					case PdfXVersion.PDF_X_3_2002:
						A_0.WriteName(Document.br);
						A_0.WriteText(Document.b0);
						break;
					case PdfXVersion.PDF_X_3_2003:
						A_0.WriteName(Document.br);
						A_0.WriteText(Document.bz);
						break;
					}
				}
				else
				{
					A_0.WriteName(Document.br);
					this.b6.hz(A_0);
					if (this.b7 != null)
					{
						A_0.WriteName(Document.bs);
						this.b7.hz(A_0);
					}
				}
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06003F8B RID: 16267 RVA: 0x0021D5F4 File Offset: 0x0021C5F4
		public PageList Pages
		{
			get
			{
				return this.aw;
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06003F8C RID: 16268 RVA: 0x0021D60C File Offset: 0x0021C60C
		public OutlineList Outlines
		{
			get
			{
				return this.av;
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06003F8D RID: 16269 RVA: 0x0021D624 File Offset: 0x0021C624
		// (set) Token: 0x06003F8E RID: 16270 RVA: 0x0021D63C File Offset: 0x0021C63C
		public virtual PageZoom InitialPageZoom
		{
			get
			{
				return this.ax;
			}
			set
			{
				this.ax = value;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06003F8F RID: 16271 RVA: 0x0021D648 File Offset: 0x0021C648
		// (set) Token: 0x06003F90 RID: 16272 RVA: 0x0021D660 File Offset: 0x0021C660
		public PageMode InitialPageMode
		{
			get
			{
				return this.ay;
			}
			set
			{
				this.ay = value;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06003F91 RID: 16273 RVA: 0x0021D66C File Offset: 0x0021C66C
		// (set) Token: 0x06003F92 RID: 16274 RVA: 0x0021D684 File Offset: 0x0021C684
		public PageLayout InitialPageLayout
		{
			get
			{
				return this.az;
			}
			set
			{
				this.b9 = true;
				this.az = value;
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06003F93 RID: 16275 RVA: 0x0021D698 File Offset: 0x0021C698
		// (set) Token: 0x06003F94 RID: 16276 RVA: 0x0021D6B0 File Offset: 0x0021C6B0
		public virtual int InitialPage
		{
			get
			{
				return this.a3;
			}
			set
			{
				this.a3 = value;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06003F95 RID: 16277 RVA: 0x0021D6BC File Offset: 0x0021C6BC
		// (set) Token: 0x06003F96 RID: 16278 RVA: 0x0021D6EC File Offset: 0x0021C6EC
		public string Producer
		{
			get
			{
				string result;
				if (this.a5 == null)
				{
					result = Document.e;
				}
				else
				{
					result = this.a5;
				}
				return result;
			}
			set
			{
				this.a5 = value;
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06003F97 RID: 16279 RVA: 0x0021D6F8 File Offset: 0x0021C6F8
		// (set) Token: 0x06003F98 RID: 16280 RVA: 0x0021D710 File Offset: 0x0021C710
		public string Author
		{
			get
			{
				return this.a4;
			}
			set
			{
				this.a4 = value;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06003F99 RID: 16281 RVA: 0x0021D71C File Offset: 0x0021C71C
		// (set) Token: 0x06003F9A RID: 16282 RVA: 0x0021D734 File Offset: 0x0021C734
		public string Language
		{
			get
			{
				return this.ba;
			}
			set
			{
				this.ba = value;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06003F9B RID: 16283 RVA: 0x0021D740 File Offset: 0x0021C740
		// (set) Token: 0x06003F9C RID: 16284 RVA: 0x0021D758 File Offset: 0x0021C758
		public string Creator
		{
			get
			{
				return this.a6;
			}
			set
			{
				this.a6 = value;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06003F9D RID: 16285 RVA: 0x0021D764 File Offset: 0x0021C764
		// (set) Token: 0x06003F9E RID: 16286 RVA: 0x0021D77C File Offset: 0x0021C77C
		public string Keywords
		{
			get
			{
				return this.a7;
			}
			set
			{
				this.a7 = value;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06003F9F RID: 16287 RVA: 0x0021D788 File Offset: 0x0021C788
		// (set) Token: 0x06003FA0 RID: 16288 RVA: 0x0021D7A0 File Offset: 0x0021C7A0
		public string Subject
		{
			get
			{
				return this.a8;
			}
			set
			{
				this.a8 = value;
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06003FA1 RID: 16289 RVA: 0x0021D7AC File Offset: 0x0021C7AC
		// (set) Token: 0x06003FA2 RID: 16290 RVA: 0x0021D7C4 File Offset: 0x0021C7C4
		public string Title
		{
			get
			{
				return this.a9;
			}
			set
			{
				this.a9 = value;
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06003FA3 RID: 16291 RVA: 0x0021D7D0 File Offset: 0x0021C7D0
		public CustomPropertyList CustomProperties
		{
			get
			{
				CustomPropertyList result;
				if (this.bn == null)
				{
					this.bn = new CustomPropertyList();
					result = this.bn;
				}
				else
				{
					result = this.bn;
				}
				return result;
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06003FA4 RID: 16292 RVA: 0x0021D810 File Offset: 0x0021C810
		// (set) Token: 0x06003FA5 RID: 16293 RVA: 0x0021D828 File Offset: 0x0021C828
		public int CompressionLevel
		{
			get
			{
				return this.bb;
			}
			set
			{
				if (value > 9 || value < 0)
				{
					throw new GeneratorException("Invalid compression level. Compression level must be 0 to 9.");
				}
				this.bb = value;
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06003FA6 RID: 16294 RVA: 0x0021D860 File Offset: 0x0021C860
		// (set) Token: 0x06003FA7 RID: 16295 RVA: 0x0021D878 File Offset: 0x0021C878
		public Security Security
		{
			get
			{
				return this.a1;
			}
			set
			{
				this.a1 = value;
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06003FA8 RID: 16296 RVA: 0x0021D884 File Offset: 0x0021C884
		public Form Form
		{
			get
			{
				if (this.a2 == null)
				{
					this.a2 = new Form();
					this.RequireLicense(1);
				}
				return this.a2;
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06003FA9 RID: 16297 RVA: 0x0021D8C4 File Offset: 0x0021C8C4
		// (set) Token: 0x06003FAA RID: 16298 RVA: 0x0021D8DC File Offset: 0x0021C8DC
		public PdfVersion PdfVersion
		{
			get
			{
				return this.bh;
			}
			set
			{
				this.bh = value;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06003FAB RID: 16299 RVA: 0x0021D8E8 File Offset: 0x0021C8E8
		// (set) Token: 0x06003FAC RID: 16300 RVA: 0x0021D900 File Offset: 0x0021C900
		public virtual XmpMetadata XmpMetadata
		{
			get
			{
				return this.bi;
			}
			set
			{
				this.bi = value;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06003FAD RID: 16301 RVA: 0x0021D90C File Offset: 0x0021C90C
		public DocumentJavaScriptList JavaScripts
		{
			get
			{
				if (this.bk == null)
				{
					this.bk = new DocumentJavaScriptList();
				}
				return this.bk;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06003FAE RID: 16302 RVA: 0x0021D940 File Offset: 0x0021C940
		public EmbeddedFileList EmbeddedFiles
		{
			get
			{
				if (this.bo == null)
				{
					this.bo = new EmbeddedFileList();
				}
				return this.bo;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06003FAF RID: 16303 RVA: 0x0021D974 File Offset: 0x0021C974
		// (set) Token: 0x06003FB0 RID: 16304 RVA: 0x0021D98C File Offset: 0x0021C98C
		public TagOptions Tag
		{
			get
			{
				return this.ca;
			}
			set
			{
				this.ca = value;
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06003FB1 RID: 16305 RVA: 0x0021D998 File Offset: 0x0021C998
		// (set) Token: 0x06003FB2 RID: 16306 RVA: 0x0021D9B0 File Offset: 0x0021C9B0
		public DocumentOptimization Optimization
		{
			get
			{
				return this.ch;
			}
			set
			{
				this.ch = value;
			}
		}

		// Token: 0x06003FB3 RID: 16307 RVA: 0x0021D9BC File Offset: 0x0021C9BC
		internal dn c()
		{
			if (this.b8 == null)
			{
				this.b8 = new dn();
			}
			return this.b8;
		}

		// Token: 0x06003FB4 RID: 16308 RVA: 0x0021D9EF File Offset: 0x0021C9EF
		internal void a(bool A_0)
		{
			this.a0 = A_0;
		}

		// Token: 0x06003FB5 RID: 16309 RVA: 0x0021D9FC File Offset: 0x0021C9FC
		internal Form d()
		{
			if (this.a2 == null)
			{
				this.a2 = new Form();
			}
			return this.a2;
		}

		// Token: 0x06003FB6 RID: 16310 RVA: 0x0021DA34 File Offset: 0x0021CA34
		internal void a(ab7 A_0, ab7 A_1, abe A_2)
		{
			this.b3 = PdfXVersion.None;
			this.b6 = A_0;
			this.b7 = A_1;
			this.b5 = null;
			if (A_2 != null)
			{
				this.b5 = new OutputIntentList(A_2);
			}
		}

		// Token: 0x06003FB7 RID: 16311 RVA: 0x0021DA74 File Offset: 0x0021CA74
		internal FormFieldList e()
		{
			if (this.a2 == null)
			{
				this.a2 = new Form();
			}
			return this.a2.Fields;
		}

		// Token: 0x06003FB8 RID: 16312 RVA: 0x0021DAAC File Offset: 0x0021CAAC
		internal FormFieldList a(string[] A_0, int A_1)
		{
			FormFieldList formFieldList = this.e();
			for (int i = 0; i < A_1; i++)
			{
				FormField formField = formFieldList[A_0[i]];
				if (formField == null)
				{
					formField = new FormField(A_0[i]);
					formFieldList.Add(formField);
				}
				formFieldList = formField.ChildFields;
			}
			return formFieldList;
		}

		// Token: 0x06003FB9 RID: 16313 RVA: 0x0021DB0C File Offset: 0x0021CB0C
		internal FormFieldList a(string A_0)
		{
			FormFieldList result;
			if (A_0 == null || A_0.Length == 0)
			{
				result = this.e();
			}
			else
			{
				string[] array = A_0.Split(new char[]
				{
					'.'
				});
				result = this.a(array, array.Length);
			}
			return result;
		}

		// Token: 0x06003FBA RID: 16314 RVA: 0x0021DB5C File Offset: 0x0021CB5C
		internal void d(DocumentWriter A_0)
		{
			if (this.av.Count > 0 && this.av.a())
			{
				this.RequireLicense(1);
			}
			if (this.bk != null)
			{
				this.RequireLicense(this.bk.e());
			}
			if (this.a2 != null && this.a2.Fields.Count > 0 && this.a2.a())
			{
				this.RequireLicense(13);
			}
			if (this.bi != null)
			{
				this.RequireLicense(3);
			}
			if (this.bo != null)
			{
				this.RequireLicense(this.bo.c());
			}
			if (this.b5 != null)
			{
				this.RequireLicense(this.b5.a());
			}
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			if (this.bn != null)
			{
				this.RequireLicense(1);
				foreach (KeyValuePair<string, string> keyValuePair in this.bn.a())
				{
					string text = keyValuePair.Key;
					if (text.Contains(" "))
					{
						StringBuilder stringBuilder = new StringBuilder();
						foreach (char c in text)
						{
							if (c == ' ')
							{
								stringBuilder.Append("#20");
							}
							else
							{
								stringBuilder.Append(c);
							}
						}
						text = stringBuilder.ToString();
					}
					A_0.WriteName(text);
					A_0.WriteText(keyValuePair.Value);
				}
			}
			this.c(A_0);
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x06003FBB RID: 16315 RVA: 0x0021DD7C File Offset: 0x0021CD7C
		internal void e(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Document.ai);
			A_0.WriteName(Document.aj);
			this.DrawRootEntries(A_0);
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x06003FBC RID: 16316 RVA: 0x0021DDBC File Offset: 0x0021CDBC
		private void b(DocumentWriter A_0)
		{
			switch (this.az)
			{
			case PageLayout.SinglePage:
				A_0.WriteName(Document.p);
				A_0.WriteName(Document.r);
				break;
			case PageLayout.OneColumn:
				A_0.WriteName(Document.p);
				A_0.WriteName(Document.q);
				break;
			case PageLayout.TwoColumnLeft:
				A_0.WriteName(Document.p);
				A_0.WriteName(Document.s);
				break;
			case PageLayout.TwoColumnRight:
				A_0.WriteName(Document.p);
				A_0.WriteName(Document.t);
				break;
			case PageLayout.TwoPageLeft:
				A_0.WriteName(Document.p);
				A_0.WriteName(Document.u);
				break;
			case PageLayout.TwoPageRight:
				A_0.WriteName(Document.p);
				A_0.WriteName(Document.v);
				break;
			}
		}

		// Token: 0x06003FBD RID: 16317 RVA: 0x0021DE94 File Offset: 0x0021CE94
		private void a(DocumentWriter A_0)
		{
			switch (this.ay)
			{
			case PageMode.Auto:
				if (this.av.Count <= 0)
				{
					return;
				}
				break;
			case PageMode.ShowNone:
				A_0.WriteName(Document.w);
				A_0.WriteName(Document.x);
				return;
			case PageMode.ShowOutlines:
				break;
			case PageMode.ShowThumbnails:
				A_0.WriteName(Document.w);
				A_0.WriteName(Document.aa);
				return;
			case PageMode.ShowOptionalContent:
				A_0.WriteName(Document.w);
				A_0.WriteName(Document.ab);
				return;
			case PageMode.ShowAttachments:
				A_0.WriteName(Document.w);
				A_0.WriteName(Document.ao);
				return;
			case PageMode.FullScreen:
				A_0.WriteName(Document.w);
				A_0.WriteName(Document.y);
				return;
			default:
				return;
			}
			A_0.WriteName(Document.w);
			A_0.WriteName(Document.z);
		}

		// Token: 0x06003FBE RID: 16318 RVA: 0x0021DF8C File Offset: 0x0021CF8C
		internal virtual void hv(DocumentWriter A_0)
		{
			if (this.bi != null)
			{
				this.bi.a(this.bn);
				A_0.WriteName(Document.f);
				A_0.WriteReference(this.bi);
			}
		}

		// Token: 0x06003FBF RID: 16319 RVA: 0x0021DFD4 File Offset: 0x0021CFD4
		internal PdfAStandard? f()
		{
			PdfAStandard? result;
			if (this.bi != null)
			{
				result = this.bi.e();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06003FC0 RID: 16320 RVA: 0x0021E00C File Offset: 0x0021D00C
		protected virtual void DrawRootEntries(DocumentWriter writer)
		{
			writer.WriteName(Document.al);
			writer.WriteReference(writer.al());
			if (this.av.Count > 0)
			{
				writer.WriteName(Document.ak);
				aad resource = new aad(this.av, writer.Resources.CurrentObjectNumber);
				writer.f(writer.Resources.AddUnique(resource));
				writer.WriteReference(writer.aa());
			}
			this.hv(writer);
			if (this.b9)
			{
				this.b(writer);
			}
			this.a(writer);
			this.bd.Draw(writer);
			this.bg.a(writer);
			this.f(writer);
			if (this.bp != null)
			{
				this.bp.a(writer);
			}
			this.g(writer);
			if ((this.a2 != null && this.a2.Fields.Count > 0) || (this.a2 != null && this.a2.f()))
			{
				this.a2.i();
				writer.WriteName(Document.ac);
				writer.WriteReference(this.a2);
			}
			if (this.cj != (CertifyingPermission)0)
			{
				ArrayList arrayList = writer.Resources.a;
				for (int i = 0; i < arrayList.Count; i++)
				{
					if (arrayList[i] is dx)
					{
						dx dx = (dx)arrayList[i];
						if (this.i() != null && this.i().ContainsKey(dx.a().Name))
						{
							writer.WriteName(Document.cl);
							writer.WriteDictionaryOpen();
							writer.WriteName(Document.ck);
							writer.WriteReference(dx.c());
							break;
						}
					}
				}
				writer.WriteDictionaryClose();
			}
			if (this.a0)
			{
				if (this.ax != PageZoom.None)
				{
					writer.WriteName(Document.g);
					this.hw(writer);
				}
			}
			if (this.b5 != null)
			{
				this.b5.a(writer);
			}
			if (this.ba != null && this.ba != string.Empty)
			{
				writer.WriteName("Lang");
				writer.WriteText(this.ba);
			}
			if (this.b8 != null)
			{
				this.b8.a(writer);
			}
			if (this.Tag != null || this.cb != null || this.l())
			{
				if (this.cd || (this.cb != null && this.cb.j()) || this.ce)
				{
					writer.WriteName(Document.ap);
					writer.WriteDictionaryOpen();
					if (this.cd)
					{
						writer.WriteName(Document.aq);
						writer.ak(32);
						writer.ap();
					}
					if (this.cb != null && this.cb.j())
					{
						writer.WriteName(Document.ar);
						writer.ak(32);
						writer.ap();
					}
					if (this.ce)
					{
						writer.WriteName(Document.@as);
						writer.ak(32);
						writer.ap();
					}
					writer.WriteDictionaryClose();
				}
			}
			if (this.bo != null)
			{
				PdfAStandard? pdfAStandard = this.f();
				if (pdfAStandard != null)
				{
					if (pdfAStandard == PdfAStandard.PdfA3a || pdfAStandard == PdfAStandard.PdfA3b || pdfAStandard == PdfAStandard.PdfA3u)
					{
						writer.a(true);
						writer.WriteName(Document.au);
						writer.WriteArrayOpen();
						for (int i = 0; i < this.bo.Count; i++)
						{
							writer.WriteReference(this.bo[i].b());
						}
						writer.WriteArrayClose();
					}
				}
			}
			if (this.cb != null)
			{
				writer.WriteName(Document.at);
				writer.WriteReference(writer.Resources.Add(this.cb));
			}
		}

		// Token: 0x06003FC1 RID: 16321 RVA: 0x0021E504 File Offset: 0x0021D504
		internal void f(DocumentWriter A_0)
		{
			if (this.bk != null || this.bl != null || this.bo != null)
			{
				A_0.WriteName(Document.am);
				A_0.WriteReferenceUnique(new x9(this.bk, this.bl, this.bo));
			}
		}

		// Token: 0x06003FC2 RID: 16322 RVA: 0x0021E560 File Offset: 0x0021D560
		internal void g(DocumentWriter A_0)
		{
			if (this.bq != null)
			{
				A_0.WriteName(Document.an);
				A_0.WriteReferenceUnique(this.bq);
			}
		}

		// Token: 0x06003FC3 RID: 16323 RVA: 0x0021E598 File Offset: 0x0021D598
		internal virtual void hw(DocumentWriter A_0)
		{
			switch (this.ax)
			{
			case PageZoom.Retain:
				A_0.WriteArrayOpen();
				A_0.WriteReference(A_0.GetPageObject(this.a3));
				A_0.WriteName(Document.ad);
				A_0.WriteNull();
				A_0.WriteNull();
				A_0.WriteNull();
				A_0.WriteArrayClose();
				break;
			case PageZoom.FitPage:
				A_0.WriteArrayOpen();
				A_0.WriteReference(A_0.GetPageObject(this.a3));
				A_0.WriteName(Document.ae);
				A_0.WriteArrayClose();
				break;
			case PageZoom.FitWidth:
				A_0.WriteArrayOpen();
				A_0.WriteReference(A_0.GetPageObject(this.a3));
				A_0.WriteName(Document.af);
				A_0.WriteArrayClose();
				break;
			case PageZoom.FitHeight:
				A_0.WriteArrayOpen();
				A_0.WriteReference(A_0.GetPageObject(this.a3));
				A_0.WriteName(Document.ag);
				A_0.WriteArrayClose();
				break;
			case PageZoom.FitBox:
				A_0.WriteArrayOpen();
				A_0.WriteReference(A_0.GetPageObject(this.a3));
				A_0.WriteName(Document.ah);
				A_0.WriteArrayClose();
				break;
			}
		}

		// Token: 0x06003FC4 RID: 16324 RVA: 0x0021E6D4 File Offset: 0x0021D6D4
		internal bool g()
		{
			return !aae.c(this.bc);
		}

		// Token: 0x06003FC5 RID: 16325 RVA: 0x0021E6F4 File Offset: 0x0021D6F4
		internal int h()
		{
			return this.bc;
		}

		// Token: 0x06003FC6 RID: 16326 RVA: 0x0021E70C File Offset: 0x0021D70C
		internal void b(abj A_0)
		{
			this.bl = A_0;
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06003FC7 RID: 16327 RVA: 0x0021E718 File Offset: 0x0021D718
		// (set) Token: 0x06003FC8 RID: 16328 RVA: 0x0021E730 File Offset: 0x0021D730
		public DiskBufferingOptions DiskBuffering
		{
			get
			{
				return this.bm;
			}
			set
			{
				this.bm = value;
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06003FC9 RID: 16329 RVA: 0x0021E73C File Offset: 0x0021D73C
		public static Version ProductVersion
		{
			get
			{
				return Document.b;
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06003FCA RID: 16330 RVA: 0x0021E754 File Offset: 0x0021D754
		public static int ProductBuild
		{
			get
			{
				return Document.c;
			}
		}

		// Token: 0x06003FCB RID: 16331 RVA: 0x0021E76C File Offset: 0x0021D76C
		internal static char[] a()
		{
			return Document.d;
		}

		// Token: 0x06003FCC RID: 16332 RVA: 0x0021E784 File Offset: 0x0021D784
		internal Hashtable i()
		{
			return this.ci;
		}

		// Token: 0x06003FCD RID: 16333 RVA: 0x0021E79C File Offset: 0x0021D79C
		internal r2 j()
		{
			return this.cb;
		}

		// Token: 0x06003FCE RID: 16334 RVA: 0x0021E7B4 File Offset: 0x0021D7B4
		internal void a(r2 A_0)
		{
			this.cb = A_0;
		}

		// Token: 0x06003FCF RID: 16335 RVA: 0x0021E7C0 File Offset: 0x0021D7C0
		internal int k()
		{
			return this.cc;
		}

		// Token: 0x06003FD0 RID: 16336 RVA: 0x0021E7D8 File Offset: 0x0021D7D8
		internal void a(int A_0)
		{
			this.cc = A_0;
		}

		// Token: 0x06003FD1 RID: 16337 RVA: 0x0021E7E2 File Offset: 0x0021D7E2
		internal void b(bool A_0)
		{
			this.cd = A_0;
		}

		// Token: 0x06003FD2 RID: 16338 RVA: 0x0021E7EC File Offset: 0x0021D7EC
		internal void c(bool A_0)
		{
			this.ce = A_0;
		}

		// Token: 0x06003FD3 RID: 16339 RVA: 0x0021E7F8 File Offset: 0x0021D7F8
		internal bool l()
		{
			return this.cf;
		}

		// Token: 0x06003FD4 RID: 16340 RVA: 0x0021E810 File Offset: 0x0021D810
		internal void d(bool A_0)
		{
			this.cf = A_0;
		}

		// Token: 0x06003FD5 RID: 16341 RVA: 0x0021E81A File Offset: 0x0021D81A
		internal void e(bool A_0)
		{
			this.b9 = A_0;
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06003FD6 RID: 16342 RVA: 0x0021E824 File Offset: 0x0021D824
		// (set) Token: 0x06003FD7 RID: 16343 RVA: 0x0021E83C File Offset: 0x0021D83C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This property is obsolete. Use Document.Form.Output property instead.")]
		public FormFlatteningOptions FormFlattening
		{
			get
			{
				return this.cg;
			}
			set
			{
				if (value != null)
				{
					this.cg = value;
					this.d().Output = FormOutput.Flatten;
					switch (value.DigitalSignatures)
					{
					case SignatureFieldFlatteningOptions.Flatten:
						this.d().SignatureFieldsOutput = FormFieldOutput.Flatten;
						break;
					case SignatureFieldFlatteningOptions.Remove:
						this.d().SignatureFieldsOutput = FormFieldOutput.Remove;
						break;
					case SignatureFieldFlatteningOptions.Retain:
						this.d().SignatureFieldsOutput = FormFieldOutput.Retain;
						break;
					}
				}
			}
		}

		// Token: 0x04002214 RID: 8724
		internal static ResourceManager a = r0.e0();

		// Token: 0x04002215 RID: 8725
		private static Version b;

		// Token: 0x04002216 RID: 8726
		private static int c;

		// Token: 0x04002217 RID: 8727
		private static char[] d;

		// Token: 0x04002218 RID: 8728
		private static string e;

		// Token: 0x04002219 RID: 8729
		internal static byte[] f = new byte[]
		{
			77,
			101,
			116,
			97,
			100,
			97,
			116,
			97
		};

		// Token: 0x0400221A RID: 8730
		internal static byte[] g = new byte[]
		{
			79,
			112,
			101,
			110,
			65,
			99,
			116,
			105,
			111,
			110
		};

		// Token: 0x0400221B RID: 8731
		private static byte[] h = new byte[]
		{
			65,
			117,
			116,
			104,
			111,
			114
		};

		// Token: 0x0400221C RID: 8732
		private static byte[] i = new byte[]
		{
			67,
			114,
			101,
			97,
			116,
			111,
			114
		};

		// Token: 0x0400221D RID: 8733
		private static byte[] j = new byte[]
		{
			75,
			101,
			121,
			119,
			111,
			114,
			100,
			115
		};

		// Token: 0x0400221E RID: 8734
		private static byte[] k = new byte[]
		{
			83,
			117,
			98,
			106,
			101,
			99,
			116
		};

		// Token: 0x0400221F RID: 8735
		private static byte[] l = new byte[]
		{
			84,
			105,
			116,
			108,
			101
		};

		// Token: 0x04002220 RID: 8736
		private static byte[] m = new byte[]
		{
			80,
			114,
			111,
			100,
			117,
			99,
			101,
			114
		};

		// Token: 0x04002221 RID: 8737
		private static byte[] n = new byte[]
		{
			67,
			114,
			101,
			97,
			116,
			105,
			111,
			110,
			68,
			97,
			116,
			101
		};

		// Token: 0x04002222 RID: 8738
		private static byte[] o = new byte[]
		{
			77,
			111,
			100,
			68,
			97,
			116,
			101
		};

		// Token: 0x04002223 RID: 8739
		private static byte[] p = new byte[]
		{
			80,
			97,
			103,
			101,
			76,
			97,
			121,
			111,
			117,
			116
		};

		// Token: 0x04002224 RID: 8740
		private static byte[] q = new byte[]
		{
			79,
			110,
			101,
			67,
			111,
			108,
			117,
			109,
			110
		};

		// Token: 0x04002225 RID: 8741
		private static byte[] r = new byte[]
		{
			83,
			105,
			110,
			103,
			108,
			101,
			80,
			97,
			103,
			101
		};

		// Token: 0x04002226 RID: 8742
		private static byte[] s = new byte[]
		{
			84,
			119,
			111,
			67,
			111,
			108,
			117,
			109,
			110,
			76,
			101,
			102,
			116
		};

		// Token: 0x04002227 RID: 8743
		private static byte[] t = new byte[]
		{
			84,
			119,
			111,
			67,
			111,
			108,
			117,
			109,
			110,
			82,
			105,
			103,
			104,
			116
		};

		// Token: 0x04002228 RID: 8744
		private static byte[] u = new byte[]
		{
			84,
			119,
			111,
			80,
			97,
			103,
			101,
			76,
			101,
			102,
			116
		};

		// Token: 0x04002229 RID: 8745
		private static byte[] v = new byte[]
		{
			84,
			119,
			111,
			80,
			97,
			103,
			101,
			82,
			105,
			103,
			104,
			116
		};

		// Token: 0x0400222A RID: 8746
		private static byte[] w = new byte[]
		{
			80,
			97,
			103,
			101,
			77,
			111,
			100,
			101
		};

		// Token: 0x0400222B RID: 8747
		private static byte[] x = new byte[]
		{
			85,
			115,
			101,
			78,
			111,
			110,
			101
		};

		// Token: 0x0400222C RID: 8748
		private static byte[] y = new byte[]
		{
			70,
			117,
			108,
			108,
			83,
			99,
			114,
			101,
			101,
			110
		};

		// Token: 0x0400222D RID: 8749
		private static byte[] z = new byte[]
		{
			85,
			115,
			101,
			79,
			117,
			116,
			108,
			105,
			110,
			101,
			115
		};

		// Token: 0x0400222E RID: 8750
		private static byte[] aa = new byte[]
		{
			85,
			115,
			101,
			84,
			104,
			117,
			109,
			98,
			115
		};

		// Token: 0x0400222F RID: 8751
		private static byte[] ab = new byte[]
		{
			85,
			115,
			101,
			79,
			67
		};

		// Token: 0x04002230 RID: 8752
		private static byte[] ac = new byte[]
		{
			65,
			99,
			114,
			111,
			70,
			111,
			114,
			109
		};

		// Token: 0x04002231 RID: 8753
		private static byte[] ad = new byte[]
		{
			88,
			89,
			90
		};

		// Token: 0x04002232 RID: 8754
		private static byte[] ae = new byte[]
		{
			70,
			105,
			116
		};

		// Token: 0x04002233 RID: 8755
		private static byte[] af = new byte[]
		{
			70,
			105,
			116,
			72
		};

		// Token: 0x04002234 RID: 8756
		private static byte[] ag = new byte[]
		{
			70,
			105,
			116,
			86
		};

		// Token: 0x04002235 RID: 8757
		private static byte[] ah = new byte[]
		{
			70,
			105,
			116,
			66
		};

		// Token: 0x04002236 RID: 8758
		private static byte[] ai = new byte[]
		{
			84,
			121,
			112,
			101
		};

		// Token: 0x04002237 RID: 8759
		private static byte[] aj = new byte[]
		{
			67,
			97,
			116,
			97,
			108,
			111,
			103
		};

		// Token: 0x04002238 RID: 8760
		private static byte[] ak = new byte[]
		{
			79,
			117,
			116,
			108,
			105,
			110,
			101,
			115
		};

		// Token: 0x04002239 RID: 8761
		private static byte[] al = new byte[]
		{
			80,
			97,
			103,
			101,
			115
		};

		// Token: 0x0400223A RID: 8762
		private static byte[] am = new byte[]
		{
			78,
			97,
			109,
			101,
			115
		};

		// Token: 0x0400223B RID: 8763
		private static byte[] an = new byte[]
		{
			67,
			111,
			108,
			108,
			101,
			99,
			116,
			105,
			111,
			110
		};

		// Token: 0x0400223C RID: 8764
		private static byte[] ao = new byte[]
		{
			85,
			115,
			101,
			65,
			116,
			97,
			99,
			104,
			109,
			101,
			110,
			116,
			115
		};

		// Token: 0x0400223D RID: 8765
		private static byte[] ap = new byte[]
		{
			77,
			97,
			114,
			107,
			73,
			110,
			102,
			111
		};

		// Token: 0x0400223E RID: 8766
		private static byte[] aq = new byte[]
		{
			77,
			97,
			114,
			107,
			101,
			100
		};

		// Token: 0x0400223F RID: 8767
		private static byte[] ar = new byte[]
		{
			85,
			115,
			101,
			114,
			80,
			114,
			111,
			112,
			101,
			114,
			116,
			105,
			101,
			115
		};

		// Token: 0x04002240 RID: 8768
		private static byte[] @as = new byte[]
		{
			83,
			117,
			115,
			112,
			101,
			99,
			116,
			115
		};

		// Token: 0x04002241 RID: 8769
		private static byte[] at = new byte[]
		{
			83,
			116,
			114,
			117,
			99,
			116,
			84,
			114,
			101,
			101,
			82,
			111,
			111,
			116
		};

		// Token: 0x04002242 RID: 8770
		private static byte[] au = new byte[]
		{
			65,
			70
		};

		// Token: 0x04002243 RID: 8771
		private OutlineList av = new OutlineList();

		// Token: 0x04002244 RID: 8772
		private PageList aw = new PageList();

		// Token: 0x04002245 RID: 8773
		private PageZoom ax = PageZoom.Retain;

		// Token: 0x04002246 RID: 8774
		private PageMode ay = PageMode.Auto;

		// Token: 0x04002247 RID: 8775
		private PageLayout az = PageLayout.SinglePage;

		// Token: 0x04002248 RID: 8776
		private bool a0 = true;

		// Token: 0x04002249 RID: 8777
		private Security a1 = null;

		// Token: 0x0400224A RID: 8778
		private Form a2 = null;

		// Token: 0x0400224B RID: 8779
		private int a3 = 1;

		// Token: 0x0400224C RID: 8780
		private string a4 = null;

		// Token: 0x0400224D RID: 8781
		private string a5 = null;

		// Token: 0x0400224E RID: 8782
		private string a6 = null;

		// Token: 0x0400224F RID: 8783
		private string a7 = null;

		// Token: 0x04002250 RID: 8784
		private string a8 = null;

		// Token: 0x04002251 RID: 8785
		private string a9 = null;

		// Token: 0x04002252 RID: 8786
		private string ba = null;

		// Token: 0x04002253 RID: 8787
		private int bb = 6;

		// Token: 0x04002254 RID: 8788
		private int bc = 0;

		// Token: 0x04002255 RID: 8789
		private ViewerPreferences bd = new ViewerPreferences();

		// Token: 0x04002256 RID: 8790
		private Template be = null;

		// Token: 0x04002257 RID: 8791
		private Template bf = null;

		// Token: 0x04002258 RID: 8792
		private SectionList bg;

		// Token: 0x04002259 RID: 8793
		private PdfVersion bh = GlobalSettings.DefaultOutputPdfVersion;

		// Token: 0x0400225A RID: 8794
		private XmpMetadata bi;

		// Token: 0x0400225B RID: 8795
		private PdfFormat bj = GlobalSettings.DefaultOutputPdfFormat;

		// Token: 0x0400225C RID: 8796
		private DocumentJavaScriptList bk = null;

		// Token: 0x0400225D RID: 8797
		private abj bl = null;

		// Token: 0x0400225E RID: 8798
		private DiskBufferingOptions bm = null;

		// Token: 0x0400225F RID: 8799
		private CustomPropertyList bn = null;

		// Token: 0x04002260 RID: 8800
		private EmbeddedFileList bo = null;

		// Token: 0x04002261 RID: 8801
		private DocumentReaderEvents bp = null;

		// Token: 0x04002262 RID: 8802
		private DocumentPackage bq = null;

		// Token: 0x04002263 RID: 8803
		private static byte[] br = new byte[]
		{
			71,
			84,
			83,
			95,
			80,
			68,
			70,
			88,
			86,
			101,
			114,
			115,
			105,
			111,
			110
		};

		// Token: 0x04002264 RID: 8804
		private static byte[] bs = new byte[]
		{
			71,
			84,
			83,
			95,
			80,
			68,
			70,
			88,
			67,
			111,
			110,
			102,
			111,
			114,
			109,
			97,
			110,
			99,
			101
		};

		// Token: 0x04002265 RID: 8805
		private static byte[] bt = new byte[]
		{
			84,
			114,
			97,
			112,
			112,
			101,
			100
		};

		// Token: 0x04002266 RID: 8806
		private static byte[] bu = new byte[]
		{
			84,
			114,
			117,
			101
		};

		// Token: 0x04002267 RID: 8807
		private static byte[] bv = new byte[]
		{
			70,
			97,
			108,
			115,
			101
		};

		// Token: 0x04002268 RID: 8808
		private static byte[] bw = new byte[]
		{
			80,
			68,
			70,
			47,
			88,
			45,
			49,
			97,
			58,
			50,
			48,
			48,
			51
		};

		// Token: 0x04002269 RID: 8809
		private static byte[] bx = new byte[]
		{
			80,
			68,
			70,
			47,
			88,
			45,
			49,
			58,
			50,
			48,
			48,
			49
		};

		// Token: 0x0400226A RID: 8810
		private static byte[] by = new byte[]
		{
			80,
			68,
			70,
			47,
			88,
			45,
			49,
			97,
			58,
			50,
			48,
			48,
			49
		};

		// Token: 0x0400226B RID: 8811
		private static byte[] bz = new byte[]
		{
			80,
			68,
			70,
			47,
			88,
			45,
			51,
			58,
			50,
			48,
			48,
			51
		};

		// Token: 0x0400226C RID: 8812
		private static byte[] b0 = new byte[]
		{
			80,
			68,
			70,
			47,
			88,
			45,
			51,
			58,
			50,
			48,
			48,
			50
		};

		// Token: 0x0400226D RID: 8813
		private static byte[] b1 = new byte[]
		{
			80,
			68,
			70,
			47,
			88,
			45,
			50,
			58,
			50,
			48,
			48,
			51
		};

		// Token: 0x0400226E RID: 8814
		private static byte[] b2 = new byte[]
		{
			80,
			68,
			70,
			47,
			88,
			45,
			49,
			58,
			49,
			57,
			57,
			57
		};

		// Token: 0x0400226F RID: 8815
		private PdfXVersion b3 = PdfXVersion.None;

		// Token: 0x04002270 RID: 8816
		private Trapped b4 = Trapped.Unknown;

		// Token: 0x04002271 RID: 8817
		private OutputIntentList b5 = null;

		// Token: 0x04002272 RID: 8818
		private ab7 b6 = null;

		// Token: 0x04002273 RID: 8819
		private ab7 b7 = null;

		// Token: 0x04002274 RID: 8820
		private dn b8 = null;

		// Token: 0x04002275 RID: 8821
		private bool b9 = true;

		// Token: 0x04002276 RID: 8822
		private TagOptions ca = null;

		// Token: 0x04002277 RID: 8823
		private r2 cb;

		// Token: 0x04002278 RID: 8824
		private int cc = 0;

		// Token: 0x04002279 RID: 8825
		private bool cd = true;

		// Token: 0x0400227A RID: 8826
		private bool ce = false;

		// Token: 0x0400227B RID: 8827
		private bool cf = false;

		// Token: 0x0400227C RID: 8828
		private FormFlatteningOptions cg = null;

		// Token: 0x0400227D RID: 8829
		private DocumentOptimization ch = null;

		// Token: 0x0400227E RID: 8830
		private Hashtable ci = null;

		// Token: 0x0400227F RID: 8831
		internal CertifyingPermission cj;

		// Token: 0x04002280 RID: 8832
		private static byte[] ck = new byte[]
		{
			68,
			111,
			99,
			77,
			68,
			80
		};

		// Token: 0x04002281 RID: 8833
		private static byte[] cl = new byte[]
		{
			80,
			101,
			114,
			109,
			115
		};
	}
}
