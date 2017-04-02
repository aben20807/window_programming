using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2
{
    public partial class FormSupervisor : Form
    {
        private FormSignin _parent;
        public FormSupervisor()
        {
            InitializeComponent();
        }
        public FormSupervisor(FormSignin parent)
        {
            InitializeComponent();
            this._parent = parent;
        }
        public FormSignin getParent()
        {
            return this._parent;
        }
    }
}
