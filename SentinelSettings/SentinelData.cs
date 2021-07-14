using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;

namespace SentinelSettings
{
    public class SentinelData
    {
        #region Init param's
        public static Dictionary<KeyValuePair<string, string>, string> vendorCode = new Dictionary<KeyValuePair<string, string>, string>() {
            { new KeyValuePair<string, string> ("DEMOMA", "37515"), "AzIceaqfA1hX5wS+M8cGnYh5ceevUnOZIzJBbXFD6dgf3tBkb9cvUF/Tkd/iKu2fsg9wAysYKw7RMAsV" +
                        "vIp4KcXle/v1RaXrLVnNBJ2H2DmrbUMOZbQUFXe698qmJsqNpLXRA367xpZ54i8kC5DTXwDhfxWTOZrB" +
                        "rh5sRKHcoVLumztIQjgWh37AzmSd1bLOfUGI0xjAL9zJWO3fRaeB0NS2KlmoKaVT5Y04zZEc06waU2r6" +
                        "AU2Dc4uipJqJmObqKM+tfNKAS0rZr5IudRiC7pUwnmtaHRe5fgSI8M7yvypvm+13Wm4Gwd4VnYiZvSxf" +
                        "8ImN3ZOG9wEzfyMIlH2+rKPUVHI+igsqla0Wd9m7ZUR9vFotj1uYV0OzG7hX0+huN2E/IdgLDjbiapj1" +
                        "e2fKHrMmGFaIvI6xzzJIQJF9GiRZ7+0jNFLKSyzX/K3JAyFrIPObfwM+y+zAgE1sWcZ1YnuBhICyRHBh" +
                        "aJDKIZL8MywrEfB2yF+R3k9wFG1oN48gSLyfrfEKuB/qgNp+BeTruWUk0AwRE9XVMUuRbjpxa4YA67SK" +
                        "unFEgFGgUfHBeHJTivvUl0u4Dki1UKAT973P+nXy2O0u239If/kRpNUVhMg8kpk7s8i6Arp7l/705/bL" +
                        "Cx4kN5hHHSXIqkiG9tHdeNV8VYo5+72hgaCx3/uVoVLmtvxbOIvo120uTJbuLVTvT8KtsOlb3DxwUrwL" +
                        "zaEMoAQAFk6Q9bNipHxfkRQER4kR7IYTMzSoW5mxh3H9O8Ge5BqVeYMEW36q9wnOYfxOLNw6yQMf8f9s" +
                        "JN4KhZty02xm707S7VEfJJ1KNq7b5pP/3RjE0IKtB2gE6vAPRvRLzEohu0m7q1aUp8wAvSiqjZy7FLaT" +
                        "tLEApXYvLvz6PEJdj4TegCZugj7c8bIOEqLXmloZ6EgVnjQ7/ttys7VFITB3mazzFiyQuKf4J6+b/a/Y" }
        };

        public static XDocument errors = new XDocument();

        public static string appSentinelUpCallData = "<upclient>" +
                                                         "<param>" +
                                                             "<key>-url</key>" +
                                                             "<value>up.sentinelcloud.com</value>" +
                                                         "</param>" +
                                                         "<param>" +
                                                             "<key>-k</key>" +
                                                             "<value>eafe87d22cc2a49793276f4141c0ebb0</value>" +
                                                         "</param>" +
                                                         "<param>" +
                                                             "<key>-pc</key>" +
                                                             "<value>1337e5b0-fd2d-4018-8a13-a921bcbfb5d2</value>" +
                                                         "</param>" +
                                                         "<param>" +
                                                             "<key>-v</key>" +
                                                             "<value>v1</value>" +
                                                         "</param>" +
                                                         "<param>" +
                                                             "<key>-update</key>" +
                                                             "<value>-update</value>" +
                                                         "</param>" +
                                                         "<param>" +
                                                             "<key>-check</key>" +
                                                             "<value>-check</value>" +
                                                         "</param>" +
                                                         "<param>" +
                                                             "<key>-st</key>" +
                                                             "<value>-st</value>" +
                                                         "</param>" +
                                                         "<param>" +
                                                             "<key>-l</key>" +
                                                             "<value>ru</value>" +
                                                         "</param>" +
                                                         "<param>" +
                                                             "<key>-log</key>" +
                                                             "<value>update.log</value>" +
                                                         "</param>" +
                                                     "</upclient>";

