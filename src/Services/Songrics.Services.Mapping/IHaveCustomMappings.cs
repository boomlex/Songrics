using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Songrics.Services.Mapping
{

    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
