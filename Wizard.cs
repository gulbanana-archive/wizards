using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wizards
{
    abstract class Wizard
    {
        private readonly WizardWindow window;
        private readonly WizardModel frameVM;
        protected readonly List<IPageModel> pages;

        private bool hasPrevious;
        private bool hasNext;
        private int page;
        
        protected Wizard(string title, IEnumerable<IPageModel> wizardPages)
        {
            frameVM = new WizardModel(title, OnForward, MayForward, OnBack, MayBack);
            
            window = new WizardWindow();
            window.DataContext = frameVM;

            pages = wizardPages.ToList();
            page = 0;
            frameVM.Page = pages[page];

            hasPrevious = false;
            hasNext = page < pages.Count;
        }

        public void Run()
        {            
            window.ShowDialog();
        }
        
        private bool MayForward()
        {
            return hasNext;
        }

        private bool MayBack()
        {
            return hasPrevious;
        }

        private void OnForward()
        {
            if (hasNext)
            {
                ++page;
                hasPrevious = true;
                hasNext = page < pages.Count - 1;
                frameVM.Page = pages[page];
            }
            else
            {
                window.Hide();
            }
        }

        private void OnBack()
        {
            --page;
            hasNext = true;
            hasPrevious = page > 0;
            frameVM.Page = pages[page];
        }
    }
}
