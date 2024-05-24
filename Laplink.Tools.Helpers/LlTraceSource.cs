using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Laplink.Tools.Helpers
{
	// Token: 0x02000008 RID: 8
	public class LlTraceSource
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002B28 File Offset: 0x00000D28
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00002B45 File Offset: 0x00000D45
		public static LlTraceSource FirstTs
		{
			get
			{
				if (LlTraceSource._llts == null)
				{
					LlTraceSource._llts = new LlTraceSource("LlTraceSource");
				}
				return LlTraceSource._llts;
			}
			set
			{
				LlTraceSource._llts = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002B4D File Offset: 0x00000D4D
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002B55 File Offset: 0x00000D55
		public bool DisplaySeq { get; set; } = true;

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002B5E File Offset: 0x00000D5E
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002B66 File Offset: 0x00000D66
		public bool DisplayTime { get; set; } = true;

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002B6F File Offset: 0x00000D6F
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002B77 File Offset: 0x00000D77
		public bool DisplayThreadId { get; set; } = true;

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002B80 File Offset: 0x00000D80
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002B88 File Offset: 0x00000D88
		public string LogFileName
		{
			get
			{
				return this._logFileName;
			}
			set
			{
				if (value != this._logFileName)
				{
					this._logFileName = value;
					this.ChangeLogFile();
				}
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002BA5 File Offset: 0x00000DA5
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002BAD File Offset: 0x00000DAD
		public string PreviousLogFileSettingName { get; set; } = "PreviousLogFile";

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002BB6 File Offset: 0x00000DB6
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002BBE File Offset: 0x00000DBE
		public LlTraceSource.PreviousLogFileAction PreviousFileAction { get; set; } = LlTraceSource.PreviousLogFileAction.Delete;

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002BC7 File Offset: 0x00000DC7
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002BCF File Offset: 0x00000DCF
		public string EnabledSettingName { get; set; } = "LoggingEnabled";

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002BD8 File Offset: 0x00000DD8
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00002BEA File Offset: 0x00000DEA
		public SourceLevels Level
		{
			get
			{
				return this._ts.Switch.Level;
			}
			set
			{
				bool level = this._ts.Switch.Level != SourceLevels.Off;
				this._ts.Switch.Level = value;
				if (!level && value != SourceLevels.Off)
				{
					this.ChangeLogFile();
				}
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002C18 File Offset: 0x00000E18
		public LlTraceSource(string name)
		{
			this._ts = new TraceSource(name);
			Trace.AutoFlush = true;
			if (LlTraceSource._llts == null)
			{
				LlTraceSource._llts = this;
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002C7C File Offset: 0x00000E7C
		public void InitLoggingFromAppData(string relativePath)
		{
			Environment.SpecialFolder folder = IdentityHelper.IsAdministrator ? Environment.SpecialFolder.CommonApplicationData : Environment.SpecialFolder.ApplicationData;
			this.InitLogging(Path.Combine(Environment.GetFolderPath(folder), relativePath), Assembly.GetCallingAssembly());
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002CB0 File Offset: 0x00000EB0
		public void InitLogging(string textFile, Assembly callingAssembly = null)
		{
			string stringSetting = ConfigHelper.GetStringSetting(this.EnabledSettingName, "Off");
			SourceLevels level;
			if (!Enum.TryParse<SourceLevels>(stringSetting, true, out level))
			{
				bool flag;
				if (!bool.TryParse(stringSetting, out flag))
				{
					flag = false;
				}
				level = (flag ? SourceLevels.Verbose : SourceLevels.Off);
			}
			this.Level = level;
			stringSetting = ConfigHelper.GetStringSetting(this.PreviousLogFileSettingName, this.PreviousFileAction.ToString());
			LlTraceSource.PreviousLogFileAction previousFileAction;
			if (Enum.TryParse<LlTraceSource.PreviousLogFileAction>(stringSetting, out previousFileAction))
			{
				this.PreviousFileAction = previousFileAction;
			}
			this.LogFileName = textFile;
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			if (entryAssembly != null)
			{
				string assemblyText = this.GetAssemblyText(entryAssembly);
				if (callingAssembly == null)
				{
					callingAssembly = Assembly.GetCallingAssembly();
				}
				string assemblyText2 = this.GetAssemblyText(callingAssembly);
				if (assemblyText2 == assemblyText)
				{
					this.TraceInformation(string.Format("{0} log starting at {1}", assemblyText, DateTime.Now));
					return;
				}
				this.TraceInformation(string.Format("{0} log from {1} starting at {2}", assemblyText, assemblyText2, DateTime.Now));
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002DA8 File Offset: 0x00000FA8
		private string GetAssemblyText(Assembly assembly)
		{
			if (assembly == null)
			{
				return null;
			}
			AssemblyName name = assembly.GetName();
			return string.Format("{0} {1}", name.Name, name.Version);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002DDD File Offset: 0x00000FDD
		private void ChangeLogFile()
		{
			if (this.Level != SourceLevels.Off && !string.IsNullOrWhiteSpace(this.LogFileName))
			{
				CodeHelper.trycatch(delegate()
				{
					if (this._myTraceListener != null)
					{
						this._myTraceListener.Dispose();
						this._ts.Listeners.Remove(this._myTraceListener);
						this._myTraceListener = null;
					}
					Directory.CreateDirectory(Path.GetDirectoryName(this.LogFileName));
					this.ProcessPreviousLogFile();
					this._myTraceListener = new LlTextWriterTraceListener(this.LogFileName)
					{
						DisplaySeq = this.DisplaySeq,
						DisplayTime = this.DisplayTime,
						DisplayThreadId = this.DisplayThreadId
					};
					this._ts.Listeners.Add(this._myTraceListener);
				});
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002E08 File Offset: 0x00001008
		private void ProcessPreviousLogFile()
		{
			if (this.PreviousFileAction == LlTraceSource.PreviousLogFileAction.Append)
			{
				return;
			}
			FileInfo fileInfo = new FileInfo(this.LogFileName);
			if (!fileInfo.Exists)
			{
				return;
			}
			if (this.PreviousFileAction == LlTraceSource.PreviousLogFileAction.Delete)
			{
				CodeHelper.trycatch(delegate()
				{
					fileInfo.Delete();
				});
				return;
			}
			string directoryName = fileInfo.DirectoryName;
			string extension = fileInfo.Extension;
			string text = Path.GetFileNameWithoutExtension(fileInfo.Name);
			text += fileInfo.LastWriteTime.ToString("_yyyyMMdd_HHmmss");
			string fullPath = Path.Combine(directoryName, text + extension);
			if (File.Exists(fullPath))
			{
				fullPath = Path.Combine(directoryName, string.Format("{0}_{1}{2}", text, Guid.NewGuid(), extension));
			}
			CodeHelper.trycatch(delegate()
			{
				File.Move(this.LogFileName, fullPath);
			});
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002F01 File Offset: 0x00001101
		public bool ShouldTrace(TraceEventType eventType)
		{
			return this._ts.Switch.ShouldTrace(eventType);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002F14 File Offset: 0x00001114
		[Conditional("TRACE")]
		public void TraceEvent(TraceEventType eventType, int id, string message)
		{
			this._ts.TraceEvent(eventType, id, message);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002F24 File Offset: 0x00001124
		[Conditional("TRACE")]
		public void TraceEvent(TraceEventType eventType, int id, string format, params object[] args)
		{
			this._ts.TraceEvent(eventType, id, format, args);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002F36 File Offset: 0x00001136
		[Conditional("TRACE")]
		public void TraceEvent(TraceEventType eventType, string message)
		{
			this.TraceEvent(eventType, 0, message);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002F41 File Offset: 0x00001141
		[Conditional("TRACE")]
		public void TraceError(string message)
		{
			this.TraceEvent(TraceEventType.Error, 0, message);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002F4C File Offset: 0x0000114C
		[Conditional("TRACE")]
		public void TraceError(string format, params object[] args)
		{
			this.TraceEvent(TraceEventType.Error, 0, format, args);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002F58 File Offset: 0x00001158
		[Conditional("TRACE")]
		public void TraceWarning(string message)
		{
			this.TraceEvent(TraceEventType.Warning, 0, message);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002F63 File Offset: 0x00001163
		[Conditional("TRACE")]
		public void TraceWarning(string format, params object[] args)
		{
			this.TraceEvent(TraceEventType.Warning, 0, format, args);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002F6F File Offset: 0x0000116F
		[Conditional("TRACE")]
		public void TraceInformation(string message)
		{
			this.TraceEvent(TraceEventType.Information, 0, message);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002F7A File Offset: 0x0000117A
		[Conditional("TRACE")]
		public void TraceInformation(string format, params object[] args)
		{
			this.TraceEvent(TraceEventType.Information, 0, format, args);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002F86 File Offset: 0x00001186
		[Conditional("TRACE")]
		public void TraceVerbose(string message)
		{
			this.TraceEvent(TraceEventType.Verbose, 0, message);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002F92 File Offset: 0x00001192
		[Conditional("TRACE")]
		public void TraceVerbose(string format, params object[] args)
		{
			this.TraceEvent(TraceEventType.Verbose, 0, format, args);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002F9F File Offset: 0x0000119F
		[Conditional("TRACE")]
		public void TraceCaller(string message, [CallerMemberName] string caller = "")
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				this.TraceInformation(caller);
				return;
			}
			this.TraceInformation(caller + ": " + message);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002FC3 File Offset: 0x000011C3
		[Conditional("TRACE")]
		public void TraceCaller(TraceEventType type, string message, [CallerMemberName] string caller = "")
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				this.TraceEvent(type, caller);
				return;
			}
			this.TraceEvent(type, caller + ": " + message);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002FE9 File Offset: 0x000011E9
		[Conditional("TRACE")]
		public void TraceException(Exception ex, [CallerMemberName] string caller = "")
		{
			this.TraceException(ex, LlTraceSource.ExceptionDetails.Standard, caller);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002FF4 File Offset: 0x000011F4
		[Conditional("TRACE")]
		public void TraceException(Exception ex, LlTraceSource.ExceptionDetails details, [CallerMemberName] string caller = "")
		{
			string text = LlTraceSource.BuildExceptionMessage(ex, details, string.Empty);
			if (details.HasFlag(LlTraceSource.ExceptionDetails.InnerException))
			{
				Exception ex2 = ex.InnerException;
				if (ex2 != null)
				{
					string str = LlTraceSource.BuildExceptionMessage(ex2, details, "InnerException: ");
					text = text + "\n" + str;
					if (ex2.InnerException != null)
					{
						ex2 = ex2.GetBaseException();
						str = LlTraceSource.BuildExceptionMessage(ex2, details, "BaseException: ");
						text = text + "\n" + str;
					}
				}
			}
			if (details.HasFlag(LlTraceSource.ExceptionDetails.StackTrace) && !string.IsNullOrWhiteSpace(ex.StackTrace))
			{
				text = text + "\nStack:\n" + ex.StackTrace;
			}
			this.TraceEvent(TraceEventType.Error, caller + ": " + text);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000030B4 File Offset: 0x000012B4
		private static string BuildExceptionMessage(Exception ex, LlTraceSource.ExceptionDetails details, string prompt)
		{
			string str = details.HasFlag(LlTraceSource.ExceptionDetails.Type) ? ex.GetType().ToString() : "Exception";
			string result;
			if (details.HasFlag(LlTraceSource.ExceptionDetails.Message))
			{
				result = prompt + str + " occurred: " + ex.Message;
			}
			else
			{
				result = prompt + str + " occurred";
			}
			return result;
		}

		// Token: 0x0400000B RID: 11
		private static LlTraceSource _llts;

		// Token: 0x0400000F RID: 15
		private string _logFileName;

		// Token: 0x04000013 RID: 19
		private readonly TraceSource _ts;

		// Token: 0x04000014 RID: 20
		private TraceListener _myTraceListener;

		// Token: 0x0200000D RID: 13
		public enum PreviousLogFileAction
		{
			// Token: 0x0400002D RID: 45
			Append,
			// Token: 0x0400002E RID: 46
			Delete,
			// Token: 0x0400002F RID: 47
			Rename
		}

		// Token: 0x0200000E RID: 14
		[Flags]
		public enum ExceptionDetails
		{
			// Token: 0x04000031 RID: 49
			Type = 1,
			// Token: 0x04000032 RID: 50
			Message = 2,
			// Token: 0x04000033 RID: 51
			InnerException = 4,
			// Token: 0x04000034 RID: 52
			StackTrace = 8,
			// Token: 0x04000035 RID: 53
			Standard = 7,
			// Token: 0x04000036 RID: 54
			All = 15
		}
	}
}
