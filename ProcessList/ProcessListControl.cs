using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace ProcessList
{
    public partial class ProcessListControl : Control
    {
        public ProcessListControl()
        {
            _listView = new ListView();
            _listView.Parent = this;
            _listView.Dock = DockStyle.Fill;
            _listView.View = View.Details;
            _listView.Columns.Add("ID");
            _listView.Columns.Add("Process name");
            _listView.Columns.Add("Start time");

            ProcessLister = new ProcessLister();

            // 
            PopulateItems();
        }

        public PropertyInfo ProcessSortKey { get; set; }

        public bool ProcessSortDescending { get; set; }

        public ProcessLister ProcessLister { get; set; }

        private void PopulateItems()
        {
            var processes = new List<Process>();
            if (ProcessLister != null)
                processes.AddRange(ProcessLister.ListProcesses());

            _listView.BeginUpdate();
            _listView.Items.Clear();
            foreach (var process in processes)
            {
                var cellTexts = new string[] {
                    process.Id.ToString(),
                    process.ProcessName,
                    process.StartTime.ToShortDateString(),
                };

                var item = new ListViewItem(cellTexts);
                _listView.Items.Add(item);
            }
            
            _listView.EndUpdate();

        }

        private ListView _listView;
    }
}
