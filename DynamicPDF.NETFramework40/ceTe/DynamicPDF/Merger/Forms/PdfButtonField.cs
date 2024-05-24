using System;
using ceTe.DynamicPDF.Forms;
using zz93;

namespace ceTe.DynamicPDF.Merger.Forms
{
	// Token: 0x020006FF RID: 1791
	public class PdfButtonField : PdfFormField
	{
		// Token: 0x060045FB RID: 17915 RVA: 0x0023C3EC File Offset: 0x0023B3EC
		internal PdfButtonField(PdfForm A_0, int A_1, PdfFormField A_2, abj A_3) : base(A_0, A_1, A_2, A_3)
		{
			for (abk abk = A_3.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 80)
				{
					if (num == 64564)
					{
						this.a = abk.c();
					}
				}
				else
				{
					this.b = (abj)abk.c().h6();
				}
			}
			if (base.x() != null)
			{
				for (abk abk = base.x().l(); abk != null; abk = abk.d())
				{
					if (abk.a().j9() == "CA")
					{
						if (abk.c().hy() == ag9.c)
						{
							this.e = (ab7)abk.c();
						}
					}
				}
			}
		}

		// Token: 0x060045FC RID: 17916 RVA: 0x0023C504 File Offset: 0x0023B504
		internal abu e()
		{
			this.d();
			return this.c;
		}

		// Token: 0x060045FD RID: 17917 RVA: 0x0023C524 File Offset: 0x0023B524
		internal string f()
		{
			string result;
			if (this.e != null)
			{
				result = this.e.kf();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060045FE RID: 17918 RVA: 0x0023C554 File Offset: 0x0023B554
		private void b(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 63910)
				{
					this.c = abk.a();
					break;
				}
			}
		}

		// Token: 0x060045FF RID: 17919 RVA: 0x0023C5A8 File Offset: 0x0023B5A8
		private void d()
		{
			if (this.c == null)
			{
				if (this.b != null)
				{
					for (abk abk = this.b.l(); abk != null; abk = abk.d())
					{
						int num = abk.a().j8();
						if (num == 14)
						{
							this.b((abj)abk.c().h6());
							break;
						}
					}
				}
			}
		}

