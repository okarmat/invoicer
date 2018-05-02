using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoicer.Infrastructure.Providers
{
    public interface ITextDataProvider
    {
        string GetTextData(string path);
    }
}