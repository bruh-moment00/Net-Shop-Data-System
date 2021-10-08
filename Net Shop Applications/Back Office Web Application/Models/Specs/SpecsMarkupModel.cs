using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_Web_Application.Models.SpecsMarkup
{
    public static class SpecsMarkupModel
    {
        public static string ReturnMarkedSpecs(this string fullSpecsString)
        {
            string tabledSpecsString = "";
            string[] trimmedString = fullSpecsString.Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach(string specString in trimmedString)
            {
                tabledSpecsString += String.Format("<tr>" +
                                                "<td><b>{0}:</b></td>" +
                                                "<td>{1}</td>" +
                                              "</tr>", specString.ReturnSpecName(), specString.ReturnSpecValue());
            }

            return tabledSpecsString;
        }

        private static string ReturnSpecName(this string specString)
        {
            string specName = specString.Substring(0, specString.IndexOf(':'));
            return specName;
        }

        private static string ReturnSpecValue(this string specString)
        {
            string spec = specString.Substring(specString.LastIndexOf(':') + 1);
            spec = spec.Trim(';');
            return spec;
        }
    }
}
