using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ceTe.DynamicPDF.Merger.Forms;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006F8 RID: 1784
	public class PdfDocument
	{
		// Token: 0x06004530 RID: 17712 RVA: 0x00236C86 File Offset: 0x00235C86
		public PdfDocument(Stream stream) : this(aa9.a(stream), string.Empty)
		{
		}

		// Token: 0x06004531 RID: 17713 RVA: 0x00236C9C File Offset: 0x00235C9C
		public PdfDocument(byte[] data) : this(new agr(data), string.Empty)
		{
		}

		// Token: 0x06004532 RID: 17714 RVA: 0x00236CB2 File Offset: 0x00235CB2
		public PdfDocument(string filePath) : this(aa9.a(filePath), string.Empty)
		{
		}

		// Token: 0x06004533 RID: 17715 RVA: 0x00236CC8 File Offset: 0x00235CC8
		public PdfDocument(Stream stream, string password) : this(aa9.a(stream), password)
		{
		}

		// Token: 0x06004534 RID: 17716 RVA: 0x00236CDA File Offset: 0x00235CDA
		public PdfDocument(byte[] data, string password) : this(new agr(data), password)
		{
		}

		// Token: 0x06004535 RID: 17717 RVA: 0x00236CEC File Offset: 0x00235CEC
		public PdfDocument(string filePath, string password) : this(aa9.a(filePath), password)
		{
		}

		// Token: 0x06004536 RID: 17718 RVA: 0x00236D00 File Offset: 0x00235D00
		internal PdfDocument(aa9 A_0, string A_1)
		{
			this.a = null;
			this.b = null;
			this.c = null;
			this.d = null;
			this.e = null;
			this.f = null;
			this.g = Trapped.Unknown;
			this.h = false;
			this.j = null;
			this.k = 14;
			this.l = null;
			this.m = null;
			this.n = null;
			this.o = false;
			this.p = null;
			this.u = null;
			this.v = false;
			this.w = false;
			this.x = null;
			this.y = null;
			this.aa = false;
			this.ac = false;
			base..ctor();
			A_0.a(this);
			this.q = A_0;
			this.i = A_1;
			this.l();
		}

		// Token: 0x06004537 RID: 17719 RVA: 0x00236DD0 File Offset: 0x00235DD0
		internal PdfDocument(aa9 A_0, string A_1, bool A_2)
		{
			this.a = null;
			this.b = null;
			this.c = null;
			this.d = null;
			this.e = null;
			this.f = null;
			this.g = Trapped.Unknown;
			this.h = false;
			this.j = null;
			this.k = 14;
			this.l = null;
			this.m = null;
			this.n = null;
			this.o = false;
			this.p = null;
			this.u = null;
			this.v = false;
			this.w = false;
			this.x = null;
			this.y = null;
			this.aa = false;
			this.ac = false;
			base..ctor();
			A_0.a(this);
			this.q = A_0;
			this.i = A_1;
			this.k();
		}

		// Token: 0x06004538 RID: 17720 RVA: 0x00236EA0 File Offset: 0x00235EA0
		public PdfPage GetPage(int pageNumber)
		{
			return this.s[pageNumber - 1];
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06004539 RID: 17721 RVA: 0x00236EC0 File Offset: 0x00235EC0
		public PdfOutlineList Outlines
		{
			get
			{
				PdfOutlineList result;
				if (this.p == null)
				{
					result = null;
				}
				else
				{
					if (this.u == null)
					{
						this.u = new PdfOutlineList(this, this.p.a());
					}
					result = this.u;
				}
				return result;
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x0600453A RID: 17722 RVA: 0x00236F18 File Offset: 0x00235F18
		public string Title
		{
			get
			{
				this.a();
				return this.a;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x0600453B RID: 17723 RVA: 0x00236F38 File Offset: 0x00235F38
		public string Author
		{
			get
			{
				this.a();
				return this.b;
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x0600453C RID: 17724 RVA: 0x00236F58 File Offset: 0x00235F58
		public string Subject
		{
			get
			{
				this.a();
				return this.c;
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x0600453D RID: 17725 RVA: 0x00236F78 File Offset: 0x00235F78
		public string Keywords
		{
			get
			{
				this.a();
				return this.d;
			}
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x0600453E RID: 17726 RVA: 0x00236F98 File Offset: 0x00235F98
		public bool NeedsRendering
		{
			get
			{
				return this.n().l();
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x0600453F RID: 17727 RVA: 0x00236FB8 File Offset: 0x00235FB8
		public string Creator
		{
			get
			{
				this.a();
				return this.e;
			}
		}

		// Token: 0x06004540 RID: 17728 RVA: 0x00236FD8 File Offset: 0x00235FD8
		internal string d()
		{
			return this.i;
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06004541 RID: 17729 RVA: 0x00236FF0 File Offset: 0x00235FF0
		public bool Tagged
		{
			get
			{
				return this.v;
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06004542 RID: 17730 RVA: 0x00237008 File Offset: 0x00236008
		public bool Signed
		{
			get
			{
				this.c();
				return this.n != null && this.n.c();
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06004543 RID: 17731 RVA: 0x00237040 File Offset: 0x00236040
		public SecurityInfo SecurityInfo
		{
			get
			{
				SecurityInfo result;
				if (this.j == null)
				{
					result = SecurityInfo.None;
				}
				else
				{
					result = this.j.aq();
				}
				return result;
			}
		}

		// Token: 0x06004544 RID: 17732 RVA: 0x00237074 File Offset: 0x00236074
		public static EncryptionInfo GetEncryptionInfo(string filePath)
		{
			aa9 a_ = aa9.a(filePath);
			EncryptionInfo result;
			try
			{
				result = PdfDocument.a(a_);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		// Token: 0x06004545 RID: 17733 RVA: 0x002370AC File Offset: 0x002360AC
		public static EncryptionInfo GetEncryptionInfo(byte[] data)
		{
			agr a_ = new agr(data);
			EncryptionInfo result;
			try
			{
				result = PdfDocument.a(a_);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		// Token: 0x06004546 RID: 17734 RVA: 0x002370E4 File Offset: 0x002360E4
		internal static EncryptionInfo a(aa9 A_0)
		{
			EncryptionInfo encryptionInfo = new EncryptionInfo();
			EncryptionInfo result;
			try
			{
				PdfDocument pdfDocument = new PdfDocument(A_0, "", true);
				if (pdfDocument.g() != null)
				{
					encryptionInfo.a(pdfDocument.g().b());
					encryptionInfo.a(pdfDocument.g().aq());
				}
				result = encryptionInfo;
			}
			catch (Exception ex)
			{
				throw new MergerException("Problem in loading the PDF");
			}
			return result;
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06004547 RID: 17735 RVA: 0x00237164 File Offset: 0x00236164
		public string Producer
		{
			get
			{
				this.a();
				return this.f;
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06004548 RID: 17736 RVA: 0x00237184 File Offset: 0x00236184
		public string XmpMetadata
		{
			get
			{
				return this.t.h();
			}
		}

		// Token: 0x06004549 RID: 17737 RVA: 0x002371A4 File Offset: 0x002361A4
		internal List<Attachment> e()
		{
			return this.z;
		}

		// Token: 0x0600454A RID: 17738 RVA: 0x002371BC File Offset: 0x002361BC
		public Attachment[] Attachments()
		{
			Attachment[] result;
			if (this.aa)
			{
				result = this.z.ToArray();
			}
			else
			{
				aba aba = this.q.k8();
				this.z = new List<Attachment>();
				this.t.a(aba);
				for (int i = 1; i <= this.s.Count; i++)
				{
					PdfPage pdfPage = this.s[i - 1];
					if (pdfPage.j() != null && pdfPage.j().c() > 0)
					{
						pdfPage.a((abe)pdfPage.a().l().c().h6(), aba);
					}
				}
				this.aa = true;
				result = this.z.ToArray();
			}
			return result;
		}

		// Token: 0x0600454B RID: 17739 RVA: 0x002372A0 File Offset: 0x002362A0
		internal aa9 f()
		{
			this.a();
			return this.q;
		}

		// Token: 0x0600454C RID: 17740 RVA: 0x002372C0 File Offset: 0x002362C0
		internal b6 g()
		{
			return this.j;
		}

		// Token: 0x0600454D RID: 17741 RVA: 0x002372D8 File Offset: 0x002362D8
		internal void a(b6 A_0)
		{
			this.j = A_0;
		}

		// Token: 0x0600454E RID: 17742 RVA: 0x002372E4 File Offset: 0x002362E4
		private void c()
		{
			if (!this.o)
			{
				if (this.t.k() != null)
				{
					abd abd = this.t.k().h6();
					if (abd != null)
					{
						if (abd.hy() != ag9.i)
						{
							this.n = new PdfForm((abj)abd);
						}
					}
				}
				this.o = true;
			}
		}

		// Token: 0x0600454F RID: 17743 RVA: 0x00237358 File Offset: 0x00236358
		private void a(aba A_0)
		{
			if (this.t.j() != null)
			{
				this.ac = true;
				this.p = new ab4(A_0, (abj)this.t.j().h6());
				this.ac = false;
			}
		}

		// Token: 0x06004550 RID: 17744 RVA: 0x002373AC File Offset: 0x002363AC
		internal bool h()
		{
			return this.ac;
		}

		// Token: 0x06004551 RID: 17745 RVA: 0x002373C4 File Offset: 0x002363C4
		internal int a(ab7 A_0)
		{
			if (!this.w)
			{
				this.b();
			}
			string key = A_0.kf();
			int result;
			if (this.x.Contains(key))
			{
				result = (int)this.x[key];
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06004552 RID: 17746 RVA: 0x00237418 File Offset: 0x00236418
		internal Dictionary<string, c2> i()
		{
			if (this.y == null)
			{
				this.y = new Dictionary<string, c2>();
			}
			return this.y;
		}

		// Token: 0x06004553 RID: 17747 RVA: 0x00237450 File Offset: 0x00236450
		private void b()
		{
			if (!this.w)
			{
				abj abj = this.t.g();
				if (abj != null)
				{
					aba aba = this.q.k8();
					abj abj2 = null;
					for (abk abk = abj.l(); abk != null; abk = abk.d())
					{
						if (abk.a().j8() == 77020467)
						{
							abj2 = (abj)abk.c().h6();
							break;
						}
					}
					if (abj2 != null)
					{
						cc cc = new cc(aba, abj2);
						this.x = cc.a(this);
					}
					aba.lr();
				}
				this.w = true;
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06004554 RID: 17748 RVA: 0x0023751C File Offset: 0x0023651C
		public PdfForm Form
		{
			get
			{
				return this.n;
			}
		}

		// Token: 0x06004555 RID: 17749 RVA: 0x00237534 File Offset: 0x00236534
		internal ab4 j()
		{
			return this.p;
		}

		// Token: 0x06004556 RID: 17750 RVA: 0x0023754C File Offset: 0x0023654C
		public void SetDocumentInfo(Document document)
		{
			this.a();
			document.Title = this.a;
			document.Author = this.b;
			document.Subject = this.c;
			document.Keywords = this.d;
			document.Creator = this.e;
		}

		// Token: 0x06004557 RID: 17751 RVA: 0x002375A4 File Offset: 0x002365A4
		private void a()
		{
			if (!this.h)
			{
				if (this.r.e() != null)
				{
					abj abj = (abj)this.r.e().h6();
					if (abj != null)
					{
						for (abk abk = abj.l(); abk != null; abk = abk.d())
						{
							int num = abk.a().j8();
							if (num <= 281591879)
							{
								if (num <= 63591302)
								{
									if (num != 30886429)
									{
										if (num == 63591302)
										{
											abd abd = abk.c().h6();
											if (abd != null && abd.hy() == ag9.c)
											{
												this.e = ((ab7)abd).kf();
											}
											else
											{
												this.e = string.Empty;
											}
										}
									}
									else
									{
										abd abd = abk.c().h6();
										if (abd != null && abd.hy() == ag9.c)
										{
											this.b = ((ab7)abd).kf();
										}
										else
										{
											this.b = string.Empty;
										}
									}
								}
								else if (num != 194295004)
								{
									if (num == 281591879)
									{
										abd abd = abk.c().h6();
										if (abd != null && abd.hy() == ag9.c)
										{
											this.f = ((ab7)abd).kf();
										}
										else
										{
											this.f = string.Empty;
										}
									}
								}
								else
								{
									abd abd = abk.c().h6();
									if (abd != null && abd.hy() == ag9.c)
									{
										this.d = ((ab7)abd).kf();
									}
									else
									{
										this.d = string.Empty;
									}
								}
							}
							else if (num <= 346508069)
							{
								if (num != 332800593)
								{
									if (num == 346508069)
									{
										abd abd = abk.c().h6();
										if (abd != null)
										{
											if (abd.hy() == ag9.c)
											{
												this.a = ((ab7)abd).kf();
											}
											else if (abd.hy() == ag9.d)
											{
												this.a = ((abu)abd).j9();
											}
											else
											{
												this.a = string.Empty;
											}
										}
										else
										{
											this.a = string.Empty;
										}
									}
								}
								else
								{
									abd abd = abk.c().h6();
									if (abd != null && abd.hy() == ag9.c)
									{
										this.c = ((ab7)abd).kf();
									}
									else
									{
										this.c = string.Empty;
									}
								}
							}
							else if (num != 348788052)
							{
								if (num != 760521591)
								{
									if (num == 830876059)
									{
										this.l = (ab7)abk.c().h6();
									}
								}
								else
								{
									this.m = (ab7)abk.c().h6();
								}
							}
							else
							{
								this.g = this.a(abk.c().h6());
							}
						}
					}
				}
				this.h = true;
			}
		}

		// Token: 0x06004558 RID: 17752 RVA: 0x002378EC File Offset: 0x002368EC
		private Trapped a(abd A_0)
		{
			Trapped result;
			if (A_0.hy() == ag9.d)
			{
				abu abu = (abu)A_0;
				int num = abu.j8();
				if (num != 5451109)
				{
					if (num != 109497573)
					{
						result = Trapped.Unknown;
					}
					else
					{
						result = Trapped.False;
					}
				}
				else
				{
					result = Trapped.True;
				}
			}
			else
			{
				if (A_0.hy() == ag9.c)
				{
					string text = ((ab7)A_0).kf().ToLower();
					if (text == "false")
					{
						return Trapped.False;
					}
					if (text == "true")
					{
						return Trapped.True;
					}
				}
				result = Trapped.Unknown;
			}
			return result;
		}

		// Token: 0x06004559 RID: 17753 RVA: 0x0023798E File Offset: 0x0023698E
		internal void a(int A_0)
		{
			this.k = A_0;
		}

		// Token: 0x0600455A RID: 17754 RVA: 0x00237998 File Offset: 0x00236998
		internal void a(MergeDocument A_0)
		{
			if (this.k < 14)
			{
				A_0.PdfVersion = PdfVersion.v1_3;
			}
			else if (this.k > 16)
			{
				A_0.PdfVersion = PdfVersion.v1_7;
			}
			else
			{
				A_0.PdfVersion = (PdfVersion)this.k;
			}
			this.t.e(A_0);
		}

		// Token: 0x0600455B RID: 17755 RVA: 0x002379F8 File Offset: 0x002369F8
		internal void b(MergeDocument A_0)
		{
			A_0.Trapped = this.g;
			this.t.a(A_0, this.l, this.m);
		}

		// Token: 0x0600455C RID: 17756 RVA: 0x00237A24 File Offset: 0x00236A24
		internal void k()
		{
			aba aba = this.q.k8();
			this.r = new abt(this);
			this.r.a(true);
			aba.lb();
			if (aba != null)
			{
				aba.lr();
			}
		}

		// Token: 0x0600455D RID: 17757 RVA: 0x00237A70 File Offset: 0x00236A70
		internal void l()
		{
			aba aba = null;
			try
			{
				aba = this.q.k8();
				this.r = new abt(this);
				aba.lb();
				if (this.r.c() - 1 > this.r.f() && this.r.g() == 1)
				{
					int num = this.r.h();
					for (int i = 0; i < this.r.c(); i++)
					{
						if (this.r.b((long)i) != null)
						{
							this.r.b((long)i).a(this.r.b((long)i).l() - num);
							this.r.a(this.r.b((long)i).l(), this.r.b((long)i));
						}
					}
				}
				this.t = new abl(aba, this.r.d(), this);
				abj abj = this.t.e();
				if (abj != null)
				{
					string text = "";
					bool flag = false;
					for (abk abk = abj.l(); abk != null; abk = abk.d())
					{
						int num2 = abk.a().j8();
						if (num2 == 226962113)
						{
							if (abk.c().hy() == ag9.a)
							{
								flag = ((abf)abk.c()).a();
							}
							else
							{
								text = ((abu)abk.c()).j9();
							}
							if ((flag || text == "true") && this.t.d() != null)
							{
								this.v = true;
							}
						}
					}
				}
				this.s = new PdfPageList(this);
				this.a();
				this.a(aba);
				this.c();
			}
			catch (PdfSecurityException ex)
			{
				throw ex;
			}
			catch (PdfParsingException ex2)
			{
				throw ex2;
			}
			catch (OutOfMemoryException ex3)
			{
				throw ex3;
			}
			catch (Exception a_)
			{
				throw new PdfParsingException("There was an error while parsing the PDF file. The PDF is likely corrupt or invalid.", a_);
			}
			finally
			{
				if (aba != null)
				{
					aba.lr();
				}
			}
		}

		// Token: 0x0600455E RID: 17758 RVA: 0x00237D40 File Offset: 0x00236D40
		internal abt m()
		{
			return this.r;
		}

		// Token: 0x0600455F RID: 17759 RVA: 0x00237D58 File Offset: 0x00236D58
		internal abl n()
		{
			return this.t;
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06004560 RID: 17760 RVA: 0x00237D70 File Offset: 0x00236D70
		// (set) Token: 0x06004561 RID: 17761 RVA: 0x00237D88 File Offset: 0x00236D88
		public CollectionType CollectionType
		{
			get
			{
				return this.ab;
			}
			set
			{
				this.ab = value;
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06004562 RID: 17762 RVA: 0x00237D94 File Offset: 0x00236D94
		public PdfPageList Pages
		{
			get
			{
				return this.s;
			}
		}

		// Token: 0x06004563 RID: 17763 RVA: 0x00237DAC File Offset: 0x00236DAC
		public string GetText()
		{
			StringBuilder stringBuilder = new StringBuilder();
			dg dg = new dg(this.s.Count);
			for (int i = 0; i < this.s.Count; i++)
			{
				this.s[i].a(dg.a()[i]);
				string[] a_ = this.s[i].u();
				if (this.s[i].k() != null)
				{
					abj a_2 = this.s[i].k().c();
					dg.a(a_, a_2, this.s[i].r(), i);
				}
				if (this.s[i].w().Count > 0)
				{
					foreach (object obj in this.s[i].w())
					{
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
						dg.a(this.s[i].v(), (abj)dictionaryEntry.Value, dictionaryEntry.Key.ToString(), i);
					}
				}
				byte[] contents = this.s[i].GetContents();
				if (contents != null)
				{
					this.s[i].a(contents, dg.a()[i], dg.c(), dg.b(), i, null);
				}
			}
			for (int i = 0; i < this.s.Count; i++)
			{
				stringBuilder.Append(dg.a(i, -1f, -1f, -1f, -1f));
				stringBuilder.AppendLine();
			}
			string result;
			if (aae.c(13))
			{
				result = stringBuilder.ToString();
			}
			else
			{
				string value = "[DynamicPDF Evaluation] ";
				stringBuilder.Insert(0, value);
				if (stringBuilder.Length < 256)
				{
					stringBuilder.Append(" [Please purchase a license or contact support for an evaluation license.]");
					result = stringBuilder.ToString();
				}
				else
				{
					int num = 280;
					stringBuilder.Remove(num, stringBuilder.Length - num);
					stringBuilder.Append(" ....[Text Truncated - Please purchase a license or contact support for an evaluation license.]");
					result = stringBuilder.ToString();
				}
			}
			return result;
		}

		// Token: 0x0400266A RID: 9834
		private string a;

		// Token: 0x0400266B RID: 9835
		private string b;

		// Token: 0x0400266C RID: 9836
		private string c;

		// Token: 0x0400266D RID: 9837
		private string d;

		// Token: 0x0400266E RID: 9838
		private string e;

		// Token: 0x0400266F RID: 9839
		private string f;

		// Token: 0x04002670 RID: 9840
		private Trapped g;

		// Token: 0x04002671 RID: 9841
		private bool h;

		// Token: 0x04002672 RID: 9842
		private string i;

		// Token: 0x04002673 RID: 9843
		private b6 j;

		// Token: 0x04002674 RID: 9844
		private int k;

		// Token: 0x04002675 RID: 9845
		private ab7 l;

		// Token: 0x04002676 RID: 9846
		private ab7 m;

		// Token: 0x04002677 RID: 9847
		private PdfForm n;

		// Token: 0x04002678 RID: 9848
		private bool o;

		// Token: 0x04002679 RID: 9849
		private ab4 p;

		// Token: 0x0400267A RID: 9850
		private aa9 q;

		// Token: 0x0400267B RID: 9851
		private abt r;

		// Token: 0x0400267C RID: 9852
		private PdfPageList s;

		// Token: 0x0400267D RID: 9853
		private abl t;

		// Token: 0x0400267E RID: 9854
		private PdfOutlineList u;

		// Token: 0x0400267F RID: 9855
		private bool v;

		// Token: 0x04002680 RID: 9856
		private bool w;

		// Token: 0x04002681 RID: 9857
		private Hashtable x;

		// Token: 0x04002682 RID: 9858
		private Dictionary<string, c2> y;

		// Token: 0x04002683 RID: 9859
		private List<Attachment> z;

		// Token: 0x04002684 RID: 9860
		private bool aa;

		// Token: 0x04002685 RID: 9861
		private CollectionType ab;

		// Token: 0x04002686 RID: 9862
		private bool ac;
	}
}
