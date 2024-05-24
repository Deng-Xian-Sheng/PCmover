using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.WebAuthn
{
	// Token: 0x020001A7 RID: 423
	public class WebAuthnClient : DevToolsDomainBase
	{
		// Token: 0x06000C48 RID: 3144 RVA: 0x0001164D File Offset: 0x0000F84D
		public WebAuthnClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x0001165C File Offset: 0x0000F85C
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("WebAuthn.enable", parameters);
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x0001167C File Offset: 0x0000F87C
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("WebAuthn.disable", parameters);
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x0001169C File Offset: 0x0000F89C
		public Task<AddVirtualAuthenticatorResponse> AddVirtualAuthenticatorAsync(VirtualAuthenticatorOptions options)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("options", options.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<AddVirtualAuthenticatorResponse>("WebAuthn.addVirtualAuthenticator", dictionary);
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x000116D4 File Offset: 0x0000F8D4
		public Task<DevToolsMethodResponse> RemoveVirtualAuthenticatorAsync(string authenticatorId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("authenticatorId", authenticatorId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("WebAuthn.removeVirtualAuthenticator", dictionary);
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x00011704 File Offset: 0x0000F904
		public Task<DevToolsMethodResponse> AddCredentialAsync(string authenticatorId, Credential credential)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("authenticatorId", authenticatorId);
			dictionary.Add("credential", credential.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("WebAuthn.addCredential", dictionary);
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x00011748 File Offset: 0x0000F948
		public Task<GetCredentialResponse> GetCredentialAsync(string authenticatorId, byte[] credentialId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("authenticatorId", authenticatorId);
			dictionary.Add("credentialId", base.ToBase64String(credentialId));
			return this._client.ExecuteDevToolsMethodAsync<GetCredentialResponse>("WebAuthn.getCredential", dictionary);
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x0001178C File Offset: 0x0000F98C
		public Task<GetCredentialsResponse> GetCredentialsAsync(string authenticatorId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("authenticatorId", authenticatorId);
			return this._client.ExecuteDevToolsMethodAsync<GetCredentialsResponse>("WebAuthn.getCredentials", dictionary);
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x000117BC File Offset: 0x0000F9BC
		public Task<DevToolsMethodResponse> RemoveCredentialAsync(string authenticatorId, byte[] credentialId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("authenticatorId", authenticatorId);
			dictionary.Add("credentialId", base.ToBase64String(credentialId));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("WebAuthn.removeCredential", dictionary);
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x00011800 File Offset: 0x0000FA00
		public Task<DevToolsMethodResponse> ClearCredentialsAsync(string authenticatorId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("authenticatorId", authenticatorId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("WebAuthn.clearCredentials", dictionary);
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x00011830 File Offset: 0x0000FA30
		public Task<DevToolsMethodResponse> SetUserVerifiedAsync(string authenticatorId, bool isUserVerified)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("authenticatorId", authenticatorId);
			dictionary.Add("isUserVerified", isUserVerified);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("WebAuthn.setUserVerified", dictionary);
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x00011874 File Offset: 0x0000FA74
		public Task<DevToolsMethodResponse> SetAutomaticPresenceSimulationAsync(string authenticatorId, bool enabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("authenticatorId", authenticatorId);
			dictionary.Add("enabled", enabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("WebAuthn.setAutomaticPresenceSimulation", dictionary);
		}

		// Token: 0x0400067A RID: 1658
		private IDevToolsClient _client;
	}
}
