using System;
using System.Collections.Generic;
using System.Linq;
using Laplink.Pcmover.Contracts;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x02000003 RID: 3
	public class ActivityClients : List<ActivityClient>
	{
		// Token: 0x06000028 RID: 40 RVA: 0x0000261F File Offset: 0x0000081F
		public ActivityClients(IPcmoverClientEngine engine)
		{
			this._engine = engine;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002630 File Offset: 0x00000830
		public T FindByType<T>()
		{
			T result;
			lock (this)
			{
				result = this.OfType<T>().FirstOrDefault<T>();
			}
			return result;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002674 File Offset: 0x00000874
		public ActivityClient FindByHandle(int handle)
		{
			ActivityClient result;
			lock (this)
			{
				result = base.Find((ActivityClient client) => client.Handle == handle);
			}
			return result;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000026CC File Offset: 0x000008CC
		public ActivityClient FindByActivityType(ActivityType type)
		{
			ActivityClient result;
			lock (this)
			{
				result = base.Find((ActivityClient client) => client.Type == type);
			}
			return result;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002724 File Offset: 0x00000924
		public bool OnProgress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			ActivityClient activityClient = this.FindByHandle(activityInfo.Handle);
			if (activityClient == null)
			{
				return false;
			}
			activityClient.OnProgress(activityInfo, progressInfo);
			return true;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000274C File Offset: 0x0000094C
		public bool OnActivityInfoChanged(ActivityInfo info)
		{
			ActivityClient activityClient = this.FindByHandle(info.Handle);
			if (activityClient == null)
			{
				IPcmoverClientEngine engine = this._engine;
				if (engine != null)
				{
					engine.FireActivityInfoEvent(info);
				}
				return false;
			}
			activityClient.OnActivityInfoChanged(info);
			return true;
		}

		// Token: 0x0400000E RID: 14
		private IPcmoverClientEngine _engine;
	}
}
