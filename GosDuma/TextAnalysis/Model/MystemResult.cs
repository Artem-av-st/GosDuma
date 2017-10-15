using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis.Model
{  

    public class MystemResult
    {
        public string Text { get; set; }
        public List<Analysis> AnalysisList { get; set; }

        public class Analysis
        {
            public string Lex { get; set; }
            public string Gr { get; set; }
        }
    }
}
