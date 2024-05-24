using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Diagnostics
{
	// Token: 0x020003F3 RID: 1011
	internal static class Log
	{
		// Token: 0x06003334 RID: 13108 RVA: 0x000C4E79 File Offset: 0x000C3079
		static Log()
		{
			Log.GlobalSwitch.MinimumLevel = LoggingLevels.ErrorLevel;
		}

		// Token: 0x06003335 RID: 13109 RVA: 0x000C4EB8 File Offset: 0x000C30B8
		public static void AddOnLogMessage(LogMessageEventHandler handler)
		{
			object obj = Log.locker;
			lock (obj)
			{
				Log._LogMessageEventHandler = (LogMessageEventHandler)Delegate.Combine(Log._LogMessageEventHandler, handler);
			}
		}

		// Token: 0x06003336 RID: 13110 RVA: 0x000C4F08 File Offset: 0x000C3108
		public static void RemoveOnLogMessage(LogMessageEventHandler handler)
		{
			object obj = Log.locker;
			lock (obj)
			{
				Log._LogMessageEventHandler = (LogMessageEventHandler)Delegate.Remove(Log._LogMessageEventHandler, handler);
			}
		}

		// Token: 0x06003337 RID: 13111 RVA: 0x000C4F58 File Offset: 0x000C3158
		public static void AddOnLogSwitchLevel(LogSwitchLevelHandler handler)
		{
			object obj = Log.locker;
			lock (obj)
			{
				Log._LogSwitchLevelHandler = (LogSwitchLevelHandler)Delegate.Combine(Log._LogSwitchLevelHandler, handler);
			}
		}

		// Token: 0x06003338 RID: 13112 RVA: 0x000C4FAC File Offset: 0x000C31AC
		public static void RemoveOnLogSwitchLevel(LogSwitchLevelHandler handler)
		{
			object obj = Log.locker;
			lock (obj)
			{
				Log._LogSwitchLevelHandler = (LogSwitchLevelHandler)Delegate.Remove(Log._LogSwitchLevelHandler, handler);
			}
		}

		// Token: 0x06003339 RID: 13113 RVA: 0x000C5000 File Offset: 0x000C3200
		internal static void InvokeLogSwitchLevelHandlers(LogSwitch ls, LoggingLevels newLevel)
		{
			LogSwitchLevelHandler logSwitchLevelHandler = Log._LogSwitchLevelHandler;
			if (logSwitchLevelHandler != null)
			{
				logSwitchLevelHandler(ls, newLevel);
			}
		}

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x0600333A RID: 13114 RVA: 0x000C5020 File Offset: 0x000C3220
		// (set) Token: 0x0600333B RID: 13115 RVA: 0x000C5029 File Offset: 0x000C3229
		public static bool IsConsoleEnabled
		{
			get
			{
				return Log.m_fConsoleDeviceEnabled;
			}
			set
			{
				Log.m_fConsoleDeviceEnabled = value;
			}
		}

		// Token: 0x0600333C RID: 13116 RVA: 0x000C5033 File Offset: 0x000C3233
		public static void LogMessage(LoggingLevels level, string message)
		{
			Log.LogMessage(level, Log.GlobalSwitch, message);
		}

		// Token: 0x0600333D RID: 13117 RVA: 0x000C5044 File Offset: 0x000C3244
		public static void LogMessage(LoggingLevels level, LogSwitch logswitch, string message)
		{
			if (logswitch == null)
			{
				throw new ArgumentNullException("LogSwitch");
			}
			if (level < LoggingLevels.TraceLevel0)
			{
				throw new ArgumentOutOfRangeException("level", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (logswitch.CheckLevel(level))
			{
				Debugger.Log((int)level, logswitch.strName, message);
				if (Log.m_fConsoleDeviceEnabled)
				{
					Console.Write(message);
				}
			}
		}

		// Token: 0x0600333E RID: 13118 RVA: 0x000C509D File Offset: 0x000C329D
		public static void Trace(LogSwitch logswitch, string message)
		{
			Log.LogMessage(LoggingLevels.TraceLevel0, logswitch, message);
		}

		// Token: 0x0600333F RID: 13119 RVA: 0x000C50A8 File Offset: 0x000C32A8
		public static void Trace(string switchname, string message)
		{
			LogSwitch @switch = LogSwitch.GetSwitch(switchname);
			Log.LogMessage(LoggingLevels.TraceLevel0, @switch, message);
		}

		// Token: 0x06003340 RID: 13120 RVA: 0x000C50C4 File Offset: 0x000C32C4
		public static void Trace(string message)
		{
			Log.LogMessage(LoggingLevels.TraceLevel0, Log.GlobalSwitch, message);
		}

		// Token: 0x06003341 RID: 13121 RVA: 0x000C50D2 File Offset: 0x000C32D2
		public static void Status(LogSwitch logswitch, string message)
		{
			Log.LogMessage(LoggingLevels.StatusLevel0, logswitch, message);
		}

		// Token: 0x06003342 RID: 13122 RVA: 0x000C50E0 File Offset: 0x000C32E0
		public static void Status(string switchname, string message)
		{
			LogSwitch @switch = LogSwitch.GetSwitch(switchname);
			Log.LogMessage(LoggingLevels.StatusLevel0, @switch, message);
		}

		// Token: 0x06003343 RID: 13123 RVA: 0x000C50FD File Offset: 0x000C32FD
		public static void Status(string message)
		{
			Log.LogMessage(LoggingLevels.StatusLevel0, Log.GlobalSwitch, message);
		}

		// Token: 0x06003344 RID: 13124 RVA: 0x000C510C File Offset: 0x000C330C
		public static void Warning(LogSwitch logswitch, string message)
		{
			Log.LogMessage(LoggingLevels.WarningLevel, logswitch, message);
		}

		// Token: 0x06003345 RID: 13125 RVA: 0x000C5118 File Offset: 0x000C3318
		public static void Warning(string switchname, string message)
		{
			LogSwitch @switch = LogSwitch.GetSwitch(switchname);
			Log.LogMessage(LoggingLevels.WarningLevel, @switch, message);
		}

		// Token: 0x06003346 RID: 13126 RVA: 0x000C5135 File Offset: 0x000C3335
		public static void Warning(string message)
		{
			Log.LogMessage(LoggingLevels.WarningLevel, Log.GlobalSwitch, message);
		}

		// Token: 0x06003347 RID: 13127 RVA: 0x000C5144 File Offset: 0x000C3344
		public static void Error(LogSwitch logswitch, string message)
		{
			Log.LogMessage(LoggingLevels.ErrorLevel, logswitch, message);
		}

		// Token: 0x06003348 RID: 13128 RVA: 0x000C5150 File Offset: 0x000C3350
		public static void Error(string switchname, string message)
		{
			LogSwitch @switch = LogSwitch.GetSwitch(switchname);
			Log.LogMessage(LoggingLevels.ErrorLevel, @switch, message);
		}

		// Token: 0x06003349 RID: 13129 RVA: 0x000C516D File Offset: 0x000C336D
		public static void Error(string message)
		{
			Log.LogMessage(LoggingLevels.ErrorLevel, Log.GlobalSwitch, message);
		}

		// Token: 0x0600334A RID: 13130 RVA: 0x000C517C File Offset: 0x000C337C
		public static void Panic(string message)
		{
			Log.LogMessage(LoggingLevels.PanicLevel, Log.GlobalSwitch, message);
		}

		// Token: 0x0600334B RID: 13131
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void AddLogSwitch(LogSwitch logSwitch);

		// Token: 0x0600334C RID: 13132
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ModifyLogSwitch(int iNewLevel, string strSwitchName, string strParentName);

		// Token: 0x040016AE RID: 5806
		internal static Hashtable m_Hashtable = new Hashtable();

		// Token: 0x040016AF RID: 5807
		private static volatile bool m_fConsoleDeviceEnabled = false;

		// Token: 0x040016B0 RID: 5808
		private static LogMessageEventHandler _LogMessageEventHandler;

		// Token: 0x040016B1 RID: 5809
		private static volatile LogSwitchLevelHandler _LogSwitchLevelHandler;

		// Token: 0x040016B2 RID: 5810
		private static object locker = new object();

		// Token: 0x040016B3 RID: 5811
		public static readonly LogSwitch GlobalSwitch = new LogSwitch("Global", "Global Switch for this log");
	}
}
