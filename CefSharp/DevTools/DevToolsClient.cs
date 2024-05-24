using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CefSharp.Callback;
using CefSharp.DevTools.Accessibility;
using CefSharp.DevTools.Animation;
using CefSharp.DevTools.Audits;
using CefSharp.DevTools.BackgroundService;
using CefSharp.DevTools.Browser;
using CefSharp.DevTools.CacheStorage;
using CefSharp.DevTools.Cast;
using CefSharp.DevTools.CSS;
using CefSharp.DevTools.Database;
using CefSharp.DevTools.Debugger;
using CefSharp.DevTools.DeviceOrientation;
using CefSharp.DevTools.DOM;
using CefSharp.DevTools.DOMDebugger;
using CefSharp.DevTools.DOMSnapshot;
using CefSharp.DevTools.DOMStorage;
using CefSharp.DevTools.Emulation;
using CefSharp.DevTools.EventBreakpoints;
using CefSharp.DevTools.Fetch;
using CefSharp.DevTools.HeadlessExperimental;
using CefSharp.DevTools.HeapProfiler;
using CefSharp.DevTools.IndexedDB;
using CefSharp.DevTools.Input;
using CefSharp.DevTools.Inspector;
using CefSharp.DevTools.IO;
using CefSharp.DevTools.LayerTree;
using CefSharp.DevTools.Log;
using CefSharp.DevTools.Media;
using CefSharp.DevTools.Memory;
using CefSharp.DevTools.Network;
using CefSharp.DevTools.Overlay;
using CefSharp.DevTools.Page;
using CefSharp.DevTools.Performance;
using CefSharp.DevTools.PerformanceTimeline;
using CefSharp.DevTools.Profiler;
using CefSharp.DevTools.Runtime;
using CefSharp.DevTools.Security;
using CefSharp.DevTools.ServiceWorker;
using CefSharp.DevTools.Storage;
using CefSharp.DevTools.SystemInfo;
using CefSharp.DevTools.Target;
using CefSharp.DevTools.Tethering;
using CefSharp.DevTools.Tracing;
using CefSharp.DevTools.WebAudio;
using CefSharp.DevTools.WebAuthn;
using CefSharp.Internals;