        public static string keyScope = "<haspscope>" +
                                            "<feature>" +
                                                "<name>Accounting</name>" +
                                                "<id>1</id>" +
                                            "</feature>" +
                                            "<feature>" +
                                                "<name>Stock</name>" +
                                                "<id>2</id>" +
                                            "</feature>" +
                                            "<feature>" +
                                                "<name>Staff</name>" +
                                                "<id>3</id>" +
                                            "</feature>" +
                                        "</haspscope>";

        public static string keyScopeXsd = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                                            "<xs:schema attributeFormDefault=\"unqualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">" +
                                              "<xs:element name=\"haspscope\">" +
                                                "<xs:complexType>" +
                                                  "<xs:sequence>" +
                                                    "<xs:element maxOccurs=\"unbounded\" name=\"feature\">" +
                                                      "<xs:complexType>" +
                                                        "<xs:sequence>" +
                                                          "<xs:element name=\"name\" type=\"xs:string\"/>" +
                                                          "<xs:element name=\"id\" type=\"xs:string\"/>" +
                                                        "</xs:sequence>" +
                                                      "</xs:complexType>" +
                                                    "</xs:element>" +
                                                  "</xs:sequence>" +
                                                "</xs:complexType>" +
                                              "</xs:element>" +
                                            "</xs:schema>";

        public static string keyFormat = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                            "<haspformat root=\"hasp_info\">" +
                                                "<hasp>" +
                                                    "<element name=\"id\"/>" +
                                                    "<element name=\"type\"/>" +
                                                    "<element name=\"detachable\"/>" +  
                                                    "<element name=\"attached\"/>" + 
                                                    "<element name=\"recipient\"/>" +  
                                                    "<element name=\"version\"/>" +
                                                    "<element name=\"hw_version\"/>" +
                                                    "<element name=\"key_model\"/>" +
                                                    "<element name=\"key_type\"/>" +
                                                    "<element name=\"form_factor\"/>" +
                                                    "<element name=\"hw_platform\"/>" +
                                                    "<element name=\"driverless\"/>" +
                                                    "<element name=\"fingerprint_change\"/>" +
                                                    "<element name=\"vclock_enabled\"/>" +
                                                    "<product>" +
                                                        "<element name=\"id\"/>" +
                                                        "<element name=\"name\"/>" +
                                                        "<feature>" +
                                                            "<element name=\"id\"/>" +
                                                            "<element name=\"name\"/>" +
                                                            "<element name=\"license\"/>" +
                                                            "<element name=\"locked\"/>" +
                                                        "</feature>" +
                                                    "</product>" +
                                                "</hasp>" +
                                            "</haspformat>";

        public string actionForDetach = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                               "<detach>" +
                                               "   <product id=\"{PRODUCT_ID}\">" +
                                               "      <duration>{NUMBER_OF_SECONDS}</duration>" +
                                               "   </product>" +
                                               "</detach>";

        public string actionForCancelDetach = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                                     "<cancel>" +
                                                     "   <hasp id=\"{KEY_ID}\"/>" +
                                                     "</cancel>";

        public string scopeForLocal = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                                             "<haspscope>" +
                                             "    <license_manager hostname=\"localhost\" />" +
                                             "</haspscope>";

        public string scopeForNoLocal = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                                             "<haspscope>" +
                                             "    <license_manager hostname=\"~localhost\" />" +
                                             "</haspscope>";

