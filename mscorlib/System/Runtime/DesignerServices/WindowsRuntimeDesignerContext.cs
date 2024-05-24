using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace System.Runtime.DesignerServices
{
	// Token: 0x0200071A RID: 1818
	public sealed class WindowsRuntimeDesignerContext
	{
		// Token: 0x06005133 RID: 20787
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern IntPtr CreateDesignerContext([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[] paths, int count, bool shared);

		// Token: 0x06005134 RID: 20788 RVA: 0x0011E5CC File Offset: 0x0011C7CC
		[SecurityCritical]
		internal static IntPtr CreateDesignerContext(IEnumerable<string> paths, [MarshalAs(UnmanagedType.Bool)] bool shared)
		{
			List<string> list = new List<string>(paths);
			string[] array = list.ToArray();
			foreach (string text in array)
			{
				if (text == null)
				{
					throw new ArgumentNullException(Environment.GetResourceString("ArgumentNull_Path"));
				}
				if (Path.IsRelative(text))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_AbsolutePathRequired"));
				}
			}
			return WindowsRuntimeDesignerContext.CreateDesignerContext(array, array.Length, shared);
		}

		// Token: 0x06005135 RID: 20789
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetCurrentContext([MarshalAs(UnmanagedType.Bool)] bool isDesignerContext, IntPtr context);

		// Token: 0x06005136 RID: 20790 RVA: 0x0011E634 File Offset: 0x0011C834
		[SecurityCritical]
		private WindowsRuntimeDesignerContext(IEnumerable<string> paths, string name, bool designModeRequired)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (paths == null)
			{
				throw new ArgumentNullException("paths");
			}
			if (!AppDomain.CurrentDomain.IsDefaultAppDomain())
			{
				throw new NotSupportedException();
			}
			if (!AppDomain.IsAppXModel())
			{
				throw new NotSupportedException();
			}
			if (designModeRequired && !AppDomain.IsAppXDesignMode())
			{
				throw new NotSupportedException();
			}
			this.m_name = name;
			object obj = WindowsRuntimeDesignerContext.s_lock;
			lock (obj)
			{
				if (WindowsRuntimeDesignerContext.s_sharedContext == IntPtr.Zero)
				{
					WindowsRuntimeDesignerContext.InitializeSharedContext(new string[0]);
				}
			}
			this.m_contextObject = WindowsRuntimeDesignerContext.CreateDesignerContext(paths, false);
		}

		// Token: 0x06005137 RID: 20791 RVA: 0x0011E6F0 File Offset: 0x0011C8F0
		[SecurityCritical]
		public WindowsRuntimeDesignerContext(IEnumerable<string> paths, string name) : this(paths, name, true)
		{
		}

		// Token: 0x06005138 RID: 20792 RVA: 0x0011E6FC File Offset: 0x0011C8FC
		[SecurityCritical]
		public static void InitializeSharedContext(IEnumerable<string> paths)
		{
			if (!AppDomain.CurrentDomain.IsDefaultAppDomain())
			{
				throw new NotSupportedException();
			}
			if (paths == null)
			{
				throw new ArgumentNullException("paths");
			}
			object obj = WindowsRuntimeDesignerContext.s_lock;
			lock (obj)
			{
				if (WindowsRuntimeDesignerContext.s_sharedContext != IntPtr.Zero)
				{
					throw new NotSupportedException();
				}
				IntPtr context = WindowsRuntimeDesignerContext.CreateDesignerContext(paths, true);
				WindowsRuntimeDesignerContext.SetCurrentContext(false, context);
				WindowsRuntimeDesignerContext.s_sharedContext = context;
			}
		}

		// Token: 0x06005139 RID: 20793 RVA: 0x0011E784 File Offset: 0x0011C984
		[SecurityCritical]
		public static void SetIterationContext(WindowsRuntimeDesignerContext context)
		{
			if (!AppDomain.CurrentDomain.IsDefaultAppDomain())
			{
				throw new NotSupportedException();
			}
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			object obj = WindowsRuntimeDesignerContext.s_lock;
			lock (obj)
			{
				WindowsRuntimeDesignerContext.SetCurrentContext(true, context.m_contextObject);
			}
		}

		// Token: 0x0600513A RID: 20794 RVA: 0x0011E7EC File Offset: 0x0011C9EC
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Assembly GetAssembly(string assemblyName)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoad(assemblyName, null, ref stackCrawlMark, this.m_contextObject, false);
		}

		// Token: 0x0600513B RID: 20795 RVA: 0x0011E80C File Offset: 0x0011CA0C
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Type GetType(string typeName)
		{
			if (typeName == null)
			{
				throw new ArgumentNullException("typeName");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeTypeHandle.GetTypeByName(typeName, false, false, false, ref stackCrawlMark, this.m_contextObject, false);
		}

		// Token: 0x17000D5B RID: 3419
		// (get) Token: 0x0600513C RID: 20796 RVA: 0x0011E83B File Offset: 0x0011CA3B
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x040023F6 RID: 9206
		private static object s_lock = new object();

		// Token: 0x040023F7 RID: 9207
		private static IntPtr s_sharedContext;

		// Token: 0x040023F8 RID: 9208
		private IntPtr m_contextObject;

		// Token: 0x040023F9 RID: 9209
		private string m_name;
	}
}
