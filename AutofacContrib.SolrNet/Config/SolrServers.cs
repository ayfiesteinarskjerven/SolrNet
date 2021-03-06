﻿using System.Collections.Generic;
using System.Configuration;

namespace AutofacContrib.SolrNet.Config {
    /// <summary>
    /// Solr cores / instances configuration
    /// </summary>
    public class SolrServers : ConfigurationElementCollection, IEnumerable<ISolrServer> {
        /// <summary>
        /// Adds a new core / instance to the config
        /// </summary>
        /// <param name="configurationElement"></param>
        public void Add(SolrServerElement configurationElement) {
            base.BaseAdd(configurationElement);
        }

        protected override ConfigurationElement CreateNewElement() {
            return new SolrServerElement();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            var solrServerElement = (SolrServerElement) element;
            return solrServerElement.Url + solrServerElement.DocumentType;
        }

        IEnumerator<ISolrServer> IEnumerable<ISolrServer>.GetEnumerator()
        {
            foreach (SolrServerElement server in this)
            {
                yield return server;
            }
        }

        public override ConfigurationElementCollectionType CollectionType {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName {
            get { return "server"; }
        }
    }
}
