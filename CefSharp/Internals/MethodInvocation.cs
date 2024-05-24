using System;
using System.Collections.Generic;

namespace CefSharp.Internals
{
	// Token: 0x020000DD RID: 221
	public sealed class MethodInvocation
	{
		// Token: 0x17000206 RID: 518
		// (get) Token: 0x060006B0 RID: 1712 RVA: 0x0000AF35 File Offset: 0x00009135
		// (set) Token: 0x060006B1 RID: 1713 RVA: 0x0000AF3D File Offset: 0x0000913D
		public int BrowserId { get; private set; }

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x060006B2 RID: 1714 RVA: 0x0000AF46 File Offset: 0x00009146
		// (set) Token: 0x060006B3 RID: 1715 RVA: 0x0000AF4E File Offset: 0x0000914E
		public long FrameId { get; private set; }

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060006B4 RID: 1716 RVA: 0x0000AF57 File Offset: 0x00009157
		// (set) Token: 0x060006B5 RID: 1717 RVA: 0x0000AF5F File Offset: 0x0000915F
		public long? CallbackId { get; private set; }

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060006B6 RID: 1718 RVA: 0x0000AF68 File Offset: 0x00009168
		// (set) Token: 0x060006B7 RID: 1719 RVA: 0x0000AF70 File Offset: 0x00009170
		public long ObjectId { get; private set; }

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060006B8 RID: 1720 RVA: 0x0000AF79 File Offset: 0x00009179
		// (set) Token: 0x060006B9 RID: 1721 RVA: 0x0000AF81 File Offset: 0x00009181
		public string MethodName { get; private set; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x060006BA RID: 1722 RVA: 0x0000AF8A File Offset: 0x0000918A
		public List<object> Parameters
		{
			get
			{
				return this.parameters;
			}
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0000AF92 File Offset: 0x00009192
		public MethodInvocation(int browserId, long frameId, long objectId, string methodName, long? callbackId)
		{
			this.BrowserId = browserId;
			this.FrameId = frameId;
			this.CallbackId = callbackId;
			this.ObjectId = objectId;
			this.MethodName = methodName;
		}

		// Token: 0x04000371 RID: 881
		private readonly List<object> parameters = new List<object>();
	}
}
