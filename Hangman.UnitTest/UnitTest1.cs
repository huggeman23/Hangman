using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Hangman;

namespace Hangman.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void wrongLetter()
        {
            var prog = new Program();
            prog.WordSet(0);
            prog.guessLetter("p");
            int t=prog.Try;
            Assert.AreEqual(9,t);
        }
        [TestMethod]
        public void rightLetter()
        {
            var prog = new Program();
            prog.WordSet(0);
            int t = prog.Try;
            prog.guessLetter("s");
            
            Assert.AreEqual(prog.Try, t);
        }
        [TestMethod]
        public void wrongWord()
        {
            var prog = new Program();
            prog.WordSet(0);
            int t = prog.Try;
            prog.guessWord("st");
            
            Assert.AreEqual(t-1, prog.Try);
        }
        [TestMethod]
        public void rightWord()
        {
            var prog = new Program();
            prog.WordSet(0);
            int t = prog.Try;
            prog.guessWord("sås");
            
            Assert.AreEqual(prog.Try, t);
        }
        
    }
}
