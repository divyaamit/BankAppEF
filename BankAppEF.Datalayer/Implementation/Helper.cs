using AutoMapper;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
