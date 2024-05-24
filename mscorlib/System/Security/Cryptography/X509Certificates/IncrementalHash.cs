using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002B9 RID: 697
	internal class IncrementalHash : IDisposable
	{
		// Token: 0x060024ED RID: 9453 RVA: 0x0008598C File Offset: 0x00083B8C
		private IncrementalHash(HashAlgorithm algorithm)
		{
			this._algorithm = algorithm;
		}

		// Token: 0x060024EE RID: 9454 RVA: 0x0008599C File Offset: 0x00083B9C
		public static IncrementalHash CreateHash(HashAlgorithmName hashAlgorithm)
		{
			if (hashAlgorithm == HashAlgorithmName.MD5)
			{
				return new IncrementalHash(MD5.Create());
			}
			if (hashAlgorithm == HashAlgorithmName.SHA1)
			{
				return new IncrementalHash(SHA1.Create());
			}
			if (hashAlgorithm == HashAlgorithmName.SHA256)
			{
				return new IncrementalHash(SHA256.Create());
			}
			if (hashAlgorithm == HashAlgorithmName.SHA384)
			{
				return new IncrementalHash(SHA384.Create());
			}
			if (hashAlgorithm == HashAlgorithmName.SHA512)
			{
				return new IncrementalHash(SHA512.Create());
			}
			throw new CryptographicException();
		}

		// Token: 0x060024EF RID: 9455 RVA: 0x00085A28 File Offset: 0x00083C28
		public void AppendData(ReadOnlySpan<byte> data)
		{
			ArraySegment<byte> arraySegment = data.DangerousGetArraySegment();
			this._algorithm.TransformBlock(arraySegment.Array, arraySegment.Offset, arraySegment.Count, null, 0);
		}

		// Token: 0x060024F0 RID: 9456 RVA: 0x00085A60 File Offset: 0x00083C60
		public bool TryGetHashAndReset(Span<byte> destination, out int bytesWritten)
		{
			if (destination.Length < this._algorithm.HashSize / 8)
			{
				bytesWritten = 0;
				return false;
			}
			this._algorithm.TransformFinalBlock(IncrementalHash.s_Empty, 0, 0);
			byte[] hash = this._algorithm.Hash;
			this._algorithm.Initialize();
			new ReadOnlyMemory<byte>(hash).CopyTo(destination);
			bytesWritten = hash.Length;
			return true;
		}

		// Token: 0x060024F1 RID: 9457 RVA: 0x00085AC7 File Offset: 0x00083CC7
		public void Dispose()
		{
			this._algorithm.Clear();
		}

		// Token: 0x04000DC4 RID: 3524
		private readonly HashAlgorithm _algorithm;

		// Token: 0x04000DC5 RID: 3525
		private static readonly byte[] s_Empty = new byte[0];
	}
}
