using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006AC RID: 1708
	public class Prepress
	{
		// Token: 0x0600409F RID: 16543 RVA: 0x002228FB File Offset: 0x002218FB
		internal Prepress(Document A_0)
		{
			this.a = A_0;
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x060040A0 RID: 16544 RVA: 0x00222914 File Offset: 0x00221914
		// (set) Token: 0x060040A1 RID: 16545 RVA: 0x00222931 File Offset: 0x00221931
		public PdfXVersion PdfXVersion
		{
			get
			{
				return this.a.PdfXVersion;
			}
			set
			{
				this.a.PdfXVersion = value;
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x060040A2 RID: 16546 RVA: 0x00222944 File Offset: 0x00221944
		// (set) Token: 0x060040A3 RID: 16547 RVA: 0x00222961 File Offset: 0x00221961
		public Trapped Trapped
		{
			get
			{
				return this.a.Trapped;
			}
			set
			{
				this.a.Trapped = value;
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x060040A4 RID: 16548 RVA: 0x00222974 File Offset: 0x00221974
		public OutputIntentList OutputIntents
		{
			get
			{
				return this.a.OutputIntents;
			}
		}

		// Token: 0x040023FD RID: 9213
		private Document a = null;
	}
}
