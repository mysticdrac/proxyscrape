using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
namespace proxyform
{
    internal class RequestState//Disposable
    {
        const int BufferSize = 8192;
        internal StringBuilder RequestData;
        internal byte[] BufferRead;
        internal WebRequest Request;
        internal Stream ResponseStream;
        // Create Decoder for appropriate enconding type.
        internal Decoder StreamDecode;
        //bool disposed;
        public RequestState()
        {
            BufferRead = new byte[BufferSize];
            RequestData = new StringBuilder(String.Empty);
            Request = null;
            ResponseStream = null;
            StreamDecode = Encoding.UTF8.GetDecoder();
        }
      
    }
}
