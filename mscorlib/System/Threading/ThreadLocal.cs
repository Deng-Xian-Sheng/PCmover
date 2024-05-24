using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;

namespace System.Threading
{
	// Token: 0x0200053F RID: 1343
	[DebuggerTypeProxy(typeof(SystemThreading_ThreadLocalDebugView<>))]
	[DebuggerDisplay("IsValueCreated={IsValueCreated}, Value={ValueForDebugDisplay}, Count={ValuesCountForDebugDisplay}")]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class ThreadLocal<T> : IDisposable
	{
		// Token: 0x06003EE3 RID: 16099 RVA: 0x000E9F7F File Offset: 0x000E817F
		[__DynamicallyInvokable]
		public ThreadLocal()
		{
			this.Initialize(null, false);
		}

		// Token: 0x06003EE4 RID: 16100 RVA: 0x000E9F9B File Offset: 0x000E819B
		[__DynamicallyInvokable]
		public ThreadLocal(bool trackAllValues)
		{
			this.Initialize(null, trackAllValues);
		}

		// Token: 0x06003EE5 RID: 16101 RVA: 0x000E9FB7 File Offset: 0x000E81B7
		[__DynamicallyInvokable]
		public ThreadLocal(Func<T> valueFactory)
		{
			if (valueFactory == null)
			{
				throw new ArgumentNullException("valueFactory");
			}
			this.Initialize(valueFactory, false);
		}

		// Token: 0x06003EE6 RID: 16102 RVA: 0x000E9FE1 File Offset: 0x000E81E1
		[__DynamicallyInvokable]
		public ThreadLocal(Func<T> valueFactory, bool trackAllValues)
		{
			if (valueFactory == null)
			{
				throw new ArgumentNullException("valueFactory");
			}
			this.Initialize(valueFactory, trackAllValues);
		}

		// Token: 0x06003EE7 RID: 16103 RVA: 0x000EA00C File Offset: 0x000E820C
		private void Initialize(Func<T> valueFactory, bool trackAllValues)
		{
			this.m_valueFactory = valueFactory;
			this.m_trackAllValues = trackAllValues;
			try
			{
			}
			finally
			{
				this.m_idComplement = ~ThreadLocal<T>.s_idManager.GetId();
				this.m_initialized = true;
			}
		}

		// Token: 0x06003EE8 RID: 16104 RVA: 0x000EA054 File Offset: 0x000E8254
		[__DynamicallyInvokable]
		~ThreadLocal()
		{
			this.Dispose(false);
		}

		// Token: 0x06003EE9 RID: 16105 RVA: 0x000EA084 File Offset: 0x000E8284
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06003EEA RID: 16106 RVA: 0x000EA094 File Offset: 0x000E8294
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
			ThreadLocal<T>.IdManager obj = ThreadLocal<T>.s_idManager;
			int num;
			lock (obj)
			{
				num = ~this.m_idComplement;
				this.m_idComplement = 0;
				if (num < 0 || !this.m_initialized)
				{
					return;
				}
				this.m_initialized = false;
				for (ThreadLocal<T>.LinkedSlot next = this.m_linkedSlot.Next; next != null; next = next.Next)
				{
					ThreadLocal<T>.LinkedSlotVolatile[] slotArray = next.SlotArray;
					if (slotArray != null)
					{
						next.SlotArray = null;
						slotArray[num].Value.Value = default(T);
						slotArray[num].Value = null;
					}
				}
			}
			this.m_linkedSlot = null;
			ThreadLocal<T>.s_idManager.ReturnId(num);
		}

		// Token: 0x06003EEB RID: 16107 RVA: 0x000EA168 File Offset: 0x000E8368
		[__DynamicallyInvokable]
		public override string ToString()
		{
			T value = this.Value;
			return value.ToString();
		}

		// Token: 0x1700094A RID: 2378
		// (get) Token: 0x06003EEC RID: 16108 RVA: 0x000EA18C File Offset: 0x000E838C
		// (set) Token: 0x06003EED RID: 16109 RVA: 0x000EA1E0 File Offset: 0x000E83E0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[__DynamicallyInvokable]
		public T Value
		{
			[__DynamicallyInvokable]
			get
			{
				ThreadLocal<T>.LinkedSlotVolatile[] array = ThreadLocal<T>.ts_slotArray;
				int num = ~this.m_idComplement;
				ThreadLocal<T>.LinkedSlot value;
				if (array != null && num >= 0 && num < array.Length && (value = array[num].Value) != null && this.m_initialized)
				{
					return value.Value;
				}
				return this.GetValueSlow();
			}
			[__DynamicallyInvokable]
			set
			{
				ThreadLocal<T>.LinkedSlotVolatile[] array = ThreadLocal<T>.ts_slotArray;
				int num = ~this.m_idComplement;
				ThreadLocal<T>.LinkedSlot value2;
				if (array != null && num >= 0 && num < array.Length && (value2 = array[num].Value) != null && this.m_initialized)
				{
					value2.Value = value;
					return;
				}
				this.SetValueSlow(value, array);
			}
		}

