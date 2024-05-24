using System;
using System.Collections;
using System.Collections.Specialized;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020002B2 RID: 690
	internal class r2 : Resource
	{
		// Token: 0x06001FB3 RID: 8115 RVA: 0x00139220 File Offset: 0x00138220
		internal r2() : base(Resource.NewUid())
		{
		}

		// Token: 0x06001FB4 RID: 8116 RVA: 0x001392C8 File Offset: 0x001382C8
		public override int get_RequiredPdfObjects()
		{
			return ((this.t != null) ? this.t.Count : 0) + ((this.aa != null) ? 1 : 0) + 1 + (this.z ? (this.ae.Count + 1) : 0);
		}

		// Token: 0x06001FB5 RID: 8117 RVA: 0x0013931C File Offset: 0x0013831C
		internal new int c()
		{
			return this.u;
		}

		// Token: 0x06001FB6 RID: 8118 RVA: 0x00139334 File Offset: 0x00138334
		internal new bool e()
		{
			return this.w;
		}

		// Token: 0x06001FB7 RID: 8119 RVA: 0x0013934C File Offset: 0x0013834C
		internal new void a(bool A_0)
		{
			this.w = A_0;
		}

		// Token: 0x06001FB8 RID: 8120 RVA: 0x00139356 File Offset: 0x00138356
		internal new void a(int A_0, int A_1)
		{
			this.q.a(new r2.a(A_1), A_0);
		}

		// Token: 0x06001FB9 RID: 8121 RVA: 0x0013936C File Offset: 0x0013836C
		internal new void a(int A_0, int A_1, bool A_2)
		{
			this.q.a(new r2.a(A_1, A_2), A_0);
		}

		// Token: 0x06001FBA RID: 8122 RVA: 0x00139384 File Offset: 0x00138384
		internal new int a(int A_0)
		{
			return this.q.a(A_0).a();
		}

		// Token: 0x06001FBB RID: 8123 RVA: 0x001393A7 File Offset: 0x001383A7
		internal new void a(int A_0, int A_1, StructureElement A_2)
		{
			this.q.a(A_0).c().a(A_1, A_2);
		}

		// Token: 0x06001FBC RID: 8124 RVA: 0x001393C4 File Offset: 0x001383C4
		internal new StructureElement b(int A_0, int A_1)
		{
			return this.q.a(A_0).c().c(A_1);
		}

		// Token: 0x06001FBD RID: 8125 RVA: 0x001393F0 File Offset: 0x001383F0
		internal new HybridDictionary f()
		{
			return this.s;
		}

		// Token: 0x06001FBE RID: 8126 RVA: 0x00139408 File Offset: 0x00138408
		internal new q2 i()
		{
			return this.q;
		}

		// Token: 0x06001FBF RID: 8127 RVA: 0x00139420 File Offset: 0x00138420
		internal bool j()
		{
			return this.v;
		}

		// Token: 0x06001FC0 RID: 8128 RVA: 0x00139438 File Offset: 0x00138438
		internal new void b(bool A_0)
		{
			this.v = A_0;
		}

		// Token: 0x06001FC1 RID: 8129 RVA: 0x00139444 File Offset: 0x00138444
		internal int k()
		{
			return this.ag;
		}

		// Token: 0x06001FC2 RID: 8130 RVA: 0x0013945C File Offset: 0x0013845C
		internal new void e(StructureElement A_0)
		{
			if (A_0.Identifier != null && this.aa == null)
			{
				this.aa = new ArrayList(10);
			}
			if (A_0.Parent == null)
			{
				if (A_0.bt())
				{
					if (!this.s.Contains(A_0))
					{
						this.s.Add(A_0, A_0);
						this.r.a(new cy(A_0.Order, this.r.b(), A_0));
						if (A_0.TagType != null && A_0.TagType.b3())
						{
							this.d(A_0);
						}
						if (A_0.q() != null)
						{
							this.a(A_0.q());
						}
					}
				}
			}
			else if (A_0.bt())
			{
				this.f(A_0);
			}
		}

		// Token: 0x06001FC3 RID: 8131 RVA: 0x00139558 File Offset: 0x00138558
		internal new void f(StructureElement A_0)
		{
			StructureElement parent = A_0.Parent;
			if (!this.s.Contains(A_0))
			{
				this.s.Add(A_0, A_0);
				if (A_0.TagType != null && A_0.TagType.b3())
				{
					this.d(A_0);
				}
				if (A_0.q() != null)
				{
					this.a(A_0.q());
				}
				parent.n().a(new cy(A_0.Order, parent.n().b(), A_0));
			}
			if (!this.s.Contains(parent) && parent.bt())
			{
				this.e(parent);
			}
		}

		// Token: 0x06001FC4 RID: 8132 RVA: 0x0013961C File Offset: 0x0013861C
		private new void d(StructureElement A_0)
		{
			if (this.p == null)
			{
				this.p = new HybridDictionary(3);
			}
			NamedTagType namedTagType = (NamedTagType)A_0.TagType;
			object obj = this.p[namedTagType.Name];
			if (obj == null)
			{
				this.p.Add(namedTagType.Name, namedTagType.TagType);
			}
			else if ((TagType)obj != namedTagType.TagType)
			{
				string text;
				do
				{
					text = namedTagType.Name + "+" + ++this.ad;
				}
				while (this.p.Contains(text));
				namedTagType.a(text);
				A_0.a(namedTagType);
				this.p.Add(text, namedTagType.TagType);
			}
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x00139700 File Offset: 0x00138700
		internal new static cu[] a(cu[] A_0, int A_1)
		{
			for (int i = 0; i < A_1; i++)
			{
				for (int j = i + 1; j < A_1; j++)
				{
					if (A_0[i].b() == A_0[j].b())
					{
						if (A_0[i].c() > A_0[j].c())
						{
							cu cu = A_0[i];
							A_0[i] = A_0[j];
							A_0[j] = cu;
						}
					}
					else
					{
						j = A_1;
					}
				}
			}
			return A_0;
		}

		// Token: 0x06001FC6 RID: 8134 RVA: 0x0013978C File Offset: 0x0013878C
		internal void l()
		{
			foreach (object obj in this.s.Keys)
			{
				StructureElement structureElement = (StructureElement)obj;
				if (!structureElement.u())
				{
					structureElement.IncludeDefaultAttributes = false;
					structureElement.a(null, null, this);
				}
			}
		}

		// Token: 0x06001FC7 RID: 8135 RVA: 0x00139810 File Offset: 0x00138810
		public override void Draw(DocumentWriter writer)
		{
			this.e(writer);
			this.a(writer);
		}

		// Token: 0x06001FC8 RID: 8136 RVA: 0x00139824 File Offset: 0x00138824
		internal new void e(DocumentWriter A_0)
		{
			if (this.z)
			{
				this.a();
			}
			else if (this.r.b() > 1)
			{
				cu[] array = this.r.a();
				Array.Sort<cu>(array, 0, this.r.b());
				this.r.a(r2.a(array, this.r.b()));
			}
			A_0.WriteBeginObject();
			this.u = A_0.GetObjectNumber();
			StructureElement[] array2 = new StructureElement[this.s.Count];
			this.s.Keys.CopyTo(array2, 0);
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].Identifier != null)
				{
					if (this.aa == null)
					{
						this.aa = new ArrayList(10);
					}
					this.aa.Add(array2[i]);
				}
			}
			for (int i = 0; i < array2.Length; i++)
			{
				this.s[array2[i]] = A_0.Resources.Add(array2[i]);
			}
			if (this.aa != null)
			{
				this.aa.Sort(new r2.b());
			}
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.a);
			A_0.WriteName(r2.b);
			int num = this.u;
			if (this.aa != null)
			{
				A_0.WriteName(r2.g);
				A_0.WriteReference(++num);
			}
			A_0.WriteName(r2.f);
			q3 resource = new q3(this);
			A_0.WriteReferenceShallow(A_0.Resources.Add(resource));
			if (this.t != null)
			{
				A_0.WriteName(r2.d);
				A_0.WriteDictionaryOpen();
				int num2 = 0;
				IDictionaryEnumerator enumerator = this.t.GetEnumerator();
				num++;
				while (enumerator.MoveNext())
				{
					A_0.WriteName(enumerator.Key.ToString());
					A_0.WriteReferenceShallow(num + num2);
					num2++;
				}
				if (this.ab != null)
				{
					enumerator = this.ab.GetEnumerator();
					while (enumerator.MoveNext())
					{
						A_0.WriteName(enumerator.Key.ToString());
						((abd)enumerator.Value).hz(A_0);
					}
				}
				A_0.WriteDictionaryClose();
			}
			else if (this.ab != null)
			{
				A_0.WriteName(r2.d);
				A_0.WriteDictionaryOpen();
				IDictionaryEnumerator enumerator = this.ab.GetEnumerator();
				while (enumerator.MoveNext())
				{
					A_0.WriteName(enumerator.Key.ToString());
					((abd)enumerator.Value).hz(A_0);
				}
				A_0.WriteDictionaryClose();
			}
			A_0.WriteName(r2.i);
			A_0.WriteNumber(A_0.Document.k());
			if (!this.z)
			{
				A_0.WriteName(r2.h);
				if (this.r.b() == 1)
				{
					this.r.a(0).a9(A_0, -1);
				}
				else
				{
					A_0.WriteArrayOpen();
					for (int j = 0; j < this.r.b(); j++)
					{
						this.r.a(j).a9(A_0, -1);
					}
					A_0.WriteArrayClose();
				}
			}
			else
			{
				A_0.WriteName(r2.h);
				this.ag = num + 1;
				A_0.WriteReference(this.ag);
			}
			this.b(A_0);
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
			if (this.aa != null)
			{
				this.a(A_0, this.aa);
			}
			if (this.z)
			{
				this.d(A_0);
			}
		}

		// Token: 0x06001FC9 RID: 8137 RVA: 0x00139C60 File Offset: 0x00138C60
		private new void d(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(r2.l);
			A_0.WriteName(r2.m);
			A_0.WriteName(r2.o);
			A_0.WriteReference(this.u);
			A_0.WriteName(r2.h);
			int num = this.ag;
			A_0.WriteArrayOpen();
			for (int i = 0; i < this.ae.Count; i++)
			{
				A_0.WriteReference(++num);
			}
			StructureElement[] array = new StructureElement[this.s.Count];
			this.s.Keys.CopyTo(array, 0);
			for (int j = 0; j < array.Length; j++)
			{
				if (!(array[j] is c5))
				{
					StructureElement structureElement = array[j];
					if (structureElement.k())
					{
						A_0.WriteReference((int)this.s[array[j]]);
					}
				}
			}
			A_0.WriteArrayClose();
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
			this.c(A_0);
		}

		// Token: 0x06001FCA RID: 8138 RVA: 0x00139D94 File Offset: 0x00138D94
		private new void c(DocumentWriter A_0)
		{
			int num = 0;
			for (int i = 0; i < this.ae.Count; i++)
			{
				int num2 = (int)this.ae[i];
				A_0.WriteBeginObject();
				A_0.WriteDictionaryOpen();
				A_0.WriteName(r2.l);
				A_0.WriteName(r2.n);
				A_0.WriteName(r2.o);
				A_0.WriteReference(this.ag);
				if (num2 > num)
				{
					A_0.WriteName(r2.h);
					A_0.WriteArrayOpen();
					if (num2 > this.r.b() - 1)
					{
						num2 = this.r.b() - 1;
					}
					for (int j = num; j <= num2; j++)
					{
						this.r.a(j).a9(A_0, -1);
					}
					num = num2 + 1;
					A_0.WriteArrayClose();
				}
				else if (this.r.a(num) != null)
				{
					A_0.WriteName(r2.h);
					this.r.a(num).a9(A_0, -1);
					num = num2 + 1;
				}
				A_0.WriteDictionaryClose();
				A_0.WriteEndObject();
			}
		}

		// Token: 0x06001FCB RID: 8139 RVA: 0x00139EE8 File Offset: 0x00138EE8
		private new void a(DocumentWriter A_0, ArrayList A_1)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(r2.j);
			A_0.WriteArrayOpen();
			for (int i = 0; i < A_1.Count; i++)
			{
				A_0.WriteText(A_1[i].ToString());
				A_0.WriteReferenceShallow((int)this.s[A_1[i]]);
			}
			A_0.WriteArrayClose();
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x06001FCC RID: 8140 RVA: 0x00139F74 File Offset: 0x00138F74
		private new void b(DocumentWriter A_0)
		{
			if (this.p != null)
			{
				A_0.WriteName(r2.c);
				A_0.WriteDictionaryOpen();
				IDictionaryEnumerator enumerator = this.p.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (enumerator.Value != null)
					{
						A_0.WriteName(enumerator.Key.ToString());
						A_0.WriteName(enumerator.Value.ToString());
					}
					else
					{
						A_0.WriteName(enumerator.Key.ToString() + " null");
					}
				}
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x06001FCD RID: 8141 RVA: 0x0013A020 File Offset: 0x00139020
		private new void a(DocumentWriter A_0)
		{
			if (this.t != null)
			{
				IDictionaryEnumerator enumerator = this.t.GetEnumerator();
				while (enumerator.MoveNext())
				{
					((AttributeClass)enumerator.Value).a(A_0);
				}
			}
		}

		// Token: 0x06001FCE RID: 8142 RVA: 0x0013A06C File Offset: 0x0013906C
		private new void a(AttributeClassList A_0)
		{
			if (this.t == null)
			{
				this.t = new HybridDictionary(A_0.Count);
			}
			for (int i = 0; i < A_0.Count; i++)
			{
				string text = A_0[i].a();
				object obj = this.t[text];
				if (obj == null)
				{
					this.t.Add(text, A_0[i]);
				}
				else if (A_0[i] != obj)
				{
					throw new GeneratorException("The '" + text + "' class name is already used by another AttributeClass object");
				}
			}
		}

		// Token: 0x06001FCF RID: 8143 RVA: 0x0013A114 File Offset: 0x00139114
		private new void a()
		{
			StructureElement[] array = new StructureElement[this.s.Count];
			this.s.Keys.CopyTo(array, 0);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].bq())
				{
					this.c(array[i]);
				}
			}
		}

		// Token: 0x06001FD0 RID: 8144 RVA: 0x0013A178 File Offset: 0x00139178
		private new void c(StructureElement A_0)
		{
			if (A_0.Parent == null)
			{
				if (this.s.Contains(A_0))
				{
					if (A_0.br())
					{
						this.s.Remove(A_0);
						this.a(A_0);
					}
				}
			}
			else
			{
				this.b(A_0);
			}
		}

		// Token: 0x06001FD1 RID: 8145 RVA: 0x0013A1E0 File Offset: 0x001391E0
		private new void b(StructureElement A_0)
		{
			StructureElement parent = A_0.Parent;
			if (this.s.Contains(A_0))
			{
				if (A_0.br())
				{
					this.s.Remove(A_0);
					parent.bs(A_0);
				}
				else if (A_0.n() != null && A_0.n().b() <= 0)
				{
					parent.bs(A_0);
				}
			}
			if (this.s.Contains(parent) && !parent.bu())
			{
				this.c(parent);
			}
		}

		// Token: 0x06001FD2 RID: 8146 RVA: 0x0013A27C File Offset: 0x0013927C
		private new void a(StructureElement A_0)
		{
			for (int i = 0; i < this.r.b(); i++)
			{
				if (!this.r.a(i).bb() && ((cy)this.r.a(i)).a() == A_0)
				{
					this.r.b(this.r.a(i));
					for (int j = 0; j < this.ae.Count; j++)
					{
						int num = (int)this.ae[j];
						if (num >= i)
						{
							this.ae[j] = num - 1;
							for (int k = j + 1; k < this.ae.Count; k++)
							{
								num = (int)this.ae[k];
								this.ae[k] = num - 1;
							}
							break;
						}
					}
				}
			}
		}

		// Token: 0x06001FD3 RID: 8147 RVA: 0x0013A3B8 File Offset: 0x001393B8
		internal new void a(abj A_0, int A_1, int A_2)
		{
			this.z = true;
			abd abd = null;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 62047363)
				{
					if (num != 11)
					{
						if (num == 62047363)
						{
							this.b((abj)abk.c().h6());
							abk.a(false);
						}
					}
					else
					{
						abd = abk.c();
						abk.a(false);
					}
				}
				else if (num != 152128640)
				{
					if (num != 314491197)
					{
						if (num == 617873419)
						{
							abd abd2 = abk.c();
							abk.a(false);
						}
					}
					else
					{
						abj a_ = (abj)abk.c().h6();
						this.a(a_);
						abk.a(false);
					}
				}
				else
				{
					abk.a(false);
				}
			}
			if (abd != null)
			{
				this.x = new c7();
				this.x.b(this.ae.Count);
				this.x.a(abd, this, A_1, A_2);
				int i;
				for (i = 0; i < this.x.c(); i++)
				{
					if (this.x.c(i) != null)
					{
						this.e(this.x.c(i));
					}
				}
				for (i = 0; i < this.x.c(); i++)
				{
					if (this.x.c(i) != null && !this.x.c(i).bt())
					{
						this.c(this.x.c(i));
					}
				}
				i = 0;
				while (!this.v && i < this.x.c())
				{
					if (this.x.c(i) != null && ((c5)this.x.c(i)).i())
					{
						this.v = true;
						break;
					}
					i++;
				}
				if (this.r.b() > 0 && this.r.b() != this.ah)
				{
					this.ae.Add(this.af, this.r.b() - 1);
					this.af++;
					this.ah = this.r.b();
				}
				this.x = null;
			}
		}

		// Token: 0x06001FD4 RID: 8148 RVA: 0x0013A688 File Offset: 0x00139688
		internal new static bool a(abd A_0)
		{
			bool flag = false;
			if (A_0.hy() == ag9.g)
			{
				flag = r2.a(((abj)A_0).l());
			}
			else if (A_0.hy() == ag9.e)
			{
				int num = 0;
				while (!flag && num < ((abe)A_0).a())
				{
					flag = r2.a(((abe)A_0).a(num));
					num++;
				}
			}
			else if (A_0.hy() == ag9.j)
			{
				flag = r2.a(A_0.h6());
			}
			return flag;
		}

		// Token: 0x06001FD5 RID: 8149 RVA: 0x0013A730 File Offset: 0x00139730
		private new static bool a(abk A_0)
		{
			bool flag = false;
			bool flag2 = false;
			while (!flag && A_0 != null)
			{
				int num = A_0.a().j8();
				if (num == 15)
				{
					if (665046161 == ((abu)A_0.c()).j8())
					{
						flag = true;
					}
					flag2 = true;
				}
				if (flag2)
				{
					break;
				}
				A_0 = A_0.d();
			}
			return flag;
		}

		// Token: 0x06001FD6 RID: 8150 RVA: 0x0013A7AC File Offset: 0x001397AC
		private new void b(abj A_0)
		{
			abk abk = A_0.l();
			if (this.ab == null)
			{
				this.ab = new HybridDictionary();
			}
			while (abk != null)
			{
				if (!this.ab.Contains(abk.a().j9()))
				{
					this.ab.Add(abk.a().j9(), abk.c());
					if (abk.c().hy() == ag9.e)
					{
						this.y += ((abe)abk.c()).a();
					}
					else if (abk.c().hy() == ag9.j)
					{
						this.y++;
					}
				}
				if (this.ac && !this.v)
				{
					this.v = r2.a(abk.c());
				}
				abk = abk.d();
			}
		}

		// Token: 0x06001FD7 RID: 8151 RVA: 0x0013A8B4 File Offset: 0x001398B4
		private new void a(abj A_0)
		{
			abk abk = A_0.l();
			if (this.p == null)
			{
				this.p = new HybridDictionary();
			}
			while (abk != null)
			{
				if (this.p.Contains(abk.a().j9()))
				{
					string text = abk.a().j9();
					StandardTagType standardTagType = TagType.a(((abu)abk.c()).j9());
					if (this.p[text] != standardTagType)
					{
						string key;
						do
						{
							key = text + "+" + ++this.ad;
						}
						while (this.p.Contains(key));
						this.p.Add(key, standardTagType);
					}
				}
				else if (abk.c().hy() == ag9.i)
				{
					this.p.Add(abk.a().j9(), null);
				}
				else
				{
					this.p.Add(abk.a().j9(), TagType.a(((abu)abk.c()).j9()));
				}
				abk = abk.d();
			}
		}

		// Token: 0x04000DA9 RID: 3497
		private new const string a = " null";

		// Token: 0x04000DAA RID: 3498
		private new static byte[] b = new byte[]
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

		// Token: 0x04000DAB RID: 3499
		private new static byte[] c = new byte[]
		{
			82,
			111,
			108,
			101,
			77,
			97,
			112
		};

		// Token: 0x04000DAC RID: 3500
		private new static byte[] d = new byte[]
		{
			67,
			108,
			97,
			115,
			115,
			77,
			97,
			112
		};

		// Token: 0x04000DAD RID: 3501
		private new static byte[] e = new byte[]
		{
			78,
			111,
			114,
			109,
			97,
			108
		};

		// Token: 0x04000DAE RID: 3502
		private new static byte[] f = new byte[]
		{
			80,
			97,
			114,
			101,
			110,
			116,
			84,
			114,
			101,
			101
		};

		// Token: 0x04000DAF RID: 3503
		private new static byte[] g = new byte[]
		{
			73,
			68,
			84,
			114,
			101,
			101
		};

		// Token: 0x04000DB0 RID: 3504
		private new static byte h = 75;

		// Token: 0x04000DB1 RID: 3505
		private new static byte[] i = new byte[]
		{
			80,
			97,
			114,
			101,
			110,
			116,
			84,
			114,
			101,
			101,
			78,
			101,
			120,
			116,
			75,
			101,
			121
		};

		// Token: 0x04000DB2 RID: 3506
		private static byte[] j = new byte[]
		{
			78,
			97,
			109,
			101,
			115
		};

		// Token: 0x04000DB3 RID: 3507
		private static byte[] k = new byte[]
		{
			78,
			117,
			109,
			115
		};

		// Token: 0x04000DB4 RID: 3508
		private static byte l = 83;

		// Token: 0x04000DB5 RID: 3509
		private static byte[] m = new byte[]
		{
			68,
			111,
			99,
			117,
			109,
			101,
			110,
			116
		};

		// Token: 0x04000DB6 RID: 3510
		private static byte[] n = new byte[]
		{
			80,
			97,
			114,
			116
		};

		// Token: 0x04000DB7 RID: 3511
		private static byte o = 80;

		// Token: 0x04000DB8 RID: 3512
		private HybridDictionary p;

		// Token: 0x04000DB9 RID: 3513
		private q2 q = new q2(10);

		// Token: 0x04000DBA RID: 3514
		private cv r = new cv(10);

		// Token: 0x04000DBB RID: 3515
		private HybridDictionary s = new HybridDictionary();

		// Token: 0x04000DBC RID: 3516
		private HybridDictionary t;

		// Token: 0x04000DBD RID: 3517
		private int u = -1;

		// Token: 0x04000DBE RID: 3518
		private bool v = false;

		// Token: 0x04000DBF RID: 3519
		private bool w = false;

		// Token: 0x04000DC0 RID: 3520
		private c7 x = null;

		// Token: 0x04000DC1 RID: 3521
		private int y = 0;

		// Token: 0x04000DC2 RID: 3522
		private bool z = false;

		// Token: 0x04000DC3 RID: 3523
		private ArrayList aa = null;

		// Token: 0x04000DC4 RID: 3524
		private HybridDictionary ab = null;

		// Token: 0x04000DC5 RID: 3525
		internal bool ac = false;

		// Token: 0x04000DC6 RID: 3526
		private int ad = 1;

		// Token: 0x04000DC7 RID: 3527
		private Hashtable ae = new Hashtable();

		// Token: 0x04000DC8 RID: 3528
		private int af = 0;

		// Token: 0x04000DC9 RID: 3529
		private int ag = -1;

		// Token: 0x04000DCA RID: 3530
		private int ah = 0;

		// Token: 0x020002B3 RID: 691
		internal new class a
		{
			// Token: 0x06001FD9 RID: 8153 RVA: 0x0013AB23 File Offset: 0x00139B23
			internal a(int A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06001FDA RID: 8154 RVA: 0x0013AB3C File Offset: 0x00139B3C
			internal a(int A_0, bool A_1)
			{
				this.a = A_0;
				this.c = A_1;
			}

			// Token: 0x06001FDB RID: 8155 RVA: 0x0013AB5C File Offset: 0x00139B5C
			internal int a()
			{
				return this.a;
			}

			// Token: 0x06001FDC RID: 8156 RVA: 0x0013AB74 File Offset: 0x00139B74
			internal bool b()
			{
				return this.c;
			}

			// Token: 0x06001FDD RID: 8157 RVA: 0x0013AB8C File Offset: 0x00139B8C
			internal c6 c()
			{
				if (this.b == null)
				{
					this.b = new c6(5);
				}
				return this.b;
			}

			// Token: 0x04000DCB RID: 3531
			private int a;

			// Token: 0x04000DCC RID: 3532
			private c6 b;

			// Token: 0x04000DCD RID: 3533
			private bool c = false;
		}

		// Token: 0x020002B4 RID: 692
		private new class b : IComparer
		{
			// Token: 0x06001FDE RID: 8158 RVA: 0x0013ABC4 File Offset: 0x00139BC4
			int IComparer.a(object A_0, object A_1)
			{
				return string.CompareOrdinal(A_0.ToString(), A_1.ToString());
			}
		}
	}
}
