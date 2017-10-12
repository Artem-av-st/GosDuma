using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GosDumaApiIntegration.BL
{
    internal interface IServices
    {
        Task<string> GetResponseFromApi(string request, IEnumerable<string> parametres);
    }
}
