using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200086C RID: 2156
	[Serializable]
	internal class SerializationMonkey : ISerializable, IFieldInfo
	{
		// Token: 0x06005BC2 RID: 23490 RVA: 0x001420A5 File Offset: 0x001402A5
		[SecurityCritical]
		internal SerializationMonkey(SerializationInfo info, StreamingContext ctx)
		{
			this._obj.RootSetObjectData(info, ctx);
		}

		// Token: 0x06005BC3 RID: 23491 RVA: 0x001420BA File Offset: 0x001402BA
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_Method"));
		}

		// Token: 0x17000FA6 RID: 4006
		// (get) Token: 0x06005BC4 RID: 23492 RVA: 0x001420CB File Offset: 0x001402CB
		// (set) Token: 0x06005BC5 RID: 23493 RVA: 0x001420D3 File Offset: 0x001402D3
		public string[] FieldNames
		{
			[SecurityCritical]
			get
			{
				return this.fieldNames;
			}
			[SecurityCritical]
			set
			{
				this.fieldNames = value;
			}
		}

		// Token: 0x17000FA7 RID: 4007
		// (get) Token: 0x06005BC6 RID: 23494 RVA: 0x001420DC File Offset: 0x001402DC
		// (set) Token: 0x06005BC7 RID: 23495 RVA: 0x001420E4 File Offset: 0x001402E4
		public Type[] FieldTypes
		{
			[SecurityCritical]
			get
			{
				return this.fieldTypes;
			}
			[SecurityCritical]
			set
			{
				this.fieldTypes = value;
			}
		}

		// Token: 0x04002978 RID: 10616
		internal ISerializationRootObject _obj;

		// Token: 0x04002979 RID: 10617
		internal string[] fieldNames;

		// Token: 0x0400297A RID: 10618
		internal Type[] fieldTypes;
	}
}