        public string formatForGetId = "<haspformat root=\"location\">" +
                                              "   <license_manager>" +
                                              "      <attribute name=\"id\"/>" +
                                              "      <attribute name=\"time\"/>" +
                                              "      <element name=\"hostname\"/>" +
                                              "      <element name=\"version\"/>" +
                                              "      <element name=\"host_fingerprint\"/>" +
                                              "   </license_manager>" +
                                              "</haspformat>";

        public string scopeForSpecificKeyId = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                                                     "<haspscope>" +
                                                     "    <hasp id=\"{KEY_ID}\"/>" +
                                                     "</haspscope>";

        public string formatForGetAvailableLicenses = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                                                             "<haspformat root=\"hasp_info\">" +
                                                             "    <hasp>" +
                                                             "        <attribute name=\"id\" />" +
                                                             "        <attribute name=\"type\" />" +
                                                             "        <feature>" +
                                                             "            <attribute name=\"id\" />" +
                                                             "        </feature>" +
                                                             "    </hasp>" +
                                                             "</haspformat>";

        public string actionForAddIbaStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + 
                                                "<config>" + 
                                                    "<serveraddr>{IBA_STR}</serveraddr>" + 
                                                    "<writeconfig/>" + 
                                                "</config>";

        public static string emsUrl = "http://localhost:8080/ems/v78/ws";

        public static bool logIsEnabled = true;

        public static bool apiIsEnabled = true;

        public static bool newActMechanism = true;

        public static bool advancedDataIsEnabled = true;

        public static string portForTestConnection = "8080";

        public static string addressForTestConnection = "8.8.8.8"; // google

        public static bool enableInternetTest = true;

        public static string regExForValidatingPK = @"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}";

        public string accProtocol = "http";

        public string accHost = "127.0.0.1";

        public string accPort = "1947";

        public string accPassword = "";

        public string urlForCancelDetachLicense = @"{PROTOCOL}://{HOST}:{PORT}/_int_/cancel2.html?haspid={KEY_ID}&vendorid={VENDOR_ID}&productid={PRODUCT_ID}";

        public string urlForAddIbaToAcc = @"{PROTOCOL}://{HOST}:{PORT}/";
        #endregion

        #region Constructor
        public SentinelData(string pathToAlp = null)
        {
            if (!String.IsNullOrEmpty(pathToAlp) && File.Exists(pathToAlp))
            {
                XDocument tmpAlp = XDocument.Load(pathToAlp);

                errors = XDocument.Parse(tmpAlp.Root.Element("ErrorCodes").ToString());
            }
            else
            {
                errors = null; //defaultErrors;
            }
        }
        #endregion

        #region Methods: ErrorMessageReplacer, CheckEmail
        public string ErrorMessageReplacer(string locale, string originalError)
        {
            string newErrorMessage = "";

            if (errors != null) {
                foreach (var elError in errors.Root.Elements("error"))
                {
                    foreach (var elLang in elError.Elements("language"))
                    {
                        //if (elLang.Attribute("type").Value.Contains("origin") && originalError.Contains(elLang.Value))
                        if (elLang.Attribute("type").Value.Contains("origin") && elLang.Value.Contains(originalError))
                        {
                            newErrorMessage = ((from el in elError.Elements() where ((string)el.Attribute("type").Value == "translate" && (string)el.Attribute("name").Value == locale) select el).Count() > 0) ? (from el in elError.Elements() where ((string)el.Attribute("type").Value == "translate" && (string)el.Attribute("name").Value == locale) select el).FirstOrDefault().Value : (from el in elError.Elements() where ((string)el.Attribute("type").Value == "translate" && (string)el.Attribute("name").Value == "en") select el).FirstOrDefault().Value;
                            return newErrorMessage;
                        }
                    }
                }
            }

            if (String.IsNullOrEmpty(newErrorMessage)) newErrorMessage = originalError;

            return newErrorMessage;
        }

        public bool CheckEmail(string s)
        {
            return ((s.Contains('@') && (s.Split('@')[1].Contains('.'))) ? true : false); 
        }
        #endregion
    }
}
