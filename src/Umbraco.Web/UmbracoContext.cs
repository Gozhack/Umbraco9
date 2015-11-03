using System;
using System.IO;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.Dnx.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Umbraco.Web.Models;
using Umbraco.Web.PublishedCache;
using Umbraco.Web.Routing;

namespace Umbraco.Web
{
    /// <summary>
    /// Request based context
    /// </summary>
    public class UmbracoContext
    {
        public UmbracoContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            if (httpContextAccessor.HttpContext == null) throw new ArgumentNullException(nameof(httpContextAccessor) + ".HttpContext");
            if (httpContextAccessor.HttpContext.Request == null) throw new ArgumentNullException(nameof(httpContextAccessor) + ".HttpContext.Request");

            //TODO: Normally this is the 'cleaned umbraco url'
            RequestPath = _httpContextAccessor.HttpContext.Request.Path;
        }
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public void Initialize(PublishedContentRequest pcr)
        {
            if (Initialized) return;

            PublishedContentRequest = pcr;

            ////TODO: This name/etc. is temporary from old testing
            //AltTemplate = _httpContextAccessor.HttpContext.Request.Query["altTemplate"];
            //if (string.IsNullOrEmpty(AltTemplate))
            //{
            //    AltTemplate = "Umbraco";
            //}

            Initialized = true;
        }

        //public string AltTemplate { get; private set; }

        public string RequestPath { get; private set; }

        public bool Initialized { get; private set; }

        public bool HasContent => PublishedContent != null;

        public IPublishedContent PublishedContent => PublishedContentRequest?.PublishedContent;

        public PublishedContentRequest PublishedContentRequest { get; private set; }

    }
}