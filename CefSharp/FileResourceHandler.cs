using System;
using System.IO;
using CefSharp.Callback;

namespace CefSharp
{
	// Token: 0x02000072 RID: 114
	public class FileResourceHandler : IResourceHandler, IDisposable
	{
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x000036D5 File Offset: 0x000018D5
		// (set) Token: 0x060002DA RID: 730 RVA: 0x000036DD File Offset: 0x000018DD
		public string FilePath { get; private set; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060002DB RID: 731 RVA: 0x000036E6 File Offset: 0x000018E6
		// (set) Token: 0x060002DC RID: 732 RVA: 0x000036EE File Offset: 0x000018EE
		public string MimeType { get; set; }

		// Token: 0x060002DD RID: 733 RVA: 0x000036F8 File Offset: 0x000018F8
		public FileResourceHandler(string mimeType, string filePath)
		{
			if (string.IsNullOrEmpty(mimeType))
			{
				throw new ArgumentNullException("mimeType", "Please provide a valid mimeType");
			}
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException("filePath", "Please provide a valid filePath");
			}
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("Unable to create FileResourceHandler", filePath);
			}
			this.MimeType = mimeType;
			this.FilePath = filePath;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000375D File Offset: 0x0000195D
		bool IResourceHandler.ProcessRequest(IRequest request, ICallback callback)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00003769 File Offset: 0x00001969
		void IResourceHandler.GetResponseHeaders(IResponse response, out long responseLength, out string redirectUrl)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00003775 File Offset: 0x00001975
		bool IResourceHandler.ReadResponse(Stream dataOut, out int bytesRead, ICallback callback)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00003781 File Offset: 0x00001981
		void IResourceHandler.Cancel()
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000378D File Offset: 0x0000198D
		bool IResourceHandler.Open(IRequest request, out bool handleRequest, ICallback callback)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00003799 File Offset: 0x00001999
		bool IResourceHandler.Skip(long bytesToSkip, out long bytesSkipped, IResourceSkipCallback callback)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000037A5 File Offset: 0x000019A5
		bool IResourceHandler.Read(Stream dataOut, out int bytesRead, IResourceReadCallback callback)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000037B1 File Offset: 0x000019B1
		void IDisposable.Dispose()
		{
		}
	}
}
