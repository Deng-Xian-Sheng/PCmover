using System;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Security.Cryptography
{
	// Token: 0x0200024F RID: 591
	[ComVisible(true)]
	public class ToBase64Transform : ICryptoTransform, IDisposable
	{
		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x060020F2 RID: 8434 RVA: 0x00072D12 File Offset: 0x00070F12
		public int InputBlockSize
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x060020F3 RID: 8435 RVA: 0x00072D15 File Offset: 0x00070F15
		public int OutputBlockSize
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x060020F4 RID: 8436 RVA: 0x00072D18 File Offset: 0x00070F18
		public bool CanTransformMultipleBlocks
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x060020F5 RID: 8437 RVA: 0x00072D1B File Offset: 0x00070F1B
		public virtual bool CanReuseTransform
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060020F6 RID: 8438 RVA: 0x00072D20 File Offset: 0x00070F20
		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			if (inputBuffer == null)
			{
				throw new ArgumentNullException("inputBuffer");
			}
			if (inputOffset < 0)
			{
				throw new ArgumentOutOfRangeException("inputOffset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (inputCount < 0 || inputCount > inputBuffer.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidValue"));
			}
			if (inputBuffer.Length - inputCount < inputOffset)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			char[] array = new char[4];
			Convert.ToBase64CharArray(inputBuffer, inputOffset, 3, array, 0);
			byte[] bytes = Encoding.ASCII.GetBytes(array);
			if (bytes.Length != 4)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_SSE_InvalidDataSize"));
			}
			Buffer.BlockCopy(bytes, 0, outputBuffer, outputOffset, bytes.Length);
			return bytes.Length;
		}

		// Token: 0x060020F7 RID: 8439 RVA: 0x00072DCC File Offset: 0x00070FCC
		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			if (inputBuffer == null)
			{
				throw new ArgumentNullException("inputBuffer");
			}
			if (inputOffset < 0)
			{
				throw new ArgumentOutOfRangeException("inputOffset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (inputCount < 0 || inputCount > inputBuffer.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidValue"));
			}
			if (inputBuffer.Length - inputCount < inputOffset)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			if (inputCount == 0)
			{
				return EmptyArray<byte>.Value;
			}
			char[] array = new char[4];
			Convert.ToBase64CharArray(inputBuffer, inputOffset, inputCount, array, 0);
			return Encoding.ASCII.GetBytes(array);
		}

		// Token: 0x060020F8 RID: 8440 RVA: 0x00072E5A File Offset: 0x0007105A
		public void Dispose()
		{
			this.Clear();
		}

		// Token: 0x060020F9 RID: 8441 RVA: 0x00072E62 File Offset: 0x00071062
		public void Clear()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060020FA RID: 8442 RVA: 0x00072E71 File Offset: 0x00071071
		protected virtual void Dispose(bool disposing)
		{
		}

		// Token: 0x060020FB RID: 8443 RVA: 0x00072E74 File Offset: 0x00071074
		~ToBase64Transform()
		{
			this.Dispose(false);
		}
	}
}