		// Token: 0x06003EEE RID: 16110 RVA: 0x000EA234 File Offset: 0x000E8434
		private T GetValueSlow()
		{
			int num = ~this.m_idComplement;
			if (num < 0)
			{
				throw new ObjectDisposedException(Environment.GetResourceString("ThreadLocal_Disposed"));
			}
			Debugger.NotifyOfCrossThreadDependency();
			T t;
			if (this.m_valueFactory == null)
			{
				t = default(T);
			}
			else
			{
				t = this.m_valueFactory();
				if (this.IsValueCreated)
				{
					throw new InvalidOperationException(Environment.GetResourceString("ThreadLocal_Value_RecursiveCallsToValue"));
				}
			}
			this.Value = t;
			return t;
		}

		// Token: 0x06003EEF RID: 16111 RVA: 0x000EA2A0 File Offset: 0x000E84A0
		private void SetValueSlow(T value, ThreadLocal<T>.LinkedSlotVolatile[] slotArray)
		{
			int num = ~this.m_idComplement;
			if (num < 0)
			{
				throw new ObjectDisposedException(Environment.GetResourceString("ThreadLocal_Disposed"));
			}
			if (slotArray == null)
			{
				slotArray = new ThreadLocal<T>.LinkedSlotVolatile[ThreadLocal<T>.GetNewTableSize(num + 1)];
				ThreadLocal<T>.ts_finalizationHelper = new ThreadLocal<T>.FinalizationHelper(slotArray, this.m_trackAllValues);
				ThreadLocal<T>.ts_slotArray = slotArray;
			}
			if (num >= slotArray.Length)
			{
				this.GrowTable(ref slotArray, num + 1);
				ThreadLocal<T>.ts_finalizationHelper.SlotArray = slotArray;
				ThreadLocal<T>.ts_slotArray = slotArray;
			}
			if (slotArray[num].Value == null)
			{
				this.CreateLinkedSlot(slotArray, num, value);
				return;
			}
			ThreadLocal<T>.LinkedSlot value2 = slotArray[num].Value;
			if (!this.m_initialized)
			{
				throw new ObjectDisposedException(Environment.GetResourceString("ThreadLocal_Disposed"));
			}
			value2.Value = value;
		}

		// Token: 0x06003EF0 RID: 16112 RVA: 0x000EA360 File Offset: 0x000E8560
		private void CreateLinkedSlot(ThreadLocal<T>.LinkedSlotVolatile[] slotArray, int id, T value)
		{
			ThreadLocal<T>.LinkedSlot linkedSlot = new ThreadLocal<T>.LinkedSlot(slotArray);
			ThreadLocal<T>.IdManager obj = ThreadLocal<T>.s_idManager;
			lock (obj)
			{
				if (!this.m_initialized)
				{
					throw new ObjectDisposedException(Environment.GetResourceString("ThreadLocal_Disposed"));
				}
				ThreadLocal<T>.LinkedSlot next = this.m_linkedSlot.Next;
				linkedSlot.Next = next;
				linkedSlot.Previous = this.m_linkedSlot;
				linkedSlot.Value = value;
				if (next != null)
				{
					next.Previous = linkedSlot;
				}
				this.m_linkedSlot.Next = linkedSlot;
				slotArray[id].Value = linkedSlot;
			}
		}

		// Token: 0x1700094B RID: 2379
		// (get) Token: 0x06003EF1 RID: 16113 RVA: 0x000EA410 File Offset: 0x000E8610
		[__DynamicallyInvokable]
		public IList<T> Values
		{
			[__DynamicallyInvokable]
			get
			{
				if (!this.m_trackAllValues)
				{
					throw new InvalidOperationException(Environment.GetResourceString("ThreadLocal_ValuesNotAvailable"));
				}
				List<T> valuesAsList = this.GetValuesAsList();
				if (valuesAsList == null)
				{
					throw new ObjectDisposedException(Environment.GetResourceString("ThreadLocal_Disposed"));
				}
				return valuesAsList;
			}
		}

