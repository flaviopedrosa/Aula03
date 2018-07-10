using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace ApiLivraria.Services
{
    public abstract class BaseService
    {
       public static readonly HttpClient client = new HttpClient();


    }
}
