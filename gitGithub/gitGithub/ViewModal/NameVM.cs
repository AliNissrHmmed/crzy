using gitGithub.Modal;
using gitGithub.srevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Text;
namespace gitGithub.ViewModal
{
     class NameVM : ssetvalue
    {
        public int x = 0;
        public NameVM()
        {
            Date = Datebase.GetAll().Result;
        }
         private List<OhMyGod>date ;

        public List<OhMyGod> Date
        {
            get => date;
            set { SetValue(ref date, value); }
        }


    }
}
