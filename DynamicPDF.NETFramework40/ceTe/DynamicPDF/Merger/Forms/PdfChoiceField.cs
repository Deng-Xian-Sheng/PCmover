using System;
using System.Collections;
using ceTe.DynamicPDF.Forms;
using zz93;

namespace ceTe.DynamicPDF.Merger.Forms
{
	// Token: 0x02000700 RID: 1792
	public class PdfChoiceField : PdfFormField
	{
		// Token: 0x0600460E RID: 17934 RVA: 0x0023CEAC File Offset: 0x0023BEAC
		internal PdfChoiceField(PdfForm A_0, int A_1, PdfFormField A_2, abj A_3) : base(A_0, A_1, A_2, A_3)
		{
			for (abk abk = A_3.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 9)
				{
					if (num == 64564)
					{
						this.a = (abe)abk.c().h6();
					}
				}
				else
				{
					this.c = abk;
					abk.a(false);
				}
			}
		}

		// Token: 0x0600460F RID: 17935 RVA: 0x0023CF40 File Offset: 0x0023BF40
		internal void a()
		{
			if (this.b == null)
			{
				this.b = new Hashtable();
				if (this.a != null)
				{
					for (int i = 0; i < this.a.a(); i++)
					{
						if (this.a.a(i).hy() == ag9.c)
						{
							aah aah = new aah(i, (ab7)this.a.a(i));
							this.b.Add(aah.b().kf(), aah);
						}
						else if (this.a.a(i).hy() == ag9.e)
						{
							abe abe = (abe)this.a.a(i);
							aah aah = new aah(i, (ab7)abe.a(0));
							this.b.Add(aah.b().kf(), aah);
						}
					}
				}
			}
		}

		// Token: 0x06004610 RID: 17936 RVA: 0x0023D04C File Offset: 0x0023C04C
		private aah a(string A_0)
		{
			object obj = this.b[A_0];
			aah result;
			if (obj == null)
			{
				result = null;
			}
			else
			{
				result = (aah)obj;
			}
			return result;
		}

		// Token: 0x06004611 RID: 17937 RVA: 0x0023D080 File Offset: 0x0023C080
		internal aah[] a(string[] A_0)
		{
			aah[] result;
			if (A_0.Length >= 2 || this.b != null)
			{
				this.a();
				aah[] array = new aah[A_0.Length];
				int num = 0;
				for (int i = 0; i < A_0.Length; i++)
				{
					object obj = this.b[A_0[i]];
					if (obj != null)
					{
						array[num++] = (aah)obj;
					}
				}
				if (array[0] == null)
				{
					result = new aah[0];
				}
				else
				{
					result = array;
				}
			}
			else
			{
				if (A_0.Length == 1)
				{
					for (int i = 0; i < this.a.a(); i++)
					{
						if (this.a.a(i).hy() == ag9.c)
						{
							if (((ab7)this.a.a(i)).kf() == A_0[0])
							{
								return new aah[]
								{
									new aah(i, (ab7)this.a.a(i))
								};
							}
						}
						else if (this.a.a(i).hy() == ag9.e)
						{
							abe abe = (abe)this.a.a(i);
							if (((ab7)abe.a(0)).kf() == A_0[0])
							{
								return new aah[]
								{
									new aah(i, (ab7)abe.a(0))
								};
							}
						}
					}
				}
				result = new aah[0];
			}
			return result;
		}

