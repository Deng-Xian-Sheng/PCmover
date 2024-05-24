using System;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009AC RID: 2476
	[SecurityCritical]
	internal class ComEventsInfo
	{
		// Token: 0x0600630D RID: 25357 RVA: 0x00151B44 File Offset: 0x0014FD44
		private ComEventsInfo(object rcw)
		{
			this._rcw = rcw;
		}

		// Token: 0x0600630E RID: 25358 RVA: 0x00151B54 File Offset: 0x0014FD54
		[SecuritySafeCritical]
		~ComEventsInfo()
		{
			this._sinks = ComEventsSink.RemoveAll(this._sinks);
		}

		// Token: 0x0600630F RID: 25359 RVA: 0x00151B8C File Offset: 0x0014FD8C
		[SecurityCritical]
		internal static ComEventsInfo Find(object rcw)
		{
			return (ComEventsInfo)Marshal.GetComObjectData(rcw, typeof(ComEventsInfo));
		}

		// Token: 0x06006310 RID: 25360 RVA: 0x00151BA4 File Offset: 0x0014FDA4
		[SecurityCritical]
		internal static ComEventsInfo FromObject(object rcw)
		{
			ComEventsInfo comEventsInfo = ComEventsInfo.Find(rcw);
			if (comEventsInfo == null)
			{
				comEventsInfo = new ComEventsInfo(rcw);
				Marshal.SetComObjectData(rcw, typeof(ComEventsInfo), comEventsInfo);
			}
			return comEventsInfo;
		}

		// Token: 0x06006311 RID: 25361 RVA: 0x00151BD5 File Offset: 0x0014FDD5
		internal ComEventsSink FindSink(ref Guid iid)
		{
			return ComEventsSink.Find(this._sinks, ref iid);
		}

		// Token: 0x06006312 RID: 25362 RVA: 0x00151BE4 File Offset: 0x0014FDE4
		internal ComEventsSink AddSink(ref Guid iid)
		{
			ComEventsSink sink = new ComEventsSink(this._rcw, iid);
			this._sinks = ComEventsSink.Add(this._sinks, sink);
			return this._sinks;
		}

		// Token: 0x06006313 RID: 25363 RVA: 0x00151C1B File Offset: 0x0014FE1B
		[SecurityCritical]
		internal ComEventsSink RemoveSink(ComEventsSink sink)
		{
			this._sinks = ComEventsSink.Remove(this._sinks, sink);
			return this._sinks;
		}

		// Token: 0x04002CAE RID: 11438
		private ComEventsSink _sinks;

		// Token: 0x04002CAF RID: 11439
		private object _rcw;
	}
}
