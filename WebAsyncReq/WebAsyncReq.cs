using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Diagnostics;
//using System.Security.Authentication;
namespace WebAsyncReq
{
    public class WebAsyncReq:MarshalByRefObject
    {
        ManualResetEvent allDone = new ManualResetEvent(false);
        const int BUFFER_SIZE = 8192;
        bool aborted = false;
        int DefaultTimeout = 30000;
        bool SSL = false;
        //string Cookies;
        //string url;
        //WebProxy proxy;
        CookieContainer Cookies;
        RequestState rstop;
        string _Postdata;
        bool _IsXMLRequest = false;
        bool _redirect = true;
      //  HttpWebRequest request;
        bool _byte=false;

        public bool SetSSL {

            set {
                SSL = true;
            }
        }
        public bool Getbyte
        {

            set
            {
                _byte = true;
            }
        }

        public CookieContainer SetCookies {
            set {
                Cookies = value;
            }
        
        }

        public int SetTimeOut {
            set {
                DefaultTimeout = value;
            
            }
        
        }
        public string SetPostData {
            set {
                _Postdata = value;
            }
        
        }

        public WebHeaderCollection GetResponseHeader {
            get {

                return rstop.Response.Headers; 
            }
        
        }

        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (error == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

          return false;
        }

        public bool IsXmlRequest {

            set {

                _IsXMLRequest = value;
            }
        }

        void Initialize(ref HttpWebRequest request) {
            if (SSL)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;

            }
            else
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            if (Cookies != null)
            {
                request.CookieContainer = Cookies;
                //request.Headers.Add("Cookie", Cookies);
            }
            if (!_redirect) {
                request.AllowAutoRedirect = false;
            }
            bool post = false;
            if (!string.IsNullOrEmpty(_Postdata))
            {

           
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                request.ContentLength = _Postdata.Length;
                post = true;
            }
            if (_IsXMLRequest) {
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                
            }
           
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*,;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Dragon/33.1.0.0 Chrome/33.0.1750.152 Safari/537.36";
            //request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.Timeout = 5000;
            request.ProtocolVersion = HttpVersion.Version11;
            request.ServicePoint.Expect100Continue = false;
            if (post) {
                request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
                allDone.WaitOne();
                allDone.Reset(); 
            }

        }

        public bool SetRedirect {
            set {
                _redirect = value;
            }
        }

        void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {

            //RequestState rs = (RequestState)asynchronousResult.AsyncState;
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            Stream postStream = request.EndGetRequestStream(asynchronousResult);

            byte[] byteArray = Encoding.UTF8.GetBytes(_Postdata);

            postStream.Write(byteArray, 0, _Postdata.Length);
            postStream.Close();
            allDone.Set();
           

        }

        public object Request(string url,WebProxy proxy)
        {
           
            object result = null;
            try
            {
                if (aborted)
                    throw new Exception();

                //url = AppDomain.CurrentDomain.GetData("Url") as string;
                //proxy = AppDomain.CurrentDomain.GetData("Proxy") as WebProxy;
                rstop = new RequestState();

               HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                
                request.Proxy = proxy;
                request.KeepAlive = false;              
                
                Initialize(ref request);

                rstop.Request = request;
              //  Debug.WriteLine(url);
                Stopwatch st = new Stopwatch();
                st.Start();
                IAsyncResult r = (IAsyncResult)request.BeginGetResponse(new AsyncCallback(RespCallback), rstop);
                ThreadPool.RegisterWaitForSingleObject(r.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), rstop.Request, DefaultTimeout, true); 
                allDone.WaitOne();
                st.Stop();
                Debug.WriteLine(st.ElapsedMilliseconds);
                if (!_byte)
                {
                    if (rstop.RequestData != null)
                    {
                        if (!rstop.RequestData.ToString().Trim().Equals(string.Empty))
                        {

                            result = rstop.RequestData.ToString();

                        }
                    }
                }
                else
                {
                    if (rstop.RequestByte != null)
                    {

                        result = rstop.RequestByte;
                    }

                }
                if (rstop.ResponseStream != null)
                {
                    rstop.ResponseStream.Close();
                    Thread.Sleep(100);
                    //Debug.WriteLine("response stream closed "+url);
                }
                

            }
            catch (Exception)
            {

                throw new Exception();
            }

            return result ;
        }
        
        void RespCallback(IAsyncResult ar)
        {
            RequestState rs = null;
            IAsyncResult iarRead = null;
            WebResponse resp = null;
            Stream ResponseStream = null;
            try
            {
                if (aborted)
                    throw new Exception();

                rs = (RequestState)ar.AsyncState;
                WebRequest req = rs.Request;
                try
                {
                    resp = req.EndGetResponse(ar);
                    ResponseStream = resp.GetResponseStream();
                    rs.ResponseStream = ResponseStream;
                    rs.Response = resp;
                    
                    
                    iarRead = ResponseStream.BeginRead(rs.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), rs);
                    
                    
                }
                catch (System.Net.Sockets.SocketException)
                {
                    throw new Exception();
                }
                catch (System.Exception)
                {
                    throw new Exception();
                }
            }
            catch (System.Exception)
            {

                if (!allDone.WaitOne(0))
                {
                    if (rs != null)
                    {
                        rs.RequestData = null;
                    }
                    allDone.Set();
                }

            }

        }
        
        void ReadCallBack(IAsyncResult asyncResult)
        {
            Stream responseStream = null;
            IAsyncResult ar = null;
            try
            {
                if (aborted)
                    throw new Exception();

                RequestState rs = (RequestState)asyncResult.AsyncState;
                responseStream = rs.ResponseStream;
                
                int read = responseStream.EndRead(asyncResult);

                if (read > 0)
                {
                    if (!_byte)
                    {
                        char[] charBuffer = new Char[BUFFER_SIZE];
                        int len = rs.StreamDecode.GetChars(rs.BufferRead, 0, read, charBuffer, 0);
                        string str = new String(charBuffer, 0, len);
                        rs.RequestData.Append(Encoding.ASCII.GetString(rs.BufferRead, 0, read));
                    }
                    else {

                        rs.RequestByte.Write(rs.BufferRead,0,read);
                    }
                    
                    try
                    {
                        ar = responseStream.BeginRead(rs.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), rs);
                    }
                    catch (System.Net.Sockets.SocketException)
                    {
                        throw new Exception();
                    }
                    catch (System.Exception)
                    {

                        throw new Exception();


                    }
                }
                else
                {

                    responseStream.Close();
                    allDone.Set();
                }

            }
            catch (System.Exception)
            {
                if (responseStream != null)
                    responseStream.Close();

                allDone.Set();

            }
            return;
        }
        
        public void Abort()
        {
            aborted = true;

        }

        void TimeoutCallback(object state, bool timedOut)
        {
            if (timedOut || aborted)
            {
                HttpWebRequest request = state as HttpWebRequest;
                if (request != null)
                {
                    request.Abort();
                }
            }
        }
    }
}
