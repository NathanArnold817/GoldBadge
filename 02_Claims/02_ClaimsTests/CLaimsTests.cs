using Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_ClaimsTests
{
    [TestClass]
    public class CLaimsTests
    {
        [TestMethod]
        public void Add()
        {
            Claim newContent = new Claim();
            ClaimRepository repository = new
                ClaimRepository();
            bool addResult = repository.Add(newContent);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void ViewAllClaims()
        {
            Claim testContent = new Claim(3, "kinda sucked", 300.00m, new DateTime(2021, 06,24), new DateTime (2021, 06,27),ClaimType.Car);
            ClaimRepository repo = new ClaimRepository();
            repo.Add(testContent);
             List<Claim> contents = repo.ViewAllClaims();
            bool directoryHasContent = contents.Contains(testContent);
            Assert.IsTrue(directoryHasContent);
        }
    }
}
