using System;

namespace PCmover.Infrastructure
{
	// Token: 0x02000014 RID: 20
	[Serializable]
	public class EmaException : Exception
	{
		// Token: 0x06000108 RID: 264 RVA: 0x00004DC2 File Offset: 0x00002FC2
		public EmaException()
		{
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00004DCA File Offset: 0x00002FCA
		public EmaException(string message) : base(message)
		{
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00004DD3 File Offset: 0x00002FD3
		public EmaException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
