using System;
using CefSharp.Core;
using CefSharp.Handler;

namespace CefSharp
{
	// Token: 0x0200000C RID: 12
	public class RequestContextBuilder
	{
		// Token: 0x060000FA RID: 250 RVA: 0x00002F59 File Offset: 0x00001159
		private void ThrowExceptionIfContextAlreadySet()
		{
			if (this._otherContext != null)
			{
				throw new Exception("A call to WithSharedSettings has already been made, it is no possible to provide custom settings.");
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00002F6E File Offset: 0x0000116E
		private void ThrowExceptionIfCustomSettingSpecified()
		{
			if (this._settings != null)
			{
				throw new Exception("A call to WithCachePath/PersistUserPreferences has already been made, it's not possible to share settings with another RequestContext.");
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00002F84 File Offset: 0x00001184
		public IRequestContext Create()
		{
			if (this._otherContext != null)
			{
				return new RequestContext(this._otherContext, this._handler);
			}
			if (this._settings != null)
			{
				return new RequestContext(this._settings.settings, this._handler);
			}
			return new RequestContext(this._handler);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00002FD5 File Offset: 0x000011D5
		public RequestContextBuilder OnInitialize(Action<IRequestContext> action)
		{
			if (this._handler == null)
			{
				this._handler = new RequestContextHandler();
			}
			this._handler.OnInitialize(action);
			return this;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00002FF8 File Offset: 0x000011F8
		public RequestContextBuilder WithCachePath(string cachePath)
		{
			this.ThrowExceptionIfContextAlreadySet();
			if (this._settings == null)
			{
				this._settings = new RequestContextSettings();
			}
			this._settings.CachePath = cachePath;
			return this;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00003020 File Offset: 0x00001220
		public RequestContextBuilder PersistUserPreferences()
		{
			this.ThrowExceptionIfContextAlreadySet();
			if (this._settings == null)
			{
				this._settings = new RequestContextSettings();
			}
			this._settings.PersistUserPreferences = true;
			return this;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00003048 File Offset: 0x00001248
		public RequestContextBuilder WithPreference(string name, object value)
		{
			if (this._handler == null)
			{
				this._handler = new RequestContextHandler();
			}
			this._handler.SetPreferenceOnContextInitialized(name, value);
			return this;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000306C File Offset: 0x0000126C
		public RequestContextBuilder WithProxyServer(string host)
		{
			if (this._handler == null)
			{
				this._handler = new RequestContextHandler();
			}
			this._handler.SetProxyOnContextInitialized(host, null);
			return this;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000030A3 File Offset: 0x000012A3
		public RequestContextBuilder WithProxyServer(string host, int? port)
		{
			if (this._handler == null)
			{
				this._handler = new RequestContextHandler();
			}
			this._handler.SetProxyOnContextInitialized(host, port);
			return this;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000030C7 File Offset: 0x000012C7
		public RequestContextBuilder WithProxyServer(string scheme, string host, int? port)
		{
			if (this._handler == null)
			{
				this._handler = new RequestContextHandler();
			}
			this._handler.SetProxyOnContextInitialized(scheme, host, port);
			return this;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000030EC File Offset: 0x000012EC
		public RequestContextBuilder WithSharedSettings(IRequestContext other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			this.ThrowExceptionIfCustomSettingSpecified();
			this._otherContext = other;
			return this;
		}

		// Token: 0x04000008 RID: 8
		private RequestContextSettings _settings;

		// Token: 0x04000009 RID: 9
		private IRequestContext _otherContext;

		// Token: 0x0400000A RID: 10
		private RequestContextHandler _handler;
	}
}
