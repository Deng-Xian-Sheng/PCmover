using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.IO.IsolatedStorage
{
	// Token: 0x020001B1 RID: 433
	[ComVisible(true)]
	[Serializable]
	public class IsolatedStorageException : Exception
	{
		// Token: 0x06001B4B RID: 6987 RVA: 0x0005C906 File Offset: 0x0005AB06
		public IsolatedStorageException() : base(Environment.GetResourceString("IsolatedStorage_Exception"))
		{
			base.SetErrorCode(-2146233264);
		}

		// Token: 0x06001B4C RID: 6988 RVA: 0x0005C923 File Offset: 0x0005AB23
		public IsolatedStorageException(string message) : base(message)
		{
			base.SetErrorCode(-2146233264);
		}

		// Token: 0x06001B4D RID: 6989 RVA: 0x0005C937 File Offset: 0x0005AB37
		public IsolatedStorageException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233264);
		}

		// Token: 0x06001B4E RID: 6990 RVA: 0x0005C94C File Offset: 0x0005AB4C
		protected IsolatedStorageException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
