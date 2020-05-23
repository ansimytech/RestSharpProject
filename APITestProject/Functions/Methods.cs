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

namespace APITestProject.Functions
{
    public class Methods
    {
        public IRestResponse GetMethod(RestClient client)
        {
            CookieContainer _cookieJar = new CookieContainer();

            client.CookieContainer = _cookieJar;
            client.CookieContainer = _cookieJar;
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse PostMethod(RestClient client)
        {
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Cookie", "sails.sid=s%3AHDY04mn0DkoJqpe-cfWJ_HTPjUOMRRsX.WvuTdD5IMXhICJTaPAv5Za0i21bhjhVdWogwItCP0fY");
            request.AddParameter("text/plain,text/plain", testdata.methodtext.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;

        }

        public IRestResponse PostMethodParams(RestClient client)
        {
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "sails.sid=s%3AFwJRJeOJFKO3Jc5fDpXpkK8CQIzXo7yD.CB7wmK2lprHWCLv1DHYkbqBmX61Ov8A%2BLSR69QNCv7s");
            request.AddParameter("strange", testdata.postparam.ToString());
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse PutMethod(RestClient client)
        {
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Cookie", "sails.sid=s%3AFwJRJeOJFKO3Jc5fDpXpkK8CQIzXo7yD.CB7wmK2lprHWCLv1DHYkbqBmX61Ov8A%2BLSR69QNCv7s");
            request.AddParameter("text/plain", testdata.methodtext.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse DeleteMethod(RestClient client)
        {
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Cookie", "sails.sid=s%3ARX-ykedHB9qSSW4mQDiz2eMfdeeOdDpi.x8TSDvYLdhy3ZY4FkFJ%2BJmNlZrWA5PscJH%2Bu9e437Wc");
            request.AddParameter("text/plain", testdata.methodtext.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
