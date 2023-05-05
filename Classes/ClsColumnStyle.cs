using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Classes
{
    class ClsColumnStyle
    {
        private string _ColumnName;
        private int _ColumnPosition;
        private int _ColumnWidth;
        private bool _IsComboColumn;
        private bool _IsEditable;
        private bool _IsDecimalColumn;
        private DataGridViewContentAlignment _Alignment;
        private string _TableComboName;
        private Object _dt;
        public string ColumnName
        {
            set { _ColumnName = value; }
            get { return _ColumnName; }
        }
        public int ColumnPosition
        {
            set { _ColumnPosition = value; }
            get { return _ColumnPosition; }
        }
        public int ColumnWidth
        {
            set { _ColumnWidth = value; }
            get { return _ColumnWidth; }
        }
        public bool IsComboColumn
        {
            set { _IsComboColumn = value; }
            get { return _IsComboColumn; }
        }
        public bool IsDecimalColumn
        {
            set { _IsDecimalColumn = value; }
            get { return _IsDecimalColumn; }
        }
        public bool IsEditable
        {
            set { _IsEditable = value; }
            get { return _IsEditable; }
        }
        public DataGridViewContentAlignment Alignment
        {
            set { _Alignment = value; }
            get { return _Alignment; }
        }
        public string TableComboName
        {
            set { _TableComboName = value; }
            get { return _TableComboName; }
        }
        public Object dt
        {
            set { _dt = value; }
            get { return _dt; }
        }
        public ClsColumnStyle(string colName, int ColPos, int ColWidth, bool isComboColumn = false, bool isEditable = true, DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft, String tableComboName = null, Object dt = null, bool isDecimalColumn = false)
        {
            this.ColumnName = colName;
            this.ColumnPosition = ColPos;
            this.ColumnWidth = ColWidth;
            this.IsComboColumn = isComboColumn;
            this.IsDecimalColumn = isDecimalColumn;
            this.IsEditable = isEditable;
            this.Alignment = alignment;
            this.TableComboName = tableComboName;
            this.dt = dt;
        }
    }

}
