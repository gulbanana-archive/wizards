using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wizards
{
    class CalculationWizard : Wizard
    {
        private UserDetailsPage user;
        private CalculationPage input;
        private ResultPage output;

        public CalculationWizard() : base(
            "Calculation Request Wizard", 
            new IPageModel[] { 
                new UserDetailsPage(),
                new CalculationPage(),
                new ResultPage()
            })
        {
            user = (UserDetailsPage)pages[0];
            input = (CalculationPage)pages[1];
            output = (ResultPage)pages[2];
        }
    }
}
