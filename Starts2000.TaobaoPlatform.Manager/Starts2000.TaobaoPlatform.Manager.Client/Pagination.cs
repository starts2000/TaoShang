using System;
using System.ComponentModel;
using System.Windows.Forms;
using Starts2000.TaobaoPlatform.Manager.Client.Properties;

namespace Starts2000.TaoBao.Views
{
    public partial class Pagination : UserControl
    {
        int _pageSize = 15;
        int _count;
        int _pageIndex = 1;
        bool _needChangePageIndexText = true;
        readonly object _reloadEventObj = new object();

        public Pagination()
        {
            InitializeComponent();
            Init();
        }

        public event EventHandler Reload
        {
            add { base.Events.AddHandler(_reloadEventObj, value); }
            remove { base.Events.RemoveHandler(_reloadEventObj, value); }
        }

        [DefaultValue(15)]
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (_pageSize != value)
                {
                    _pageSize = value < 1 ? 1 : value;
                    CheckPageIndex();
                    lbPageSize.Text = _pageSize.ToString();
                }
            }
        }

        [DefaultValue(1)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                if (_pageIndex != value)
                {
                    if (value < 1)
                    {
                        _pageIndex = 1;
                    }
                    else
                    {
                        var pageNum = GetPageNum();
                        if (value > pageNum)
                        {
                            _pageIndex = pageNum;
                        }
                        else
                        {
                            _pageIndex = value;
                        }
                    }

                    if (_needChangePageIndexText)
                    {
                        stbPageIndex.Text = _pageIndex.ToString();
                    }

                    CheckEnable();
                    OnReload();
                }
            }
        }

        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int Count
        {
            get { return _count; }
            set
            {
                if (_count != value)
                {
                    _count = value < 0 ? 0 : value;

                    CheckPageIndex();
                    CheckEnable();
                    lbCount.Text = _count.ToString();
                    lbPageNum.Text = GetPageNum().ToString();
                }
            }
        }

        void Init()
        {
            lbFirst.Image = Resources.first;
            lbPrev.Image = Resources.prev;
            lbNext.Image = Resources.next;
            lbLast.Image = Resources.last;
            lbReload.Image = Resources.reload;

            lbPageSize.Text = "15";
            stbPageIndex.Text = "1";
            lbPageNum.Text = "1";
            CheckEnable();

            stbPageIndex.KeyUp += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.None)
                {
                    int pageIndex;
                    if (int.TryParse(stbPageIndex.Text.Trim(), out pageIndex))
                    {
                        _needChangePageIndexText = false;
                        PageIndex = pageIndex;
                        _needChangePageIndexText = true;
                    }
                }
            };

            lbFirst.Click += (sender, e) =>
            {
                PageIndex = 1;
            };

            lbLast.Click += (sender, e) =>
            {
                PageIndex = GetPageNum();
            };

            lbPrev.Click += (sender, e) =>
            {
                PageIndex -= 1;
            };

            lbNext.Click += (sender, e) =>
            {
                PageIndex += 1;
            };

            lbReload.Click += (sender, e) =>
            {
                OnReload();
            };
        }

        void OnReload()
        {
            var handler = base.Events[_reloadEventObj] as EventHandler;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        void CheckPageIndex()
        {
            var pageNum = GetPageNum();
            if (_pageIndex > pageNum)
            {
                PageIndex = pageNum;
            }
        }

        void CheckEnable()
        {
            lbFirst.Enabled = true;
            lbPrev.Enabled = true;
            lbNext.Enabled = true;
            lbLast.Enabled = true;

            if (_pageIndex == 1)
            {
                lbFirst.Enabled = false;
                lbPrev.Enabled = false;
            }

            if (_pageIndex == GetPageNum())
            {
                lbNext.Enabled = false;
                lbLast.Enabled = false;
            }
        }

        int GetPageNum()
        {
            var pageNum = (int)Math.Ceiling((double)_count / _pageSize);
            if(pageNum == 0)
            {
                pageNum = 1;
            }

            return pageNum;
        }
    }
}