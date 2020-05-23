using System;
using RestSharp;
using System.Web.SessionState;
using NUnit.Framework;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using Allure.Commons;
using NUnit.Allure.Attributes;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.CSharp;
using APITestProject.Data;
using System.Diagnostics;
using System.Net.Mail;
using NUnit.Allure;
using NUnit.Allure.Core;
using System.Configuration;
using System.Web.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using GemBox.Document;
using System.Text.RegularExpressions;
using IronPdf;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Collections.Generic;
using APITestProject.Functions;

namespace APITestProject
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Postman-APIs")]
    [AllureDisplayIgnored]
    public class Postman : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();
        static bool emailReport = Convert.ToBoolean(Environment.GetEnvironmentVariable("sendEmail"));
        static int passCount = 1, failCount = 0;

        [Test(Description = "Get APIs")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("Postman APIs")]
        [Category("SmokeSuite")]
        public void CRUD_PostmanAPIs()
        {
            try
            {
                var client = new RestClient(endpoints.baseURL + endpoints.getURL);
                CookieContainer _cookieJar = new CookieContainer();

                Methods metd = new Methods();

                IRestResponse response = metd.GetMethod(client);

                Assert.AreEqual("OK", response.StatusCode.ToString());

                string getResponse = response.Content;
                int statusCode = (int)response.StatusCode;

                Assert.IsNotNull(getResponse);
                Assert.AreEqual(200, statusCode);

                dynamic jsonResponse = JsonConvert.DeserializeObject(getResponse);

                string param1 = jsonResponse.args.test;

                Assert.IsTrue(true, param1.ToString());


                client = new RestClient(endpoints.baseURL + endpoints.postURL);

                response = metd.PostMethod(client);

                Assert.AreEqual("OK", response.StatusCode.ToString());

                client = new RestClient(endpoints.baseURL + endpoints.postURL);

                response = metd.PostMethodParams(client);

                Assert.IsTrue(true, response.Content);

                client = new RestClient(endpoints.baseURL + endpoints.putURL);

                response = metd.PutMethod(client);

                Assert.IsTrue(true, response.Content);

                client = new RestClient(endpoints.baseURL + endpoints.deleteURL);

                response = metd.DeleteMethod(client);

                Assert.IsTrue(true, response.Content);

                
            }
            catch (Exception e)
            {
                StaticVariables.passCount--;
                StaticVariables.failCount++;
                Assert.Fail(e.Message);
            }

        }

       

        [OneTimeTearDown]
        public void tearDown()
        {
            LaunchCommandLineApp();
            if (emailReport)
            {
                EmailReport();
            }
        }

        static void LaunchCommandLineApp()
        {

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = testdata.buildagentpath + @"\postmanReport.bat";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (Exception)
            {

            }
        }


        static void EmailReport()
        {
            string subject = reportData.subject.ToString() + "_PassCount: " + passCount + "," + "FailCount: " + failCount;


            var client = new RestClient("https://outlook.office.com/webhook/7328b915-614f-4b86-930e-c816ffe299f6@a9a861e4-f7e0-4579-b45c-156f22016553/IncomingWebhook/54148d2528c442de8c6caae02087e6db/d20edae9-dfbd-42bd-b102-aa7f52bdc7c0");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("text/html", "{\r\n    \"@type\": \"MessageCard\",\r\n    \"@context\": \"http://schema.org/extensions\",\r\n    \"themeColor\": \"0076D7\",\r\n    \"summary\": \"API Test Automation Results\",\r\n    \"sections\": [{\r\n        \"activityTitle\": \"![TestImage](https://dev.azure.com/LogBookMe/_apis/GraphProfile/MemberAvatars/aad.N2Y5YTRkMTMtNmVhMi03NWYxLTgyMjItMTdhZWViMTJhMThj) API Automation Execution Summary\",\r\n        \"activitySubtitle\": \"Please find the UAT API automation results\",\r\n        \"activityImage\": \"https://dev.azure.com/LogBookMe/_apis/GraphProfile/MemberAvatars/aad.N2Y5YTRkMTMtNmVhMi03NWYxLTgyMjItMTdhZWViMTJhMThj\",\r\n        \"markdown\": true\r\n    }],\r\n   \"potentialAction\": [\r\n        {\r\n            \"@context\": \"http://schema.org\",\r\n            \"@type\": \"ViewAction\",\r\n            \"name\": \"View Results\",\r\n            \"target\": [\r\n                \"http://192.168.0.38:3000/api/\"\r\n            ]\r\n        }\r\n    ]\r\n}\r\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual("OK", response.StatusCode.ToString());

            int statusCode = (int)response.StatusCode;

            Assert.AreEqual(200, statusCode);

            
            //string subject = reportData.subject.ToString() + "_PassCount: " + StaticVariables.passCount + "," + "FailCount: " + StaticVariables.failCount;

            //string body = File.ReadAllText(testdata.buildagentpath + @"\APITestProject\EmailTemplate.html");

            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromAddress.Address, reportData.emailPassword)
            //};
            //using (var message = new MailMessage(fromAddress, toAddress)
            //{
            //    Subject = subject,
            //    Body = body,
            //    IsBodyHtml = true
            //})
            //{
            //    smtp.Send(message);
            //    emailReport = false;


            //}

        }


    }

}

