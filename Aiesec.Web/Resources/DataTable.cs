using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Aiesec.Web.Resources
{
    public class DataTable
    {
        private readonly IStringLocalizer localizer;
        public DataTable(IStringLocalizerFactory localizer)
        {
            this.localizer = localizer.Create(nameof(DataTable), new AssemblyName(typeof(DataTable).Assembly.FullName).Name);
        }

        public string LocalizedString(string key)
        {
            return localizer[key];
        }
        public string SearchTitle => localizer[nameof(SearchTitle)];
        public string ResetTitle => localizer[nameof(ResetTitle)];
        public string Showing => localizer[nameof(Showing)];
        public string From => localizer[nameof(From)];
        public string To => localizer[nameof(To)];
        public string Of => localizer[nameof(Of)];
        public string Entries => localizer[nameof(Entries)];
        public string First => localizer[nameof(First)];
        public string Last => localizer[nameof(Last)];
        public string NextPage => localizer[nameof(NextPage)];
        public string PreviousPage => localizer[nameof(PreviousPage)];
        public string Processing => localizer[nameof(Processing)];
        public string EmptyTable => localizer[nameof(EmptyTable)];
    }
}
