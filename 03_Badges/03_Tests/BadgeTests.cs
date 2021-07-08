using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Tests
{
    [TestClass]
    public class BadgeTests
    {
        [TestMethod]
        public void AddBadge()
        {
            Badges newContent = new Badges();
            BadgesRepository repository = new BadgesRepository();
            bool addResult = repository.AddBadge(newContent);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void View()
        {
            Badges testContent = new Badges(1151, new List<string>() { "B7", "A14" });
            BadgesRepository repo = new BadgesRepository();
            repo.AddBadge(testContent);
            List<Badges> contents = repo.View();
            bool directoryHasContent = contents.Contains(testContent);
            Assert.IsTrue(directoryHasContent);
        }
        
       
    }
}

