using System;
using System.Threading;
using Autodesk.Revit.UI;

namespace HOK.MaterialGenerator
{
    public class MaterialGeneratorRequestHandlers : IExternalEventHandler
    {
        public MaterialGeneratorRequest Request { get; set; } = new MaterialGeneratorRequest();
        public object Arg1 { get; set; }

        public string GetName()
        {
            return "Material Generator External Event";
        }

        public void Execute(UIApplication app)
        {
            try
            {
                switch (Request.Take())
                {
                    case MaterialGeneratorRequestType.None:
                        {
                            return;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public class MaterialGeneratorRequest
    {
        private int _request = (int)MaterialGeneratorRequestType.None;

        public MaterialGeneratorRequestType Take()
        {
            return (MaterialGeneratorRequestType)Interlocked.Exchange(ref _request, (int)MaterialGeneratorRequestType.None);
        }

        public void Make(MaterialGeneratorRequestType request)
        {
            Interlocked.Exchange(ref _request, (int)request);
        }
    }

    public enum MaterialGeneratorRequestType
    {
        None
    }
}
