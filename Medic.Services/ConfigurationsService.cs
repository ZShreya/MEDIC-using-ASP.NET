﻿using Medic.Database;
using Medic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class ConfigurationsService
    {
        //public static ConfigurationsService ClassObject
        //{
        //    get
        //    {
        //        if (privateInMemoryObject == null) privateInMemoryObject = new ConfigurationsService();

        //        return privateInMemoryObject;
        //    }
        //}
        //private static ConfigurationsService privateInMemoryObject { get; set; }

        //private ConfigurationsService()
        //{
        //}

        #region Singleton
        public static ConfigurationsService Instance
        {
            get
            {
                if (instance == null) instance = new ConfigurationsService();

                return instance;
            }
        }
        private static ConfigurationsService instance { get; set; }

        private ConfigurationsService()
        {
        }
        #endregion

        public Config GetConfig(string Key)
        {
            using (var context = new MedicContext())
            {
                return context.Configurations.Find(Key);
            }
        }


        public int PageSize()
        {
            using (var context = new MedicContext())
            {
                var pageSizeConfig = context.Configurations.Find("PageSize");
                return pageSizeConfig != null ? int.Parse(pageSizeConfig.Value) : 10;
            }
        }

        public int ShopPageSize()
        {
            using (var context = new MedicContext())
            {
                var pageSizeConfig = context.Configurations.Find("ShopPageSize");
                return pageSizeConfig != null ? int.Parse(pageSizeConfig.Value) : 6;
            }
        }
    }
}