		// Token: 0x06003EF2 RID: 16114 RVA: 0x000EA450 File Offset: 0x000E8650
		private List<T> GetValuesAsList()
		{
			List<T> list = new List<T>();
			int num = ~this.m_idComplement;
			if (num == -1)
			{
				return null;
			}
			for (ThreadLocal<T>.LinkedSlot next = this.m_linkedSlot.Next; next != null; next = next.Next)
			{
				list.Add(next.Value);
			}
			return list;
		}

		// Token: 0x1700094C RID: 2380
		// (get) Token: 0x06003EF3 RID: 16115 RVA: 0x000EA49C File Offset: 0x000E869C
		private int ValuesCountForDebugDisplay
		{
			get
			{
				int num = 0;
				for (ThreadLocal<T>.LinkedSlot next = this.m_linkedSlot.Next; next != null; next = next.Next)
				{
					num++;
				}
				return num;
			}
		}

		// Token: 0x1700094D RID: 2381
		// (get) Token: 0x06003EF4 RID: 16116 RVA: 0x000EA4CC File Offset: 0x000E86CC
		[__DynamicallyInvokable]
		public bool IsValueCreated
		{
			[__DynamicallyInvokable]
			get
			{
				int num = ~this.m_idComplement;
				if (num < 0)
				{
					throw new ObjectDisposedException(Environment.GetResourceString("ThreadLocal_Disposed"));
				}
				ThreadLocal<T>.LinkedSlotVolatile[] array = ThreadLocal<T>.ts_slotArray;
				return array != null && num < array.Length && array[num].Value != null;
			}
		}

		// Token: 0x1700094E RID: 2382
		// (get) Token: 0x06003EF5 RID: 16117 RVA: 0x000EA518 File Offset: 0x000E8718
		internal T ValueForDebugDisplay
		{
			get
			{
				ThreadLocal<T>.LinkedSlotVolatile[] array = ThreadLocal<T>.ts_slotArray;
				int num = ~this.m_idComplement;
				ThreadLocal<T>.LinkedSlot value;
				if (array == null || num >= array.Length || (value = array[num].Value) == null || !this.m_initialized)
				{
					return default(T);
				}
				return value.Value;
			}
		}

		// Token: 0x1700094F RID: 2383
		// (get) Token: 0x06003EF6 RID: 16118 RVA: 0x000EA568 File Offset: 0x000E8768
		internal List<T> ValuesForDebugDisplay
		{
			get
			{
				return this.GetValuesAsList();
			}
		}

		// Token: 0x06003EF7 RID: 16119 RVA: 0x000EA570 File Offset: 0x000E8770
		private void GrowTable(ref ThreadLocal<T>.LinkedSlotVolatile[] table, int minLength)
		{
			int newTableSize = ThreadLocal<T>.GetNewTableSize(minLength);
			ThreadLocal<T>.LinkedSlotVolatile[] array = new ThreadLocal<T>.LinkedSlotVolatile[newTableSize];
			ThreadLocal<T>.IdManager obj = ThreadLocal<T>.s_idManager;
			lock (obj)
			{
				for (int i = 0; i < table.Length; i++)
				{
					ThreadLocal<T>.LinkedSlot value = table[i].Value;
					if (value != null && value.SlotArray != null)
					{
						value.SlotArray = array;
						array[i] = table[i];
					}
				}
			}
			table = array;
		}

		// Token: 0x06003EF8 RID: 16120 RVA: 0x000EA60C File Offset: 0x000E880C
		private static int GetNewTableSize(int minSize)
		{
			if (minSize > 2146435071)
			{
				return int.MaxValue;
			}
			int num = minSize - 1;
			num |= num >> 1;
			num |= num >> 2;
			num |= num >> 4;
			num |= num >> 8;
			num |= num >> 16;
			num++;
			if (num > 2146435071)
			{
				num = 2146435071;
			}
			return num;
		}

		// Token: 0x04001A70 RID: 6768
		private Func<T> m_valueFactory;

		// Token: 0x04001A71 RID: 6769
		[ThreadStatic]
		private static ThreadLocal<T>.LinkedSlotVolatile[] ts_slotArray;

		// Token: 0x04001A72 RID: 6770
		[ThreadStatic]
		private static ThreadLocal<T>.FinalizationHelper ts_finalizationHelper;

