using Publico.Common.Entities;
using System;

namespace Publico.Services
{
    public interface IBotService
    {
        StooqModel GetStooq(string stock_code);
    } 
}
