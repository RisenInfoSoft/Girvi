using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girvi.Classes
{
    class TableNames
    {
        public static string Users = "users";
        public static string Party = "party";
        public static string Item = "itemmaster";
        public static string Bills = "bills";
        public static string PartyWiseValueSet = "partywisevaluset";
        public static string Tunch = "";
    }

    public static class Prefixes
    {
        public static string Party = "P";
        public static string Item = "I";
        public static string Bills = "GR";

        public static string getPrefix(string table)
        {
            if (table.Equals(TableNames.Party))
                return Party;
            if (table.Equals(TableNames.Item))
                return Item;
            if (table.Equals(TableNames.Bills))
                return Bills;
            return "";
        }
    }
}