		// Token: 0x06004612 RID: 17938 RVA: 0x0023D24C File Offset: 0x0023C24C
		internal ab7 b(string A_0)
		{
			if (this.a != null)
			{
				if (this.b != null)
				{
					aah aah = this.a(A_0);
					if (aah == null)
					{
						return null;
					}
					return aah.b();
				}
				else
				{
					for (int i = 0; i < this.a.a(); i++)
					{
						if (this.a.a(i).hy() == ag9.c)
						{
							if (((ab7)this.a.a(i)).kf() == A_0)
							{
								return (ab7)this.a.a(i);
							}
						}
						else if (this.a.a(i).hy() == ag9.e)
						{
							abe abe = (abe)this.a.a(i);
							if (((ab7)abe.a(0)).kf() == A_0)
							{
								return (ab7)abe.a(1);
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06004613 RID: 17939 RVA: 0x0023D390 File Offset: 0x0023C390
		public string[] GetItems()
		{
			string[] result;
			if (this.a != null)
			{
				string[] array = new string[this.a.a()];
				for (int i = 0; i < this.a.a(); i++)
				{
					abd abd = this.a.a(i);
					if (abd.hy() == ag9.c)
					{
						array[i] = ((ab7)abd).kf();
					}
					else if (abd.hy() == ag9.e)
					{
						abe abe = (abe)abd;
						array[i] = ((ab7)abe.a(1)).kf();
					}
				}
				result = array;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06004614 RID: 17940 RVA: 0x0023D450 File Offset: 0x0023C450
		public string[] GetItemsExportValues()
		{
			string[] result;
			if (this.a != null)
			{
				string[] array = new string[this.a.a()];
				for (int i = 0; i < this.a.a(); i++)
				{
					abd abd = this.a.a(i);
					if (abd.hy() == ag9.e)
					{
						abe abe = (abe)abd;
						array[i] = ((ab7)abe.a(0)).kf();
					}
				}
				result = array;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06004615 RID: 17941 RVA: 0x0023D4E8 File Offset: 0x0023C4E8
		public override Font Font
		{
			get
			{
				if (base.Font == null && base.i() != null)
				{
					this.a(base.s());
				}
				return base.Font;
			}
		}

		// Token: 0x06004616 RID: 17942 RVA: 0x0023D528 File Offset: 0x0023C528
		public string[] GetValues()
		{
			string[] result;
			if (base.u() == null)
			{
				result = new string[]
				{
					string.Empty
				};
			}
			else
			{
				abd abd = base.u();
				if (abd.hy() == ag9.c)
				{
					result = new string[]
					{
						((ab7)abd).kf()
					};
				}
				else
				{
					abe abe = (abe)abd;
					string[] array = new string[abe.a()];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = ((ab7)abe.a(i)).kf();
					}
					result = array;
				}
			}
			return result;
		}

		// Token: 0x06004617 RID: 17943 RVA: 0x0023D5DC File Offset: 0x0023C5DC
		public override string GetValue()
		{
			string result;
			if (base.u() == null)
			{
				result = base.GetValue();
			}
			else
			{
				abd abd = base.u();
				if (abd.hy() == ag9.c)
				{
					result = ((ab7)abd).kf();
				}
				else
				{
					abe abe = (abe)abd;
					string text = string.Empty;
					for (int i = 0; i < abe.a(); i++)
					{
						if (i > 0)
						{
							text += ",";
						}
						text += ((ab7)abe.a(i)).kf();
					}
					result = text;
				}
			}
			return result;
		}

		// Token: 0x06004618 RID: 17944 RVA: 0x0023D690 File Offset: 0x0023C690
		public string[] GetDefaultValues()
		{
			string[] result;
			if (base.v() == null)
			{
				result = new string[]
				{
					string.Empty
				};
			}
			else
			{
				abd abd = base.v();
				if (abd.hy() == ag9.c)
				{
					result = new string[]
					{
						((ab7)abd).kf()
					};
				}
				else
				{
					abe abe = (abe)abd;
					string[] array = new string[abe.a()];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = ((ab7)abe.a(i)).kf();
					}
					result = array;
				}
			}
			return result;
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06004619 RID: 17945 RVA: 0x0023D744 File Offset: 0x0023C744
		public override string ExportValue
		{
			get
			{
				if (this.b == null)
				{
					this.a();
				}
				string value = this.GetValue();
				string result;
				if (this.b.ContainsKey(value))
				{
					result = value;
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x0600461A RID: 17946 RVA: 0x0023D790 File Offset: 0x0023C790
		public override string[] ExportValues
		{
			get
			{
				if (this.b == null)
				{
					this.a();
				}
				string[] values = this.GetValues();
				string[] array = new string[values.Length];
				int num = 0;
				for (int i = 0; i < values.Length; i++)
				{
					if (this.b.ContainsKey(values[i]))
					{
						array[num++] = values[i];
					}
				}
				return array;
			}
		}

		// Token: 0x0600461B RID: 17947 RVA: 0x0023D80C File Offset: 0x0023C80C
		public override string GetDefaultValue()
		{
			string result;
			if (base.v() == null)
			{
				result = base.GetDefaultValue();
			}
			else
			{
				abd abd = base.v();
				if (abd.hy() == ag9.c)
				{
					result = ((ab7)abd).kf();
				}
				else
				{
					abe abe = (abe)abd;
					string text = string.Empty;
					for (int i = 0; i < abe.a(); i++)
					{
						if (i > 0)
						{
							text += ",";
						}
						text += ((ab7)abe.a(i)).kf();
					}
					result = text;
				}
			}
			return result;
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x0600461C RID: 17948 RVA: 0x0023D8C0 File Offset: 0x0023C8C0
		public override bool Combo
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.Combo);
				}
				else
				{
					result = ((base.m() & 131072) == 131072);
				}
				return result;
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x0600461D RID: 17949 RVA: 0x0023D918 File Offset: 0x0023C918
		public override bool Edit
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.Edit);
				}
				else
				{
					result = ((base.m() & 262144) == 262144);
				}
				return result;
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x0600461E RID: 17950 RVA: 0x0023D970 File Offset: 0x0023C970
		public override bool Sort
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.Sort);
				}
				else
				{
					result = ((base.m() & 524288) == 524288);
				}
				return result;
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x0600461F RID: 17951 RVA: 0x0023D9C8 File Offset: 0x0023C9C8
		public override bool DoNotSpellCheck
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.DoNotSpellCheck);
				}
				else
				{
					result = ((base.m() & 4194304) == 4194304);
				}
				return result;
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06004620 RID: 17952 RVA: 0x0023DA20 File Offset: 0x0023CA20
		public override bool CommitOnSelChange
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.CommitOnSelChange);
				}
				else
				{
					result = ((base.m() & 67108864) == 67108864);
				}
				return result;
			}
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06004621 RID: 17953 RVA: 0x0023DA78 File Offset: 0x0023CA78
		public override bool MultiSelect
		{
			get
			{
				bool result;
				if (base.n() == null)
				{
					result = (base.Parent != null && base.Parent.MultiSelect);
				}
				else
				{
					result = ((base.m() & 2097152) == 2097152);
				}
				return result;
			}
		}

		// Token: 0x06004622 RID: 17954 RVA: 0x0023DAD0 File Offset: 0x0023CAD0
		internal abe b()
		{
			return this.a;
		}

		// Token: 0x06004623 RID: 17955 RVA: 0x0023DAE8 File Offset: 0x0023CAE8
		internal abk c()
		{
			return this.c;
		}

		// Token: 0x06004624 RID: 17956 RVA: 0x0023DB00 File Offset: 0x0023CB00
		internal override FormField hm(int A_0)
		{
			FormField result;
			if ((base.Flags & FormFieldFlags.Combo) == FormFieldFlags.Combo)
			{
				result = new aak(this, A_0);
			}
			else
			{
				result = new aam(this, A_0);
			}
			return result;
		}

		// Token: 0x06004625 RID: 17957 RVA: 0x0023DB40 File Offset: 0x0023CB40
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
										break;
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

		// Token: 0x040026CF RID: 9935
		private new abe a = null;

		// Token: 0x040026D0 RID: 9936
		private Hashtable b = null;

		// Token: 0x040026D1 RID: 9937
		private new abk c = null;
	}
}
