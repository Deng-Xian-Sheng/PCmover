using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x020003B4 RID: 948
	public class DocumentJavaScript
	{
		// Token: 0x06002824 RID: 10276 RVA: 0x00174FA9 File Offset: 0x00173FA9
		public DocumentJavaScript(string name, string javaScript)
		{
			this.a = new aci(name);
			this.b = javaScript;
		}

		// Token: 0x06002825 RID: 10277 RVA: 0x00174FC7 File Offset: 0x00173FC7
		internal DocumentJavaScript(aci A_0)
		{
			this.a = A_0;
			this.b = null;
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06002826 RID: 10278 RVA: 0x00174FE0 File Offset: 0x00173FE0
		public string Name
		{
			get
			{
				return this.a.a();
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06002827 RID: 10279 RVA: 0x00175000 File Offset: 0x00174000
		// (set) Token: 0x06002828 RID: 10280 RVA: 0x00175018 File Offset: 0x00174018
		public virtual string JavaScript
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x06002829 RID: 10281 RVA: 0x00175022 File Offset: 0x00174022
		public virtual void DrawReference(DocumentWriter writer)
		{
			writer.WriteReferenceUnique(new JavaScriptResource(this.b));
		}

		// Token: 0x0600282A RID: 10282 RVA: 0x00175038 File Offset: 0x00174038
		internal aci b()
		{
			return this.a;
		}

		// Token: 0x0600282B RID: 10283 RVA: 0x00175050 File Offset: 0x00174050
		internal void a(DocumentWriter A_0)
		{
			this.a.a(A_0);
			this.DrawReference(A_0);
		}

		// Token: 0x0600282C RID: 10284 RVA: 0x00175068 File Offset: 0x00174068
		internal bool a(DocumentJavaScript A_0)
		{
			return this.a.a(A_0.a);
		}

		// Token: 0x040011A6 RID: 4518
		private aci a;

		// Token: 0x040011A7 RID: 4519
		private string b;
	}
}
