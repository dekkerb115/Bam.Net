using System;
using System.Collections.Generic;
using System.Text;
using Bam.Net.Data;

namespace Bam.Net.CoreServices.ApplicationRegistration.Dao
{
    public class HostDomainColumns: QueryFilter<HostDomainColumns>, IFilterToken
    {
        public HostDomainColumns() { }
        public HostDomainColumns(string columnName)
            : base(columnName)
        { }
		
		public HostDomainColumns KeyColumn
		{
			get
			{
				return new HostDomainColumns("Id");
			}
		}	

				
        public HostDomainColumns Id
        {
            get
            {
                return new HostDomainColumns("Id");
            }
        }
        public HostDomainColumns Uuid
        {
            get
            {
                return new HostDomainColumns("Uuid");
            }
        }
        public HostDomainColumns Cuid
        {
            get
            {
                return new HostDomainColumns("Cuid");
            }
        }
        public HostDomainColumns DomainName
        {
            get
            {
                return new HostDomainColumns("DomainName");
            }
        }
        public HostDomainColumns Authorized
        {
            get
            {
                return new HostDomainColumns("Authorized");
            }
        }
        public HostDomainColumns Created
        {
            get
            {
                return new HostDomainColumns("Created");
            }
        }
        public HostDomainColumns CreatedBy
        {
            get
            {
                return new HostDomainColumns("CreatedBy");
            }
        }
        public HostDomainColumns ModifiedBy
        {
            get
            {
                return new HostDomainColumns("ModifiedBy");
            }
        }
        public HostDomainColumns Modified
        {
            get
            {
                return new HostDomainColumns("Modified");
            }
        }
        public HostDomainColumns Deleted
        {
            get
            {
                return new HostDomainColumns("Deleted");
            }
        }


		protected internal Type TableType
		{
			get
			{
				return typeof(HostDomain);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}