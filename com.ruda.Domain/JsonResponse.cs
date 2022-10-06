using System;
using System.Collections.Generic;
using System.Text;

namespace com.ruda.Domain
{
    public class JsonResponse
    {
        public string action { get; set; }
        public jsonmeta meta { get; set; }
        public string error { get; set; }
        public object response { get; set; }

        public bool ShouldSerializeerror()
        {
            // don't serialize if property is null
            return (error != null);
        }
        public bool ShouldSerializeresponse()
        {
            // don't serialize if property is null
            return (response != null);
        }
    }
}
