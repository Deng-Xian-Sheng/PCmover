using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Media
{
	// Token: 0x0200019E RID: 414
	public class MediaClient : DevToolsDomainBase
	{
		// Token: 0x06000C05 RID: 3077 RVA: 0x0001131A File Offset: 0x0000F51A
		public MediaClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000C06 RID: 3078 RVA: 0x00011329 File Offset: 0x0000F529
		// (remove) Token: 0x06000C07 RID: 3079 RVA: 0x0001133C File Offset: 0x0000F53C
		public event EventHandler<PlayerPropertiesChangedEventArgs> PlayerPropertiesChanged
		{
			add
			{
				this._client.AddEventHandler<PlayerPropertiesChangedEventArgs>("Media.playerPropertiesChanged", value);
			}
			remove
			{
				this._client.RemoveEventHandler<PlayerPropertiesChangedEventArgs>("Media.playerPropertiesChanged", value);
			}
		}

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06000C08 RID: 3080 RVA: 0x00011350 File Offset: 0x0000F550
		// (remove) Token: 0x06000C09 RID: 3081 RVA: 0x00011363 File Offset: 0x0000F563
		public event EventHandler<PlayerEventsAddedEventArgs> PlayerEventsAdded
		{
			add
			{
				this._client.AddEventHandler<PlayerEventsAddedEventArgs>("Media.playerEventsAdded", value);
			}
			remove
			{
				this._client.RemoveEventHandler<PlayerEventsAddedEventArgs>("Media.playerEventsAdded", value);
			}
		}

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06000C0A RID: 3082 RVA: 0x00011377 File Offset: 0x0000F577
		// (remove) Token: 0x06000C0B RID: 3083 RVA: 0x0001138A File Offset: 0x0000F58A
		public event EventHandler<PlayerMessagesLoggedEventArgs> PlayerMessagesLogged
		{
			add
			{
				this._client.AddEventHandler<PlayerMessagesLoggedEventArgs>("Media.playerMessagesLogged", value);
			}
			remove
			{
				this._client.RemoveEventHandler<PlayerMessagesLoggedEventArgs>("Media.playerMessagesLogged", value);
			}
		}

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06000C0C RID: 3084 RVA: 0x0001139E File Offset: 0x0000F59E
		// (remove) Token: 0x06000C0D RID: 3085 RVA: 0x000113B1 File Offset: 0x0000F5B1
		public event EventHandler<PlayerErrorsRaisedEventArgs> PlayerErrorsRaised
		{
			add
			{
				this._client.AddEventHandler<PlayerErrorsRaisedEventArgs>("Media.playerErrorsRaised", value);
			}
			remove
			{
				this._client.RemoveEventHandler<PlayerErrorsRaisedEventArgs>("Media.playerErrorsRaised", value);
			}
		}

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x06000C0E RID: 3086 RVA: 0x000113C5 File Offset: 0x0000F5C5
		// (remove) Token: 0x06000C0F RID: 3087 RVA: 0x000113D8 File Offset: 0x0000F5D8
		public event EventHandler<PlayersCreatedEventArgs> PlayersCreated
		{
			add
			{
				this._client.AddEventHandler<PlayersCreatedEventArgs>("Media.playersCreated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<PlayersCreatedEventArgs>("Media.playersCreated", value);
			}
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x000113EC File Offset: 0x0000F5EC
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Media.enable", parameters);
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x0001140C File Offset: 0x0000F60C
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Media.disable", parameters);
		}

		// Token: 0x04000659 RID: 1625
		private IDevToolsClient _client;
	}
}
