using System;
using System.Collections.Generic;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200042C RID: 1068
	internal class EtwSession
	{
		// Token: 0x06003555 RID: 13653 RVA: 0x000CEE6C File Offset: 0x000CD06C
		public static EtwSession GetEtwSession(int etwSessionId, bool bCreateIfNeeded = false)
		{
			if (etwSessionId < 0)
			{
				return null;
			}
			EtwSession etwSession;
			foreach (WeakReference<EtwSession> weakReference in EtwSession.s_etwSessions)
			{
				if (weakReference.TryGetTarget(out etwSession) && etwSession.m_etwSessionId == etwSessionId)
				{
					return etwSession;
				}
			}
			if (!bCreateIfNeeded)
			{
				return null;
			}
			if (EtwSession.s_etwSessions == null)
			{
				EtwSession.s_etwSessions = new List<WeakReference<EtwSession>>();
			}
			etwSession = new EtwSession(etwSessionId);
			EtwSession.s_etwSessions.Add(new WeakReference<EtwSession>(etwSession));
			if (EtwSession.s_etwSessions.Count > 16)
			{
				EtwSession.TrimGlobalList();
			}
			return etwSession;
		}

		// Token: 0x06003556 RID: 13654 RVA: 0x000CEF18 File Offset: 0x000CD118
		public static void RemoveEtwSession(EtwSession etwSession)
		{
			if (EtwSession.s_etwSessions == null || etwSession == null)
			{
				return;
			}
			EtwSession.s_etwSessions.RemoveAll(delegate(WeakReference<EtwSession> wrEtwSession)
			{
				EtwSession etwSession2;
				return wrEtwSession.TryGetTarget(out etwSession2) && etwSession2.m_etwSessionId == etwSession.m_etwSessionId;
			});
			if (EtwSession.s_etwSessions.Count > 16)
			{
				EtwSession.TrimGlobalList();
			}
		}

		// Token: 0x06003557 RID: 13655 RVA: 0x000CEF6C File Offset: 0x000CD16C
		private static void TrimGlobalList()
		{
			if (EtwSession.s_etwSessions == null)
			{
				return;
			}
			EtwSession.s_etwSessions.RemoveAll(delegate(WeakReference<EtwSession> wrEtwSession)
			{
				EtwSession etwSession;
				return !wrEtwSession.TryGetTarget(out etwSession);
			});
		}

		// Token: 0x06003558 RID: 13656 RVA: 0x000CEFA0 File Offset: 0x000CD1A0
		private EtwSession(int etwSessionId)
		{
			this.m_etwSessionId = etwSessionId;
		}

		// Token: 0x040017B3 RID: 6067
		public readonly int m_etwSessionId;

		// Token: 0x040017B4 RID: 6068
		public ActivityFilter m_activityFilter;

		// Token: 0x040017B5 RID: 6069
		private static List<WeakReference<EtwSession>> s_etwSessions = new List<WeakReference<EtwSession>>();

		// Token: 0x040017B6 RID: 6070
		private const int s_thrSessionCount = 16;
	}
}
