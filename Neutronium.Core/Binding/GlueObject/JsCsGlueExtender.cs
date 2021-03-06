﻿using System.Collections.Generic;
using Neutronium.Core.WebBrowserEngine.JavascriptObject;
using System;

namespace Neutronium.Core.Binding.GlueObject
{
    public static class JsCsGlueExtender
    {
        public static bool IsBasic(this IJsCsGlue @this)
        {
            return (@this.Type == JsCsGlueType.Basic);
        }

        public static void VisitDescendantsSafe(this IJsCsGlue @this, Func<IJsCsGlue, bool> visit)
        {
            var res = new HashSet<IJsCsGlue>();
            Func<IJsCsGlue, bool> newVisitor = (glue) => (res.Add(glue)) && visit(glue);
            @this.VisitDescendants(newVisitor);
        }

        public static IJavascriptObject GetJsSessionValue(this IJsCsGlue @this)
        {
            var inj = @this as IJsCsMappedBridge;
            return (inj != null) ? inj.CachableJsValue : @this.JsValue;
        }
    }
}