		// Token: 0x06004600 RID: 17920 RVA: 0x0023C624 File Offset: 0x0023B624
		internal aaq a(string A_0)
		{
			A_0 = A_0.Replace(" ", "#20");
			if (this.a != null)
			{
				if (this.a.hy() == ag9.c && ((ab7)this.a).kf() == A_0)
				{
					return new aaq(this.e(), (ab7)this.a);
				}
				if (this.a.hy() == ag9.e)
				{
					abe abe = (abe)this.a;
					int i = 0;
					while (i < abe.a())
					{
						if (((ab7)abe.a(i)).kf() == A_0)
						{
							if (base.ChildFields != null)
							{
								return new aaq(((PdfButtonField)base.ChildFields[i]).e(), (ab7)abe.a(i));
							}
							return new aaq(this.e(), (ab7)abe.a(i));
						}
						else
						{
							i++;
						}
					}
					return null;
				}
			}
			if (base.HasChildFields)
			{
				for (int i = 0; i < base.ChildFields.Count; i++)
				{
					PdfButtonField pdfButtonField = (PdfButtonField)base.ChildFields[i];
					if (pdfButtonField.e() != null && pdfButtonField.e().j9() == A_0)
					{
						return new aaq(pdfButtonField.e());
					}
				}
			}
			aaq result;
			if (this.e() != null && this.e().j9() == A_0)
			{
				result = new aaq(this.e());
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06004601 RID: 17921 RVA: 0x0023C81C File Offset: 0x0023B81C
		public override string GetDefaultValue()
		{
			string result;
			if (base.v() == null)
			{
				result = base.GetDefaultValue();
			}
			else if (((abu)base.v()).j8() == 63910)
			{
				result = string.Empty;
			}
			else if (this.a == null)
			{
				result = ((abu)base.v()).j9();
			}
			else
			{
				result = this.a();
			}
			return result;
		}

		// Token: 0x06004602 RID: 17922 RVA: 0x0023C898 File Offset: 0x0023B898
		public override string GetValue()
		{
			string result;
			if (base.u() == null)
			{
				result = base.GetValue();
			}
			else if (((abu)base.u()).j8() == 63910)
			{
				result = string.Empty;
			}
			else if (this.a == null)
			{
				result = ((abu)base.u()).j9();
			}
			else
			{
				result = this.b();
			}
			return result;
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06004603 RID: 17923 RVA: 0x0023C914 File Offset: 0x0023B914
		public override string ExportValue
		{
			get
			{
				int num = (int)(base.Flags & (FormFieldFlags)98304);
				string empty;
				if (num != 65536)
				{
					if (this.d == null || this.d == string.Empty)
					{
						this.c();
					}
					empty = this.d;
				}
				else
				{
					empty = string.Empty;
				}
				return empty;
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06004604 RID: 17924 RVA: 0x0023C978 File Offset: 0x0023B978
		public override bool NoToggleToOff
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.NoToggleToOff);
				}
				else
				{
					result = ((base.m() & 16384) == 16384);
				}
				return result;
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06004605 RID: 17925 RVA: 0x0023C9D0 File Offset: 0x0023B9D0
		public override bool Radio
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.Radio);
				}
				else
				{
					result = ((base.m() & 32768) == 32768);
				}
				return result;
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06004606 RID: 17926 RVA: 0x0023CA28 File Offset: 0x0023BA28
		public override bool Pushbutton
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.Pushbutton);
				}
				else
				{
					result = ((base.m() & 65536) == 65536);
				}
				return result;
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06004607 RID: 17927 RVA: 0x0023CA80 File Offset: 0x0023BA80
		public override bool RadiosInUnison
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.RadiosInUnison);
				}
				else
				{
					result = ((base.m() & 33554432) == 33554432);
				}
				return result;
			}
		}

		// Token: 0x06004608 RID: 17928 RVA: 0x0023CAD8 File Offset: 0x0023BAD8
		private void c()
		{
			if (base.s() != null)
			{
				for (abk abk = base.s().l(); abk != null; abk = abk.d())
				{
					int num = abk.a().j8();
					if (num == 14)
					{
						abj abj = (abj)abk.c().h6();
						abk abk2 = abj.l();
						this.d = abk2.a().j9();
						if (this.d.Contains("Off"))
						{
							abk2 = abk2.d();
							this.d = abk2.a().j9();
						}
					}
				}
			}
		}

		// Token: 0x06004609 RID: 17929 RVA: 0x0023CB90 File Offset: 0x0023BB90
		private string b()
		{
			string result;
			if (base.HasChildFields)
			{
				abe abe = (abe)this.a;
				int a_ = ((abu)base.u()).kc();
				result = ((ab7)abe.a(a_)).kf();
			}
			else if (this.a.hy() == ag9.c)
			{
				result = ((ab7)this.a).kf();
			}
			else
			{
				result = ((ab7)((abe)this.a).a(0)).kf();
			}
			return result;
		}

		// Token: 0x0600460A RID: 17930 RVA: 0x0023CC28 File Offset: 0x0023BC28
		private string a()
		{
			string result;
			if (base.HasChildFields)
			{
				abe abe = (abe)this.a;
				int a_ = ((abu)base.v()).kc();
				result = ((ab7)abe.a(a_)).kf();
			}
			else if (this.a.hy() == ag9.c)
			{
				result = ((ab7)this.a).kf();
			}
			else
			{
				result = ((ab7)((abe)this.a).a(0)).kf();
			}
			return result;
		}

		// Token: 0x0600460B RID: 17931 RVA: 0x0023CCC0 File Offset: 0x0023BCC0
		internal override FormField hm(int A_0)
		{
			int num = (int)(base.Flags & (FormFieldFlags)98304);
			FormField result;
			if (num != 32768)
			{
				if (num != 65536)
				{
					result = new aaj(this, A_0);
				}
				else
				{
					result = new aai(this, A_0);
				}
			}
			else
			{
				result = new aan(this, A_0);
			}
			return result;
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x0600460C RID: 17932 RVA: 0x0023CD0C File Offset: 0x0023BD0C
		public override Font Font
		{
			get
			{
				if (base.Font == null)
				{
					this.a(base.s());
				}
				return base.Font;
			}
		}

		// Token: 0x0600460D RID: 17933 RVA: 0x0023CD44 File Offset: 0x0023BD44
		private void a(abj A_0)
		{
			if (A_0 != null)
			{
				if (base.Font == null)
				{
					for (abk abk = A_0.l(); abk != null; abk = abk.d())
					{
						int num = abk.a().j8();
						if (num != 14)
						{
							if (num != 1768372)
							{
								if (num == 308085382)
								{
									this.a((abj)abk.c().h6());
								}
							}
							else if (base.Font == null)
							{
								abj abj = (abj)abk.c().h6();
								for (abk abk2 = abj.l(); abk2 != null; abk2 = abk2.d())
								{
									if (abk2.c().hy() == ag9.j)
									{
										c2 c = new c2(abk2.c());
										base.Font = c;
										base.Form.a(abk2.a().j9(), c);
									}
								}
							}
						}
						else
						{
							this.a((abj)abk.c().h6());
						}
					}
				}
			}
			if (base.Font == null)
			{
				base.Font = Font.Helvetica;
			}
		}

		// Token: 0x040026CA RID: 9930
		private new abd a = null;

		// Token: 0x040026CB RID: 9931
		private abj b = null;

		// Token: 0x040026CC RID: 9932
		private new abu c = null;

		// Token: 0x040026CD RID: 9933
		private string d = string.Empty;

		// Token: 0x040026CE RID: 9934
		private ab7 e = null;
	}
}
