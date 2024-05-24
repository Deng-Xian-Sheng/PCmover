using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Security.Principal
{
	// Token: 0x0200033D RID: 829
	[ComVisible(false)]
	[Serializable]
	public sealed class IdentityNotMappedException : SystemException
	{
		// Token: 0x06002951 RID: 10577 RVA: 0x00098D7C File Offset: 0x00096F7C
		public IdentityNotMappedException() : base(Environment.GetResourceString("IdentityReference_IdentityNotMapped"))
		{
		}

		// Token: 0x06002952 RID: 10578 RVA: 0x00098D8E File Offset: 0x00096F8E
		public IdentityNotMappedException(string message) : base(message)
		{
		}

		// Token: 0x06002953 RID: 10579 RVA: 0x00098D97 File Offset: 0x00096F97
		public IdentityNotMappedException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06002954 RID: 10580 RVA: 0x00098DA1 File Offset: 0x00096FA1
		internal IdentityNotMappedException(string message, IdentityReferenceCollection unmappedIdentities) : this(message)
		{
			this.unmappedIdentities = unmappedIdentities;
		}

		// Token: 0x06002955 RID: 10581 RVA: 0x00098DB1 File Offset: 0x00096FB1
		internal IdentityNotMappedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06002956 RID: 10582 RVA: 0x00098DBB File Offset: 0x00096FBB
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			base.GetObjectData(serializationInfo, streamingContext);
		}

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06002957 RID: 10583 RVA: 0x00098DC5 File Offset: 0x00096FC5
		public IdentityReferenceCollection UnmappedIdentities
		{
			get
			{
				if (this.unmappedIdentities == null)
				{
					this.unmappedIdentities = new IdentityReferenceCollection();
				}
				return this.unmappedIdentities;
			}
		}

		// Token: 0x040010FF RID: 4351
		private IdentityReferenceCollection unmappedIdentities;
	}
}
