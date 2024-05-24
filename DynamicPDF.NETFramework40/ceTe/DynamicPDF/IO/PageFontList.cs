using System;
using System.Collections;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006DA RID: 1754
	public class PageFontList
	{
		// Token: 0x060043A6 RID: 17318 RVA: 0x00230973 File Offset: 0x0022F973
		internal PageFontList()
		{
		}

		// Token: 0x060043A7 RID: 17319 RVA: 0x00230993 File Offset: 0x0022F993
		public void SetStartingNameNumber(int startingNameNumber)
		{
			this.c = startingNameNumber;
		}

		// Token: 0x060043A8 RID: 17320 RVA: 0x002309A0 File Offset: 0x0022F9A0
		public void Add(Resource font, PageWriter writer)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.b = new Hashtable();
			}
			writer.Write(PageFontList.d);
			if (this.b.ContainsKey(font.Uid))
			{
				writer.Write((int)this.b[font.Uid]);
			}
			else
			{
				if (font is OpenTypeFont || font is Type1Font)
				{
					writer.RequireLicense(1);
				}
				int num = this.a.Add(font) + this.c;
				this.b.Add(font.Uid, num);
				writer.Write(num);
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x060043A9 RID: 17321 RVA: 0x00230A84 File Offset: 0x0022FA84
		public int Count
		{
			get
			{
				return (this.a == null) ? 0 : this.a.Count;
			}
		}

		// Token: 0x060043AA RID: 17322 RVA: 0x00230AB0 File Offset: 0x0022FAB0
		internal void a(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(PageFontList.e);
				A_0.WriteDictionaryOpen();
				this.DrawEntries(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x060043AB RID: 17323 RVA: 0x00230AF0 File Offset: 0x0022FAF0
		public void DrawEntries(DocumentWriter writer)
		{
			int num = this.c;
			foreach (object obj in this.a)
			{
				Resource resource = (Resource)obj;
				writer.WriteName(70, num++);
				if (resource.ResourceType == ResourceType.Font)
				{
					((Font)resource).bj(writer);
				}
			}
		}

		// Token: 0x040025B6 RID: 9654
		private ArrayList a = null;

		// Token: 0x040025B7 RID: 9655
		private Hashtable b = null;

		// Token: 0x040025B8 RID: 9656
		private int c = 0;

		// Token: 0x040025B9 RID: 9657
		private static byte[] d = new byte[]
		{
			47,
			70
		};

		// Token: 0x040025BA RID: 9658
		private static byte[] e = new byte[]
		{
			70,
			111,
			110,
			116
		};
	}
}
