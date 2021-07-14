using System;
using System.Net;
using System.Net.Http;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace SentinelConnector
{
    public class RequestData 
    {
        public HttpClient httpClient;
        public HttpResponseMessage httpClientResponse;
        public string httpClientResponseStr;
        public string httpClientResponseStatus;

        public RequestData(HttpClient newClient = null, HttpResponseMessage newResponse = null, string newResponseStr = null, string newResponseStatus = null) 
        {
            httpClient = newClient;
            httpClientResponse = newResponse;
            httpClientResponseStr = newResponseStr;
            httpClientResponseStatus = newResponseStatus;
        }
    }

    public class SentinelEMSClass
    {
        private struct currentRequest
        {
            public string key;
            public string value;
        }

        private string emsUrl;
        private string connectionType;
        private string hostName;
        private string port;
        private string startDir;
        private string emsVersion;
        private string requestType;
        private currentRequest cRequest;

        public SentinelEMSClass(string url)
        {
            string tmpUrl = url.Replace(":", "/");
            tmpUrl = tmpUrl.Replace("///", "/");
            string[] tmpMass = tmpUrl.Split('/');

            connectionType = tmpMass[0];
            hostName = tmpMass[1];
            port = tmpMass[2];
            startDir = tmpMass[3];
            emsVersion = tmpMass[4];
            requestType = tmpMass[5];

            emsUrl = connectionType + "://" + hostName + ":" + port + "/" + startDir + "/" + emsVersion + "/" + requestType + "/";
        }

        public string SayHello()
        {
            return "Hi Man!";
        }

        private string UrlBuilder(string reqSubStr) 
        {
            string fullUrl = "";

            fullUrl = emsUrl + reqSubStr;

            return fullUrl;
        }

        public RequestData GetRequest(string rString, HttpMethod method, KeyValuePair<string, string> rData = new KeyValuePair<string, string>(), RequestData client = null)
        {
            string fullRequestUrl = UrlBuilder(rString);
            var patterns = new[] { 
                @"login.ws",
                @"loginByProductKey.ws",
                @"customer.ws",
                @"activation/target.ws",
                @"customer/[0-9]+.ws",
                @"productKey/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}.ws",
                @"productKey/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}/activation.ws"
            };

            Regex regex;
            cRequest = new currentRequest();

            foreach (string p in patterns) {
                regex = new Regex(p);

                if (regex.IsMatch(rString)) {
                    if (p.Contains("activation.ws")) {
                        cRequest.key = "activation.ws";
                        cRequest.value = rString.Split('/')[1];
                    } else if (p.Contains("target.ws")) {
                        cRequest.key = "target.ws";
                        cRequest.value = (rString.Contains("/")) ? rString.Split('/')[1] : rString;
                    } else {
                        cRequest.key = (p.Contains("/")) ? p.Split('/')[0] : p;
                        cRequest.value = (rString.Contains("/")) ? rString.Split('/')[1] : rString;
                    }
                    break;
                }
            }

            if (client == null)
            {
                client = new RequestData(null, new HttpResponseMessage(), "", "");
            }

            switch (cRequest.key)
            {
                case "login.ws":
                    try
                    {
                        client.httpClient = new HttpClient();

                        var content = new StringContent(rData.Value, Encoding.UTF8, "application/xml");
                        client.httpClientResponse = client.httpClient.PostAsync(fullRequestUrl, content).Result;
                        client.httpClientResponseStr = client.httpClientResponse.Content.ReadAsStringAsync().Result;
                        client.httpClientResponseStatus = client.httpClientResponse.StatusCode.ToString();
                    }
                    catch (System.AggregateException e)
                    {
                        client.httpClientResponseStatus += e.InnerException.InnerException.Message;
                    }
                    catch (HttpRequestException hE)
                    {
                        client.httpClientResponseStatus += hE.Message;
                    }
                    break;

                case "loginByProductKey.ws":
                    try
                    {
                        client.httpClient = new HttpClient();

                        var content = new FormUrlEncodedContent(new[] { rData });
                        client.httpClientResponse = client.httpClient.PostAsync(fullRequestUrl, content).Result;
                        client.httpClientResponseStr = client.httpClientResponse.Content.ReadAsStringAsync().Result;
                        client.httpClientResponseStatus = client.httpClientResponse.StatusCode.ToString();
                    }
                    catch (System.AggregateException e)
                    {

                        client.httpClientResponseStatus += e.InnerException.InnerException.Message;

                    }
                    catch (HttpRequestException hE)
                    {
                        client.httpClientResponseStatus += hE.Message;
                    }
                    break;

                case "customer.ws":
                    if (client != null && client.httpClient != null)
                    {
                        if (client.httpClientResponseStatus == "OK")
                        {
                            try
                            {
                                var content = new StringContent(rData.Value, Encoding.UTF8, "application/xml");
                                client.httpClientResponse = client.httpClient.PutAsync(fullRequestUrl, content).Result;
                                client.httpClientResponseStr = client.httpClientResponse.Content.ReadAsStringAsync().Result;
                                client.httpClientResponseStatus = client.httpClientResponse.StatusCode.ToString();
                            }
                            catch (System.AggregateException e)
                            {
                                client.httpClientResponseStatus += e.InnerException.InnerException.Message + " | in customer create request by PK after login by PK.";
                            }
                            catch (HttpRequestException hE)
                            {
                                client.httpClientResponseStatus += hE.Message + " | in customer create request by PK after login by PK.";
                            }
                        }
                    }
                    else
                    {
                        client.httpClientResponseStatus = "Not set HttpClient instance.";
                    }
                    break;

                case "productKey":
                    if (client != null && client.httpClient != null)
                    {
                        if (client.httpClientResponseStatus == "OK")
                        {
                            try
                            {
                                if (method == HttpMethod.Get) {
                                    client.httpClientResponse = client.httpClient.GetAsync(fullRequestUrl).Result;
                                } else if (method == HttpMethod.Post) {
                                    var content = new StringContent(rData.Value, Encoding.UTF8, "application/xml");
                                    client.httpClientResponse = client.httpClient.PostAsync(fullRequestUrl, content).Result;
                                }

                                client.httpClientResponseStr = client.httpClientResponse.Content.ReadAsStringAsync().Result;
                                client.httpClientResponseStatus = client.httpClientResponse.StatusCode.ToString();

                                if (client.httpClientResponseStatus == "OK" && method == HttpMethod.Get)
                                {
                                    XDocument tmpPKInfo = XDocument.Parse(client.httpClientResponseStr);
                                    string tmpResponseStr = "";

                                    if (!string.IsNullOrEmpty(tmpPKInfo.Root.Element("customerId").Value))
                                    {
                                        tmpResponseStr = GetRequest("customer/" + tmpPKInfo.Root.Element("customerId").Value + ".ws", HttpMethod.Get, new KeyValuePair<string, string>(null, null), new RequestData(client.httpClient, client.httpClientResponse, client.httpClientResponseStr, client.httpClientResponseStatus)).httpClientResponseStr;

                                        if (!string.IsNullOrEmpty(tmpResponseStr))
                                        {
                                            client.httpClientResponseStr = client.httpClientResponseStr.Replace("<customerId>" + tmpPKInfo.Root.Element("customerId").Value + "</customerId>", "<customerId>" + tmpPKInfo.Root.Element("customerId").Value + "</customerId>" + "<customerEmail>" + tmpResponseStr + "</customerEmail>");
                                        }
                                    }
                                }
                            }
                            catch (System.AggregateException e)
                            {
                                client.httpClientResponseStatus += e.InnerException.InnerException.Message + " | in get info request after login by PK.";
                            }
                            catch (HttpRequestException hE)
                            {
                                client.httpClientResponseStatus += hE.Message + " | in get info request after login by PK.";
                            }
                        }
                    }
                    else
                    {
                        client.httpClientResponseStatus = "Not set HttpClient instance.";
                    }
                    break;

                case "activation.ws":
                    if (client != null && client.httpClient != null)
                    {
                        if (client.httpClientResponseStatus == "OK" || client.httpClientResponseStatus == "Created")
                        {
                            try
                            {
                                var content = new StringContent(rData.Value, Encoding.UTF8, "application/xml");
                                client.httpClientResponse = client.httpClient.PostAsync(fullRequestUrl, content).Result;
                                client.httpClientResponseStr = client.httpClientResponse.Content.ReadAsStringAsync().Result;
                                client.httpClientResponseStatus = client.httpClientResponse.StatusCode.ToString();
                            }
                            catch (System.AggregateException e)
                            {
                                client.httpClientResponseStatus += e.InnerException.InnerException.Message + " | in activate request after login by PK.";
                            }
                            catch (HttpRequestException hE)
                            {
                                client.httpClientResponseStatus += hE.Message + " | in activate request after login by PK.";
                            }
                        }
                    }
                    else
                    {
                        client.httpClientResponseStatus = "Not set HttpClient instance.";
                    }
                    break;

                case "target.ws":
                    try {
                        client.httpClient = new HttpClient();

                        var content = new StringContent(rData.Value, Encoding.UTF8, "application/xml");
                        client.httpClientResponse = client.httpClient.PostAsync(fullRequestUrl, content).Result;
                        client.httpClientResponseStr = client.httpClientResponse.Content.ReadAsStringAsync().Result;
                        client.httpClientResponseStatus = client.httpClientResponse.StatusCode.ToString();
                    }
                    catch (System.AggregateException e)
                    {
                        client.httpClientResponseStatus += e.InnerException.InnerException.Message + " | in get update by C2V request.";
                    }
                    catch (HttpRequestException hE)
                    {
                        client.httpClientResponseStatus += hE.Message + " | in get update by C2V request.";
                    }
                    break;

                case "customer":
                    if (client != null && client.httpClient != null) 
                    {
                        if (client.httpClientResponseStatus == "OK")
                        {
                            try
                            {
                                client.httpClientResponse = client.httpClient.GetAsync(fullRequestUrl).Result;
                                client.httpClientResponseStr = client.httpClientResponse.Content.ReadAsStringAsync().Result;
                                client.httpClientResponseStatus = client.httpClientResponse.StatusCode.ToString();

                                if (client.httpClientResponseStatus == "OK")
                                {
                                    XDocument tmpCustomerInfo = XDocument.Parse(client.httpClientResponseStr);

                                    client.httpClientResponseStr = tmpCustomerInfo.Root.Element("defaultContact").Element("emailId").Value;
                                }
                            }
                            catch (System.AggregateException e)
                            {
                                client.httpClientResponseStatus += e.InnerException.InnerException.Message + " | in get info request about customer ID after login by PK.";
                            }
                            catch (HttpRequestException hE)
                            {
                                client.httpClientResponseStatus += hE.Message + " | in get info request about customer ID after login by PK.";
                            }
                        }
                    } else {
                        client.httpClientResponseStatus = "Not set HttpClient instance.";
                    }
                    break;

                default:
                    // Передали в качестве запроса что-то невразумительное
                    client.httpClientResponseStatus = "Something whrong...";
                    break;
            }

            return client;
        }
    }
}
