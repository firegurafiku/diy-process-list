﻿using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace ProcessList
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            uxSortKeyComboBox.SelectedIndex = 0;
        }

        private void RefreshProcessList(string propName, bool descending)
        {
            PropertyInfo propInfo = null;
            if (!string.IsNullOrEmpty(propName))
                propInfo = typeof(Process).GetProperty(propName);

            uxProcessList.ProcessSortKey = propInfo;
            uxProcessList.ProcessSortDescending = descending;
        }

        private void RefreshProcessListEvent(object sender, EventArgs e)
        {
            object selItem = uxSortKeyComboBox.SelectedItem;
            string propName = selItem != null
                    ? selItem.ToString()
                    : "";

            if (string.IsNullOrEmpty(propName) || propName.StartsWith("-"))
                propName = null;

            bool descending = uxDescendingCheckbox.Checked;
            RefreshProcessList(propName, descending);
        }

        private void RefreshTimerTickEvent(object sender, EventArgs e)
        {
            uxProcessList.RefreshProcesses();
        }

        private void uxExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
