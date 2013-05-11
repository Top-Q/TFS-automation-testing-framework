using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using TfsAutomation.Report;
using TfsAutomation.ListenerManager;
using YAXLib;
using TfsAutomation.SutHandling;

namespace TfsAutomation.Adaptors
{
    public class AdaptorsManager
    {
        protected readonly IReporter report = TestListenerManagerImpl.Instance;

        static readonly AdaptorsManager instance = new AdaptorsManager();

        private Dictionary<string,AdaptorImpl> adaptors = new Dictionary<string,AdaptorImpl>();

        static AdaptorsManager(){}

        AdaptorsManager() { }

        public static AdaptorsManager Instance
        {
            get { return instance; }
    
        }      

        public object GetAdaptor(string adaptorName, Type adaptorType, Stream sutFile = null)
        {

            if (adaptors.ContainsKey(adaptorName))
            {
                return adaptors[adaptorName];
            }
            var serializer = new YAXSerializer(adaptorType, YAXExceptionHandlingPolicies.ThrowErrorsOnly, YAXExceptionTypes.Error, YAXSerializationOptions.DontSerializeNullObjects);
            AdaptorImpl adaptor = null;
            try
            {
                string sutXml = null;
                if (sutFile != null)
                {
                    var stramReader = new StreamReader(sutFile);
                    sutXml = stramReader.ReadToEnd();
                }
                else
                {
                    sutXml = File.ReadAllText(SutManager.CurrentSut());
                }

                adaptor = (AdaptorImpl)serializer.Deserialize(sutXml);
            }
            catch (YAXBadlyFormedXML e)
            {
                report.Report("Failed to read sut file", e);
                return null;
            }
            adaptors.Add(adaptorName, adaptor);

            adaptor.Init();

            return adaptor;
        }
    }
}
