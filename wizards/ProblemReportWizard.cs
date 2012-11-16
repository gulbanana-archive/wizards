using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace wizards
{
    class ProblemReportWizard : Wizard
    {
        private UserDetailsPage user;
        private ProblemDetailsPage problem;
        private SummaryPage summary;

        public ProblemReportWizard() : base(
            "Problem Report Wizard", 
            new IPageModel[] { 
                new UserDetailsPage(),
                new ProblemDetailsPage(),
                new SummaryPage()
            })
        {
            user = (UserDetailsPage)pages[0];
            problem = (ProblemDetailsPage)pages[1];
            summary = (SummaryPage)pages[2];
        }
    }
}
