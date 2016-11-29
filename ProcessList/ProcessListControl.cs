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
            _processLister = new ProcessLister();
            _listView = new ListView();

            SuspendLayout();
            _listView.Parent = this;
            _listView.Dock = DockStyle.Fill;
            _listView.View = View.Details;
            _listView.FullRowSelect = true;

            // Sorry for magic constants here, but all I want for
            // now is just go home and rest.
            _listView.Columns.Add("ID");
            _listView.Columns.Add("Process name", 200);
            _listView.Columns.Add("Start time", 100);
            ResumeLayout();

            //
            RefreshProcesses();
        }

        public PropertyInfo ProcessSortKey {
            get { return _processSortKey; }
            set {
                if (_processSortKey != value)
                {
                    _processSortKey = value;
                    RefreshProcesses();
                }
            }
        }

        public bool ProcessSortDescending {
            get { return _processSortDescending; }
            set
            {
                if (_processSortDescending != value)
                {
                    _processSortDescending = value;
                    RefreshProcesses();
                }
            }
        }

        public ProcessLister ProcessLister {
            get { return _processLister; }
            set { _processLister = value;
                  RefreshProcesses(); }
        }

        public void RefreshProcesses()
        {
            if (_listView == null)
                return;
            
            if (_processLister == null)
            {
                _listView.Items.Clear();
                return;
            }

            var processes = _processLister.ListProcesses();
            try {
                var sortedProcesses = ProcessListSorter.Sort(processes,
                                ProcessSortKey, ProcessSortDescending).ToList();

                _listView.BeginUpdate();
                _listView.Items.Clear();

                foreach (var process in sortedProcesses)
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
            finally {
                foreach (IDisposable process in processes)
                    process.Dispose();
            }
        }

        private ListView _listView;
        private ProcessLister _processLister;
        private PropertyInfo _processSortKey;
        bool _processSortDescending;
    }
}
