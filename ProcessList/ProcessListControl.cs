using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

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
            _listView.Columns.Add("Start time", 130);
            ResumeLayout();

            // It may be dangerous to enumerate processes here as this
            // code gets running not only in runtime, but also in Visual
            // Studio desing time. But we have already add protection
            // against Win32-to-Win64 access, so prey it'd suffice.
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

        public IProcessLister ProcessLister {
            get { return _processLister; }
            set
            {
                if (_processLister != value)
                {
                    _processLister = value;
                    RefreshProcesses();
                }
            }
        }

        public void RefreshProcesses()
        {
            // Don't know how it can happen, but let it be here.
            if (_listView == null)
                return;
            
            if (_processLister == null)
            {
                _listView.Items.Clear();
                return;
            }

            // Class System.Diagnostics.Process implements IDisposable, so we must
            // properly close all the object we've optained. Newer C# versions can
            // do it with a single 'using' statement; we have to use 'try'.
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
                            process.StartTime.ToString()
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
        private IProcessLister _processLister;
        private PropertyInfo _processSortKey;
        bool _processSortDescending;
    }
}
