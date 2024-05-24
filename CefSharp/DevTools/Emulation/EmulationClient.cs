using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CefSharp.DevTools.DOM;
using CefSharp.DevTools.Page;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x0200035C RID: 860
	public class EmulationClient : DevToolsDomainBase
	{
		// Token: 0x060018BE RID: 6334 RVA: 0x0001D2B9 File Offset: 0x0001B4B9
		public EmulationClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000094 RID: 148
		// (add) Token: 0x060018BF RID: 6335 RVA: 0x0001D2C8 File Offset: 0x0001B4C8
		// (remove) Token: 0x060018C0 RID: 6336 RVA: 0x0001D2DB File Offset: 0x0001B4DB
		public event EventHandler<EventArgs> VirtualTimeBudgetExpired
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("Emulation.virtualTimeBudgetExpired", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("Emulation.virtualTimeBudgetExpired", value);
			}
		}

		// Token: 0x060018C1 RID: 6337 RVA: 0x0001D2F0 File Offset: 0x0001B4F0
		public Task<CanEmulateResponse> CanEmulateAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<CanEmulateResponse>("Emulation.canEmulate", parameters);
		}

		// Token: 0x060018C2 RID: 6338 RVA: 0x0001D310 File Offset: 0x0001B510
		public Task<DevToolsMethodResponse> ClearDeviceMetricsOverrideAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.clearDeviceMetricsOverride", parameters);
		}

		// Token: 0x060018C3 RID: 6339 RVA: 0x0001D330 File Offset: 0x0001B530
		public Task<DevToolsMethodResponse> ClearGeolocationOverrideAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.clearGeolocationOverride", parameters);
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x0001D350 File Offset: 0x0001B550
		public Task<DevToolsMethodResponse> ResetPageScaleFactorAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.resetPageScaleFactor", parameters);
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x0001D370 File Offset: 0x0001B570
		public Task<DevToolsMethodResponse> SetFocusEmulationEnabledAsync(bool enabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setFocusEmulationEnabled", dictionary);
		}

		// Token: 0x060018C6 RID: 6342 RVA: 0x0001D3A8 File Offset: 0x0001B5A8
		public Task<DevToolsMethodResponse> SetAutoDarkModeOverrideAsync(bool? enabled = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (enabled != null)
			{
				dictionary.Add("enabled", enabled.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setAutoDarkModeOverride", dictionary);
		}

		// Token: 0x060018C7 RID: 6343 RVA: 0x0001D3EC File Offset: 0x0001B5EC
		public Task<DevToolsMethodResponse> SetCPUThrottlingRateAsync(double rate)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("rate", rate);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setCPUThrottlingRate", dictionary);
		}

		// Token: 0x060018C8 RID: 6344 RVA: 0x0001D424 File Offset: 0x0001B624
		public Task<DevToolsMethodResponse> SetDefaultBackgroundColorOverrideAsync(RGBA color = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (color != null)
			{
				dictionary.Add("color", color.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setDefaultBackgroundColorOverride", dictionary);
		}

		// Token: 0x060018C9 RID: 6345 RVA: 0x0001D45C File Offset: 0x0001B65C
		public Task<DevToolsMethodResponse> SetDeviceMetricsOverrideAsync(int width, int height, double deviceScaleFactor, bool mobile, double? scale = null, int? screenWidth = null, int? screenHeight = null, int? positionX = null, int? positionY = null, bool? dontSetVisibleSize = null, ScreenOrientation screenOrientation = null, Viewport viewport = null, DisplayFeature displayFeature = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("width", width);
			dictionary.Add("height", height);
			dictionary.Add("deviceScaleFactor", deviceScaleFactor);
			dictionary.Add("mobile", mobile);
			if (scale != null)
			{
				dictionary.Add("scale", scale.Value);
			}
			if (screenWidth != null)
			{
				dictionary.Add("screenWidth", screenWidth.Value);
			}
			if (screenHeight != null)
			{
				dictionary.Add("screenHeight", screenHeight.Value);
			}
			if (positionX != null)
			{
				dictionary.Add("positionX", positionX.Value);
			}
			if (positionY != null)
			{
				dictionary.Add("positionY", positionY.Value);
			}
			if (dontSetVisibleSize != null)
			{
				dictionary.Add("dontSetVisibleSize", dontSetVisibleSize.Value);
			}
			if (screenOrientation != null)
			{
				dictionary.Add("screenOrientation", screenOrientation.ToDictionary());
			}
			if (viewport != null)
			{
				dictionary.Add("viewport", viewport.ToDictionary());
			}
			if (displayFeature != null)
			{
				dictionary.Add("displayFeature", displayFeature.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setDeviceMetricsOverride", dictionary);
		}

		// Token: 0x060018CA RID: 6346 RVA: 0x0001D5C8 File Offset: 0x0001B7C8
		public Task<DevToolsMethodResponse> SetScrollbarsHiddenAsync(bool hidden)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("hidden", hidden);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setScrollbarsHidden", dictionary);
		}

		// Token: 0x060018CB RID: 6347 RVA: 0x0001D600 File Offset: 0x0001B800
		public Task<DevToolsMethodResponse> SetDocumentCookieDisabledAsync(bool disabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("disabled", disabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setDocumentCookieDisabled", dictionary);
		}

		// Token: 0x060018CC RID: 6348 RVA: 0x0001D638 File Offset: 0x0001B838
		public Task<DevToolsMethodResponse> SetEmitTouchEventsForMouseAsync(bool enabled, SetEmitTouchEventsForMouseConfiguration? configuration = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			if (configuration != null)
			{
				dictionary.Add("configuration", base.EnumToString(configuration));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setEmitTouchEventsForMouse", dictionary);
		}

		// Token: 0x060018CD RID: 6349 RVA: 0x0001D690 File Offset: 0x0001B890
		public Task<DevToolsMethodResponse> SetEmulatedMediaAsync(string media = null, IList<MediaFeature> features = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(media))
			{
				dictionary.Add("media", media);
			}
			if (features != null)
			{
				dictionary.Add("features", from x in features
				select x.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setEmulatedMedia", dictionary);
		}

		// Token: 0x060018CE RID: 6350 RVA: 0x0001D6FC File Offset: 0x0001B8FC
		public Task<DevToolsMethodResponse> SetEmulatedVisionDeficiencyAsync(SetEmulatedVisionDeficiencyType type)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("type", base.EnumToString(type));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setEmulatedVisionDeficiency", dictionary);
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x0001D738 File Offset: 0x0001B938
		public Task<DevToolsMethodResponse> SetGeolocationOverrideAsync(double? latitude = null, double? longitude = null, double? accuracy = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (latitude != null)
			{
				dictionary.Add("latitude", latitude.Value);
			}
			if (longitude != null)
			{
				dictionary.Add("longitude", longitude.Value);
			}
			if (accuracy != null)
			{
				dictionary.Add("accuracy", accuracy.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setGeolocationOverride", dictionary);
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x0001D7BC File Offset: 0x0001B9BC
		public Task<DevToolsMethodResponse> SetIdleOverrideAsync(bool isUserActive, bool isScreenUnlocked)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("isUserActive", isUserActive);
			dictionary.Add("isScreenUnlocked", isScreenUnlocked);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setIdleOverride", dictionary);
		}

		// Token: 0x060018D1 RID: 6353 RVA: 0x0001D804 File Offset: 0x0001BA04
		public Task<DevToolsMethodResponse> ClearIdleOverrideAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.clearIdleOverride", parameters);
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x0001D824 File Offset: 0x0001BA24
		public Task<DevToolsMethodResponse> SetPageScaleFactorAsync(double pageScaleFactor)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("pageScaleFactor", pageScaleFactor);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setPageScaleFactor", dictionary);
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x0001D85C File Offset: 0x0001BA5C
		public Task<DevToolsMethodResponse> SetScriptExecutionDisabledAsync(bool value)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("value", value);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setScriptExecutionDisabled", dictionary);
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x0001D894 File Offset: 0x0001BA94
		public Task<DevToolsMethodResponse> SetTouchEmulationEnabledAsync(bool enabled, int? maxTouchPoints = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			if (maxTouchPoints != null)
			{
				dictionary.Add("maxTouchPoints", maxTouchPoints.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setTouchEmulationEnabled", dictionary);
		}

		// Token: 0x060018D5 RID: 6357 RVA: 0x0001D8EC File Offset: 0x0001BAEC
		public Task<SetVirtualTimePolicyResponse> SetVirtualTimePolicyAsync(VirtualTimePolicy policy, double? budget = null, int? maxVirtualTimeTaskStarvationCount = null, double? initialVirtualTime = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("policy", base.EnumToString(policy));
			if (budget != null)
			{
				dictionary.Add("budget", budget.Value);
			}
			if (maxVirtualTimeTaskStarvationCount != null)
			{
				dictionary.Add("maxVirtualTimeTaskStarvationCount", maxVirtualTimeTaskStarvationCount.Value);
			}
			if (initialVirtualTime != null)
			{
				dictionary.Add("initialVirtualTime", initialVirtualTime.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<SetVirtualTimePolicyResponse>("Emulation.setVirtualTimePolicy", dictionary);
		}

		// Token: 0x060018D6 RID: 6358 RVA: 0x0001D988 File Offset: 0x0001BB88
		public Task<DevToolsMethodResponse> SetLocaleOverrideAsync(string locale = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(locale))
			{
				dictionary.Add("locale", locale);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setLocaleOverride", dictionary);
		}

		// Token: 0x060018D7 RID: 6359 RVA: 0x0001D9C0 File Offset: 0x0001BBC0
		public Task<DevToolsMethodResponse> SetTimezoneOverrideAsync(string timezoneId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("timezoneId", timezoneId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setTimezoneOverride", dictionary);
		}

		// Token: 0x060018D8 RID: 6360 RVA: 0x0001D9F0 File Offset: 0x0001BBF0
		public Task<DevToolsMethodResponse> SetDisabledImageTypesAsync(DisabledImageType[] imageTypes)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("imageTypes", base.EnumToString(imageTypes));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setDisabledImageTypes", dictionary);
		}

		// Token: 0x060018D9 RID: 6361 RVA: 0x0001DA28 File Offset: 0x0001BC28
		public Task<DevToolsMethodResponse> SetUserAgentOverrideAsync(string userAgent, string acceptLanguage = null, string platform = null, UserAgentMetadata userAgentMetadata = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("userAgent", userAgent);
			if (!string.IsNullOrEmpty(acceptLanguage))
			{
				dictionary.Add("acceptLanguage", acceptLanguage);
			}
			if (!string.IsNullOrEmpty(platform))
			{
				dictionary.Add("platform", platform);
			}
			if (userAgentMetadata != null)
			{
				dictionary.Add("userAgentMetadata", userAgentMetadata.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Emulation.setUserAgentOverride", dictionary);
		}

		// Token: 0x04000DC0 RID: 3520
		private IDevToolsClient _client;
	}
}
