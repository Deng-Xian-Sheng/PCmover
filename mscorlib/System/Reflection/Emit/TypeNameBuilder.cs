using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Reflection.Emit
{
	// Token: 0x0200062E RID: 1582
	internal class TypeNameBuilder
	{
		// Token: 0x06004988 RID: 18824
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern IntPtr CreateTypeNameBuilder();

		// Token: 0x06004989 RID: 18825
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void ReleaseTypeNameBuilder(IntPtr pAQN);

		// Token: 0x0600498A RID: 18826
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void OpenGenericArguments(IntPtr tnb);

		// Token: 0x0600498B RID: 18827
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void CloseGenericArguments(IntPtr tnb);

		// Token: 0x0600498C RID: 18828
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void OpenGenericArgument(IntPtr tnb);

		// Token: 0x0600498D RID: 18829
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void CloseGenericArgument(IntPtr tnb);

		// Token: 0x0600498E RID: 18830
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddName(IntPtr tnb, string name);

		// Token: 0x0600498F RID: 18831
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddPointer(IntPtr tnb);

		// Token: 0x06004990 RID: 18832
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddByRef(IntPtr tnb);

		// Token: 0x06004991 RID: 18833
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddSzArray(IntPtr tnb);

		// Token: 0x06004992 RID: 18834
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddArray(IntPtr tnb, int rank);

		// Token: 0x06004993 RID: 18835
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddAssemblySpec(IntPtr tnb, string assemblySpec);

		// Token: 0x06004994 RID: 18836
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void ToString(IntPtr tnb, StringHandleOnStack retString);

		// Token: 0x06004995 RID: 18837
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void Clear(IntPtr tnb);

		// Token: 0x06004996 RID: 18838 RVA: 0x0010A86C File Offset: 0x00108A6C
		[SecuritySafeCritical]
		internal static string ToString(Type type, TypeNameBuilder.Format format)
		{
			if ((format == TypeNameBuilder.Format.FullName || format == TypeNameBuilder.Format.AssemblyQualifiedName) && !type.IsGenericTypeDefinition && type.ContainsGenericParameters)
			{
				return null;
			}
			TypeNameBuilder typeNameBuilder = new TypeNameBuilder(TypeNameBuilder.CreateTypeNameBuilder());
			typeNameBuilder.Clear();
			typeNameBuilder.ConstructAssemblyQualifiedNameWorker(type, format);
			string result = typeNameBuilder.ToString();
			typeNameBuilder.Dispose();
			return result;
		}

		// Token: 0x06004997 RID: 18839 RVA: 0x0010A8BA File Offset: 0x00108ABA
		private TypeNameBuilder(IntPtr typeNameBuilder)
		{
			this.m_typeNameBuilder = typeNameBuilder;
		}

		// Token: 0x06004998 RID: 18840 RVA: 0x0010A8C9 File Offset: 0x00108AC9
		[SecurityCritical]
		internal void Dispose()
		{
			TypeNameBuilder.ReleaseTypeNameBuilder(this.m_typeNameBuilder);
		}

		// Token: 0x06004999 RID: 18841 RVA: 0x0010A8D8 File Offset: 0x00108AD8
		[SecurityCritical]
		private void AddElementType(Type elementType)
		{
			if (elementType.HasElementType)
			{
				this.AddElementType(elementType.GetElementType());
			}
			if (elementType.IsPointer)
			{
				this.AddPointer();
				return;
			}
			if (elementType.IsByRef)
			{
				this.AddByRef();
				return;
			}
			if (elementType.IsSzArray)
			{
				this.AddSzArray();
				return;
			}
			if (elementType.IsArray)
			{
				this.AddArray(elementType.GetArrayRank());
			}
		}

		// Token: 0x0600499A RID: 18842 RVA: 0x0010A93C File Offset: 0x00108B3C
		[SecurityCritical]
		private void ConstructAssemblyQualifiedNameWorker(Type type, TypeNameBuilder.Format format)
		{
			Type type2 = type;
			while (type2.HasElementType)
			{
				type2 = type2.GetElementType();
			}
			List<Type> list = new List<Type>();
			Type type3 = type2;
			while (type3 != null)
			{
				list.Add(type3);
				type3 = (type3.IsGenericParameter ? null : type3.DeclaringType);
			}
			for (int i = list.Count - 1; i >= 0; i--)
			{
				Type type4 = list[i];
				string text = type4.Name;
				if (i == list.Count - 1 && type4.Namespace != null && type4.Namespace.Length != 0)
				{
					text = type4.Namespace + "." + text;
				}
				this.AddName(text);
			}
			if (type2.IsGenericType && (!type2.IsGenericTypeDefinition || format == TypeNameBuilder.Format.ToString))
			{
				Type[] genericArguments = type2.GetGenericArguments();
				this.OpenGenericArguments();
				for (int j = 0; j < genericArguments.Length; j++)
				{
					TypeNameBuilder.Format format2 = (format == TypeNameBuilder.Format.FullName) ? TypeNameBuilder.Format.AssemblyQualifiedName : format;
					this.OpenGenericArgument();
					this.ConstructAssemblyQualifiedNameWorker(genericArguments[j], format2);
					this.CloseGenericArgument();
				}
				this.CloseGenericArguments();
			}
			this.AddElementType(type);
			if (format == TypeNameBuilder.Format.AssemblyQualifiedName)
			{
				this.AddAssemblySpec(type.Module.Assembly.FullName);
			}
		}

		// Token: 0x0600499B RID: 18843 RVA: 0x0010AA6A File Offset: 0x00108C6A
		[SecurityCritical]
		private void OpenGenericArguments()
		{
			TypeNameBuilder.OpenGenericArguments(this.m_typeNameBuilder);
		}

		// Token: 0x0600499C RID: 18844 RVA: 0x0010AA77 File Offset: 0x00108C77
		[SecurityCritical]
		private void CloseGenericArguments()
		{
			TypeNameBuilder.CloseGenericArguments(this.m_typeNameBuilder);
		}

		// Token: 0x0600499D RID: 18845 RVA: 0x0010AA84 File Offset: 0x00108C84
		[SecurityCritical]
		private void OpenGenericArgument()
		{
			TypeNameBuilder.OpenGenericArgument(this.m_typeNameBuilder);
		}

		// Token: 0x0600499E RID: 18846 RVA: 0x0010AA91 File Offset: 0x00108C91
		[SecurityCritical]
		private void CloseGenericArgument()
		{
			TypeNameBuilder.CloseGenericArgument(this.m_typeNameBuilder);
		}

		// Token: 0x0600499F RID: 18847 RVA: 0x0010AA9E File Offset: 0x00108C9E
		[SecurityCritical]
		private void AddName(string name)
		{
			TypeNameBuilder.AddName(this.m_typeNameBuilder, name);
		}

		// Token: 0x060049A0 RID: 18848 RVA: 0x0010AAAC File Offset: 0x00108CAC
		[SecurityCritical]
		private void AddPointer()
		{
			TypeNameBuilder.AddPointer(this.m_typeNameBuilder);
		}

		// Token: 0x060049A1 RID: 18849 RVA: 0x0010AAB9 File Offset: 0x00108CB9
		[SecurityCritical]
		private void AddByRef()
		{
			TypeNameBuilder.AddByRef(this.m_typeNameBuilder);
		}

		// Token: 0x060049A2 RID: 18850 RVA: 0x0010AAC6 File Offset: 0x00108CC6
		[SecurityCritical]
		private void AddSzArray()
		{
			TypeNameBuilder.AddSzArray(this.m_typeNameBuilder);
		}

		// Token: 0x060049A3 RID: 18851 RVA: 0x0010AAD3 File Offset: 0x00108CD3
		[SecurityCritical]
		private void AddArray(int rank)
		{
			TypeNameBuilder.AddArray(this.m_typeNameBuilder, rank);
		}

		// Token: 0x060049A4 RID: 18852 RVA: 0x0010AAE1 File Offset: 0x00108CE1
		[SecurityCritical]
		private void AddAssemblySpec(string assemblySpec)
		{
			TypeNameBuilder.AddAssemblySpec(this.m_typeNameBuilder, assemblySpec);
		}

		// Token: 0x060049A5 RID: 18853 RVA: 0x0010AAF0 File Offset: 0x00108CF0
		[SecuritySafeCritical]
		public override string ToString()
		{
			string result = null;
			TypeNameBuilder.ToString(this.m_typeNameBuilder, JitHelpers.GetStringHandleOnStack(ref result));
			return result;
		}

		// Token: 0x060049A6 RID: 18854 RVA: 0x0010AB12 File Offset: 0x00108D12
		[SecurityCritical]
		private void Clear()
		{
			TypeNameBuilder.Clear(this.m_typeNameBuilder);
		}

		// Token: 0x04001E7B RID: 7803
		private IntPtr m_typeNameBuilder;

		// Token: 0x02000C3C RID: 3132
		internal enum Format
		{
			// Token: 0x04003743 RID: 14147
			ToString,
			// Token: 0x04003744 RID: 14148
			FullName,
			// Token: 0x04003745 RID: 14149
			AssemblyQualifiedName
		}
	}
}
