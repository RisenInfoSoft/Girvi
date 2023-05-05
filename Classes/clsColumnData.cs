using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girvi.Classes
{
    [Serializable()]
    public class clsColumnData
    {
        string fieldName;
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }
        object value;

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public bool isUnicode = false;
        public bool nullifBlank = false;
    }

    public class ColumnDataCollection : CollectionBase
    {
        public clsColumnData this[int index]
        {
            set
            {
                List[index] = value;
            }
            get
            {
                return (clsColumnData)List[index];
            }
        }

        public void Add(clsColumnData data)
        {
            InnerList.Add(data);
        }
        public void Add(string fieldName, object value)
        {
            Add(fieldName, value, false);
        }
        public void Add(string fieldName, object value, bool boolIsUnicode = false, bool nullifblank = false)
        {
            clsColumnData objColumnData = new clsColumnData();
            objColumnData.FieldName = fieldName;
            objColumnData.Value = value;
            objColumnData.nullifBlank = nullifblank;
            objColumnData.isUnicode = boolIsUnicode;
            Add(objColumnData);
        }

        public void Remove(clsColumnData data)
        {
            InnerList.Remove(data);
        }

        public void Remove(string fieldName)
        {
            for (int i = 0; i < InnerList.Count; i++)
            {
                clsColumnData data = (clsColumnData)InnerList[i];
                if (data.FieldName.ToLower() == fieldName.ToLower())
                {
                    Remove(data);
                    break;
                }
            }
        }


    }

    public class clsAddUpdateData
    {
        ColumnDataCollection columnDataCollection;

        public ColumnDataCollection ColumnDataCollection
        {
            get { return columnDataCollection; }
            set { columnDataCollection = value; }
        }
    }

}
