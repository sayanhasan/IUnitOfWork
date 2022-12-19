using Deneme.DAL.Base;
using Deneme.DAL.Base.AppDBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deneme.Project.Base
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        private UnitWorker _worker;
        protected UnitWorker Worker
        {
            get
            {
                return _worker ?? (_worker = new UnitWorker(new DenemeDbContext()));
            }
            private set
            {
                _worker = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && Worker != null)
            {
                Worker.Dispose();
                Worker = null;
            }
        }
       
    }
}
