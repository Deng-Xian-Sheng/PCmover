using System;

namespace System.Runtime.ExceptionServices
{
	// Token: 0x020007A9 RID: 1961
	[__DynamicallyInvokable]
	public sealed class ExceptionDispatchInfo
	{
		// Token: 0x060054FE RID: 21758 RVA: 0x0012E174 File Offset: 0x0012C374
		private ExceptionDispatchInfo(Exception exception)
		{
			this.m_Exception = exception;
			this.m_remoteStackTrace = exception.RemoteStackTrace;
			object stackTrace;
			object dynamicMethods;
			this.m_Exception.GetStackTracesDeepCopy(out stackTrace, out dynamicMethods);
			this.m_stackTrace = stackTrace;
			this.m_dynamicMethods = dynamicMethods;
			this.m_IPForWatsonBuckets = exception.IPForWatsonBuckets;
			this.m_WatsonBuckets = exception.WatsonBuckets;
		}

		// Token: 0x17000DF0 RID: 3568
		// (get) Token: 0x060054FF RID: 21759 RVA: 0x0012E1CF File Offset: 0x0012C3CF
		internal UIntPtr IPForWatsonBuckets
		{
			get
			{
				return this.m_IPForWatsonBuckets;
			}
		}

		// Token: 0x17000DF1 RID: 3569
		// (get) Token: 0x06005500 RID: 21760 RVA: 0x0012E1D7 File Offset: 0x0012C3D7
		internal object WatsonBuckets
		{
			get
			{
				return this.m_WatsonBuckets;
			}
		}

		// Token: 0x17000DF2 RID: 3570
		// (get) Token: 0x06005501 RID: 21761 RVA: 0x0012E1DF File Offset: 0x0012C3DF
		internal object BinaryStackTraceArray
		{
			get
			{
				return this.m_stackTrace;
			}
		}

		// Token: 0x17000DF3 RID: 3571
		// (get) Token: 0x06005502 RID: 21762 RVA: 0x0012E1E7 File Offset: 0x0012C3E7
		internal object DynamicMethodArray
		{
			get
			{
				return this.m_dynamicMethods;
			}
		}

		// Token: 0x17000DF4 RID: 3572
		// (get) Token: 0x06005503 RID: 21763 RVA: 0x0012E1EF File Offset: 0x0012C3EF
		internal string RemoteStackTrace
		{
			get
			{
				return this.m_remoteStackTrace;
			}
		}

		// Token: 0x06005504 RID: 21764 RVA: 0x0012E1F7 File Offset: 0x0012C3F7
		[__DynamicallyInvokable]
		public static ExceptionDispatchInfo Capture(Exception source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source", Environment.GetResourceString("ArgumentNull_Obj"));
			}
			return new ExceptionDispatchInfo(source);
		}

		// Token: 0x17000DF5 RID: 3573
		// (get) Token: 0x06005505 RID: 21765 RVA: 0x0012E217 File Offset: 0x0012C417
		[__DynamicallyInvokable]
		public Exception SourceException
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Exception;
			}
		}

		// Token: 0x06005506 RID: 21766 RVA: 0x0012E21F File Offset: 0x0012C41F
		[__DynamicallyInvokable]
		public void Throw()
		{
			this.m_Exception.RestoreExceptionDispatchInfo(this);
			throw this.m_Exception;
		}

		// Token: 0x04002719 RID: 10009
		private Exception m_Exception;

		// Token: 0x0400271A RID: 10010
		private string m_remoteStackTrace;

		// Token: 0x0400271B RID: 10011
		private object m_stackTrace;

		// Token: 0x0400271C RID: 10012
		private object m_dynamicMethods;

		// Token: 0x0400271D RID: 10013
		private UIntPtr m_IPForWatsonBuckets;

		// Token: 0x0400271E RID: 10014
		private object m_WatsonBuckets;
	}
}
