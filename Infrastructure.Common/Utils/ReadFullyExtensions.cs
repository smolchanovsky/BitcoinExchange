using System.IO;

namespace Infrastructure.Common.Utils
{
	public static class ReadFullyExtensions
	{
		public static byte[] ReadFully(this Stream source)
		{
			using (var memoryStream = new MemoryStream())
			{
				source.CopyTo(memoryStream);
				return memoryStream.ToArray();
			}
		}
	}
}