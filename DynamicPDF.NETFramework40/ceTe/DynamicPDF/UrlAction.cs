using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006B9 RID: 1721
	public class UrlAction : OutlineAnnotationAction
	{
		// Token: 0x0600425A RID: 16986 RVA: 0x00228C30 File Offset: 0x00227C30
		public UrlAction(string url)
		{
			this.a = url;
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x0600425B RID: 16987 RVA: 0x00228C44 File Offset: 0x00227C44
		// (set) Token: 0x0600425C RID: 16988 RVA: 0x00228C5C File Offset: 0x00227C5C
		public string URL
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x0600425D RID: 16989 RVA: 0x00228C68 File Offset: 0x00227C68
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteDictionaryOpen();
			writer.WriteName(Action.a);
			writer.WriteName(UrlAction.b);
			writer.WriteName(83);
			writer.WriteName(UrlAction.c);
			writer.WriteName(UrlAction.c);
			writer.WriteText(this.a);
			if (base.NextAction != null)
			{
				writer.WriteName(Action.d);
				base.NextAction.Draw(writer);
			}
			writer.WriteDictionaryClose();
		}

		// Token: 0x040024D0 RID: 9424
		private new string a;

		// Token: 0x040024D1 RID: 9425
		private new static byte[] b = new byte[]
		{
			65,
			99,
			116,
			105,
			111,
			110
		};

		// Token: 0x040024D2 RID: 9426
		private new static byte[] c = new byte[]
		{
			85,
			82,
			73
		};
	}
}
