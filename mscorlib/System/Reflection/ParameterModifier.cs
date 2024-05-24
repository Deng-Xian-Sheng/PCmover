using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000617 RID: 1559
	[ComVisible(true)]
	[Serializable]
	public struct ParameterModifier
	{
		// Token: 0x06004843 RID: 18499 RVA: 0x00106B62 File Offset: 0x00104D62
		public ParameterModifier(int parameterCount)
		{
			if (parameterCount <= 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ParmArraySize"));
			}
			this._byRef = new bool[parameterCount];
		}

		// Token: 0x17000B3C RID: 2876
		// (get) Token: 0x06004844 RID: 18500 RVA: 0x00106B84 File Offset: 0x00104D84
		internal bool[] IsByRefArray
		{
			get
			{
				return this._byRef;
			}
		}

		// Token: 0x17000B3D RID: 2877
		public bool this[int index]
		{
			get
			{
				return this._byRef[index];
			}
			set
			{
				this._byRef[index] = value;
			}
		}

		// Token: 0x04001DF8 RID: 7672
		private bool[] _byRef;
	}
}
