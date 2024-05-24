using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using Laplink.Tools.Helpers;

namespace Laplink.Pcmover.Configurator.FolderTools
{
	// Token: 0x02000008 RID: 8
	public class RestartManagerSession : IDisposable
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00002E84 File Offset: 0x00001084
		public RestartManagerSession(LlTraceSource ts)
		{
			this.SessionKey = Guid.NewGuid().ToString();
			this.ts = ts;
			IntPtr intPtr;
			int num = RestartManagerSession.StartSession(out intPtr, 0, this.SessionKey);
			if (num != 0)
			{
				if (ts != null)
				{
					ts.TraceVerbose(string.Format("RestartManagerSession: StartSession Error  {0}", num));
				}
				throw new Win32Exception(num);
			}
			this.Handle = intPtr;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002EF0 File Offset: 0x000010F0
		public RestartManagerSession(string sessionKey, LlTraceSource ts)
		{
			this.SessionKey = sessionKey;
			this.ts = ts;
			IntPtr intPtr;
			int num = RestartManagerSession.JoinSession(out intPtr, this.SessionKey);
			if (num != 0)
			{
				if (ts != null)
				{
					ts.TraceVerbose(string.Format("RestartManagerSession: JoinSession Error  {0}", num));
				}
				throw new Win32Exception(num);
			}
			this.Handle = intPtr;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002F49 File Offset: 0x00001149
		private IntPtr Handle { get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002F51 File Offset: 0x00001151
		public string SessionKey { get; }

		// Token: 0x06000044 RID: 68 RVA: 0x00002F59 File Offset: 0x00001159
		public void Dispose()
		{
			this.ReleaseUnmanagedResources();
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000045 RID: 69
		[DllImport("rstrtmgr", CharSet = CharSet.Auto, EntryPoint = "RmAddFilter")]
		private static extern int AddFilter(IntPtr sessionHandle, string fileName, RestartManagerSession.UniqueProcess application, string serviceName, RestartManagerSession.FilterAction filterAction);

		// Token: 0x06000046 RID: 70
		[DllImport("rstrtmgr", CharSet = CharSet.Auto, EntryPoint = "RmAddFilter")]
		private static extern int AddFilter(IntPtr sessionHandle, string fileName, IntPtr application, string serviceName, RestartManagerSession.FilterAction filterAction);

		// Token: 0x06000047 RID: 71
		[DllImport("rstrtmgr", EntryPoint = "RmEndSession")]
		private static extern int EndSession(IntPtr sessionHandle);

		// Token: 0x06000048 RID: 72
		[DllImport("rstrtmgr", CharSet = CharSet.Auto, EntryPoint = "RmJoinSession")]
		private static extern int JoinSession(out IntPtr sessionHandle, string strSessionKey);

		// Token: 0x06000049 RID: 73
		[DllImport("rstrtmgr", CharSet = CharSet.Auto, EntryPoint = "RmRegisterResources")]
		private static extern int RegisterResources(IntPtr sessionHandle, uint numberOfFiles, string[] fileNames, uint numberOfApplications, RestartManagerSession.UniqueProcess[] applications, uint numberOfServices, string[] serviceNames);

		// Token: 0x0600004A RID: 74
		[DllImport("rstrtmgr", EntryPoint = "RmRestart")]
		private static extern int Restart(IntPtr sessionHandle, int restartFlags, RestartManagerSession.WriteStatusCallback statusCallback);

		// Token: 0x0600004B RID: 75
		[DllImport("rstrtmgr", EntryPoint = "RmShutdown")]
		private static extern int Shutdown(IntPtr sessionHandle, RestartManagerSession.ShutdownType actionFlags, RestartManagerSession.WriteStatusCallback statusCallback);

		// Token: 0x0600004C RID: 76
		[DllImport("rstrtmgr", CharSet = CharSet.Auto, EntryPoint = "RmStartSession")]
		private static extern int StartSession(out IntPtr sessionHandle, int sessionFlags, string strSessionKey);

		// Token: 0x0600004D RID: 77 RVA: 0x00002F68 File Offset: 0x00001168
		public void FilterProcess(Process process, RestartManagerSession.FilterAction action)
		{
			int num = RestartManagerSession.AddFilter(this.Handle, null, RestartManagerSession.UniqueProcess.FromProcess(process), null, action);
			if (num != 0)
			{
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceVerbose(string.Format("RestartManagerSession: FilterProcess Error  {0}", num));
				}
				throw new Win32Exception(num);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002FB8 File Offset: 0x000011B8
		public void FilterProcessFile(FileInfo file, RestartManagerSession.FilterAction action)
		{
			int num = RestartManagerSession.AddFilter(this.Handle, file.FullName, IntPtr.Zero, null, action);
			if (num != 0)
			{
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceVerbose(string.Format("RestartManagerSession: FilterProcessFile Error  {0}", num));
				}
				throw new Win32Exception(num);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000300C File Offset: 0x0000120C
		public void FilterService(ServiceController service, RestartManagerSession.FilterAction action)
		{
			int num = RestartManagerSession.AddFilter(this.Handle, null, IntPtr.Zero, service.ServiceName, action);
			if (num != 0)
			{
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceVerbose(string.Format("RestartManagerSession: FilterService Error  {0}", num));
				}
				throw new Win32Exception(num);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003060 File Offset: 0x00001260
		public void RegisterProcess(params Process[] processes)
		{
			int num = RestartManagerSession.RegisterResources(this.Handle, 0U, new string[0], (uint)processes.Length, processes.Select(new Func<Process, RestartManagerSession.UniqueProcess>(RestartManagerSession.UniqueProcess.FromProcess)).ToArray<RestartManagerSession.UniqueProcess>(), 0U, new string[0]);
			if (num != 0)
			{
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceVerbose(string.Format("RestartManagerSession: RegisterProcess Error  {0}", num));
				}
				throw new Win32Exception(num);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000030CC File Offset: 0x000012CC
		public void RegisterProcessFile(params FileInfo[] files)
		{
			int num = RestartManagerSession.RegisterResources(this.Handle, (uint)files.Length, (from f in files
			select f.FullName).ToArray<string>(), 0U, new RestartManagerSession.UniqueProcess[0], 0U, new string[0]);
			if (num != 0)
			{
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceVerbose(string.Format("RestartManagerSession: RegisterProcessFile Error  {0}", num));
				}
				throw new Win32Exception(num);
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000314C File Offset: 0x0000134C
		public void RegisterService(params ServiceController[] services)
		{
			int num = RestartManagerSession.RegisterResources(this.Handle, 0U, new string[0], 0U, new RestartManagerSession.UniqueProcess[0], (uint)services.Length, (from s in services
			select s.ServiceName).ToArray<string>());
			if (num != 0)
			{
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceVerbose(string.Format("RestartManagerSession: RegisterService Error  {0}", num));
				}
				throw new Win32Exception(num);
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000031CC File Offset: 0x000013CC
		public void Restart(RestartManagerSession.WriteStatusCallback statusCallback)
		{
			int num = RestartManagerSession.Restart(this.Handle, 0, statusCallback);
			if (num != 0)
			{
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceVerbose(string.Format("RestartManagerSession: Restart Error  {0}", num));
				}
				throw new Win32Exception(num);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003212 File Offset: 0x00001412
		public void Restart()
		{
			this.Restart(null);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000321C File Offset: 0x0000141C
		public int Shutdown(RestartManagerSession.ShutdownType shutdownType, RestartManagerSession.WriteStatusCallback statusCallback)
		{
			int num = RestartManagerSession.Shutdown(this.Handle, shutdownType, statusCallback);
			if (num != 0)
			{
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceVerbose(string.Format("RestartManagerSession: Shutdown Error  {0}", num));
				}
			}
			return num;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000325C File Offset: 0x0000145C
		public void Shutdown(RestartManagerSession.ShutdownType shutdownType)
		{
			this.Shutdown(shutdownType, null);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003268 File Offset: 0x00001468
		private void ReleaseUnmanagedResources()
		{
			try
			{
				RestartManagerSession.EndSession(this.Handle);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003298 File Offset: 0x00001498
		~RestartManagerSession()
		{
			this.ReleaseUnmanagedResources();
		}

		// Token: 0x04000026 RID: 38
		private readonly LlTraceSource ts;

		// Token: 0x02000012 RID: 18
		// (Invoke) Token: 0x06000076 RID: 118
		public delegate void WriteStatusCallback(uint percentageCompleted);

		// Token: 0x02000013 RID: 19
		public enum FilterAction : uint
		{
			// Token: 0x04000070 RID: 112
			RmNoRestart = 1U,
			// Token: 0x04000071 RID: 113
			RmNoShutdown
		}

		// Token: 0x02000014 RID: 20
		[Flags]
		public enum ShutdownType : uint
		{
			// Token: 0x04000073 RID: 115
			Normal = 0U,
			// Token: 0x04000074 RID: 116
			ForceShutdown = 1U,
			// Token: 0x04000075 RID: 117
			ShutdownOnlyRegistered = 16U
		}

		// Token: 0x02000015 RID: 21
		private struct FileTime
		{
			// Token: 0x06000079 RID: 121 RVA: 0x000037F0 File Offset: 0x000019F0
			public static RestartManagerSession.FileTime FromDateTime(DateTime dateTime)
			{
				long num = dateTime.ToFileTime();
				return new RestartManagerSession.FileTime
				{
					HighDateTime = (uint)(num >> 32),
					LowDateTime = (uint)(num & (long)((ulong)-1))
				};
			}

			// Token: 0x04000076 RID: 118
			private uint LowDateTime;

			// Token: 0x04000077 RID: 119
			private uint HighDateTime;
		}

		// Token: 0x02000016 RID: 22
		private struct UniqueProcess
		{
			// Token: 0x0600007A RID: 122 RVA: 0x00003828 File Offset: 0x00001A28
			public static RestartManagerSession.UniqueProcess FromProcess(Process process)
			{
				return new RestartManagerSession.UniqueProcess
				{
					ProcessId = process.Id,
					ProcessStartTime = RestartManagerSession.FileTime.FromDateTime(process.StartTime)
				};
			}

			// Token: 0x04000078 RID: 120
			private int ProcessId;

			// Token: 0x04000079 RID: 121
			private RestartManagerSession.FileTime ProcessStartTime;
		}
	}
}
