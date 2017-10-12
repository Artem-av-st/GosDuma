using GosDumaApiIntegration.BL;
using GosDumaApiIntegration.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GosDumaApiIntegration
{
    public class GosDuma
    {

        private readonly string _apiToken;
        private readonly string _appToken;
        private IServices _service;

        public GosDuma(string apiToken, string appToken)
        {
            _apiToken = apiToken;
            _appToken = appToken;
            _service = JsonServices.GetInstance(_apiToken, _appToken);
        }

        public async Task<List<Deputy>> GetDeputiesList(bool isCurrent = true, Deputy.DeputyPosition position = Deputy.DeputyPosition.Any)
        {
            var isCurrentParameter = $"current={isCurrent.ToString().ToLower()}";

            string positionParameter = String.Empty;
            switch (position)
            {
                case Deputy.DeputyPosition.GdMember: positionParameter = "Депутат%ГД"; break;
                case Deputy.DeputyPosition.SfMember: positionParameter = "Член%СФ"; break;
            }

            var responseString=await _service.GetResponseFromApi("deputies", new[] { isCurrentParameter, positionParameter });
            return JsonConvert.DeserializeObject<List<Deputy>>(responseString);

            
        }
    }
}
