﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ExampleBase;

namespace PowerPointExamplesCS35
{
    public partial class FormMain : FormBase
    {
        public FormMain()
        {
            InitializeComponent();

            this.Text = "NetOffice PowerPoint Examples in C#";
            LoadExamples();

        }

        private void LoadExamples()
        {
            LoadExample(new Example01());
            LoadExample(new Example02());
            LoadExample(new Example03());
            LoadExample(new Example04());
            LoadExample(new Example05());
            LoadExample(new Example06());
            LoadExample(new Example07());
        }
    }
}
