using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NLog;

namespace Day19Task
{
    class XmlWriter
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private IParser parser;
        private string[] records;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="records"></param>
        public XmlWriter(string[] records, IParser parser)
        {
            this.parser = parser;
            this.records = records;
        }

        /// <summary>
        /// Write to XML
        /// </summary>
        public void Write()
        {
            logger.Trace("Start Write");
            XDocument doc = new XDocument();
            XElement urlAdresses = new XElement("urlAdresses");
            foreach (string s in records)
            {
                if (s == string.Empty)
                {
                    continue;
                }

                string host = string.Empty;
                string[] parameters = new string[0];
                string[] segments = new string[0];
                try
                {

                    host = parser.GetHost(s);
                    parameters = parser.GetParameters(s);
                    segments = parser.GetSegments(s);
                }
                catch (FormatException)
                {
                    logger.Info("Url is not valid : {0}", s);
                    continue;
                }

                XElement urlAdress = new XElement("urlAdress");
                XElement urlHost = new XElement("host");
                XAttribute hostName = new XAttribute("name", host);

                List<XElement> list = new List<XElement>();

                foreach (string a in segments)
                {
                    if (a == string.Empty)
                    {
                        continue;
                    }

                    if (a.Split('?').Count() != 0)
                    {
                        list.Add(new XElement("segment", a.Split('?').First()));
                    }
                    else list.Add(new XElement("segment", a));
                }

                XElement urlUri = new XElement("uri", list);
                XElement urlParameters = new XElement("parameters");

                foreach (string b in parameters)
                {
                    if (b == string.Empty)
                    {
                        continue;
                    }

                    XElement parametr = new XElement("parametr");
                    parametr.Add(new XAttribute("key", b.Split('=').First()));
                    parametr.Add(new XAttribute("value", b.Split('=').Last()));
                    urlParameters.Add(parametr);
                }

                urlHost.Add(hostName);
                urlAdress.Add(urlHost);

                if (segments.Length > 1)
                {
                    urlAdress.Add(urlUri);
                }

                if (parameters.Length > 1)
                {
                    urlAdress.Add(urlParameters);
                }

                urlAdresses.Add(urlAdress);
            }
            doc.Add(urlAdresses);
            doc.Save("doc.xml");
            logger.Trace("End Write");
        }

    }
}
