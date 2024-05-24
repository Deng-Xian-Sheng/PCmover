using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Diagnostics
{
	// Token: 0x020003F6 RID: 1014
	[Serializable]
	internal class StackFrameHelper : IDisposable
	{
		// Token: 0x06003357 RID: 13143 RVA: 0x000C5340 File Offset: 0x000C3540
		public StackFrameHelper(Thread target)
		{
			this.targetThread = target;
			this.rgMethodBase = null;
			this.rgMethodHandle = null;
			this.rgiMethodToken = null;
			this.rgiOffset = null;
			this.rgiILOffset = null;
			this.rgAssemblyPath = null;
			this.rgLoadedPeAddress = null;
			this.rgiLoadedPeSize = null;
			this.rgInMemoryPdbAddress = null;
			this.rgiInMemoryPdbSize = null;
			this.dynamicMethods = null;
			this.rgFilename = null;
			this.rgiLineNumber = null;
			this.rgiColumnNumber = null;
			this.rgiLastFrameFromForeignExceptionStackTrace = null;
			this.iFrameCount = 0;
		}

		// Token: 0x06003358 RID: 13144 RVA: 0x000C53CC File Offset: 0x000C35CC
		[SecuritySafeCritical]
		internal void InitializeSourceInfo(int iSkip, bool fNeedFileInfo, Exception exception)
		{
			StackTrace.GetStackFramesInternal(this, iSkip, fNeedFileInfo, exception);
			if (!fNeedFileInfo)
			{
				return;
			}
			if (!RuntimeFeature.IsSupported("PortablePdb"))
			{
				return;
			}
			if (StackFrameHelper.t_reentrancy > 0)
			{
				return;
			}
			StackFrameHelper.t_reentrancy++;
			try
			{
				if (!CodeAccessSecurityEngine.QuickCheckForAllDemands())
				{
					new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Assert();
					new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Assert();
				}
				if (StackFrameHelper.s_getSourceLineInfo == null)
				{
					Type type = Type.GetType("System.Diagnostics.StackTraceSymbols, System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", false);
					if (type == null)
					{
						return;
					}
					MethodInfo method = type.GetMethod("GetSourceLineInfoWithoutCasAssert", new Type[]
					{
						typeof(string),
						typeof(IntPtr),
						typeof(int),
						typeof(IntPtr),
						typeof(int),
						typeof(int),
						typeof(int),
						typeof(string).MakeByRefType(),
						typeof(int).MakeByRefType(),
						typeof(int).MakeByRefType()
					});
					if (method == null)
					{
						method = type.GetMethod("GetSourceLineInfo", new Type[]
						{
							typeof(string),
							typeof(IntPtr),
							typeof(int),
							typeof(IntPtr),
							typeof(int),
							typeof(int),
							typeof(int),
							typeof(string).MakeByRefType(),
							typeof(int).MakeByRefType(),
							typeof(int).MakeByRefType()
						});
					}
					if (method == null)
					{
						return;
					}
					object target = Activator.CreateInstance(type);
					StackFrameHelper.GetSourceLineInfoDelegate value = (StackFrameHelper.GetSourceLineInfoDelegate)method.CreateDelegate(typeof(StackFrameHelper.GetSourceLineInfoDelegate), target);
					Interlocked.CompareExchange<StackFrameHelper.GetSourceLineInfoDelegate>(ref StackFrameHelper.s_getSourceLineInfo, value, null);
				}
				for (int i = 0; i < this.iFrameCount; i++)
				{
					if (this.rgiMethodToken[i] != 0)
					{
						StackFrameHelper.s_getSourceLineInfo(this.rgAssemblyPath[i], this.rgLoadedPeAddress[i], this.rgiLoadedPeSize[i], this.rgInMemoryPdbAddress[i], this.rgiInMemoryPdbSize[i], this.rgiMethodToken[i], this.rgiILOffset[i], out this.rgFilename[i], out this.rgiLineNumber[i], out this.rgiColumnNumber[i]);
					}
				}
			}
			catch
			{
			}
			finally
			{
				StackFrameHelper.t_reentrancy--;
			}
		}

		// Token: 0x06003359 RID: 13145 RVA: 0x000C56B4 File Offset: 0x000C38B4
		void IDisposable.Dispose()
		{
		}

		// Token: 0x0600335A RID: 13146 RVA: 0x000C56B8 File Offset: 0x000C38B8
		[SecuritySafeCritical]
		public virtual MethodBase GetMethodBase(int i)
		{
			IntPtr methodHandleValue = this.rgMethodHandle[i];
			if (methodHandleValue.IsNull())
			{
				return null;
			}
			IRuntimeMethodInfo typicalMethodDefinition = RuntimeMethodHandle.GetTypicalMethodDefinition(new RuntimeMethodInfoStub(methodHandleValue, this));
			return RuntimeType.GetMethodBase(typicalMethodDefinition);
		}

		// Token: 0x0600335B RID: 13147 RVA: 0x000C56EC File Offset: 0x000C38EC
		public virtual int GetOffset(int i)
		{
			return this.rgiOffset[i];
		}

		// Token: 0x0600335C RID: 13148 RVA: 0x000C56F6 File Offset: 0x000C38F6
		public virtual int GetILOffset(int i)
		{
			return this.rgiILOffset[i];
		}

		// Token: 0x0600335D RID: 13149 RVA: 0x000C5700 File Offset: 0x000C3900
		public virtual string GetFilename(int i)
		{
			if (this.rgFilename != null)
			{
				return this.rgFilename[i];
			}
			return null;
		}

		// Token: 0x0600335E RID: 13150 RVA: 0x000C5714 File Offset: 0x000C3914
		public virtual int GetLineNumber(int i)
		{
			if (this.rgiLineNumber != null)
			{
				return this.rgiLineNumber[i];
			}
			return 0;
		}

		// Token: 0x0600335F RID: 13151 RVA: 0x000C5728 File Offset: 0x000C3928
		public virtual int GetColumnNumber(int i)
		{
			if (this.rgiColumnNumber != null)
			{
				return this.rgiColumnNumber[i];
			}
			return 0;
		}

		// Token: 0x06003360 RID: 13152 RVA: 0x000C573C File Offset: 0x000C393C
		public virtual bool IsLastFrameFromForeignExceptionStackTrace(int i)
		{
			return this.rgiLastFrameFromForeignExceptionStackTrace != null && this.rgiLastFrameFromForeignExceptionStackTrace[i];
		}

		// Token: 0x06003361 RID: 13153 RVA: 0x000C5750 File Offset: 0x000C3950
		public virtual int GetNumberOfFrames()
		{
			return this.iFrameCount;
		}

		// Token: 0x06003362 RID: 13154 RVA: 0x000C5758 File Offset: 0x000C3958
		public virtual void SetNumberOfFrames(int i)
		{
			this.iFrameCount = i;
		}

		// Token: 0x06003363 RID: 13155 RVA: 0x000C5764 File Offset: 0x000C3964
		[OnSerializing]
		[SecuritySafeCritical]
		private void OnSerializing(StreamingContext context)
		{
			this.rgMethodBase = ((this.rgMethodHandle == null) ? null : new MethodBase[this.rgMethodHandle.Length]);
			if (this.rgMethodHandle != null)
			{
				for (int i = 0; i < this.rgMethodHandle.Length; i++)
				{
					if (!this.rgMethodHandle[i].IsNull())
					{
						this.rgMethodBase[i] = RuntimeType.GetMethodBase(new RuntimeMethodInfoStub(this.rgMethodHandle[i], this));
					}
				}
			}
		}

		// Token: 0x06003364 RID: 13156 RVA: 0x000C57D8 File Offset: 0x000C39D8
		[OnSerialized]
		private void OnSerialized(StreamingContext context)
		{
			this.rgMethodBase = null;
		}

		// Token: 0x06003365 RID: 13157 RVA: 0x000C57E4 File Offset: 0x000C39E4
		[OnDeserialized]
		[SecuritySafeCritical]
		private void OnDeserialized(StreamingContext context)
		{
			this.rgMethodHandle = ((this.rgMethodBase == null) ? null : new IntPtr[this.rgMethodBase.Length]);
			if (this.rgMethodBase != null)
			{
				for (int i = 0; i < this.rgMethodBase.Length; i++)
				{
					if (this.rgMethodBase[i] != null)
					{
						this.rgMethodHandle[i] = this.rgMethodBase[i].MethodHandle.Value;
					}
				}
			}
			this.rgMethodBase = null;
		}

		// Token: 0x040016C7 RID: 5831
		[NonSerialized]
		private Thread targetThread;

		// Token: 0x040016C8 RID: 5832
		private int[] rgiOffset;

		// Token: 0x040016C9 RID: 5833
		private int[] rgiILOffset;

		// Token: 0x040016CA RID: 5834
		private MethodBase[] rgMethodBase;

		// Token: 0x040016CB RID: 5835
		private object dynamicMethods;

		// Token: 0x040016CC RID: 5836
		[NonSerialized]
		private IntPtr[] rgMethodHandle;

		// Token: 0x040016CD RID: 5837
		private string[] rgAssemblyPath;

		// Token: 0x040016CE RID: 5838
		private IntPtr[] rgLoadedPeAddress;

		// Token: 0x040016CF RID: 5839
		private int[] rgiLoadedPeSize;

		// Token: 0x040016D0 RID: 5840
		private IntPtr[] rgInMemoryPdbAddress;

		// Token: 0x040016D1 RID: 5841
		private int[] rgiInMemoryPdbSize;

		// Token: 0x040016D2 RID: 5842
		private int[] rgiMethodToken;

		// Token: 0x040016D3 RID: 5843
		private string[] rgFilename;

		// Token: 0x040016D4 RID: 5844
		private int[] rgiLineNumber;

		// Token: 0x040016D5 RID: 5845
		private int[] rgiColumnNumber;

		// Token: 0x040016D6 RID: 5846
		[OptionalField]
		private bool[] rgiLastFrameFromForeignExceptionStackTrace;

		// Token: 0x040016D7 RID: 5847
		private int iFrameCount;

		// Token: 0x040016D8 RID: 5848
		private static StackFrameHelper.GetSourceLineInfoDelegate s_getSourceLineInfo;

		// Token: 0x040016D9 RID: 5849
		[ThreadStatic]
		private static int t_reentrancy;

		// Token: 0x02000B81 RID: 2945
		// (Invoke) Token: 0x06006C58 RID: 27736
		private delegate void GetSourceLineInfoDelegate(string assemblyPath, IntPtr loadedPeAddress, int loadedPeSize, IntPtr inMemoryPdbAddress, int inMemoryPdbSize, int methodToken, int ilOffset, out string sourceFile, out int sourceLine, out int sourceColumn);
	}
}
