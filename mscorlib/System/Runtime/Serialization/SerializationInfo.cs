using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using System.Security;

namespace System.Runtime.Serialization
{
	// Token: 0x02000740 RID: 1856
	[ComVisible(true)]
	public sealed class SerializationInfo
	{
		// Token: 0x060051E5 RID: 20965 RVA: 0x0011FF5A File Offset: 0x0011E15A
		[CLSCompliant(false)]
		public SerializationInfo(Type type, IFormatterConverter converter) : this(type, converter, false)
		{
		}

		// Token: 0x060051E6 RID: 20966 RVA: 0x0011FF68 File Offset: 0x0011E168
		[CLSCompliant(false)]
		public SerializationInfo(Type type, IFormatterConverter converter, bool requireSameTokenInPartialTrust)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (converter == null)
			{
				throw new ArgumentNullException("converter");
			}
			this.objectType = type;
			this.m_fullTypeName = type.FullName;
			this.m_assemName = type.Module.Assembly.FullName;
			this.m_members = new string[4];
			this.m_data = new object[4];
			this.m_types = new Type[4];
			this.m_nameToIndex = new Dictionary<string, int>();
			this.m_converter = converter;
			this.requireSameTokenInPartialTrust = requireSameTokenInPartialTrust;
		}

		// Token: 0x17000D7F RID: 3455
		// (get) Token: 0x060051E7 RID: 20967 RVA: 0x0011FFFD File Offset: 0x0011E1FD
		// (set) Token: 0x060051E8 RID: 20968 RVA: 0x00120005 File Offset: 0x0011E205
		public string FullTypeName
		{
			get
			{
				return this.m_fullTypeName;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.m_fullTypeName = value;
				this.isFullTypeNameSetExplicit = true;
			}
		}

