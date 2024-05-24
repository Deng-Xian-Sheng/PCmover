using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000154 RID: 340
	public class RuntimeClient : DevToolsDomainBase
	{
		// Token: 0x060009C8 RID: 2504 RVA: 0x0000E970 File Offset: 0x0000CB70
		public RuntimeClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060009C9 RID: 2505 RVA: 0x0000E97F File Offset: 0x0000CB7F
		// (remove) Token: 0x060009CA RID: 2506 RVA: 0x0000E992 File Offset: 0x0000CB92
		public event EventHandler<BindingCalledEventArgs> BindingCalled
		{
			add
			{
				this._client.AddEventHandler<BindingCalledEventArgs>("Runtime.bindingCalled", value);
			}
			remove
			{
				this._client.RemoveEventHandler<BindingCalledEventArgs>("Runtime.bindingCalled", value);
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060009CB RID: 2507 RVA: 0x0000E9A6 File Offset: 0x0000CBA6
		// (remove) Token: 0x060009CC RID: 2508 RVA: 0x0000E9B9 File Offset: 0x0000CBB9
		public event EventHandler<ConsoleAPICalledEventArgs> ConsoleAPICalled
		{
			add
			{
				this._client.AddEventHandler<ConsoleAPICalledEventArgs>("Runtime.consoleAPICalled", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ConsoleAPICalledEventArgs>("Runtime.consoleAPICalled", value);
			}
		}

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060009CD RID: 2509 RVA: 0x0000E9CD File Offset: 0x0000CBCD
		// (remove) Token: 0x060009CE RID: 2510 RVA: 0x0000E9E0 File Offset: 0x0000CBE0
		public event EventHandler<ExceptionRevokedEventArgs> ExceptionRevoked
		{
			add
			{
				this._client.AddEventHandler<ExceptionRevokedEventArgs>("Runtime.exceptionRevoked", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ExceptionRevokedEventArgs>("Runtime.exceptionRevoked", value);
			}
		}

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060009CF RID: 2511 RVA: 0x0000E9F4 File Offset: 0x0000CBF4
		// (remove) Token: 0x060009D0 RID: 2512 RVA: 0x0000EA07 File Offset: 0x0000CC07
		public event EventHandler<ExceptionThrownEventArgs> ExceptionThrown
		{
			add
			{
				this._client.AddEventHandler<ExceptionThrownEventArgs>("Runtime.exceptionThrown", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ExceptionThrownEventArgs>("Runtime.exceptionThrown", value);
			}
		}

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060009D1 RID: 2513 RVA: 0x0000EA1B File Offset: 0x0000CC1B
		// (remove) Token: 0x060009D2 RID: 2514 RVA: 0x0000EA2E File Offset: 0x0000CC2E
		public event EventHandler<ExecutionContextCreatedEventArgs> ExecutionContextCreated
		{
			add
			{
				this._client.AddEventHandler<ExecutionContextCreatedEventArgs>("Runtime.executionContextCreated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ExecutionContextCreatedEventArgs>("Runtime.executionContextCreated", value);
			}
		}

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x060009D3 RID: 2515 RVA: 0x0000EA42 File Offset: 0x0000CC42
		// (remove) Token: 0x060009D4 RID: 2516 RVA: 0x0000EA55 File Offset: 0x0000CC55
		public event EventHandler<ExecutionContextDestroyedEventArgs> ExecutionContextDestroyed
		{
			add
			{
				this._client.AddEventHandler<ExecutionContextDestroyedEventArgs>("Runtime.executionContextDestroyed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ExecutionContextDestroyedEventArgs>("Runtime.executionContextDestroyed", value);
			}
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x060009D5 RID: 2517 RVA: 0x0000EA69 File Offset: 0x0000CC69
		// (remove) Token: 0x060009D6 RID: 2518 RVA: 0x0000EA7C File Offset: 0x0000CC7C
		public event EventHandler<EventArgs> ExecutionContextsCleared
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("Runtime.executionContextsCleared", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("Runtime.executionContextsCleared", value);
			}
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060009D7 RID: 2519 RVA: 0x0000EA90 File Offset: 0x0000CC90
		// (remove) Token: 0x060009D8 RID: 2520 RVA: 0x0000EAA3 File Offset: 0x0000CCA3
		public event EventHandler<InspectRequestedEventArgs> InspectRequested
		{
			add
			{
				this._client.AddEventHandler<InspectRequestedEventArgs>("Runtime.inspectRequested", value);
			}
			remove
			{
				this._client.RemoveEventHandler<InspectRequestedEventArgs>("Runtime.inspectRequested", value);
			}
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0000EAB8 File Offset: 0x0000CCB8
		public Task<AwaitPromiseResponse> AwaitPromiseAsync(string promiseObjectId, bool? returnByValue = null, bool? generatePreview = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("promiseObjectId", promiseObjectId);
			if (returnByValue != null)
			{
				dictionary.Add("returnByValue", returnByValue.Value);
			}
			if (generatePreview != null)
			{
				dictionary.Add("generatePreview", generatePreview.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<AwaitPromiseResponse>("Runtime.awaitPromise", dictionary);
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x0000EB28 File Offset: 0x0000CD28
		public Task<CallFunctionOnResponse> CallFunctionOnAsync(string functionDeclaration, string objectId = null, IList<CallArgument> arguments = null, bool? silent = null, bool? returnByValue = null, bool? generatePreview = null, bool? userGesture = null, bool? awaitPromise = null, int? executionContextId = null, string objectGroup = null, bool? throwOnSideEffect = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("functionDeclaration", functionDeclaration);
			if (!string.IsNullOrEmpty(objectId))
			{
				dictionary.Add("objectId", objectId);
			}
			if (arguments != null)
			{
				dictionary.Add("arguments", from x in arguments
				select x.ToDictionary());
			}
			if (silent != null)
			{
				dictionary.Add("silent", silent.Value);
			}
			if (returnByValue != null)
			{
				dictionary.Add("returnByValue", returnByValue.Value);
			}
			if (generatePreview != null)
			{
				dictionary.Add("generatePreview", generatePreview.Value);
			}
			if (userGesture != null)
			{
				dictionary.Add("userGesture", userGesture.Value);
			}
			if (awaitPromise != null)
			{
				dictionary.Add("awaitPromise", awaitPromise.Value);
			}
			if (executionContextId != null)
			{
				dictionary.Add("executionContextId", executionContextId.Value);
			}
			if (!string.IsNullOrEmpty(objectGroup))
			{
				dictionary.Add("objectGroup", objectGroup);
			}
			if (throwOnSideEffect != null)
			{
				dictionary.Add("throwOnSideEffect", throwOnSideEffect.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<CallFunctionOnResponse>("Runtime.callFunctionOn", dictionary);
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0000EC98 File Offset: 0x0000CE98
		public Task<CompileScriptResponse> CompileScriptAsync(string expression, string sourceURL, bool persistScript, int? executionContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("expression", expression);
			dictionary.Add("sourceURL", sourceURL);
			dictionary.Add("persistScript", persistScript);
			if (executionContextId != null)
			{
				dictionary.Add("executionContextId", executionContextId.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<CompileScriptResponse>("Runtime.compileScript", dictionary);
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0000ED08 File Offset: 0x0000CF08
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.disable", parameters);
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0000ED28 File Offset: 0x0000CF28
		public Task<DevToolsMethodResponse> DiscardConsoleEntriesAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.discardConsoleEntries", parameters);
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0000ED48 File Offset: 0x0000CF48
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.enable", parameters);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x0000ED68 File Offset: 0x0000CF68
		public Task<EvaluateResponse> EvaluateAsync(string expression, string objectGroup = null, bool? includeCommandLineAPI = null, bool? silent = null, int? contextId = null, bool? returnByValue = null, bool? generatePreview = null, bool? userGesture = null, bool? awaitPromise = null, bool? throwOnSideEffect = null, double? timeout = null, bool? disableBreaks = null, bool? replMode = null, bool? allowUnsafeEvalBlockedByCSP = null, string uniqueContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("expression", expression);
			if (!string.IsNullOrEmpty(objectGroup))
			{
				dictionary.Add("objectGroup", objectGroup);
			}
			if (includeCommandLineAPI != null)
			{
				dictionary.Add("includeCommandLineAPI", includeCommandLineAPI.Value);
			}
			if (silent != null)
			{
				dictionary.Add("silent", silent.Value);
			}
			if (contextId != null)
			{
				dictionary.Add("contextId", contextId.Value);
			}
			if (returnByValue != null)
			{
				dictionary.Add("returnByValue", returnByValue.Value);
			}
			if (generatePreview != null)
			{
				dictionary.Add("generatePreview", generatePreview.Value);
			}
			if (userGesture != null)
			{
				dictionary.Add("userGesture", userGesture.Value);
			}
			if (awaitPromise != null)
			{
				dictionary.Add("awaitPromise", awaitPromise.Value);
			}
			if (throwOnSideEffect != null)
			{
				dictionary.Add("throwOnSideEffect", throwOnSideEffect.Value);
			}
			if (timeout != null)
			{
				dictionary.Add("timeout", timeout.Value);
			}
			if (disableBreaks != null)
			{
				dictionary.Add("disableBreaks", disableBreaks.Value);
			}
			if (replMode != null)
			{
				dictionary.Add("replMode", replMode.Value);
			}
			if (allowUnsafeEvalBlockedByCSP != null)
			{
				dictionary.Add("allowUnsafeEvalBlockedByCSP", allowUnsafeEvalBlockedByCSP.Value);
			}
			if (!string.IsNullOrEmpty(uniqueContextId))
			{
				dictionary.Add("uniqueContextId", uniqueContextId);
			}
			return this._client.ExecuteDevToolsMethodAsync<EvaluateResponse>("Runtime.evaluate", dictionary);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0000EF44 File Offset: 0x0000D144
		public Task<GetIsolateIdResponse> GetIsolateIdAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetIsolateIdResponse>("Runtime.getIsolateId", parameters);
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x0000EF64 File Offset: 0x0000D164
		public Task<GetHeapUsageResponse> GetHeapUsageAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetHeapUsageResponse>("Runtime.getHeapUsage", parameters);
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x0000EF84 File Offset: 0x0000D184
		public Task<GetPropertiesResponse> GetPropertiesAsync(string objectId, bool? ownProperties = null, bool? accessorPropertiesOnly = null, bool? generatePreview = null, bool? nonIndexedPropertiesOnly = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("objectId", objectId);
			if (ownProperties != null)
			{
				dictionary.Add("ownProperties", ownProperties.Value);
			}
			if (accessorPropertiesOnly != null)
			{
				dictionary.Add("accessorPropertiesOnly", accessorPropertiesOnly.Value);
			}
			if (generatePreview != null)
			{
				dictionary.Add("generatePreview", generatePreview.Value);
			}
			if (nonIndexedPropertiesOnly != null)
			{
				dictionary.Add("nonIndexedPropertiesOnly", nonIndexedPropertiesOnly.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetPropertiesResponse>("Runtime.getProperties", dictionary);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0000F034 File Offset: 0x0000D234
		public Task<GlobalLexicalScopeNamesResponse> GlobalLexicalScopeNamesAsync(int? executionContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (executionContextId != null)
			{
				dictionary.Add("executionContextId", executionContextId.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GlobalLexicalScopeNamesResponse>("Runtime.globalLexicalScopeNames", dictionary);
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x0000F078 File Offset: 0x0000D278
		public Task<QueryObjectsResponse> QueryObjectsAsync(string prototypeObjectId, string objectGroup = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("prototypeObjectId", prototypeObjectId);
			if (!string.IsNullOrEmpty(objectGroup))
			{
				dictionary.Add("objectGroup", objectGroup);
			}
			return this._client.ExecuteDevToolsMethodAsync<QueryObjectsResponse>("Runtime.queryObjects", dictionary);
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0000F0BC File Offset: 0x0000D2BC
		public Task<DevToolsMethodResponse> ReleaseObjectAsync(string objectId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("objectId", objectId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.releaseObject", dictionary);
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0000F0EC File Offset: 0x0000D2EC
		public Task<DevToolsMethodResponse> ReleaseObjectGroupAsync(string objectGroup)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("objectGroup", objectGroup);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.releaseObjectGroup", dictionary);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x0000F11C File Offset: 0x0000D31C
		public Task<DevToolsMethodResponse> RunIfWaitingForDebuggerAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.runIfWaitingForDebugger", parameters);
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0000F13C File Offset: 0x0000D33C
		public Task<RunScriptResponse> RunScriptAsync(string scriptId, int? executionContextId = null, string objectGroup = null, bool? silent = null, bool? includeCommandLineAPI = null, bool? returnByValue = null, bool? generatePreview = null, bool? awaitPromise = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scriptId", scriptId);
			if (executionContextId != null)
			{
				dictionary.Add("executionContextId", executionContextId.Value);
			}
			if (!string.IsNullOrEmpty(objectGroup))
			{
				dictionary.Add("objectGroup", objectGroup);
			}
			if (silent != null)
			{
				dictionary.Add("silent", silent.Value);
			}
			if (includeCommandLineAPI != null)
			{
				dictionary.Add("includeCommandLineAPI", includeCommandLineAPI.Value);
			}
			if (returnByValue != null)
			{
				dictionary.Add("returnByValue", returnByValue.Value);
			}
			if (generatePreview != null)
			{
				dictionary.Add("generatePreview", generatePreview.Value);
			}
			if (awaitPromise != null)
			{
				dictionary.Add("awaitPromise", awaitPromise.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<RunScriptResponse>("Runtime.runScript", dictionary);
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0000F240 File Offset: 0x0000D440
		public Task<DevToolsMethodResponse> SetAsyncCallStackDepthAsync(int maxDepth)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("maxDepth", maxDepth);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.setAsyncCallStackDepth", dictionary);
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0000F278 File Offset: 0x0000D478
		public Task<DevToolsMethodResponse> SetCustomObjectFormatterEnabledAsync(bool enabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.setCustomObjectFormatterEnabled", dictionary);
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x0000F2B0 File Offset: 0x0000D4B0
		public Task<DevToolsMethodResponse> SetMaxCallStackSizeToCaptureAsync(int size)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("size", size);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.setMaxCallStackSizeToCapture", dictionary);
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x0000F2E8 File Offset: 0x0000D4E8
		public Task<DevToolsMethodResponse> TerminateExecutionAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.terminateExecution", parameters);
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0000F308 File Offset: 0x0000D508
		public Task<DevToolsMethodResponse> AddBindingAsync(string name, int? executionContextId = null, string executionContextName = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("name", name);
			if (executionContextId != null)
			{
				dictionary.Add("executionContextId", executionContextId.Value);
			}
			if (!string.IsNullOrEmpty(executionContextName))
			{
				dictionary.Add("executionContextName", executionContextName);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.addBinding", dictionary);
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0000F36C File Offset: 0x0000D56C
		public Task<DevToolsMethodResponse> RemoveBindingAsync(string name)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("name", name);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Runtime.removeBinding", dictionary);
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0000F39C File Offset: 0x0000D59C
		public Task<GetExceptionDetailsResponse> GetExceptionDetailsAsync(string errorObjectId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("errorObjectId", errorObjectId);
			return this._client.ExecuteDevToolsMethodAsync<GetExceptionDetailsResponse>("Runtime.getExceptionDetails", dictionary);
		}

		// Token: 0x04000571 RID: 1393
		private IDevToolsClient _client;
	}
}
