using AutoMapper;

namespace ClubsCore.Mapping
{
    public static class MapperInitializer
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClubProfile>();
            });

            return config.CreateMapper();
        }
    }
}