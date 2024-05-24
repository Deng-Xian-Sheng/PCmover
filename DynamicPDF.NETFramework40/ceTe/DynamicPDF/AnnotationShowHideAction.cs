using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000639 RID: 1593
	public class AnnotationShowHideAction : OutlineAnnotationAction
	{
		// Token: 0x06003B81 RID: 15233 RVA: 0x001FC6FA File Offset: 0x001FB6FA
		public AnnotationShowHideAction(string fieldName)
		{
			this.b = fieldName;
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06003B82 RID: 15234 RVA: 0x001FC72C File Offset: 0x001FB72C
		// (set) Token: 0x06003B83 RID: 15235 RVA: 0x001FC744 File Offset: 0x001FB744
		public bool ShowField
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x06003B84 RID: 15236 RVA: 0x001FC750 File Offset: 0x001FB750
		public override void Draw(DocumentWriter writer)
		{
			writer.Document.RequireLicense(3);
			writer.WriteDictionaryOpen();
			writer.WriteName(83);
			writer.WriteName(this.a);
			writer.WriteName(84);
			writer.WriteText(this.b);
			if (this.c)
			{
				writer.WriteName(72);
				writer.WriteBoolean(false);
			}
			if (base.NextAction != null)
			{
				writer.WriteName(Action.d);
				base.NextAction.Draw(writer);
			}
			writer.WriteDictionaryClose();
		}

		// Token: 0x0400207F RID: 8319
		private new byte[] a = new byte[]
		{
			72,
			105,
			100,
			101
		};

		// Token: 0x04002080 RID: 8320
		private new string b;

		// Token: 0x04002081 RID: 8321
		private new bool c = false;
	}
}
