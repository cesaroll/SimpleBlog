﻿using System.Dynamic;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using SimpleBlog.Models;

namespace SimpleBlog
{
    public static class Database
    {
        private const string SessionKey = "SimpleBlog.Database.SesisonKey";

        private static ISessionFactory _sessionFactory;

        public static ISession Session
        {
            get{ return (ISession) HttpContext.Current.Items[SessionKey]; }
        }

        public static void Configure()
        {
            var config = new Configuration();

            //Configure the connection string
            config.Configure();

            //Add our mappings
            var mapper = new ModelMapper();
            mapper.AddMapping<UserMap>();
            mapper.AddMapping<RoleMap>();
            mapper.AddMapping<PostMap>();
            mapper.AddMapping<TagMap>();

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            //Create session factory
            _sessionFactory = config.BuildSessionFactory();
        }

        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        public static void CloseSession()
        {
            var session = HttpContext.Current.Items[SessionKey] as ISession;

            if (session != null)
                session.Close();

            HttpContext.Current.Items.Remove(SessionKey);
        }
    }
}