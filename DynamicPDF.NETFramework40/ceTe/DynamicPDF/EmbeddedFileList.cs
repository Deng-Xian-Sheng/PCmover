using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000673 RID: 1651
	public class EmbeddedFileList : Resource
	{
		// Token: 0x06003FE9 RID: 16361 RVA: 0x0021F11A File Offset: 0x0021E11A
		internal EmbeddedFileList()
		{
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06003FEA RID: 16362 RVA: 0x0021F144 File Offset: 0x0021E144
		public int Count
		{
			get
			{
				this.a();
				int result;
				if (this.b == null)
				{
					result = 0;
				}
				else
				{
					result = this.b.Count;
				}
				return result;
			}
		}

		// Token: 0x1700024B RID: 587
		public EmbeddedFile this[int index]
		{
			get
			{
				this.a();
				return (EmbeddedFile)this.b[index];
			}
		}

		// Token: 0x06003FEC RID: 16364 RVA: 0x0021F1A8 File Offset: 0x0021E1A8
		public override void Draw(DocumentWriter writer)
		{
			if (this.d != null)
			{
				writer.WriteBeginObject();
				if ((this.d.k().b().g() != null && this.d.k().b().g().at()) || (writer.Document.Security != null && writer.Document.Security.a() == b5.b && writer.Document.Security.d()))
				{
					this.a(writer);
				}
				else
				{
					this.d.hz(writer);
				}
				writer.WriteEndObject();
			}
			else if (this.b == null)
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				writer.WriteName(EmbeddedFileList.a);
				writer.WriteArrayOpen();
				writer.WriteArrayClose();
				writer.WriteDictionaryClose();
				writer.WriteEndObject();
			}
			else
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				writer.WriteName(EmbeddedFileList.a);
				writer.WriteArrayOpen();
				this.b(writer);
				writer.WriteArrayClose();
				writer.WriteDictionaryClose();
				writer.WriteEndObject();
			}
		}

		// Token: 0x06003FED RID: 16365 RVA: 0x0021F2F0 File Offset: 0x0021E2F0
		public void Add(EmbeddedFile embeddedFile)
		{
			this.e = true;
			this.a();
			switch (this.b.Count)
			{
			case 0:
				this.b.Add(embeddedFile);
				break;
			case 1:
				if (embeddedFile.f().Equals(this[0].f()))
				{
					aci a_ = embeddedFile.f().a(2);
					embeddedFile.a(a_);
					embeddedFile.f().a(true);
				}
				this.c = new SortedList(new ya());
				this.c.Add(this[0].f().a(), this[0]);
				this.b.Add(embeddedFile);
				this.c.Add(embeddedFile.f().a(), embeddedFile);
				break;
			default:
				if (this.a(embeddedFile.f()))
				{
					int num = 2;
					aci a_;
					do
					{
						a_ = embeddedFile.f().a(num++);
					}
					while (this.a(a_));
					embeddedFile.a(a_);
					embeddedFile.f().a(true);
					this.b.Add(embeddedFile);
					this.c.Add(embeddedFile.f().a(), embeddedFile);
				}
				else
				{
					this.b.Add(embeddedFile);
					this.c.Add(embeddedFile.f().a(), embeddedFile);
				}
				break;
			}
		}

		// Token: 0x06003FEE RID: 16366 RVA: 0x0021F47C File Offset: 0x0021E47C
		internal new int c()
		{
			int result;
			if (this.e)
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06003FEF RID: 16367 RVA: 0x0021F4A0 File Offset: 0x0021E4A0
		internal new void b(abj A_0)
		{
			if (this.b == null)
			{
				if (this.d == null)
				{
					this.d = A_0;
				}
				else
				{
					this.b = new ArrayList();
					this.c = new SortedList();
					aba aba = this.d.k().b().f().k8();
					this.a(this.d);
					aba.lr();
					this.a(A_0);
					this.d = null;
				}
			}
			else
			{
				if (this.c == null)
				{
					this.c = new SortedList();
					if (this.b.Count == 1)
					{
						this.c.Add(this[0].f().a(), this[0]);
					}
				}
				this.a(A_0);
			}
		}

		// Token: 0x06003FF0 RID: 16368 RVA: 0x0021F594 File Offset: 0x0021E594
		internal new bool a(aci A_0)
		{
			bool result;
			if (this.d == null && this.b == null)
			{
				result = false;
			}
			else if (this.b.Count == 1)
			{
				result = A_0.Equals(this[0].f());
			}
			else
			{
				EmbeddedFile embeddedFile = (EmbeddedFile)this.c[A_0.a()];
				if (embeddedFile != null)
				{
					result = true;
				}
				else
				{
					for (int i = 0; i < this.c.Count; i++)
					{
						byte[] array = ((EmbeddedFile)this.c.GetByIndex(i)).f().c();
						if (array.Length > 1 && array[0] == 254 && array[1] == 255)
						{
							string @string = Encoding.BigEndianUnicode.GetString(array, 2, array.Length - 2);
							if (@string.Equals(A_0.a()))
							{
								return true;
							}
						}
					}
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06003FF1 RID: 16369 RVA: 0x0021F6D4 File Offset: 0x0021E6D4
		private new void a(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num == 243718515)
				{
					this.a((abe)abk.c());
				}
			}
		}

		// Token: 0x06003FF2 RID: 16370 RVA: 0x0021F72C File Offset: 0x0021E72C
		private new void b(DocumentWriter A_0)
		{
			if (this.c == null && this.b != null)
			{
				for (int i = 0; i < this.b.Count; i++)
				{
					EmbeddedFile embeddedFile = (EmbeddedFile)this.b[i];
					embeddedFile.a(A_0);
				}
			}
			else
			{
				IList keyList = this.c.GetKeyList();
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				ArrayList arrayList3 = new ArrayList();
				int i;
				for (i = 0; i < keyList.Count; i++)
				{
					arrayList2.Add(keyList[i]);
				}
				i = arrayList2.Count;
				while (--i > 0)
				{
					for (int j = 0; j < i; j++)
					{
						string text = arrayList2[j] as string;
						char[] array = text.ToCharArray();
						string text2 = arrayList2[j + 1] as string;
						char[] array2 = text2.ToCharArray();
						if (array != null && array2 != null)
						{
							bool flag = array[0] == 'þ' && array[1] == 'ÿ';
							bool flag2 = array2[0] == 'þ' && array2[1] == 'ÿ';
							if (!flag && !flag2)
							{
								if (array[0] > array2[0])
								{
									string value = (string)arrayList2[j];
									arrayList2[j] = arrayList2[j + 1];
									arrayList2[j + 1] = value;
								}
							}
							else if (!flag && flag2)
							{
								if (array[0] > array2[3])
								{
									string value = (string)arrayList2[j];
									arrayList2[j] = arrayList2[j + 1];
									arrayList2[j + 1] = value;
								}
							}
							else if (flag && !flag2)
							{
								if (array[3] > array2[0])
								{
									string value = (string)arrayList2[j];
									arrayList2[j] = arrayList2[j + 1];
									arrayList2[j + 1] = value;
								}
							}
							else if (array[3] > array2[3])
							{
								string value = (string)arrayList2[j];
								arrayList2[j] = arrayList2[j + 1];
								arrayList2[j + 1] = value;
							}
						}
					}
				}
				for (i = 0; i < arrayList2.Count; i++)
				{
					EmbeddedFile embeddedFile2 = (EmbeddedFile)this.c[arrayList2[i]];
					string text3 = arrayList2[i] as string;
					char[] array3 = text3.ToCharArray();
					if ((array3[0] == 'þ' && array3[1] == 'ÿ') || embeddedFile2.f().b())
					{
						arrayList.Add(arrayList2[i]);
					}
					else
					{
						arrayList3.Add(arrayList2[i]);
					}
				}
				for (int k = 0; k < arrayList3.Count; k++)
				{
					for (int l = 0; l < this.c.Count; l++)
					{
						if (arrayList3[k] == this.c.GetKey(l))
						{
							EmbeddedFile embeddedFile3 = (EmbeddedFile)this.c.GetByIndex(l);
							embeddedFile3.a(A_0);
						}
					}
				}
				for (int k = 0; k < arrayList.Count; k++)
				{
					for (int l = 0; l < this.c.Count; l++)
					{
						if (arrayList[k] == this.c.GetKey(l))
						{
							EmbeddedFile embeddedFile3 = (EmbeddedFile)this.c.GetByIndex(l);
							embeddedFile3.a(A_0);
						}
					}
				}
			}
		}

		// Token: 0x06003FF3 RID: 16371 RVA: 0x0021FBB0 File Offset: 0x0021EBB0
		private new void a(abe A_0)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				ab7 ab = null;
				if (A_0.a(i).hy() == ag9.c)
				{
					ab = (ab7)A_0.a(i++);
				}
				else
				{
					abd abd = A_0.a(i++).h6();
					if (abd.hy() == ag9.c)
					{
						ab = (ab7)abd;
					}
				}
				aci aci = new aci(ab.kg());
				if (this.a(aci))
				{
					int num = 2;
					aci = new aci(ab.kf());
					aci aci2;
					do
					{
						aci2 = aci.a(num++);
					}
					while (this.a(aci2));
					aci = aci2;
				}
				cg cg = new cg(aci, (abj)A_0.a(i).h6());
				this.b.Add(cg);
				this.c.Add(cg.f().a(), cg);
			}
		}

		// Token: 0x06003FF4 RID: 16372 RVA: 0x0021FCD0 File Offset: 0x0021ECD0
		private new void a()
		{
			if (this.b == null)
			{
				this.b = new ArrayList();
				if (this.d != null)
				{
					this.c = new SortedList();
					this.a(this.d);
				}
				this.d = null;
			}
		}

		// Token: 0x06003FF5 RID: 16373 RVA: 0x0021FD26 File Offset: 0x0021ED26
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteDictionaryOpen();
			this.a(A_0, this.d);
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06003FF6 RID: 16374 RVA: 0x0021FD48 File Offset: 0x0021ED48
		private new void a(DocumentWriter A_0, abj A_1)
		{
			for (abk abk = A_1.l(); abk != null; abk = abk.d())
			{
				abk.a().hz(A_0);
				if (abk.c().hy() == ag9.e)
				{
					A_0.WriteArrayOpen();
					abe abe = (abe)abk.c();
					for (int i = 0; i < abe.a(); i++)
					{
						if (abe.a(i).hy() == ag9.j)
						{
							ab6 ab = (ab6)abe.a(i);
							abg abg = ab.b().m().b((long)ab.c());
							abj abj = (abj)abg.i();
							if (abg != null)
							{
								if (abk.a().j9() == "Names")
								{
									A_0.WriteReferenceUnique(new ch(abj));
								}
								else
								{
									A_0.WriteDictionaryOpen();
									this.a(A_0, abj);
									A_0.WriteDictionaryClose();
								}
							}
						}
						else if (abe.a(i).hy() == ag9.g)
						{
							A_0.WriteDictionaryOpen();
							this.a(A_0, (abj)abe.a(i));
							A_0.WriteDictionaryClose();
						}
						else
						{
							abe.a(i).hz(A_0);
						}
					}
					A_0.WriteArrayClose();
				}
			}
		}

		// Token: 0x0400228D RID: 8845
		private new static byte[] a = new byte[]
		{
			78,
			97,
			109,
			101,
			115
		};

		// Token: 0x0400228E RID: 8846
		private new ArrayList b = null;

		// Token: 0x0400228F RID: 8847
		private new SortedList c = null;

		// Token: 0x04002290 RID: 8848
		private new abj d = null;

		// Token: 0x04002291 RID: 8849
		private new bool e = false;
	}
}
