using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006A7 RID: 1703
	public class PageList : IEnumerable
	{
		// Token: 0x17000274 RID: 628
		public Page this[int index]
		{
			get
			{
				return (Page)this.a[index];
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06004097 RID: 16535 RVA: 0x0022255C File Offset: 0x0022155C
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x06004098 RID: 16536 RVA: 0x0022257C File Offset: 0x0022157C
		public int Add(Page page)
		{
			return this.a.Add(page);
		}

		// Token: 0x06004099 RID: 16537 RVA: 0x0022259A File Offset: 0x0022159A
		public void Insert(int index, Page page)
		{
			this.a.Insert(index, page);
		}

		// Token: 0x0600409A RID: 16538 RVA: 0x002225AC File Offset: 0x002215AC
		public IEnumerator GetEnumerator()
		{
			return this.a.GetEnumerator();
		}

		// Token: 0x0600409B RID: 16539 RVA: 0x002225CC File Offset: 0x002215CC
		internal bool a()
		{
			return this.g;
		}

		// Token: 0x0600409C RID: 16540 RVA: 0x002225E4 File Offset: 0x002215E4
		internal int b()
		{
			int result;
			if (this.a.Count <= 16)
			{
				result = 1;
			}
			else
			{
				result = 2 + (this.a.Count - 1) / 16;
			}
			return result;
		}

		// Token: 0x0600409D RID: 16541 RVA: 0x00222624 File Offset: 0x00221624
		internal void a(DocumentWriter A_0, int A_1, int A_2)
		{
			int num = 1;
			if (this.a.Count > 16)
			{
				A_0.WriteBeginObject();
				A_0.WriteDictionaryOpen();
				A_0.WriteName(PageList.b);
				A_0.WriteName(PageList.c);
				A_0.WriteName(PageList.d);
				A_0.WriteArrayOpen();
				int objectNumber = A_0.GetObjectNumber();
				int num2 = objectNumber + 1;
				int num3 = num2 + (this.a.Count - 1) / 16;
				for (int i = num2; i <= num3; i++)
				{
					A_0.WriteReference(i);
				}
				A_0.WriteArrayClose();
				A_0.WriteName(PageList.f);
				A_0.WriteNumber(this.a.Count);
				A_0.WriteDictionaryClose();
				A_0.WriteEndObject();
				int j = A_1;
				int num4 = num2 + 1;
				while (j <= A_2)
				{
					int k = 0;
					A_0.WriteBeginObject();
					A_0.WriteDictionaryOpen();
					A_0.WriteName(PageList.b);
					A_0.WriteName(PageList.c);
					A_0.WriteName(PageList.e);
					A_0.WriteReference(objectNumber);
					A_0.WriteName(PageList.d);
					A_0.WriteArrayOpen();
					while (k < this.a.Count)
					{
						A_0.WriteReference(j);
						j += num;
						k++;
						if (k % 16 == 0 || j > A_2)
						{
							break;
						}
					}
					A_0.WriteArrayClose();
					A_0.WriteName(PageList.f);
					A_0.WriteNumber(k);
					A_0.WriteDictionaryClose();
					A_0.WriteEndObject();
					num4++;
				}
			}
			else
			{
				A_0.WriteBeginObject();
				A_0.WriteDictionaryOpen();
				A_0.WriteName(PageList.b);
				A_0.WriteName(PageList.c);
				A_0.WriteName(PageList.d);
				A_0.WriteArrayOpen();
				for (int i = A_1; i <= A_2; i++)
				{
					A_0.WriteReference(i);
				}
				A_0.WriteArrayClose();
				A_0.WriteName(PageList.f);
				A_0.WriteNumber(this.a.Count);
				A_0.WriteDictionaryClose();
				A_0.WriteEndObject();
			}
		}

		// Token: 0x040023E0 RID: 9184
		private ArrayList a = new ArrayList();

		// Token: 0x040023E1 RID: 9185
		private static byte[] b = new byte[]
		{
			84,
			121,
			112,
			101
		};

		// Token: 0x040023E2 RID: 9186
		private static byte[] c = new byte[]
		{
			80,
			97,
			103,
			101,
			115
		};

		// Token: 0x040023E3 RID: 9187
		private static byte[] d = new byte[]
		{
			75,
			105,
			100,
			115
		};

		// Token: 0x040023E4 RID: 9188
		private static byte[] e = new byte[]
		{
			80,
			97,
			114,
			101,
			110,
			116
		};

		// Token: 0x040023E5 RID: 9189
		private static byte[] f = new byte[]
		{
			67,
			111,
			117,
			110,
			116
		};

		// Token: 0x040023E6 RID: 9190
		private bool g = false;
	}
}