		// Token: 0x17000D80 RID: 3456
		// (get) Token: 0x060051E9 RID: 20969 RVA: 0x00120023 File Offset: 0x0011E223
		// (set) Token: 0x060051EA RID: 20970 RVA: 0x0012002B File Offset: 0x0011E22B
		public string AssemblyName
		{
			get
			{
				return this.m_assemName;
			}
			[SecuritySafeCritical]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.requireSameTokenInPartialTrust)
				{
					SerializationInfo.DemandForUnsafeAssemblyNameAssignments(this.m_assemName, value);
				}
				this.m_assemName = value;
				this.isAssemblyNameSetExplicit = true;
			}
		}

		// Token: 0x060051EB RID: 20971 RVA: 0x00120060 File Offset: 0x0011E260
		[SecuritySafeCritical]
		public void SetType(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (this.requireSameTokenInPartialTrust)
			{
				SerializationInfo.DemandForUnsafeAssemblyNameAssignments(this.ObjectType.Assembly.FullName, type.Assembly.FullName);
			}
			if (this.objectType != type)
			{
				this.objectType = type;
				this.m_fullTypeName = type.FullName;
				this.m_assemName = type.Module.Assembly.FullName;
				this.isFullTypeNameSetExplicit = false;
				this.isAssemblyNameSetExplicit = false;
			}
		}

		// Token: 0x060051EC RID: 20972 RVA: 0x001200E4 File Offset: 0x0011E2E4
		private static bool Compare(byte[] a, byte[] b)
		{
			if (a == null || b == null || a.Length == 0 || b.Length == 0 || a.Length != b.Length)
			{
				return false;
			}
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] != b[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060051ED RID: 20973 RVA: 0x00120122 File Offset: 0x0011E322
		[SecuritySafeCritical]
		internal static void DemandForUnsafeAssemblyNameAssignments(string originalAssemblyName, string newAssemblyName)
		{
			if (!SerializationInfo.IsAssemblyNameAssignmentSafe(originalAssemblyName, newAssemblyName))
			{
				CodeAccessPermission.Demand(PermissionType.SecuritySerialization);
			}
		}

		// Token: 0x060051EE RID: 20974 RVA: 0x00120134 File Offset: 0x0011E334
		internal static bool IsAssemblyNameAssignmentSafe(string originalAssemblyName, string newAssemblyName)
		{
			if (originalAssemblyName == newAssemblyName)
			{
				return true;
			}
			AssemblyName assemblyName = new AssemblyName(originalAssemblyName);
			AssemblyName assemblyName2 = new AssemblyName(newAssemblyName);
			return !string.Equals(assemblyName2.Name, "mscorlib", StringComparison.OrdinalIgnoreCase) && !string.Equals(assemblyName2.Name, "mscorlib.dll", StringComparison.OrdinalIgnoreCase) && SerializationInfo.Compare(assemblyName.GetPublicKeyToken(), assemblyName2.GetPublicKeyToken());
		}

		// Token: 0x17000D81 RID: 3457
		// (get) Token: 0x060051EF RID: 20975 RVA: 0x00120193 File Offset: 0x0011E393
		public int MemberCount
		{
			get
			{
				return this.m_currMember;
			}
		}

		// Token: 0x17000D82 RID: 3458
		// (get) Token: 0x060051F0 RID: 20976 RVA: 0x0012019B File Offset: 0x0011E39B
		public Type ObjectType
		{
			get
			{
				return this.objectType;
			}
		}

		// Token: 0x17000D83 RID: 3459
		// (get) Token: 0x060051F1 RID: 20977 RVA: 0x001201A3 File Offset: 0x0011E3A3
		public bool IsFullTypeNameSetExplicit
		{
			get
			{
				return this.isFullTypeNameSetExplicit;
			}
		}

		// Token: 0x17000D84 RID: 3460
		// (get) Token: 0x060051F2 RID: 20978 RVA: 0x001201AB File Offset: 0x0011E3AB
		public bool IsAssemblyNameSetExplicit
		{
			get
			{
				return this.isAssemblyNameSetExplicit;
			}
		}

		// Token: 0x060051F3 RID: 20979 RVA: 0x001201B3 File Offset: 0x0011E3B3
		public SerializationInfoEnumerator GetEnumerator()
		{
			return new SerializationInfoEnumerator(this.m_members, this.m_data, this.m_types, this.m_currMember);
		}

		// Token: 0x060051F4 RID: 20980 RVA: 0x001201D4 File Offset: 0x0011E3D4
		private void ExpandArrays()
		{
			int num = this.m_currMember * 2;
			if (num < this.m_currMember && 2147483647 > this.m_currMember)
			{
				num = int.MaxValue;
			}
			string[] array = new string[num];
			object[] array2 = new object[num];
			Type[] array3 = new Type[num];
			Array.Copy(this.m_members, array, this.m_currMember);
			Array.Copy(this.m_data, array2, this.m_currMember);
			Array.Copy(this.m_types, array3, this.m_currMember);
			this.m_members = array;
			this.m_data = array2;
			this.m_types = array3;
		}

		// Token: 0x060051F5 RID: 20981 RVA: 0x00120266 File Offset: 0x0011E466
		public void AddValue(string name, object value, Type type)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.AddValueInternal(name, value, type);
		}

		// Token: 0x060051F6 RID: 20982 RVA: 0x0012028D File Offset: 0x0011E48D
		public void AddValue(string name, object value)
		{
			if (value == null)
			{
				this.AddValue(name, value, typeof(object));
				return;
			}
			this.AddValue(name, value, value.GetType());
		}

		// Token: 0x060051F7 RID: 20983 RVA: 0x001202B3 File Offset: 0x0011E4B3
		public void AddValue(string name, bool value)
		{
			this.AddValue(name, value, typeof(bool));
		}

		// Token: 0x060051F8 RID: 20984 RVA: 0x001202CC File Offset: 0x0011E4CC
		public void AddValue(string name, char value)
		{
			this.AddValue(name, value, typeof(char));
		}

		// Token: 0x060051F9 RID: 20985 RVA: 0x001202E5 File Offset: 0x0011E4E5
		[CLSCompliant(false)]
		public void AddValue(string name, sbyte value)
		{
			this.AddValue(name, value, typeof(sbyte));
		}

		// Token: 0x060051FA RID: 20986 RVA: 0x001202FE File Offset: 0x0011E4FE
		public void AddValue(string name, byte value)
		{
			this.AddValue(name, value, typeof(byte));
		}

		// Token: 0x060051FB RID: 20987 RVA: 0x00120317 File Offset: 0x0011E517
		public void AddValue(string name, short value)
		{
			this.AddValue(name, value, typeof(short));
		}

		// Token: 0x060051FC RID: 20988 RVA: 0x00120330 File Offset: 0x0011E530
		[CLSCompliant(false)]
		public void AddValue(string name, ushort value)
		{
			this.AddValue(name, value, typeof(ushort));
		}

		// Token: 0x060051FD RID: 20989 RVA: 0x00120349 File Offset: 0x0011E549
		public void AddValue(string name, int value)
		{
			this.AddValue(name, value, typeof(int));
		}

		// Token: 0x060051FE RID: 20990 RVA: 0x00120362 File Offset: 0x0011E562
		[CLSCompliant(false)]
		public void AddValue(string name, uint value)
		{
			this.AddValue(name, value, typeof(uint));
		}

		// Token: 0x060051FF RID: 20991 RVA: 0x0012037B File Offset: 0x0011E57B
		public void AddValue(string name, long value)
		{
			this.AddValue(name, value, typeof(long));
		}

		// Token: 0x06005200 RID: 20992 RVA: 0x00120394 File Offset: 0x0011E594
		[CLSCompliant(false)]
		public void AddValue(string name, ulong value)
		{
			this.AddValue(name, value, typeof(ulong));
		}

		// Token: 0x06005201 RID: 20993 RVA: 0x001203AD File Offset: 0x0011E5AD
		public void AddValue(string name, float value)
		{
			this.AddValue(name, value, typeof(float));
		}

		// Token: 0x06005202 RID: 20994 RVA: 0x001203C6 File Offset: 0x0011E5C6
		public void AddValue(string name, double value)
		{
			this.AddValue(name, value, typeof(double));
		}

		// Token: 0x06005203 RID: 20995 RVA: 0x001203DF File Offset: 0x0011E5DF
		public void AddValue(string name, decimal value)
		{
			this.AddValue(name, value, typeof(decimal));
		}

		// Token: 0x06005204 RID: 20996 RVA: 0x001203F8 File Offset: 0x0011E5F8
		public void AddValue(string name, DateTime value)
		{
			this.AddValue(name, value, typeof(DateTime));
		}

		// Token: 0x06005205 RID: 20997 RVA: 0x00120414 File Offset: 0x0011E614
		internal void AddValueInternal(string name, object value, Type type)
		{
			if (this.m_nameToIndex.ContainsKey(name))
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_SameNameTwice"));
			}
			this.m_nameToIndex.Add(name, this.m_currMember);
			if (this.m_currMember >= this.m_members.Length)
			{
				this.ExpandArrays();
			}
			this.m_members[this.m_currMember] = name;
			this.m_data[this.m_currMember] = value;
			this.m_types[this.m_currMember] = type;
			this.m_currMember++;
		}

		// Token: 0x06005206 RID: 20998 RVA: 0x001204A0 File Offset: 0x0011E6A0
		internal void UpdateValue(string name, object value, Type type)
		{
			int num = this.FindElement(name);
			if (num < 0)
			{
				this.AddValueInternal(name, value, type);
				return;
			}
			this.m_data[num] = value;
			this.m_types[num] = type;
		}

		// Token: 0x06005207 RID: 20999 RVA: 0x001204D8 File Offset: 0x0011E6D8
		private int FindElement(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			int result;
			if (this.m_nameToIndex.TryGetValue(name, out result))
			{
				return result;
			}
			return -1;
		}

		// Token: 0x06005208 RID: 21000 RVA: 0x00120508 File Offset: 0x0011E708
		private object GetElement(string name, out Type foundType)
		{
			int num = this.FindElement(name);
			if (num == -1)
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_NotFound", new object[]
				{
					name
				}));
			}
			foundType = this.m_types[num];
			return this.m_data[num];
		}

		// Token: 0x06005209 RID: 21001 RVA: 0x00120550 File Offset: 0x0011E750
		[ComVisible(true)]
		private object GetElementNoThrow(string name, out Type foundType)
		{
			int num = this.FindElement(name);
			if (num == -1)
			{
				foundType = null;
				return null;
			}
			foundType = this.m_types[num];
			return this.m_data[num];
		}

		// Token: 0x0600520A RID: 21002 RVA: 0x00120580 File Offset: 0x0011E780
		[SecuritySafeCritical]
		public object GetValue(string name, Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			RuntimeType runtimeType = type as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			Type type2;
			object element = this.GetElement(name, out type2);
			if (RemotingServices.IsTransparentProxy(element))
			{
				RealProxy realProxy = RemotingServices.GetRealProxy(element);
				if (RemotingServices.ProxyCheckCast(realProxy, runtimeType))
				{
					return element;
				}
			}
			else if (type2 == type || type.IsAssignableFrom(type2) || element == null)
			{
				return element;
			}
			return this.m_converter.Convert(element, type);
		}

		// Token: 0x0600520B RID: 21003 RVA: 0x00120600 File Offset: 0x0011E800
		[SecuritySafeCritical]
		[ComVisible(true)]
		internal object GetValueNoThrow(string name, Type type)
		{
			Type type2;
			object elementNoThrow = this.GetElementNoThrow(name, out type2);
			if (elementNoThrow == null)
			{
				return null;
			}
			if (RemotingServices.IsTransparentProxy(elementNoThrow))
			{
				RealProxy realProxy = RemotingServices.GetRealProxy(elementNoThrow);
				if (RemotingServices.ProxyCheckCast(realProxy, (RuntimeType)type))
				{
					return elementNoThrow;
				}
			}
			else if (type2 == type || type.IsAssignableFrom(type2) || elementNoThrow == null)
			{
				return elementNoThrow;
			}
			return this.m_converter.Convert(elementNoThrow, type);
		}

		// Token: 0x0600520C RID: 21004 RVA: 0x0012065C File Offset: 0x0011E85C
		public bool GetBoolean(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(bool))
			{
				return (bool)element;
			}
			return this.m_converter.ToBoolean(element);
		}

		// Token: 0x0600520D RID: 21005 RVA: 0x00120694 File Offset: 0x0011E894
		public char GetChar(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(char))
			{
				return (char)element;
			}
			return this.m_converter.ToChar(element);
		}

		// Token: 0x0600520E RID: 21006 RVA: 0x001206CC File Offset: 0x0011E8CC
		[CLSCompliant(false)]
		public sbyte GetSByte(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(sbyte))
			{
				return (sbyte)element;
			}
			return this.m_converter.ToSByte(element);
		}

		// Token: 0x0600520F RID: 21007 RVA: 0x00120704 File Offset: 0x0011E904
		public byte GetByte(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(byte))
			{
				return (byte)element;
			}
			return this.m_converter.ToByte(element);
		}

		// Token: 0x06005210 RID: 21008 RVA: 0x0012073C File Offset: 0x0011E93C
		public short GetInt16(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(short))
			{
				return (short)element;
			}
			return this.m_converter.ToInt16(element);
		}

		// Token: 0x06005211 RID: 21009 RVA: 0x00120774 File Offset: 0x0011E974
		[CLSCompliant(false)]
		public ushort GetUInt16(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(ushort))
			{
				return (ushort)element;
			}
			return this.m_converter.ToUInt16(element);
		}

		// Token: 0x06005212 RID: 21010 RVA: 0x001207AC File Offset: 0x0011E9AC
		public int GetInt32(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(int))
			{
				return (int)element;
			}
			return this.m_converter.ToInt32(element);
		}

		// Token: 0x06005213 RID: 21011 RVA: 0x001207E4 File Offset: 0x0011E9E4
		[CLSCompliant(false)]
		public uint GetUInt32(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(uint))
			{
				return (uint)element;
			}
			return this.m_converter.ToUInt32(element);
		}

		// Token: 0x06005214 RID: 21012 RVA: 0x0012081C File Offset: 0x0011EA1C
		public long GetInt64(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(long))
			{
				return (long)element;
			}
			return this.m_converter.ToInt64(element);
		}

		// Token: 0x06005215 RID: 21013 RVA: 0x00120854 File Offset: 0x0011EA54
		[CLSCompliant(false)]
		public ulong GetUInt64(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(ulong))
			{
				return (ulong)element;
			}
			return this.m_converter.ToUInt64(element);
		}

		// Token: 0x06005216 RID: 21014 RVA: 0x0012088C File Offset: 0x0011EA8C
		public float GetSingle(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(float))
			{
				return (float)element;
			}
			return this.m_converter.ToSingle(element);
		}

		// Token: 0x06005217 RID: 21015 RVA: 0x001208C4 File Offset: 0x0011EAC4
		public double GetDouble(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(double))
			{
				return (double)element;
			}
			return this.m_converter.ToDouble(element);
		}

		// Token: 0x06005218 RID: 21016 RVA: 0x001208FC File Offset: 0x0011EAFC
		public decimal GetDecimal(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(decimal))
			{
				return (decimal)element;
			}
			return this.m_converter.ToDecimal(element);
		}

		// Token: 0x06005219 RID: 21017 RVA: 0x00120934 File Offset: 0x0011EB34
		public DateTime GetDateTime(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(DateTime))
			{
				return (DateTime)element;
			}
			return this.m_converter.ToDateTime(element);
		}

		// Token: 0x0600521A RID: 21018 RVA: 0x0012096C File Offset: 0x0011EB6C
		public string GetString(string name)
		{
			Type type;
			object element = this.GetElement(name, out type);
			if (type == typeof(string) || element == null)
			{
				return (string)element;
			}
			return this.m_converter.ToString(element);
		}

		// Token: 0x17000D85 RID: 3461
		// (get) Token: 0x0600521B RID: 21019 RVA: 0x001209A6 File Offset: 0x0011EBA6
		internal string[] MemberNames
		{
			get
			{
				return this.m_members;
			}
		}

		// Token: 0x17000D86 RID: 3462
		// (get) Token: 0x0600521C RID: 21020 RVA: 0x001209AE File Offset: 0x0011EBAE
		internal object[] MemberValues
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x04002442 RID: 9282
		private const int defaultSize = 4;

		// Token: 0x04002443 RID: 9283
		private const string s_mscorlibAssemblySimpleName = "mscorlib";

		// Token: 0x04002444 RID: 9284
		private const string s_mscorlibFileName = "mscorlib.dll";

		// Token: 0x04002445 RID: 9285
		internal string[] m_members;

		// Token: 0x04002446 RID: 9286
		internal object[] m_data;

		// Token: 0x04002447 RID: 9287
		internal Type[] m_types;

		// Token: 0x04002448 RID: 9288
		private Dictionary<string, int> m_nameToIndex;

		// Token: 0x04002449 RID: 9289
		internal int m_currMember;

		// Token: 0x0400244A RID: 9290
		internal IFormatterConverter m_converter;

		// Token: 0x0400244B RID: 9291
		private string m_fullTypeName;

		// Token: 0x0400244C RID: 9292
		private string m_assemName;

		// Token: 0x0400244D RID: 9293
		private Type objectType;

		// Token: 0x0400244E RID: 9294
		private bool isFullTypeNameSetExplicit;

		// Token: 0x0400244F RID: 9295
		private bool isAssemblyNameSetExplicit;

		// Token: 0x04002450 RID: 9296
		private bool requireSameTokenInPartialTrust;
	}
}