namespace CefSharp.DevTools
{
	// Token: 0x0200011A RID: 282
	public class DevToolsClient : IDevToolsMessageObserver, IDisposable, IDevToolsClient
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600080D RID: 2061 RVA: 0x0000C9D0 File Offset: 0x0000ABD0
		// (remove) Token: 0x0600080E RID: 2062 RVA: 0x0000CA08 File Offset: 0x0000AC08
		public event EventHandler<DevToolsEventArgs> DevToolsEvent;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600080F RID: 2063 RVA: 0x0000CA40 File Offset: 0x0000AC40
		// (remove) Token: 0x06000810 RID: 2064 RVA: 0x0000CA78 File Offset: 0x0000AC78
		public event EventHandler<DevToolsErrorEventArgs> DevToolsEventError;

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x0000CAAD File Offset: 0x0000ACAD
		// (set) Token: 0x06000812 RID: 2066 RVA: 0x0000CAB5 File Offset: 0x0000ACB5
		public bool CaptureSyncContext { get; set; }

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x0000CABE File Offset: 0x0000ACBE
		// (set) Token: 0x06000814 RID: 2068 RVA: 0x0000CAC6 File Offset: 0x0000ACC6
		public SynchronizationContext SyncContext
		{
			get
			{
				return this.syncContext;
			}
			set
			{
				this.CaptureSyncContext = false;
				this.syncContext = value;
			}
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0000CAD6 File Offset: 0x0000ACD6
		public DevToolsClient(IBrowser browser)
		{
			this.browser = browser;
			this.CaptureSyncContext = true;
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0000CB02 File Offset: 0x0000AD02
		public void SetDevToolsObserverRegistration(IRegistration devToolsRegistration)
		{
			this.devToolsRegistration = devToolsRegistration;
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0000CB0C File Offset: 0x0000AD0C
		public void AddEventHandler<T>(string eventName, EventHandler<T> eventHandler) where T : EventArgs
		{
			IEventProxy orAdd = this.eventHandlers.GetOrAdd(eventName, (string _) => new EventProxy<T>(new Func<string, Stream, T>(DevToolsClient.DeserializeJsonEvent<T>)));
			EventProxy<T> eventProxy = (EventProxy<T>)orAdd;
			eventProxy.AddHandler(eventHandler);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0000CB54 File Offset: 0x0000AD54
		public bool RemoveEventHandler<T>(string eventName, EventHandler<T> eventHandler) where T : EventArgs
		{
			IEventProxy eventProxy;
			if (this.eventHandlers.TryGetValue(eventName, out eventProxy))
			{
				EventProxy<T> eventProxy2 = (EventProxy<T>)eventProxy;
				if (eventProxy2.RemoveHandler(eventHandler))
				{
					IEventProxy eventProxy3;
					return !this.eventHandlers.TryRemove(eventName, out eventProxy3);
				}
			}
			return true;
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0000CB94 File Offset: 0x0000AD94
		public Task<DevToolsMethodResponse> ExecuteDevToolsMethodAsync(string method, IDictionary<string, object> parameters = null)
		{
			return this.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>(method, parameters);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0000CBA0 File Offset: 0x0000ADA0
		public Task<T> ExecuteDevToolsMethodAsync<T>(string method, IDictionary<string, object> parameters = null) where T : DevToolsDomainResponseBase
		{
			if (this.browser == null || this.browser.IsDisposed)
			{
				throw new ObjectDisposedException("IBrowser");
			}
			TaskCompletionSource<T> taskCompletionSource = new TaskCompletionSource<T>();
			DevToolsMethodResponseContext methodResultContext = new DevToolsMethodResponseContext(typeof(T), (object o) => taskCompletionSource.TrySetResult((T)((object)o)), new Func<Exception, bool>(taskCompletionSource.TrySetException), this.CaptureSyncContext ? SynchronizationContext.Current : this.SyncContext);
			IBrowserHost browserHost = this.browser.GetHost();
			int messageId = browserHost.GetNextDevToolsMessageId();
			if (!this.queuedCommandResults.TryAdd(messageId, methodResultContext))
			{
				throw new DevToolsClientException(string.Format("Unable to add MessageId {0} to queuedCommandResults ConcurrentDictionary.", messageId));
			}
			if (CefThread.CurrentlyOnUiThread)
			{
				this.ExecuteDevToolsMethod(browserHost, messageId, method, parameters, methodResultContext);
			}
			else
			{
				if (!CefThread.CanExecuteOnUiThread)
				{
					this.queuedCommandResults.TryRemove(messageId, out methodResultContext);
					throw new DevToolsClientException("Unable to invoke ExecuteDevToolsMethod on CEF UI Thread.");
				}
				CefThread.ExecuteOnUiThread<object>(delegate
				{
					this.ExecuteDevToolsMethod(browserHost, messageId, method, parameters, methodResultContext);
					return null;
				});
			}
			return taskCompletionSource.Task;
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0000CD08 File Offset: 0x0000AF08
		private void ExecuteDevToolsMethod(IBrowserHost browserHost, int messageId, string method, IDictionary<string, object> parameters, DevToolsMethodResponseContext methodResultContext)
		{
			try
			{
				int num = browserHost.ExecuteDevToolsMethod(messageId, method, parameters);
				if (num == 0)
				{
					throw new DevToolsClientException(string.Format("Failed to execute dev tools method {0}.", method));
				}
				if (num != messageId)
				{
					throw new DevToolsClientException(string.Format("Generated MessageId {0} doesn't match returned Message Id {1}", num, messageId));
				}
			}
			catch (Exception exception)
			{
				DevToolsMethodResponseContext devToolsMethodResponseContext;
				this.queuedCommandResults.TryRemove(messageId, out devToolsMethodResponseContext);
				methodResultContext.SetException(exception);
			}
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0000CD80 File Offset: 0x0000AF80
		void IDisposable.Dispose()
		{
			if (Interlocked.Increment(ref this.disposeCount) == 1)
			{
				this.DevToolsEvent = null;
				IRegistration registration = this.devToolsRegistration;
				if (registration != null)
				{
					registration.Dispose();
				}
				this.devToolsRegistration = null;
				this.browser = null;
				ICollection<IEventProxy> values = this.eventHandlers.Values;
				this.eventHandlers.Clear();
				foreach (IEventProxy eventProxy in values)
				{
					eventProxy.Dispose();
				}
			}
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x0000CE14 File Offset: 0x0000B014
		void IDevToolsMessageObserver.OnDevToolsAgentAttached(IBrowser browser)
		{
			this.devToolsAttached = true;
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0000CE1D File Offset: 0x0000B01D
		void IDevToolsMessageObserver.OnDevToolsAgentDetached(IBrowser browser)
		{
			this.devToolsAttached = false;
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0000CE28 File Offset: 0x0000B028
		void IDevToolsMessageObserver.OnDevToolsEvent(IBrowser browser, string method, Stream parameters)
		{
			try
			{
				EventHandler<DevToolsEventArgs> devToolsEvent = this.DevToolsEvent;
				if (devToolsEvent != null)
				{
					string paramsAsJsonString = DevToolsClient.StreamToString(parameters, true);
					devToolsEvent(this, new DevToolsEventArgs(method, paramsAsJsonString));
				}
				IEventProxy eventProxy;
				if (this.eventHandlers.TryGetValue(method, out eventProxy))
				{
					eventProxy.Raise(this, method, parameters, this.SyncContext);
				}
			}
			catch (Exception ex)
			{
				EventHandler<DevToolsErrorEventArgs> devToolsEventError = this.DevToolsEventError;
				string json = "";
				if (parameters.Length > 0L)
				{
					parameters.Position = 0L;
					try
					{
						json = DevToolsClient.StreamToString(parameters, false);
					}
					catch (Exception)
					{
					}
				}
				DevToolsErrorEventArgs e = new DevToolsErrorEventArgs(method, json, ex);
				if (devToolsEventError != null)
				{
					devToolsEventError(this, e);
				}
			}
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0000CEE0 File Offset: 0x0000B0E0
		bool IDevToolsMessageObserver.OnDevToolsMessage(IBrowser browser, Stream message)
		{
			return false;
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0000CEE4 File Offset: 0x0000B0E4
		void IDevToolsMessageObserver.OnDevToolsMethodResult(IBrowser browser, int messageId, bool success, Stream result)
		{
			DevToolsMethodResponseContext devToolsMethodResponseContext;
			if (this.queuedCommandResults.TryRemove(messageId, out devToolsMethodResponseContext))
			{
				if (success)
				{
					if (devToolsMethodResponseContext.Type == typeof(DevToolsMethodResponse) || devToolsMethodResponseContext.Type == typeof(DevToolsDomainResponseBase))
					{
						devToolsMethodResponseContext.SetResult(new DevToolsMethodResponse
						{
							Success = success,
							MessageId = messageId,
							ResponseAsJsonString = DevToolsClient.StreamToString(result, false)
						});
						return;
					}
					try
					{
						devToolsMethodResponseContext.SetResult(DevToolsClient.DeserializeJson(devToolsMethodResponseContext.Type, result));
						return;
					}
					catch (Exception exception)
					{
						devToolsMethodResponseContext.SetException(exception);
						return;
					}
				}
				DevToolsDomainErrorResponse devToolsDomainErrorResponse = DevToolsClient.DeserializeJson<DevToolsDomainErrorResponse>(result);
				devToolsDomainErrorResponse.MessageId = messageId;
				devToolsMethodResponseContext.SetException(new DevToolsClientException("DevTools Client Error :" + devToolsDomainErrorResponse.Message, devToolsDomainErrorResponse));
			}
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0000CFBC File Offset: 0x0000B1BC
		private static T DeserializeJsonEvent<T>(string eventName, Stream stream) where T : EventArgs
		{
			if (typeof(T) == typeof(EventArgs))
			{
				return (T)((object)EventArgs.Empty);
			}
			if (typeof(T) == typeof(DevToolsEventArgs))
			{
				string paramsAsJsonString = DevToolsClient.StreamToString(stream, true);
				DevToolsEventArgs devToolsEventArgs = new DevToolsEventArgs(eventName, paramsAsJsonString);
				return (T)((object)devToolsEventArgs);
			}
			return (T)((object)DevToolsClient.DeserializeJson(typeof(T), stream));
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0000D036 File Offset: 0x0000B236
		private static T DeserializeJson<T>(Stream stream)
		{
			return (T)((object)DevToolsClient.DeserializeJson(typeof(T), stream));
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0000D050 File Offset: 0x0000B250
		private static object DeserializeJson(Type type, Stream stream)
		{
			DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(type, new DataContractJsonSerializerSettings
			{
				UseSimpleDictionaryFormat = true
			});
			return dataContractJsonSerializer.ReadObject(stream);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0000D07C File Offset: 0x0000B27C
		private static string StreamToString(Stream stream, bool leaveOpen = false)
		{
			string result;
			using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8, false, 1024, leaveOpen))
			{
				result = streamReader.ReadToEnd();
			}
			return result;
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x0000D0C0 File Offset: 0x0000B2C0
		public AccessibilityClient Accessibility
		{
			get
			{
				if (this._Accessibility == null)
				{
					this._Accessibility = new AccessibilityClient(this);
				}
				return this._Accessibility;
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000827 RID: 2087 RVA: 0x0000D0DC File Offset: 0x0000B2DC
		public AnimationClient Animation
		{
			get
			{
				if (this._Animation == null)
				{
					this._Animation = new AnimationClient(this);
				}
				return this._Animation;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000828 RID: 2088 RVA: 0x0000D0F8 File Offset: 0x0000B2F8
		public AuditsClient Audits
		{
			get
			{
				if (this._Audits == null)
				{
					this._Audits = new AuditsClient(this);
				}
				return this._Audits;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000829 RID: 2089 RVA: 0x0000D114 File Offset: 0x0000B314
		public BackgroundServiceClient BackgroundService
		{
			get
			{
				if (this._BackgroundService == null)
				{
					this._BackgroundService = new BackgroundServiceClient(this);
				}
				return this._BackgroundService;
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x0000D130 File Offset: 0x0000B330
		public BrowserClient Browser
		{
			get
			{
				if (this._Browser == null)
				{
					this._Browser = new BrowserClient(this);
				}
				return this._Browser;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x0600082B RID: 2091 RVA: 0x0000D14C File Offset: 0x0000B34C
		public CSSClient CSS
		{
			get
			{
				if (this._CSS == null)
				{
					this._CSS = new CSSClient(this);
				}
				return this._CSS;
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x0600082C RID: 2092 RVA: 0x0000D168 File Offset: 0x0000B368
		public CacheStorageClient CacheStorage
		{
			get
			{
				if (this._CacheStorage == null)
				{
					this._CacheStorage = new CacheStorageClient(this);
				}
				return this._CacheStorage;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x0000D184 File Offset: 0x0000B384
		public CastClient Cast
		{
			get
			{
				if (this._Cast == null)
				{
					this._Cast = new CastClient(this);
				}
				return this._Cast;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x0000D1A0 File Offset: 0x0000B3A0
		public DOMClient DOM
		{
			get
			{
				if (this._DOM == null)
				{
					this._DOM = new DOMClient(this);
				}
				return this._DOM;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x0000D1BC File Offset: 0x0000B3BC
		public DOMDebuggerClient DOMDebugger
		{
			get
			{
				if (this._DOMDebugger == null)
				{
					this._DOMDebugger = new DOMDebuggerClient(this);
				}
				return this._DOMDebugger;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x0000D1D8 File Offset: 0x0000B3D8
		public EventBreakpointsClient EventBreakpoints
		{
			get
			{
				if (this._EventBreakpoints == null)
				{
					this._EventBreakpoints = new EventBreakpointsClient(this);
				}
				return this._EventBreakpoints;
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x0000D1F4 File Offset: 0x0000B3F4
		public DOMSnapshotClient DOMSnapshot
		{
			get
			{
				if (this._DOMSnapshot == null)
				{
					this._DOMSnapshot = new DOMSnapshotClient(this);
				}
				return this._DOMSnapshot;
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x0000D210 File Offset: 0x0000B410
		public DOMStorageClient DOMStorage
		{
			get
			{
				if (this._DOMStorage == null)
				{
					this._DOMStorage = new DOMStorageClient(this);
				}
				return this._DOMStorage;
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x0000D22C File Offset: 0x0000B42C
		public DatabaseClient Database
		{
			get
			{
				if (this._Database == null)
				{
					this._Database = new DatabaseClient(this);
				}
				return this._Database;
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x0000D248 File Offset: 0x0000B448
		public DeviceOrientationClient DeviceOrientation
		{
			get
			{
				if (this._DeviceOrientation == null)
				{
					this._DeviceOrientation = new DeviceOrientationClient(this);
				}
				return this._DeviceOrientation;
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000835 RID: 2101 RVA: 0x0000D264 File Offset: 0x0000B464
		public EmulationClient Emulation
		{
			get
			{
				if (this._Emulation == null)
				{
					this._Emulation = new EmulationClient(this);
				}
				return this._Emulation;
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x0000D280 File Offset: 0x0000B480
		public HeadlessExperimentalClient HeadlessExperimental
		{
			get
			{
				if (this._HeadlessExperimental == null)
				{
					this._HeadlessExperimental = new HeadlessExperimentalClient(this);
				}
				return this._HeadlessExperimental;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x0000D29C File Offset: 0x0000B49C
		public IOClient IO
		{
			get
			{
				if (this._IO == null)
				{
					this._IO = new IOClient(this);
				}
				return this._IO;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0000D2B8 File Offset: 0x0000B4B8
		public IndexedDBClient IndexedDB
		{
			get
			{
				if (this._IndexedDB == null)
				{
					this._IndexedDB = new IndexedDBClient(this);
				}
				return this._IndexedDB;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x0000D2D4 File Offset: 0x0000B4D4
		public InputClient Input
		{
			get
			{
				if (this._Input == null)
				{
					this._Input = new InputClient(this);
				}
				return this._Input;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x0000D2F0 File Offset: 0x0000B4F0
		public InspectorClient Inspector
		{
			get
			{
				if (this._Inspector == null)
				{
					this._Inspector = new InspectorClient(this);
				}
				return this._Inspector;
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x0000D30C File Offset: 0x0000B50C
		public LayerTreeClient LayerTree
		{
			get
			{
				if (this._LayerTree == null)
				{
					this._LayerTree = new LayerTreeClient(this);
				}
				return this._LayerTree;
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x0000D328 File Offset: 0x0000B528
		public LogClient Log
		{
			get
			{
				if (this._Log == null)
				{
					this._Log = new LogClient(this);
				}
				return this._Log;
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x0000D344 File Offset: 0x0000B544
		public MemoryClient Memory
		{
			get
			{
				if (this._Memory == null)
				{
					this._Memory = new MemoryClient(this);
				}
				return this._Memory;
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0000D360 File Offset: 0x0000B560
		public NetworkClient Network
		{
			get
			{
				if (this._Network == null)
				{
					this._Network = new NetworkClient(this);
				}
				return this._Network;
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x0000D37C File Offset: 0x0000B57C
		public OverlayClient Overlay
		{
			get
			{
				if (this._Overlay == null)
				{
					this._Overlay = new OverlayClient(this);
				}
				return this._Overlay;
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0000D398 File Offset: 0x0000B598
		public PageClient Page
		{
			get
			{
				if (this._Page == null)
				{
					this._Page = new PageClient(this);
				}
				return this._Page;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x0000D3B4 File Offset: 0x0000B5B4
		public PerformanceClient Performance
		{
			get
			{
				if (this._Performance == null)
				{
					this._Performance = new PerformanceClient(this);
				}
				return this._Performance;
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x0000D3D0 File Offset: 0x0000B5D0
		public PerformanceTimelineClient PerformanceTimeline
		{
			get
			{
				if (this._PerformanceTimeline == null)
				{
					this._PerformanceTimeline = new PerformanceTimelineClient(this);
				}
				return this._PerformanceTimeline;
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x0000D3EC File Offset: 0x0000B5EC
		public SecurityClient Security
		{
			get
			{
				if (this._Security == null)
				{
					this._Security = new SecurityClient(this);
				}
				return this._Security;
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x0000D408 File Offset: 0x0000B608
		public ServiceWorkerClient ServiceWorker
		{
			get
			{
				if (this._ServiceWorker == null)
				{
					this._ServiceWorker = new ServiceWorkerClient(this);
				}
				return this._ServiceWorker;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x0000D424 File Offset: 0x0000B624
		public StorageClient Storage
		{
			get
			{
				if (this._Storage == null)
				{
					this._Storage = new StorageClient(this);
				}
				return this._Storage;
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0000D440 File Offset: 0x0000B640
		public SystemInfoClient SystemInfo
		{
			get
			{
				if (this._SystemInfo == null)
				{
					this._SystemInfo = new SystemInfoClient(this);
				}
				return this._SystemInfo;
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000847 RID: 2119 RVA: 0x0000D45C File Offset: 0x0000B65C
		public TargetClient Target
		{
			get
			{
				if (this._Target == null)
				{
					this._Target = new TargetClient(this);
				}
				return this._Target;
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x0000D478 File Offset: 0x0000B678
		public TetheringClient Tethering
		{
			get
			{
				if (this._Tethering == null)
				{
					this._Tethering = new TetheringClient(this);
				}
				return this._Tethering;
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x0000D494 File Offset: 0x0000B694
		public TracingClient Tracing
		{
			get
			{
				if (this._Tracing == null)
				{
					this._Tracing = new TracingClient(this);
				}
				return this._Tracing;
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x0000D4B0 File Offset: 0x0000B6B0
		public FetchClient Fetch
		{
			get
			{
				if (this._Fetch == null)
				{
					this._Fetch = new FetchClient(this);
				}
				return this._Fetch;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x0000D4CC File Offset: 0x0000B6CC
		public WebAudioClient WebAudio
		{
			get
			{
				if (this._WebAudio == null)
				{
					this._WebAudio = new WebAudioClient(this);
				}
				return this._WebAudio;
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x0000D4E8 File Offset: 0x0000B6E8
		public WebAuthnClient WebAuthn
		{
			get
			{
				if (this._WebAuthn == null)
				{
					this._WebAuthn = new WebAuthnClient(this);
				}
				return this._WebAuthn;
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0000D504 File Offset: 0x0000B704
		public MediaClient Media
		{
			get
			{
				if (this._Media == null)
				{
					this._Media = new MediaClient(this);
				}
				return this._Media;
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x0000D520 File Offset: 0x0000B720
		public DebuggerClient Debugger
		{
			get
			{
				if (this._Debugger == null)
				{
					this._Debugger = new DebuggerClient(this);
				}
				return this._Debugger;
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x0000D53C File Offset: 0x0000B73C
		public HeapProfilerClient HeapProfiler
		{
			get
			{
				if (this._HeapProfiler == null)
				{
					this._HeapProfiler = new HeapProfilerClient(this);
				}
				return this._HeapProfiler;
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x0000D558 File Offset: 0x0000B758
		public ProfilerClient Profiler
		{
			get
			{
				if (this._Profiler == null)
				{
					this._Profiler = new ProfilerClient(this);
				}
				return this._Profiler;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x0000D574 File Offset: 0x0000B774
		public RuntimeClient Runtime
		{
			get
			{
				if (this._Runtime == null)
				{
					this._Runtime = new RuntimeClient(this);
				}
				return this._Runtime;
			}
		}

		// Token: 0x0400044C RID: 1100
		private readonly ConcurrentDictionary<int, DevToolsMethodResponseContext> queuedCommandResults = new ConcurrentDictionary<int, DevToolsMethodResponseContext>();

		// Token: 0x0400044D RID: 1101
		private readonly ConcurrentDictionary<string, IEventProxy> eventHandlers = new ConcurrentDictionary<string, IEventProxy>();

		// Token: 0x0400044E RID: 1102
		private IBrowser browser;

		// Token: 0x0400044F RID: 1103
		private IRegistration devToolsRegistration;

		// Token: 0x04000450 RID: 1104
		private bool devToolsAttached;

		// Token: 0x04000451 RID: 1105
		private SynchronizationContext syncContext;

		// Token: 0x04000452 RID: 1106
		private int disposeCount;

		// Token: 0x04000456 RID: 1110
		private AccessibilityClient _Accessibility;

		// Token: 0x04000457 RID: 1111
		private AnimationClient _Animation;

		// Token: 0x04000458 RID: 1112
		private AuditsClient _Audits;

		// Token: 0x04000459 RID: 1113
		private BackgroundServiceClient _BackgroundService;

		// Token: 0x0400045A RID: 1114
		private BrowserClient _Browser;

		// Token: 0x0400045B RID: 1115
		private CSSClient _CSS;

		// Token: 0x0400045C RID: 1116
		private CacheStorageClient _CacheStorage;

		// Token: 0x0400045D RID: 1117
		private CastClient _Cast;

		// Token: 0x0400045E RID: 1118
		private DOMClient _DOM;

		// Token: 0x0400045F RID: 1119
		private DOMDebuggerClient _DOMDebugger;

		// Token: 0x04000460 RID: 1120
		private EventBreakpointsClient _EventBreakpoints;

		// Token: 0x04000461 RID: 1121
		private DOMSnapshotClient _DOMSnapshot;

		// Token: 0x04000462 RID: 1122
		private DOMStorageClient _DOMStorage;

		// Token: 0x04000463 RID: 1123
		private DatabaseClient _Database;

		// Token: 0x04000464 RID: 1124
		private DeviceOrientationClient _DeviceOrientation;

		// Token: 0x04000465 RID: 1125
		private EmulationClient _Emulation;

		// Token: 0x04000466 RID: 1126
		private HeadlessExperimentalClient _HeadlessExperimental;

		// Token: 0x04000467 RID: 1127
		private IOClient _IO;

		// Token: 0x04000468 RID: 1128
		private IndexedDBClient _IndexedDB;

		// Token: 0x04000469 RID: 1129
		private InputClient _Input;

		// Token: 0x0400046A RID: 1130
		private InspectorClient _Inspector;

		// Token: 0x0400046B RID: 1131
		private LayerTreeClient _LayerTree;

		// Token: 0x0400046C RID: 1132
		private LogClient _Log;

		// Token: 0x0400046D RID: 1133
		private MemoryClient _Memory;

		// Token: 0x0400046E RID: 1134
		private NetworkClient _Network;

		// Token: 0x0400046F RID: 1135
		private OverlayClient _Overlay;

		// Token: 0x04000470 RID: 1136
		private PageClient _Page;

		// Token: 0x04000471 RID: 1137
		private PerformanceClient _Performance;

		// Token: 0x04000472 RID: 1138
		private PerformanceTimelineClient _PerformanceTimeline;

		// Token: 0x04000473 RID: 1139
		private SecurityClient _Security;

		// Token: 0x04000474 RID: 1140
		private ServiceWorkerClient _ServiceWorker;

		// Token: 0x04000475 RID: 1141
		private StorageClient _Storage;

		// Token: 0x04000476 RID: 1142
		private SystemInfoClient _SystemInfo;

		// Token: 0x04000477 RID: 1143
		private TargetClient _Target;

		// Token: 0x04000478 RID: 1144
		private TetheringClient _Tethering;

		// Token: 0x04000479 RID: 1145
		private TracingClient _Tracing;

		// Token: 0x0400047A RID: 1146
		private FetchClient _Fetch;

		// Token: 0x0400047B RID: 1147
		private WebAudioClient _WebAudio;

		// Token: 0x0400047C RID: 1148
		private WebAuthnClient _WebAuthn;

		// Token: 0x0400047D RID: 1149
		private MediaClient _Media;

		// Token: 0x0400047E RID: 1150
		private DebuggerClient _Debugger;

		// Token: 0x0400047F RID: 1151
		private HeapProfilerClient _HeapProfiler;

		// Token: 0x04000480 RID: 1152
		private ProfilerClient _Profiler;

		// Token: 0x04000481 RID: 1153
		private RuntimeClient _Runtime;
	}
}
