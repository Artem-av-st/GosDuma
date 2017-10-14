using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GosDumaApiIntegration.Model
{
    public class Shorthand
    {
        public string Name { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public int QuestionCount { get; set; }
        public List<Meeting> Meetings { get; set; }

        public class Part
        {
            public int StartLine { get; set; }
            public int EndLine { get; set; }
            public string Type { get; set; }
            public List<string> Lines { get; set; }
            public List<object> Votes { get; set; }
        }

        public class Question
        {
            public string Name { get; set; }
            public string Stage { get; set; }
            public List<Part> Parts { get; set; }
        }

        public class Meeting
        {
            public DateTime Date { get; set; }
            public int Number { get; set; }
            public int MaxNumber { get; set; }
            public List<Question> Questions { get; set; }
        }
    }
   
        
}
