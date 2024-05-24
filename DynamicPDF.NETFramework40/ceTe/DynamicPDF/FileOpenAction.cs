using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200065A RID: 1626
	public class FileOpenAction : OutlineAnnotationAction
	{
		// Token: 0x06003D82 RID: 15746 RVA: 0x002158BB File Offset: 0x002148BB
		public FileOpenAction(string filePath) : this(filePath, FileLaunchMode.UserPreference)
		{
		}

		// Token: 0x06003D83 RID: 15747 RVA: 0x002158C8 File Offset: 0x002148C8
		public FileOpenAction(string filePath, FileLaunchMode mode)
		{
			this.b = filePath;
			this.a = mode;
			string text = filePath.Trim();
			text = "/" + text;
			int num = text.IndexOf(':');
			if (num != -1)
			{
				this.c = text.Substring(0, num);
				this.c += text.Substring(num + 1);
			}
			else
			{
				this.c = text;
			}
			this.c = this.c.Replace('\\', '/');
		}

		// Token: 0x06003D84 RID: 15748 RVA: 0x00215970 File Offset: 0x00214970
		public override void Draw(DocumentWriter writer)
		{
			writer.Document.RequireLicense(3);
			writer.WriteReferenceUnique(new by(this));
		}

		// Token: 0x06003D85 RID: 15749 RVA: 0x00215990 File Offset: 0x00214990
		internal new string a()
		{
			return this.c;
		}

		// Token: 0x06003D86 RID: 15750 RVA: 0x002159A8 File Offset: 0x002149A8
		internal new FileLaunchMode b()
		{
			return this.a;
		}

		// Token: 0x04002129 RID: 8489
		private new FileLaunchMode a;

		// Token: 0x0400212A RID: 8490
		private new string b = "";

		// Token: 0x0400212B RID: 8491
		private new string c = "";
	}
}
