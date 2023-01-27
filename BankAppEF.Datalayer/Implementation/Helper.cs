using AutoMapper;

namespace BankAppEF.Datalayer.Implementation
{
    public static class Helper<Source, Destination>
    {
        public static Mapper _myMapper = new Mapper(new MapperConfiguration(
            options => options.CreateMap<Source, Destination>()
            ));

        public static Destination Map(Source source)
        {
            return _myMapper.Map<Destination>(source);
        }
        public static IEnumerable<Destination> Map(IEnumerable<Source> source)
        {
            return _myMapper.Map<IEnumerable<Destination>>(source);
        }

    }
}
