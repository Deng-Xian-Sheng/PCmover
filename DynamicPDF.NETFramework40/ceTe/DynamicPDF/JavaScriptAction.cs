using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200069E RID: 1694
	public class JavaScriptAction : OutlineAnnotationAction
	{
		// Token: 0x06004062 RID: 16482 RVA: 0x0022183C File Offset: 0x0022083C
		public JavaScriptAction(string javaScript)
		{
			this.a = javaScript;
		}

		// Token: 0x06004063 RID: 16483 RVA: 0x00221850 File Offset: 0x00220850
		internal new string a()
		{
			return this.a;
		}

		// Token: 0x06004064 RID: 16484 RVA: 0x00221868 File Offset: 0x00220868
		public override void Draw(DocumentWriter writer)
		{
			writer.Document.RequireLicense(3);
			writer.WriteReferenceUnique(new JavaScriptResource(this));
		}

		// Token: 0x040023B3 RID: 9139
		private new string a;
	}
}
