using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wizards
{
    class WizardModel : NotificationObject
    {
        private readonly string title;
        private readonly ICommand forwardCommand;
        private readonly DelegateCommand backCommand;
        private readonly Func<bool> forwardTest;

        public WizardModel(string wizardTitle, Action goForward, Func<bool> canGoForward, Action goBack, Func<bool> canGoBack)
        {
            title = wizardTitle;
            forwardCommand = new DelegateCommand(goForward);
            forwardTest = canGoForward;
            backCommand = new DelegateCommand(goBack, canGoBack);
        }

        public string Title 
        { 
            get { return title + ": " + page.Title; } 
        }

        public string ForwardOrDone
        {
            get
            {
                if (forwardTest())
                    return "Forward";
                else
                    return "Done";
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; RaisePropertyChanged(() => this.Status); }
        }

        private IPageModel page;
        public IPageModel Page
        {
            get { return page; }
            set 
            { 
                page = value; 
                RaisePropertyChanged(() => this.Page); 
                RaisePropertyChanged(() => this.Title);
                RaisePropertyChanged(() => this.ForwardOrDone);
                this.backCommand.RaiseCanExecuteChanged();
            }
        }

        public ICommand ForwardCommand { get { return forwardCommand; } }
        public ICommand BackCommand { get { return backCommand; } }
    }
}
