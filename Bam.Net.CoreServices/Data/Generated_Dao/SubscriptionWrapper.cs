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
	public class SubscriptionWrapper: Bam.Net.CoreServices.Data.Subscription, IHasUpdatedXrefCollectionProperties
	{
		public SubscriptionWrapper()
		{
			this.UpdatedXrefCollectionProperties = new Dictionary<string, PropertyInfo>();
		}

		public SubscriptionWrapper(DaoRepository repository) : this()
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


Bam.Net.CoreServices.Data.User _user;
		public override Bam.Net.CoreServices.Data.User User
		{
			get
			{
				if (_user == null)
				{
					_user = (Bam.Net.CoreServices.Data.User)Repository.GetParentPropertyOfChild(this, typeof(Bam.Net.CoreServices.Data.User));
				}
				return _user;
			}
			set
			{
				_user = value;
			}
		}

	}
	// -- generated
}																								
