using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using Microsoft.Win32;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200041E RID: 1054
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	internal class EventProvider : IDisposable
	{
		// Token: 0x0600344C RID: 13388 RVA: 0x000C7345 File Offset: 0x000C5545
		[SecurityCritical]
		[PermissionSet(SecurityAction.Demand, Unrestricted = true)]
		protected EventProvider(Guid providerGuid)
		{
			this.m_providerId = providerGuid;
			this.Register(providerGuid);
		}

		// Token: 0x0600344D RID: 13389 RVA: 0x000C735B File Offset: 0x000C555B
		internal EventProvider()
		{
		}

		// Token: 0x0600344E RID: 13390 RVA: 0x000C7364 File Offset: 0x000C5564
		[SecurityCritical]
		internal void Register(Guid providerGuid)
		{
			this.m_providerId = providerGuid;
			this.m_etwCallback = new UnsafeNativeMethods.ManifestEtw.EtwEnableCallback(this.EtwEnableCallBack);
			uint num = this.EventRegister(ref this.m_providerId, this.m_etwCallback);
			if (num != 0U)
			{
				throw new ArgumentException(Win32Native.GetMessage((int)num));
			}
		}

		// Token: 0x0600344F RID: 13391 RVA: 0x000C73AC File Offset: 0x000C55AC
		[SecurityCritical]
		internal unsafe int SetInformation(UnsafeNativeMethods.ManifestEtw.EVENT_INFO_CLASS eventInfoClass, void* data, int dataSize)
		{
			int result = 50;
			if (!EventProvider.m_setInformationMissing)
			{
				try
				{
					result = UnsafeNativeMethods.ManifestEtw.EventSetInformation(this.m_regHandle, eventInfoClass, data, dataSize);
				}
				catch (TypeLoadException)
				{
					EventProvider.m_setInformationMissing = true;
				}
			}
			return result;
		}

		// Token: 0x06003450 RID: 13392 RVA: 0x000C73F0 File Offset: 0x000C55F0
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06003451 RID: 13393 RVA: 0x000C7400 File Offset: 0x000C5600
		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			if (this.m_disposed)
			{
				return;
			}
			this.m_enabled = false;
			long num = 0L;
			object eventListenersLock = EventListener.EventListenersLock;
			lock (eventListenersLock)
			{
				if (this.m_disposed)
				{
					return;
				}
				num = this.m_regHandle;
				this.m_regHandle = 0L;
				this.m_disposed = true;
			}
			if (num != 0L)
			{
				this.EventUnregister(num);
			}
		}

		// Token: 0x06003452 RID: 13394 RVA: 0x000C7478 File Offset: 0x000C5678
		public virtual void Close()
		{
			this.Dispose();
		}

		// Token: 0x06003453 RID: 13395 RVA: 0x000C7480 File Offset: 0x000C5680
		~EventProvider()
		{
			this.Dispose(false);
		}

		// Token: 0x06003454 RID: 13396 RVA: 0x000C74B0 File Offset: 0x000C56B0
		[SecurityCritical]
		private unsafe void EtwEnableCallBack([In] ref Guid sourceId, [In] int controlCode, [In] byte setLevel, [In] long anyKeyword, [In] long allKeyword, [In] UnsafeNativeMethods.ManifestEtw.EVENT_FILTER_DESCRIPTOR* filterData, [In] void* callbackContext)
		{
			try
			{
				ControllerCommand command = ControllerCommand.Update;
				IDictionary<string, string> dictionary = null;
				bool flag = false;
				if (controlCode == 1)
				{
					this.m_enabled = true;
					this.m_level = setLevel;
					this.m_anyKeywordMask = anyKeyword;
					this.m_allKeywordMask = allKeyword;
					List<Tuple<EventProvider.SessionInfo, bool>> sessions = this.GetSessions();
					using (List<Tuple<EventProvider.SessionInfo, bool>>.Enumerator enumerator = sessions.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							Tuple<EventProvider.SessionInfo, bool> tuple = enumerator.Current;
							int sessionIdBit = tuple.Item1.sessionIdBit;
							int etwSessionId = tuple.Item1.etwSessionId;
							bool item = tuple.Item2;
							flag = true;
							dictionary = null;
							if (sessions.Count > 1)
							{
								filterData = null;
							}
							byte[] array;
							int i;
							if (item && this.GetDataFromController(etwSessionId, filterData, out command, out array, out i))
							{
								dictionary = new Dictionary<string, string>(4);
								while (i < array.Length)
								{
									int num = EventProvider.FindNull(array, i);
									int num2 = num + 1;
									int num3 = EventProvider.FindNull(array, num2);
									if (num3 < array.Length)
									{
										string @string = Encoding.UTF8.GetString(array, i, num - i);
										string string2 = Encoding.UTF8.GetString(array, num2, num3 - num2);
										dictionary[@string] = string2;
									}
									i = num3 + 1;
								}
							}
							this.OnControllerCommand(command, dictionary, item ? sessionIdBit : (-sessionIdBit), etwSessionId);
						}
						goto IL_162;
					}
				}
				if (controlCode == 0)
				{
					this.m_enabled = false;
					this.m_level = 0;
					this.m_anyKeywordMask = 0L;
					this.m_allKeywordMask = 0L;
					this.m_liveSessions = null;
				}
				else
				{
					if (controlCode != 2)
					{
						return;
					}
					command = ControllerCommand.SendManifest;
				}
				IL_162:
				if (!flag)
				{
					this.OnControllerCommand(command, dictionary, 0, 0);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06003455 RID: 13397 RVA: 0x000C7668 File Offset: 0x000C5868
		protected virtual void OnControllerCommand(ControllerCommand command, IDictionary<string, string> arguments, int sessionId, int etwSessionId)
		{
		}

		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x06003456 RID: 13398 RVA: 0x000C766A File Offset: 0x000C586A
		// (set) Token: 0x06003457 RID: 13399 RVA: 0x000C7672 File Offset: 0x000C5872
		protected EventLevel Level
		{
			get
			{
				return (EventLevel)this.m_level;
			}
			set
			{
				this.m_level = (byte)value;
			}
		}

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x06003458 RID: 13400 RVA: 0x000C767C File Offset: 0x000C587C
		// (set) Token: 0x06003459 RID: 13401 RVA: 0x000C7684 File Offset: 0x000C5884
		protected EventKeywords MatchAnyKeyword
		{
			get
			{
				return (EventKeywords)this.m_anyKeywordMask;
			}
			set
			{
				this.m_anyKeywordMask = (long)value;
			}
		}

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x0600345A RID: 13402 RVA: 0x000C768D File Offset: 0x000C588D
		// (set) Token: 0x0600345B RID: 13403 RVA: 0x000C7695 File Offset: 0x000C5895
		protected EventKeywords MatchAllKeyword
		{
			get
			{
				return (EventKeywords)this.m_allKeywordMask;
			}
			set
			{
				this.m_allKeywordMask = (long)value;
			}
		}

		// Token: 0x0600345C RID: 13404 RVA: 0x000C769E File Offset: 0x000C589E
		private static int FindNull(byte[] buffer, int idx)
		{
			while (idx < buffer.Length && buffer[idx] != 0)
			{
				idx++;
			}
			return idx;
		}

		// Token: 0x0600345D RID: 13405 RVA: 0x000C76B4 File Offset: 0x000C58B4
		[SecuritySafeCritical]
		private List<Tuple<EventProvider.SessionInfo, bool>> GetSessions()
		{
			List<EventProvider.SessionInfo> liveSessionList = null;
			this.GetSessionInfo(delegate(int etwSessionId, long matchAllKeywords)
			{
				EventProvider.GetSessionInfoCallback(etwSessionId, matchAllKeywords, ref liveSessionList);
			});
			List<Tuple<EventProvider.SessionInfo, bool>> list = new List<Tuple<EventProvider.SessionInfo, bool>>();
			if (this.m_liveSessions != null)
			{
				foreach (EventProvider.SessionInfo sessionInfo in this.m_liveSessions)
				{
					int index;
					if ((index = EventProvider.IndexOfSessionInList(liveSessionList, sessionInfo.etwSessionId)) < 0 || liveSessionList[index].sessionIdBit != sessionInfo.sessionIdBit)
					{
						list.Add(Tuple.Create<EventProvider.SessionInfo, bool>(sessionInfo, false));
					}
				}
			}
			if (liveSessionList != null)
			{
				foreach (EventProvider.SessionInfo sessionInfo2 in liveSessionList)
				{
					int index2;
					if ((index2 = EventProvider.IndexOfSessionInList(this.m_liveSessions, sessionInfo2.etwSessionId)) < 0 || this.m_liveSessions[index2].sessionIdBit != sessionInfo2.sessionIdBit)
					{
						list.Add(Tuple.Create<EventProvider.SessionInfo, bool>(sessionInfo2, true));
					}
				}
			}
			this.m_liveSessions = liveSessionList;
			return list;
		}

		// Token: 0x0600345E RID: 13406 RVA: 0x000C7800 File Offset: 0x000C5A00
		private static void GetSessionInfoCallback(int etwSessionId, long matchAllKeywords, ref List<EventProvider.SessionInfo> sessionList)
		{
			uint n = (uint)SessionMask.FromEventKeywords((ulong)matchAllKeywords);
			if (EventProvider.bitcount(n) > 1)
			{
				return;
			}
			if (sessionList == null)
			{
				sessionList = new List<EventProvider.SessionInfo>(8);
			}
			if (EventProvider.bitcount(n) == 1)
			{
				sessionList.Add(new EventProvider.SessionInfo(EventProvider.bitindex(n) + 1, etwSessionId));
				return;
			}
			sessionList.Add(new EventProvider.SessionInfo(EventProvider.bitcount((uint)SessionMask.All) + 1, etwSessionId));
		}

		// Token: 0x0600345F RID: 13407 RVA: 0x000C786C File Offset: 0x000C5A6C
		[SecurityCritical]
		private unsafe void GetSessionInfo(Action<int, long> action)
		{
			int num = 256;
			byte* ptr2;
			int num2;
			do
			{
				byte* ptr = stackalloc byte[(UIntPtr)num];
				ptr2 = ptr;
				fixed (Guid* ptr3 = &this.m_providerId)
				{
					Guid* inBuffer = ptr3;
					num2 = UnsafeNativeMethods.ManifestEtw.EnumerateTraceGuidsEx(UnsafeNativeMethods.ManifestEtw.TRACE_QUERY_INFO_CLASS.TraceGuidQueryInfo, (void*)inBuffer, sizeof(Guid), (void*)ptr2, num, ref num);
				}
				if (num2 == 0)
				{
					goto IL_42;
				}
			}
			while (num2 == 122);
			return;
			IL_42:
			UnsafeNativeMethods.ManifestEtw.TRACE_GUID_INFO* ptr4 = (UnsafeNativeMethods.ManifestEtw.TRACE_GUID_INFO*)ptr2;
			UnsafeNativeMethods.ManifestEtw.TRACE_PROVIDER_INSTANCE_INFO* ptr5 = (UnsafeNativeMethods.ManifestEtw.TRACE_PROVIDER_INSTANCE_INFO*)(ptr4 + 1);
			int currentProcessId = (int)Win32Native.GetCurrentProcessId();
			for (int i = 0; i < ptr4->InstanceCount; i++)
			{
				if (ptr5->Pid == currentProcessId)
				{
					UnsafeNativeMethods.ManifestEtw.TRACE_ENABLE_INFO* ptr6 = (UnsafeNativeMethods.ManifestEtw.TRACE_ENABLE_INFO*)(ptr5 + 1);
					for (int j = 0; j < ptr5->EnableCount; j++)
					{
						action((int)ptr6[j].LoggerId, ptr6[j].MatchAllKeyword);
					}
				}
				if (ptr5->NextOffset == 0)
				{
					break;
				}
				byte* ptr7 = (byte*)ptr5;
				ptr5 = (UnsafeNativeMethods.ManifestEtw.TRACE_PROVIDER_INSTANCE_INFO*)(ptr7 + ptr5->NextOffset);
			}
		}

		// Token: 0x06003460 RID: 13408 RVA: 0x000C7950 File Offset: 0x000C5B50
		private static int IndexOfSessionInList(List<EventProvider.SessionInfo> sessions, int etwSessionId)
		{
			if (sessions == null)
			{
				return -1;
			}
			for (int i = 0; i < sessions.Count; i++)
			{
				if (sessions[i].etwSessionId == etwSessionId)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003461 RID: 13409 RVA: 0x000C7988 File Offset: 0x000C5B88
		[SecurityCritical]
		private unsafe bool GetDataFromController(int etwSessionId, UnsafeNativeMethods.ManifestEtw.EVENT_FILTER_DESCRIPTOR* filterData, out ControllerCommand command, out byte[] data, out int dataStart)
		{
			data = null;
			dataStart = 0;
			if (filterData != null)
			{
				if (filterData->Ptr != 0L && 0 < filterData->Size && filterData->Size <= 1024)
				{
					data = new byte[filterData->Size];
					Marshal.Copy((IntPtr)filterData->Ptr, data, 0, data.Length);
				}
				command = (ControllerCommand)filterData->Type;
				return true;
			}
			string str = "\\Microsoft\\Windows\\CurrentVersion\\Winevt\\Publishers\\{";
			Guid providerId = this.m_providerId;
			string text = str + providerId.ToString() + "}";
			if (Marshal.SizeOf(typeof(IntPtr)) == 8)
			{
				text = "HKEY_LOCAL_MACHINE\\Software\\Wow6432Node" + text;
			}
			else
			{
				text = "HKEY_LOCAL_MACHINE\\Software" + text;
			}
			string valueName = "ControllerData_Session_" + etwSessionId.ToString(CultureInfo.InvariantCulture);
			new RegistryPermission(RegistryPermissionAccess.Read, text).Assert();
			data = (Registry.GetValue(text, valueName, null) as byte[]);
			if (data != null)
			{
				command = ControllerCommand.Update;
				return true;
			}
			command = ControllerCommand.Update;
			return false;
		}

		// Token: 0x06003462 RID: 13410 RVA: 0x000C7A85 File Offset: 0x000C5C85
		public bool IsEnabled()
		{
			return this.m_enabled;
		}

		// Token: 0x06003463 RID: 13411 RVA: 0x000C7A8D File Offset: 0x000C5C8D
		public bool IsEnabled(byte level, long keywords)
		{
			return this.m_enabled && ((level <= this.m_level || this.m_level == 0) && (keywords == 0L || ((keywords & this.m_anyKeywordMask) != 0L && (keywords & this.m_allKeywordMask) == this.m_allKeywordMask)));
		}

		// Token: 0x06003464 RID: 13412 RVA: 0x000C7ACA File Offset: 0x000C5CCA
		internal bool IsValid()
		{
			return this.m_regHandle != 0L;
		}

		// Token: 0x06003465 RID: 13413 RVA: 0x000C7AD6 File Offset: 0x000C5CD6
		public static EventProvider.WriteEventErrorCode GetLastWriteEventError()
		{
			return EventProvider.s_returnCode;
		}

		// Token: 0x06003466 RID: 13414 RVA: 0x000C7ADD File Offset: 0x000C5CDD
		private static void SetLastError(int error)
		{
			if (error != 8)
			{
				if (error == 234 || error == 534)
				{
					EventProvider.s_returnCode = EventProvider.WriteEventErrorCode.EventTooBig;
					return;
				}
			}
			else
			{
				EventProvider.s_returnCode = EventProvider.WriteEventErrorCode.NoFreeBuffers;
			}
		}

		// Token: 0x06003467 RID: 13415 RVA: 0x000C7B00 File Offset: 0x000C5D00
		[SecurityCritical]
		private unsafe static object EncodeObject(ref object data, ref EventProvider.EventData* dataDescriptor, ref byte* dataBuffer, ref uint totalEventSize)
		{
			string text;
			byte[] array;
			for (;;)
			{
				dataDescriptor.Reserved = 0U;
				text = (data as string);
				array = null;
				if (text != null)
				{
					break;
				}
				if ((array = (data as byte[])) != null)
				{
					goto Block_1;
				}
				if (data is IntPtr)
				{
					goto Block_2;
				}
				if (data is int)
				{
					goto Block_3;
				}
				if (data is long)
				{
					goto Block_4;
				}
				if (data is uint)
				{
					goto Block_5;
				}
				if (data is ulong)
				{
					goto Block_6;
				}
				if (data is char)
				{
					goto Block_7;
				}
				if (data is byte)
				{
					goto Block_8;
				}
				if (data is short)
				{
					goto Block_9;
				}
				if (data is sbyte)
				{
					goto Block_10;
				}
				if (data is ushort)
				{
					goto Block_11;
				}
				if (data is float)
				{
					goto Block_12;
				}
				if (data is double)
				{
					goto Block_13;
				}
				if (data is bool)
				{
					goto Block_14;
				}
				if (data is Guid)
				{
					goto Block_16;
				}
				if (data is decimal)
				{
					goto Block_17;
				}
				if (data is DateTime)
				{
					goto Block_18;
				}
				if (!(data is Enum))
				{
					goto IL_40C;
				}
				Type underlyingType = Enum.GetUnderlyingType(data.GetType());
				if (underlyingType == typeof(int))
				{
					data = ((IConvertible)data).ToInt32(null);
				}
				else
				{
					if (!(underlyingType == typeof(long)))
					{
						goto IL_40C;
					}
					data = ((IConvertible)data).ToInt64(null);
				}
			}
			dataDescriptor.Size = (uint)((text.Length + 1) * 2);
			goto IL_431;
			Block_1:
			*dataBuffer = array.Length;
			dataDescriptor.Ptr = (ulong)dataBuffer;
			dataDescriptor.Size = 4U;
			totalEventSize += dataDescriptor.Size;
			dataDescriptor += (IntPtr)sizeof(EventProvider.EventData);
			dataBuffer += 16;
			dataDescriptor.Size = (uint)array.Length;
			goto IL_431;
			Block_2:
			dataDescriptor.Size = (uint)sizeof(IntPtr);
			IntPtr* ptr = dataBuffer;
			*ptr = (IntPtr)data;
			dataDescriptor.Ptr = ptr;
			goto IL_431;
			Block_3:
			dataDescriptor.Size = 4U;
			int* ptr2 = dataBuffer;
			*ptr2 = (int)data;
			dataDescriptor.Ptr = ptr2;
			goto IL_431;
			Block_4:
			dataDescriptor.Size = 8U;
			long* ptr3 = dataBuffer;
			*ptr3 = (long)data;
			dataDescriptor.Ptr = ptr3;
			goto IL_431;
			Block_5:
			dataDescriptor.Size = 4U;
			uint* ptr4 = dataBuffer;
			*ptr4 = (uint)data;
			dataDescriptor.Ptr = ptr4;
			goto IL_431;
			Block_6:
			dataDescriptor.Size = 8U;
			ulong* ptr5 = dataBuffer;
			*ptr5 = (ulong)data;
			dataDescriptor.Ptr = ptr5;
			goto IL_431;
			Block_7:
			dataDescriptor.Size = 2U;
			char* ptr6 = dataBuffer;
			*ptr6 = (char)data;
			dataDescriptor.Ptr = ptr6;
			goto IL_431;
			Block_8:
			dataDescriptor.Size = 1U;
			byte* ptr7 = dataBuffer;
			*ptr7 = (byte)data;
			dataDescriptor.Ptr = ptr7;
			goto IL_431;
			Block_9:
			dataDescriptor.Size = 2U;
			short* ptr8 = dataBuffer;
			*ptr8 = (short)data;
			dataDescriptor.Ptr = ptr8;
			goto IL_431;
			Block_10:
			dataDescriptor.Size = 1U;
			sbyte* ptr9 = dataBuffer;
			*ptr9 = (sbyte)data;
			dataDescriptor.Ptr = ptr9;
			goto IL_431;
			Block_11:
			dataDescriptor.Size = 2U;
			ushort* ptr10 = dataBuffer;
			*ptr10 = (ushort)data;
			dataDescriptor.Ptr = ptr10;
			goto IL_431;
			Block_12:
			dataDescriptor.Size = 4U;
			float* ptr11 = dataBuffer;
			*ptr11 = (float)data;
			dataDescriptor.Ptr = ptr11;
			goto IL_431;
			Block_13:
			dataDescriptor.Size = 8U;
			double* ptr12 = dataBuffer;
			*ptr12 = (double)data;
			dataDescriptor.Ptr = ptr12;
			goto IL_431;
			Block_14:
			dataDescriptor.Size = 4U;
			int* ptr13 = dataBuffer;
			if ((bool)data)
			{
				*ptr13 = 1;
			}
			else
			{
				*ptr13 = 0;
			}
			dataDescriptor.Ptr = ptr13;
			goto IL_431;
			Block_16:
			dataDescriptor.Size = (uint)sizeof(Guid);
			Guid* ptr14 = dataBuffer;
			*ptr14 = (Guid)data;
			dataDescriptor.Ptr = ptr14;
			goto IL_431;
			Block_17:
			dataDescriptor.Size = 16U;
			decimal* ptr15 = dataBuffer;
			*ptr15 = (decimal)data;
			dataDescriptor.Ptr = ptr15;
			goto IL_431;
			Block_18:
			long num = 0L;
			if (((DateTime)data).Ticks > 504911232000000000L)
			{
				num = ((DateTime)data).ToFileTimeUtc();
			}
			dataDescriptor.Size = 8U;
			long* ptr16 = dataBuffer;
			*ptr16 = num;
			dataDescriptor.Ptr = ptr16;
			goto IL_431;
			IL_40C:
			if (data == null)
			{
				text = "";
			}
			else
			{
				text = data.ToString();
			}
			dataDescriptor.Size = (uint)((text.Length + 1) * 2);
			IL_431:
			totalEventSize += dataDescriptor.Size;
			dataDescriptor += (IntPtr)sizeof(EventProvider.EventData);
			dataBuffer += 16;
			return text ?? array;
		}

		// Token: 0x06003468 RID: 13416 RVA: 0x000C7F64 File Offset: 0x000C6164
		[SecurityCritical]
		internal unsafe bool WriteEvent(ref EventDescriptor eventDescriptor, Guid* activityID, Guid* childActivityID, params object[] eventPayload)
		{
			int num = 0;
			if (this.IsEnabled(eventDescriptor.Level, eventDescriptor.Keywords))
			{
				int num2 = eventPayload.Length;
				if (num2 > 128)
				{
					EventProvider.s_returnCode = EventProvider.WriteEventErrorCode.TooManyArgs;
					return false;
				}
				uint num3 = 0U;
				int i = 0;
				List<int> list = new List<int>(8);
				List<object> list2 = new List<object>(8);
				EventProvider.EventData* ptr = stackalloc EventProvider.EventData[checked(unchecked((UIntPtr)(2 * num2)) * (UIntPtr)sizeof(EventProvider.EventData))];
				EventProvider.EventData* ptr2 = ptr;
				byte* ptr3 = stackalloc byte[(UIntPtr)(32 * num2)];
				byte* ptr4 = ptr3;
				bool flag = false;
				for (int j = 0; j < eventPayload.Length; j++)
				{
					if (eventPayload[j] == null)
					{
						EventProvider.s_returnCode = EventProvider.WriteEventErrorCode.NullInput;
						return false;
					}
					object obj = EventProvider.EncodeObject(ref eventPayload[j], ref ptr2, ref ptr4, ref num3);
					if (obj != null)
					{
						int num4 = (int)((long)(ptr2 - ptr) - 1L);
						if (!(obj is string))
						{
							if (eventPayload.Length + num4 + 1 - j > 128)
							{
								EventProvider.s_returnCode = EventProvider.WriteEventErrorCode.TooManyArgs;
								return false;
							}
							flag = true;
						}
						list2.Add(obj);
						list.Add(num4);
						i++;
					}
				}
				num2 = (int)((long)(ptr2 - ptr));
				if (num3 > 65482U)
				{
					EventProvider.s_returnCode = EventProvider.WriteEventErrorCode.EventTooBig;
					return false;
				}
				if (!flag && i < 8)
				{
					while (i < 8)
					{
						list2.Add(null);
						i++;
					}
					fixed (string text = (string)list2[0])
					{
						char* ptr5 = text;
						if (ptr5 != null)
						{
							ptr5 += RuntimeHelpers.OffsetToStringData / 2;
						}
						fixed (string text2 = (string)list2[1])
						{
							char* ptr6 = text2;
							if (ptr6 != null)
							{
								ptr6 += RuntimeHelpers.OffsetToStringData / 2;
							}
							fixed (string text3 = (string)list2[2])
							{
								char* ptr7 = text3;
								if (ptr7 != null)
								{
									ptr7 += RuntimeHelpers.OffsetToStringData / 2;
								}
								fixed (string text4 = (string)list2[3])
								{
									char* ptr8 = text4;
									if (ptr8 != null)
									{
										ptr8 += RuntimeHelpers.OffsetToStringData / 2;
									}
									fixed (string text5 = (string)list2[4])
									{
										char* ptr9 = text5;
										if (ptr9 != null)
										{
											ptr9 += RuntimeHelpers.OffsetToStringData / 2;
										}
										fixed (string text6 = (string)list2[5])
										{
											char* ptr10 = text6;
											if (ptr10 != null)
											{
												ptr10 += RuntimeHelpers.OffsetToStringData / 2;
											}
											fixed (string text7 = (string)list2[6])
											{
												char* ptr11 = text7;
												if (ptr11 != null)
												{
													ptr11 += RuntimeHelpers.OffsetToStringData / 2;
												}
												fixed (string text8 = (string)list2[7])
												{
													char* ptr12 = text8;
													if (ptr12 != null)
													{
														ptr12 += RuntimeHelpers.OffsetToStringData / 2;
													}
													ptr2 = ptr;
													if (list2[0] != null)
													{
														ptr2[list[0]].Ptr = ptr5;
													}
													if (list2[1] != null)
													{
														ptr2[list[1]].Ptr = ptr6;
													}
													if (list2[2] != null)
													{
														ptr2[list[2]].Ptr = ptr7;
													}
													if (list2[3] != null)
													{
														ptr2[list[3]].Ptr = ptr8;
													}
													if (list2[4] != null)
													{
														ptr2[list[4]].Ptr = ptr9;
													}
													if (list2[5] != null)
													{
														ptr2[list[5]].Ptr = ptr10;
													}
													if (list2[6] != null)
													{
														ptr2[list[6]].Ptr = ptr11;
													}
													if (list2[7] != null)
													{
														ptr2[list[7]].Ptr = ptr12;
													}
													num = UnsafeNativeMethods.ManifestEtw.EventWriteTransferWrapper(this.m_regHandle, ref eventDescriptor, activityID, childActivityID, num2, ptr);
													text = null;
													text2 = null;
													text3 = null;
													text4 = null;
													text5 = null;
													text6 = null;
													text7 = null;
												}
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					ptr2 = ptr;
					GCHandle[] array = new GCHandle[i];
					for (int k = 0; k < i; k++)
					{
						array[k] = GCHandle.Alloc(list2[k], GCHandleType.Pinned);
						if (list2[k] is string)
						{
							fixed (string text9 = (string)list2[k])
							{
								char* ptr13 = text9;
								if (ptr13 != null)
								{
									ptr13 += RuntimeHelpers.OffsetToStringData / 2;
								}
								ptr2[list[k]].Ptr = ptr13;
							}
						}
						else
						{
							byte[] array2;
							byte* ptr14;
							if ((array2 = (byte[])list2[k]) == null || array2.Length == 0)
							{
								ptr14 = null;
							}
							else
							{
								ptr14 = &array2[0];
							}
							ptr2[list[k]].Ptr = ptr14;
							array2 = null;
						}
					}
					num = UnsafeNativeMethods.ManifestEtw.EventWriteTransferWrapper(this.m_regHandle, ref eventDescriptor, activityID, childActivityID, num2, ptr);
					for (int l = 0; l < i; l++)
					{
						array[l].Free();
					}
				}
			}
			if (num != 0)
			{
				EventProvider.SetLastError(num);
				return false;
			}
			return true;
		}

		// Token: 0x06003469 RID: 13417 RVA: 0x000C842C File Offset: 0x000C662C
		[SecurityCritical]
		protected internal unsafe bool WriteEvent(ref EventDescriptor eventDescriptor, Guid* activityID, Guid* childActivityID, int dataCount, IntPtr data)
		{
			UIntPtr uintPtr = (UIntPtr)0;
			int num = UnsafeNativeMethods.ManifestEtw.EventWriteTransferWrapper(this.m_regHandle, ref eventDescriptor, activityID, childActivityID, dataCount, (EventProvider.EventData*)((void*)data));
			if (num != 0)
			{
				EventProvider.SetLastError(num);
				return false;
			}
			return true;
		}

		// Token: 0x0600346A RID: 13418 RVA: 0x000C8464 File Offset: 0x000C6664
		[SecurityCritical]
		internal unsafe bool WriteEventRaw(ref EventDescriptor eventDescriptor, Guid* activityID, Guid* relatedActivityID, int dataCount, IntPtr data)
		{
			int num = UnsafeNativeMethods.ManifestEtw.EventWriteTransferWrapper(this.m_regHandle, ref eventDescriptor, activityID, relatedActivityID, dataCount, (EventProvider.EventData*)((void*)data));
			if (num != 0)
			{
				EventProvider.SetLastError(num);
				return false;
			}
			return true;
		}

		// Token: 0x0600346B RID: 13419 RVA: 0x000C8495 File Offset: 0x000C6695
		[SecurityCritical]
		private uint EventRegister(ref Guid providerId, UnsafeNativeMethods.ManifestEtw.EtwEnableCallback enableCallback)
		{
			this.m_providerId = providerId;
			this.m_etwCallback = enableCallback;
			return UnsafeNativeMethods.ManifestEtw.EventRegister(ref providerId, enableCallback, null, ref this.m_regHandle);
		}

		// Token: 0x0600346C RID: 13420 RVA: 0x000C84B9 File Offset: 0x000C66B9
		[SecurityCritical]
		private uint EventUnregister(long registrationHandle)
		{
			return UnsafeNativeMethods.ManifestEtw.EventUnregister(registrationHandle);
		}

		// Token: 0x0600346D RID: 13421 RVA: 0x000C84C4 File Offset: 0x000C66C4
		private static int bitcount(uint n)
		{
			int num = 0;
			while (n != 0U)
			{
				num += EventProvider.nibblebits[(int)(n & 15U)];
				n >>= 4;
			}
			return num;
		}

		// Token: 0x0600346E RID: 13422 RVA: 0x000C84EC File Offset: 0x000C66EC
		private static int bitindex(uint n)
		{
			int num = 0;
			while (((ulong)n & (ulong)(1L << (num & 31))) == 0UL)
			{
				num++;
			}
			return num;
		}

		// Token: 0x04001737 RID: 5943
		private static bool m_setInformationMissing;

		// Token: 0x04001738 RID: 5944
		[SecurityCritical]
		private UnsafeNativeMethods.ManifestEtw.EtwEnableCallback m_etwCallback;

		// Token: 0x04001739 RID: 5945
		private long m_regHandle;

		// Token: 0x0400173A RID: 5946
		private byte m_level;

		// Token: 0x0400173B RID: 5947
		private long m_anyKeywordMask;

		// Token: 0x0400173C RID: 5948
		private long m_allKeywordMask;

		// Token: 0x0400173D RID: 5949
		private List<EventProvider.SessionInfo> m_liveSessions;

		// Token: 0x0400173E RID: 5950
		private bool m_enabled;

		// Token: 0x0400173F RID: 5951
		private Guid m_providerId;

		// Token: 0x04001740 RID: 5952
		internal bool m_disposed;

		// Token: 0x04001741 RID: 5953
		[ThreadStatic]
		private static EventProvider.WriteEventErrorCode s_returnCode;

		// Token: 0x04001742 RID: 5954
		private const int s_basicTypeAllocationBufferSize = 16;

		// Token: 0x04001743 RID: 5955
		private const int s_etwMaxNumberArguments = 128;

		// Token: 0x04001744 RID: 5956
		private const int s_etwAPIMaxRefObjCount = 8;

		// Token: 0x04001745 RID: 5957
		private const int s_maxEventDataDescriptors = 128;

		// Token: 0x04001746 RID: 5958
		private const int s_traceEventMaximumSize = 65482;

		// Token: 0x04001747 RID: 5959
		private const int s_traceEventMaximumStringSize = 32724;

		// Token: 0x04001748 RID: 5960
		private static int[] nibblebits = new int[]
		{
			0,
			1,
			1,
			2,
			1,
			2,
			2,
			3,
			1,
			2,
			2,
			3,
			2,
			3,
			3,
			4
		};

		// Token: 0x02000B84 RID: 2948
		public struct EventData
		{
			// Token: 0x040034E6 RID: 13542
			internal ulong Ptr;

			// Token: 0x040034E7 RID: 13543
			internal uint Size;

			// Token: 0x040034E8 RID: 13544
			internal uint Reserved;
		}

		// Token: 0x02000B85 RID: 2949
		public struct SessionInfo
		{
			// Token: 0x06006C65 RID: 27749 RVA: 0x001776BA File Offset: 0x001758BA
			internal SessionInfo(int sessionIdBit_, int etwSessionId_)
			{
				this.sessionIdBit = sessionIdBit_;
				this.etwSessionId = etwSessionId_;
			}

			// Token: 0x040034E9 RID: 13545
			internal int sessionIdBit;

			// Token: 0x040034EA RID: 13546
			internal int etwSessionId;
		}

		// Token: 0x02000B86 RID: 2950
		public enum WriteEventErrorCode
		{
			// Token: 0x040034EC RID: 13548
			NoError,
			// Token: 0x040034ED RID: 13549
			NoFreeBuffers,
			// Token: 0x040034EE RID: 13550
			EventTooBig,
			// Token: 0x040034EF RID: 13551
			NullInput,
			// Token: 0x040034F0 RID: 13552
			TooManyArgs,
			// Token: 0x040034F1 RID: 13553
			Other
		}
	}
}
