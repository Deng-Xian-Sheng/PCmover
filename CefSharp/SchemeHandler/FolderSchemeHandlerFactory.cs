using System;
using System.IO;
using System.Net;

namespace CefSharp.SchemeHandler
{
	// Token: 0x020000AC RID: 172
	public class FolderSchemeHandlerFactory : ISchemeHandlerFactory
	{
		// Token: 0x06000556 RID: 1366 RVA: 0x00008454 File Offset: 0x00006654
		public FolderSchemeHandlerFactory(string rootFolder, string schemeName = null, string hostName = null, string defaultPage = "index.html", FileShare resourceFileShare = FileShare.Read)
		{
			this.rootFolder = Path.GetFullPath(rootFolder);
			this.defaultPage = defaultPage;
			this.schemeName = schemeName;
			this.hostName = hostName;
			this.resourceFileShare = resourceFileShare;
			if (!Directory.Exists(this.rootFolder))
			{
				throw new DirectoryNotFoundException(this.rootFolder);
			}
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x000084AA File Offset: 0x000066AA
		IResourceHandler ISchemeHandlerFactory.Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
		{
			return this.Create(browser, frame, schemeName, request);
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x000084B8 File Offset: 0x000066B8
		protected virtual IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
		{
			if (this.schemeName != null && !schemeName.Equals(this.schemeName, StringComparison.OrdinalIgnoreCase))
			{
				return ResourceHandler.ForErrorMessage(string.Format("SchemeName {0} does not match the expected SchemeName of {1}.", schemeName, this.schemeName), HttpStatusCode.NotFound);
			}
			Uri uri = new Uri(request.Url);
			if (this.hostName != null && !uri.Host.Equals(this.hostName, StringComparison.OrdinalIgnoreCase))
			{
				return ResourceHandler.ForErrorMessage(string.Format("HostName {0} does not match the expected HostName of {1}.", uri.Host, this.hostName), HttpStatusCode.NotFound);
			}
			string text = uri.AbsolutePath.Substring(1);
			if (string.IsNullOrEmpty(text))
			{
				text = this.defaultPage;
			}
			string text2 = WebUtility.UrlDecode(Path.GetFullPath(Path.Combine(this.rootFolder, text)));
			if (text2.StartsWith(this.rootFolder, StringComparison.OrdinalIgnoreCase) && File.Exists(text2))
			{
				string extension = Path.GetExtension(text2);
				string mimeType = FolderSchemeHandlerFactory.GetMimeTypeDelegate(extension);
				FileStream stream = new FileStream(text2, FileMode.Open, FileAccess.Read, this.resourceFileShare);
				return ResourceHandler.FromStream(stream, mimeType, false, null);
			}
			return ResourceHandler.ForErrorMessage("File Not Found - " + text2, HttpStatusCode.NotFound);
		}

		// Token: 0x04000307 RID: 775
		private readonly string rootFolder;

		// Token: 0x04000308 RID: 776
		private readonly string defaultPage;

		// Token: 0x04000309 RID: 777
		private readonly string schemeName;

		// Token: 0x0400030A RID: 778
		private readonly string hostName;

		// Token: 0x0400030B RID: 779
		private readonly FileShare resourceFileShare;

		// Token: 0x0400030C RID: 780
		public static Func<string, string> GetMimeTypeDelegate = (string s) => ResourceHandler.GetMimeType(s);
	}
}
