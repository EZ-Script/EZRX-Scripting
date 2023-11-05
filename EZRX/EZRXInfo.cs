using System;
using System.Drawing;
using Grasshopper;
using Grasshopper.Kernel;

namespace EZRX
{
    public class EZRXInfo : GH_AssemblyInfo
    {
        public override string Name => "EZRX";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("46f42c05-117b-4e6a-993e-0461ab64c325");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}