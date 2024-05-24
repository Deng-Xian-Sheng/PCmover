using System;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000875 RID: 2165
	internal class SmuggledObjRef
	{
		// Token: 0x06005C2A RID: 23594 RVA: 0x00143184 File Offset: 0x00141384
		[SecurityCritical]
		public SmuggledObjRef(ObjRef objRef)
		{
			this._objRef = objRef;
		}

		// Token: 0x17000FD8 RID: 4056
		// (get) Token: 0x06005C2B RID: 23595 RVA: 0x00143193 File Offset: 0x00141393
		public ObjRef ObjRef
		{
			[SecurityCritical]
			get
			{
				return this._objRef;
			}
		}

		// Token: 0x04002997 RID: 10647
		[SecurityCritical]
		private ObjRef _objRef;
	}
}
