using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x02000197 RID: 407
	public enum PlayerErrorType
	{
		// Token: 0x0400064C RID: 1612
		[EnumMember(Value = "pipeline_error")]
		PipelineError,
		// Token: 0x0400064D RID: 1613
		[EnumMember(Value = "media_error")]
		MediaError
	}
}
