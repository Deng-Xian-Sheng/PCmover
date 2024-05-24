using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000192 RID: 402
	public class DebuggerClient : DevToolsDomainBase
	{
		// Token: 0x06000BB0 RID: 2992 RVA: 0x00010801 File Offset: 0x0000EA01
		public DebuggerClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x06000BB1 RID: 2993 RVA: 0x00010810 File Offset: 0x0000EA10
		// (remove) Token: 0x06000BB2 RID: 2994 RVA: 0x00010823 File Offset: 0x0000EA23
		public event EventHandler<BreakpointResolvedEventArgs> BreakpointResolved
		{
			add
			{
				this._client.AddEventHandler<BreakpointResolvedEventArgs>("Debugger.breakpointResolved", value);
			}
			remove
			{
				this._client.RemoveEventHandler<BreakpointResolvedEventArgs>("Debugger.breakpointResolved", value);
			}
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06000BB3 RID: 2995 RVA: 0x00010837 File Offset: 0x0000EA37
		// (remove) Token: 0x06000BB4 RID: 2996 RVA: 0x0001084A File Offset: 0x0000EA4A
		public event EventHandler<PausedEventArgs> Paused
		{
			add
			{
				this._client.AddEventHandler<PausedEventArgs>("Debugger.paused", value);
			}
			remove
			{
				this._client.RemoveEventHandler<PausedEventArgs>("Debugger.paused", value);
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06000BB5 RID: 2997 RVA: 0x0001085E File Offset: 0x0000EA5E
		// (remove) Token: 0x06000BB6 RID: 2998 RVA: 0x00010871 File Offset: 0x0000EA71
		public event EventHandler<EventArgs> Resumed
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("Debugger.resumed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("Debugger.resumed", value);
			}
		}

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06000BB7 RID: 2999 RVA: 0x00010885 File Offset: 0x0000EA85
		// (remove) Token: 0x06000BB8 RID: 3000 RVA: 0x00010898 File Offset: 0x0000EA98
		public event EventHandler<ScriptFailedToParseEventArgs> ScriptFailedToParse
		{
			add
			{
				this._client.AddEventHandler<ScriptFailedToParseEventArgs>("Debugger.scriptFailedToParse", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ScriptFailedToParseEventArgs>("Debugger.scriptFailedToParse", value);
			}
		}

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06000BB9 RID: 3001 RVA: 0x000108AC File Offset: 0x0000EAAC
		// (remove) Token: 0x06000BBA RID: 3002 RVA: 0x000108BF File Offset: 0x0000EABF
		public event EventHandler<ScriptParsedEventArgs> ScriptParsed
		{
			add
			{
				this._client.AddEventHandler<ScriptParsedEventArgs>("Debugger.scriptParsed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ScriptParsedEventArgs>("Debugger.scriptParsed", value);
			}
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x000108D4 File Offset: 0x0000EAD4
		public Task<DevToolsMethodResponse> ContinueToLocationAsync(Location location, ContinueToLocationTargetCallFrames? targetCallFrames = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("location", location.ToDictionary());
			if (targetCallFrames != null)
			{
				dictionary.Add("targetCallFrames", base.EnumToString(targetCallFrames));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.continueToLocation", dictionary);
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x0001092C File Offset: 0x0000EB2C
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.disable", parameters);
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0001094C File Offset: 0x0000EB4C
		public Task<EnableResponse> EnableAsync(double? maxScriptsCacheSize = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (maxScriptsCacheSize != null)
			{
				dictionary.Add("maxScriptsCacheSize", maxScriptsCacheSize.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<EnableResponse>("Debugger.enable", dictionary);
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x00010990 File Offset: 0x0000EB90
		public Task<EvaluateOnCallFrameResponse> EvaluateOnCallFrameAsync(string callFrameId, string expression, string objectGroup = null, bool? includeCommandLineAPI = null, bool? silent = null, bool? returnByValue = null, bool? generatePreview = null, bool? throwOnSideEffect = null, double? timeout = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("callFrameId", callFrameId);
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
			if (returnByValue != null)
			{
				dictionary.Add("returnByValue", returnByValue.Value);
			}
			if (generatePreview != null)
			{
				dictionary.Add("generatePreview", generatePreview.Value);
			}
			if (throwOnSideEffect != null)
			{
				dictionary.Add("throwOnSideEffect", throwOnSideEffect.Value);
			}
			if (timeout != null)
			{
				dictionary.Add("timeout", timeout.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<EvaluateOnCallFrameResponse>("Debugger.evaluateOnCallFrame", dictionary);
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x00010AA0 File Offset: 0x0000ECA0
		public Task<GetPossibleBreakpointsResponse> GetPossibleBreakpointsAsync(Location start, Location end = null, bool? restrictToFunction = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("start", start.ToDictionary());
			if (end != null)
			{
				dictionary.Add("end", end.ToDictionary());
			}
			if (restrictToFunction != null)
			{
				dictionary.Add("restrictToFunction", restrictToFunction.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetPossibleBreakpointsResponse>("Debugger.getPossibleBreakpoints", dictionary);
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x00010B0C File Offset: 0x0000ED0C
		public Task<GetScriptSourceResponse> GetScriptSourceAsync(string scriptId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scriptId", scriptId);
			return this._client.ExecuteDevToolsMethodAsync<GetScriptSourceResponse>("Debugger.getScriptSource", dictionary);
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x00010B3C File Offset: 0x0000ED3C
		public Task<GetStackTraceResponse> GetStackTraceAsync(StackTraceId stackTraceId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("stackTraceId", stackTraceId.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<GetStackTraceResponse>("Debugger.getStackTrace", dictionary);
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x00010B74 File Offset: 0x0000ED74
		public Task<DevToolsMethodResponse> PauseAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.pause", parameters);
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x00010B94 File Offset: 0x0000ED94
		public Task<DevToolsMethodResponse> RemoveBreakpointAsync(string breakpointId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("breakpointId", breakpointId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.removeBreakpoint", dictionary);
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x00010BC4 File Offset: 0x0000EDC4
		public Task<DevToolsMethodResponse> ResumeAsync(bool? terminateOnResume = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (terminateOnResume != null)
			{
				dictionary.Add("terminateOnResume", terminateOnResume.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.resume", dictionary);
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x00010C08 File Offset: 0x0000EE08
		public Task<SearchInContentResponse> SearchInContentAsync(string scriptId, string query, bool? caseSensitive = null, bool? isRegex = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scriptId", scriptId);
			dictionary.Add("query", query);
			if (caseSensitive != null)
			{
				dictionary.Add("caseSensitive", caseSensitive.Value);
			}
			if (isRegex != null)
			{
				dictionary.Add("isRegex", isRegex.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<SearchInContentResponse>("Debugger.searchInContent", dictionary);
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x00010C84 File Offset: 0x0000EE84
		public Task<DevToolsMethodResponse> SetAsyncCallStackDepthAsync(int maxDepth)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("maxDepth", maxDepth);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.setAsyncCallStackDepth", dictionary);
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x00010CBC File Offset: 0x0000EEBC
		public Task<DevToolsMethodResponse> SetBlackboxPatternsAsync(string[] patterns)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("patterns", patterns);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.setBlackboxPatterns", dictionary);
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x00010CEC File Offset: 0x0000EEEC
		public Task<DevToolsMethodResponse> SetBlackboxedRangesAsync(string scriptId, IList<ScriptPosition> positions)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scriptId", scriptId);
			dictionary.Add("positions", from x in positions
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.setBlackboxedRanges", dictionary);
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x00010D4C File Offset: 0x0000EF4C
		public Task<SetBreakpointResponse> SetBreakpointAsync(Location location, string condition = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("location", location.ToDictionary());
			if (!string.IsNullOrEmpty(condition))
			{
				dictionary.Add("condition", condition);
			}
			return this._client.ExecuteDevToolsMethodAsync<SetBreakpointResponse>("Debugger.setBreakpoint", dictionary);
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x00010D98 File Offset: 0x0000EF98
		public Task<SetInstrumentationBreakpointResponse> SetInstrumentationBreakpointAsync(SetInstrumentationBreakpointInstrumentation instrumentation)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("instrumentation", base.EnumToString(instrumentation));
			return this._client.ExecuteDevToolsMethodAsync<SetInstrumentationBreakpointResponse>("Debugger.setInstrumentationBreakpoint", dictionary);
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x00010DD4 File Offset: 0x0000EFD4
		public Task<SetBreakpointByUrlResponse> SetBreakpointByUrlAsync(int lineNumber, string url = null, string urlRegex = null, string scriptHash = null, int? columnNumber = null, string condition = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("lineNumber", lineNumber);
			if (!string.IsNullOrEmpty(url))
			{
				dictionary.Add("url", url);
			}
			if (!string.IsNullOrEmpty(urlRegex))
			{
				dictionary.Add("urlRegex", urlRegex);
			}
			if (!string.IsNullOrEmpty(scriptHash))
			{
				dictionary.Add("scriptHash", scriptHash);
			}
			if (columnNumber != null)
			{
				dictionary.Add("columnNumber", columnNumber.Value);
			}
			if (!string.IsNullOrEmpty(condition))
			{
				dictionary.Add("condition", condition);
			}
			return this._client.ExecuteDevToolsMethodAsync<SetBreakpointByUrlResponse>("Debugger.setBreakpointByUrl", dictionary);
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x00010E80 File Offset: 0x0000F080
		public Task<SetBreakpointOnFunctionCallResponse> SetBreakpointOnFunctionCallAsync(string objectId, string condition = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("objectId", objectId);
			if (!string.IsNullOrEmpty(condition))
			{
				dictionary.Add("condition", condition);
			}
			return this._client.ExecuteDevToolsMethodAsync<SetBreakpointOnFunctionCallResponse>("Debugger.setBreakpointOnFunctionCall", dictionary);
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x00010EC4 File Offset: 0x0000F0C4
		public Task<DevToolsMethodResponse> SetBreakpointsActiveAsync(bool active)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("active", active);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.setBreakpointsActive", dictionary);
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x00010EFC File Offset: 0x0000F0FC
		public Task<DevToolsMethodResponse> SetPauseOnExceptionsAsync(SetPauseOnExceptionsState state)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("state", base.EnumToString(state));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.setPauseOnExceptions", dictionary);
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x00010F38 File Offset: 0x0000F138
		public Task<DevToolsMethodResponse> SetReturnValueAsync(CallArgument newValue)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("newValue", newValue.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.setReturnValue", dictionary);
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x00010F70 File Offset: 0x0000F170
		public Task<SetScriptSourceResponse> SetScriptSourceAsync(string scriptId, string scriptSource, bool? dryRun = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scriptId", scriptId);
			dictionary.Add("scriptSource", scriptSource);
			if (dryRun != null)
			{
				dictionary.Add("dryRun", dryRun.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<SetScriptSourceResponse>("Debugger.setScriptSource", dictionary);
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x00010FCC File Offset: 0x0000F1CC
		public Task<DevToolsMethodResponse> SetSkipAllPausesAsync(bool skip)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("skip", skip);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.setSkipAllPauses", dictionary);
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x00011004 File Offset: 0x0000F204
		public Task<DevToolsMethodResponse> SetVariableValueAsync(int scopeNumber, string variableName, CallArgument newValue, string callFrameId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scopeNumber", scopeNumber);
			dictionary.Add("variableName", variableName);
			dictionary.Add("newValue", newValue.ToDictionary());
			dictionary.Add("callFrameId", callFrameId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.setVariableValue", dictionary);
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x00011064 File Offset: 0x0000F264
		public Task<DevToolsMethodResponse> StepIntoAsync(bool? breakOnAsyncCall = null, IList<LocationRange> skipList = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (breakOnAsyncCall != null)
			{
				dictionary.Add("breakOnAsyncCall", breakOnAsyncCall.Value);
			}
			if (skipList != null)
			{
				dictionary.Add("skipList", from x in skipList
				select x.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.stepInto", dictionary);
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x000110DC File Offset: 0x0000F2DC
		public Task<DevToolsMethodResponse> StepOutAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.stepOut", parameters);
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x000110FC File Offset: 0x0000F2FC
		public Task<DevToolsMethodResponse> StepOverAsync(IList<LocationRange> skipList = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (skipList != null)
			{
				dictionary.Add("skipList", from x in skipList
				select x.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Debugger.stepOver", dictionary);
		}

		// Token: 0x0400063F RID: 1599
		private IDevToolsClient _client;
	}
}
