using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Data.Common;
using System.Linq;
using Bam.Net;
using Bam.Net.Data;
using Bam.Net.Data.Repositories;
using Newtonsoft.Json;
using Bam.Net.CoreServices.Data;
using Bam.Net.CoreServices.Data.Dao;

namespace Bam.Net.CoreServices.Data.Wrappers
{
	// generated
	[Serializable]
	public class ConfigurationSettingWrapper: Bam.Net.CoreServices.Data.ConfigurationSetting, IHasUpdatedXrefCollectionProperties
	{
		public ConfigurationSettingWrapper()
		{
			this.UpdatedXrefCollectionProperties = new Dictionary<string, PropertyInfo>();
		}

		public ConfigurationSettingWrapper(DaoRepository repository) : this()
		{
			this.Repository = repository;
		}

		[JsonIgnore]
		public DaoRepository Repository { get; set; }

		[JsonIgnore]
		public Dictionary<string, PropertyInfo> UpdatedXrefCollectionProperties { get; set; }

		protected void SetUpdatedXrefCollectionProperty(string propertyName, PropertyInfo correspondingProperty)
		{
			if(UpdatedXrefCollectionProperties != null && !UpdatedXrefCollectionProperties.ContainsKey(propertyName))
			{
				UpdatedXrefCollectionProperties?.Add(propertyName, correspondingProperty);				
			}
			else if(UpdatedXrefCollectionProperties != null)
			{
				UpdatedXrefCollectionProperties[propertyName] = correspondingProperty;				
			}
		}


Bam.Net.CoreServices.Data.Configuration _configuration;
		public override Bam.Net.CoreServices.Data.Configuration Configuration
		{
			get
			{
				if (_configuration == null)
				{
					_configuration = (Bam.Net.CoreServices.Data.Configuration)Repository.GetParentPropertyOfChild(this, typeof(Bam.Net.CoreServices.Data.Configuration));
				}
				return _configuration;
			}
			set
			{
				_configuration = value;
			}
		}

	}
	// -- generated
}																								
