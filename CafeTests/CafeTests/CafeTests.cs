using GoldBadgeChallenges._01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_CafeTest
{
    [TestClass]
    public class CafeTests
    {

        [TestMethod]
        public void Add()
        {
            Menu newContent = new Menu();
            MenuRepository repository = new
                MenuRepository();
            bool addResult = repository.Add(newContent);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetContents()
        {
            Menu testContent = new Menu(3, "Steak", "Amazing", "stuffs", 8.50m);
            MenuRepository repo = new MenuRepository();
            repo.Add(testContent);
            List<Menu> contents = repo.GetContents();
            bool directoryHasContent = contents.Contains(testContent);
            Assert.IsTrue(directoryHasContent);
        }
        private Menu _content;
        private MenuRepository _repo;
        [TestInitialize]
        public void Arrange()
        {
            _content = new Menu(3, "Steak", "Amazing", "stuffs", 8.50m);
            _repo = new MenuRepository();
            _repo.Add(_content);
        }
        public void GetContentByName()
        {
            Menu searchResult = _repo.GetContentByName("Steak");
            Assert.AreEqual(_content, searchResult);
        }
        public void Delete()
        {
            Menu foundContent = _repo.GetContentByName("steak");
            bool removeResult = _repo.Delete(foundContent);
            Assert.IsTrue(removeResult);
        }
    }
}
