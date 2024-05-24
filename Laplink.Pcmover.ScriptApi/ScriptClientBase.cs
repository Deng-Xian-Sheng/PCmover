using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading;
using Laplink.Tools.Helpers;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x02000007 RID: 7
	public abstract class ScriptClientBase : ICommunicationObject, IDisposable
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000025DB File Offset: 0x000007DB
		public LlTraceSource Ts { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000025E3 File Offset: 0x000007E3
		// (set) Token: 0x0600002D RID: 45 RVA: 0x000025EB File Offset: 0x000007EB
		private protected ScriptChannelBase ChannelBase { protected get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000025F4 File Offset: 0x000007F4
		public IScriptChannel Channel
		{
			get
			{
				return this.ChannelBase;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000025FC File Offset: 0x000007FC
		public Uri Uri { get; }

		// Token: 0x06000030 RID: 48 RVA: 0x00002604 File Offset: 0x00000804
		public ScriptClientBase(Uri uri, LlTraceSource ts)
		{
			this.Ts = ts;
			this.Uri = uri;
			if (uri.Scheme == LlEndpoint.UriSchemeWmi)
			{
				this.ChannelBase = new WmiScriptChannel(this, uri);
			}
			else
			{
				if (!(uri.Scheme == LlEndpoint.UriSchemeEma))
				{
					throw new EndpointNotFoundException("Unsupported script scheme " + uri.Scheme);
				}
				this.ChannelBase = new EmaScriptChannel(this, uri);
			}
			this.State = CommunicationState.Created;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000026CC File Offset: 0x000008CC
		public ScriptClientBase(ScriptChannelBase channelBase, Uri uri, LlTraceSource ts)
		{
			this.Ts = ts;
			this.Uri = uri;
			this.ChannelBase = channelBase;
			this.State = this.ChannelBase.ClientBase.State;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002752 File Offset: 0x00000952
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				if (disposing)
				{
					this.StopEventPolling();
					if (this.ChannelBase.ClientBase == this)
					{
						this.ChannelBase.CloseConnection();
					}
				}
				this.disposedValue = true;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002788 File Offset: 0x00000988
		~ScriptClientBase()
		{
			this.Dispose(false);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000027B8 File Offset: 0x000009B8
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000027C7 File Offset: 0x000009C7
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000027CF File Offset: 0x000009CF
		public bool IsAborted { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000027D8 File Offset: 0x000009D8
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000027EC File Offset: 0x000009EC
		public CommunicationState State
		{
			get
			{
				return this.ChannelBase.ClientBase._state;
			}
			set
			{
				if (this.ChannelBase.ClientBase == this)
				{
					object stateLock = this._stateLock;
					lock (stateLock)
					{
						if (value != this._state)
						{
							this._state = value;
							switch (value)
							{
							case CommunicationState.Opening:
							{
								EventHandler opening = this.Opening;
								if (opening != null)
								{
									opening(this, EventArgs.Empty);
								}
								break;
							}
							case CommunicationState.Opened:
							{
								EventHandler opened = this.Opened;
								if (opened != null)
								{
									opened(this, EventArgs.Empty);
								}
								break;
							}
							case CommunicationState.Closing:
							{
								EventHandler closing = this.Closing;
								if (closing != null)
								{
									closing(this, EventArgs.Empty);
								}
								break;
							}
							case CommunicationState.Closed:
							{
								EventHandler closed = this.Closed;
								if (closed != null)
								{
									closed(this, EventArgs.Empty);
								}
								break;
							}
							case CommunicationState.Faulted:
							{
								EventHandler faulted = this.Faulted;
								if (faulted != null)
								{
									faulted(this, EventArgs.Empty);
								}
								break;
							}
							}
						}
						return;
					}
				}
				this.ChannelBase.ClientBase.State = value;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000039 RID: 57 RVA: 0x000028FC File Offset: 0x00000AFC
		// (remove) Token: 0x0600003A RID: 58 RVA: 0x00002934 File Offset: 0x00000B34
		public event EventHandler Closed;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600003B RID: 59 RVA: 0x0000296C File Offset: 0x00000B6C
		// (remove) Token: 0x0600003C RID: 60 RVA: 0x000029A4 File Offset: 0x00000BA4
		public event EventHandler Closing;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600003D RID: 61 RVA: 0x000029DC File Offset: 0x00000BDC
		// (remove) Token: 0x0600003E RID: 62 RVA: 0x00002A14 File Offset: 0x00000C14
		public event EventHandler Faulted;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600003F RID: 63 RVA: 0x00002A4C File Offset: 0x00000C4C
		// (remove) Token: 0x06000040 RID: 64 RVA: 0x00002A84 File Offset: 0x00000C84
		public event EventHandler Opened;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000041 RID: 65 RVA: 0x00002ABC File Offset: 0x00000CBC
		// (remove) Token: 0x06000042 RID: 66 RVA: 0x00002AF4 File Offset: 0x00000CF4
		public event EventHandler Opening;

		// Token: 0x06000043 RID: 67 RVA: 0x00002B2C File Offset: 0x00000D2C
		public void Abort()
		{
			if (this.ChannelBase.ClientBase == this)
			{
				object stateLock = this._stateLock;
				lock (stateLock)
				{
					if (this.State != CommunicationState.Closed)
					{
						this._state = CommunicationState.Closed;
						this.IsAborted = true;
					}
					return;
				}
			}
			this.ChannelBase.ClientBase.Abort();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002B9C File Offset: 0x00000D9C
		public void Close()
		{
			if (this.ChannelBase.ClientBase == this)
			{
				object stateLock = this._stateLock;
				lock (stateLock)
				{
					switch (this.State)
					{
					case CommunicationState.Created:
						this.Abort();
						break;
					case CommunicationState.Opening:
						this.Abort();
						break;
					case CommunicationState.Opened:
						this.State = CommunicationState.Closing;
						this.ChannelBase.CloseConnection();
						this.State = CommunicationState.Closed;
						break;
					case CommunicationState.Faulted:
						this.Ts.TraceError("Cannot Close in Faulted state");
						throw new CommunicationObjectFaultedException();
					}
					return;
				}
			}
			this.ChannelBase.ClientBase.Close();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002C60 File Offset: 0x00000E60
		public void Close(TimeSpan timeSpan)
		{
			this.Close();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002C68 File Offset: 0x00000E68
		public void Open()
		{
			if (this.ChannelBase.ClientBase == this)
			{
				object stateLock = this._stateLock;
				lock (stateLock)
				{
					if (this.State != CommunicationState.Created)
					{
						this.ThrowCommunicationException(string.Format("Cannot Open in {0} state", this.State), null);
					}
					this.State = CommunicationState.Opening;
				}
				this.ChannelBase.Open();
				this.FinishOpen();
				this.State = CommunicationState.Opened;
				return;
			}
			this.ChannelBase.ClientBase.Open();
		}

		// Token: 0x06000047 RID: 71
		protected abstract void FinishOpen();

		// Token: 0x06000048 RID: 72 RVA: 0x00002D04 File Offset: 0x00000F04
		public void Open(TimeSpan timeout)
		{
			this.Open();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002D0C File Offset: 0x00000F0C
		public IAsyncResult BeginClose(AsyncCallback callback, object state)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002D13 File Offset: 0x00000F13
		public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002D1A File Offset: 0x00000F1A
		public void EndClose(IAsyncResult result)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002D21 File Offset: 0x00000F21
		public IAsyncResult BeginOpen(AsyncCallback callback, object state)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002D28 File Offset: 0x00000F28
		public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002D2F File Offset: 0x00000F2F
		public void EndOpen(IAsyncResult result)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002D36 File Offset: 0x00000F36
		public void ThrowCommunicationException(string msg, Exception innerException = null)
		{
			this.Ts.TraceError(msg);
			this.State = CommunicationState.Faulted;
			throw new CommunicationException(msg, innerException);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002D52 File Offset: 0x00000F52
		public void ThrowScriptException(ScriptResult res, string script, string msg)
		{
			this.Ts.TraceError(string.Format("{0} processing {1}: {2}", res, script, msg));
			this.State = CommunicationState.Faulted;
			throw ScriptException.Create(res, script, msg, null);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002D81 File Offset: 0x00000F81
		public void ThrowNotImplementedException([CallerMemberName] string message = "")
		{
			this.Ts.TraceError("Not implemented: " + message);
			this.State = CommunicationState.Faulted;
			throw new NotImplementedException(message);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002DA6 File Offset: 0x00000FA6
		protected static bool ScriptResultToBool(string scriptResult)
		{
			return scriptResult != "0";
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002DB3 File Offset: 0x00000FB3
		protected static T ScriptResultToEnum<T>(string scriptResult) where T : Enum
		{
			return (T)((object)Enum.Parse(typeof(T), scriptResult));
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002DCC File Offset: 0x00000FCC
		protected static string ParseValue(string[] data, string Property)
		{
			try
			{
				string text = data.FirstOrDefault((string x) => x.Trim().StartsWith(Property));
				if (text != null)
				{
					string text2 = string.Empty;
					if (text.Contains("="))
					{
						text2 = text.Substring(text.IndexOf("=") + 1);
					}
					else if (text.Contains(":"))
					{
						text2 = text.Substring(text.IndexOf(":") + 1);
					}
					return text2.Trim();
				}
			}
			catch (Exception)
			{
			}
			return string.Empty;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002E6C File Offset: 0x0000106C
		public static string CreateScriptString(string val)
		{
			string text = (val != null) ? val.Replace("\\", "\\\\") : null;
			text = ((text != null) ? text.Replace("\"", "\\\"") : null);
			return "\"" + text + "\"";
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002EBB File Offset: 0x000010BB
		protected void StartEventPolling()
		{
			this._eventPollingTimer = new Timer(new TimerCallback(this.OnEventPoll));
			this._eventPollingTimer.Change(this._eventPollingTime, this._eventPollingTime);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002EEC File Offset: 0x000010EC
		private void StopEventPolling()
		{
			Timer eventPollingTimer = this._eventPollingTimer;
			if (eventPollingTimer == null)
			{
				return;
			}
			eventPollingTimer.Change(-1, -1);
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002F01 File Offset: 0x00001101
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002F09 File Offset: 0x00001109
		protected string GetPendingEventsScript { get; set; }

		// Token: 0x0600005A RID: 90 RVA: 0x00002F14 File Offset: 0x00001114
		private void OnEventPoll(object state)
		{
			if (this.State != CommunicationState.Opened)
			{
				return;
			}
			try
			{
				if (!string.IsNullOrWhiteSpace(this.GetPendingEventsScript))
				{
					string pendingEvents = this.ChannelBase.InvokeScript(this.GetPendingEventsScript);
					this.ProcessEvents(pendingEvents);
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "OnEventPoll");
				this.StopEventPolling();
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002F80 File Offset: 0x00001180
		private void ProcessEvents(string pendingEvents)
		{
			foreach (string text in pendingEvents.Split(this._newLineChars, StringSplitOptions.RemoveEmptyEntries))
			{
				int num = text.IndexOf(": ");
				if (num < 0)
				{
					this.Ts.TraceVerbose("Invalid event format: " + text);
				}
				else
				{
					text.Substring(0, num);
					int num2 = num + 2;
					int num3 = text.IndexOf(':', num2);
					string eventName;
					string eventData;
					if (num3 > 0)
					{
						eventName = text.Substring(num2, num3 - num2);
						eventData = text.Substring(num3 + 1);
					}
					else
					{
						eventName = text.Substring(num2);
						eventData = string.Empty;
					}
					this.ProcessEvent(eventName, eventData);
				}
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003032 File Offset: 0x00001232
		protected virtual void ProcessEvent(string eventName, string eventData)
		{
		}

		// Token: 0x0400000F RID: 15
		private bool disposedValue;

		// Token: 0x04000010 RID: 16
		private object _stateLock = new object();

		// Token: 0x04000012 RID: 18
		private CommunicationState _state = CommunicationState.Closed;

		// Token: 0x04000018 RID: 24
		private Timer _eventPollingTimer;

		// Token: 0x04000019 RID: 25
		private TimeSpan _eventPollingTime = TimeSpan.FromSeconds(2.0);

		// Token: 0x0400001B RID: 27
		protected char[] _newLineChars = new char[]
		{
			'\n'
		};

		// Token: 0x0400001C RID: 28
		protected char[] _commaChars = new char[]
		{
			','
		};
	}
}
