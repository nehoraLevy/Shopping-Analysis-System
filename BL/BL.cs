﻿using BL.associationRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    internal class BL
    {
        public IAssociationProductAnalysis AssosiationProductsAnalysis { get; }
        public IDataManagement DataManagement { get; }
        public IGraphManagement GraphManagement { get; }


        public BL ()
        {

            AssosiationProductsAnalysis = new AssociationProductAnalysis();

            GraphManagement = new GraphManagement();

            DataManagement = new DataManagement();

        }
    }
}
