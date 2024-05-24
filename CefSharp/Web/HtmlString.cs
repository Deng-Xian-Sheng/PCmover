using System;
using System.IO;
using System.Text;

namespace CefSharp.Web
{
	// Token: 0x020000A1 RID: 161
	public class HtmlString
	{
		// Token: 0x060004F8 RID: 1272 RVA: 0x00007F1F File Offset: 0x0000611F
		public HtmlString(string html, bool base64Encode = false, string charSet = null)
		{
			this.base64Encode = base64Encode;
			this.html = html;
			this.charSet = charSet;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00007F3C File Offset: 0x0000613C
		public string ToDataUriString()
		{
			string str = "data:text/html";
			if (!string.IsNullOrEmpty(this.charSet))
			{
				str = str + ";charset=" + this.charSet;
			}
			if (this.base64Encode)
			{
				string str2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(this.html));
				return str + ";base64," + str2;
			}
			string str3 = Uri.EscapeDataString(this.html);
			return str + "," + str3;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00007FB1 File Offset: 0x000061B1
		public static explicit operator HtmlString(string html)
		{
			return new HtmlString(html, true, null);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00007FBC File Offset: 0x000061BC
		public static HtmlString FromFile(string fileName)
		{
			string text = File.ReadAllText(fileName, Encoding.UTF8);
			return (HtmlString)text;
		}

		// Token: 0x040002DD RID: 733
		private readonly string html;

		// Token: 0x040002DE RID: 734
		private readonly bool base64Encode;

		// Token: 0x040002DF RID: 735
		private readonly string charSet;
	}
}
