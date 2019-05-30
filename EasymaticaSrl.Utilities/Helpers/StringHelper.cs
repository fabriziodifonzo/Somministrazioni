using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaticaSrl.Utilities.Helpers
{
    public static class StringHelper
    {

        //
        // Check if string is empty and if so return null. If not return the original value.
        // The parameter can't be null.
        //
        public static string NullIfEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        //
        // If the value is null return empty. If the value is not null return the original value.
        //
        //
        public static string EmptyIfNull(string value) {

            if (value == null) {
                return string.Empty;
            }
            return value;
        }

        //
        // Check if string is empty and if so return null.
        // If not parse the value in int. Nate that no check in the paramater in really an int
        // so a FormatException can be thrown.
        // The parameter can't be null.
        //
        public static int? NullOrParseInt(string value)
        {

            if (string.IsNullOrEmpty(value)) {
                return null;
            }

            return Int32.Parse(value);

        }

        //
        // Check if string is empty and if so return an hyphen;
        // If the string is no empty return the original one.
        //
        public static string HyphenIfEmpty(string value) {

            if (string.IsNullOrEmpty(value)) {
                return GenericConstants.CHR_HYPEN;
            }
            return value;
        }


    }
}
