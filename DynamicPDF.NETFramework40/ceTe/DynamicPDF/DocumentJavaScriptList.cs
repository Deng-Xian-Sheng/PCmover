using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000671 RID: 1649
	public class DocumentJavaScriptList : Resource
	{
		// Token: 0x06003FD8 RID: 16344 RVA: 0x0021E8B0 File Offset: 0x0021D8B0
		internal DocumentJavaScriptList()
		{
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06003FD9 RID: 16345 RVA: 0x0021E8E0 File Offset: 0x0021D8E0
		public int Count
		{
			get
			{
				this.a();
				int result;
				if (this.c == null)
				{
					result = 0;
				}
				else
				{
					result = this.c.Count;
				}
				return result;
			}
		}

		// Token: 0x17000248 RID: 584
		public DocumentJavaScript this[int index]
		{
			get
			{
				this.a();
				return (DocumentJavaScript)this.c[index];
			}
		}

		// Token: 0x17000249 RID: 585
		public DocumentJavaScript this[string name]
		{
			get
			{
				return this.b(new aci(name));
			}
		}

		// Token: 0x06003FDC RID: 16348 RVA: 0x0021E964 File Offset: 0x0021D964
		public override void Draw(DocumentWriter writer)
		{
			if (this.f != null)
			{
				writer.WriteBeginObject();
				this.f.hz(writer);
				writer.WriteEndObject();
			}
			else if (this.c == null)
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				writer.WriteName(DocumentJavaScriptList.a);
				writer.WriteArrayOpen();
				writer.WriteArrayClose();
				writer.WriteDictionaryClose();
				writer.WriteEndObject();
			}
			else
			{
				this.c();
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				writer.WriteName(DocumentJavaScriptList.a);
				writer.WriteArrayOpen();
				for (int i = 0; i < this.e.Length; i++)
				{
					this.e[i].a(writer);
				}
				writer.WriteArrayClose();
				writer.WriteDictionaryClose();
				writer.WriteEndObject();
			}
		}

		// Token: 0x06003FDD RID: 16349 RVA: 0x0021EA54 File Offset: 0x0021DA54
		public void Add(DocumentJavaScript javaScript)
		{
			this.b = true;
			this.a();
			switch (this.c.Count)
			{
			case 0:
				this.c.Add(javaScript);
				this.e = null;
				break;
			case 1:
				if (javaScript.b().Equals(this[0].b()))
				{
					throw new GeneratorException("Document level JavaScript by that name already exists.");
				}
				this.d = new Hashtable();
				this.d.Add(this[0].b(), this[0]);
				this.c.Add(javaScript);
				this.d.Add(javaScript.b(), javaScript);
				this.e = null;
				break;
			default:
				if (this.d.ContainsKey(javaScript.b()))
				{
					throw new GeneratorException("Document level JavaScript by that name already exists.");
				}
				this.c.Add(javaScript);
				this.d.Add(javaScript.b(), javaScript);
				this.e = null;
				break;
			}
		}

		// Token: 0x06003FDE RID: 16350 RVA: 0x0021EB70 File Offset: 0x0021DB70
		public bool ContainsName(string name)
		{
			return this.a(new aci(name));
		}

		// Token: 0x06003FDF RID: 16351 RVA: 0x0021EB90 File Offset: 0x0021DB90
		internal new void b(abj A_0)
		{
			if (this.c == null)
			{
				if (this.f == null)
				{
					this.f = A_0;
				}
				else
				{
					this.c = new ArrayList();
					this.d = new Hashtable();
					aba aba = this.f.k().b().f().k8();
					this.a(this.f);
					aba.lr();
					this.a(A_0);
					this.f = null;
				}
			}
			else
			{
				if (this.d == null)
				{
					this.d = new Hashtable();
					if (this.c.Count == 1)
					{
						this.d.Add(this[0].b(), this[0]);
					}
				}
				this.a(A_0);
			}
		}

		// Token: 0x06003FE0 RID: 16352 RVA: 0x0021EC7C File Offset: 0x0021DC7C
		internal new bool a(aci A_0)
		{
			bool result;
			if (this.f == null && this.c == null)
			{
				result = false;
			}
			else if (this.c.Count == 1)
			{
				result = A_0.Equals(this[0].b());
			}
			else
			{
				object obj = this.d[A_0];
				result = (obj != null);
			}
			return result;
		}

		// Token: 0x06003FE1 RID: 16353 RVA: 0x0021ED00 File Offset: 0x0021DD00
		internal new int e()
		{
			int result;
			if (this.b)
			{
				result = 3;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06003FE2 RID: 16354 RVA: 0x0021ED24 File Offset: 0x0021DD24
		internal new DocumentJavaScript b(aci A_0)
		{
			DocumentJavaScript result;
			if (this.f == null && this.c == null)
			{
				result = null;
			}
			else
			{
				this.a();
				if (this.c.Count == 1)
				{
					if (A_0.Equals(this[0].b()))
					{
						result = this[0];
					}
					else
					{
						result = null;
					}
				}
				else
				{
					object obj = this.d[A_0];
					if (obj != null)
					{
						result = (DocumentJavaScript)obj;
					}
					else
					{
						result = null;
					}
				}
			}
			return result;
		}

		// Token: 0x06003FE3 RID: 16355 RVA: 0x0021EDBC File Offset: 0x0021DDBC
		private new void c()
		{
			this.e = new DocumentJavaScript[this.c.Count];
			this.c.CopyTo(this.e);
			if (this.c.Count > 1)
			{
				this.a(this.e, 0, this.e.Length - 1);
			}
		}

		// Token: 0x06003FE4 RID: 16356 RVA: 0x0021EE20 File Offset: 0x0021DE20
		private new void a(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 3053875)
				{
					if (num == 243718515)
					{
						this.a((abe)abk.c());
					}
				}
				else
				{
					abd abd = abk.c().h6();
					if (abd != null)
					{
						if (abd.hy() == ag9.e)
						{
							abe abe = (abe)abd;
							for (int i = 0; i < abe.a(); i++)
							{
								ab6 ab = (ab6)abe.a(i);
								this.a((abj)ab.h6());
							}
						}
						else if (abd.hy() == ag9.g)
						{
							this.a((abj)abd);
						}
					}
				}
			}
		}

		// Token: 0x06003FE5 RID: 16357 RVA: 0x0021EF24 File Offset: 0x0021DF24
		private new void a(abe A_0)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				ab7 ab = (ab7)A_0.a(i++);
				aci aci = new aci(ab.kg());
				if (this.a(aci))
				{
					int num = 2;
					aci aci2;
					do
					{
						aci2 = aci.a(num++);
					}
					while (this.a(aci2));
					aci = aci2;
				}
				yt yt = new yt(aci, (abj)A_0.a(i).h6());
				this.c.Add(yt);
				this.d.Add(yt.b(), yt);
			}
		}

		// Token: 0x06003FE6 RID: 16358 RVA: 0x0021EFE0 File Offset: 0x0021DFE0
		private new void a(DocumentJavaScript[] A_0, int A_1, int A_2)
		{
			if (A_2 > A_1)
			{
				int i = A_1;
				int num = A_2;
				int num2 = (A_1 + A_2 + 1) / 2;
				DocumentJavaScript documentJavaScript = A_0[num2];
				while (i <= num)
				{
					while (i < A_2 && A_0[i].a(documentJavaScript))
					{
						i++;
					}
					while (num > A_1 && documentJavaScript.a(A_0[num]))
					{
						num--;
					}
					if (i <= num)
					{
						DocumentJavaScript documentJavaScript2 = A_0[i];
						A_0[i] = A_0[num];
						A_0[num] = documentJavaScript2;
						i++;
						num--;
					}
				}
				if (A_1 < num)
				{
					this.a(A_0, A_1, num);
				}
				if (i < A_2)
				{
					this.a(A_0, i, A_2);
				}
			}
		}

		// Token: 0x06003FE7 RID: 16359 RVA: 0x0021F0AC File Offset: 0x0021E0AC
		private new void a()
		{
			if (this.c == null)
			{
				this.c = new ArrayList();
				if (this.f != null)
				{
					this.d = new Hashtable();
					this.a(this.f);
				}
				this.f = null;
			}
		}

		// Token: 0x04002282 RID: 8834
		private new static byte[] a = new byte[]
		{
			78,
			97,
			109,
			101,
			115
		};

		// Token: 0x04002283 RID: 8835
		private new bool b = false;

		// Token: 0x04002284 RID: 8836
		private new ArrayList c = null;

		// Token: 0x04002285 RID: 8837
		private new Hashtable d = null;

		// Token: 0x04002286 RID: 8838
		private new DocumentJavaScript[] e = null;

		// Token: 0x04002287 RID: 8839
		private new abj f = null;
	}
}
