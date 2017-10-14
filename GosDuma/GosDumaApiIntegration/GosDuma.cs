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

        #region Constructor
        public GosDuma(string apiToken, string appToken)
        {
            _apiToken = apiToken;
            _appToken = appToken;
            _service = JsonServices.GetInstance(_apiToken, _appToken);
        }
        #endregion Constructor

        /// <summary>
        /// Returns list of deputies
        /// </summary>
        public async Task<List<Deputy>> GetDeputiesList(bool isCurrent = true, Deputy.DeputyPosition position = Deputy.DeputyPosition.Any)
        {
            var parametresDictionary = new Dictionary<string, string>
            {
                { "current", isCurrent.ToString().ToLower()}
            }; 

            var positionValue = String.Empty;
            switch (position)
            {
                case Deputy.DeputyPosition.GdMember: positionValue = "position=Депутат%20ГД"; break;
                case Deputy.DeputyPosition.SfMember: positionValue = "position=Член%20СФ"; break;
            }

            if(!String.IsNullOrEmpty(positionValue))
            {
                parametresDictionary.Add("position", positionValue);
            }

            

            return await _service.GetResponseFromApi<List<Deputy>>("deputies", parametresDictionary);
                        
        }

        public async Task<string> GetShorthandRecordByDeputyId(int deputyId, DateTime dateFrom, DateTime dateTo)
        {
            
            var parametresDictionary = new Dictionary<string,string>
            {
                // Limit is a number of shorthands on one page (20 is max).
                { "limit","20" },
                { "page", "1" },
                { "dateFrom", dateFrom.ToString("yyyy-MM-dd")},
                { "dateTo", dateTo.ToString("yyyy-MM-dd")}
            };
            
            var shorthand = await _service.GetResponseFromApi<Shorthand>($"transcriptDeputy/{deputyId}", parametresDictionary);

            var pagesCount = Math.Ceiling((decimal)shorthand.TotalCount / 20);

            for (int page=2; page<=pagesCount; page++)
            {
                parametresDictionary["page"] = page.ToString();
                var shorthandPartial = await _service.GetResponseFromApi<Shorthand>($"transcriptDeputy/{deputyId}", parametresDictionary);
                if (shorthandPartial.Meetings.First().Date < dateFrom) break;
                shorthand.Meetings.AddRange(shorthandPartial.Meetings);
            }
            
            return String.Join(" ",
                (from meeting in shorthand.Meetings
                    from question in meeting.Questions
                        from part in question.Parts
                            from line in part.Lines
                            select line));
            
        }
                
    }
}
