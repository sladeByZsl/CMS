using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;

using NUnit.Framework;

namespace NHibernateTest
{
    [TestFixture]
    public class NHibernateInit
    {
        [Test]
        public void InitTest()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory()) { }
        }
    }
}
