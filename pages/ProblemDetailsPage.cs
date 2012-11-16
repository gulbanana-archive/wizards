using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wizards
{
    class ProblemDetailsPage : IPageModel
    {
        public string Title { get { return "Problem Details"; } }
        public string Details { get; set; }
    }
}
