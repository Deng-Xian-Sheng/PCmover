using System;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006DD RID: 1757
	public class PageResources
	{
		// Token: 0x060043BB RID: 17339 RVA: 0x00230FE4 File Offset: 0x0022FFE4
		internal PageResources()
		{
			this.a = new PageXObjectList();
			this.b = new PageFontList();
			this.c = new PageShadingList();
			this.d = new PageColorSpaceList();
			this.e = new PagePatternList();
			this.f = new PagePropertiesList();
			this.g = new PageExtGStateList();
		}

		// Token: 0x060043BC RID: 17340 RVA: 0x00231048 File Offset: 0x00230048
		public void Draw(DocumentWriter writer)
		{
			writer.WriteName(PageResources.h);
			writer.WriteDictionaryOpen();
			writer.WriteName(PageResources.i);
			writer.WriteArrayOpen();
			writer.WriteName(PageResources.j);
			writer.WriteName(PageResources.k);
			writer.WriteName(PageResources.l);
			writer.WriteName(PageResources.m);
			writer.WriteName(PageResources.n);
			writer.WriteArrayClose();
			this.b.a(writer);
			this.a.a(writer);
			this.g.a(writer);
			this.c.a(writer);
			this.d.a(writer);
			this.e.a(writer);
			this.f.a(writer);
			writer.WriteDictionaryClose();
		}

		// Token: 0x060043BD RID: 17341 RVA: 0x00231124 File Offset: 0x00230124
		public void SetStartingNameNumber(int startingNameNumber)
		{
			this.b.SetStartingNameNumber(startingNameNumber);
			this.a.SetStartingNameNumber(startingNameNumber);
			this.g.SetStartingNameNumber(startingNameNumber);
			this.c.SetStartingNameNumber(startingNameNumber);
			this.d.SetStartingNameNumber(startingNameNumber);
			this.e.SetStartingNameNumber(startingNameNumber);
			this.f.SetStartingNameNumber(startingNameNumber);
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x060043BE RID: 17342 RVA: 0x00231190 File Offset: 0x00230190
		public PageFontList Fonts
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x060043BF RID: 17343 RVA: 0x002311A8 File Offset: 0x002301A8
		public PageXObjectList XObjects
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x060043C0 RID: 17344 RVA: 0x002311C0 File Offset: 0x002301C0
		public PageShadingList Shadings
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x060043C1 RID: 17345 RVA: 0x002311D8 File Offset: 0x002301D8
		public PageColorSpaceList ColorSpaces
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x060043C2 RID: 17346 RVA: 0x002311F0 File Offset: 0x002301F0
		public PagePatternList Patterns
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x060043C3 RID: 17347 RVA: 0x00231208 File Offset: 0x00230208
		public PagePropertiesList Properties
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x060043C4 RID: 17348 RVA: 0x00231220 File Offset: 0x00230220
		public PageExtGStateList ExtGStates
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x040025C5 RID: 9669
		private PageXObjectList a;

		// Token: 0x040025C6 RID: 9670
		private PageFontList b;

		// Token: 0x040025C7 RID: 9671
		private PageShadingList c;

		// Token: 0x040025C8 RID: 9672
		private PageColorSpaceList d;

		// Token: 0x040025C9 RID: 9673
		private PagePatternList e;

		// Token: 0x040025CA RID: 9674
		private PagePropertiesList f;

		// Token: 0x040025CB RID: 9675
		private PageExtGStateList g;

		// Token: 0x040025CC RID: 9676
		private static byte[] h = new byte[]
		{
			82,
			101,
			115,
			111,
			117,
			114,
			99,
			101,
			115
		};

		// Token: 0x040025CD RID: 9677
		private static byte[] i = new byte[]
		{
			80,
			114,
			111,
			99,
			83,
			101,
			116
		};

		// Token: 0x040025CE RID: 9678
		private static byte[] j = new byte[]
		{
			80,
			68,
			70
		};

		// Token: 0x040025CF RID: 9679
		private static byte[] k = new byte[]
		{
			73,
			109,
			97,
			103,
			101,
			67
		};

		// Token: 0x040025D0 RID: 9680
		private static byte[] l = new byte[]
		{
			73,
			109,
			97,
			103,
			101,
			73
		};

		// Token: 0x040025D1 RID: 9681
		private static byte[] m = new byte[]
		{
			73,
			109,
			97,
			103,
			101,
			66
		};

		// Token: 0x040025D2 RID: 9682
		private static byte[] n = new byte[]
		{
			84,
			101,
			120,
			116
		};
	}
}
