using BE;
using PLWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PLWPF.ViewModel
{
    
    public class PdfRecommendedVM
    {
        public AssociationsModel associationModel;
        private ObservableCollection<RuleVM> _rules;

        public ObservableCollection<RuleVM> Rules
        {
            get { return _rules; }
            set { value=_rules; }
        }

        public PdfRecommendedVM()
        {
            associationModel = new AssociationsModel();


        }

    }
}
