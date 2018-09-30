using AutoMapper;

namespace Infrastructure.Common
{
	public static class MapperFactory
	{
		public static IMapper Create()
		{
			var mapperConfiguration = new MapperConfiguration(_ => { });
			return new Mapper(mapperConfiguration);
		}
	}
}