		// Token: 0x04001A73 RID: 6771
		private int m_idComplement;

		// Token: 0x04001A74 RID: 6772
		private volatile bool m_initialized;

		// Token: 0x04001A75 RID: 6773
		private static ThreadLocal<T>.IdManager s_idManager = new ThreadLocal<T>.IdManager();

		// Token: 0x04001A76 RID: 6774
		private ThreadLocal<T>.LinkedSlot m_linkedSlot = new ThreadLocal<T>.LinkedSlot(null);

		// Token: 0x04001A77 RID: 6775
		private bool m_trackAllValues;

		// Token: 0x02000BFA RID: 3066
		private struct LinkedSlotVolatile
		{
			// Token: 0x0400363D RID: 13885
			internal volatile ThreadLocal<T>.LinkedSlot Value;
		}

		// Token: 0x02000BFB RID: 3067
		private sealed class LinkedSlot
		{
			// Token: 0x06006F83 RID: 28547 RVA: 0x001806B7 File Offset: 0x0017E8B7
			internal LinkedSlot(ThreadLocal<T>.LinkedSlotVolatile[] slotArray)
			{
				this.SlotArray = slotArray;
			}

			// Token: 0x0400363E RID: 13886
			internal volatile ThreadLocal<T>.LinkedSlot Next;

			// Token: 0x0400363F RID: 13887
			internal volatile ThreadLocal<T>.LinkedSlot Previous;

			// Token: 0x04003640 RID: 13888
			internal volatile ThreadLocal<T>.LinkedSlotVolatile[] SlotArray;

			// Token: 0x04003641 RID: 13889
			internal T Value;
		}

		// Token: 0x02000BFC RID: 3068
		private class IdManager
		{
			// Token: 0x06006F84 RID: 28548 RVA: 0x001806C8 File Offset: 0x0017E8C8
			internal int GetId()
			{
				List<bool> freeIds = this.m_freeIds;
				int result;
				lock (freeIds)
				{
					int num = this.m_nextIdToTry;
					while (num < this.m_freeIds.Count && !this.m_freeIds[num])
					{
						num++;
					}
					if (num == this.m_freeIds.Count)
					{
						this.m_freeIds.Add(false);
					}
					else
					{
						this.m_freeIds[num] = false;
					}
					this.m_nextIdToTry = num + 1;
					result = num;
				}
				return result;
			}

			// Token: 0x06006F85 RID: 28549 RVA: 0x00180760 File Offset: 0x0017E960
			internal void ReturnId(int id)
			{
				List<bool> freeIds = this.m_freeIds;
				lock (freeIds)
				{
					this.m_freeIds[id] = true;
					if (id < this.m_nextIdToTry)
					{
						this.m_nextIdToTry = id;
					}
				}
			}

			// Token: 0x04003642 RID: 13890
			private int m_nextIdToTry;

			// Token: 0x04003643 RID: 13891
			private List<bool> m_freeIds = new List<bool>();
		}

		// Token: 0x02000BFD RID: 3069
		private class FinalizationHelper
		{
			// Token: 0x06006F87 RID: 28551 RVA: 0x001807CB File Offset: 0x0017E9CB
			internal FinalizationHelper(ThreadLocal<T>.LinkedSlotVolatile[] slotArray, bool trackAllValues)
			{
				this.SlotArray = slotArray;
				this.m_trackAllValues = trackAllValues;
			}

			// Token: 0x06006F88 RID: 28552 RVA: 0x001807E4 File Offset: 0x0017E9E4
			protected override void Finalize()
			{
				try
				{
					ThreadLocal<T>.LinkedSlotVolatile[] slotArray = this.SlotArray;
					for (int i = 0; i < slotArray.Length; i++)
					{
						ThreadLocal<T>.LinkedSlot value = slotArray[i].Value;
						if (value != null)
						{
							if (this.m_trackAllValues)
							{
								value.SlotArray = null;
							}
							else
							{
								ThreadLocal<T>.IdManager s_idManager = ThreadLocal<T>.s_idManager;
								lock (s_idManager)
								{
									if (value.Next != null)
									{
										value.Next.Previous = value.Previous;
									}
									value.Previous.Next = value.Next;
								}
							}
						}
					}
				}
				finally
				{
					base.Finalize();
				}
			}

			// Token: 0x04003644 RID: 13892
			internal ThreadLocal<T>.LinkedSlotVolatile[] SlotArray;

			// Token: 0x04003645 RID: 13893
			private bool m_trackAllValues;
		}
	}
}
