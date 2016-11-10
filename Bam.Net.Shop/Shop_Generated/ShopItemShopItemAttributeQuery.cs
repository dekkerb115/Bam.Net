/*
	This file was generated and should not be modified directly
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Bam.Net.Data;

namespace Bam.Net.Shop
{
    public class ShopItemShopItemAttributeQuery: Query<ShopItemShopItemAttributeColumns, ShopItemShopItemAttribute>
    { 
		public ShopItemShopItemAttributeQuery(){}
		public ShopItemShopItemAttributeQuery(WhereDelegate<ShopItemShopItemAttributeColumns> where, OrderBy<ShopItemShopItemAttributeColumns> orderBy = null, Database db = null) : base(where, orderBy, db) { }
		public ShopItemShopItemAttributeQuery(Func<ShopItemShopItemAttributeColumns, QueryFilter<ShopItemShopItemAttributeColumns>> where, OrderBy<ShopItemShopItemAttributeColumns> orderBy = null, Database db = null) : base(where, orderBy, db) { }		
		public ShopItemShopItemAttributeQuery(Delegate where, Database db = null) : base(where, db) { }
		
        public static ShopItemShopItemAttributeQuery Where(WhereDelegate<ShopItemShopItemAttributeColumns> where)
        {
            return Where(where, null, null);
        }

        public static ShopItemShopItemAttributeQuery Where(WhereDelegate<ShopItemShopItemAttributeColumns> where, OrderBy<ShopItemShopItemAttributeColumns> orderBy = null, Database db = null)
        {
            return new ShopItemShopItemAttributeQuery(where, orderBy, db);
        }

		public ShopItemShopItemAttributeCollection Execute()
		{
			return new ShopItemShopItemAttributeCollection(this, true);
		}
    }
}